using ClienteHCS_2.HCS;
using System;
using System.Collections.Generic;
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClienteHCS_2
{
    /// <summary>
    /// Se evaluaron las siguientes coodificaciones:  
    /// Encoding.ASCII.GetBytes(), no sirve para caracteres extendidos como la Ñ, ya que los reemplaza por un caracter '?'
    /// Encoding.Default.GetBytes(), codifica bien la Ñ, pero puede cambiar con la configuracion de windows. En este caso sirvio porque la default era la windows-1252
    /// Encoding.UTF8.GetBytes(), codifica bien la Ñ pero al convertirla a EDCDIC, utiliza otros caracteres que no son reconocidos por mainframe
    /// Encoding.GetEncoding("Windows-1252").GetBytes(), es la elegida en base a lo obtenido con la codificacion Default usando Encoding. Default.EncodingName
    /// </summary>

    class HCSClient : IDisposable
    {
        private const string WINDOWS_ENCODING = "Windows-1252";
        private const int HOST_ANSI_CODEPAGE = 20284;

        private readonly Encoding _windowsEncoding;
        private ConectorBrokerWCFClient _client;
        private readonly Encoding _hostEncoding;

        private static long _txCounter = 0;

        public HCSClient(string hcsServer, NetworkCredential networkCredentials)
        {
            _client = new ConectorBrokerWCFClient("NetTcpBinding_IConectorBrokerWCF");
            _client.Endpoint.Address = new EndpointAddress(new Uri($"net.tcp://{hcsServer}/BNA.FU.HCS/ConectorBrokerWCF"));
            _client.ClientCredentials.Windows.ClientCredential = networkCredentials;
            _windowsEncoding = Encoding.GetEncoding(WINDOWS_ENCODING);
            _hostEncoding = Encoding.GetEncoding(HOST_ANSI_CODEPAGE);
        }


        public async Task<List<string>> EnviarYRecibir(Transaction transaccion, bool cerrarConexionAlTerminar = true, string messageId = null)
        {
            List<string> respuesta = new List<string>();
            HCS.WCFMensaje[] wcfresp;
            HCS.WCFMensaje wcfmsg;

            try
            {
                wcfmsg = new HCS.WCFMensaje();
                wcfmsg.Contenido = transaccion.EsHexa ? ConvertHexStringToBytes(transaccion.Mensaje) : _windowsEncoding.GetBytes(transaccion.Mensaje);
                if (!string.IsNullOrEmpty(messageId))
                    wcfmsg.ID = messageId;
                wcfresp = await _client.EnviarRecibirAsync(wcfmsg, transaccion.TXFile);
                Interlocked.Increment(ref _txCounter);
                if (cerrarConexionAlTerminar) _client.Close();

                foreach (HCS.WCFMensaje mensaje in wcfresp)
                {
                    ReemplazarCaracteresNulosInPlace(mensaje.Contenido, 32);

                    if (transaccion.EsHexa)
                        respuesta.Add(_hostEncoding.GetString(mensaje.Contenido));
                    else
                        respuesta.Add(_windowsEncoding.GetString(mensaje.Contenido));
                }
                return respuesta;
            }
            catch (Exception e)
            {
                //Para cuando hay fallas que no deben cerrar la conexion porque 
                //no se deben al falla del canal, como por ejemplo MQRC_NO_MSGE_AVAILABLE
                //El canal debe seguir abierto si era lo que se le pidio al cliente.
                if (cerrarConexionAlTerminar) _client?.Abort();
                throw;
            }
        }

        public static long GetTransmisiones()
        {
            return _txCounter;
        }

        public static void ResetTxCounter()
        {
            Interlocked.Exchange(ref _txCounter, 0);
        }


        public void Cerrar()
        {
            if (_client == null) return;

            try
            {
                if (_client.State == CommunicationState.Opened)
                    _client.Close();
            }
            catch { }
            finally
            {
                _client.Abort();
                _client = null;
            }
        }
        //Abort() cierra la conexion si estuviera abierta. Close la cierra, pero previamente hay que preguntar si esta abierta, si no lanza una Exception


        public void Dispose()
        {
            Cerrar();
        }


        static byte[] ConvertHexStringToBytes(string hexString)
        {
            if (hexString.Length % 2 != 0)
                throw new ArgumentException("La longitud de la cadena debe ser par.");

            byte[] byteArray = new byte[hexString.Length / 2];

            // Itero sobre la cadena de a 2 caracteres y convierto a bytes
            for (int i = 0; i < hexString.Length; i += 2)
            {
                byteArray[i / 2] = Convert.ToByte(hexString.Substring(i, 2), 16);
            }

            return byteArray;
        }


        static void ReemplazarCaracteresNulosInPlace(byte[] rawArray, byte reemplazo)
        {
            if (rawArray == null) return;

            for (int i = 0; i < rawArray.Length; i++)
            {
                if (rawArray[i] == 0)
                    rawArray[i] = reemplazo;
            }
        }
    }
}