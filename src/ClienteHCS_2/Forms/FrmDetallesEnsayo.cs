using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ClienteHCS_2.Helpers;
using Newtonsoft.Json;

namespace ClienteHCS_2
{

    public partial class FrmDetallesEnsayo : Form
    {
        private LoadTestReport _report;
        private IList<LoadTestThreadItem> _items;
        private LoadTestDefinition _definition;
        private bool _esVacio;

        // Constructor para permitir abrir el Diseñador de WinForms.
        public FrmDetallesEnsayo()
        {
            _report = new LoadTestReport();
            _items = new List<LoadTestThreadItem>();
            _definition = new LoadTestDefinition();
            _esVacio = true;

            InitializeComponent();
            CargarResumen();
            ConfigurarCharts();
        }

        public FrmDetallesEnsayo(
            LoadTestReport report,
            IList<LoadTestThreadItem> items,
            LoadTestDefinition definition)
        {
            _report = report ?? throw new ArgumentNullException(nameof(report));
            _items = items ?? new List<LoadTestThreadItem>();
            _definition = definition ?? throw new ArgumentNullException(nameof(definition));
            _esVacio = false;

            InitializeComponent();
            CargarResumen();
            ConfigurarCharts();
        }

        private void CargarResumen()
        {
            if (_esVacio || _definition == null)
            {
                lblConfig.Text = "---";
                lblResultados1.Text = "---";
                lblResultados2.Text = "---";
                return;
            }

            lblConfig.Text = _definition.ToConfigString();

            if (_report == null) return;
            lblResultados1.Text =
                $"Fecha: {_report.Fecha:yyyy-MM-dd HH:mm:ss}\r\n" +
                $"Finalizados OK: {_report.FinalizadosOK} | FAIL: {_report.FinalizadosFAIL}\r\n" +
                $"Transmisiones completadas: {_report.TransmisionesCompletadas}\r\n" +
                $"Sin respuesta: {_report.TransmisionesSinRespuesta}\r\n" +
                $"Tiempo: {_report.TiempoMs} ms\r\n" +
                $"Throughput: {_report.ThroughputTrxSeg:F2} trx/seg\r\n" +
                $"Latencia (ms): min {_report.LatenciaMinMs} | max {_report.LatenciaMaxMs} | prom {_report.LatenciaPromMs}\r\n" +
                $"p50: {_report.LatenciaP50Ms} | p90: {_report.LatenciaP90Ms} | p95: {_report.LatenciaP95Ms} | p99: {_report.LatenciaP99Ms}";

            lblResultados2.Text =
                $"Throughput por hilo: {_report.ThroughputPorHilo:F2} trx/seg\r\n" +
                $"Tasa éxito hilos: {_report.TasaExitoHilos:F1}%\r\n" +
                $"Estabilidad de latencia: {_report.EstabilidadLatencia:F4}\r\n" +
                $"Tasa éxito transacciones: {_report.TasaExitoTransacciones:F1}%\r\n" +
                $"Consistencia rendimiento: {_report.ConsistenciaRendimiento:F4}";
        }


        private void ConfigurarCharts()
        {
            var valoresLatencia = _items.Where(i => i.LatAvg >= 0).Select(i => (double)i.LatAvg).ToList();
            var valoresThroughputOk = _items.Select(i => i.ThroughputOK).ToList();

            ConfigurarHistogramaChart(chartLatencia, valoresLatencia, "Latencia (ms)", "Hilos", decimalesEjeX: 1);
            ConfigurarHistogramaChart(chartThroughputOk, valoresThroughputOk, "Throughput OK [tps]", "Hilos", decimalesEjeX: 2);
        }

        /// <summary>
        /// Configura un Chart con datos de histograma (mismo algoritmo que el original: buckets con paso redondo, Y = cantidad de hilos).
        /// </summary>
        /// <param name="decimalesEjeX">Cantidad de decimales para las etiquetas del eje X (0, 1, 2...).</param>
        private static void ConfigurarHistogramaChart(Chart chart, IList<double> values, string tituloEjeX, string tituloEjeY, int decimalesEjeX = 0)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();

            chart.ChartAreas.Add(new ChartArea("Default"));
            var area = chart.ChartAreas[0];
            area.AxisX.Title = tituloEjeX;
            area.AxisY.Title = tituloEjeY;
            area.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            area.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            area.BackColor = System.Drawing.Color.White;

            var series = new Series("Histograma")
            {
                ChartType = SeriesChartType.Column,
                Color = System.Drawing.Color.SteelBlue,
                BorderColor = System.Drawing.Color.SteelBlue
            };
            chart.Series.Add(series);

            if (values == null || values.Count == 0)
            {
                chart.Titles.Clear();
                chart.Titles.Add(new Title("Sin datos") { Font = new System.Drawing.Font("Segoe UI", 10f), ForeColor = System.Drawing.Color.Gray });
                return;
            }

            int nBucketsDeseado = Math.Min(25, Math.Max(8, (int)Math.Sqrt(values.Count) + 2));
            double min = values.Min();
            double max = values.Max();
            if (max <= min) max = min + 1;
            double range = max - min;

            // Paso "redondo" (1, 2, 5, 10, 20, 50, 0.1, 0.2, 0.5, ...)
            double pasoRudo = range / nBucketsDeseado;
            if (pasoRudo <= 0) pasoRudo = 1;
            double magnitud = Math.Pow(10, Math.Floor(Math.Log10(pasoRudo)));
            if (magnitud == 0 || double.IsInfinity(magnitud)) magnitud = 1;
            double normalizado = pasoRudo / magnitud;
            double pasoRedondo;
            if (normalizado <= 1) pasoRedondo = 1 * magnitud;
            else if (normalizado <= 2) pasoRedondo = 2 * magnitud;
            else if (normalizado <= 5) pasoRedondo = 5 * magnitud;
            else pasoRedondo = 10 * magnitud;

            double bucketStart = Math.Floor(min / pasoRedondo) * pasoRedondo;
            int nBuckets = Math.Max(1, Math.Min(30, (int)Math.Ceiling((max - bucketStart) / pasoRedondo)));

            var buckets = new int[nBuckets];
            foreach (double v in values)
            {
                int idx = (int)((v - bucketStart) / pasoRedondo);
                if (idx >= nBuckets) idx = nBuckets - 1;
                if (idx < 0) idx = 0;
                buckets[idx]++;
            }

            string formatoX = "F" + decimalesEjeX;
            for (int i = 0; i < nBuckets; i++)
            {
                double valorBucket = bucketStart + i * pasoRedondo;
                string textoX = valorBucket.ToString(formatoX);
                series.Points.AddXY(textoX, buckets[i]);
            }
        }


        private void tsbGuardarComo_Click(object sender, EventArgs e)
        {
            using (var dlg = new SaveFileDialog())
            {
                dlg.Filter = "Ensayo de carga (*.ltst)|*.ltst|CSV (*.csv)|*.csv|JSON reporte (*.json)|*.json";
                dlg.DefaultExt = "ltst";
                dlg.FileName = $"PruebaCarga_{_report.Fecha:yyyyMMdd_HHmmss}";
                if (dlg.ShowDialog() != DialogResult.OK) return;

                try
                {
                    if (dlg.FileName.EndsWith(".ltst", StringComparison.OrdinalIgnoreCase))
                    {
                        GuardarEnsayoCompleto(dlg.FileName);
                        MessageBox.Show("Ensayo guardado correctamente.", "Guardar ensayo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (dlg.FileName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                    {
                        LoadTestReportExporter.ExportarJson(_report, dlg.FileName);
                        MessageBox.Show("Reporte exportado correctamente.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        LoadTestReportExporter.ExportarCsv(_report, dlg.FileName);
                        MessageBox.Show("Reporte exportado correctamente.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar/exportar: {ex.Message}", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbAbrirEnsayo_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "Ensayo de carga (*.ltst)|*.ltst|JSON (*.json)|*.json";
                dlg.CheckFileExists = true;
                dlg.Multiselect = false;
                if (dlg.ShowDialog() != DialogResult.OK) return;

                try
                {
                    CargarEnsayoDesdeArchivo(dlg.FileName);
                    MessageBox.Show("Ensayo cargado correctamente.", "Abrir ensayo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se pudo abrir el ensayo: {ex.Message}", "Abrir ensayo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbMedidasRendimiento_Click(object sender, EventArgs e)
        {
            if (_report == null || _esVacio)
            {
                MessageBox.Show("No hay un ensayo actual cargado para comparar.", "Comparar ensayos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var dlg = new OpenFileDialog())
            {
                dlg.Filter = "Ensayo de carga (*.ltst)|*.ltst|JSON (*.json)|*.json";
                dlg.CheckFileExists = true;
                dlg.Multiselect = false;
                if (dlg.ShowDialog() != DialogResult.OK) return;

                try
                {
                    var comparado = LeerEnsayoGuardado(dlg.FileName);
                    string nombreComparado = Path.GetFileNameWithoutExtension(dlg.FileName);
                    using (var frmComparacion = new FrmComparacionEnsayos(
                        _report,
                        _definition,
                        comparado.Reporte,
                        comparado.Definicion,
                        "Ensayo actual",
                        nombreComparado))
                    {
                        frmComparacion.ShowDialog(this);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"No se pudo abrir el ensayo a comparar: {ex.Message}", "Comparar ensayos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GuardarEnsayoCompleto(string path)
        {
            var ensayo = new EnsayoGuardado
            {
                Reporte = _report,
                Hilos = _items != null ? _items.ToList() : new List<LoadTestThreadItem>(),
                Definicion = _definition
            };

            string json = JsonConvert.SerializeObject(ensayo, Formatting.Indented);
            File.WriteAllText(path, json);
        }

        private void CargarEnsayoDesdeArchivo(string path)
        {
            var ensayo = LeerEnsayoGuardado(path);
            _report = ensayo.Reporte;
            _items = ensayo.Hilos ?? new List<LoadTestThreadItem>();
            _definition = ensayo.Definicion ?? CrearDefinicionDesdeReporte(_report);
            _esVacio = false;

            CargarResumen();
            ConfigurarCharts();
        }

        internal static EnsayoGuardado LeerEnsayoGuardado(string path)
        {
            string json = File.ReadAllText(path);

            EnsayoGuardado ensayo = null;
            try
            {
                ensayo = JsonConvert.DeserializeObject<EnsayoGuardado>(json);
            }
            catch
            {
                // Compatibilidad: JSON antiguo con solo LoadTestReport.
            }

            if (ensayo != null && ensayo.Reporte != null)
            {
                return new EnsayoGuardado
                {
                    Reporte = ensayo.Reporte,
                    Hilos = ensayo.Hilos ?? new List<LoadTestThreadItem>(),
                    Definicion = ensayo.Definicion ?? CrearDefinicionDesdeReporte(ensayo.Reporte)
                };
            }

            // Compatibilidad con exportaciones previas del reporte.
            var reporte = JsonConvert.DeserializeObject<LoadTestReport>(json);
            if (reporte == null)
                throw new InvalidOperationException("El archivo no tiene un formato de ensayo válido.");

            return new EnsayoGuardado
            {
                Reporte = reporte,
                Hilos = new List<LoadTestThreadItem>(),
                Definicion = CrearDefinicionDesdeReporte(reporte)
            };
        }

        private static LoadTestDefinition CrearDefinicionDesdeReporte(LoadTestReport reporte)
        {
            if (reporte == null) return new LoadTestDefinition();
            return new LoadTestDefinition
            {
                Server = reporte.Servidor ?? "",
                TxFile = reporte.TxFile ?? "",
                NroHilos = reporte.TotalHilos,
                PausaMs = reporte.PausaMs,
                DuracionSeg = reporte.TiempoMs > 0 ? reporte.TiempoMs / 1000.0 : 0,
                UsarUnicaConexion = false
            };
        }

    }
}
