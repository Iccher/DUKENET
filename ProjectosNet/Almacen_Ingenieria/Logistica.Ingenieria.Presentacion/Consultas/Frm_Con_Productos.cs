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


namespace Logistica.Ingenieria.Presentacion.Consultas
{
    public partial class Frm_Con_Productos : Form
    {
        public Frm_Con_Productos()
        {
            InitializeComponent();
        }

        BTablas ObjBus = new BTablas();
        DataView dv = new DataView();
        DataTable dtBusqueda = new DataTable();
        BTablas objBusTab = new BTablas();
        TControlVB oUtils = new TControlVB();
        TControlC oUtilsC = new TControlC();

        //string ficheroAnimacion = "..\\..\\Resources\\f.AVI";
        private void Frm_Con_Productos_Load(object sender, EventArgs e)
        {
            //animation.Open(ficheroAnimacion);
            dgvProductos.GridColor = Color.Red;            
            Grilla();            
        }

        void Grilla()
        {
            cboBusqueda.Items.Add("Codigo");
            cboBusqueda.Items.Add("Descripción");
            //animation.Visible = true;
            dtBusqueda = ObjBus.GetConsultaPlantaRPG(Program.Usuario, Program.Password);
            //animation.Visible = false;

            dv = new DataView(dtBusqueda);
            dgvProductos.DataSource = dv;

            dgvProductos.Columns["MIMSTT"].Visible = false;
            dgvProductos.Columns["MIMUID"].Visible = false;
            dgvProductos.Columns["MIMUFE"].Visible = false;
            dgvProductos.Columns["MIMUHM"].Visible = false;
            dgvProductos.Columns["MIMCTA"].Visible = false;
            dgvProductos.Columns["MIMUNI"].Visible = false;

            dgvProductos.Columns["MIMCOD"].DisplayIndex = 0;
	        dgvProductos.Columns["MIMDES"].DisplayIndex = 1;
	        dgvProductos.Columns["MIDEA1"].DisplayIndex = 2;
	        dgvProductos.Columns["MIDEA2"].DisplayIndex = 3;
	        dgvProductos.Columns["MIDEA3"].DisplayIndex = 4;
	        dgvProductos.Columns["MIDEA4"].DisplayIndex = 5;
	        dgvProductos.Columns["MIDEA5"].DisplayIndex = 6;
	        dgvProductos.Columns["MIDEA6"].DisplayIndex = 7;
	        dgvProductos.Columns["MIMCTA"].DisplayIndex = 8;
            dgvProductos.Columns["MIMPRO"].DisplayIndex = 9;
            dgvProductos.Columns["T01AL1"].DisplayIndex = 10;
	        dgvProductos.Columns["MIMSCO"].DisplayIndex = 11;
            dgvProductos.Columns["MIMSDI"].DisplayIndex = 12;

            dgvProductos.Columns["MIMCOD"].HeaderText = "Codigo";
            dgvProductos.Columns["MIMDES"].HeaderText = "Descrip.Almacen";
            dgvProductos.Columns["MIDEA1"].HeaderText = "Descrip.Logistica";
            dgvProductos.Columns["MIDEA2"].HeaderText = "Descrip. 2";
            dgvProductos.Columns["MIDEA3"].HeaderText = "Descrip. 3";
            dgvProductos.Columns["MIDEA4"].HeaderText = "Descrip. 4";
            dgvProductos.Columns["MIDEA5"].HeaderText = "Descrip. 5";
            dgvProductos.Columns["MIDEA6"].HeaderText = "Descrip. 6";            
            dgvProductos.Columns["MIMPRO"].HeaderText = "Procedencia";
            dgvProductos.Columns["T01AL1"].HeaderText = "U.Med.";
            dgvProductos.Columns["MIMSCO"].HeaderText = "Stck.C.";
            dgvProductos.Columns["MIMSDI"].HeaderText = "Stck.D.";

            dgvProductos.Columns["MIMCOD"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["MIMDES"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["MIDEA1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["MIDEA2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["MIDEA3"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["MIDEA4"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["MIDEA5"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["MIDEA6"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter; 
            dgvProductos.Columns["MIMPRO"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["T01AL1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["MIMSCO"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["MIMSDI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvProductos.Columns["MIMCOD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["MIMDES"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvProductos.Columns["MIDEA1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvProductos.Columns["MIDEA2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvProductos.Columns["MIDEA3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvProductos.Columns["MIDEA4"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvProductos.Columns["MIDEA5"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvProductos.Columns["MIDEA6"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvProductos.Columns["MIMPRO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvProductos.Columns["T01AL1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvProductos.Columns["MIMSCO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns["MIMSDI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvProductos.Columns["MIMCOD"].Width = 100;
            dgvProductos.Columns["MIMDES"].Width = 280;
            dgvProductos.Columns["MIDEA1"].Width = 280;
            dgvProductos.Columns["MIDEA2"].Width = 150;
            dgvProductos.Columns["MIDEA3"].Width = 150;
            dgvProductos.Columns["MIDEA4"].Width = 150;
            dgvProductos.Columns["MIDEA5"].Width = 150;
            dgvProductos.Columns["MIDEA6"].Width = 150;
            dgvProductos.Columns["MIMPRO"].Width = 100;
            dgvProductos.Columns["T01AL1"].Width = 100;
            dgvProductos.Columns["MIMSCO"].Width = 80;
            dgvProductos.Columns["MIMSDI"].Width = 80;
        }

        private void cboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboBusqueda.SelectedIndex)
            {
                case 0:
                    dv = new DataView(dtBusqueda, "", "MIMCOD ASC", DataViewRowState.OriginalRows);
                    dgvProductos.DataSource = dv; 
                    break;
                case 1:
                    dv = new DataView(dtBusqueda, "", "MIMDES ASC", DataViewRowState.OriginalRows);
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
                    dv = new DataView(dtBusqueda, "MIMCOD like '" + txtBusqueda.Text.ToString() + "%'", "MIMCOD ASC", DataViewRowState.OriginalRows);
                    dgvProductos.DataSource = dv;
                    break;
                case 1:
                    dv = new DataView(dtBusqueda, "MIMDES like '%" + txtBusqueda.Text.ToString() + "%' OR MIDEA1 like '%" + txtBusqueda.Text.ToString() + "%' OR MIDEA2 like '%" + txtBusqueda.Text.ToString() + "%' OR MIDEA3 like '%" + txtBusqueda.Text.ToString() + "%' OR MIDEA4 like '%" + txtBusqueda.Text.ToString() + "%' OR MIDEA5 like '%" + txtBusqueda.Text.ToString() + "%' OR MIDEA6 like '%" + txtBusqueda.Text.ToString() + "%'", "MIMDES ASC", DataViewRowState.OriginalRows);
                    dgvProductos.DataSource = dv;
                    break;
            }

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            oUtils.DataTableToExcelDATAGRIDVIEW(dgvProductos);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Frm_Requerimiento frm = new Frm_Requerimiento();
            frm.ShowDialog();
            this.Cursor = Cursors.Default;   
        }

    }
}
