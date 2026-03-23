using System;
using System.IO;

namespace ClienteHCS_2
{
    public class Transaction
    {
        private const string FILE_FIELDS_SAPARATOR = "|@|";

        public string Mensaje { get; set; }
        public string TXFile { get; set; }
        public bool EsHexa { get; set; }
        public string Descripcion { get; set; }

        public Transaction()
        {
        }

        public Transaction(string mensaje, string tXFile, bool esHexa, string descripcion)
        {
            Mensaje = mensaje;
            TXFile = tXFile;
            EsHexa = esHexa;
            Descripcion = descripcion;
        }


        public void SaveToFile(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(TXFile + FILE_FIELDS_SAPARATOR + Mensaje + FILE_FIELDS_SAPARATOR + EsHexa.ToString() + FILE_FIELDS_SAPARATOR + Descripcion);
            }
        }


        public void LoadFromFile(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(fileContent)) throw new Exception("El archivo es nulo o en blanco");

            string[] contenido = fileContent.Split(new string[] { "|@|" }, StringSplitOptions.None);

            if (contenido.Length < 4) throw new Exception("La estructura del archivo en incorrecta");

            if (!bool.TryParse(contenido[2], out bool isHexa)) throw new Exception("La estructura del archivo es incorrecta. La marca de Hexa debe ser un dato tipo boolean");

            this.TXFile = contenido[0];
            this.Mensaje = contenido[1];
            this.EsHexa = isHexa;
            this.Descripcion = contenido[3];
        }


        public bool Validar(out string msjeError)
        {
            if (this.Mensaje == "")
            {
                msjeError = "El campo Mensaje no puede ser un valor nulo";
                return false;
            }

            if (string.IsNullOrEmpty(this.TXFile))
            {
                msjeError = "El campo archivo TXFile no puede ser un valor nulo";
                return false;
            }

            if (EsHexa)
            {
                if (!IsHexadecimal(this.Mensaje, out string errorMessage))
                {
                    msjeError = $"El campo Mensaje no es valido para una transaccion HEXA.\n{errorMessage}" +
                        $"\nLos mensajes en HEXA no pueden contener ESPACIOS EN BLANCO ni SALTOS DE LINEA y deben tener una cantidad PAR de caracteres";
                    return false;
                }
            }

            msjeError = "";
            return true;
        }


        static bool IsHexadecimal(string input, out string errorMessage)
        {
            if (input.Length % 2 != 0)
            {
                errorMessage = "La longitud de la cadena debe ser par.";
                return false;
            }

            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (!((c >= '0' && c <= '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f')))
                {
                    errorMessage = "La cadena tiene caracteres no validos para un hexa";
                    return false;
                }
            }

            errorMessage = "";
            return true;
        }

    }
}
