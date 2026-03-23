using System;
using System.Windows.Forms;

namespace ClienteHCS_2
{
    public partial class FrmConfiguracionRampa : Form
    {
        /// <summary>Número de hilos del ensayo (para validar coherencia del incremento).</summary>
        public int TotalHilosEnsayo { get; set; }

        public int IncrementoHilos { get; set; } = 10;

        public double IntervaloRampaSeg { get; set; } = 5;

        public FrmConfiguracionRampa()
        {
            InitializeComponent();
        }

        private void FrmConfiguracionRampa_Load(object sender, EventArgs e)
        {
            int inc = IncrementoHilos < 1 ? 1 : IncrementoHilos;
            nudIncremento.Value = Math.Max(nudIncremento.Minimum, Math.Min(nudIncremento.Maximum, inc));
            double iv = IntervaloRampaSeg < 1 ? 1 : IntervaloRampaSeg;
            nudIntervaloSeg.Value = (decimal)Math.Max((double)nudIntervaloSeg.Minimum,
                Math.Min((double)nudIntervaloSeg.Maximum, iv));
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (!Validar(out string error))
            {
                MessageBox.Show(this, error, "Configuración de rampa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IncrementoHilos = (int)nudIncremento.Value;
            IntervaloRampaSeg = (double)nudIntervaloSeg.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private bool Validar(out string error)
        {
            error = null;
            int inc = (int)nudIncremento.Value;
            double intervalo = (double)nudIntervaloSeg.Value;

            if (TotalHilosEnsayo < 1)
            {
                error = "El número de hilos del ensayo debe ser al menos 1.";
                return false;
            }

            if (inc < 1)
            {
                error = "El incremento de hilos debe ser al menos 1.";
                return false;
            }

            if (inc > 1000)
            {
                error = "El incremento de hilos no puede superar 1000.";
                return false;
            }

            if (intervalo < 1)
            {
                error = "El intervalo entre pasos debe ser de al menos 1 segundo.";
                return false;
            }

            if (intervalo > 600)
            {
                error = "El intervalo entre pasos no puede superar 600 segundos.";
                return false;
            }

            return true;
        }

    }
}
