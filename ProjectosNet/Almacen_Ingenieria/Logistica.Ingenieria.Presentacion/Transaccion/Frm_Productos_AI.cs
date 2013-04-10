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
    public partial class Frm_Productos_AI : Form
    {
        public Frm_Productos_AI()
        {
            InitializeComponent();
        }

        public string vCodigoProd = "";
        public string vDescripcion = "";
        public decimal vStockC = 0;
        public decimal vStockD = 0;
        public string vUndMed = "";
        public decimal vPrecioSoles = 0;
        public decimal vPrecioDolares = 0;
        public string vUbicacion = "";

        public decimal vProcedencia = 0;
        public decimal vCtaAlmacen = 0;
        public decimal vCuentaCargo = 0;


        public string TIPOCONSULTA = "";


        BTablas ObjBus = new BTablas();
        DataTable dtProduc = new DataTable();
        DataView dv = new DataView();

        private void Frm_Productos_AI_Load(object sender, EventArgs e)
        {
            dgvProductos.GridColor = Color.Red;
            Productos();

            cboBusqueda.SelectedIndex = 1;
            txtBusqueda.Focus();
        }

        void Productos()
        {
            cboBusqueda.Items.Add("Codigo");
            cboBusqueda.Items.Add("Descripcion");
            ObjBus = new BTablas();

            if (TIPOCONSULTA == "")
            {
                dtProduc = ObjBus.getProductosRequerimiento(Program.Cuentas);
            }
            else
            {
                dtProduc = ObjBus.getProductosVALESSALIDA(Convert.ToDecimal(Program.codplanillaUSU.ToString()));
            }

            dgvProductos.DataSource = dtProduc;
            dgvProductos.Columns["MPMSCO"].Visible = false;
            dgvProductos.Columns["MPMCPR"].Visible = false;
            dgvProductos.Columns["MPMCDO"].Visible = false;
            dgvProductos.Columns["MPMUBI"].Visible = false;
            dgvProductos.Columns["MPMCTA"].Visible = false;
            dgvProductos.Columns["MPMCCA"].Visible = false;
            dgvProductos.Columns["MPMPRO"].Visible = false;

            dgvProductos.Columns["Detalle"].DisplayIndex = 4;

            dgvProductos.Columns["MPMCOD"].DisplayIndex = 0;
            dgvProductos.Columns["MPMDES"].DisplayIndex = 1;
            dgvProductos.Columns["T01AL1"].DisplayIndex = 3;
            dgvProductos.Columns["MPMSDI"].DisplayIndex = 2;            

            dgvProductos.Columns["MPMCOD"].HeaderText = "Codigo";
            dgvProductos.Columns["MPMDES"].HeaderText = "Descripcion";
            dgvProductos.Columns["T01AL1"].HeaderText = "Und.Med";
            dgvProductos.Columns["MPMSDI"].HeaderText = "Stock";

            dgvProductos.Columns["MPMCOD"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["MPMDES"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["T01AL1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["MPMSDI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvProductos.Columns["MPMCOD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["MPMDES"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvProductos.Columns["T01AL1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvProductos.Columns["MPMSDI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvProductos.Columns["MPMCOD"].Width = 100;
            dgvProductos.Columns["MPMDES"].Width = 300;
            dgvProductos.Columns["T01AL1"].Width = 100;
            dgvProductos.Columns["MPMSDI"].Width = 80;
        }

        private void cboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboBusqueda.SelectedIndex)
            {
                case 0:
                    dv = new DataView(dtProduc, "", "MPMCOD ASC", DataViewRowState.OriginalRows);
                    dgvProductos.DataSource = dv;
                    break;
                case 1:
                    dv = new DataView(dtProduc, "", "MPMDES ASC", DataViewRowState.OriginalRows);
                    dgvProductos.DataSource = dv;
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
                        dv = new DataView(dtProduc, "MPMCOD like '" + txtBusqueda.Text.ToString() + "%'", "MPMCOD ASC", DataViewRowState.OriginalRows);
                        dgvProductos.DataSource = dv;
                        break;
                    case 1:
                        dv = new DataView(dtProduc, "MPMDES like '%" + txtBusqueda.Text.ToString() + "%'", "MPMDES ASC", DataViewRowState.OriginalRows);
                        dgvProductos.DataSource = dv;
                        break;
                }
            }
            catch { }
        }

        private void dgvProductos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int p = dgvProductos.CurrentRow.Index;

                vCodigoProd = dgvProductos.Rows[p].Cells["MPMCOD"].Value.ToString();
                vDescripcion = dgvProductos.Rows[p].Cells["MPMDES"].Value.ToString();
                vStockC = Convert.ToDecimal(dgvProductos.Rows[p].Cells["MPMSCO"].Value);
                vStockD = Convert.ToDecimal(dgvProductos.Rows[p].Cells["MPMSDI"].Value.ToString());
                vUndMed = dgvProductos.Rows[p].Cells["T01AL1"].Value.ToString();
                vPrecioSoles = Convert.ToDecimal(dgvProductos.Rows[p].Cells["MPMCPR"].Value.ToString());
                vPrecioDolares = Convert.ToDecimal(dgvProductos.Rows[p].Cells["MPMCDO"].Value.ToString());
                vUbicacion = dgvProductos.Rows[p].Cells["MPMUBI"].Value.ToString();

                vCtaAlmacen = Convert.ToDecimal(dgvProductos.Rows[p].Cells["MPMCTA"].Value.ToString());
                vCuentaCargo = Convert.ToDecimal(dgvProductos.Rows[p].Cells["MPMCCA"].Value.ToString());
                vProcedencia = Convert.ToDecimal(dgvProductos.Rows[p].Cells["MPMPRO"].Value.ToString());


                this.Close();
            }
            catch { }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int p = dgvProductos.CurrentRow.Index;
                string cod = dgvProductos.Rows[p].Cells["MPMCOD"].Value.ToString();
                string nom = dgvProductos.Rows[p].Cells["MPMDES"].Value.ToString();
                Transaccion.Frm_FotoArt frm = new Logistica.Ingenieria.Presentacion.Transaccion.Frm_FotoArt();
                frm.codProd = cod;
                frm.nomprod = nom;
                frm.ShowDialog();
            }
        }

        private void Frm_Productos_AI_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
