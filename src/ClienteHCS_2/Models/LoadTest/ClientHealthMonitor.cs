using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace ClienteHCS_2.Models.LoadTest
{
    /// <summary>
    /// Una muestra puntual de las métricas de salud del cliente durante el ensayo.
    /// </summary>
    public sealed class ClientHealthSnapshot
    {
        public int SegundoRelativo { get; set; }
        public double CpuPercent { get; set; }
        public double MemoryMB { get; set; }
        public int ThreadPoolWorkersBusy { get; set; }
        public int ThreadPoolIOCPBusy { get; set; }
        public int ThreadPoolPendingWorkItems { get; set; }
        public int GcGen0 { get; set; }
        public int GcGen1 { get; set; }
        public int GcGen2 { get; set; }
    }

    /// <summary>
    /// Resumen de salud del cliente al finalizar un ensayo.
    /// Incluye promedios, máximos y un veredicto sobre si el cliente se saturó.
    /// </summary>
    public sealed class ClientHealthReport
    {
        public List<ClientHealthSnapshot> Snapshots { get; set; } = new List<ClientHealthSnapshot>();

        public double CpuAvgPercent { get; set; }
        public double CpuMaxPercent { get; set; }
        public double MemoryAvgMB { get; set; }
        public double MemoryMaxMB { get; set; }
        public int ThreadPoolPendingMax { get; set; }
        public int ThreadPoolPendingAvg { get; set; }
        public int GcGen0Total { get; set; }
        public int GcGen1Total { get; set; }
        public int GcGen2Total { get; set; }

        /// <summary>
        /// Indica si se detectó saturación del cliente durante el ensayo.
        /// Un ensayo saturado no es confiable: las latencias y el throughput medidos
        /// pueden reflejar la limitación del cliente, no del servicio bajo prueba.
        /// </summary>
        public bool Saturado { get; set; }

        /// <summary>Detalle legible de las causas de saturación (si las hay).</summary>
        public string DetalleSaturacion { get; set; } = "";

        public override string ToString()
        {
            return
                $"CPU: avg {CpuAvgPercent:F1}% | max {CpuMaxPercent:F1}%\r\n" +
                $"Memoria: avg {MemoryAvgMB:F0} MB | max {MemoryMaxMB:F0} MB\r\n" +
                $"ThreadPool pending: avg {ThreadPoolPendingAvg} | max {ThreadPoolPendingMax}\r\n" +
                $"GC collections: Gen0={GcGen0Total} | Gen1={GcGen1Total} | Gen2={GcGen2Total}\r\n" +
                $"Saturado: {(Saturado ? "SÍ" : "No")}" +
                (Saturado ? $"\r\n{DetalleSaturacion}" : "");
        }
    }

    /// <summary>
    /// Monitorea la salud del cliente (CPU, memoria, ThreadPool, GC) durante un ensayo de carga.
    /// Se ejecuta en un timer de background y produce un <see cref="ClientHealthReport"/> al finalizar.
    /// </summary>
    internal sealed class ClientHealthMonitor : IDisposable
    {
        public const double CPU_AVG_THRESHOLD = 80.0;
        public const double CPU_MAX_THRESHOLD = 95.0;
        public const int THREADPOOL_PENDING_AVG_THRESHOLD = 10;
        public const int GC_GEN2_THRESHOLD = 5;

        private readonly Process _process;
        private readonly List<ClientHealthSnapshot> _snapshots = new List<ClientHealthSnapshot>();
        private readonly Stopwatch _stopwatch = new Stopwatch();
        private Timer _timer;
        private TimeSpan _lastCpuTime;
        private DateTime _lastWallTime;
        private readonly int _processorCount;
        private bool _disposed;

        /// <summary>Última muestra capturada. Se lee desde el hilo de UI para mostrar en tiempo real.</summary>
        public ClientHealthSnapshot UltimaSnapshot { get; private set; }

        public ClientHealthMonitor()
        {
            _process = Process.GetCurrentProcess();
            _processorCount = Environment.ProcessorCount;
        }

        /// <summary>Inicia el muestreo (una muestra por segundo).</summary>
        public void Iniciar()
        {
            _snapshots.Clear();
            _process.Refresh();
            _lastCpuTime = _process.TotalProcessorTime;
            _lastWallTime = DateTime.UtcNow;
            _stopwatch.Restart();
            _timer = new Timer(Muestrear, null, 1000, 1000);
        }

        /// <summary>Detiene el muestreo y genera el reporte final.</summary>
        public ClientHealthReport Detener()
        {
            _timer?.Change(Timeout.Infinite, Timeout.Infinite);
            _timer?.Dispose();
            _timer = null;
            _stopwatch.Stop();
            return GenerarReporte();
        }

        private void Muestrear(object state)
        {
            try
            {
                _process.Refresh();

                // CPU del proceso
                DateTime now = DateTime.UtcNow;
                TimeSpan currentCpu = _process.TotalProcessorTime;
                double elapsedCpuMs = (currentCpu - _lastCpuTime).TotalMilliseconds;
                double elapsedWallMs = (now - _lastWallTime).TotalMilliseconds;
                double cpuPercent = elapsedWallMs > 0
                    ? (elapsedCpuMs / (_processorCount * elapsedWallMs)) * 100.0
                    : 0;
                _lastCpuTime = currentCpu;
                _lastWallTime = now;

                // Memoria Working Set
                double memoryMB = _process.WorkingSet64 / (1024.0 * 1024.0);

                // ThreadPool
                ThreadPool.GetAvailableThreads(out int workerAvail, out int iocpAvail);
                ThreadPool.GetMaxThreads(out int workerMax, out int iocpMax);
                ThreadPool.GetMinThreads(out int workerMin, out _);
                int workerBusy = workerMax - workerAvail;
                int iocpBusy = iocpMax - iocpAvail;
                int pending = Math.Max(0, workerBusy - workerMin);

                // GC acumulado
                int gc0 = GC.CollectionCount(0);
                int gc1 = GC.CollectionCount(1);
                int gc2 = GC.CollectionCount(2);

                var snapshot = new ClientHealthSnapshot
                {
                    SegundoRelativo = (int)(_stopwatch.ElapsedMilliseconds / 1000),
                    CpuPercent = Math.Min(cpuPercent, 100.0),
                    MemoryMB = memoryMB,
                    ThreadPoolWorkersBusy = workerBusy,
                    ThreadPoolIOCPBusy = iocpBusy,
                    ThreadPoolPendingWorkItems = pending,
                    GcGen0 = gc0,
                    GcGen1 = gc1,
                    GcGen2 = gc2
                };

                UltimaSnapshot = snapshot;

                lock (_snapshots)
                {
                    _snapshots.Add(snapshot);
                }
            }
            catch
            {
                // No interrumpir el ensayo si falla una muestra
            }
        }

        private ClientHealthReport GenerarReporte()
        {
            List<ClientHealthSnapshot> snapshots;
            lock (_snapshots)
            {
                snapshots = new List<ClientHealthSnapshot>(_snapshots);
            }

            if (snapshots.Count == 0)
            {
                return new ClientHealthReport
                {
                    Snapshots = snapshots,
                    DetalleSaturacion = "Sin muestras de salud del cliente."
                };
            }

            double cpuAvg = snapshots.Average(s => s.CpuPercent);
            double cpuMax = snapshots.Max(s => s.CpuPercent);
            double memAvg = snapshots.Average(s => s.MemoryMB);
            double memMax = snapshots.Max(s => s.MemoryMB);
            int pendingAvg = (int)snapshots.Average(s => s.ThreadPoolPendingWorkItems);
            int pendingMax = snapshots.Max(s => s.ThreadPoolPendingWorkItems);

            int gc0Total = snapshots.Last().GcGen0 - snapshots.First().GcGen0;
            int gc1Total = snapshots.Last().GcGen1 - snapshots.First().GcGen1;
            int gc2Total = snapshots.Last().GcGen2 - snapshots.First().GcGen2;

            var causas = new List<string>();
            if (cpuAvg >= CPU_AVG_THRESHOLD)
                causas.Add($"CPU promedio alta: {cpuAvg:F1}% (umbral: {CPU_AVG_THRESHOLD}%)");
            if (cpuMax >= CPU_MAX_THRESHOLD)
                causas.Add($"CPU pico: {cpuMax:F1}% (umbral: {CPU_MAX_THRESHOLD}%)");
            if (pendingAvg >= THREADPOOL_PENDING_AVG_THRESHOLD)
                causas.Add($"ThreadPool con presion sostenida: avg pending {pendingAvg} (umbral: {THREADPOOL_PENDING_AVG_THRESHOLD})");
            if (gc2Total >= GC_GEN2_THRESHOLD)
                causas.Add($"GC Gen2 elevado: {gc2Total} collections (umbral: {GC_GEN2_THRESHOLD})");

            bool saturado = causas.Count > 0;

            return new ClientHealthReport
            {
                Snapshots = snapshots,
                CpuAvgPercent = cpuAvg,
                CpuMaxPercent = cpuMax,
                MemoryAvgMB = memAvg,
                MemoryMaxMB = memMax,
                ThreadPoolPendingAvg = pendingAvg,
                ThreadPoolPendingMax = pendingMax,
                GcGen0Total = gc0Total,
                GcGen1Total = gc1Total,
                GcGen2Total = gc2Total,
                Saturado = saturado,
                DetalleSaturacion = saturado
                    ? string.Join("\r\n", causas.ToArray())
                    : ""
            };
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
            _timer?.Dispose();
        }
    }
}
