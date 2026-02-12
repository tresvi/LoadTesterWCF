namespace ClienteHCS_2
{
    partial class FrmPruebaDeContinuidad
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
            this.txtSalida = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.nudPeriodoEnvioDatos = new System.Windows.Forms.NumericUpDown();
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.lblCredenciales = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudDuracion = new System.Windows.Forms.NumericUpDown();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.lblTransaccion = new System.Windows.Forms.Label();
            this.lblTxFile = new System.Windows.Forms.Label();
            this.lblServer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCopiarPortapapeles = new System.Windows.Forms.Button();
            this.lblConexionesOK = new System.Windows.Forms.Label();
            this.lblConexionesFail = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriodoEnvioDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuracion)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSalida
            // 
            this.txtSalida.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSalida.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSalida.Location = new System.Drawing.Point(4, 160);
            this.txtSalida.Multiline = true;
            this.txtSalida.Name = "txtSalida";
            this.txtSalida.ReadOnly = true;
            this.txtSalida.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtSalida.Size = new System.Drawing.Size(922, 376);
            this.txtSalida.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnAyuda);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.nudPeriodoEnvioDatos);
            this.groupBox1.Controls.Add(this.btnFinalizar);
            this.groupBox1.Controls.Add(this.lblCredenciales);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.nudDuracion);
            this.groupBox1.Controls.Add(this.btnIniciar);
            this.groupBox1.Controls.Add(this.lblTransaccion);
            this.groupBox1.Controls.Add(this.lblTxFile);
            this.groupBox1.Controls.Add(this.lblServer);
            this.groupBox1.Location = new System.Drawing.Point(4, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(922, 143);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // btnAyuda
            // 
            this.btnAyuda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAyuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAyuda.Location = new System.Drawing.Point(586, 89);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(106, 31);
            this.btnAyuda.TabIndex = 20;
            this.btnAyuda.Text = "Ayuda...";
            this.btnAyuda.UseVisualStyleBackColor = true;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(334, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(243, 24);
            this.label4.TabIndex = 17;
            this.label4.Text = "Enviar datos cada [Seg.]:";
            // 
            // nudPeriodoEnvioDatos
            // 
            this.nudPeriodoEnvioDatos.DecimalPlaces = 1;
            this.nudPeriodoEnvioDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPeriodoEnvioDatos.Location = new System.Drawing.Point(585, 47);
            this.nudPeriodoEnvioDatos.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudPeriodoEnvioDatos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nudPeriodoEnvioDatos.Name = "nudPeriodoEnvioDatos";
            this.nudPeriodoEnvioDatos.Size = new System.Drawing.Size(108, 29);
            this.nudPeriodoEnvioDatos.TabIndex = 16;
            this.nudPeriodoEnvioDatos.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinalizar.Enabled = false;
            this.btnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizar.Location = new System.Drawing.Point(748, 63);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(126, 37);
            this.btnFinalizar.TabIndex = 15;
            this.btnFinalizar.Text = "&Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = true;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // lblCredenciales
            // 
            this.lblCredenciales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCredenciales.AutoSize = true;
            this.lblCredenciales.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCredenciales.Location = new System.Drawing.Point(19, 80);
            this.lblCredenciales.Name = "lblCredenciales";
            this.lblCredenciales.Size = new System.Drawing.Size(166, 24);
            this.lblCredenciales.TabIndex = 14;
            this.lblCredenciales.Text = "Credenciales: ---";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(380, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(201, 24);
            this.label2.TabIndex = 12;
            this.label2.Text = "Duracion hilo [Seg.]:";
            // 
            // nudDuracion
            // 
            this.nudDuracion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudDuracion.Location = new System.Drawing.Point(584, 17);
            this.nudDuracion.Maximum = new decimal(new int[] {
            86400,
            0,
            0,
            0});
            this.nudDuracion.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudDuracion.Name = "nudDuracion";
            this.nudDuracion.Size = new System.Drawing.Size(109, 30);
            this.nudDuracion.TabIndex = 10;
            this.nudDuracion.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // btnIniciar
            // 
            this.btnIniciar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.Location = new System.Drawing.Point(749, 16);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(126, 37);
            this.btnIniciar.TabIndex = 8;
            this.btnIniciar.Text = "&Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // lblTransaccion
            // 
            this.lblTransaccion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTransaccion.AutoSize = true;
            this.lblTransaccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTransaccion.Location = new System.Drawing.Point(19, 110);
            this.lblTransaccion.Name = "lblTransaccion";
            this.lblTransaccion.Size = new System.Drawing.Size(158, 24);
            this.lblTransaccion.TabIndex = 7;
            this.lblTransaccion.Text = "Transaccion: ---";
            // 
            // lblTxFile
            // 
            this.lblTxFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTxFile.AutoSize = true;
            this.lblTxFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTxFile.Location = new System.Drawing.Point(19, 48);
            this.lblTxFile.Name = "lblTxFile";
            this.lblTxFile.Size = new System.Drawing.Size(102, 24);
            this.lblTxFile.TabIndex = 6;
            this.lblTxFile.Text = "TxFile: ---";
            // 
            // lblServer
            // 
            this.lblServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblServer.AutoSize = true;
            this.lblServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServer.Location = new System.Drawing.Point(19, 16);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(104, 24);
            this.lblServer.TabIndex = 5;
            this.lblServer.Text = "Server: ---";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1, 546);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 24);
            this.label1.TabIndex = 15;
            this.label1.Text = "Conexiones OK:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(257, 546);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 24);
            this.label3.TabIndex = 16;
            this.label3.Text = "Conexiones FALLIDAS:";
            // 
            // btnCopiarPortapapeles
            // 
            this.btnCopiarPortapapeles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopiarPortapapeles.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopiarPortapapeles.Location = new System.Drawing.Point(743, 544);
            this.btnCopiarPortapapeles.Name = "btnCopiarPortapapeles";
            this.btnCopiarPortapapeles.Size = new System.Drawing.Size(185, 27);
            this.btnCopiarPortapapeles.TabIndex = 17;
            this.btnCopiarPortapapeles.Text = "Copiar al portapapeles";
            this.btnCopiarPortapapeles.UseVisualStyleBackColor = true;
            this.btnCopiarPortapapeles.Click += new System.EventHandler(this.btnCopiarPortapapeles_Click);
            // 
            // lblConexionesOK
            // 
            this.lblConexionesOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblConexionesOK.AutoSize = true;
            this.lblConexionesOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConexionesOK.Location = new System.Drawing.Point(138, 546);
            this.lblConexionesOK.Name = "lblConexionesOK";
            this.lblConexionesOK.Size = new System.Drawing.Size(31, 24);
            this.lblConexionesOK.TabIndex = 18;
            this.lblConexionesOK.Text = "---";
            // 
            // lblConexionesFail
            // 
            this.lblConexionesFail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblConexionesFail.AutoSize = true;
            this.lblConexionesFail.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConexionesFail.Location = new System.Drawing.Point(445, 546);
            this.lblConexionesFail.Name = "lblConexionesFail";
            this.lblConexionesFail.Size = new System.Drawing.Size(31, 24);
            this.lblConexionesFail.TabIndex = 19;
            this.lblConexionesFail.Text = "---";
            // 
            // FrmPruebaDeContinuidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 578);
            this.Controls.Add(this.lblConexionesFail);
            this.Controls.Add(this.lblConexionesOK);
            this.Controls.Add(this.btnCopiarPortapapeles);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSalida);
            this.Controls.Add(this.groupBox1);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(770, 578);
            this.Name = "FrmPruebaDeContinuidad";
            this.Text = "Test de Continuidad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPruebaDeContinuidad_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPruebaDeContinuidad_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPeriodoEnvioDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuracion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSalida;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCredenciales;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudDuracion;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label lblTransaccion;
        private System.Windows.Forms.Label lblTxFile;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCopiarPortapapeles;
        private System.Windows.Forms.Label lblConexionesOK;
        private System.Windows.Forms.Label lblConexionesFail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudPeriodoEnvioDatos;
        private System.Windows.Forms.Button btnAyuda;
    }
}