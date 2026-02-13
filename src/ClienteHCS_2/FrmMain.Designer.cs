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
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.lblResumenRespuesta = new System.Windows.Forms.Label();
            this.txtRespuesta = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.txtHCSServer = new System.Windows.Forms.TextBox();
            this.cbEsHexa = new System.Windows.Forms.CheckBox();
            this.txtTXFile = new System.Windows.Forms.TextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.pbLoadingGif = new System.Windows.Forms.PictureBox();
            this.tsbAbrirTrx = new System.Windows.Forms.ToolStripButton();
            this.tsbGuardarTrx = new System.Windows.Forms.ToolStripButton();
            this.tsbGuardarTrxComo = new System.Windows.Forms.ToolStripButton();
            this.tsbLoadTest = new System.Windows.Forms.ToolStripButton();
            this.tsbLoadTestMultiTrx = new System.Windows.Forms.ToolStripButton();
            this.tsbContinutyTest = new System.Windows.Forms.ToolStripButton();
            this.tsbCompararLoadTest = new System.Windows.Forms.ToolStripButton();
            this.tsbInfo = new System.Windows.Forms.ToolStripButton();
            this.tsbDetallesLoadTest = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.grpCredenciales.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoadingGif)).BeginInit();
            this.SuspendLayout();
            // 
            // grpCredenciales
            // 
            this.grpCredenciales.Controls.Add(this.txtPassword);
            this.grpCredenciales.Controls.Add(this.lblContrasenia);
            this.grpCredenciales.Controls.Add(this.txtUsuario);
            this.grpCredenciales.Controls.Add(this.lblUsuario);
            this.grpCredenciales.Controls.Add(this.optOtrasCredenciales);
            this.grpCredenciales.Controls.Add(this.optInteractivo);
            this.grpCredenciales.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCredenciales.Location = new System.Drawing.Point(9, 60);
            this.grpCredenciales.Name = "grpCredenciales";
            this.grpCredenciales.Size = new System.Drawing.Size(976, 62);
            this.grpCredenciales.TabIndex = 4;
            this.grpCredenciales.TabStop = false;
            this.grpCredenciales.Text = "Credenciales";
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(854, 25);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(112, 25);
            this.txtPassword.TabIndex = 5;
            // 
            // lblContrasenia
            // 
            this.lblContrasenia.AutoSize = true;
            this.lblContrasenia.Enabled = false;
            this.lblContrasenia.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrasenia.Location = new System.Drawing.Point(805, 29);
            this.lblContrasenia.Name = "lblContrasenia";
            this.lblContrasenia.Size = new System.Drawing.Size(46, 18);
            this.lblContrasenia.TabIndex = 5;
            this.lblContrasenia.Text = "&Pass:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ClienteHCS_2.Properties.Settings.Default, "Usuario", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(673, 25);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(113, 25);
            this.txtUsuario.TabIndex = 4;
            this.txtUsuario.Text = global::ClienteHCS_2.Properties.Settings.Default.Usuario;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Enabled = false;
            this.lblUsuario.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(622, 29);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(46, 18);
            this.lblUsuario.TabIndex = 3;
            this.lblUsuario.Text = "&User:";
            // 
            // optOtrasCredenciales
            // 
            this.optOtrasCredenciales.AutoSize = true;
            this.optOtrasCredenciales.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optOtrasCredenciales.Location = new System.Drawing.Point(440, 27);
            this.optOtrasCredenciales.Name = "optOtrasCredenciales";
            this.optOtrasCredenciales.Size = new System.Drawing.Size(163, 22);
            this.optOtrasCredenciales.TabIndex = 2;
            this.optOtrasCredenciales.Text = "Otras Credenciales";
            this.optOtrasCredenciales.UseVisualStyleBackColor = true;
            this.optOtrasCredenciales.CheckedChanged += new System.EventHandler(this.optOtrasCredenciales_CheckedChanged);
            // 
            // optInteractivo
            // 
            this.optInteractivo.AutoSize = true;
            this.optInteractivo.Checked = true;
            this.optInteractivo.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optInteractivo.Location = new System.Drawing.Point(8, 27);
            this.optInteractivo.Name = "optInteractivo";
            this.optInteractivo.Size = new System.Drawing.Size(393, 22);
            this.optInteractivo.TabIndex = 1;
            this.optInteractivo.TabStop = true;
            this.optInteractivo.Text = "Interactivo (Credenciales del usuario %username%)";
            this.optInteractivo.UseVisualStyleBackColor = true;
            // 
            // labelTxFile
            // 
            this.labelTxFile.AutoSize = true;
            this.labelTxFile.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTxFile.Location = new System.Drawing.Point(18, 135);
            this.labelTxFile.Name = "labelTxFile";
            this.labelTxFile.Size = new System.Drawing.Size(223, 18);
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
            this.txtNotas.Location = new System.Drawing.Point(9, 603);
            this.txtNotas.Multiline = true;
            this.txtNotas.Name = "txtNotas";
            this.txtNotas.ReadOnly = true;
            this.txtNotas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotas.Size = new System.Drawing.Size(976, 60);
            this.txtNotas.TabIndex = 27;
            this.txtNotas.Text = resources.GetString("txtNotas.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(631, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 18);
            this.label2.TabIndex = 30;
            this.label2.Text = "Server HCS:";
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
            this.tsbCompararLoadTest,
            this.toolStripSeparator4,
            this.toolStripLabel2,
            this.toolStripSeparator3,
            this.tsbLoadTestMultiTrx,
            this.tsbContinutyTest,
            this.toolStripSeparator5,
            this.tsbInfo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(997, 55);
            this.toolStrip1.TabIndex = 42;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
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
            this.groupBox1.Location = new System.Drawing.Point(9, 287);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(976, 310);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Respuesta desde HCS:";
            // 
            // btnCopiar
            // 
            this.btnCopiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopiar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopiar.Location = new System.Drawing.Point(803, 267);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(81, 37);
            this.btnCopiar.TabIndex = 48;
            this.btnCopiar.Text = "&Copiar";
            this.btnCopiar.UseVisualStyleBackColor = true;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBorrar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBorrar.Location = new System.Drawing.Point(890, 267);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(81, 37);
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
            this.lblResumenRespuesta.Location = new System.Drawing.Point(8, 267);
            this.lblResumenRespuesta.Name = "lblResumenRespuesta";
            this.lblResumenRespuesta.Size = new System.Drawing.Size(24, 19);
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
            this.txtRespuesta.Location = new System.Drawing.Point(6, 25);
            this.txtRespuesta.Multiline = true;
            this.txtRespuesta.Name = "txtRespuesta";
            this.txtRespuesta.ReadOnly = true;
            this.txtRespuesta.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRespuesta.Size = new System.Drawing.Size(964, 236);
            this.txtRespuesta.TabIndex = 23;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtMensaje);
            this.groupBox2.Controls.Add(this.btnEnviar);
            this.groupBox2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(12, 169);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(973, 112);
            this.groupBox2.TabIndex = 46;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mensaje a enviar por HCS:";
            // 
            // txtMensaje
            // 
            this.txtMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMensaje.Font = new System.Drawing.Font("Consolas", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensaje.Location = new System.Drawing.Point(7, 22);
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMensaje.Size = new System.Drawing.Size(807, 81);
            this.txtMensaje.TabIndex = 8;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviar.Font = new System.Drawing.Font("Arial", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Location = new System.Drawing.Point(820, 22);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(143, 81);
            this.btnEnviar.TabIndex = 7;
            this.btnEnviar.Text = "&Enviar>>";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // txtHCSServer
            // 
            this.txtHCSServer.AcceptsTab = true;
            this.txtHCSServer.BackColor = System.Drawing.SystemColors.Info;
            this.txtHCSServer.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ClienteHCS_2.Properties.Settings.Default, "HCSServer", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtHCSServer.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHCSServer.Location = new System.Drawing.Point(751, 12);
            this.txtHCSServer.Name = "txtHCSServer";
            this.txtHCSServer.Size = new System.Drawing.Size(224, 25);
            this.txtHCSServer.TabIndex = 31;
            this.txtHCSServer.Text = global::ClienteHCS_2.Properties.Settings.Default.HCSServer;
            // 
            // cbEsHexa
            // 
            this.cbEsHexa.AutoSize = true;
            this.cbEsHexa.Checked = global::ClienteHCS_2.Properties.Settings.Default.EsHexa;
            this.cbEsHexa.DataBindings.Add(new System.Windows.Forms.Binding("Checked", global::ClienteHCS_2.Properties.Settings.Default, "EsHexa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cbEsHexa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbEsHexa.Location = new System.Drawing.Point(405, 135);
            this.cbEsHexa.Name = "cbEsHexa";
            this.cbEsHexa.Size = new System.Drawing.Size(153, 24);
            this.cbEsHexa.TabIndex = 43;
            this.cbEsHexa.Text = "Msjes en HEXA";
            this.cbEsHexa.UseVisualStyleBackColor = true;
            // 
            // txtTXFile
            // 
            this.txtTXFile.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ClienteHCS_2.Properties.Settings.Default, "TXFile", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtTXFile.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTXFile.Location = new System.Drawing.Point(245, 133);
            this.txtTXFile.Name = "txtTXFile";
            this.txtTXFile.Size = new System.Drawing.Size(135, 25);
            this.txtTXFile.TabIndex = 7;
            this.txtTXFile.Text = global::ClienteHCS_2.Properties.Settings.Default.TXFile;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(16, 52);
            this.toolStripLabel1.Text = "   ";
            // 
            // pbLoadingGif
            // 
            this.pbLoadingGif.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pbLoadingGif.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbLoadingGif.Image = global::ClienteHCS_2.Properties.Resources.loading;
            this.pbLoadingGif.Location = new System.Drawing.Point(405, 326);
            this.pbLoadingGif.Name = "pbLoadingGif";
            this.pbLoadingGif.Size = new System.Drawing.Size(226, 189);
            this.pbLoadingGif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbLoadingGif.TabIndex = 47;
            this.pbLoadingGif.TabStop = false;
            this.pbLoadingGif.Visible = false;
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
            // tsbCompararLoadTest
            // 
            this.tsbCompararLoadTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCompararLoadTest.Image = global::ClienteHCS_2.Properties.Resources.evaluacion_comparativa;
            this.tsbCompararLoadTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCompararLoadTest.Name = "tsbCompararLoadTest";
            this.tsbCompararLoadTest.Size = new System.Drawing.Size(52, 52);
            this.tsbCompararLoadTest.Text = "Compara Ensayos de Carga";
            this.tsbCompararLoadTest.Click += new System.EventHandler(this.tsbMedidasRendimiento_Click);
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
            // tsbDetallesLoadTest
            // 
            this.tsbDetallesLoadTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDetallesLoadTest.Image = global::ClienteHCS_2.Properties.Resources.kpi;
            this.tsbDetallesLoadTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDetallesLoadTest.Name = "tsbDetallesLoadTest";
            this.tsbDetallesLoadTest.Size = new System.Drawing.Size(52, 52);
            this.tsbDetallesLoadTest.Text = "Detalles de ensayos de carga";
            this.tsbDetallesLoadTest.Click += new System.EventHandler(this.tsbDetallesLoadTest_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 55);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(16, 52);
            this.toolStripLabel2.Text = "   ";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 671);
            this.Controls.Add(this.pbLoadingGif);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtHCSServer);
            this.Controls.Add(this.cbEsHexa);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.txtNotas);
            this.Controls.Add(this.txtTXFile);
            this.Controls.Add(this.labelTxFile);
            this.Controls.Add(this.grpCredenciales);
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtHCSServer;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAbrirTrx;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripButton tsbGuardarTrx;
        private System.Windows.Forms.ToolStripButton tsbGuardarTrxComo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbLoadTest;
        private System.Windows.Forms.ToolStripButton tsbCompararLoadTest;
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
    }
}

