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
    public partial class Frm_SubGrupo : Form
    {
        public Frm_SubGrupo()
        {
            InitializeComponent();
        }

        public string vCod, vDes = "";
        public string vCodigoProd = "";


        public string vVarForm = "";

        private void Frm_SubGrupo_Load(object sender, EventArgs e)
        {
            lblBusqueda.Text = vCod.Trim() + " - " + vDes.Trim();
            dgvGrupos.GridColor = Color.Red;
            GRUPO();

            cboBusqueda.SelectedIndex = 1;
            txtBusqueda.Focus();
        }

        BTablas objBTablas = new BTablas();
        DataView dv = new DataView();
        DataTable dtSubGrupos = new DataTable();
        void GRUPO()
        {
            dtSubGrupos = objBTablas.getCargaSubGRUPOSxAREA(Convert.ToDecimal(vCod));
            cboBusqueda.Items.Add("Codigo");
            cboBusqueda.Items.Add("Descripcion");

            dgvGrupos.DataSource = dtSubGrupos;

            dgvGrupos.Columns["AISCOD"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrupos.Columns["AISDES"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void cboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboBusqueda.SelectedIndex)
            {
                case 0:
                    dv = new DataView(dtSubGrupos, "", "AISCOD ASC", DataViewRowState.OriginalRows);
                    dgvGrupos.DataSource = dv;
                    break;
                case 1:
                    dv = new DataView(dtSubGrupos, "", "AISDES ASC", DataViewRowState.OriginalRows);
                    dgvGrupos.DataSource = dv;
                    break;
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            try
            {
                switch (cboBusqueda.SelectedIndex)
                {
                    case 0:
                        dv = new DataView(dtSubGrupos, "AISCOD = '" + txtBusqueda.Text.ToString() + "'", "AISCOD ASC", DataViewRowState.OriginalRows);
                        dgvGrupos.DataSource = dv;
                        break;
                    case 1:
                        dv = new DataView(dtSubGrupos, "AISDES like '%" + txtBusqueda.Text.ToString() + "%'", "AISDES ASC", DataViewRowState.OriginalRows);
                        dgvGrupos.DataSource = dv;
                        break;
                }
            }
            catch
            {
                dv = new DataView(dtSubGrupos, "", "AISCOD ASC", DataViewRowState.OriginalRows);
                dgvGrupos.DataSource = dv;
            }
        }

        string cod, des = "";
        private void dgvGrupos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (vVarForm == "REQUI")
            {
                if (e.ColumnIndex == 0)
                {
                    cod = dgvGrupos.Rows[dgvGrupos.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    des = dgvGrupos.Rows[dgvGrupos.CurrentCell.RowIndex].Cells[1].Value.ToString();
                    this.Cursor = Cursors.WaitCursor;
                    Frm_RepuestoGrupoSubGrupo frm1 = new Frm_RepuestoGrupoSubGrupo();
                    frm1.vCod1 = vCod;
                    frm1.vDes1 = vDes;
                    frm1.vCod = cod;
                    frm1.vDes = des;
                    frm1.ShowDialog();
                    this.Cursor = Cursors.Default;
                    if (frm1.vCodigoProd != "")
                    {
                        vCodigoProd = frm1.vCodigoProd;
                        this.Close();
                    }
                }
            }
            else
            {
                if (e.ColumnIndex == 0)
                {
                    cod = dgvGrupos.Rows[dgvGrupos.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    des = dgvGrupos.Rows[dgvGrupos.CurrentCell.RowIndex].Cells[1].Value.ToString();
                    this.Cursor = Cursors.WaitCursor;
                    Consultas.Frm_RepuestoXMaquina frm1 = new Logistica.Ingenieria.Presentacion.Consultas.Frm_RepuestoXMaquina();
                    frm1.vCod1 = vCod;
                    frm1.vDes1 = vDes;
                    frm1.vCod = cod;
                    frm1.vDes = des;
                    frm1.ShowDialog();
                    this.Cursor = Cursors.Default;
                }

            }
            
        }

        private void Frm_SubGrupo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

    }
}
