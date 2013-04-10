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
    public partial class FrmReporteMP : Form
    {
        public FrmReporteMP()
        {
            InitializeComponent();
        }

        public List<EntidadMP> oMP = new List<EntidadMP>();
        BTablas obTablas = new BTablas();

        private void FrmReporteMP_Load(object sender, EventArgs e)
        {
            EMateriaPrima.DataSource = oMP;
            this.reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
            this.reportViewer1.RefreshReport();
        }
    }
}
