namespace ClienteHCS_2
{
    partial class FrmConfiguracionRampa
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblIncremento = new System.Windows.Forms.Label();
            this.nudIncremento = new System.Windows.Forms.NumericUpDown();
            this.lblIncrementoAyuda = new System.Windows.Forms.Label();
            this.lblIntervalo = new System.Windows.Forms.Label();
            this.nudIntervaloSeg = new System.Windows.Forms.NumericUpDown();
            this.lblIntervaloAyuda = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tlpPrincipal = new System.Windows.Forms.TableLayoutPanel();
            this.flpBotones = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.nudIncremento)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntervaloSeg)).BeginInit();
            this.tlpPrincipal.SuspendLayout();
            this.flpBotones.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(3, 0);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 7);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(346, 48);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Defina cuántos hilos se añaden en cada paso y el tiempo de espera entre pasos, ha" +
    "sta alcanzar el total configurado en el ensayo.";
            // 
            // lblIncremento
            // 
            this.lblIncremento.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblIncremento.AutoSize = true;
            this.lblIncremento.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncremento.Location = new System.Drawing.Point(3, 55);
            this.lblIncremento.Name = "lblIncremento";
            this.lblIncremento.Size = new System.Drawing.Size(182, 17);
            this.lblIncremento.TabIndex = 1;
            this.lblIncremento.Text = "Hilos por paso (incremento)";
            // 
            // nudIncremento
            // 
            this.nudIncremento.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudIncremento.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudIncremento.Location = new System.Drawing.Point(3, 75);
            this.nudIncremento.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudIncremento.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudIncremento.Name = "nudIncremento";
            this.nudIncremento.Size = new System.Drawing.Size(86, 27);
            this.nudIncremento.TabIndex = 2;
            this.nudIncremento.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // lblIncrementoAyuda
            // 
            this.lblIncrementoAyuda.AutoSize = true;
            this.lblIncrementoAyuda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIncrementoAyuda.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblIncrementoAyuda.Location = new System.Drawing.Point(3, 105);
            this.lblIncrementoAyuda.Margin = new System.Windows.Forms.Padding(3, 0, 3, 9);
            this.lblIncrementoAyuda.Name = "lblIncrementoAyuda";
            this.lblIncrementoAyuda.Size = new System.Drawing.Size(299, 15);
            this.lblIncrementoAyuda.TabIndex = 3;
            this.lblIncrementoAyuda.Text = "Entre 1 y 1000. Si es mayor que el total, un solo paso.";
            // 
            // lblIntervalo
            // 
            this.lblIntervalo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblIntervalo.AutoSize = true;
            this.lblIntervalo.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntervalo.Location = new System.Drawing.Point(3, 129);
            this.lblIntervalo.Name = "lblIntervalo";
            this.lblIntervalo.Size = new System.Drawing.Size(212, 17);
            this.lblIntervalo.TabIndex = 4;
            this.lblIntervalo.Text = "Intervalo entre pasos (segundos)";
            // 
            // nudIntervaloSeg
            // 
            this.nudIntervaloSeg.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.nudIntervaloSeg.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nudIntervaloSeg.Location = new System.Drawing.Point(3, 149);
            this.nudIntervaloSeg.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.nudIntervaloSeg.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudIntervaloSeg.Name = "nudIntervaloSeg";
            this.nudIntervaloSeg.Size = new System.Drawing.Size(86, 27);
            this.nudIntervaloSeg.TabIndex = 5;
            this.nudIntervaloSeg.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblIntervaloAyuda
            // 
            this.lblIntervaloAyuda.AutoSize = true;
            this.lblIntervaloAyuda.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIntervaloAyuda.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblIntervaloAyuda.Location = new System.Drawing.Point(3, 179);
            this.lblIntervaloAyuda.Name = "lblIntervaloAyuda";
            this.lblIntervaloAyuda.Size = new System.Drawing.Size(139, 15);
            this.lblIntervaloAyuda.TabIndex = 6;
            this.lblIntervaloAyuda.Text = "Entre 1 y 600 segundos.";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(94, 3);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(85, 24);
            this.btnAceptar.TabIndex = 7;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(3, 3);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 24);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // tlpPrincipal
            // 
            this.tlpPrincipal.ColumnCount = 1;
            this.tlpPrincipal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrincipal.Controls.Add(this.lblTitulo, 0, 0);
            this.tlpPrincipal.Controls.Add(this.lblIncremento, 0, 1);
            this.tlpPrincipal.Controls.Add(this.nudIncremento, 0, 2);
            this.tlpPrincipal.Controls.Add(this.lblIncrementoAyuda, 0, 3);
            this.tlpPrincipal.Controls.Add(this.lblIntervalo, 0, 4);
            this.tlpPrincipal.Controls.Add(this.nudIntervaloSeg, 0, 5);
            this.tlpPrincipal.Controls.Add(this.lblIntervaloAyuda, 0, 6);
            this.tlpPrincipal.Controls.Add(this.flpBotones, 0, 7);
            this.tlpPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrincipal.Location = new System.Drawing.Point(10, 10);
            this.tlpPrincipal.Name = "tlpPrincipal";
            this.tlpPrincipal.RowCount = 8;
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrincipal.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpPrincipal.Size = new System.Drawing.Size(355, 237);
            this.tlpPrincipal.TabIndex = 0;
            // 
            // flpBotones
            // 
            this.flpBotones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flpBotones.AutoSize = true;
            this.flpBotones.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flpBotones.Controls.Add(this.btnAceptar);
            this.flpBotones.Controls.Add(this.btnCancelar);
            this.flpBotones.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpBotones.Location = new System.Drawing.Point(170, 203);
            this.flpBotones.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.flpBotones.Name = "flpBotones";
            this.flpBotones.Size = new System.Drawing.Size(182, 30);
            this.flpBotones.TabIndex = 9;
            this.flpBotones.WrapContents = false;
            // 
            // FrmConfiguracionRampa
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(375, 257);
            this.Controls.Add(this.tlpPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfiguracionRampa";
            this.Padding = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuración de rampa";
            this.Load += new System.EventHandler(this.FrmConfiguracionRampa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudIncremento)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntervaloSeg)).EndInit();
            this.tlpPrincipal.ResumeLayout(false);
            this.tlpPrincipal.PerformLayout();
            this.flpBotones.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblIncremento;
        private System.Windows.Forms.NumericUpDown nudIncremento;
        private System.Windows.Forms.Label lblIncrementoAyuda;
        private System.Windows.Forms.Label lblIntervalo;
        private System.Windows.Forms.NumericUpDown nudIntervaloSeg;
        private System.Windows.Forms.Label lblIntervaloAyuda;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TableLayoutPanel tlpPrincipal;
        private System.Windows.Forms.FlowLayoutPanel flpBotones;
    }
}
