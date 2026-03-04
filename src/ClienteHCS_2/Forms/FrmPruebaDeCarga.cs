using ClienteHCS_2.Models.LoadTest;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace ClienteHCS_2
{
    public partial class FrmPruebaDeCarga : Form
    {
        private readonly string _server;
        private readonly Transaction _transaccion;
        private readonly NetworkCredential _networkCredential;

        LoadTestRunner _runner;
        LoadTestDefinition _loadTestDefinition;
        SortableBindingList<LoadTestThreadItem> _listaHilos = new SortableBindingList<LoadTestThreadItem>();
        LoadTestReport _lastReport;

        Label _lblHealthRealtime;


        public FrmPruebaDeCarga(string server, Transaction transaccion, NetworkCredential networkCredential)
        {
            _transaccion = transaccion;
            _server = server;
            _networkCredential = networkCredential;
            InitializeComponent();

            // Label de salud del cliente en tiempo real (creado por código, sobre la barra de progreso)
            _lblHealthRealtime = new Label
            {
                AutoSize = true,
                Font = new Font("Consolas", 8.25F, FontStyle.Regular),
                ForeColor = Color.DarkSlateGray,
                Text = "",
                Visible = false,
                BackColor = Color.Transparent
            };
            tlpParams.Controls.Add(_lblHealthRealtime, 3, 1);
            tlpParams.SetColumnSpan(_lblHealthRealtime, 5);

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
                $"Al finalizar se muestran throughput, latencias (min/max/prom/percentiles)."
                , "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private async void btnIniciar_Click(object sender, System.EventArgs e)
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

            _runner = new LoadTestRunner(_loadTestDefinition, _transaccion, _networkCredential);

            // Warm-up: una transmisión previa para validar parámetros y calentar la conexión
            try
            {
                await _runner.WarmUpAsync();
            }
            catch (Exception ex)
            {
                lblCreandoHilos.Visible = false;
                MessageBox.Show(
                    $"Error en la transmisión de warm-up. Verifique los parámetros de conexión.\n\nDetalles: {ex.Message}",
                    "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HabilitarControles();
                return;
            }

            // Suscribir eventos del runner
            _runner.OnHiloIniciado += Runner_OnHiloIniciado;
            _runner.OnHiloFinalizado += Runner_OnHiloFinalizado;

            try
            {
                var items = _runner.Iniciar();

                _listaHilos.Clear();
                foreach (var item in items)
                    _listaHilos.Add(item);

                this.Invalidate();
                this.Update();
                lblCreandoHilos.Visible = false;
                tmrFinalizacion.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar el ensayo. Detalles {ex.Message}"
                    , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                HabilitarControles();
            }
        }


        private void Runner_OnHiloIniciado(int rowIndex, int threadNum, string corrId)
        {
            if (dgvHilos.InvokeRequired)
            {
                dgvHilos.BeginInvoke(new Action<int, int, string>(Runner_OnHiloIniciado), rowIndex, threadNum, corrId);
                return;
            }
            if (rowIndex < 0 || rowIndex >= _listaHilos.Count) return;
            _listaHilos[rowIndex].ThreadNum = threadNum;
            _listaHilos[rowIndex].CorrID = corrId;
        }

        private void Runner_OnHiloFinalizado(LoadTestThreadResult r)
        {
            if (dgvHilos.InvokeRequired)
            {
                dgvHilos.BeginInvoke(new Action<LoadTestThreadResult>(Runner_OnHiloFinalizado), r);
                return;
            }
            if (r.RowIndex < 0 || r.RowIndex >= _listaHilos.Count) return;
            var item = _listaHilos[r.RowIndex];
            item.StartTime = r.StartTime.ToString("HH:mm:ss.fff");
            item.EndTime = r.EndTime.ToString("HH:mm:ss.fff");
            item.Status = r.StatusOk ? "OK" : "FAIL";
            item.StatusOk = r.StatusOk;
            item.FailureReason = r.FailureReason ?? "";
            item.LatAvg = r.LatAvg;
            item.LatMin = r.LatMin;
            item.LatMax = r.LatMax;
            item.TrxOK = r.TrxOK;
            item.TrxFail = r.TrxFail;
            item.ThroughputOK = r.ThroughputOK;
            item.ThroughputTotal = r.ThroughputTotal;
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
            decimal elapsedSeconds = (decimal)_runner.ElapsedMs / 1000;
            int porcentajeAvance = (int)(elapsedSeconds / nudDuracion.Value * 100);
            porcentajeAvance = porcentajeAvance > 100 ? 100 : porcentajeAvance;
            prgbarHilos.Value = porcentajeAvance;
            prgbarHilos.Visible = true;

            // Mostrar salud del cliente en tiempo real
            var snap = _runner.UltimaSnapshotSalud;
            if (snap != null)
            {
                _lblHealthRealtime.Text = $"CPU: {snap.CpuPercent:F0}%  |  RAM: {snap.MemoryMB:F0} MB  |  Threads busy: {snap.ThreadPoolWorkersBusy}  |  GC Gen2: {snap.GcGen2}";
                _lblHealthRealtime.ForeColor = snap.CpuPercent >= ClientHealthMonitor.CPU_AVG_THRESHOLD
                    ? Color.Red
                    : Color.DarkSlateGray;
                _lblHealthRealtime.Visible = true;
            }

            int pendientes = _runner.TareasPendientes;
            Debug.WriteLine($"Pendientes: {pendientes}");

            if (!_runner.TodasFinalizadas) return;

            tmrFinalizacion.Stop();
            prgbarHilos.Visible = false;
            _lblHealthRealtime.Visible = false;

            _lastReport = _runner.Finalizar(_listaHilos.ToList());

            HabilitarControles();
            btnVerDetalles.Enabled = true;

            // Advertencia de saturación prominente
            if (_lastReport.SaludCliente != null && _lastReport.SaludCliente.Saturado)
            {
                MessageBox.Show(
                    "⚠ Se detectó saturación del cliente durante el ensayo.\n\n" +
                    _lastReport.SaludCliente.DetalleSaturacion + "\n\n" +
                    "Los resultados de throughput y latencia pueden no reflejar el rendimiento real del servicio, " +
                    "sino la limitación del equipo que ejecutó el ensayo.\n" +
                    "Se recomienda repetir el ensayo con menos hilos o en un equipo con más recursos.",
                    "Cliente saturado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

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
            using (var frm = new FrmDetallesEnsayoCarga(
                _lastReport,
                _listaHilos.ToList(),
                _loadTestDefinition))
            {
                frm.ShowDialog(this);
            }
        }

        private void FrmPruebaDeCarga_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_runner == null || !_runner.EnCurso) return;

            DialogResult dialogResult = MessageBox.Show(
                "Hay un ensayo en curso, se recomienda que espere que finalice para cerrar la ventana. Desea cerrar la ventana de todos modos?"
                , "Detener ensayo de Carga"
                , MessageBoxButtons.YesNo
                , MessageBoxIcon.Question);

            if (dialogResult == DialogResult.No)
                e.Cancel = true;
            else
                _runner.Abortar();
        }

        private void HabilitarControles()
        {
            btnIniciar.Enabled = cbUsarUnicaConexion.Enabled = true;
            nudDuracion.Enabled = nudHilosParalelos.Enabled = nudPausaMs.Enabled = true;
        }
    }
}