using System.ComponentModel;

namespace ClienteHCS_2
{
    /// <summary>
    /// Modelo de una fila del DataGridView de prueba de carga (un hilo/tarea).
    /// Implementa INotifyPropertyChanged para que la grilla se actualice al cambiar propiedades.
    /// </summary>
    public class LoadTestThreadItem : INotifyPropertyChanged
    {
        private int _threadNum;
        private string _corrID = "";
        private string _startTime = "";
        private string _endTime = "";
        private string _status = "";
        private string _failureReason = "";
        private bool _statusOk;
        private long _latAvg;
        private long _latMin;
        private long _latMax;
        private int _trxOK;
        private int _trxFail;
        private double _throughputOK;
        private double _throughputTotal;

        public int ThreadNum
        {
            get => _threadNum;
            set { _threadNum = value; OnPropertyChanged(nameof(ThreadNum)); }
        }

        public string CorrID
        {
            get => _corrID;
            set { _corrID = value ?? ""; OnPropertyChanged(nameof(CorrID)); }
        }

        public string StartTime
        {
            get => _startTime;
            set { _startTime = value ?? ""; OnPropertyChanged(nameof(StartTime)); }
        }

        public string EndTime
        {
            get => _endTime;
            set { _endTime = value ?? ""; OnPropertyChanged(nameof(EndTime)); }
        }

        public string Status
        {
            get => _status;
            set { _status = value ?? ""; OnPropertyChanged(nameof(Status)); }
        }

        /// <summary>
        /// Motivo del fallo cuando el hilo termina en FAIL.
        /// </summary>
        public string FailureReason
        {
            get => _failureReason;
            set { _failureReason = value ?? ""; OnPropertyChanged(nameof(FailureReason)); }
        }

        /// <summary>
        /// Indica si el hilo terminó OK (para colorear la celda Status).
        /// </summary>
        public bool StatusOk
        {
            get => _statusOk;
            set { _statusOk = value; OnPropertyChanged(nameof(StatusOk)); }
        }

        public long LatAvg
        {
            get => _latAvg;
            set { _latAvg = value; OnPropertyChanged(nameof(LatAvg)); }
        }

        public long LatMin
        {
            get => _latMin;
            set { _latMin = value; OnPropertyChanged(nameof(LatMin)); }
        }

        public long LatMax
        {
            get => _latMax;
            set { _latMax = value; OnPropertyChanged(nameof(LatMax)); }
        }

        public int TrxOK
        {
            get => _trxOK;
            set { _trxOK = value; OnPropertyChanged(nameof(TrxOK)); }
        }

        public int TrxFail
        {
            get => _trxFail;
            set { _trxFail = value; OnPropertyChanged(nameof(TrxFail)); }
        }

        public double ThroughputOK
        {
            get => _throughputOK;
            set { _throughputOK = value; OnPropertyChanged(nameof(ThroughputOK)); }
        }

        public double ThroughputTotal
        {
            get => _throughputTotal;
            set { _throughputTotal = value; OnPropertyChanged(nameof(ThroughputTotal)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
