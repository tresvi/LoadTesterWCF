using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using ClienteHCS_2.Models.LoadTest;

namespace ClienteHCS_2
{
    /// <summary>
    /// Orquesta la ejecución de un ensayo de carga: warm-up, lanzamiento de hilos,
    /// recolección de latencias/timestamps y generación del reporte final.
    /// Reporta progreso y resultados por hilo mediante eventos, sin depender de la UI.
    /// </summary>
    internal sealed class LoadTestRunner
    {
        private readonly LoadTestDefinition _definition;
        private readonly Transaction _transaccion;
        private readonly NetworkCredential _credential;

        private Task[] _tasks;
        private Stopwatch _timerEnsayo;
        private int _countArranque;
        private TaskCompletionSource<bool> _tcsArranque;
        private bool _useASingleConnection;
        private HCSClient _sharedClient;
        private volatile bool _abortRequested;

        private int _contadorOK;
        private int _contadorFAIL;
        private long _contadorSinRespuesta;
        private ConcurrentBag<long> _latencies;
        private ConcurrentBag<TrxTimestamp> _timestamps;
        private string _correlationIDBase;

        /// <summary>Indica si el ensayo está en curso.</summary>
        public bool EnCurso { get; private set; }

        /// <summary>Milisegundos transcurridos desde el inicio del ensayo.</summary>
        public long ElapsedMs => _timerEnsayo?.ElapsedMilliseconds ?? 0;

        /// <summary>Cantidad de tareas que aún no finalizaron.</summary>
        public int TareasPendientes
        {
            get
            {
                if (_tasks == null) return 0;
                int count = 0;
                for (int i = 0; i < _tasks.Length; i++)
                    if (!_tasks[i].IsCompleted) count++;
                return count;
            }
        }

        /// <summary>True cuando todas las tareas finalizaron.</summary>
        public bool TodasFinalizadas => _tasks != null && TareasPendientes == 0;

        #region Eventos

        /// <summary>Se dispara cuando un hilo inicia (para actualizar la grilla).</summary>
        public event Action<int, int, string> OnHiloIniciado;

        /// <summary>Se dispara cuando un hilo finaliza con sus resultados.</summary>
        public event Action<LoadTestThreadResult> OnHiloFinalizado;

        /// <summary>Se dispara cuando todo el ensayo finaliza.</summary>
        public event Action<LoadTestReport, IList<LoadTestThreadItem>> OnEnsayoFinalizado;

        #endregion

        public LoadTestRunner(LoadTestDefinition definition, Transaction transaccion, NetworkCredential credential)
        {
            _definition = definition ?? throw new ArgumentNullException(nameof(definition));
            _transaccion = transaccion ?? throw new ArgumentNullException(nameof(transaccion));
            _credential = credential ?? throw new ArgumentNullException(nameof(credential));
        }

        /// <summary>
        /// Ejecuta una transmisión de prueba para validar parámetros y calentar la conexión.
        /// Lanza excepción si falla.
        /// </summary>
        public async Task WarmUpAsync()
        {
            using (var client = new HCSClient(_definition.Server, _credential))
            {
                await client.EnviarYRecibir(_transaccion, cerrarConexionAlTerminar: true);
            }
        }

        /// <summary>
        /// Inicia el ensayo de carga. Lanza los hilos y retorna inmediatamente.
        /// Usar <see cref="TodasFinalizadas"/> o <see cref="OnEnsayoFinalizado"/> para detectar fin.
        /// </summary>
        public IList<LoadTestThreadItem> Iniciar()
        {
            if (EnCurso) throw new InvalidOperationException("Ya hay un ensayo en curso.");

            _abortRequested = false;
            _contadorOK = 0;
            _contadorFAIL = 0;
            _contadorSinRespuesta = 0;
            _latencies = new ConcurrentBag<long>();
            _timestamps = new ConcurrentBag<TrxTimestamp>();

            var items = new List<LoadTestThreadItem>();
            for (int i = 0; i < _definition.NroHilos; i++)
                items.Add(new LoadTestThreadItem { ThreadNum = i + 1 });

            _tasks = new Task[_definition.NroHilos];
            _countArranque = _definition.NroHilos;
            _tcsArranque = new TaskCompletionSource<bool>();
            HCSClient.ResetTxCounter();

            _useASingleConnection = _definition.UsarUnicaConexion;
            if (_useASingleConnection)
                _sharedClient = new HCSClient(_definition.Server, _credential);

            _correlationIDBase = DateTime.Now.ToString("HHmmss-ffff");

            _timerEnsayo = new Stopwatch();
            _timerEnsayo.Start();
            EnCurso = true;

            for (int i = 0; i < _definition.NroHilos; i++)
            {
                int nroTarea = i + 1;
                _tasks[i] = RunVirtualUserAsync(nroTarea, _correlationIDBase, items[nroTarea - 1]);
            }

            return items;
        }

        /// <summary>
        /// Solicita la cancelación del ensayo. Los hilos finalizarán en cuanto puedan.
        /// </summary>
        public void Abortar()
        {
            _abortRequested = true;
        }

        /// <summary>
        /// Finaliza el ensayo: cierra recursos, genera el reporte y dispara <see cref="OnEnsayoFinalizado"/>.
        /// Debe llamarse desde el hilo de UI cuando <see cref="TodasFinalizadas"/> es true.
        /// </summary>
        public LoadTestReport Finalizar(IList<LoadTestThreadItem> items)
        {
            _timerEnsayo.Stop();
            if (_useASingleConnection)
                _sharedClient?.Cerrar();

            EnCurso = false;

            long transmisiones = HCSClient.GetTransmisiones();
            long tiempoMs = _timerEnsayo.ElapsedMilliseconds;

            var report = LoadTestReport.Create(
                latencias: _latencies,
                hilos: items,
                loadTestDefinition: _definition,
                finalizadosOK: _contadorOK,
                finalizadosFAIL: _contadorFAIL,
                transmisionesSinRespuesta: _contadorSinRespuesta,
                transmisionesCompletadas: transmisiones,
                tiempoMs: tiempoMs,
                correlationIDBase: _correlationIDBase,
                timestamps: _timestamps);

            OnEnsayoFinalizado?.Invoke(report, items);

            return report;
        }

        private async Task RunVirtualUserAsync(int nroTarea, string correlationIDBase, LoadTestThreadItem item)
        {
            await Task.Yield();

            string correlationIdTarea = correlationIDBase + "-" + nroTarea.ToString("D4");
            OnHiloIniciado?.Invoke(nroTarea - 1, nroTarea, correlationIdTarea);

            var latenciasHilo = new List<long>();
            int trxOk = 0, trxFail = 0;
            Stopwatch sw = Stopwatch.StartNew();
            HCSClient client = null;
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime;
            bool ok = false;
            string failureReason = "";
            int nroTransmision = 0;

            try
            {
                client = _useASingleConnection ? _sharedClient : new HCSClient(_definition.Server, _credential);

                if (Interlocked.Decrement(ref _countArranque) == 0)
                    _tcsArranque.TrySetResult(true);

                await _tcsArranque.Task;

                startTime = DateTime.Now;

                sw.Restart();
                while ((sw.ElapsedMilliseconds / 1000 < _definition.DuracionSeg) && !_abortRequested)
                {
                    string correlationId = $"{correlationIdTarea}-{nroTransmision++}";
                    Stopwatch reqSw = Stopwatch.StartNew();
                    try
                    {
                        await client.EnviarYRecibir(_transaccion, false, correlationId);
                        reqSw.Stop();
                        long ms = reqSw.ElapsedMilliseconds;
                        latenciasHilo.Add(ms);
                        _latencies.Add(ms);
                        _timestamps.Add(new TrxTimestamp
                        {
                            SegundoRelativo = (int)(sw.ElapsedMilliseconds / 1000),
                            NroHilo = nroTarea
                        });
                        trxOk++;
                    }
                    catch
                    {
                        reqSw.Stop();
                        trxFail++;
                        Interlocked.Increment(ref _contadorSinRespuesta);
                        throw;
                    }
                    if (_definition.PausaMs > 0)
                        await Task.Delay(_definition.PausaMs);
                }
                endTime = DateTime.Now;
                ok = true;
                Interlocked.Increment(ref _contadorOK);
            }
            catch (Exception ex)
            {
                endTime = DateTime.Now;
                Interlocked.Increment(ref _contadorFAIL);
                failureReason = ex.Message ?? ex.ToString();
                if (failureReason.Length > 500)
                    failureReason = failureReason.Substring(0, 497) + "...";
            }
            finally
            {
                if (!_useASingleConnection) client?.Cerrar();
            }

            double durationSec = (endTime - startTime).TotalSeconds;
            long latMin = latenciasHilo.Count > 0 ? latenciasHilo.Min() : 0;
            long latMax = latenciasHilo.Count > 0 ? latenciasHilo.Max() : 0;
            long latAvg = latenciasHilo.Count > 0 ? (long)latenciasHilo.Average() : 0;
            double thrOk = durationSec > 0 ? trxOk / durationSec : 0;
            double thrTotal = durationSec > 0 ? (trxOk + trxFail) / durationSec : 0;

            LoadTestThreadResult result = new LoadTestThreadResult
            {
                RowIndex = nroTarea - 1,
                StartTime = startTime,
                EndTime = endTime,
                StatusOk = ok,
                FailureReason = failureReason,
                LatAvg = latAvg,
                LatMin = latMin,
                LatMax = latMax,
                TrxOK = trxOk,
                TrxFail = trxFail,
                ThroughputOK = thrOk,
                ThroughputTotal = thrTotal
            };

            OnHiloFinalizado?.Invoke(result);
        }
    }

}
