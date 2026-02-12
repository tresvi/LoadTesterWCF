namespace ClienteHCS_2
{
    /// <summary>
    /// Parámetros de configuración del ensayo de carga, definidos antes de iniciar.
    /// </summary>
    public class LoadTestDefinition
    {
        public string Server { get; set; } = "";
        public string TxFile { get; set; } = "";
        public int NroHilos { get; set; }
        public double DuracionSeg { get; set; }
        public int PausaMs { get; set; }
        public bool UsarUnicaConexion { get; set; }

        /// <summary>Texto de configuración para mostrar en resúmenes (Servidor, TxFile, Nro hilos, etc.).</summary>
        public string ToConfigString() =>
            $"Servidor: {Server}\r\nTxFile: {TxFile}\r\nNro hilos: {NroHilos}\r\nDuración (seg): {DuracionSeg}\r\nPausa entre envíos (ms): {PausaMs}\r\nÚnica conexión para todos los hilos: {(UsarUnicaConexion ? "Sí" : "No")}";

        /// <summary>Crea una copia de esta definición.</summary>
        public LoadTestDefinition Copy() => new LoadTestDefinition
        {
            Server = Server,
            TxFile = TxFile,
            NroHilos = NroHilos,
            DuracionSeg = DuracionSeg,
            PausaMs = PausaMs,
            UsarUnicaConexion = UsarUnicaConexion
        };
    }
}
