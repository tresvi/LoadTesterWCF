using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Newtonsoft.Json;

namespace ClienteHCS_2
{

    public partial class FrmDetallesEnsayoCarga : Form
    {
        private LoadTestReport _report;
        private IList<LoadTestThreadItem> _items;
        private LoadTestDefinition _definition;
        private bool _esVacio;

        private const int VentanaMediaMovilTemporal = 3;
        private double[] _temporalThroughputOriginal;
        private double[] _temporalLatenciaOriginal;
        private double[] _temporalThroughputActual;
        private double[] _temporalLatenciaActual;
        private bool _temporalHayLatencia;

        // Constructor para permitir abrir el Diseñador de WinForms.
        public FrmDetallesEnsayoCarga()
        {
            _report = new LoadTestReport();
            _items = new List<LoadTestThreadItem>();
            _definition = new LoadTestDefinition();
            _esVacio = true;

            InitializeComponent();
            CargarResumen();
            ConfigurarCharts();
        }

        public FrmDetallesEnsayoCarga(
            LoadTestReport report,
            IList<LoadTestThreadItem> items,
            LoadTestDefinition definition)
        {
            _report = report ?? throw new ArgumentNullException(nameof(report));
            _items = items ?? new List<LoadTestThreadItem>();
            _definition = definition ?? throw new ArgumentNullException(nameof(definition));
            _esVacio = false;

            InitializeComponent();
            tsbAbrirEnsayo.Enabled = false;
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
            ConfigurarThroughputTemporalChart();
        }

        /// <summary>
        /// Configura el chart de throughput y latencia en función del tiempo.
        /// Eje Y izquierdo: throughput (trx/seg). Eje Y derecho: latencia promedio (ms).
        /// </summary>
        private void ConfigurarThroughputTemporalChart()
        {
            chartThroughputTemporal.Series.Clear();
            chartThroughputTemporal.ChartAreas.Clear();
            chartThroughputTemporal.Legends.Clear();
            chartThroughputTemporal.Titles.Clear();

            var timestamps = _report?.Timestamps;
            if (timestamps == null || timestamps.Count == 0)
            {
                var areaVacio = new ChartArea("Default");
                areaVacio.AxisX.Minimum = 0;
                areaVacio.AxisX.IsMarginVisible = false;
                areaVacio.AxisX.LabelStyle.Format = "0";
                ConfigurarZoomTemporal(areaVacio, false);
                chartThroughputTemporal.ChartAreas.Add(areaVacio);
                chartThroughputTemporal.Titles.Add(new Title("Sin datos de throughput temporal")
                {
                    Font = new System.Drawing.Font("Segoe UI", 11f),
                    ForeColor = System.Drawing.Color.Gray
                });
                LimpiarBuffersGraficoTemporal();
                return;
            }

            var area = new ChartArea("Default");
            area.AxisX.Title = "Tiempo (seg)";
            area.AxisX.TitleFont = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            area.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9f);
            area.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            area.AxisX.MinorGrid.Enabled = true;
            area.AxisX.MinorGrid.Interval = 1;
            area.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gainsboro;
            area.AxisX.Interval = 1;
            area.AxisX.Minimum = 0;
            area.AxisX.IsMarginVisible = false;
            area.AxisX.LabelStyle.Format = "0";
            area.BackColor = System.Drawing.Color.White;

            area.AxisY.Title = "Trx/seg";
            area.AxisY.TitleFont = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            area.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9f);
            area.AxisY.TitleForeColor = System.Drawing.Color.Black;
            area.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;

            area.AxisY2.Title = "Latencia Promedio (ms)";
            area.AxisY2.TitleFont = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            area.AxisY2.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 9f);
            area.AxisY2.TitleForeColor = System.Drawing.Color.OrangeRed;
            area.AxisY2.LabelStyle.ForeColor = System.Drawing.Color.OrangeRed;
            area.AxisY2.MajorGrid.Enabled = false;
            area.AxisY2.Enabled = AxisEnabled.True;
            ConfigurarZoomTemporal(area, true);

            chartThroughputTemporal.ChartAreas.Add(area);

            int maxSeg = timestamps.Max(t => t.SegundoRelativo);
            AgregarMarcadoresRampaTemporal(area, maxSeg);

            // Throughput total por segundo
            var totalPorSegundo = new int[maxSeg + 1];
            // Acumuladores de latencia por segundo
            var sumaLatenciaPorSegundo = new long[maxSeg + 1];
            var countLatenciaPorSegundo = new int[maxSeg + 1];

            foreach (var ts in timestamps)
            {
                totalPorSegundo[ts.SegundoRelativo]++;
                if (ts.LatenciaMs > 0)
                {
                    sumaLatenciaPorSegundo[ts.SegundoRelativo] += ts.LatenciaMs;
                    countLatenciaPorSegundo[ts.SegundoRelativo]++;
                }
            }

            Series serieThroughput = new Series("Throughput")
            {
                ChartType = SeriesChartType.Line,
                Color = System.Drawing.Color.Black,
                BorderWidth = 3,
                YAxisType = AxisType.Primary
            };
            for (int s = 0; s <= maxSeg; s++)
                serieThroughput.Points.AddXY(s, totalPorSegundo[s]);
            chartThroughputTemporal.Series.Add(serieThroughput);

            bool hayLatencia = countLatenciaPorSegundo.Any(c => c > 0);
            if (hayLatencia)
            {
                Series serieLatencia = new Series("Latencia Promedio (ms)")
                {
                    ChartType = SeriesChartType.Line,
                    Color = System.Drawing.Color.OrangeRed,
                    BorderWidth = 2,
                    BorderDashStyle = ChartDashStyle.Dash,
                    YAxisType = AxisType.Secondary
                };
                for (int s = 0; s <= maxSeg; s++)
                {
                    double latProm = countLatenciaPorSegundo[s] > 0
                        ? (double)sumaLatenciaPorSegundo[s] / countLatenciaPorSegundo[s]
                        : double.NaN;
                    serieLatencia.Points.AddXY(s, latProm);
                }
                chartThroughputTemporal.Series.Add(serieLatencia);
            }

            var legend = new Legend("Default")
            {
                Docking = Docking.Top,
                Alignment = System.Drawing.StringAlignment.Center,
                Font = new System.Drawing.Font("Segoe UI", 9f)
            };
            chartThroughputTemporal.Legends.Add(legend);

            // Evitar que el autoscale muestre -1 en X: fijar rango tras cargar series
            Axis ax = chartThroughputTemporal.ChartAreas["Default"].AxisX;
            ax.Minimum = 0;
            ax.Maximum = maxSeg;
            int intervaloEtiquetasX = 5;
            ax.Interval = intervaloEtiquetasX;
            ax.LabelStyle.Interval = intervaloEtiquetasX;
            ax.MajorGrid.Interval = intervaloEtiquetasX;

            _temporalHayLatencia = hayLatencia;
            _temporalThroughputOriginal = new double[maxSeg + 1];
            for (int s = 0; s <= maxSeg; s++)
                _temporalThroughputOriginal[s] = totalPorSegundo[s];
            if (hayLatencia)
            {
                _temporalLatenciaOriginal = new double[maxSeg + 1];
                for (int s = 0; s <= maxSeg; s++)
                {
                    _temporalLatenciaOriginal[s] = countLatenciaPorSegundo[s] > 0
                        ? (double)sumaLatenciaPorSegundo[s] / countLatenciaPorSegundo[s]
                        : double.NaN;
                }
            }
            else
                _temporalLatenciaOriginal = null;
            _temporalThroughputActual = null;
            _temporalLatenciaActual = null;
            ActualizarEstadoBotonesGraficoTemporal();
        }

        /// <summary>
        /// En modo rampa, marca cada inicio de paso con los hilos activos acumulados.
        /// </summary>
        private void AgregarMarcadoresRampaTemporal(ChartArea area, int maxSeg)
        {
            if (area == null || _definition == null) return;
            if (!_definition.UsarRampa) return;
            if (_definition.IncrementoHilos <= 0 || _definition.IntervaloRampaSeg <= 0) return;
            if (_definition.NroHilos <= 0) return;

            int incremento = _definition.IncrementoHilos;
            int total = _definition.NroHilos;
            int pasos = (int)Math.Ceiling((double)total / incremento);
            int intervaloSeg = Math.Max(1, (int)Math.Round(_definition.IntervaloRampaSeg));

            for (int i = 0; i < pasos; i++)
            {
                int segundoPaso = i * intervaloSeg;
                if (segundoPaso > maxSeg) break;

                int hilosActivos = Math.Min(total, (i + 1) * incremento);
                // En X=0 el borde del eje puede tapar la línea: moverla mínimamente dentro del área.
                double offsetMarca = (segundoPaso == 0) ? 0.001 : segundoPaso;
                var marca = new StripLine
                {
                    IntervalOffset = offsetMarca,
                    StripWidth = 0,
                    BorderColor = System.Drawing.Color.DarkSlateGray,
                    BorderDashStyle = ChartDashStyle.Dot,
                    BorderWidth = 2,
                    Text = $"{hilosActivos}h",
                    TextAlignment = System.Drawing.StringAlignment.Near,
                    TextLineAlignment = System.Drawing.StringAlignment.Far,
                    Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold),
                    ForeColor = System.Drawing.Color.DimGray
                };
                area.AxisX.StripLines.Add(marca);
            }
        }

        private void LimpiarBuffersGraficoTemporal()
        {
            _temporalThroughputOriginal = null;
            _temporalLatenciaOriginal = null;
            _temporalThroughputActual = null;
            _temporalLatenciaActual = null;
            _temporalHayLatencia = false;
            ActualizarEstadoBotonesGraficoTemporal();
        }

        private void ActualizarEstadoBotonesGraficoTemporal()
        {
            bool ok = _temporalThroughputOriginal != null && _temporalThroughputOriginal.Length > 0;
            btnMediaMovilTemporal.Enabled = ok;
            btnResetGraficoTemporal.Enabled = ok;
            btnResetZoomTemporal.Enabled = ok;
        }

        private void btnMediaMovilTemporal_Click(object sender, EventArgs e)
        {
            if (_temporalThroughputOriginal == null) return;
            var srcTp = _temporalThroughputActual ?? _temporalThroughputOriginal;
            _temporalThroughputActual = MediaMovilSimple(srcTp, VentanaMediaMovilTemporal);
            if (_temporalHayLatencia && _temporalLatenciaOriginal != null)
            {
                var srcLat = _temporalLatenciaActual ?? _temporalLatenciaOriginal;
                _temporalLatenciaActual = MediaMovilSimple(srcLat, VentanaMediaMovilTemporal);
            }
            RefrescarPuntosGraficoTemporal();
        }

        private void btnResetGraficoTemporal_Click(object sender, EventArgs e)
        {
            if (_temporalThroughputOriginal == null) return;
            _temporalThroughputActual = null;
            _temporalLatenciaActual = null;
            RefrescarPuntosGraficoTemporal();
        }

        private void btnResetZoomTemporal_Click(object sender, EventArgs e)
        {
            if (chartThroughputTemporal.ChartAreas.Count == 0) return;
            var area = chartThroughputTemporal.ChartAreas["Default"];
            area.AxisX.ScaleView.ZoomReset(0);
            area.AxisY.ScaleView.ZoomReset(0);
            area.AxisY2.ScaleView.ZoomReset(0);
        }

        private void RefrescarPuntosGraficoTemporal()
        {
            var tp = _temporalThroughputActual ?? _temporalThroughputOriginal;
            var lat = _temporalLatenciaOriginal != null
                ? (_temporalLatenciaActual ?? _temporalLatenciaOriginal)
                : null;
            var serieTp = chartThroughputTemporal.Series["Throughput"];
            serieTp.Points.Clear();
            for (int s = 0; s < tp.Length; s++)
                serieTp.Points.AddXY(s, tp[s]);
            if (_temporalHayLatencia && lat != null)
            {
                var serieLat = chartThroughputTemporal.Series["Latencia Promedio (ms)"];
                serieLat.Points.Clear();
                for (int s = 0; s < lat.Length; s++)
                    serieLat.Points.AddXY(s, lat[s]);
            }
        }

        /// <summary>Media móvil centrada; en huecos (NaN) promedia solo los valores válidos de la ventana.</summary>
        private static double[] MediaMovilSimple(double[] datos, int ventana)
        {
            if (datos == null || datos.Length == 0 || ventana < 1) return datos;
            int half = ventana / 2;
            var salida = new double[datos.Length];
            for (int i = 0; i < datos.Length; i++)
            {
                int ini = Math.Max(0, i - half);
                int fin = Math.Min(datos.Length - 1, i + half);
                double suma = 0;
                int n = 0;
                for (int j = ini; j <= fin; j++)
                {
                    if (!double.IsNaN(datos[j]))
                    {
                        suma += datos[j];
                        n++;
                    }
                }
                salida[i] = n > 0 ? suma / n : double.NaN;
            }
            return salida;
        }

        /// <summary>
        /// Calcula cada cuántas marcas mostrar etiquetas en X para evitar superposición visual.
        /// </summary>
        private static int CalcularIntervaloEtiquetasX(int cantidadPuntos, int maxEtiquetasVisibles = 12)
        {
            if (cantidadPuntos <= 0) return 1;
            return Math.Max(1, (int)Math.Ceiling((double)cantidadPuntos / Math.Max(1, maxEtiquetasVisibles)));
        }

        private static void ConfigurarZoomTemporal(ChartArea area, bool conDatos)
        {
            area.CursorX.IsUserEnabled = conDatos;
            area.CursorX.IsUserSelectionEnabled = conDatos;
            area.CursorX.Interval = 0;

            area.AxisX.ScaleView.Zoomable = conDatos;
            area.AxisX.ScrollBar.Enabled = conDatos;
            area.AxisX.ScrollBar.IsPositionedInside = true;
            area.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;

            // Mantener zoom horizontal: Y no seleccionable, pero reseteable por botón
            area.CursorY.IsUserEnabled = false;
            area.CursorY.IsUserSelectionEnabled = false;
            area.AxisY.ScaleView.Zoomable = false;
            area.AxisY2.ScaleView.Zoomable = false;
        }
         
        /// <summary>
        /// Configura un Chart con datos de histograma (mismo algoritmo que el original: buckets con paso redondo, Y = cantidad de hilos).
        /// </summary>
        /// <param name="decimalesEjeX">Cantidad de decimales para las etiquetas del eje X (0, 1, 2...).</param>
        private static void ConfigurarHistogramaChart(Chart chart, IList<double> values, string tituloEjeX, string tituloEjeY, int decimalesEjeX = 0)
        {
            chart.Series.Clear();
            chart.ChartAreas.Clear();
            chart.Titles.Clear();

            chart.ChartAreas.Add(new ChartArea("Default"));
            var area = chart.ChartAreas[0];
            area.AxisX.Title = tituloEjeX;
            area.AxisY.Title = tituloEjeY;
            area.AxisX.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            area.AxisY.MajorGrid.LineColor = System.Drawing.Color.LightGray;
            area.BackColor = System.Drawing.Color.White;
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Angle = -45;

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
                dlg.Filter = "Ensayo de carga (*.ltst)|*.ltst";
                dlg.DefaultExt = "ltst";
                string servidor = (_definition?.Server ?? "");
                int hilos = _definition?.NroHilos ?? 0;
                double duracion = _definition?.DuracionSeg ?? 0;
                int pausa = _definition?.PausaMs ?? 0;
                string hora = _report.Fecha.ToString("HHmmss");
                string sufijoRampa = (_definition != null && _definition.UsarRampa) ? "-ramp" : "";
                dlg.FileName = $"{servidor}-{hilos}-{duracion}-{pausa}{sufijoRampa}-{hora}";
                if (dlg.ShowDialog() != DialogResult.OK) return;

                try
                {
                    GuardarEnsayoCompleto(dlg.FileName);
                    MessageBox.Show("Ensayo guardado correctamente.", "Guardar ensayo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar: {ex.Message}", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void tsbCompararEnsayosCarga_Click(object sender, EventArgs e)
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
            var ensayo = new LoadTestFile
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

        internal static LoadTestFile LeerEnsayoGuardado(string path)
        {
            string json = File.ReadAllText(path);

            LoadTestFile ensayo = null;
            try
            {
                ensayo = JsonConvert.DeserializeObject<LoadTestFile>(json);
            }
            catch
            {
                // Compatibilidad: JSON antiguo con solo LoadTestReport.
            }

            if (ensayo != null && ensayo.Reporte != null)
            {
                return new LoadTestFile
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

            return new LoadTestFile
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
