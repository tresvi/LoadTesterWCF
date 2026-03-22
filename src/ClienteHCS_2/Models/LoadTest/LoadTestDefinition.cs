using System;

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

        public bool UsarRampa { get; set; }
        public int IncrementoHilos { get; set; }
        public double IntervaloRampaSeg { get; set; }

        /// <summary>Texto de configuración para mostrar en resúmenes (Servidor, TxFile, Nro hilos, etc.).</summary>
        public string ToConfigString()
        {
            var s = $"Servidor: {Server}\r\nTxFile: {TxFile}\r\nNro hilos: {NroHilos}\r\nDuración (seg): {DuracionSeg}\r\nPausa entre envíos (ms): {PausaMs}\r\nÚnica conexión para todos los hilos: {(UsarUnicaConexion ? "Sí" : "No")}";
            if (UsarRampa)
                s += $"\r\nRampa: de {IncrementoHilos} hilos cada {IntervaloRampaSeg} seg";
            return s;
        }

        /// <summary>
        /// Duración estimada del ensayo completo (rampa + duración por hilo).
        /// En modo sin rampa, coincide con <see cref="DuracionSeg"/>.
        /// </summary>
        public double CalcularDuracionEstimadaSeg()
        {
            if (!UsarRampa || IncrementoHilos <= 0 || IntervaloRampaSeg <= 0)
                return DuracionSeg;
            int pasos = (int)Math.Ceiling((double)NroHilos / IncrementoHilos);
            double tiempoRampa = (pasos - 1) * IntervaloRampaSeg;
            return tiempoRampa + DuracionSeg;
        }

        /// <summary>Crea una copia de esta definición.</summary>
        public LoadTestDefinition Copy() => new LoadTestDefinition
        {
            Server = Server,
            TxFile = TxFile,
            NroHilos = NroHilos,
            DuracionSeg = DuracionSeg,
            PausaMs = PausaMs,
            UsarUnicaConexion = UsarUnicaConexion,
            UsarRampa = UsarRampa,
            IncrementoHilos = IncrementoHilos,
            IntervaloRampaSeg = IntervaloRampaSeg
        };
    }
}
