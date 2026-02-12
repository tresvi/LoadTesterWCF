using System.Windows.Forms.DataVisualization.Charting;

namespace ClienteHCS_2
{
    partial class FrmDetallesEnsayo
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
            this.btnExportar = new System.Windows.Forms.Button();
            this.grpResumen = new System.Windows.Forms.GroupBox();
            this.tlpResumen = new System.Windows.Forms.TableLayoutPanel();
            this.lblResultados2 = new System.Windows.Forms.Label();
            this.lblConfig = new System.Windows.Forms.Label();
            this.lblResultados1 = new System.Windows.Forms.Label();
            this.tlpGraficos = new System.Windows.Forms.TableLayoutPanel();
            this.lblTituloThroughputFail = new System.Windows.Forms.Label();
            this.chartThroughputFail = new Chart();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTituloThroughputOk = new System.Windows.Forms.Label();
            this.chartThroughputOk = new Chart();
            this.lblTituloLatencia = new System.Windows.Forms.Label();
            this.chartLatencia = new Chart();
            this.grpResumen.SuspendLayout();
            this.tlpResumen.SuspendLayout();
            this.tlpGraficos.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExportar
            // 
            this.btnExportar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnExportar.Location = new System.Drawing.Point(750, 441);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(199, 28);
            this.btnExportar.TabIndex = 3;
            this.btnExportar.Text = "Exportar resultados...";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // grpResumen
            // 
            this.grpResumen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpResumen.Controls.Add(this.tlpResumen);
            this.grpResumen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpResumen.Location = new System.Drawing.Point(12, 12);
            this.grpResumen.Name = "grpResumen";
            this.grpResumen.Size = new System.Drawing.Size(1112, 140);
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
            this.tlpResumen.Location = new System.Drawing.Point(3, 17);
            this.tlpResumen.Name = "tlpResumen";
            this.tlpResumen.Padding = new System.Windows.Forms.Padding(4);
            this.tlpResumen.RowCount = 1;
            this.tlpResumen.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpResumen.Size = new System.Drawing.Size(1106, 120);
            this.tlpResumen.TabIndex = 0;
            // 
            // lblResultados2
            // 
            this.lblResultados2.AutoSize = true;
            this.lblResultados2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResultados2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblResultados2.Location = new System.Drawing.Point(372, 4);
            this.lblResultados2.Name = "lblResultados2";
            this.lblResultados2.Padding = new System.Windows.Forms.Padding(4);
            this.lblResultados2.Size = new System.Drawing.Size(727, 112);
            this.lblResultados2.TabIndex = 2;
            this.lblResultados2.Text = "Resultados...";
            // 
            // lblConfig
            // 
            this.lblConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblConfig.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblConfig.Location = new System.Drawing.Point(7, 4);
            this.lblConfig.Name = "lblConfig";
            this.lblConfig.Padding = new System.Windows.Forms.Padding(4);
            this.lblConfig.Size = new System.Drawing.Size(264, 112);
            this.lblConfig.TabIndex = 0;
            this.lblConfig.Text = "Configuración...";
            // 
            // lblResultados1
            // 
            this.lblResultados1.AutoSize = true;
            this.lblResultados1.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblResultados1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblResultados1.Location = new System.Drawing.Point(277, 4);
            this.lblResultados1.Name = "lblResultados1";
            this.lblResultados1.Padding = new System.Windows.Forms.Padding(4);
            this.lblResultados1.Size = new System.Drawing.Size(89, 112);
            this.lblResultados1.TabIndex = 1;
            this.lblResultados1.Text = "Resultados...";
            // 
            // tlpGraficos
            // 
            this.tlpGraficos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpGraficos.ColumnCount = 2;
            this.tlpGraficos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGraficos.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpGraficos.Controls.Add(this.lblTituloThroughputFail, 0, 4);
            this.tlpGraficos.Controls.Add(this.chartThroughputFail, 0, 5);
            this.tlpGraficos.Location = new System.Drawing.Point(1126, 348);
            this.tlpGraficos.Name = "tlpGraficos";
            this.tlpGraficos.RowCount = 6;
            this.tlpGraficos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlpGraficos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpGraficos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tlpGraficos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33F));
            this.tlpGraficos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tlpGraficos.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.34F));
            this.tlpGraficos.Size = new System.Drawing.Size(546, 0);
            this.tlpGraficos.TabIndex = 1;
            this.tlpGraficos.Visible = false;
            // 
            // lblTituloThroughputFail
            // 
            this.lblTituloThroughputFail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTituloThroughputFail.AutoSize = true;
            this.lblTituloThroughputFail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTituloThroughputFail.Location = new System.Drawing.Point(0, -1);
            this.lblTituloThroughputFail.Margin = new System.Windows.Forms.Padding(0);
            this.lblTituloThroughputFail.Name = "lblTituloThroughputFail";
            this.lblTituloThroughputFail.Size = new System.Drawing.Size(214, 22);
            this.lblTituloThroughputFail.TabIndex = 4;
            this.lblTituloThroughputFail.Text = "Histograma Throughput Fail (trx fallidas/seg por hilo)";
            // 
            // chartThroughputFail
            // 
            this.chartThroughputFail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartThroughputFail.Location = new System.Drawing.Point(0, 21);
            this.chartThroughputFail.Margin = new System.Windows.Forms.Padding(0);
            this.chartThroughputFail.Name = "chartThroughputFail";
            this.chartThroughputFail.Size = new System.Drawing.Size(273, 1);
            this.chartThroughputFail.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblTituloThroughputOk, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartThroughputOk, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTituloLatencia, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chartLatencia, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(17, 157);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1104, 295);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // lblTituloThroughputOk
            // 
            this.lblTituloThroughputOk.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTituloThroughputOk.AutoSize = true;
            this.lblTituloThroughputOk.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTituloThroughputOk.Location = new System.Drawing.Point(552, 7);
            this.lblTituloThroughputOk.Margin = new System.Windows.Forms.Padding(0);
            this.lblTituloThroughputOk.Name = "lblTituloThroughputOk";
            this.lblTituloThroughputOk.Size = new System.Drawing.Size(266, 17);
            this.lblTituloThroughputOk.TabIndex = 10;
            this.lblTituloThroughputOk.Text = "Histograma Throughput de hilos OK [tps]";
            // 
            // chartThroughputOk
            // 
            this.chartThroughputOk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartThroughputOk.Location = new System.Drawing.Point(552, 32);
            this.chartThroughputOk.Margin = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.chartThroughputOk.Name = "chartThroughputOk";
            this.chartThroughputOk.Size = new System.Drawing.Size(548, 259);
            this.chartThroughputOk.TabIndex = 9;
            // 
            // lblTituloLatencia
            // 
            this.lblTituloLatencia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTituloLatencia.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblTituloLatencia.Location = new System.Drawing.Point(0, 2);
            this.lblTituloLatencia.Margin = new System.Windows.Forms.Padding(0);
            this.lblTituloLatencia.Name = "lblTituloLatencia";
            this.lblTituloLatencia.Size = new System.Drawing.Size(372, 27);
            this.lblTituloLatencia.TabIndex = 1;
            this.lblTituloLatencia.Text = "Histograma de Latencias de hilos [ms]";
            // 
            // chartLatencia
            // 
            this.chartLatencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartLatencia.Location = new System.Drawing.Point(0, 32);
            this.chartLatencia.Margin = new System.Windows.Forms.Padding(0, 0, 4, 4);
            this.chartLatencia.Name = "chartLatencia";
            this.chartLatencia.Size = new System.Drawing.Size(548, 259);
            this.chartLatencia.TabIndex = 2;
            // 
            // FrmDetallesEnsayo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 470);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tlpGraficos);
            this.Controls.Add(this.grpResumen);
            this.Controls.Add(this.btnExportar);
            this.MinimumSize = new System.Drawing.Size(598, 394);
            this.Name = "FrmDetallesEnsayo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Detalles del ensayo";
            this.grpResumen.ResumeLayout(false);
            this.tlpResumen.ResumeLayout(false);
            this.tlpResumen.PerformLayout();
            this.tlpGraficos.ResumeLayout(false);
            this.tlpGraficos.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpResumen;
        private System.Windows.Forms.TableLayoutPanel tlpResumen;
        private System.Windows.Forms.Label lblConfig;
        private System.Windows.Forms.Label lblResultados1;
        private System.Windows.Forms.TableLayoutPanel tlpGraficos;
        private Chart chartThroughputFail;
        private System.Windows.Forms.Label lblTituloThroughputFail;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTituloLatencia;
        private Chart chartThroughputOk;
        private Chart chartLatencia;
        private System.Windows.Forms.Label lblTituloThroughputOk;
        private System.Windows.Forms.Label lblResultados2;
        private System.Windows.Forms.Button btnExportar;
    }
}
