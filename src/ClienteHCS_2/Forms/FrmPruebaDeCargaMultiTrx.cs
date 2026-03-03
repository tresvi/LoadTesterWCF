using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteHCS_2.Forms
{
    public partial class FrmPruebaDeCargaMultiTrx : Form
    {
        private const int NRO_MAXIMO_CLIENTES = 10;
        private const int NRO_MAX_CARACTERES_SALIDA = 100000;

        OpenFileDialog _openFileDialog = new OpenFileDialog();
        List<Task> _tasks = new List<Task>();
        CancellationTokenSource _cancelationTokenSource;
        Random _random = new Random(DateTime.Now.Millisecond);
        int _contadorClientes = 0;
        object _locker = new object();
        StreamWriter _outputFile = null;


        private readonly string _server;
        private readonly NetworkCredential _networkCredential;

        public FrmPruebaDeCargaMultiTrx(string server, NetworkCredential networkCredential)
        {
            _server = server;
            _networkCredential = networkCredential;
            InitializeComponent();

            lblServer.Text = $"Server: {_server}";
            if (networkCredential.UserName == "")
                lblCredenciales.Text = $@"Credenciales: {Environment.UserDomainName}\{Environment.UserName}";
            else
                lblCredenciales.Text = $@"Credenciales: {networkCredential.Domain}\{networkCredential.UserName}";
        }


        private void AgregarCliente(object sender, EventArgs e)
        {
            if (dgvTransacciones.Rows.Count == NRO_MAXIMO_CLIENTES)
            {
                MessageBox.Show(this, $"Nro maximo de clientes alcanzado ({NRO_MAXIMO_CLIENTES})", "Aviso"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Transaction transaccion = AbrirTrx();
            if (transaccion == null) return;

            dgvTransacciones.Rows.Add();
            int lastRowIndex = dgvTransacciones.Rows.Count - 1;
            DataGridViewRow newRow = dgvTransacciones.Rows[lastRowIndex];
            newRow.Cells["Cliente"].Value = ++_contadorClientes;
            newRow.Cells["TxFile"].Value = transaccion.TXFile;
            newRow.Cells["Mensaje"].Value = transaccion.Mensaje;
            newRow.Cells["EsHexa"].Value = transaccion.EsHexa ? "SI" : "NO";
            newRow.Cells["Habilitado"].Value = true;
            newRow.Cells["ObjetoTransaccion"].Value = transaccion;
        }


        private void dgvTransacciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvTransacciones.Columns[e.ColumnIndex].Name == "Habilitado")
            {
                DataGridViewRow filaCliente = dgvTransacciones.Rows[e.RowIndex];
                bool habilitado = (bool) filaCliente.Cells[e.ColumnIndex].Value;
                filaCliente.Cells[e.ColumnIndex].Value = !habilitado;
            }
        }


        private Transaction AbrirTrx()
        {
            _openFileDialog.Title = "Abrir transaccion de HCS";
            _openFileDialog.Filter = "Transacciones HCS|*.hcs";
            DialogResult result = _openFileDialog.ShowDialog();
            if (_openFileDialog.FileName == "" || result == DialogResult.Cancel) return null;

            try
            {
                Transaction transaccion = new Transaction();
                transaccion.LoadFromFile(_openFileDialog.FileName);

                bool trxValida = transaccion.Validar(out string msjeError);
                if (!trxValida)
                {
                    MessageBox.Show(this, msjeError, "Trx Invalida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                return transaccion;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el archivo. Detalles: {ex.Message}", "Abrir archivo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (dgvTransacciones.Rows.Count == 0)
            {
                MessageBox.Show("Para iniciar la prueba, cree al menos 1 cliente", "Iniciar", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            CrearFileLogger();

            _cancelationTokenSource = new CancellationTokenSource();
            CancellationToken token = _cancelationTokenSource.Token;

            //Por cada fila en el datagrid, creare un cliente con su hilo pegandole a su trx correspondiente
            foreach (DataGridViewRow  row in dgvTransacciones.Rows)
            {
                int nroCliente = (int)row.Cells["Cliente"].Value;
                Transaction transaccion = (Transaction)row.Cells["ObjetoTransaccion"].Value;
                _tasks.Add(Task.Run(() => TaskEnviarRecibir(nroCliente, transaccion, token), token));
            }

            btnAgregarCliente.Enabled = false;
            nudTransmitirCada.Enabled = false;
            btnIniciar.Enabled = false;
            btnFinalizar.Enabled = true;
            lblInicio.Text = $"Inicio: {DateTime.Now:yyyy/MM/dd hh:mm:ss}";
        }

        public void TaskEnviarRecibir(int nroCliente, Transaction transaccion, CancellationToken token)
        {
            WriteOutput($"Cliente #{nroCliente} Iniciando. Se escribirá en TxFile {transaccion.TXFile}");
            int nroEnvio = 0;

            Thread.Sleep(_random.Next(0, 1200)); //Solo para que no arranquen al mismo tiempo
            DataGridViewRow rowCliente = dgvTransacciones.Rows[nroCliente - 1];

            while (!token.IsCancellationRequested)
            {
                if ((bool)rowCliente.Cells["Habilitado"].Value == false)
                {
                    Thread.Sleep(250);
                    continue;
                }

                try
                {
                    Thread.Sleep((int)nudTransmitirCada.Value);
                    Stopwatch sw = new Stopwatch();
                    sw.Start();
                    nroEnvio++;

                    using (HCSClient hcsClient = new HCSClient(_server, _networkCredential))
                    {
                        hcsClient.EnviarYRecibir(transaccion, true).GetAwaiter().GetResult();
                        WriteOutput($"Cliente #{nroCliente} nroEnvio {nroEnvio}. Envio OK en {sw.ElapsedMilliseconds} ms");
                    }
                }
                catch (Exception ex)
                {
                    WriteOutput($"**ERROR**: Cliente #{nroCliente} nroEnvio {nroEnvio}. Fallo al enviar. {ex.Message}");
                }
            }
            WriteOutput($"**FIN** Cliente #{nroCliente} Finalizó con un total de {nroEnvio} envíos");
        }


        //delegate void WriteOutputCallback(string msje);
        private void WriteOutput(string text)
        {
            string fechaHora = DateTime.Now.ToString("yy/MM/dd HH:mm:ss");

            if (chkLogText.Checked)
            { 
                if (txtSalida.InvokeRequired)
                {
                    // WriteOutputCallback writeCallback = new WriteOutputCallback(WriteOutput);
                    // this.BeginInvoke(writeCallback, new object[] { text });
                    txtSalida.BeginInvoke((MethodInvoker)(() => WriteOutput(text))); // Se evita la delegación explícita
                    return;
                }
                
                if (txtSalida.Text.Length > NRO_MAX_CARACTERES_SALIDA)
                    txtSalida.Text = txtSalida.Text.Substring(txtSalida.Text.Length - NRO_MAX_CARACTERES_SALIDA);

                txtSalida.AppendText($"{fechaHora} - {text}{Environment.NewLine}");
            }

            if (chkLogArchivo.Checked)
            {
                if (_outputFile != null)
                {
                    lock (_locker)
                    {
                        try { _outputFile.WriteLine($"{fechaHora} - {text}"); } catch { }
                    }
                }
            }
        }


        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            _cancelationTokenSource?.Cancel();
            Task.WaitAll(_tasks.ToArray());
            nudTransmitirCada.Enabled = true;
            btnAgregarCliente.Enabled = true;
            btnIniciar.Enabled = true;
            btnFinalizar.Enabled = false;
            _outputFile?.Close();
        }


        private void FrmPruebaDeCargaMultiTrx_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_cancelationTokenSource != null && !_cancelationTokenSource.IsCancellationRequested)
            {
                MessageBox.Show("Hay un ensayo en curso. Primero finalicelo para poder salir.", "Salir", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Cancel = true;
            }
        }


        private void btnAyuda_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, $"Crea la cantidad de clientes independientes especificados " +
                $"(hasta {NRO_MAXIMO_CLIENTES} clientes) y envia las transacciones especificadas para cada uno. Los " +
                $"envios se harán según los milisegundos configurados en el campo 'Transmitir cada'.\n" +
                $"En otras palabras, simula la presencia de varios clientes consumiendo diferentes transacciones.\n\n" +
                $"Los clientes mantienen cada uno su conexion abierta durante todo el ensayo."
                , "Ayuda", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtSalida.Text = "";
        }

        private void dgvTransacciones_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (!_cancelationTokenSource.IsCancellationRequested)
            {
                MessageBox.Show("No puede eliminar un cliente durante un ensayo. En su lugar, deshabilitelo, o bien detenga el ensayo para eliminarlo.", "Salir", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                e.Cancel = true;
            }
            else
            {
                DialogResult respuesta = MessageBox.Show("Confirma la eliminación de este cliente?", "Eliminar cliente", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.No) e.Cancel = true;
            }
        }


        void CrearFileLogger()
        {
            try
            {
                _outputFile?.Close();
                string fileName = $"CargaMultiTRX_{DateTime.Now:yyyMMdd_hhmmss_fff}.log";
                _outputFile = new StreamWriter(fileName);
                _outputFile.AutoFlush = true;
            }
            catch (Exception ex)
            {
                WriteOutput($"Error al crear el archivo de log del ensayo. Exception: {ex}");
            }
        }

    }
}
