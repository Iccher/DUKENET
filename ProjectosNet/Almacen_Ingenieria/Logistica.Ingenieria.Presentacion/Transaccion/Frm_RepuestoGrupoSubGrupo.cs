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
    public partial class Frm_RepuestoGrupoSubGrupo : Form
    {
        public Frm_RepuestoGrupoSubGrupo()
        {
            InitializeComponent();
        }

        public string vCod, vDes = "";
        public string vCod1, vDes1 = "";

        BTablas objBTablas = new BTablas();

        DataView dv = new DataView();
        DataTable dtRepuestos = new DataTable();
        DataTable dtAplicabi = new DataTable();
        DataTable dtRepAplicab = new DataTable();

        public string vCodigoProd = "";

        private void Frm_RepuestoGrupoSubGrupo_Load(object sender, EventArgs e)
        {
            lblBusqueda.Text = vCod1.Trim() + " - " + vDes1.Trim() + "           " + vCod.Trim() + " - " + vDes.Trim();
            objBTablas = new BTablas();
            dtRepuestos = objBTablas.getCargaRepuestosxSubGRUPOS(vCod);
            objBTablas = new BTablas();
            dtAplicabi = objBTablas.getCargaAPLICABILIDADxSubGRUPO(vCod);           

            dgvProductos.GridColor = Color.Red;
            Grilla();

            cboBusqueda.SelectedIndex = 1;
            txtBusqueda.Focus();
        }

        void Grilla()
        {
            objBTablas = new BTablas();
            dtRepAplicab = objBTablas.getRepuestosAplicabilidad(dtRepuestos, dtAplicabi);
            dgvProductos.DataSource = dtRepAplicab;


            cboBusqueda.Items.Add("Codigo");
            cboBusqueda.Items.Add("Descripción");
            cboBusqueda.Items.Add("Parte");
            cboBusqueda.Items.Add("Aplicabilidad");

            

            dgvProductos.Columns["Codigo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["Descripcion_Tarde"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["N_Parte"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["Unid_Med"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["Ubicacion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["Cod_Aplicabilidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["Des_Aplicabilidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["Des_Mecanicos"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void cboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboBusqueda.SelectedIndex)
            {
                case 0:
                    dv = new DataView(dtRepAplicab);
                    dv.Sort = "Codigo ASC";
                    dgvProductos.DataSource = dv;
                    break;
                case 1:
                    dv = new DataView(dtRepAplicab);
                    dv.Sort = "Descripcion ASC,Descripcion_Tarde ASC,Des_Mecanicos ASC";
                    dgvProductos.DataSource = dv;
                    break;
                case 2:
                    dv = new DataView(dtRepAplicab);
                    dv.Sort = "N_Parte ASC";
                    dgvProductos.DataSource = dv;
                    break;
                case 3:
                    dv = new DataView(dtRepAplicab);
                    dv.Sort = "Des_Aplicabilidad ASC";
                    dgvProductos.DataSource = dv;
                    break;
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            dgvProductos.GridColor = Color.Red;
            switch (cboBusqueda.SelectedIndex)
            {                    
                case 0:
                    dv = new DataView(dtRepAplicab);
                    dv.Sort = "Codigo ASC";
                    dv.RowFilter = "Codigo like '%" + txtBusqueda.Text.ToString() + "%'";
                    dgvProductos.DataSource = dv;
                    break;
                case 1:
                    dv = new DataView(dtRepAplicab);
                    dv.Sort = "Descripcion ASC,Descripcion_Tarde ASC";
                    dv.RowFilter = "Descripcion like '%" + txtBusqueda.Text.ToString() + "%' OR Descripcion_Tarde like '%" + txtBusqueda.Text.ToString() + "%' OR Des_Mecanicos like '%" + txtBusqueda.Text.ToString() + "%'";
                    dgvProductos.DataSource = dv;
                    break;
                case 2:
                    dv = new DataView(dtRepAplicab);
                    dv.Sort = "N_Parte ASC";
                    dv.RowFilter = "N_Parte like '%" + txtBusqueda.Text.ToString() + "%'";
                    dgvProductos.DataSource = dv;
                    break;
                case 3:
                    dv = new DataView(dtRepAplicab);
                    dv.Sort = "Des_Aplicabilidad ASC";
                    dv.RowFilter = "Des_Aplicabilidad like '%" + txtBusqueda.Text.ToString() + "%'";
                    dgvProductos.DataSource = dv;
                    break;


            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int p = dgvProductos.CurrentRow.Index;
                string cod = dgvProductos.Rows[p].Cells["Codigo"].Value.ToString();
                string nom = dgvProductos.Rows[p].Cells["Descripcion"].Value.ToString();
                Transaccion.Frm_FotoArt frm = new Logistica.Ingenieria.Presentacion.Transaccion.Frm_FotoArt();
                frm.codProd = cod;
                frm.nomprod = nom;
                frm.ShowDialog();
            }
            if (e.ColumnIndex == 1)
            {
                int p = dgvProductos.CurrentRow.Index;
                string cod = dgvProductos.Rows[p].Cells["Codigo"].Value.ToString();
                string nom = dgvProductos.Rows[p].Cells["Descripcion"].Value.ToString();
                Transaccion.Frm_Deta_Mecanico frm = new Logistica.Ingenieria.Presentacion.Transaccion.Frm_Deta_Mecanico();
                frm.codProd = cod;
                frm.nomProd = nom;
                frm.ShowDialog();
                if (frm.flag == 1)
                {
                    this.Cursor = Cursors.WaitCursor;
                    objBTablas = new BTablas();
                    dtRepuestos = objBTablas.getCargaRepuestosxSubGRUPOS(vCod);
                    objBTablas = new BTablas();
                    dtAplicabi = objBTablas.getCargaAPLICABILIDADxSubGRUPO(vCod);

                    cboBusqueda.Items.Clear();
                    
                    dgvProductos.GridColor = Color.Red;
                    Grilla();
                    cboBusqueda.SelectedIndex = 1;
                    txtBusqueda.Focus();
                    this.Cursor = Cursors.Default;
                }
                
            }
            if (e.ColumnIndex == 2)
            {
                try
                {
                    int p = dgvProductos.CurrentRow.Index;
                    vCodigoProd = dgvProductos.Rows[p].Cells["Codigo"].Value.ToString();
                    this.Close();
                }
                catch { }
            }



        }

        private void Frm_RepuestoGrupoSubGrupo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        

    }
}
