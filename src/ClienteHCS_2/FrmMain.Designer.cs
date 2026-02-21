using System;

namespace ClienteHCS_2
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.grpCredenciales = new System.Windows.Forms.GroupBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblContrasenia = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.optOtrasCredenciales = new System.Windows.Forms.RadioButton();
            this.optInteractivo = new System.Windows.Forms.RadioButton();
            this.labelTxFile = new System.Windows.Forms.Label();
            this.txtNotas = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAbrirTrx = new System.Windows.Forms.ToolStripButton();
            this.tsbGuardarTrx = new System.Windows.Forms.ToolStripButton();
            this.tsbGuardarTrxComo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLoadTest = new System.Windows.Forms.ToolStripButton();
            this.tsbDetallesLoadTest = new System.Windows.Forms.ToolStripButton();
            this.tsbMedidasRendimiento = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLoadTestMultiTrx = new System.Windows.Forms.ToolStripButton();
            this.tsbContinutyTest = new System.Windows.Forms.ToolStripButton();
            this.tsbInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tslServer = new System.Windows.Forms.ToolStripLabel();
            this.tstHCSServer = new System.Windows.Forms.ToolStripTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.lblResumenRespuesta = new System.Windows.Forms.Label();
            this.txtRespuesta = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.cbEsHexa = new System.Windows.Forms.CheckBox();
            this.txtTXFile = new System.Windows.Forms.TextBox();
            this.pbLoadingGif = new System.Windows.Forms.PictureBox();
            this.grpCredenciales.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingGif)).BeginInit();
            this.SuspendLayout();
            // 
            // grpCredenciales
            // 
            this.grpCredenciales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCredenciales.Controls.Add(this.txtPassword);
            this.grpCredenciales.Controls.Add(this.lblContrasenia);
            this.grpCredenciales.Controls.Add(this.txtUsuario);
            this.grpCredenciales.Controls.Add(this.lblUsuario);
            this.grpCredenciales.Controls.Add(this.optOtrasCredenciales);
            this.grpCredenciales.Controls.Add(this.optInteractivo);
            this.grpCredenciales.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCredenciales.Location = new System.Drawing.Point(14, 88);
            this.grpCredenciales.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpCredenciales.Name = "grpCredenciales";
            this.grpCredenciales.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpCredenciales.Size = new System.Drawing.Size(1322, 95);
            this.grpCredenciales.TabIndex = 4;
            this.grpCredenciales.TabStop = false;
            this.grpCredenciales.Text = "Credenciales";
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(919, 37);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(166, 33);
            this.txtPassword.TabIndex = 5;
            // 
            // lblContrasenia
            // 
            this.lblContrasenia.AutoSize = true;
            this.lblContrasenia.Enabled = false;
            this.lblContrasenia.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrasenia.Location = new System.Drawing.Point(842, 42);
            this.lblContrasenia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContrasenia.Name = "lblContrasenia";
            this.lblContrasenia.Size = new System.Drawing.Size(73, 27);
            this.lblContrasenia.TabIndex = 5;
            this.lblContrasenia.Text = "&Pass:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ClienteHCS_2.Properties.Settings.Default, "Usuario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(632, 37);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(168, 33);
            this.txtUsuario.TabIndex = 4;
            this.txtUsuario.Text = global::ClienteHCS_2.Properties.Settings.Default.Usuario;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Enabled = false;
            this.lblUsuario.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(553, 42);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(71, 27);
            this.lblUsuario.TabIndex = 3;
            this.lblUsuario.Text = "&User:";
            // 
            // optOtrasCredenciales
            // 
            this.optOtrasCredenciales.AutoSize = true;
            this.optOtrasCredenciales.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optOtrasCredenciales.Location = new System.Drawing.Point(439, 40);
            this.optOtrasCredenciales.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.optOtrasCredenciales.Name = "optOtrasCredenciales";
            this.optOtrasCredenciales.Size = new System.Drawing.Size(86, 31);
            this.optOtrasCredenciales.TabIndex = 2;
            this.optOtrasCredenciales.Text = "Otro";
            this.optOtrasCredenciales.UseVisualStyleBackColor = true;
            this.optOtrasCredenciales.CheckedChanged += new System.EventHandler(this.optOtrasCredenciales_CheckedChanged);
            // 
            // optInteractivo
            // 
            this.optInteractivo.AutoSize = true;
            this.optInteractivo.Checked = true;
            this.optInteractivo.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optInteractivo.Location = new System.Drawing.Point(12, 40);
            this.optInteractivo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.optInteractivo.Name = "optInteractivo";
            this.optInteractivo.Size = new System.Drawing.Size(323, 31);
            this.optInteractivo.TabIndex = 1;
            this.optInteractivo.TabStop = true;
            this.optInteractivo.Text = "Interactivo (%username%)";
            this.optInteractivo.UseVisualStyleBackColor = true;
            // 
            // labelTxFile
            // 
            this.labelTxFile.AutoSize = true;
            this.labelTxFile.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTxFile.Location = new System.Drawing.Point(27, 212);
            this.labelTxFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelTxFile.Name = "labelTxFile";
            this.labelTxFile.Size = new System.Drawing.Size(354, 27);
            this.labelTxFile.TabIndex = 26;
            this.labelTxFile.Text = "Archivo TxFile (sin extensión):";
            // 
            // txtNotas
            // 
            this.txtNotas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotas.BackColor = System.Drawing.SystemColors.Control;
            this.txtNotas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotas.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotas.ForeColor = System.Drawing.Color.DarkGreen;
            this.txtNotas.Location = new System.Drawing.Point(14, 752);
            this.txtNotas.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.ReadOnly = true;
            this.txtNotas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotas.Size = new System.Drawing.Size(1316, 91);
            this.txtNotas.TabIndex = 27;
            this.txtNotas.Text = resources.GetString("txtNotas.Text");
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAbrirTrx,
            this.tsbGuardarTrx,
            this.tsbGuardarTrxComo,
            this.toolStripSeparator2,
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.tsbLoadTest,
            this.tsbDetallesLoadTest,
            this.tsbMedidasRendimiento,
            this.toolStripSeparator4,
            this.toolStripLabel2,
            this.toolStripSeparator3,
            this.tsbLoadTestMultiTrx,
            this.tsbContinutyTest,
            this.tsbInfo,
            this.toolStripSeparator5,
            this.toolStripLabel3,
            this.tslServer,
            this.tstHCSServer});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1349, 57);
            this.toolStrip1.TabIndex = 42;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAbrirTrx
            // 
            this.tsbAbrirTrx.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAbrirTrx.Image = global::ClienteHCS_2.Properties.Resources.abrir_documento;
            this.tsbAbrirTrx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbrirTrx.Name = "tsbAbrirTrx";
            this.tsbAbrirTrx.Size = new System.Drawing.Size(52, 52);
            this.tsbAbrirTrx.Text = "Abrir Transaccion";
            this.tsbAbrirTrx.Click += new System.EventHandler(this.tsbAbrirTrx_Click);
            // 
            // tsbGuardarTrx
            // 
            this.tsbGuardarTrx.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGuardarTrx.Image = global::ClienteHCS_2.Properties.Resources.disco_flexible__1_;
            this.tsbGuardarTrx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGuardarTrx.Name = "tsbGuardarTrx";
            this.tsbGuardarTrx.Size = new System.Drawing.Size(52, 52);
            this.tsbGuardarTrx.Text = "Guardar Transaccion";
            this.tsbGuardarTrx.Click += new System.EventHandler(this.tsbGuardarTrx_Click);
            // 
            // tsbGuardarTrxComo
            // 
            this.tsbGuardarTrxComo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGuardarTrxComo.Image = global::ClienteHCS_2.Properties.Resources.Save_as_80_icon_icons_com_57275;
            this.tsbGuardarTrxComo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGuardarTrxComo.Name = "tsbGuardarTrxComo";
            this.tsbGuardarTrxComo.Size = new System.Drawing.Size(52, 52);
            this.tsbGuardarTrxComo.Text = "Guardar Transaccion Como";
            this.tsbGuardarTrxComo.Click += new System.EventHandler(this.tsbGuardarTrxComo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 57);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(27, 52);
            this.toolStripLabel1.Text = "   ";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 57);
            // 
            // tsbLoadTest
            // 
            this.tsbLoadTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLoadTest.Image = global::ClienteHCS_2.Properties.Resources.escala_corporal;
            this.tsbLoadTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadTest.Name = "tsbLoadTest";
            this.tsbLoadTest.Size = new System.Drawing.Size(52, 52);
            this.tsbLoadTest.Text = "Load Test";
            this.tsbLoadTest.Click += new System.EventHandler(this.tsbLoadTest_Click);
            // 
            // tsbDetallesLoadTest
            // 
            this.tsbDetallesLoadTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDetallesLoadTest.Image = global::ClienteHCS_2.Properties.Resources.kpi_48x48;
            this.tsbDetallesLoadTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDetallesLoadTest.Name = "tsbDetallesLoadTest";
            this.tsbDetallesLoadTest.Size = new System.Drawing.Size(52, 52);
            this.tsbDetallesLoadTest.Text = "Ver detalles de ensayos de carga";
            this.tsbDetallesLoadTest.Click += new System.EventHandler(this.tsbDetallesLoadTest_Click);
            // 
            // tsbMedidasRendimiento
            // 
            this.tsbMedidasRendimiento.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMedidasRendimiento.Image = global::ClienteHCS_2.Properties.Resources.evaluacion_comparativa;
            this.tsbMedidasRendimiento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMedidasRendimiento.Name = "tsbMedidasRendimiento";
            this.tsbMedidasRendimiento.Size = new System.Drawing.Size(52, 52);
            this.tsbMedidasRendimiento.Text = "Medidas de Rendimiento";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 57);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(27, 52);
            this.toolStripLabel2.Text = "   ";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 57);
            // 
            // tsbLoadTestMultiTrx
            // 
            this.tsbLoadTestMultiTrx.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbLoadTestMultiTrx.Image = global::ClienteHCS_2.Properties.Resources.TestCargaMultiTrx;
            this.tsbLoadTestMultiTrx.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadTestMultiTrx.Name = "tsbLoadTestMultiTrx";
            this.tsbLoadTestMultiTrx.Size = new System.Drawing.Size(52, 52);
            this.tsbLoadTestMultiTrx.Text = "Load Test Multi transaccion";
            this.tsbLoadTestMultiTrx.Click += new System.EventHandler(this.tsbLoadTestMultiTrx_Click);
            // 
            // tsbContinutyTest
            // 
            this.tsbContinutyTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbContinutyTest.Image = global::ClienteHCS_2.Properties.Resources.indicador;
            this.tsbContinutyTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbContinutyTest.Name = "tsbContinutyTest";
            this.tsbContinutyTest.Size = new System.Drawing.Size(52, 52);
            this.tsbContinutyTest.Text = "Continuity test";
            this.tsbContinutyTest.Click += new System.EventHandler(this.tsbContinutyTest_Click);
            // 
            // tsbInfo
            // 
            this.tsbInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbInfo.Image = global::ClienteHCS_2.Properties.Resources.information;
            this.tsbInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInfo.Name = "tsbInfo";
            this.tsbInfo.Size = new System.Drawing.Size(52, 52);
            this.tsbInfo.Text = "Info";
            this.tsbInfo.Click += new System.EventHandler(this.tsbInfo_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 57);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(22, 52);
            this.toolStripLabel3.Text = "  ";
            // 
            // tslServer
            // 
            this.tslServer.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tslServer.Name = "tslServer";
            this.tslServer.Size = new System.Drawing.Size(135, 52);
            this.tslServer.Text = "Server HCS:";
            // 
            // tstHCSServer
            // 
            this.tstHCSServer.AutoSize = false;
            this.tstHCSServer.BackColor = System.Drawing.SystemColors.Info;
            this.tstHCSServer.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.tstHCSServer.Name = "tstHCSServer";
            this.tstHCSServer.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.tstHCSServer.Size = new System.Drawing.Size(300, 57);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnCopiar);
            this.groupBox1.Controls.Add(this.btnBorrar);
            this.groupBox1.Controls.Add(this.lblResumenRespuesta);
            this.groupBox1.Controls.Add(this.txtRespuesta);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(14, 445);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(1317, 298);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Respuesta desde HCS:";
            // 
            // btnCopiar
            // 
            this.btnCopiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopiar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopiar.Location = new System.Drawing.Point(1057, 232);
            this.btnCopiar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(122, 57);
            this.btnCopiar.TabIndex = 48;
            this.btnCopiar.Text = "&Copiar";
            this.btnCopiar.UseVisualStyleBackColor = true;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBorrar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrar.Location = new System.Drawing.Point(1188, 232);
            this.btnBorrar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(122, 57);
            this.btnBorrar.TabIndex = 45;
            this.btnBorrar.Text = "&Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // lblResumenRespuesta
            // 
            this.lblResumenRespuesta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblResumenRespuesta.AutoSize = true;
            this.lblResumenRespuesta.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResumenRespuesta.Location = new System.Drawing.Point(12, 232);
            this.lblResumenRespuesta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResumenRespuesta.Name = "lblResumenRespuesta";
            this.lblResumenRespuesta.Size = new System.Drawing.Size(37, 29);
            this.lblResumenRespuesta.TabIndex = 27;
            this.lblResumenRespuesta.Text = "---";
            this.lblResumenRespuesta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRespuesta
            // 
            this.txtRespuesta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRespuesta.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRespuesta.Location = new System.Drawing.Point(9, 38);
            this.txtRespuesta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRespuesta.Multiline = true;
            this.txtRespuesta.Name = "txtRespuesta";
            this.txtRespuesta.ReadOnly = true;
            this.txtRespuesta.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRespuesta.Size = new System.Drawing.Size(1297, 182);
            this.txtRespuesta.TabIndex = 23;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtMensaje);
            this.groupBox2.Controls.Add(this.btnEnviar);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(18, 262);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox2.Size = new System.Drawing.Size(1313, 172);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mensaje a enviar por HCS:";
            // 
            // txtMensaje
            // 
            this.txtMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMensaje.Font = new System.Drawing.Font("Consolas", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensaje.Location = new System.Drawing.Point(10, 34);
            this.txtMensaje.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMensaje.Size = new System.Drawing.Size(1061, 122);
            this.txtMensaje.TabIndex = 8;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviar.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Location = new System.Drawing.Point(1083, 34);
            this.btnEnviar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(214, 125);
            this.btnEnviar.TabIndex = 7;
            this.btnEnviar.Text = "&Enviar>>";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // cbEsHexa
            // 
            this.cbEsHexa.AutoSize = true;
            this.cbEsHexa.Checked = global::ClienteHCS_2.Properties.Settings.Default.EsHexa;
            this.cbEsHexa.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ClienteHCS_2.Properties.Settings.Default, "EsHexa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbEsHexa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEsHexa.Location = new System.Drawing.Point(621, 209);
            this.cbEsHexa.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbEsHexa.Name = "cbEsHexa";
            this.cbEsHexa.Size = new System.Drawing.Size(220, 33);
            this.cbEsHexa.TabIndex = 43;
            this.cbEsHexa.Text = "Msjes en HEXA";
            this.cbEsHexa.UseVisualStyleBackColor = true;
            // 
            // txtTXFile
            // 
            this.txtTXFile.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ClienteHCS_2.Properties.Settings.Default, "TXFile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtTXFile.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTXFile.Location = new System.Drawing.Point(382, 210);
            this.txtTXFile.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTXFile.Name = "txtTXFile";
            this.txtTXFile.Size = new System.Drawing.Size(200, 33);
            this.txtTXFile.TabIndex = 7;
            this.txtTXFile.Text = global::ClienteHCS_2.Properties.Settings.Default.TXFile;
            // 
            // pbLoadingGif
            // 
            this.pbLoadingGif.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbLoadingGif.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLoadingGif.Image = global::ClienteHCS_2.Properties.Resources.loading;
            this.pbLoadingGif.Location = new System.Drawing.Point(608, 502);
            this.pbLoadingGif.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbLoadingGif.Name = "pbLoadingGif";
            this.pbLoadingGif.Size = new System.Drawing.Size(338, 290);
            this.pbLoadingGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbLoadingGif.TabIndex = 47;
            this.pbLoadingGif.TabStop = false;
            this.pbLoadingGif.Visible = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1349, 856);
            this.Controls.Add(this.pbLoadingGif);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cbEsHexa);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.txtNotas);
            this.Controls.Add(this.txtTXFile);
            this.Controls.Add(this.labelTxFile);
            this.Controls.Add(this.grpCredenciales);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMain";
            this.Text = "HCS Client 2";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.SizeChanged += new System.EventHandler(this.FrmMain_SizeChanged);
            this.grpCredenciales.ResumeLayout(false);
            this.grpCredenciales.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingGif)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grpCredenciales;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblContrasenia;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.RadioButton optOtrasCredenciales;
        private System.Windows.Forms.RadioButton optInteractivo;
        private System.Windows.Forms.Label labelTxFile;
        private System.Windows.Forms.TextBox txtTXFile;
        private System.Windows.Forms.TextBox txtNotas;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAbrirTrx;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripButton tsbGuardarTrx;
        private System.Windows.Forms.ToolStripButton tsbGuardarTrxComo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbLoadTest;
        private System.Windows.Forms.ToolStripButton tsbMedidasRendimiento;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.CheckBox cbEsHexa;
        private System.Windows.Forms.ToolStripButton tsbContinutyTest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Label lblResumenRespuesta;
        private System.Windows.Forms.TextBox txtRespuesta;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.ToolStripButton tsbLoadTestMultiTrx;
        private System.Windows.Forms.ToolStripButton tsbInfo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.PictureBox pbLoadingGif;
        private System.Windows.Forms.Button btnCopiar;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tsbDetallesLoadTest;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripLabel tslServer;
        private System.Windows.Forms.ToolStripTextBox tstHCSServer;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
    }
}

