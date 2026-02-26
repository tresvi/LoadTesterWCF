using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteHCS_2.Models.LoadTest
{
    /// <summary>
    /// Resultado de un hilo individual al finalizar.
    /// </summary>
    internal sealed class LoadTestThreadResult
    {
        public int RowIndex { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool StatusOk { get; set; }
        public string FailureReason { get; set; }
        public long LatAvg { get; set; }
        public long LatMin { get; set; }
        public long LatMax { get; set; }
        public int TrxOK { get; set; }
        public int TrxFail { get; set; }
        public double ThroughputOK { get; set; }
        public double ThroughputTotal { get; set; }
    }
}
