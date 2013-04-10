using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Logistica.Ingenieria.Bussiness;
using System.Collections;
using System.Diagnostics;



namespace Logistica.Ingenieria.Presentacion.Consultas
{
    public partial class Frm_RepuestoXMaquina : Form
    {
        public Frm_RepuestoXMaquina()
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

        public List<String> objLIST = new List<string>();

        public static Boolean Actualiza = false;



        private void Frm_RepuestoXMaquina_Load(object sender, EventArgs e)
        {
            lblBusqueda.Text = vCod1.Trim() + " - " + vDes1.Trim() + "           " + vCod.Trim() + " - " + vDes.Trim();
            objBTablas = new BTablas();
            dtRepuestos = objBTablas.getCargaRepuestosxSubGRUPOS(vCod);
            objBTablas = new BTablas();
            dtAplicabi = objBTablas.getCargaAPLICABILIDADxSubGRUPO(vCod);

            dgvProductos.GridColor = Color.Red;
            dgvProductos.AutoGenerateColumns = false;
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

            dgvProductos.Columns["Codigo"].ReadOnly = true;
            dgvProductos.Columns["Descripcion"].ReadOnly = true;
            dgvProductos.Columns["Descripcion_Tarde"].ReadOnly = true;
            dgvProductos.Columns["N_Parte"].ReadOnly = true;
            dgvProductos.Columns["Unid_Med"].ReadOnly = true;
            dgvProductos.Columns["Precio"].ReadOnly = true;
            dgvProductos.Columns["Cod_Aplicabilidad"].ReadOnly = true;
            dgvProductos.Columns["Des_Aplicabilidad"].ReadOnly = true;
            dgvProductos.Columns["Des_Mecanicos"].ReadOnly = true;

            dgvProductos.Columns["Codigo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["Descripcion_Tarde"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["N_Parte"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["Unid_Med"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["Precio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
                    chekeaSELE();
                    break;
                case 1:
                    dv = new DataView(dtRepAplicab);
                    dv.Sort = "Descripcion ASC,Descripcion_Tarde ASC,Des_Mecanicos ASC";
                    dgvProductos.DataSource = dv;
                    chekeaSELE();
                    break;
                case 2:
                    dv = new DataView(dtRepAplicab);
                    dv.Sort = "N_Parte ASC";
                    dgvProductos.DataSource = dv;
                    chekeaSELE();
                    break;
                case 3:
                    dv = new DataView(dtRepAplicab);
                    dv.Sort = "Des_Aplicabilidad ASC";
                    dgvProductos.DataSource = dv;
                    chekeaSELE();
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
                    chekeaSELE();
                    break;
                case 1:
                    dv = new DataView(dtRepAplicab);
                    dv.Sort = "Descripcion ASC,Descripcion_Tarde ASC";
                    dv.RowFilter = "Descripcion like '%" + txtBusqueda.Text.ToString() + "%' OR Descripcion_Tarde like '%" + txtBusqueda.Text.ToString() + "%' OR Des_Mecanicos like '%" + txtBusqueda.Text.ToString() + "%'";
                    dgvProductos.DataSource = dv;
                    chekeaSELE();
                    break;
                case 2:
                    dv = new DataView(dtRepAplicab);
                    dv.Sort = "N_Parte ASC";
                    dv.RowFilter = "N_Parte like '%" + txtBusqueda.Text.ToString() + "%'";
                    dgvProductos.DataSource = dv;
                    chekeaSELE();
                    break;
                case 3:
                    dv = new DataView(dtRepAplicab);
                    dv.Sort = "Des_Aplicabilidad ASC";
                    dv.RowFilter = "Des_Aplicabilidad like '%" + txtBusqueda.Text.ToString() + "%'";
                    dgvProductos.DataSource = dv;
                    chekeaSELE();
                    break;


            }
        }

        private void Frm_RepuestoXMaquina_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            CargarEXCEL();
        }

        void CargarEXCEL()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ArrayList titulos = new ArrayList();
                DataTable datosTabla = new DataTable();
                //Especificar rutal del archivo con extencion de excel.
                OtrosFormatos OF = new OtrosFormatos(Application.StartupPath + @"\\test.xls");

                //obtenemos los titulos del grid y creamos las columnas de la tabla
                foreach (DataGridViewColumn item in dgvProductos.Columns)
                {
                    titulos.Add(item.HeaderText);
                    datosTabla.Columns.Add();
                }
                //se crean los renglones de la tabla
                foreach (DataGridViewRow item in dgvProductos.Rows)
                {
                    DataRow rowx = datosTabla.NewRow();
                    datosTabla.Rows.Add(rowx);
                }
                //se pasan los datos del dataGridView a la tabla
                foreach (DataGridViewColumn item in dgvProductos.Columns)
                {
                    foreach (DataGridViewRow itemx in dgvProductos.Rows)
                    {
                        datosTabla.Rows[itemx.Index][item.Index] = dgvProductos[item.Index, itemx.Index].Value;
                    }
                }
                OF.Export(titulos, datosTabla);
                Process.Start(OF.xpath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;


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
                Consultas.Frm_Detalle_Adicional frm = new Frm_Detalle_Adicional();
                frm.codProd = cod;
                frm.nomprod = nom;
                frm.parte = dgvProductos.Rows[p].Cells["N_Parte"].Value.ToString();
                frm.aplicabilidad = dgvProductos.Rows[p].Cells["Des_Aplicabilidad"].Value.ToString();
                frm.precio = dgvProductos.Rows[p].Cells["Precio"].Value.ToString();
                frm.ShowDialog();
            }

            if (dgvProductos.Columns[e.ColumnIndex].Name == "Seleccion")
            {
                DataGridViewRow row = dgvProductos.Rows[e.RowIndex];
                DataGridViewCheckBoxCell cellSelecion = row.Cells["Seleccion"] as DataGridViewCheckBoxCell;
                if (Convert.ToBoolean(cellSelecion.Value))
                {
                    //string mensaje = string.Format(row.Cells["Codigo"].Value.ToString());
                    //MessageBox.Show(mensaje, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    objLIST.Add(row.Cells["Codigo"].Value.ToString());
                }
                else
                {
                    objLIST.Remove(row.Cells["Codigo"].Value.ToString());
                }
            }
        }

        private void dgvProductos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvProductos.IsCurrentCellDirty)
            {
                dgvProductos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {          
            if (objLIST.Count > 0)
            {
                Consultas.Frm_Detalle_Rep_Obsoletos_Sele frm = new Frm_Detalle_Rep_Obsoletos_Sele();
                frm.dtRepDetalle = dtRepAplicab;
                frm.objLISTDet = new List<string>();
                frm.objLISTDet = objLIST;
                frm.ShowDialog();
                if (objLIST.Count > 0)
                {
                    dv = new DataView(dtRepAplicab);
                    dv.Sort = "Descripcion ASC,Descripcion_Tarde ASC,Des_Mecanicos ASC";
                    dgvProductos.DataSource = dv;
                    chekeaSELE();
                }
                else
                {
                    dv = new DataView(dtRepAplicab);
                    dv.Sort = "Descripcion ASC,Descripcion_Tarde ASC,Des_Mecanicos ASC";
                    dgvProductos.DataSource = dv;
                }
            }

        }


        public void chekeaSELE()
        {
            
            for (int i = 0; i <= dgvProductos.Rows.Count - 1; i++)
            {
                string codEvalua = dgvProductos["Codigo", i].Value.ToString();
                bool exists = objLIST.Contains(codEvalua);
                if (exists == true)
                {
                    DataGridViewRow row = dgvProductos.Rows[i];
                    DataGridViewCheckBoxCell cellSelecion = row.Cells["Seleccion"] as DataGridViewCheckBoxCell;
                    cellSelecion.Value = true;
                }
                
            }
        }

        int Contador = 1;
        private void button3_Click(object sender, EventArgs e)
        {
            if (Contador == 1)
            {
                objLIST.Clear();
                for (int i = 0; i <= dgvProductos.Rows.Count - 1; i++)
                {
                    DataGridViewRow row = dgvProductos.Rows[i];
                    DataGridViewCheckBoxCell cellSelecion = row.Cells["Seleccion"] as DataGridViewCheckBoxCell;
                    cellSelecion.Value = true;
                    objLIST.Add(row.Cells["Codigo"].Value.ToString());
                }
                Contador = 2;
            }
            else
            {
                objLIST.Clear();
                for (int i = 0; i <= dgvProductos.Rows.Count - 1; i++)
                {
                    DataGridViewRow row = dgvProductos.Rows[i];
                    DataGridViewCheckBoxCell cellSelecion = row.Cells["Seleccion"] as DataGridViewCheckBoxCell;
                    cellSelecion.Value = false;
                }
                Contador = 1;
            }
        }

        private void Frm_RepuestoXMaquina_Activated(object sender, EventArgs e)
        {
            if (Actualiza == true)
            {
                this.Cursor = Cursors.WaitCursor;
                objBTablas = new BTablas();
                dtRepuestos = objBTablas.getCargaRepuestosxSubGRUPOS(vCod);
                objBTablas = new BTablas();
                dtAplicabi = objBTablas.getCargaAPLICABILIDADxSubGRUPO(vCod);
                Grilla();
                Actualiza = false;
                this.Cursor = Cursors.Default;
            }
        }

    }
}
