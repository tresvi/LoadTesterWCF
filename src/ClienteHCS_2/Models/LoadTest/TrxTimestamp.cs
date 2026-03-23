namespace ClienteHCS_2
{
    /// <summary>
    /// Registro del instante (relativo al inicio del ensayo) en que se complet� una transacci�n exitosa.
    /// Se usa para construir la curva de throughput en funci�n del tiempo.
    /// </summary>
    public struct TrxTimestamp
    {
        /// <summary>Segundo relativo al inicio del ensayo (truncado a entero).</summary>
        public int SegundoRelativo { get; set; }

        /// <summary>N�mero de hilo que complet� la transacci�n (1-based).</summary>
        public int NroHilo { get; set; }

        /// <summary>Latencia de la transacci�n en milisegundos.</summary>
        public long LatenciaMs { get; set; }
    }
}
