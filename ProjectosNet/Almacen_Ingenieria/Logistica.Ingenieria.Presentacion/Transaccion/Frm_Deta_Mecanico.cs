using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Logistica.Ingenieria.Bussiness;

namespace Logistica.Ingenieria.Presentacion.Transaccion
{
    public partial class Frm_Deta_Mecanico : Form
    {
        public Frm_Deta_Mecanico()
        {
            InitializeComponent();
        }

        BTransaccion objTransa = new BTransaccion();
        BTablas objTablas = new BTablas();

        public string codProd = "";
        public string nomProd = "";

        DataTable dtRepDes = new DataTable();
        DateTime FechaSis = DateTime.Now; 

        private void Frm_Deta_Mecanico_Load(object sender, EventArgs e)
        {            
            lblCodProd.Text = codProd + "  -  " + nomProd;

            objTablas = new BTablas();
            dtRepDes = objTablas.getDescriAdicionalMECANICOS(codProd);

            if (dtRepDes.Rows.Count > 0)
            {
                lblBusqueda.Text = "Modificacion de Descripcion Repuestos";
                txtDescripcion.Text = dtRepDes.Rows[0]["MPDDES"].ToString().Trim();
                txtDescripcion.Focus();
            }
            else
            {
                lblBusqueda.Text = "Ingreso de Descripcion de Repuestos";
                txtDescripcion.Focus();
            }
        }


        decimal fecha = 0;
        decimal Hora = 0;
        public int flag = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            fecha = Convert.ToDecimal(FechaSis.ToShortDateString().Substring(6, 4) + FechaSis.ToShortDateString().Substring(3, 2) + FechaSis.ToShortDateString().Substring(0, 2));
            Hora = Convert.ToDecimal(FechaSis.Hour.ToString() + FechaSis.Minute.ToString());
            if (dtRepDes.Rows.Count > 0)
            {
                if (MessageBox.Show("Desea Modificar Det.Adicional Req.", "Alm.Ing", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    flag = objTransa.BUpdateSQL("UPDATE " + Program.LibreLALMINGB + ".ALMMMAPDES " +
" SET MPDUID = '" + Program.Usuario + "' " +
" 	,MPDUFE = " + fecha + " " +
" 	,MPDUHM = " + Hora + " " +
" 	,MPDDES = '" + txtDescripcion.Text.ToString().ToUpper().Trim() + "' " +
" WHERE MPDCOD = '" + codProd + "'");
                    /*MENSAJE DE OKA*/
                    if (flag == 1)
                    {
                        MessageBox.Show("Modificado Correctamente", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    } 
                }
            }
            else
            {
                if (MessageBox.Show("Desea Ingresar Det.Adicional Req.", "Alm.Ing", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    flag = objTablas.BInsertDescriAdicionalMECANICOS(Program.Usuario, fecha, Hora, codProd, txtDescripcion.Text.ToString().ToUpper().Trim());
                    /*MENSAJE DE OKA*/
                    if (flag == 1)
                    {
                        MessageBox.Show("Ingresado Correctamente", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }

        }

        private void Frm_Deta_Mecanico_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }



    }
}
