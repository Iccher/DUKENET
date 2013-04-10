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
    public partial class Frm_Aprobacion_Firma_Electronica_Detalle : Form
    {
        public Frm_Aprobacion_Firma_Electronica_Detalle()
        {
            InitializeComponent();
        }

        BTablas obTran = new BTablas();
        BTransaccion obTransaccion = new BTransaccion();

        public static Boolean Actualiza;


        DataTable dtVALE = new DataTable();
        string SQL = "";

        public decimal nroVale = 0;


        private void Frm_Aprobacion_Firma_Electronica_Detalle_Load(object sender, EventArgs e)
        {           
            dgvDetReq.GridColor = Color.Red;
            SQL = "SELECT A13NSA,A13COD,MPMDES,M.T01AL1  AS UNID,A13CAD,A13FVS,J.ODTDES,J.T01AL1,NOMEMP FROM " + Program.LibreLALMINGB + ".ALI013UTIL LEFT OUTER JOIN " +
                  " " + Program.LibreLALMINGB + ".ALMMMAP ON A13COD=MPMCOD LEFT OUTER JOIN " +
                  " " + Program.LibreLALMINGB + ".ALI011UTIL ON A13NSA=A11NSA LEFT OUTER JOIN " +
                  " (SELECT ODTCOD,ODTDES,T01AL1 FROM " + Program.LibreLALMINGB + ".AIODET LEFT JOIN " + Program.LibreLUGTF + ".UGT01 ON (DIGITS(ODTDPT) = T01ESP AND T01IDT='CCT')) AS J ON A11OTR=J.ODTCOD " +
                  " LEFT OUTER JOIN " +
                  " (SELECT T01ESP,T01AL1,T01AL2,T01NU2 FROM " + Program.LibreLUGTF + ".UGT01 WHERE T01IDT='UND' AND T01NU2=1) AS M ON SUBSTR(DIGITS(MPMUNI),2,2)=M.T01ESP " +
                  " LEFT OUTER JOIN " +
                  " " + Program.LibreLALMINGB + ".ALIUSERS ON A11UGE=CODUSE " +
                  " WHERE A13NVS=" + nroVale;


            dtVALE = obTran.getSELECTLIBRE(SQL);
            dgvDetReq.DataSource = dtVALE;

            dgvDetReq.Columns["A13NSA"].Visible = false;
            dgvDetReq.Columns["A13FVS"].Visible = false;
            dgvDetReq.Columns["ODTDES"].Visible = false;
            dgvDetReq.Columns["T01AL1"].Visible = false;
            dgvDetReq.Columns["NOMEMP"].Visible = false;

            dgvDetReq.Columns["A13COD"].DisplayIndex = 0;
            dgvDetReq.Columns["MPMDES"].DisplayIndex = 1;            
            dgvDetReq.Columns["A13CAD"].DisplayIndex = 2;
            dgvDetReq.Columns["UNID"].DisplayIndex = 3;

            dgvDetReq.Columns["A13COD"].HeaderText = "Codigo";
            dgvDetReq.Columns["MPMDES"].HeaderText = "Descripción";
            dgvDetReq.Columns["A13CAD"].HeaderText = "Cantidad";
            dgvDetReq.Columns["UNID"].HeaderText = "Medida";

            dgvDetReq.Columns["A13COD"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["MPMDES"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["A13CAD"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["UNID"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDetReq.Columns["A13COD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["MPMDES"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDetReq.Columns["A13CAD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetReq.Columns["UNID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDetReq.Columns["A13COD"].Width = 120;
            dgvDetReq.Columns["MPMDES"].Width = 350;
            dgvDetReq.Columns["A13CAD"].Width = 120;
            dgvDetReq.Columns["UNID"].Width = 150;


            txtDpto.Text = dtVALE.Rows[0]["T01AL1"].ToString().Trim();
            txtDescripcionDPTO.Text = dtVALE.Rows[0]["ODTDES"].ToString().Trim();
            txtSolicitante.Text = dtVALE.Rows[0]["NOMEMP"].ToString().Trim();
            txtNroVale.Text = Convert.ToString(nroVale);
            txtReq.Text = dtVALE.Rows[0]["A13NSA"].ToString().Trim();
            string fecha= dtVALE.Rows[0]["A13FVS"].ToString().Trim();
            txtFecha.Text = fecha.Substring(6, 2) + "/" + fecha.Substring(4, 2) + "/" + fecha.Substring(0, 4);

            txtCodigo.CharacterCasing = CharacterCasing.Upper;
            txtPwd.CharacterCasing = CharacterCasing.Upper;

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtPwd.Text = "";
            panel1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {            
            panel1.Visible = false;
        }
        DataTable dtUser = new DataTable();
        private void button2_Click(object sender, EventArgs e)
        {            
            if (MessageBox.Show("Desea Recepcionar el Vale Req.", "Alm.Ing", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                obTran = new BTablas();
                dtUser = obTran.getSELECTLIBRE("SELECT CODUSE,CODPWD,NOMEMP FROM " + Program.LibreLALMINGB + ".ALIUSERS WHERE CODUSE='" + txtCodigo.Text.Trim() + "' AND CODPWD='" + txtPwd.Text.Trim() + "'");
                if (dtUser.Rows.Count > 0)
                {
                    obTransaccion = new BTransaccion();
                    int i = obTransaccion.BUpdateSQL("UPDATE " + Program.LibreLALMINGB + ".ALI013UTIL SET A13EST='R',A13URE='" + dtUser.Rows[0]["CODUSE"].ToString() + "' WHERE A13NVS=" + nroVale + "");
                    MessageBox.Show("Actualizado correctamente", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Transaccion.Frm_Aprobacion_Firma_Electronica.Actualiza = true;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta o Usuario no existe", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodigo.Text = "";
                    txtPwd.Text = "";
                }


            }
        }
    }
}
