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
            nudIncrementoHilosPorPaso.Value = Math.Max(nudIncrementoHilosPorPaso.Minimum, Math.Min(nudIncrementoHilosPorPaso.Maximum, IncrementoHilos));
            double iv = IntervaloRampaSeg;
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

            IncrementoHilos = (int)nudIncrementoHilosPorPaso.Value;
            IntervaloRampaSeg = (double)nudIntervaloSeg.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private bool Validar(out string error)
        {
            error = null;

            if (TotalHilosEnsayo < 1)
            {
                error = "El número de hilos del ensayo debe ser al menos 1.";
                return false;
            }

            return true;
        }

    }
}
