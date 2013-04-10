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
    public partial class Frm_Periodo : Form
    {
        public Frm_Periodo()
        {
            InitializeComponent();
        }

        //DateTime dt = new DateTime();
        //DateTime dt1 = dt.AddMonths(2);
        //dt.Subtract(
        public string vVar = "";
        private void button1_Click(object sender, EventArgs e)
        {
            if (vVar=="FECHAS")
            {
                this.Cursor = Cursors.WaitCursor;
                Consultas.Frm_Fechas frm = new Logistica.Ingenieria.Presentacion.Consultas.Frm_Fechas();
                frm.dt1 = DTP1;
                frm.dt2 = DTP2;
                frm.ShowDialog();
                this.Cursor = Cursors.Default;
            }
            if (vVar == "CONSUMO")
            {
                this.Cursor = Cursors.WaitCursor;
                Consultas.Frm_Consumos_AI frm = new Logistica.Ingenieria.Presentacion.Consultas.Frm_Consumos_AI();
                frm.dt1 = DTP1;
                frm.dt2 = DTP2;
                frm.ShowDialog();
                this.Cursor = Cursors.Default;
            }
            if (vVar == "INGRESO")
            {
                this.Cursor = Cursors.WaitCursor;
                Consultas.Frm_Ingreso_AI frm = new Logistica.Ingenieria.Presentacion.Consultas.Frm_Ingreso_AI();
                frm.dt1 = DTP1;
                frm.dt2 = DTP2;
                frm.ShowDialog();
                this.Cursor = Cursors.Default;
            }

        }

        private void Frm_Periodo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
