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
    public partial class Frm_Seleccion_CCT : Form
    {
        public Frm_Seleccion_CCT()
        {
            InitializeComponent();
        }

        BTablas obTran = new BTablas();

        DataTable dtcuentasMP = new DataTable();
        DataTable dtcuentasAI = new DataTable();



        List<String> listCTAALM = new List<string>();

        private void Frm_Seleccion_CCT_Load(object sender, EventArgs e)
        {
            obTran = new BTablas();
            dtcuentasMP = obTran.getSELECTLIBRE("SELECT MPTARG,CASE WHEN  MPTARG='00' " +
" THEN 'Bladder' " +
" ELSE MPTDES  " +
" END MPTDES  FROM ( " +
" SELECT MPTARG,MPTDES FROM " + Program.LibreLALMACEB + ".ALMTALM WHERE MPTTAB='CAL' " +
" UNION ALL " +
" SELECT MPTARG,MPTDES FROM " + Program.LibreLALMACEB + ".ALMTALM WHERE MPTTAB='CAI' AND MPTARG='00' " +
" ) AS M");
            /*ListView Cuenta Almacen*/
            int i = 0;
            while (i <= dtcuentasMP.Rows.Count - 1)
            {
                ListViewItem List;
                List = lvCtaAlmMP.Items.Add(dtcuentasMP.Rows[i]["MPTDES"].ToString());
                List.SubItems.Add(dtcuentasMP.Rows[i]["MPTDES"].ToString());
                i += 1;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i = 0;
            string opcion = "";
            listCTAALM = new List<string>();


            while (i <= lvCtaAlmMP.Items.Count - 1)
            {
                if (lvCtaAlmMP.Items[i].Checked == true)
                {
                    opcion = opcion + "'" + lvCtaAlmMP.Items[i].Text.ToString().Trim() + "'" + ",";
                    listCTAALM.Add(lvCtaAlmMP.Items[i].Text.ToString().Trim());
                }
                i += 1;
            }


            string cadena = "";
            if (opcion.Length > 0)
            {
                cadena = opcion.Substring(0, opcion.Length - 1);
            }

            if (listCTAALM.Count > 0)
            {
                Consultas.Frm_Consulta_Principal_MP frm = new Frm_Consulta_Principal_MP();
                frm.cadena = cadena;

                if (CHK1.Checked == true && CHK2.Checked == true)
                {
                    frm.whereAG = "'','Agotado'";
                }
                if (CHK1.Checked == true && CHK2.Checked == false)
                {
                    frm.whereAG = "''";
                }
                if (CHK1.Checked == false && CHK2.Checked == true)
                {
                    frm.whereAG = "'Agotado'";
                }


                if (frm.whereAG != "")
                {
                    frm.listCTAALM = listCTAALM;
                    frm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Seleccione Materia prima Activo o Agotado", "Materia Prima", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Seleccione Cuentas de Almacen", "Materia Prima", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }


        int j = 0;
        string flag1 = "1";
        private void button1_Click(object sender, EventArgs e)
        {
            if (flag1 == "1")
            {
                while (j <= lvCtaAlmMP.Items.Count - 1)
                {
                    lvCtaAlmMP.Items[j].Checked = true;
                    j += 1;
                }
                j = 0;
                flag1 = "2";
            }
            else
            {
                while (j <= lvCtaAlmMP.Items.Count - 1)
                {
                    lvCtaAlmMP.Items[j].Checked = false;
                    j += 1;
                }
                j = 0;
                flag1 = "1";
            }  
        }
    }
}
