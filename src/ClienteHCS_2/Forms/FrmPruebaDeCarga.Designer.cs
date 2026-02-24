namespace ClienteHCS_2
{
    partial class FrmPruebaDeCarga
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tlpParams = new System.Windows.Forms.TableLayoutPanel();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudHilosParalelos = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudDuracion = new System.Windows.Forms.NumericUpDown();
            this.lblPausa = new System.Windows.Forms.Label();
            this.nudPausaMs = new System.Windows.Forms.NumericUpDown();
            this.btnAyuda = new System.Windows.Forms.Button();
            this.prgbarHilos = new System.Windows.Forms.ProgressBar();
            this.cbUsarUnicaConexion = new System.Windows.Forms.CheckBox();
            this.dgvHilos = new System.Windows.Forms.DataGridView();
            this.colRowNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblContadorOK = new System.Windows.Forms.Label();
            this.lblContadorFAIL = new System.Windows.Forms.Label();
            this.tmrFinalizacion = new System.Windows.Forms.Timer(this.components);
            this.lblTiempo = new System.Windows.Forms.Label();
            this.lblCreandoHilos = new System.Windows.Forms.Label();
            this.lblThroughput = new System.Windows.Forms.Label();
            this.lblLatenciaResumen = new System.Windows.Forms.Label();
            this.lblSinRespuesta = new System.Windows.Forms.Label();
            this.tlpBottom = new System.Windows.Forms.TableLayoutPanel();
            this.btnVerDetalles = new System.Windows.Forms.Button();
            this.lblMetricasNuevas = new System.Windows.Forms.Label();
            this.gbConectividad = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.lblServer = new System.Windows.Forms.Label();
            this.lblTxFile = new System.Windows.Forms.Label();
            this.lblCredenciales = new System.Windows.Forms.Label();
            this.lblTransaccion = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.tlpParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHilosParalelos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuracion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPausaMs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHilos)).BeginInit();
            this.tlpBottom.SuspendLayout();
            this.gbConectividad.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tlpParams);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(16, 97);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox1.Size = new System.Drawing.Size(1318, 191);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuración de Ensayo";
            // 
            // tlpParams
            // 
            this.tlpParams.ColumnCount = 9;
            this.tlpParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tlpParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tlpParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 165F));
            this.tlpParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 270F));
            this.tlpParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpParams.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tlpParams.Controls.Add(this.btnIniciar, 8, 0);
            this.tlpParams.Controls.Add(this.label1, 0, 0);
            this.tlpParams.Controls.Add(this.nudHilosParalelos, 1, 0);
            this.tlpParams.Controls.Add(this.label2, 0, 1);
            this.tlpParams.Controls.Add(this.nudDuracion, 1, 1);
            this.tlpParams.Controls.Add(this.lblPausa, 0, 2);
            this.tlpParams.Controls.Add(this.nudPausaMs, 1, 2);
            this.tlpParams.Controls.Add(this.btnAyuda, 8, 2);
            this.tlpParams.Controls.Add(this.prgbarHilos, 3, 2);
            this.tlpParams.Controls.Add(this.cbUsarUnicaConexion, 3, 0);
            this.tlpParams.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpParams.Location = new System.Drawing.Point(6, 27);
            this.tlpParams.Margin = new System.Windows.Forms.Padding(0);
            this.tlpParams.Name = "tlpParams";
            this.tlpParams.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.tlpParams.RowCount = 3;
            this.tlpParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpParams.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpParams.Size = new System.Drawing.Size(1306, 158);
            this.tlpParams.TabIndex = 0;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnIniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciar.Location = new System.Drawing.Point(1075, 12);
            this.btnIniciar.Margin = new System.Windows.Forms.Padding(6);
            this.btnIniciar.Name = "btnIniciar";
            this.tlpParams.SetRowSpan(this.btnIniciar, 2);
            this.btnIniciar.Size = new System.Drawing.Size(222, 88);
            this.btnIniciar.TabIndex = 8;
            this.btnIniciar.Text = "&Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(151, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 27);
            this.label1.TabIndex = 11;
            this.label1.Text = "# Hilos:";
            // 
            // nudHilosParalelos
            // 
            this.nudHilosParalelos.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudHilosParalelos.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.nudHilosParalelos.Location = new System.Drawing.Point(259, 13);
            this.nudHilosParalelos.Margin = new System.Windows.Forms.Padding(6);
            this.nudHilosParalelos.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudHilosParalelos.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHilosParalelos.Name = "nudHilosParalelos";
            this.nudHilosParalelos.Size = new System.Drawing.Size(117, 35);
            this.nudHilosParalelos.TabIndex = 9;
            this.nudHilosParalelos.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(63, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(184, 27);
            this.label2.TabIndex = 12;
            this.label2.Text = "Duración [seg]:";
            // 
            // nudDuracion
            // 
            this.nudDuracion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudDuracion.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.nudDuracion.Location = new System.Drawing.Point(259, 63);
            this.nudDuracion.Margin = new System.Windows.Forms.Padding(6);
            this.nudDuracion.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.nudDuracion.Minimum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudDuracion.Name = "nudDuracion";
            this.nudDuracion.Size = new System.Drawing.Size(117, 35);
            this.nudDuracion.TabIndex = 10;
            this.nudDuracion.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // lblPausa
            // 
            this.lblPausa.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPausa.AutoSize = true;
            this.lblPausa.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPausa.Location = new System.Drawing.Point(6, 118);
            this.lblPausa.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblPausa.Name = "lblPausa";
            this.lblPausa.Size = new System.Drawing.Size(241, 27);
            this.lblPausa.TabIndex = 21;
            this.lblPausa.Text = "Pausa e/envíos [ms]:";
            // 
            // nudPausaMs
            // 
            this.nudPausaMs.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudPausaMs.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudPausaMs.Location = new System.Drawing.Point(259, 114);
            this.nudPausaMs.Margin = new System.Windows.Forms.Padding(6);
            this.nudPausaMs.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.nudPausaMs.Name = "nudPausaMs";
            this.nudPausaMs.Size = new System.Drawing.Size(117, 35);
            this.nudPausaMs.TabIndex = 20;
            this.nudPausaMs.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btnAyuda
            // 
            this.btnAyuda.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAyuda.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAyuda.Location = new System.Drawing.Point(1078, 112);
            this.btnAyuda.Margin = new System.Windows.Forms.Padding(6);
            this.btnAyuda.Name = "btnAyuda";
            this.btnAyuda.Size = new System.Drawing.Size(222, 40);
            this.btnAyuda.TabIndex = 19;
            this.btnAyuda.Text = "Ayuda...";
            this.btnAyuda.UseVisualStyleBackColor = true;
            this.btnAyuda.Click += new System.EventHandler(this.btnAyuda_Click);
            // 
            // prgbarHilos
            // 
            this.prgbarHilos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpParams.SetColumnSpan(this.prgbarHilos, 5);
            this.prgbarHilos.Location = new System.Drawing.Point(433, 112);
            this.prgbarHilos.Margin = new System.Windows.Forms.Padding(6);
            this.prgbarHilos.Name = "prgbarHilos";
            this.prgbarHilos.Size = new System.Drawing.Size(627, 35);
            this.prgbarHilos.TabIndex = 15;
            this.prgbarHilos.Value = 60;
            this.prgbarHilos.Visible = false;
            // 
            // cbUsarUnicaConexion
            // 
            this.cbUsarUnicaConexion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbUsarUnicaConexion.AutoSize = true;
            this.tlpParams.SetColumnSpan(this.cbUsarUnicaConexion, 3);
            this.cbUsarUnicaConexion.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.cbUsarUnicaConexion.Location = new System.Drawing.Point(431, 15);
            this.cbUsarUnicaConexion.Margin = new System.Windows.Forms.Padding(4);
            this.cbUsarUnicaConexion.Name = "cbUsarUnicaConexion";
            this.cbUsarUnicaConexion.Size = new System.Drawing.Size(458, 31);
            this.cbUsarUnicaConexion.TabIndex = 22;
            this.cbUsarUnicaConexion.Text = "Usar única conexión p/todos los hilos";
            this.cbUsarUnicaConexion.UseVisualStyleBackColor = true;
            // 
            // dgvHilos
            // 
            this.dgvHilos.AllowUserToAddRows = false;
            this.dgvHilos.AllowUserToDeleteRows = false;
            this.dgvHilos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHilos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHilos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRowNum});
            this.dgvHilos.Location = new System.Drawing.Point(18, 302);
            this.dgvHilos.Margin = new System.Windows.Forms.Padding(6);
            this.dgvHilos.MultiSelect = false;
            this.dgvHilos.Name = "dgvHilos";
            this.dgvHilos.ReadOnly = true;
            this.dgvHilos.RowHeadersVisible = false;
            this.dgvHilos.RowHeadersWidth = 62;
            this.dgvHilos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHilos.Size = new System.Drawing.Size(1318, 374);
            this.dgvHilos.TabIndex = 6;
            // 
            // colRowNum
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(235)))));
            this.colRowNum.DefaultCellStyle = dataGridViewCellStyle5;
            this.colRowNum.DividerWidth = 3;
            this.colRowNum.Frozen = true;
            this.colRowNum.HeaderText = "#";
            this.colRowNum.MinimumWidth = 8;
            this.colRowNum.Name = "colRowNum";
            this.colRowNum.ReadOnly = true;
            this.colRowNum.Width = 36;
            // 
            // lblContadorOK
            // 
            this.lblContadorOK.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblContadorOK.AutoSize = true;
            this.lblContadorOK.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContadorOK.Location = new System.Drawing.Point(6, 3);
            this.lblContadorOK.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblContadorOK.Name = "lblContadorOK";
            this.lblContadorOK.Size = new System.Drawing.Size(245, 24);
            this.lblContadorOK.TabIndex = 7;
            this.lblContadorOK.Text = "Hilos Finalizados OK:  ---";
            // 
            // lblContadorFAIL
            // 
            this.lblContadorFAIL.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblContadorFAIL.AutoSize = true;
            this.lblContadorFAIL.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContadorFAIL.Location = new System.Drawing.Point(6, 33);
            this.lblContadorFAIL.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblContadorFAIL.Name = "lblContadorFAIL";
            this.lblContadorFAIL.Size = new System.Drawing.Size(250, 24);
            this.lblContadorFAIL.TabIndex = 8;
            this.lblContadorFAIL.Text = "Hilos Finalizados FAIL: ---";
            // 
            // tmrFinalizacion
            // 
            this.tmrFinalizacion.Interval = 333;
            this.tmrFinalizacion.Tick += new System.EventHandler(this.tmrFinalizacion_Tick);
            // 
            // lblTiempo
            // 
            this.lblTiempo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTiempo.AutoSize = true;
            this.lblTiempo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiempo.Location = new System.Drawing.Point(336, 3);
            this.lblTiempo.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTiempo.Name = "lblTiempo";
            this.lblTiempo.Size = new System.Drawing.Size(148, 24);
            this.lblTiempo.TabIndex = 9;
            this.lblTiempo.Text = "Tiempo: --- ms";
            // 
            // lblCreandoHilos
            // 
            this.lblCreandoHilos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCreandoHilos.AutoSize = true;
            this.lblCreandoHilos.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreandoHilos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblCreandoHilos.Location = new System.Drawing.Point(452, 431);
            this.lblCreandoHilos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCreandoHilos.Name = "lblCreandoHilos";
            this.lblCreandoHilos.Size = new System.Drawing.Size(584, 37);
            this.lblCreandoHilos.TabIndex = 16;
            this.lblCreandoHilos.Text = "Creando Hilos. Espere un momento...";
            this.lblCreandoHilos.Visible = false;
            // 
            // lblThroughput
            // 
            this.lblThroughput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblThroughput.AutoSize = true;
            this.lblThroughput.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThroughput.Location = new System.Drawing.Point(6, 63);
            this.lblThroughput.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblThroughput.Name = "lblThroughput";
            this.lblThroughput.Size = new System.Drawing.Size(205, 24);
            this.lblThroughput.TabIndex = 18;
            this.lblThroughput.Text = "Throughput: --- trx/s";
            // 
            // lblLatenciaResumen
            // 
            this.lblLatenciaResumen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblLatenciaResumen.AutoSize = true;
            this.tlpBottom.SetColumnSpan(this.lblLatenciaResumen, 3);
            this.lblLatenciaResumen.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatenciaResumen.Location = new System.Drawing.Point(336, 63);
            this.lblLatenciaResumen.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblLatenciaResumen.Name = "lblLatenciaResumen";
            this.lblLatenciaResumen.Size = new System.Drawing.Size(375, 24);
            this.lblLatenciaResumen.TabIndex = 19;
            this.lblLatenciaResumen.Text = "Latencia (ms): min --- | max --- | p50 ---";
            // 
            // lblSinRespuesta
            // 
            this.lblSinRespuesta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSinRespuesta.AutoSize = true;
            this.tlpBottom.SetColumnSpan(this.lblSinRespuesta, 3);
            this.lblSinRespuesta.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSinRespuesta.Location = new System.Drawing.Point(336, 33);
            this.lblSinRespuesta.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblSinRespuesta.Name = "lblSinRespuesta";
            this.lblSinRespuesta.Size = new System.Drawing.Size(318, 24);
            this.lblSinRespuesta.TabIndex = 20;
            this.lblSinRespuesta.Text = "Sin respuesta (error/timeout): ---";
            // 
            // tlpBottom
            // 
            this.tlpBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpBottom.ColumnCount = 6;
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 330F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 330F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 405F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 330F));
            this.tlpBottom.Controls.Add(this.lblContadorOK, 0, 0);
            this.tlpBottom.Controls.Add(this.lblThroughput, 0, 2);
            this.tlpBottom.Controls.Add(this.lblContadorFAIL, 0, 1);
            this.tlpBottom.Controls.Add(this.lblLatenciaResumen, 1, 2);
            this.tlpBottom.Controls.Add(this.lblTiempo, 1, 0);
            this.tlpBottom.Controls.Add(this.lblSinRespuesta, 1, 1);
            this.tlpBottom.Controls.Add(this.btnVerDetalles, 5, 0);
            this.tlpBottom.Controls.Add(this.lblMetricasNuevas, 5, 2);
            this.tlpBottom.Location = new System.Drawing.Point(18, 682);
            this.tlpBottom.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBottom.Name = "tlpBottom";
            this.tlpBottom.RowCount = 4;
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tlpBottom.Size = new System.Drawing.Size(1318, 123);
            this.tlpBottom.TabIndex = 21;
            // 
            // btnVerDetalles
            // 
            this.btnVerDetalles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerDetalles.Enabled = false;
            this.btnVerDetalles.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerDetalles.Image = global::ClienteHCS_2.Properties.Resources.kpi_48x48;
            this.btnVerDetalles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerDetalles.Location = new System.Drawing.Point(1074, 5);
            this.btnVerDetalles.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnVerDetalles.Name = "btnVerDetalles";
            this.tlpBottom.SetRowSpan(this.btnVerDetalles, 3);
            this.btnVerDetalles.Size = new System.Drawing.Size(240, 80);
            this.btnVerDetalles.TabIndex = 21;
            this.btnVerDetalles.Text = "Ver detalles...";
            this.btnVerDetalles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnVerDetalles.UseVisualStyleBackColor = true;
            this.btnVerDetalles.Click += new System.EventHandler(this.btnVerDetalles_Click);
            // 
            // lblMetricasNuevas
            // 
            this.lblMetricasNuevas.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMetricasNuevas.AutoSize = true;
            this.tlpBottom.SetColumnSpan(this.lblMetricasNuevas, 4);
            this.lblMetricasNuevas.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetricasNuevas.Location = new System.Drawing.Point(6, 94);
            this.lblMetricasNuevas.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblMetricasNuevas.Name = "lblMetricasNuevas";
            this.lblMetricasNuevas.Size = new System.Drawing.Size(569, 24);
            this.lblMetricasNuevas.TabIndex = 23;
            this.lblMetricasNuevas.Text = "Throughput/hilo: --- | Tasa éxito hilos: ---% | Estabilidad: ---";
            // 
            // gbConectividad
            // 
            this.gbConectividad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbConectividad.Controls.Add(this.flowLayoutPanel1);
            this.gbConectividad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbConectividad.Location = new System.Drawing.Point(18, 12);
            this.gbConectividad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbConectividad.Name = "gbConectividad";
            this.gbConectividad.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbConectividad.Size = new System.Drawing.Size(1316, 83);
            this.gbConectividad.TabIndex = 22;
            this.gbConectividad.TabStop = false;
            this.gbConectividad.Text = "Conectividad";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.lblServer);
            this.flowLayoutPanel1.Controls.Add(this.lblTxFile);
            this.flowLayoutPanel1.Controls.Add(this.lblCredenciales);
            this.flowLayoutPanel1.Controls.Add(this.lblTransaccion);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 26);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1308, 52);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // lblServer
            // 
            this.lblServer.AutoSize = true;
            this.lblServer.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblServer.Location = new System.Drawing.Point(6, 0);
            this.lblServer.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(121, 27);
            this.lblServer.TabIndex = 6;
            this.lblServer.Text = "Server: ---";
            // 
            // lblTxFile
            // 
            this.lblTxFile.AutoSize = true;
            this.lblTxFile.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTxFile.Location = new System.Drawing.Point(139, 0);
            this.lblTxFile.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTxFile.Name = "lblTxFile";
            this.lblTxFile.Size = new System.Drawing.Size(117, 27);
            this.lblTxFile.TabIndex = 7;
            this.lblTxFile.Text = "TxFile: ---";
            // 
            // lblCredenciales
            // 
            this.lblCredenciales.AutoSize = true;
            this.lblCredenciales.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblCredenciales.Location = new System.Drawing.Point(268, 0);
            this.lblCredenciales.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblCredenciales.Name = "lblCredenciales";
            this.lblCredenciales.Size = new System.Drawing.Size(196, 27);
            this.lblCredenciales.TabIndex = 15;
            this.lblCredenciales.Text = "Credenciales: ---";
            // 
            // lblTransaccion
            // 
            this.lblTransaccion.AutoSize = true;
            this.lblTransaccion.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblTransaccion.Location = new System.Drawing.Point(476, 0);
            this.lblTransaccion.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblTransaccion.Name = "lblTransaccion";
            this.lblTransaccion.Size = new System.Drawing.Size(188, 27);
            this.lblTransaccion.TabIndex = 16;
            this.lblTransaccion.Text = "Transaccion: ---";
            // 
            // FrmPruebaDeCarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 812);
            this.Controls.Add(this.gbConectividad);
            this.Controls.Add(this.lblCreandoHilos);
            this.Controls.Add(this.tlpBottom);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvHilos);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1339, 739);
            this.Name = "FrmPruebaDeCarga";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Prueba De Carga";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPruebaDeCarga_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.tlpParams.ResumeLayout(false);
            this.tlpParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudHilosParalelos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDuracion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPausaMs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHilos)).EndInit();
            this.tlpBottom.ResumeLayout(false);
            this.tlpBottom.PerformLayout();
            this.gbConectividad.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tlpParams;
        private System.Windows.Forms.TableLayoutPanel tlpBottom;
        private System.Windows.Forms.DataGridView dgvHilos;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRowNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThreadNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCorrID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEndTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLatAvg;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLatMin;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLatMax;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrxOK;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTrxFail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThroughputOK;
        private System.Windows.Forms.DataGridViewTextBoxColumn colThroughputTotal;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudDuracion;
        private System.Windows.Forms.NumericUpDown nudHilosParalelos;
        private System.Windows.Forms.Label lblContadorOK;
        private System.Windows.Forms.Label lblContadorFAIL;
        private System.Windows.Forms.Timer tmrFinalizacion;
        private System.Windows.Forms.Label lblTiempo;
        private System.Windows.Forms.ProgressBar prgbarHilos;
        private System.Windows.Forms.Label lblCreandoHilos;
        private System.Windows.Forms.Button btnAyuda;
        private System.Windows.Forms.NumericUpDown nudPausaMs;
        private System.Windows.Forms.Label lblThroughput;
        private System.Windows.Forms.Label lblLatenciaResumen;
        private System.Windows.Forms.Label lblSinRespuesta;
        private System.Windows.Forms.CheckBox cbUsarUnicaConexion;
        private System.Windows.Forms.GroupBox gbConectividad;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblTransaccion;
        private System.Windows.Forms.Label lblCredenciales;
        private System.Windows.Forms.Label lblTxFile;
        private System.Windows.Forms.Label lblServer;
        private System.Windows.Forms.Label lblPausa;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnVerDetalles;
        private System.Windows.Forms.Label lblMetricasNuevas;
    }
}