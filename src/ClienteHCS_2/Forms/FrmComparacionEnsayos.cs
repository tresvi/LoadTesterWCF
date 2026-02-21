using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ClienteHCS_2
{
    public partial class FrmComparacionEnsayos : Form
    {
        private readonly LoadTestReport _actual;
        private readonly LoadTestDefinition _defActual;
        private readonly LoadTestReport _comparado;
        private readonly LoadTestDefinition _defComparado;
        private readonly string _nombreActual;
        private readonly string _nombreComparado;

        public FrmComparacionEnsayos(
            LoadTestReport actual,
            LoadTestDefinition definitionActual,
            LoadTestReport comparado,
            LoadTestDefinition definitionComparado,
            string nombreActual,
            string nombreComparado)
        {
            _actual = actual ?? throw new ArgumentNullException(nameof(actual));
            _defActual = definitionActual ?? new LoadTestDefinition();
            _comparado = comparado ?? throw new ArgumentNullException(nameof(comparado));
            _defComparado = definitionComparado ?? new LoadTestDefinition();
            _nombreActual = string.IsNullOrWhiteSpace(nombreActual) ? "Ensayo actual" : nombreActual;
            _nombreComparado = string.IsNullOrWhiteSpace(nombreComparado) ? "Ensayo comparado" : nombreComparado;

            InitializeComponent();
            CargarComparacion();
        }

        private void CargarComparacion()
        {
            lblTitulo.Text = string.Format(CultureInfo.InvariantCulture,"{0} vs {1}", _nombreActual,_nombreComparado);

            bool hayAdvertenciaFuerte;
            string advertencias = GenerarAdvertencias(out hayAdvertenciaFuerte);
            if (string.IsNullOrEmpty(advertencias))
            {
                lblAdvertencias.Text = "Comparación homogénea: configuración equivalente en hilos, pausa, conexión única y duración.";
                lblAdvertencias.ForeColor = Color.DarkGreen;
            }
            else
            {
                lblAdvertencias.Text = advertencias;
                lblAdvertencias.ForeColor = hayAdvertenciaFuerte ? Color.DarkRed : Color.DarkOrange;
            }

            dgvMetricas.Columns["colActual"].HeaderText = _nombreActual;
            dgvMetricas.Columns["colComparado"].HeaderText = _nombreComparado;

            var metricas = new[]
            {
                new Metrica("Throughput total (trx/seg)", _actual.ThroughputTrxSeg, _comparado.ThroughputTrxSeg, true, "F2"),
                new Metrica("Tasa éxito transacciones (%)", _actual.TasaExitoTransacciones, _comparado.TasaExitoTransacciones, true, "F1"),
                new Metrica("Tasa éxito hilos (%)", _actual.TasaExitoHilos, _comparado.TasaExitoHilos, true, "F1"),
                new Metrica("Estabilidad latencia", _actual.EstabilidadLatencia, _comparado.EstabilidadLatencia, true, "F4"),
                new Metrica("Consistencia rendimiento", _actual.ConsistenciaRendimiento, _comparado.ConsistenciaRendimiento, true, "F4"),
                new Metrica("Latencia p95 (ms)", _actual.LatenciaP95Ms, _comparado.LatenciaP95Ms, false, "F0")
            };

            chartRadar.Series.Clear();
            var serieActual = new Series(_nombreActual)
            {
                ChartType = SeriesChartType.Radar,
                BorderWidth = 2,
                Color = Color.FromArgb(220, 52, 152, 219),
                MarkerStyle = MarkerStyle.Circle,
                MarkerSize = 6
            };
            var serieComparado = new Series(_nombreComparado)
            {
                ChartType = SeriesChartType.Radar,
                BorderWidth = 2,
                Color = Color.FromArgb(220, 46, 204, 113),
                MarkerStyle = MarkerStyle.Diamond,
                MarkerSize = 6
            };

            chartRadar.Series.Add(serieActual);
            chartRadar.Series.Add(serieComparado);

            dgvMetricas.Rows.Clear();
            foreach (Metrica metrica in metricas)
            {
                double scoreActual;
                double scoreComparado;
                CalcularScores(metrica, out scoreActual, out scoreComparado);

                serieActual.Points.AddXY(metrica.Nombre, scoreActual);
                serieComparado.Points.AddXY(metrica.Nombre, scoreComparado);

                string vActual = metrica.Actual.ToString(metrica.Formato, CultureInfo.InvariantCulture);
                string vComparado = metrica.Comparado.ToString(metrica.Formato, CultureInfo.InvariantCulture);
                string deltaTxt;
                string lectura;
                if (metrica.MayorEsMejor)
                {
                    var delta = metrica.Actual - metrica.Comparado;
                    var deltaPct = Math.Abs(metrica.Comparado) > double.Epsilon
                        ? (delta / metrica.Comparado) * 100.0
                        : 0;
                    deltaTxt = string.Format(CultureInfo.InvariantCulture, "{0:+0.##;-0.##;0} ({1:+0.##;-0.##;0}%)", delta, deltaPct);
                    lectura = delta > 0 ? "Mejor actual" : (delta < 0 ? "Mejor comparado" : "Igual");
                }
                else
                {
                    var delta = metrica.Actual - metrica.Comparado;
                    var deltaPct = Math.Abs(metrica.Comparado) > double.Epsilon
                        ? (delta / metrica.Comparado) * 100.0
                        : 0;
                    deltaTxt = string.Format(CultureInfo.InvariantCulture, "{0:+0.##;-0.##;0} ms ({1:+0.##;-0.##;0}%)", delta, deltaPct);
                    lectura = delta < 0 ? "Mejor actual" : (delta > 0 ? "Mejor comparado" : "Igual");
                }

                int row = dgvMetricas.Rows.Add(metrica.Nombre, vActual, vComparado, deltaTxt, lectura);
                if (lectura == "Mejor actual")
                    dgvMetricas.Rows[row].DefaultCellStyle.BackColor = Color.FromArgb(235, 248, 235);
                else if (lectura == "Mejor comparado")
                    dgvMetricas.Rows[row].DefaultCellStyle.BackColor = Color.FromArgb(255, 244, 232);
            }
        }

        private static void CalcularScores(Metrica metrica, out double scoreActual, out double scoreComparado)
        {
            scoreActual = 0;
            scoreComparado = 0;

            if (metrica.MayorEsMejor)
            {
                var referencia = Math.Max(metrica.Actual, metrica.Comparado);
                if (referencia <= 0) return;
                scoreActual = Clamp((metrica.Actual / referencia) * 100.0);
                scoreComparado = Clamp((metrica.Comparado / referencia) * 100.0);
                return;
            }

            if (metrica.Actual <= 0 || metrica.Comparado <= 0) return;
            var mejor = Math.Min(metrica.Actual, metrica.Comparado);
            scoreActual = Clamp((mejor / metrica.Actual) * 100.0);
            scoreComparado = Clamp((mejor / metrica.Comparado) * 100.0);
        }

        private static double Clamp(double value)
        {
            if (value < 0) return 0;
            if (value > 100) return 100;
            return value;
        }

        private string GenerarAdvertencias(out bool hayAdvertenciaFuerte)
        {
            hayAdvertenciaFuerte = false;
            var mensajes = new List<string>();

            if (_defActual.NroHilos != _defComparado.NroHilos)
            {
                hayAdvertenciaFuerte = true;
                mensajes.Add(string.Format(
                    CultureInfo.InvariantCulture,
                    "No homogéneo: número de hilos distinto ({0} vs {1}).",
                    _defActual.NroHilos,
                    _defComparado.NroHilos));
            }

            if (_defActual.PausaMs != _defComparado.PausaMs)
            {
                hayAdvertenciaFuerte = true;
                mensajes.Add(string.Format(
                    CultureInfo.InvariantCulture,
                    "No homogéneo: pausa entre envíos distinta ({0} ms vs {1} ms).",
                    _defActual.PausaMs,
                    _defComparado.PausaMs));
            }

            if (_defActual.UsarUnicaConexion != _defComparado.UsarUnicaConexion)
            {
                hayAdvertenciaFuerte = true;
                mensajes.Add(string.Format(
                    CultureInfo.InvariantCulture,
                    "No homogéneo: uso de única conexión distinto ({0} vs {1}).",
                    _defActual.UsarUnicaConexion ? "Sí" : "No",
                    _defComparado.UsarUnicaConexion ? "Sí" : "No"));
            }

            if (_defActual.DuracionSeg > 0 && _defComparado.DuracionSeg > 0)
            {
                double diffPct = Math.Abs(_defActual.DuracionSeg - _defComparado.DuracionSeg) /
                                 Math.Max(_defActual.DuracionSeg, _defComparado.DuracionSeg) * 100.0;
                if (diffPct > 10)
                {
                    mensajes.Add(string.Format(
                        CultureInfo.InvariantCulture,
                        "Duración distinta: {0:F1}s vs {1:F1}s (diferencia {2:F1}%). Interpretar resultados con cautela.",
                        _defActual.DuracionSeg,
                        _defComparado.DuracionSeg,
                        diffPct));
                }
            }
            else if (Math.Abs(_defActual.DuracionSeg - _defComparado.DuracionSeg) > double.Epsilon)
            {
                mensajes.Add(string.Format(
                    CultureInfo.InvariantCulture,
                    "Duración distinta: {0:F1}s vs {1:F1}s. Interpretar resultados con cautela.",
                    _defActual.DuracionSeg,
                    _defComparado.DuracionSeg));
            }

            return string.Join(Environment.NewLine, mensajes.ToArray());
        }

        private sealed class Metrica
        {
            public Metrica(string nombre, double actual, double comparado, bool mayorEsMejor, string formato)
            {
                Nombre = nombre;
                Actual = actual;
                Comparado = comparado;
                MayorEsMejor = mayorEsMejor;
                Formato = formato;
            }

            public string Nombre { get; private set; }
            public double Actual { get; private set; }
            public double Comparado { get; private set; }
            public bool MayorEsMejor { get; private set; }
            public string Formato { get; private set; }
        }
    }
}
