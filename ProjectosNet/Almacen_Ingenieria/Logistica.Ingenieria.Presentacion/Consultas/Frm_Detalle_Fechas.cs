using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Logistica.Ingenieria.Bussiness;

namespace Logistica.Ingenieria.Presentacion.Consultas
{
    public partial class Frm_Detalle_Fechas : Form
    {
        public Frm_Detalle_Fechas()
        {
            InitializeComponent();
        }

        public string vMES = "";
        public decimal vVale = 0;

        public string vCodAutoriza = "";
        public string vAutoriza = "";
        public string vCodSolicita = "";
        public string vSolicita = "";
        public string vCodArea = "";
        public string vArea = "";

        BTablas oBusTab = new BTablas();

        private void Frm_Detalle_Fechas_Load(object sender, EventArgs e)
        {
            dgvValesIng.DataSource = oBusTab.getArmadoSalidasXProducto(vMES, vVale);
        }
    }
}
