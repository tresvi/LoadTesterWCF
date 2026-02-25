namespace ClienteHCS_2
{
    /// <summary>
    /// Registro del instante (relativo al inicio del ensayo) en que se completó una transacción exitosa.
    /// Se usa para construir la curva de throughput en función del tiempo.
    /// </summary>
    public sealed class TrxTimestamp
    {
        /// <summary>Segundo relativo al inicio del ensayo (truncado a entero).</summary>
        public int SegundoRelativo { get; set; }

        /// <summary>Número de hilo que completó la transacción (1-based).</summary>
        public int NroHilo { get; set; }
    }
}
