namespace Logistica.Ingenieria.Presentacion.Reportes
{
    partial class Frm_Reporte_Vale
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Reporte_Vale));
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.eReporte = new System.Windows.Forms.BindingSource(this.components);
            this.EReporteVALEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.eReporte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EReporteVALEBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "Logistica_Ingenieria_Entity_EReporteVALE";
            reportDataSource1.Value = this.eReporte;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "Logistica.Ingenieria.Presentacion.Reportes.RepValeVER4.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(712, 579);
            this.reportViewer2.TabIndex = 0;
            // 
            // eReporte
            // 
            this.eReporte.DataSource = typeof(Logistica.Ingenieria.Bussiness.BReporte);
            // 
            // EReporteVALEBindingSource
            // 
            this.EReporteVALEBindingSource.DataSource = typeof(Logistica.Ingenieria.Entity.EReporteVALE);
            // 
            // Frm_Reporte_Vale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 579);
            this.Controls.Add(this.reportViewer2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Reporte_Vale";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte Vale";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Frm_Reporte_Vale_FormClosed);
            this.Load += new System.EventHandler(this.Frm_Reporte_Vale_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eReporte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EReporteVALEBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource eReporte;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.BindingSource EReporteVALEBindingSource;
    }
}