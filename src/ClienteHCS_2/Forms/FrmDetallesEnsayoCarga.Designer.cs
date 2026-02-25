namespace ClienteHCS_2
{
    partial class FrmDetallesEnsayoCarga
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.grpResumen = new System.Windows.Forms.GroupBox();
            this.tlpResumen = new System.Windows.Forms.TableLayoutPanel();
            this.lblResultados2 = new System.Windows.Forms.Label();
            this.lblConfig = new System.Windows.Forms.Label();
            this.lblResultados1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTituloThroughputOk = new System.Windows.Forms.Label();
            this.chartThroughputOk = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTituloLatencia = new System.Windows.Forms.Label();
            this.chartLatencia = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTituloThroughputTemporal = new System.Windows.Forms.Label();
            this.chartThroughputTemporal = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAbrirEnsayo = new System.Windows.Forms.ToolStripButton();
            this.tsbGuardarEnsayo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbMedidasRendimiento = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbInfo = new System.Windows.Forms.ToolStripButton();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.grpResumen.SuspendLayout();
            this.tlpResumen.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartThroughputOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLatencia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartThroughputTemporal)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.pnlContenido.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpResumen
            // 
            this.grpResumen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpResumen.Controls.Add(this.tlpResumen);
            this.grpResumen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpResumen.Location = new System.Drawing.Point(31, 12);
            this.grpResumen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpResumen.Name = "grpResumen";
            this.grpResumen.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpResumen.Size = new System.Drawing.Size(1985, 258);
            this.grpResumen.TabIndex = 0;
            this.grpResumen.TabStop = false;
            this.grpResumen.Text = "Configuración y resultados del ensayo";
            // 
            // tlpResumen
            // 
            this.tlpResumen.ColumnCount = 3;
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpResumen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpResumen.Controls.Add(this.lblResultados2, 2, 0);
            this.tlpResumen.Controls.Add(this.lblConfig, 0, 0);
            this.tlpResumen.Controls.Add(this.lblResultados1, 1, 0);
            this.tlpResumen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpResumen.Location = new System.Drawing.Point(4, 26);
            this.tlpResumen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tlpResumen.Name = "tlpResumen";
            this.tlpResumen.Padding = new System.Windows.Forms.Padding(6);
            this.tlpResumen.RowCount = 1;
            this.tlpResumen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpResumen.Size = new System.Drawing.Size(1977, 227);
            this.tlpResumen.TabIndex = 0;
            // 
            // lblResultados2
            // 
            this.lblResultados2.AutoSize = true;
            this.lblResultados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResultados2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblResultados2.Location = new System.Drawing.Point(552, 6);
            this.lblResultados2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResultados2.Name = "lblResultados2";
            this.lblResultados2.Padding = new System.Windows.Forms.Padding(6);
            this.lblResultados2.Size = new System.Drawing.Size(1415, 215);
            this.lblResultados2.TabIndex = 2;
            this.lblResultados2.Text = "Resultados...";
            // 
            // lblConfig
            // 
            this.lblConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConfig.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblConfig.Location = new System.Drawing.Point(10, 6);
            this.lblConfig.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConfig.Name = "lblConfig";
            this.lblConfig.Padding = new System.Windows.Forms.Padding(6);
            this.lblConfig.Size = new System.Drawing.Size(396, 215);
            this.lblConfig.TabIndex = 0;
            this.lblConfig.Text = "Configuración...";
            // 
            // lblResultados1
            // 
            this.lblResultados1.AutoSize = true;
            this.lblResultados1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblResultados1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblResultados1.Location = new System.Drawing.Point(414, 6);
            this.lblResultados1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblResultados1.Name = "lblResultados1";
            this.lblResultados1.Padding = new System.Windows.Forms.Padding(6);
            this.lblResultados1.Size = new System.Drawing.Size(130, 215);
            this.lblResultados1.TabIndex = 1;
            this.lblResultados1.Text = "Resultados...";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblTituloThroughputOk, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartThroughputOk, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTituloLatencia, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartLatencia, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTituloThroughputTemporal, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.chartThroughputTemporal, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(31, 280);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1985, 924);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lblTituloThroughputOk
            // 
            this.lblTituloThroughputOk.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTituloThroughputOk.AutoSize = true;
            this.lblTituloThroughputOk.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTituloThroughputOk.Location = new System.Drawing.Point(992, 3);
            this.lblTituloThroughputOk.Margin = new System.Windows.Forms.Padding(0);
            this.lblTituloThroughputOk.Name = "lblTituloThroughputOk";
            this.lblTituloThroughputOk.Size = new System.Drawing.Size(403, 28);
            this.lblTituloThroughputOk.TabIndex = 10;
            this.lblTituloThroughputOk.Text = "Histograma Throughput de hilos OK [tps]";
            // 
            // chartThroughputOk
            // 
            this.chartThroughputOk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartThroughputOk.Location = new System.Drawing.Point(992, 35);
            this.chartThroughputOk.Margin = new System.Windows.Forms.Padding(0, 0, 6, 6);
            this.chartThroughputOk.Name = "chartThroughputOk";
            this.chartThroughputOk.Size = new System.Drawing.Size(987, 344);
            this.chartThroughputOk.TabIndex = 9;
            // 
            // lblTituloLatencia
            // 
            this.lblTituloLatencia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTituloLatencia.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTituloLatencia.Location = new System.Drawing.Point(0, 0);
            this.lblTituloLatencia.Margin = new System.Windows.Forms.Padding(0);
            this.lblTituloLatencia.Name = "lblTituloLatencia";
            this.lblTituloLatencia.Size = new System.Drawing.Size(558, 35);
            this.lblTituloLatencia.TabIndex = 1;
            this.lblTituloLatencia.Text = "Histograma de Latencias de hilos [ms]";
            // 
            // chartLatencia
            // 
            this.chartLatencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartLatencia.Location = new System.Drawing.Point(0, 35);
            this.chartLatencia.Margin = new System.Windows.Forms.Padding(0, 0, 6, 6);
            this.chartLatencia.Name = "chartLatencia";
            this.chartLatencia.Size = new System.Drawing.Size(986, 344);
            this.chartLatencia.TabIndex = 2;
            // 
            // lblTituloThroughputTemporal
            // 
            this.lblTituloThroughputTemporal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTituloThroughputTemporal.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblTituloThroughputTemporal, 2);
            this.lblTituloThroughputTemporal.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTituloThroughputTemporal.Location = new System.Drawing.Point(0, 388);
            this.lblTituloThroughputTemporal.Margin = new System.Windows.Forms.Padding(0);
            this.lblTituloThroughputTemporal.Name = "lblTituloThroughputTemporal";
            this.lblTituloThroughputTemporal.Size = new System.Drawing.Size(428, 28);
            this.lblTituloThroughputTemporal.TabIndex = 11;
            this.lblTituloThroughputTemporal.Text = "Throughput en función del tiempo [trx/seg]";
            // 
            // chartThroughputTemporal
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.chartThroughputTemporal, 2);
            this.chartThroughputTemporal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartThroughputTemporal.Location = new System.Drawing.Point(0, 420);
            this.chartThroughputTemporal.Margin = new System.Windows.Forms.Padding(0, 0, 6, 6);
            this.chartThroughputTemporal.Name = "chartThroughputTemporal";
            this.chartThroughputTemporal.Size = new System.Drawing.Size(1979, 498);
            this.chartThroughputTemporal.TabIndex = 12;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAbrirEnsayo,
            this.tsbGuardarEnsayo,
            this.toolStripSeparator2,
            this.tsbMedidasRendimiento,
            this.toolStripSeparator4,
            this.tsbInfo});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1894, 57);
            this.toolStrip1.TabIndex = 43;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAbrirEnsayo
            // 
            this.tsbAbrirEnsayo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAbrirEnsayo.Image = global::ClienteHCS_2.Properties.Resources.abrir_loadTest;
            this.tsbAbrirEnsayo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbrirEnsayo.Name = "tsbAbrirEnsayo";
            this.tsbAbrirEnsayo.Size = new System.Drawing.Size(52, 52);
            this.tsbAbrirEnsayo.Text = "Abrir Resultado de ensayo de carga";
            this.tsbAbrirEnsayo.Click += new System.EventHandler(this.tsbAbrirEnsayo_Click);
            // 
            // tsbGuardarEnsayo
            // 
            this.tsbGuardarEnsayo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbGuardarEnsayo.Image = global::ClienteHCS_2.Properties.Resources.GuardarLoadTest;
            this.tsbGuardarEnsayo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGuardarEnsayo.Name = "tsbGuardarEnsayo";
            this.tsbGuardarEnsayo.Size = new System.Drawing.Size(52, 52);
            this.tsbGuardarEnsayo.Text = "Guardar Ensayo de carga";
            this.tsbGuardarEnsayo.Click += new System.EventHandler(this.tsbGuardarComo_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 57);
            // 
            // tsbMedidasRendimiento
            // 
            this.tsbMedidasRendimiento.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbMedidasRendimiento.Image = global::ClienteHCS_2.Properties.Resources.evaluacion_comparativa;
            this.tsbMedidasRendimiento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMedidasRendimiento.Name = "tsbMedidasRendimiento";
            this.tsbMedidasRendimiento.Size = new System.Drawing.Size(52, 52);
            this.tsbMedidasRendimiento.Text = "Comparar Ensayos de Carga";
            this.tsbMedidasRendimiento.Click += new System.EventHandler(this.tsbMedidasRendimiento_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 57);
            // 
            // tsbInfo
            // 
            this.tsbInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbInfo.Image = global::ClienteHCS_2.Properties.Resources.information;
            this.tsbInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbInfo.Name = "tsbInfo";
            this.tsbInfo.Size = new System.Drawing.Size(52, 52);
            this.tsbInfo.Text = "Info";
            // 
            // pnlContenido
            // 
            this.pnlContenido.AutoScroll = true;
            this.pnlContenido.Controls.Add(this.tableLayoutPanel1);
            this.pnlContenido.Controls.Add(this.grpResumen);
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(0, 57);
            this.pnlContenido.Margin = new System.Windows.Forms.Padding(0);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(1894, 1059);
            this.pnlContenido.TabIndex = 44;
            // 
            // FrmDetallesEnsayoCarga
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1894, 1116);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(886, 576);
            this.Name = "FrmDetallesEnsayoCarga";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalles del ensayo de carga";
            this.grpResumen.ResumeLayout(false);
            this.tlpResumen.ResumeLayout(false);
            this.tlpResumen.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartThroughputOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLatencia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartThroughputTemporal)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlContenido.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpResumen;
        private System.Windows.Forms.TableLayoutPanel tlpResumen;
        private System.Windows.Forms.Label lblConfig;
        private System.Windows.Forms.Label lblResultados1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTituloLatencia;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartThroughputOk;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLatencia;
        private System.Windows.Forms.Label lblTituloThroughputOk;
        private System.Windows.Forms.Label lblResultados2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAbrirEnsayo;
        private System.Windows.Forms.ToolStripButton tsbGuardarEnsayo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsbInfo;
        private System.Windows.Forms.ToolStripButton tsbMedidasRendimiento;
        private System.Windows.Forms.Label lblTituloThroughputTemporal;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartThroughputTemporal;
        private System.Windows.Forms.Panel pnlContenido;
    }
}
