using System;
using System.Collections.Concurrent;
using ClienteHCS_2.Helpers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteHCS_2
{
    public partial class FrmPruebaDeCarga : Form
    {
        private readonly string _server;
        private readonly Transaction _transaccion;
        private readonly NetworkCredential _networkCredential;

        /// <summary>Definición del ensayo (se crea al iniciar).</summary>
        LoadTestDefinition _loadTestDefinition;
        int _contador, _contadorOK, _contadorFAIL = 0;
        long _contadorSinRespuesta = 0;  // transmisiones que no recibieron respuesta (excepción)
        Task[] _tasks;
        Stopwatch _timerEnsayo;
        int _countArranque;
        TaskCompletionSource<bool> _tcsArranque;
        bool _useASingleConnection = false;
        bool _abortImmediatly = false;
        HCSClient _hcsClient;
        ConcurrentBag<long> _latencies = new ConcurrentBag<long>();
        ConcurrentBag<TrxTimestamp> _timestamps = new ConcurrentBag<TrxTimestamp>();
        SortableBindingList<LoadTestThreadItem> _listaHilos = new SortableBindingList<LoadTestThreadItem>();
        string _correlationIDBase;

        /// <summary>
        /// Último reporte generado (para exportar y mostrar en UI).
        /// </summary>
        LoadTestReport _lastReport;


        public FrmPruebaDeCarga(string server, Transaction transaccion, NetworkCredential networkCredential)
        {
            _transaccion = transaccion;
            _server = server;
            _networkCredential = networkCredential;
            InitializeComponent();

            // Doble búfer para que el DataGridView se dibuje más fluido al hacer scroll
            var prop = typeof(Control).GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            prop?.SetValue(dgvHilos, true, null);

            dgvHilos.DataSource = _listaHilos;
            dgvHilos.CellFormatting += dgvHilos_CellFormatting;
            // Ocultar columna StatusOk (el color de fila ya indica OK/FAIL; no hace falta mostrarla)
            var colStatusOk = dgvHilos.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.DataPropertyName == "StatusOk");
            if (colStatusOk != null)
                colStatusOk.Visible = false;
            // Una sola columna Failure Reason, siempre como última columna
            var colFailure = dgvHilos.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.DataPropertyName == "FailureReason");
            if (colFailure != null)
            {
                dgvHilos.Columns.Remove(colFailure);
                dgvHilos.Columns.Add(colFailure);
            }
            else
            {
                dgvHilos.Columns.Add(new DataGridViewTextBoxColumn
                {
                    Name = "colFailureReason",
                    DataPropertyName = "FailureReason",
                    HeaderText = "Failure Reason",
                    ReadOnly = true,
                    Width = 220
                });
            }

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


        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, $"Se ejecutarán simultáneamente la cantidad de hilos configurada; cada hilo tendrá la " +
                $"duración en segundos seleccionada.\nCada hilo enviará transacciones a HCS de forma continua (esperando " +
                $"cada respuesta antes de la siguiente), con la pausa configurada en \"Pausa entre envíos (ms)\" entre cada envío " +
                $"(0 = sin pausa).\nCada hilo abrirá su propia conexión hacia el servidor, a menos que se habilite " +
                $"\"{cbUsarUnicaConexion.Text}\", en cuyo caso todas compartirán la misma conexión (puede producir cuellos de botella).\n" +
                $"Al finalizar se muestran throughput, latencias (min/max/prom/percentiles) y se pueden exportar los resultados a CSV o JSON."
                , "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnIniciar_Click(object sender, System.EventArgs e)
        {
            lblCreandoHilos.Visible = true;
            btnIniciar.Enabled = cbUsarUnicaConexion.Enabled = false;
            nudDuracion.Enabled = nudHilosParalelos.Enabled = nudPausaMs.Enabled = false;
            btnVerDetalles.Enabled = false;
            _loadTestDefinition = new LoadTestDefinition
            {
                Server = _server,
                TxFile = _transaccion?.TXFile ?? "",
                NroHilos = (int)nudHilosParalelos.Value,
                DuracionSeg = (double)nudDuracion.Value,
                PausaMs = (int)nudPausaMs.Value,
                UsarUnicaConexion = cbUsarUnicaConexion.Checked
            };
            _contador = _contadorOK = _contadorFAIL = 0;
            _contadorSinRespuesta = 0;
            _listaHilos.Clear();
            for (int i = 0; i < _loadTestDefinition.NroHilos; i++)
                _listaHilos.Add(new LoadTestThreadItem { ThreadNum = i + 1 });

            this.Invalidate();
            this.Update();
            _latencies = new ConcurrentBag<long>();
            _timestamps = new ConcurrentBag<TrxTimestamp>();
            _tasks = new Task[_loadTestDefinition.NroHilos];
            _countArranque = _loadTestDefinition.NroHilos;
            _tcsArranque = new TaskCompletionSource<bool>();
            HCSClient.ResetTxCounter();

            try
            {
                if (cbUsarUnicaConexion.Checked)
                {
                    _hcsClient = new HCSClient(_loadTestDefinition.Server, _networkCredential);
                    _useASingleConnection = true;
                }
                else
                {
                    _useASingleConnection = false;
                }

                string correlationIDBase = DateTime.Now.ToString("HHmmss-ffff") + "-";
                _correlationIDBase = DateTime.Now.ToString("HHmmss-ffff");
                _timerEnsayo = new Stopwatch();
                _timerEnsayo.Start();
                for (int i = 0; i < _loadTestDefinition.NroHilos; i++)
                {
                    int nroTarea = i + 1;
                    _tasks[i] = RunUserAsync(nroTarea, correlationIDBase);
                }

                lblCreandoHilos.Visible = false;
                tmrFinalizacion.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar el ensayo. Detalles {ex.Message}"
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIniciar.Enabled = cbUsarUnicaConexion.Enabled = true;
                nudDuracion.Enabled = nudHilosParalelos.Enabled = nudPausaMs.Enabled = true;
            }
        }


        private async Task RunUserAsync(int nroTarea, string correlationIDBase)
        {
            await Task.Yield();     // Saltar al ThreadPool inmediatamente para no bloquear el hilo de UI

            string corrId = correlationIDBase + nroTarea.ToString("D3");

            UpdateGridRowStart(nroTarea - 1, nroTarea, corrId);

            var latenciasHilo = new List<long>();
            int trxOk = 0, trxFail = 0;
            Stopwatch sw = Stopwatch.StartNew();
            HCSClient client = null;
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime;
            bool ok = false;
            string failureReason = "";

            try
            {
                client = (_useASingleConnection ? _hcsClient : new HCSClient(_loadTestDefinition.Server, _networkCredential));

                // Barrera async: todas las tareas esperan aquí hasta que las N hayan llegado; luego arrancan juntas
                if (Interlocked.Decrement(ref _countArranque) == 0)
                    _tcsArranque.TrySetResult(true);

                await _tcsArranque.Task;

                startTime = DateTime.Now;

                sw.Restart();
                while ((sw.ElapsedMilliseconds / 1000 < _loadTestDefinition.DuracionSeg) && !_abortImmediatly)
                {
                    Stopwatch reqSw = Stopwatch.StartNew();
                    try
                    {
                        await client.EnviarYRecibir(_transaccion, false, corrId);
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
                    if (_loadTestDefinition.PausaMs > 0)
                        await Task.Delay(_loadTestDefinition.PausaMs);
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

            UpdateGridRowFinish(nroTarea - 1, startTime, endTime, ok, failureReason, latAvg, latMin, latMax, trxOk, trxFail, thrOk, thrTotal);
        }

        private void UpdateGridRowStart(int rowIndex, int threadNum, string corrId)
        {
            if (dgvHilos.InvokeRequired)
            {
                dgvHilos.BeginInvoke(new Action<int, int, string>(UpdateGridRowStart), rowIndex, threadNum, corrId);
                return;
            }
            if (rowIndex < 0 || rowIndex >= _listaHilos.Count) return;
            _listaHilos[rowIndex].ThreadNum = threadNum;
            _listaHilos[rowIndex].CorrID = corrId;
        }

        private void UpdateGridRowFinish(int rowIndex, DateTime startTime, DateTime endTime, bool statusOk, string failureReason, long latAvg, long latMin, long latMax, int trxOk, int trxFail, double throughputOk, double throughputTotal)
        {
            if (dgvHilos.InvokeRequired)
            {
                dgvHilos.BeginInvoke(new Action<int, DateTime, DateTime, bool, string, long, long, long, int, int, double, double>(UpdateGridRowFinish), rowIndex, startTime, endTime, statusOk, failureReason, latAvg, latMin, latMax, trxOk, trxFail, throughputOk, throughputTotal);
                return;
            }
            if (rowIndex < 0 || rowIndex >= _listaHilos.Count) return;
            var item = _listaHilos[rowIndex];
            item.StartTime = startTime.ToString("HH:mm:ss.fff");
            item.EndTime = endTime.ToString("HH:mm:ss.fff");
            item.Status = statusOk ? "OK" : "FAIL";
            item.StatusOk = statusOk;
            item.FailureReason = failureReason ?? "";
            item.LatAvg = latAvg;
            item.LatMin = latMin;
            item.LatMax = latMax;
            item.TrxOK = trxOk;
            item.TrxFail = trxFail;
            item.ThroughputOK = throughputOk;
            item.ThroughputTotal = throughputTotal;
        }

        private void dgvHilos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= _listaHilos.Count) return;
            // Columna fija de número de fila (guía visual, no se ordena ni está en el modelo)
            if (dgvHilos.Columns[e.ColumnIndex].Name == "colRowNum")
            {
                e.Value = (e.RowIndex + 1).ToString();
                return;
            }
            // Throughput: mostrar solo 2 decimales (no depende de que la columna exista al crear el formulario)
            var dataProp = dgvHilos.Columns[e.ColumnIndex].DataPropertyName;
            if (dataProp == "ThroughputOK" || dataProp == "ThroughputTotal")
            {
                if (e.Value is double d)
                    e.Value = d.ToString("F2");
                return;
            }
            if (dataProp != "Status") return;
            var item = _listaHilos[e.RowIndex];
            if (string.IsNullOrEmpty(item.Status)) return;
            e.CellStyle.BackColor = item.StatusOk ? Color.LightGreen : Color.LightCoral;
        }

        private void tmrFinalizacion_Tick(object sender, EventArgs e)
        {
            decimal elapsedSeconds = (decimal)_timerEnsayo.ElapsedMilliseconds / 1000;
            int porcentajeAvance = (int) (elapsedSeconds / nudDuracion.Value * 100);
            porcentajeAvance = porcentajeAvance > 100 ? 100 : porcentajeAvance;
            prgbarHilos.Value = porcentajeAvance;
            prgbarHilos.Visible = true;

            // Si alguna tarea aún no terminó, me voy
            int pendientes = _tasks.Count(t => !t.IsCompleted);
            Debug.WriteLine($"Pendientes: {pendientes}");
            Debug.WriteLine($"Faltan llegar a barrera: {_countArranque}");
            
            if (!_tasks.All(t => t.IsCompleted)) return;

            tmrFinalizacion.Stop();
            _timerEnsayo.Stop();
            if (_useASingleConnection) _hcsClient.Cerrar();
            btnIniciar.Enabled = cbUsarUnicaConexion.Enabled = true;
            nudDuracion.Enabled = nudHilosParalelos.Enabled = nudPausaMs.Enabled = true;
            prgbarHilos.Visible = false;

            long transmisiones = HCSClient.GetTransmisiones();
            long tiempoMs = _timerEnsayo.ElapsedMilliseconds;

            _lastReport = LoadTestReport.Create(
                latencias: _latencies,
                hilos: _listaHilos,
                loadTestDefinition: _loadTestDefinition,
                finalizadosOK: _contadorOK,
                finalizadosFAIL: _contadorFAIL,
                transmisionesSinRespuesta: _contadorSinRespuesta,
                transmisionesCompletadas: transmisiones,
                tiempoMs: tiempoMs,
                correlationIDBase: _correlationIDBase,
                timestamps: _timestamps);

            btnVerDetalles.Enabled = true;

            MessageBox.Show("Prueba finalizada." + _lastReport.ToString());

            lblContadorOK.Text = $"Hilos Finalizados OK: {_lastReport.FinalizadosOK}";
            lblContadorFAIL.Text = $"Hilos Finalizados FAIL: {_lastReport.FinalizadosFAIL}";
            lblSinRespuesta.Text = $"Sin respuesta (error/timeout): {_lastReport.TransmisionesSinRespuesta}";
            lblTiempo.Text = $"Tiempo: {_lastReport.TiempoMs} ms";
            lblThroughput.Text = $"Throughput: {_lastReport.ThroughputTrxSeg:F2} trx/seg";
            lblLatenciaResumen.Text = _lastReport.LatenciasOrdenadas.Length > 0
                ? $"Latencia (ms): min {_lastReport.LatenciaMinMs} | max {_lastReport.LatenciaMaxMs} | p50 {_lastReport.LatenciaP50Ms} | p95 {_lastReport.LatenciaP95Ms}"
                : "Latencia: ---";
            lblMetricasNuevas.Text = $"Throughput/hilo: {_lastReport.ThroughputPorHilo:F2} trx/seg | Tasa éxito hilos: {_lastReport.TasaExitoHilos:F1}% | Estabilidad latencia: {_lastReport.EstabilidadLatencia:F4} | Tasa éxito trans: {_lastReport.TasaExitoTransacciones:F1}% | Consistencia: {_lastReport.ConsistenciaRendimiento:F4}";
        }

        private void btnVerDetalles_Click(object sender, EventArgs e)
        {
            if (_lastReport == null) return;
            using (var frm = new FrmDetallesEnsayo(
                _lastReport,
                _listaHilos.ToList(),
                _loadTestDefinition))
            {
                frm.ShowDialog(this);
            }
        }

        private void FrmPruebaDeCarga_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnIniciar.Enabled) return;

            DialogResult dialogResult = MessageBox.Show(
                "Hay un ensayo en curso, se recomienda que espere que finalice para cerrar la ventana. Desea cerrar la ventana de todos modos?"
                , "Detener ensayo de Carga"
                , MessageBoxButtons.YesNo
                , MessageBoxIcon.Question);

            if (dialogResult == DialogResult.No)
                e.Cancel = true;
            else
                _abortImmediatly = true;
        }


    }
}