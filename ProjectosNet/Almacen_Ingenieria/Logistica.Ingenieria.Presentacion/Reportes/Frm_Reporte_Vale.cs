using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Logistica.Ingenieria.Entity;
using Logistica.Ingenieria.Bussiness;
using Microsoft.Reporting.WinForms;

namespace Logistica.Ingenieria.Presentacion.Reportes
{
    public partial class Frm_Reporte_Vale : Form
    {
        public Frm_Reporte_Vale()
        {
            InitializeComponent();
        }

        BReporte oRep = new BReporte();
        public decimal nro_Vale = 0;

        public string observacion = "";

        private System.Drawing.Printing.PrintDocument docToPrint = new System.Drawing.Printing.PrintDocument();
        private void Frm_Reporte_Vale_Load(object sender, EventArgs e)
        {
            //PageSetupDialog pgS = new PageSetupDialog();
            //System.Drawing.Printing.PaperSize pag = new System.Drawing.Printing.PaperSize();
            //pag.Height = 551;
            //pag.Width = 846;
            ReportParameter[] parameters = new ReportParameter[1];
            parameters[0] = new ReportParameter("Observacion", observacion);
            eReporte.DataSource = oRep.DListarProforma(nro_Vale, "xxxxxx", "aaaaaa");
            this.reportViewer2.LocalReport.SetParameters(parameters);
            //eReporte.DataSource = oRep.DListarProforma(2011021970, "xxxxxx", "aaaaaa");
            ///dataGridView1.DataSource = oRep.DListarProforma(0, "xxxxxx", "aaaaaa");
            this.reportViewer2.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            //printDocument1.PrintPage 
            //printDialog1.Document = oRep.DListarProforma(nro_Vale, "xxxxxx", "aaaaaa"); ;
            //this.reportViewer1.set
            //this.reportViewer1.PrintDialog();
            //printDialog1.PrinterSettings.
            this.reportViewer2.RefreshReport();
        }

        private void Frm_Reporte_Vale_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
