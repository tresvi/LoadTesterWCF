using ClienteHCS_2.Forms;
using ClienteHCS_2.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace ClienteHCS_2
{
    public partial class FrmMain : Form
    {
        private string _archivoAbierto = null;


        public FrmMain()
        {
            InitializeComponent();
            string user = Environment.UserDomainName + @"\" + Environment.UserName;
            optInteractivo.Text = optInteractivo.Text.Replace("%username%", user);
            LoadTitleBar();

            pbLoadingGif.Parent = this;
            pbLoadingGif.BringToFront();
            
            // Sincronizar el ToolStripTextBox con la configuración guardada
            tstHCSServer.Text = Properties.Settings.Default.HCSServer;
        }


        private async void btnEnviar_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            Transaction transaccion = new Transaction(txtMensaje.Text, txtTXFile.Text, cbEsHexa.Checked, "");

            if (!transaccion.Validar(out string msjeError))
            {
                MessageBox.Show($"Transaccion no definida correctamente. Detalles: {msjeError}", "Enviar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                NetworkCredential networkCredential = GetNetworkCredentials();

                //Ejecución y medicion de tiempo de respuesta.
                HCSClient cliente = new HCSClient(tstHCSServer.Text, networkCredential);

                btnEnviar.Enabled = false;
                pbLoadingGif.Visible = true;

                sw.Start();
                List<string> respuesta = await cliente.EnviarYRecibir(transaccion, true);
                sw.Stop();

                //La edicion del texto se trabaja en un StringBuilder en lugar del textbox para disminuir el congelamiento de la pantalla
                StringBuilder sbSalida = new StringBuilder();
                sbSalida.Append(txtRespuesta.Text);
                sbSalida.Append($"************************{DateTime.Now.ToString("HH:mm:ss")}|" +
                            $"{sw.ElapsedMilliseconds.ToString()}ms|" +
                            $"Nro Msjes: {respuesta.Count}************************" + Environment.NewLine);

                long contadorCaracteres = 0;
                foreach (string msje in respuesta)
                {
                    sbSalida.Append(msje + Environment.NewLine);
                    contadorCaracteres += msje.Length;
                }

                txtRespuesta.SuspendLayout();
                txtRespuesta.Text = sbSalida.ToString();
                //Bajo la ScrollBar para mostrar el ultimo texto ingresado
                txtRespuesta.SelectionStart = txtRespuesta.Text.Length;
                txtRespuesta.ScrollToCaret();
                lblResumenRespuesta.Text = $"Tiempo Respuesta [mSeg]: {sw.ElapsedMilliseconds}  |  " +
                    $"Ultima respuesta: {respuesta.Count} mensajes. Total {contadorCaracteres} caracteres  |  " +
                    $"Nro Msjes: {respuesta.Count}";

                txtRespuesta.ResumeLayout();
                btnEnviar.Enabled = true;
                pbLoadingGif.Visible = false;
            }
            catch (Exception ex)
            {
                btnEnviar.Enabled = true;
                pbLoadingGif.Visible = false;
                txtRespuesta.ResumeLayout();
                lblResumenRespuesta.Text = sw.ElapsedMilliseconds.ToString();
                MessageBox.Show("ERROR: " + ex.Message + " \n\n STACKTRACE:" + ex.StackTrace + "\n\n SOURCE:" + ex.Source, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private NetworkCredential GetNetworkCredentials()
        {
            if (optInteractivo.Checked) return CredentialCache.DefaultNetworkCredentials;

            if (txtPassword.Text.Trim() == "" || txtUsuario.Text.Trim() == "")
                throw new Exception(@"Debe especificar nombre de Usuario (Domain\User) y Password");

            int posicionBarra = txtUsuario.Text.IndexOf(@"\");
            if (posicionBarra == 0) throw new Exception(@"Debe especificar nombre de Usuario (Domain\User) y Password");

            string userDomain = txtUsuario.Text.Substring(0, posicionBarra);
            string userName = txtUsuario.Text.Substring(posicionBarra + 1);

            return new NetworkCredential(userName, txtPassword.Text, userDomain);
        }


        private void optOtrasCredenciales_CheckedChanged(object sender, EventArgs e)
        {
            txtUsuario.Enabled = txtPassword.Enabled = lblUsuario.Enabled = lblContrasenia.Enabled = optOtrasCredenciales.Checked;
        }


        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Guardo la ultima configuracion
            Settings.Default.TXFile = txtTXFile.Text;
            Settings.Default.Usuario = txtUsuario.Text;
            Settings.Default.EsHexa = cbEsHexa.Checked;
            Settings.Default.HCSServer = tstHCSServer.Text;
            Settings.Default.Save();
        }


        private void tsbAbrirTrx_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Abrir transaccion de HCS";
            ofd.Filter = "Transacciones HCS|*.hcs";
            ofd.ShowDialog();
            if (ofd.FileName == "") return;

            try
            {
                Transaction transaccion = new Transaction();
                transaccion.LoadFromFile(ofd.FileName);

                txtTXFile.Text = transaccion.TXFile;
                txtMensaje.Text = transaccion.Mensaje;
                cbEsHexa.Checked = transaccion.EsHexa;

                _archivoAbierto = ofd.FileName;
                LoadTitleBar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el archivo. Detalles: {ex.Message}", "Abrir archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }


        private void tsbGuardarTrx_Click(object sender, EventArgs e)
        {
            if (_archivoAbierto == null)
            {
                tsbGuardarTrxComo_Click(sender, e);
                return;
            }
            else 
            {
                DialogResult result = MessageBox.Show(this, "Confirma guardar los cambios en el archivo abierto actualmente?"
                    , "Guardar", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel) return;
            }

            try
            {
                Transaction transaccion = new Transaction(txtMensaje.Text, txtTXFile.Text, cbEsHexa.Checked, "");

                if (!transaccion.Validar(out string msjeError))
                {
                    MessageBox.Show($"Transaccion no definida correctamente. Detalles: {msjeError}", "Enviar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                transaccion.SaveToFile(_archivoAbierto);
                LoadTitleBar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar Guardar el archivo. Detalles: {ex.Message}", "Guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void tsbGuardarTrxComo_Click(object sender, EventArgs e)
        {
            try
            {
                Transaction transaccion = new Transaction(txtMensaje.Text, txtTXFile.Text, cbEsHexa.Checked, "");

                if (!transaccion.Validar(out string msjeError))
                {
                    MessageBox.Show($"Transaccion no definida correctamente. Detalles: {msjeError}", "Enviar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Guardar transaccion de HCS como...";
                sfd.Filter = "Transacciones HCS|*.hcs";
                sfd.ShowDialog();

                if (string.IsNullOrWhiteSpace(sfd.FileName)) return;

                if (File.Exists(sfd.FileName))
                {
                    DialogResult respuesta = MessageBox.Show($"Ya existe un archivo de nombre {sfd.FileName}, desea reemplazarlo"
                        , "Guardar Como", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (respuesta == DialogResult.No) return;
                }

                transaccion.SaveToFile(sfd.FileName);
                MessageBox.Show("La transaccion se guardo correctamente", "Guardar Transaccion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _archivoAbierto = sfd.FileName;
                LoadTitleBar();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al intentar Guardar Como. Detalles: {ex.Message}", "Guardar Como", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadTitleBar()
        {
            string serverName = "";
            try { serverName = Environment.MachineName; }
            catch { } 

            this.Text = $"ClienteHCS | PID: {Process.GetCurrentProcess().Id} | Equipo: {serverName}";
            if (_archivoAbierto != null)
                this.Text += this.Text = $" | Archivo: {_archivoAbierto}";
        }


        private void tsbLoadTest_Click(object sender, EventArgs e)
        {
            Transaction transaccion = new Transaction(txtMensaje.Text, txtTXFile.Text, cbEsHexa.Checked, "");
            if (!transaccion.Validar(out string msjeError))
            {
                MessageBox.Show($"Transaccion no definida correctamente. Detalles: {msjeError}", "Enviar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmPruebaDeCarga frmLoadTest = new FrmPruebaDeCarga(tstHCSServer.Text, transaccion, GetNetworkCredentials());
            frmLoadTest.ShowDialog();
        }


        private void tsbLoadTestMultiTrx_Click(object sender, EventArgs e)
        {
            FrmPruebaDeCargaMultiTrx frmLoadTest = new FrmPruebaDeCargaMultiTrx(tstHCSServer.Text, GetNetworkCredentials());
            frmLoadTest.ShowDialog();
        }


        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtRespuesta.Text = "";
        }


        private void tsbContinutyTest_Click(object sender, EventArgs e)
        {
            Transaction transaccion = new Transaction(txtMensaje.Text, txtTXFile.Text, cbEsHexa.Checked, "");
            if (!transaccion.Validar(out string msjeError))
            {
                MessageBox.Show($"Transaccion no definida correctamente. Detalles: {msjeError}", "Enviar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FrmPruebaDeContinuidad frmContinuityTest = new FrmPruebaDeContinuidad(tstHCSServer.Text, transaccion, GetNetworkCredentials());
            frmContinuityTest.ShowDialog();
        }


        private void tsbInfo_Click(object sender, EventArgs e)
        {
            string version = "0.0.0";
            try
            {
                version = typeof(FrmMain).Assembly.GetName().Version.ToString();
            }
            catch { }
            MessageBox.Show($"Cliente HCS - Version {version}");
        }


        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            pbLoadingGif.Left = (this.ClientSize.Width - pbLoadingGif.Width) / 2;
            pbLoadingGif.Top = (this.ClientSize.Height - pbLoadingGif.Height) / 2;
        }


        private void btnCopiar_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.Clear();
                Clipboard.SetText(txtRespuesta.Text, TextDataFormat.UnicodeText);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo copiar al portapapeles:\n" + ex.Message);
            }
        }

  
        private void tsbDetallesLoadTest_Click(object sender, EventArgs e)
        {
            using (FrmDetallesEnsayo frm = new FrmDetallesEnsayo())
            {
                frm.ShowDialog(this);
            }
        }

    }
}