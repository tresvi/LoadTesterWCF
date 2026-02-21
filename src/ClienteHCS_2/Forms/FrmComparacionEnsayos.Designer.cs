using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ClienteHCS_2
{
    partial class FrmComparacionEnsayos
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblAdvertencias = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chartRadar = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgvMetricas = new System.Windows.Forms.DataGridView();
            this.colMetrica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colComparado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDelta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLectura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartRadar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetricas)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblTitulo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblAdvertencias, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1024, 684);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(13, 10);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.lblTitulo.Size = new System.Drawing.Size(998, 35);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Comparación de ensayos";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAdvertencias
            // 
            this.lblAdvertencias.AutoSize = true;
            this.lblAdvertencias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblAdvertencias.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdvertencias.Location = new System.Drawing.Point(13, 45);
            this.lblAdvertencias.Name = "lblAdvertencias";
            this.lblAdvertencias.Padding = new System.Windows.Forms.Padding(0, 0, 0, 8);
            this.lblAdvertencias.Size = new System.Drawing.Size(998, 35);
            this.lblAdvertencias.TabIndex = 1;
            this.lblAdvertencias.Text = "Advertencias";
            this.lblAdvertencias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(13, 83);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.chartRadar);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvMetricas);
            this.splitContainer1.Size = new System.Drawing.Size(998, 588);
            this.splitContainer1.SplitterDistance = 400;
            this.splitContainer1.TabIndex = 2;
            // 
            // chartRadar
            // 
            this.chartRadar.BackColor = System.Drawing.Color.White;
            chartArea1.AxisX.Interval = 1D;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY.Interval = 20D;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY.Maximum = 100D;
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.AxisY.Title = "Score normalizado (0-100)";
            chartArea1.BackColor = System.Drawing.Color.White;
            chartArea1.Name = "Radar";
            this.chartRadar.ChartAreas.Add(chartArea1);
            this.chartRadar.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend";
            this.chartRadar.Legends.Add(legend1);
            this.chartRadar.Location = new System.Drawing.Point(0, 0);
            this.chartRadar.Name = "chartRadar";
            this.chartRadar.Size = new System.Drawing.Size(998, 400);
            this.chartRadar.TabIndex = 0;
            this.chartRadar.Text = "chart1";
            // 
            // dgvMetricas
            // 
            this.dgvMetricas.AllowUserToAddRows = false;
            this.dgvMetricas.AllowUserToDeleteRows = false;
            this.dgvMetricas.AllowUserToResizeRows = false;
            this.dgvMetricas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMetricas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMetricas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMetrica,
            this.colActual,
            this.colComparado,
            this.colDelta,
            this.colLectura});
            this.dgvMetricas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMetricas.Location = new System.Drawing.Point(0, 0);
            this.dgvMetricas.MultiSelect = false;
            this.dgvMetricas.Name = "dgvMetricas";
            this.dgvMetricas.ReadOnly = true;
            this.dgvMetricas.RowHeadersVisible = false;
            this.dgvMetricas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMetricas.Size = new System.Drawing.Size(998, 184);
            this.dgvMetricas.TabIndex = 0;
            // 
            // colMetrica
            // 
            this.colMetrica.HeaderText = "Métrica";
            this.colMetrica.Name = "colMetrica";
            this.colMetrica.ReadOnly = true;
            // 
            // colActual
            // 
            this.colActual.HeaderText = "Actual";
            this.colActual.Name = "colActual";
            this.colActual.ReadOnly = true;
            // 
            // colComparado
            // 
            this.colComparado.HeaderText = "Comparado";
            this.colComparado.Name = "colComparado";
            this.colComparado.ReadOnly = true;
            // 
            // colDelta
            // 
            this.colDelta.HeaderText = "Delta";
            this.colDelta.Name = "colDelta";
            this.colDelta.ReadOnly = true;
            // 
            // colLectura
            // 
            this.colLectura.HeaderText = "Lectura";
            this.colLectura.Name = "colLectura";
            this.colLectura.ReadOnly = true;
            // 
            // FrmComparacionEnsayos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 684);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(860, 580);
            this.Name = "FrmComparacionEnsayos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Comparación de ensayos";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartRadar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetricas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblAdvertencias;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRadar;
        private System.Windows.Forms.DataGridView dgvMetricas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMetrica;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn colComparado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDelta;
        private System.Windows.Forms.DataGridViewTextBoxColumn colLectura;
    }
}