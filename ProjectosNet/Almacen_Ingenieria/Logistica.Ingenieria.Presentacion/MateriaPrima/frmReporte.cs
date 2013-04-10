using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Logistica.Ingenieria.Bussiness;

namespace Logistica.Ingenieria.Presentacion
{
    public partial class frmReporte : Form
    {
        public frmReporte()
        {
            InitializeComponent();
        }

        public string VALE;
        NReqMatProd obj = new NReqMatProd();
        private void frmReporte_Load(object sender, EventArgs e)
        {
            obj = new NReqMatProd();
            EReporteVALEBindingSource.DataSource = obj.DListarProforma(VALE);
            ///dataGridView1.DataSource = oRep.DListarProforma(0, "xxxxxx", "aaaaaa");
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer1.RefreshReport();
        }
    }
}
