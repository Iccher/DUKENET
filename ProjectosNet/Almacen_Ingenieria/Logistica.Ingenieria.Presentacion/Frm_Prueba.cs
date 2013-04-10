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
    public partial class Frm_Prueba : Form
    {
        public Frm_Prueba()
        {
            InitializeComponent();
        }
        //public string mes1 = "";
        //public string mes2 = "";

        public DateTimePicker dt1 = new DateTimePicker();
        public DateTimePicker dt2 = new DateTimePicker();
        BTablas objBus = new BTablas();     
   
        private void Frm_Prueba_Load(object sender, EventArgs e)
        {
            DateTime mes1 = dt1.Value;
            DateTime mes2 = dt2.Value; 
            //mes1 = "1001";
            //mes2 = "1001";
            dataGridView1.DataSource = objBus.getArmado(Program.dtEmpleados, Program.dtArea, mes1, mes2);
        }

    }
}
