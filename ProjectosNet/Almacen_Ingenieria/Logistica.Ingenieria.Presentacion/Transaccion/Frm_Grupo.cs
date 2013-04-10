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
    public partial class Frm_Grupo : Form
    {
        public Frm_Grupo()
        {
            InitializeComponent();
        }

        private void Frm_Grupo_Load(object sender, EventArgs e)
        {
            dgvGrupos.GridColor = Color.Red;
            GRUPO();

            cboBusqueda.SelectedIndex = 1;
            txtBusqueda.Focus();
        }

        DataView dv = new DataView();
        public string vCodigoProd = "";

        public string variableForm = "";
        void GRUPO()
        {
            cboBusqueda.Items.Add("Codigo");
            cboBusqueda.Items.Add("Descripcion");

            dgvGrupos.DataSource = Program.dtGrupos;

            dgvGrupos.Columns["AIGCOD"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvGrupos.Columns["AIGDES"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void cboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboBusqueda.SelectedIndex)
            {
                case 0:
                    dv = new DataView(Program.dtGrupos, "", "AIGCOD ASC", DataViewRowState.OriginalRows);
                    dgvGrupos.DataSource = dv;
                    break;
                case 1:
                    dv = new DataView(Program.dtGrupos, "", "AIGDES ASC", DataViewRowState.OriginalRows);
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
                        dv = new DataView(Program.dtGrupos, "AIGCOD = '" + txtBusqueda.Text.ToString() + "'", "AIGCOD ASC", DataViewRowState.OriginalRows);
                        dgvGrupos.DataSource = dv;
                        break;
                    case 1:
                        dv = new DataView(Program.dtGrupos, "AIGDES like '%" + txtBusqueda.Text.ToString() + "%'", "AIGDES ASC", DataViewRowState.OriginalRows);
                        dgvGrupos.DataSource = dv;
                        break;
                }
            }
            catch
            {
                dv = new DataView(Program.dtGrupos, "", "AIGCOD ASC", DataViewRowState.OriginalRows);
                dgvGrupos.DataSource = dv;
            }
        }

        string cod, des = "";
        private void dgvGrupos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                cod = dgvGrupos.Rows[dgvGrupos.CurrentCell.RowIndex].Cells[0].Value.ToString();
                des = dgvGrupos.Rows[dgvGrupos.CurrentCell.RowIndex].Cells[1].Value.ToString();
                this.Cursor = Cursors.WaitCursor;
                Frm_SubGrupo frm1 = new Frm_SubGrupo();
                frm1.vVarForm = variableForm;
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

        private void Frm_Grupo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }


    }
}
