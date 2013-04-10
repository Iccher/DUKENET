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

namespace Logistica.Ingenieria.Presentacion.Consultas
{
    public partial class Frm_Fechas : Form
    {
        public Frm_Fechas()
        {
            InitializeComponent();
        }

        public DateTimePicker dt1 = new DateTimePicker();
        public DateTimePicker dt2 = new DateTimePicker();
        BTablas objBusTab = new BTablas();
        TControlVB oUtils = new TControlVB();
        DataView dv1 = new DataView();

   
        private void Frm_Fechas_Load(object sender, EventArgs e)
        {
            dgvValesIng.GridColor = Color.Red;
            Grilla();            
        }

        void Grilla()
        {

            cboBusqueda.Items.Add("Nro.Vale");
            cboBusqueda.Items.Add("Nom.Autorizacion");
            cboBusqueda.Items.Add("Nom.Solicitante");
            cboBusqueda.Items.Add("Cod.Area");
            cboBusqueda.Items.Add("Desc. Area");


            DateTime mes1 = dt1.Value;
            DateTime mes2 = dt2.Value;

            objBusTab = new BTablas();

            Program.dtValesIng = objBusTab.getArmado(Program.dtEmpleados, Program.dtArea, mes1, mes2);
            
            dv1 = new DataView(Program.dtValesIng);

            dgvValesIng.DataSource = dv1;            


            dgvValesIng.Columns["CODAUTORIZA"].DisplayIndex = 1;
            dgvValesIng.Columns["CODAUTORIZA"].Visible = false;
            dgvValesIng.Columns["CODSOLIC"].DisplayIndex = 3;
            dgvValesIng.Columns["CODSOLIC"].Visible = false;

            dgvValesIng.Columns["VALE"].DisplayIndex = 0;            
            dgvValesIng.Columns["AUTORIZA"].DisplayIndex = 2;            
            dgvValesIng.Columns["SOLIC"].DisplayIndex = 4;
            dgvValesIng.Columns["CODAREA"].DisplayIndex = 5;
            dgvValesIng.Columns["AREA"].DisplayIndex = 6;


            dgvValesIng.Columns["VALE"].HeaderText = "Vale";
            dgvValesIng.Columns["AUTORIZA"].HeaderText = "Usu.Autoriza";
            dgvValesIng.Columns["SOLIC"].HeaderText = "Usu.Solicitante";
            dgvValesIng.Columns["CODAREA"].HeaderText = "Cod.Area";
            dgvValesIng.Columns["AREA"].HeaderText = "Area";

            dgvValesIng.Columns["VALE"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["AUTORIZA"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["SOLIC"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["CODAREA"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["AREA"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvValesIng.Columns["VALE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["AUTORIZA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvValesIng.Columns["SOLIC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvValesIng.Columns["CODAREA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["AREA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvValesIng.Columns["VALE"].Width = 100;
            dgvValesIng.Columns["AUTORIZA"].Width = 250;
            dgvValesIng.Columns["SOLIC"].Width = 250;
            dgvValesIng.Columns["CODAREA"].Width = 100;
            dgvValesIng.Columns["AREA"].Width = 250;
        }

        private void cboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboBusqueda.SelectedIndex)
            {
                case 0:
                    //dv1 = new DataView(Program.dtValesIng, "", "VALE ASC", DataViewRowState.OriginalRows);
                    //MessageBox.Show(Convert.ToString(dv1.Count));
                    //dgvValesIng.DataSource = dv1;
                    dv1 = new DataView(Program.dtValesIng);
                    dv1.Sort = "VALE ASC";
                    dgvValesIng.DataSource = dv1;
                    dgvValesIng.Columns["VALE"].DisplayIndex = 0;
                    dgvValesIng.Columns["AUTORIZA"].DisplayIndex = 2;
                    dgvValesIng.Columns["SOLIC"].DisplayIndex = 4;
                    dgvValesIng.Columns["CODAREA"].DisplayIndex = 5;
                    dgvValesIng.Columns["AREA"].DisplayIndex = 6;
                    break;
                case 1:
                    dv1 = new DataView(Program.dtValesIng);
                    dv1.Sort = "AUTORIZA ASC";
                    dgvValesIng.DataSource = dv1;
                    dgvValesIng.Columns["VALE"].DisplayIndex = 2;
                    dgvValesIng.Columns["AUTORIZA"].DisplayIndex = 0;
                    dgvValesIng.Columns["SOLIC"].DisplayIndex = 4;
                    dgvValesIng.Columns["CODAREA"].DisplayIndex = 5;
                    dgvValesIng.Columns["AREA"].DisplayIndex = 6;
                    break;
                case 2:
                    dv1 = new DataView(Program.dtValesIng);
                    dv1.Sort = "SOLIC ASC";
                    dgvValesIng.DataSource = dv1;
                    dgvValesIng.Columns["VALE"].DisplayIndex = 2;
                    dgvValesIng.Columns["AUTORIZA"].DisplayIndex = 4;
                    dgvValesIng.Columns["SOLIC"].DisplayIndex = 0;
                    dgvValesIng.Columns["CODAREA"].DisplayIndex = 5;
                    dgvValesIng.Columns["AREA"].DisplayIndex = 6;
                    break;
                case 3:
                    dv1 = new DataView(Program.dtValesIng);
                    dv1.Sort = "CODAREA ASC";
                    dgvValesIng.DataSource = dv1;
                    dgvValesIng.Columns["VALE"].DisplayIndex = 2;
                    dgvValesIng.Columns["AUTORIZA"].DisplayIndex = 4;
                    dgvValesIng.Columns["SOLIC"].DisplayIndex = 5;
                    dgvValesIng.Columns["CODAREA"].DisplayIndex = 0;
                    dgvValesIng.Columns["AREA"].DisplayIndex = 6;
                    break;
                case 4:
                    dv1 = new DataView(Program.dtValesIng);
                    dv1.Sort = "AREA ASC";
                    dgvValesIng.DataSource = dv1;
                    dgvValesIng.Columns["VALE"].DisplayIndex = 2;
                    dgvValesIng.Columns["AUTORIZA"].DisplayIndex = 4;
                    dgvValesIng.Columns["SOLIC"].DisplayIndex = 5;
                    dgvValesIng.Columns["CODAREA"].DisplayIndex = 6;
                    dgvValesIng.Columns["AREA"].DisplayIndex = 0;
                    break;
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            oUtils.DataTableToExcel(Program.dtValesIng);
        }

        private void dgvValesIng_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int p = dgvValesIng.CurrentRow.Index;
            Consultas.Frm_Detalle_Fechas frm = new Frm_Detalle_Fechas();
            frm.vMES = dgvValesIng.Rows[p].Cells["VALE"].Value.ToString().Substring(2, 4);
            frm.vVale = Convert.ToDecimal(dgvValesIng.Rows[p].Cells["VALE"].Value);
            frm.vCodAutoriza = dgvValesIng.Rows[p].Cells["CODAUTORIZA"].Value.ToString();
            frm.vAutoriza = dgvValesIng.Rows[p].Cells["AUTORIZA"].Value.ToString();
            frm.vCodSolicita = dgvValesIng.Rows[p].Cells["CODSOLIC"].Value.ToString();
            frm.vSolicita = dgvValesIng.Rows[p].Cells["SOLIC"].Value.ToString();
            frm.vCodArea = dgvValesIng.Rows[p].Cells["CODAREA"].Value.ToString();
            frm.vArea = dgvValesIng.Rows[p].Cells["AREA"].Value.ToString();
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }





    }
}
