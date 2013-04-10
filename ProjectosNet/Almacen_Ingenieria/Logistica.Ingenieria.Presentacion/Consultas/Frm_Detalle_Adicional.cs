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
    public partial class Frm_Detalle_Adicional : Form
    {
        public Frm_Detalle_Adicional()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        BTablas objBusTab = new BTablas();
        DataTable dtRepuesto = new DataTable();

        public string codProd = "";
        public string nomprod = "";
        public string parte = "";
        public string aplicabilidad = "";
        public string precio = "";
        string SQL = "";
        private void Frm_Detalle_Adicional_Load(object sender, EventArgs e)
        {
            lblBusqueda.Text = codProd.Trim() + "  -  " + nomprod.Trim();
            SQL = "SELECT " +
" MIMSTT,MIMUID,MIMUFE,MIMUHM,MIMCOD,MIMDES,MIDEA1,MIDEA2,MIDEA3,MIDEA4,MIDEA5, " +
" MIDEA6,MIMCTA, " +
" CASE WHEN MIMPRO=1 THEN 'Local' " +
" WHEN MIMPRO=2 THEN 'Local/Importado' " +
" WHEN MIMPRO=3 THEN 'Importado' " +
" ELSE 'Autoconsumo' END AS MIMPRO, " +
" MIMUNI,MIMSCO,MIMSDI,T01AL1 " +
" FROM " + Program.LibreLALMINGB + ".ALMWCON LEFT OUTER JOIN " +
" (SELECT T01ESP,T01AL1,T01AL2,T01NU2 FROM " + Program.LibreLUGTF + ".UGT01 WHERE T01IDT='UND' AND T01NU2=1) AS M ON SUBSTR(DIGITS(MIMUNI),2,2)=M.T01ESP " +
" WHERE MIMCOD='" + codProd.Trim() + "'";
            dtRepuesto = objBusTab.getSELECTLIBRE(SQL);

            lbl1.Text = dtRepuesto.Rows[0]["MIMDES"].ToString().Trim();
            lbl2.Text = dtRepuesto.Rows[0]["MIDEA1"].ToString().Trim();
            lbl3.Text = dtRepuesto.Rows[0]["MIDEA2"].ToString().Trim();
            lbl4.Text = dtRepuesto.Rows[0]["MIDEA3"].ToString().Trim();
            lbl5.Text = dtRepuesto.Rows[0]["MIDEA4"].ToString().Trim();
            lbl6.Text = dtRepuesto.Rows[0]["MIDEA5"].ToString().Trim();
            lbl7.Text = dtRepuesto.Rows[0]["MIDEA6"].ToString().Trim();

            lblPro.Text = dtRepuesto.Rows[0]["MIMPRO"].ToString().Trim();
            lblMedida.Text = dtRepuesto.Rows[0]["T01AL1"].ToString().Trim();
            lblPre.Text = precio;

            lblParte.Text = parte;
            lblApli.Text = aplicabilidad;




        }
    }
}
