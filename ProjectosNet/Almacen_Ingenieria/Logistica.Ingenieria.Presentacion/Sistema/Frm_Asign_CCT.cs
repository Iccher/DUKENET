using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Logistica.Ingenieria.Bussiness;
using Logistica.Ingenieria.Utils;
using Logistica.Ingenieria.UtilsC;

namespace Logistica.Ingenieria.Presentacion.Sistema
{
    public partial class Frm_Asign_CCT : Form
    {
        public Frm_Asign_CCT()
        {
            InitializeComponent();
        }

        BTablas oTablas = new BTablas();
        DataTable dtAsignaciones = new DataTable();
        DataView dv = new DataView();
        string SQL = "";
        private void Frm_Asign_CCT_Load(object sender, EventArgs e)
        {
            dgvAsignacion.GridColor = Color.Red;
            oTablas = new BTablas();
            SQL = "SELECT IDOCOD,TRANOM,DATCVE,DATDES,IDOARE,T01AL1 FROM LALMINGB.WEBING80 LEFT OUTER JOIN " +
                    " ADAMPERUV2.V_TRABAJ ON (IDOCOD=TRIM(TRACVE)) LEFT OUTER JOIN " +
                    " LUGTF.UGT01 ON (T01IDT='CCT' AND IDOARE=T01ESP)"; 
            dtAsignaciones = oTablas.getSELECTLIBRE(SQL);
            dgvAsignacion.DataSource = dtAsignaciones;

        }


        void RolearGilla()
        {
            try
            {
                int p = dgvAsignacion.CurrentRow.Index;
                lblcod1.Text = dgvAsignacion.Rows[p].Cells["IDOCOD"].Value.ToString();
                lblnom1.Text = dgvAsignacion.Rows[p].Cells["TRANOM"].Value.ToString();

                lblcod2.Text = dgvAsignacion.Rows[p].Cells["DATCVE"].Value.ToString();
                lblnom2.Text = dgvAsignacion.Rows[p].Cells["DATDES"].Value.ToString();

                lblcod3.Text = dgvAsignacion.Rows[p].Cells["IDOARE"].Value.ToString();
                lblnom3.Text = dgvAsignacion.Rows[p].Cells["T01AL1"].Value.ToString();
               
            }
            catch { }
        }

        private void dgvAsignacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RolearGilla();
        }

        private void dgvAsignacion_SelectionChanged(object sender, EventArgs e)
        {
            RolearGilla();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Frm_Busqueda frm = new Frm_Busqueda();
            //OT = Orden de Trabajo
            frm.Busqueda = "CCT";
            frm.ShowDialog();
            lblcod3.Text = frm.vCentroCosto.Trim();
            lblnom3.Text = frm.vDescriCentroCosto.Trim();
            this.Cursor = Cursors.Default;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    dv = new DataView(dtAsignaciones, "", "IDOCOD ASC", DataViewRowState.OriginalRows);
                    dgvAsignacion.DataSource = dv;
                    break;
                case 1:
                    dv = new DataView(dtAsignaciones, "", "TRANOM ASC", DataViewRowState.OriginalRows);
                    dgvAsignacion.DataSource = dv;
                    break;
            }                
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                switch (comboBox1.SelectedIndex)
                {
                    case 0:
                        dv = new DataView(dtAsignaciones, "IDOCOD = '" + textBox1.Text.Trim() + "'", "IDOCOD ASC", DataViewRowState.OriginalRows);
                        dgvAsignacion.DataSource = dv;
                        break;
                    case 1:
                        dv = new DataView(dtAsignaciones, "TRANOM like '%" + textBox1.Text.Trim() + "%'", "TRANOM ASC", DataViewRowState.OriginalRows);
                        dgvAsignacion.DataSource = dv;
                        break;
                }
            }
            catch
            {
                dv = new DataView(dtAsignaciones, "", "IDOCOD ASC", DataViewRowState.OriginalRows);
                dgvAsignacion.DataSource = dv;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oTablas = new BTablas();
            int i = oTablas.BUpdateLIBRE("UPDATE LALMINGB.WEBING80 SET IDOARE='" + lblcod3.Text.Trim() + "' WHERE IDOCOD='" + lblcod1.Text.Trim() + "'");
            MessageBox.Show("Actualizacion Correcta", "Alm.Utiles", MessageBoxButtons.OK, MessageBoxIcon.Information);
            oTablas = new BTablas();
            SQL = "SELECT IDOCOD,TRANOM,DATCVE,DATDES,IDOARE,T01AL1 FROM LALMINGB.WEBING80 LEFT OUTER JOIN " +
                    " ADAMPERUV2.V_TRABAJ ON (IDOCOD=TRIM(TRACVE)) LEFT OUTER JOIN " +
                    " LUGTF.UGT01 ON (T01IDT='CCT' AND IDOARE=T01ESP)";
            dtAsignaciones = oTablas.getSELECTLIBRE(SQL);
            dgvAsignacion.DataSource = dtAsignaciones;

        }


    }
}
