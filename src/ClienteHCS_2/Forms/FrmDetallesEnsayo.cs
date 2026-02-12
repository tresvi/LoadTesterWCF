using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ClienteHCS_2.Helpers;

namespace ClienteHCS_2
{
    /// <summary>
    /// Ventana con configuración del ensayo, resultados y tres histogramas (latencias, throughput OK, throughput Fail).
    /// Usa System.Windows.Forms.DataVisualization.Charting para los gráficos.
    /// </summary>
    public partial class FrmDetallesEnsayo : Form
    {
        private readonly LoadTestReport _report;
        private readonly IList<LoadTestThreadItem> _items;
        private readonly LoadTestDefinition _definition;

        public FrmDetallesEnsayo(
            LoadTestReport report,
            IList<LoadTestThreadItem> items,
            LoadTestDefinition definition)
        {
            _report = report ?? throw new ArgumentNullException(nameof(report));
            _items = items ?? new List<LoadTestThreadItem>();
            _definition = definition ?? throw new ArgumentNullException(nameof(definition));

            InitializeComponent();
            CargarResumen();
            ConfigurarCharts();
        }

        private void CargarResumen()
        {
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

        private void btnExportar_Click(object sender, EventArgs e)
        {
            using (var dlg = new SaveFileDialog())
            {
                dlg.Filter = "CSV (*.csv)|*.csv|JSON (*.json)|*.json";
                dlg.DefaultExt = "csv";
                dlg.FileName = $"PruebaCarga_{_report.Fecha:yyyyMMdd_HHmmss}";
                if (dlg.ShowDialog() != DialogResult.OK) return;

                try
                {
                    if (dlg.FileName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                        LoadTestReportExporter.ExportarJson(_report, dlg.FileName);
                    else
                        LoadTestReportExporter.ExportarCsv(_report, dlg.FileName);
                    MessageBox.Show("Resultados exportados correctamente.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al exportar: {ex.Message}", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ConfigurarCharts()
        {
            var valoresLatencia = _items.Where(i => i.LatAvg >= 0).Select(i => (double)i.LatAvg).ToList();
            var valoresThroughputOk = _items.Select(i => i.ThroughputOK).ToList();
            double dur = _definition.DuracionSeg > 0 ? _definition.DuracionSeg : 1;
            var valoresThroughputFail = _items.Select(i => i.TrxFail / dur).ToList();

            ConfigurarHistogramaChart(chartLatencia, valoresLatencia, "Latencia (ms)", "Hilos", decimalesEjeX: 1);
            ConfigurarHistogramaChart(chartThroughputOk, valoresThroughputOk, "Throughput OK [tps]", "Hilos", decimalesEjeX: 2);
            ConfigurarHistogramaChart(chartThroughputFail, valoresThroughputFail, "Throughput Fail [tps]", "Hilos", decimalesEjeX: 2);
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
    }
}
