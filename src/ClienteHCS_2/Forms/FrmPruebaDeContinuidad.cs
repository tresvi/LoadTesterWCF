using System;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace ClienteHCS_2
{
    public partial class FrmPruebaDeContinuidad : Form
    {
        private readonly string _server;
        private readonly Transaction _transaccion;
        private readonly NetworkCredential _networkCredential;

        HCSClient _hcsClient = null;
        decimal _duration;
        int _periodoEnvioDatosmSeg;
        static bool _ensayoEnCurso = false;
        int _contadorConexiones, _contadorOK, _contadorFAIL = 0;
        object lockObject = new object();
        Thread _taskEnsayo;
        Stopwatch _timerEnsayo;


        public FrmPruebaDeContinuidad(string server, Transaction transaccion, NetworkCredential networkCredential)
        {
            InitializeComponent();
            _transaccion = transaccion;
            _server = server;
            _networkCredential = networkCredential;

            string usuario;
            if (networkCredential.UserName == "")
                usuario = $@"{Environment.UserDomainName}\{Environment.UserName}";
            else
                usuario = $@"{networkCredential.Domain}\{networkCredential.UserName}";

            lblServer.Text = $"Server: {_server}";
            lblTxFile.Text = $"TxFile: {transaccion.TXFile}";
            lblTransaccion.Text = $"Transaccion: {transaccion.Mensaje}";
            lblCredenciales.Text = $"Credenciales: {usuario}";
        }


        public FrmPruebaDeContinuidad()
        {
            InitializeComponent();
        }


        private void btnIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                btnIniciar.Enabled = nudDuracion.Enabled = nudPeriodoEnvioDatos.Enabled = false;
                btnFinalizar.Enabled = true;
                txtSalida.Text = "";
                _timerEnsayo = new Stopwatch();

                ThreadStart threadStart = new ThreadStart(TaskEnviarRecibir);
                _contadorConexiones = _contadorOK = _contadorFAIL = 0;
                _duration = nudDuracion.Value;
                _periodoEnvioDatosmSeg = (int)(nudPeriodoEnvioDatos.Value * 1000);
                _taskEnsayo = new Thread(threadStart);
                _taskEnsayo.Start();
                _timerEnsayo.Start();
                _ensayoEnCurso = true;

                WriteLog($"+++++++++++++++++ INICIANDO Ensayo de Continuidad +++++++++++++++++");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar el ensayo. Detalles {ex.Message}"
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIniciar.Enabled = true;
                nudDuracion.Enabled = true;
                nudPeriodoEnvioDatos.Enabled = true;
            }
        }


        public void TaskEnviarRecibir()
        {
            Stopwatch sw = new Stopwatch();
            bool esPrimerEnvio;

            while (_ensayoEnCurso)
            {
                UpdateCountersLabel();
                try
                {
                    esPrimerEnvio = true;
                    WriteLog($"Iniciando conexion {++_contadorConexiones} ");
                    _hcsClient = new HCSClient(_server, _networkCredential);

                    sw.Start();
                    while (sw.ElapsedMilliseconds / 1000 < _duration && _ensayoEnCurso)
                    {
                        _hcsClient.EnviarYRecibir(_transaccion, false).GetAwaiter().GetResult();
                        Thread.Sleep(_periodoEnvioDatosmSeg);
                        if (esPrimerEnvio)
                        {
                            WriteLog($"Conexion {_contadorConexiones} establecida OK. Se continua transmitiendo por {_duration} segundos...");
                            esPrimerEnvio = false;
                        }
                    }
                    lock (lockObject) { ++_contadorOK; }
                    WriteLog($"Conexion {_contadorConexiones} Finalizo OK en {sw.ElapsedMilliseconds} ms");
                    _hcsClient.Cerrar();
                }
                catch (Exception ex)
                {
                    _hcsClient.Cerrar();
                    lock (lockObject) { ++_contadorFAIL; }
                    WriteLog($"!!!!!!Conexion {_contadorConexiones} finalizo con ERROR en {sw.ElapsedMilliseconds} ms. Detalles: {ex.Message}");
                    WriteLog("Esperando 3 seg. antes de continuar...");
                    Thread.Sleep(2000);
                }
                sw.Stop();
                sw.Reset();
            }
        }


        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            FinalizarEnsayo();
        }


        private void FrmPruebaDeContinuidad_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_ensayoEnCurso)
            {
                _ensayoEnCurso = false;
                _hcsClient?.Cerrar();
            }
        }


        private void WriteLog(string text)
        {
            text = $"{DateTime.Now.ToString("hh:mm:ss")} --> {text}";
            WriteOutput(text);
        }


        private void UpdateCountersLabel()
        {
            WriteLabel(_contadorOK.ToString(), lblConexionesOK);
            WriteLabel(_contadorFAIL.ToString(), lblConexionesFail);
        }

        private void btnCopiarPortapapeles_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtSalida.Text);
        }

        private void FrmPruebaDeContinuidad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_ensayoEnCurso) return;

            DialogResult dialogResult = MessageBox.Show(
                "Hay un ensayo en curso, debe finalizarlo para salir. Desea finalizarlo ahora?"
                , "Detener ensayo de continuidad"
                , MessageBoxButtons.YesNo
                , MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes) FinalizarEnsayo();

            e.Cancel = true;
        }

        private void FinalizarEnsayo()
        {
            _ensayoEnCurso = false;

            WriteLog($"+++++++++++++++++ FINALIZANDO Ensayo de Continuidad +++++++++++++++++. Duracion Total: {_timerEnsayo.ElapsedMilliseconds / 1000} seg");
            Thread.Sleep(3 * _periodoEnvioDatosmSeg);
            UpdateCountersLabel();

            MessageBox.Show($"Prueba Finalizada." +
                $"\nIntentos de conexion: {_contadorConexiones}" +
                $"\nFinalizados OK: {_contadorOK}" +
                $"\nFinalizados FAIL: {_contadorFAIL}" +
                $"\nTiempo: {_timerEnsayo.ElapsedMilliseconds / 1000} Seg.");
            btnFinalizar.Enabled = false;
            btnIniciar.Enabled = nudDuracion.Enabled = nudPeriodoEnvioDatos.Enabled = true;
        }

        delegate void WriteOutputCallback(string msje);
        private void WriteOutput(string text)
        {
            if (txtSalida.InvokeRequired)
            {
                WriteOutputCallback d = new WriteOutputCallback(WriteOutput);
                this.BeginInvoke(d, new object[] { text });
            }
            else
            {
                txtSalida.AppendText(text + Environment.NewLine);
            }
        }


        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, $"Se abrirá una unica conexión a HCS que tendrá la duración configurada. Dicha " +
                $"conexión enviará una transacción a HCS cada X segundos (configurado en el campo 'Intervalo de Envios'). " +
                $"La transacción enviada, será la elegida en la pantalla principal. " +
                $"Al finalizar la conexión, se abrirá una nueva, siguiendo el ciclo indefinidamente hasta que se presione " +
                $"el botnón 'Finalizar'.", "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        delegate void UpdateCountersLabelsCallback(string msje, Label labelToWrite);
        private void WriteLabel(string text, Label label)
        {
            if (label.InvokeRequired)
            {
                UpdateCountersLabelsCallback d = new UpdateCountersLabelsCallback(WriteLabel);
                this.BeginInvoke(d, new object[] { text, label });
            }
            else
            {
                label.Text = text;
            }
        }


    }
}
