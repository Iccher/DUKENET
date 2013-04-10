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
    public partial class FrmPeriodo : Form
    {
        public FrmPeriodo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmDescomposicion frm = new frmDescomposicion();
            frm.fecha = dateTimePicker1.Text;
            frm.ShowDialog();
        }

        private void FrmPeriodo_Load(object sender, EventArgs e)
        {

        }
    }
}
