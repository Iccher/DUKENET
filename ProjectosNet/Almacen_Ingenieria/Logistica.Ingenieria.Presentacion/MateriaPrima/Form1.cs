using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Logistica.Ingenieria.Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void requerimientoMaterialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            FrmPeriodo frm = new FrmPeriodo();
            frm.ShowDialog();
        }

        private void valeLibreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmValeLibre frm = new frmValeLibre();
            frm.ShowDialog();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
