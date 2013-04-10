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
    public partial class Frm_Consumos_AI : Form
    {
        public Frm_Consumos_AI()
        {
            InitializeComponent();
        }

        public DateTimePicker dt1 = new DateTimePicker();
        public DateTimePicker dt2 = new DateTimePicker();
        BTablas objBusTab = new BTablas();
        TControlVB oUtils = new TControlVB();
        DataView dv1 = new DataView();

        private void Frm_Consumos_AI_Load(object sender, EventArgs e)
        {
            dgvValesIng.GridColor = Color.Red;

            DateTime mes1 = dt1.Value;
            DateTime mes2 = dt2.Value;
            objBusTab = new BTablas();
            Program.dtValesIng = objBusTab.getConsultaConsumos(Program.dtEmpleados, Program.dtArea, Program.dtCCostos, mes1, mes2);
            dv1 = new DataView(Program.dtValesIng);
            dv1.Sort = "NOMTRAB2 ASC";
            dgvValesIng.DataSource = dv1;

            cboBusqueda.Items.Add("Nro.Vale");
            cboBusqueda.Items.Add("Codigo Prod.");
            cboBusqueda.Items.Add("Descripción Prod.");
            cboBusqueda.Items.Add("Area");
            cboBusqueda.Items.Add("Orden Trabajo");
            cboBusqueda.Items.Add("Solicitante");
            cboBusqueda.Items.Add("Autoriza");


            Grilla(); 
        }

        void Grilla()
        {

            
            //cboBusqueda.Items.Add("Nom.Autorizacion");
            //cboBusqueda.Items.Add("Nom.Solicitante");
            //cboBusqueda.Items.Add("Cod.Area");
            //cboBusqueda.Items.Add("Desc. Area");


              


            dgvValesIng.Columns["MPSCOD"].DisplayIndex = 9;
            dgvValesIng.Columns["MPSNSA"].DisplayIndex = 10;
            dgvValesIng.Columns["MPSARE"].DisplayIndex = 11;
            dgvValesIng.Columns["MPSCOR"].DisplayIndex = 12;
            dgvValesIng.Columns["MPSSOL"].DisplayIndex = 13;
            dgvValesIng.Columns["MPMCCA"].DisplayIndex = 14;
            dgvValesIng.Columns["MPSPRO"].DisplayIndex = 15;
            dgvValesIng.Columns["MPMUNI"].DisplayIndex = 16;
            dgvValesIng.Columns["T01AL1"].DisplayIndex = 17;
            dgvValesIng.Columns["MPMSMX"].DisplayIndex = 18;
            dgvValesIng.Columns["MPMSMN"].DisplayIndex = 19;
            dgvValesIng.Columns["MPMSEM"].DisplayIndex = 20;
            dgvValesIng.Columns["MPMPRE"].DisplayIndex = 21;
            dgvValesIng.Columns["MPMSCO"].DisplayIndex = 22;
            dgvValesIng.Columns["MPMUBI"].DisplayIndex = 23;
            dgvValesIng.Columns["MPSOTR"].DisplayIndex = 24;

            dgvValesIng.Columns["MPSCOD"].Visible = false;
            dgvValesIng.Columns["MPSIMP"].Visible = false;
            dgvValesIng.Columns["MPSARE"].Visible = false;
            dgvValesIng.Columns["MPSCOR"].Visible = false;
            dgvValesIng.Columns["MPSSOL"].Visible = false;
            dgvValesIng.Columns["MPMCCA"].Visible = false;
            dgvValesIng.Columns["MPSPRO"].Visible = false;
            dgvValesIng.Columns["MPMUNI"].Visible = false;
            dgvValesIng.Columns["T01AL1"].Visible = false;
            dgvValesIng.Columns["MPMSMX"].Visible = false;
            dgvValesIng.Columns["MPMSMN"].Visible = false;
            dgvValesIng.Columns["MPMSEM"].Visible = false;
            dgvValesIng.Columns["MPMPRE"].Visible = false;
            dgvValesIng.Columns["MPMSCO"].Visible = false;
            dgvValesIng.Columns["MPMUBI"].Visible = false;
            dgvValesIng.Columns["MPSOTR"].Visible = false;

            dgvValesIng.Columns["MPSFSA"].DisplayIndex = 0; 
            dgvValesIng.Columns["MPMDES"].DisplayIndex = 1;                       
            dgvValesIng.Columns["MPSCAN"].DisplayIndex = 2;
            dgvValesIng.Columns["MPSNSA"].DisplayIndex = 3;            
            dgvValesIng.Columns["DESAREA"].DisplayIndex = 4;
            dgvValesIng.Columns["NOMTRAB2"].DisplayIndex = 5;
            dgvValesIng.Columns["DESOTR"].DisplayIndex = 6;
            dgvValesIng.Columns["MPMCTA"].DisplayIndex = 7;
            dgvValesIng.Columns["NOMTRAB1"].DisplayIndex = 8;

            dgvValesIng.Columns["MPSFSA"].HeaderText = "F.Salida";
            dgvValesIng.Columns["MPMDES"].HeaderText = "Descripcion";
            dgvValesIng.Columns["MPSCAN"].HeaderText = "Cant.Atend.";
            dgvValesIng.Columns["MPSNSA"].HeaderText = "Nro Vale";
            dgvValesIng.Columns["DESAREA"].HeaderText = "Area";
            dgvValesIng.Columns["NOMTRAB2"].HeaderText = "User.Autoriz.";            
            dgvValesIng.Columns["DESOTR"].HeaderText = "Ord.Trab";
            dgvValesIng.Columns["MPMCTA"].HeaderText = "Cuenta";
            dgvValesIng.Columns["NOMTRAB1"].HeaderText = "User.Solic.";

            dgvValesIng.Columns["MPSFSA"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["MPMDES"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["MPSCAN"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["MPSNSA"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["DESAREA"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["NOMTRAB2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;            
            dgvValesIng.Columns["DESOTR"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["MPMCTA"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["NOMTRAB1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvValesIng.Columns["MPSFSA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["MPMDES"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvValesIng.Columns["MPSCAN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvValesIng.Columns["MPSNSA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["DESAREA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvValesIng.Columns["NOMTRAB2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;            
            dgvValesIng.Columns["DESOTR"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvValesIng.Columns["MPMCTA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["NOMTRAB1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvValesIng.Columns["MPSCAN"].DefaultCellStyle.Format = "##,##.000";
            //dgvValesIng.Columns["MPSNSA"].DefaultCellStyle.Format = "##,##.00";
            //dgvValesIng.Columns["MPSFSA"].DefaultCellStyle.Format = "##/##/####";


            dgvValesIng.Columns["MPSFSA"].Width = 100;
            dgvValesIng.Columns["MPMDES"].Width = 250;
            dgvValesIng.Columns["MPSCAN"].Width = 80;
            dgvValesIng.Columns["MPSNSA"].Width = 80;
            dgvValesIng.Columns["DESAREA"].Width = 200;
            dgvValesIng.Columns["NOMTRAB2"].Width = 200;
            dgvValesIng.Columns["DESOTR"].Width = 200;
            dgvValesIng.Columns["MPMCTA"].Width = 200;
            dgvValesIng.Columns["NOMTRAB1"].Width = 200;
        }

        private void dgvValesIng_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int p = dgvValesIng.CurrentRow.Index;
            lbl1.Text = dgvValesIng.Rows[p].Cells["MPSCOD"].Value.ToString() + "  " + dgvValesIng.Rows[p].Cells["MPMDES"].Value.ToString();
            lbl2.Text = dgvValesIng.Rows[p].Cells["MPSFSA"].Value.ToString();
            lbl3.Text = dgvValesIng.Rows[p].Cells["MPSNSA"].Value.ToString();
            lbl4.Text = dgvValesIng.Rows[p].Cells["MPSCAN"].Value.ToString();
            lbl5.Text = dgvValesIng.Rows[p].Cells["MPSIMP"].Value.ToString();
            lbl6.Text = dgvValesIng.Rows[p].Cells["DESAREA"].Value.ToString();
            lbl7.Text = dgvValesIng.Rows[p].Cells["NOMTRAB1"].Value.ToString();
            lbl8.Text = dgvValesIng.Rows[p].Cells["NOMTRAB2"].Value.ToString();
            lbl9.Text = dgvValesIng.Rows[p].Cells["MPMCCA"].Value.ToString();
            lbl10.Text = dgvValesIng.Rows[p].Cells["MPSPRO"].Value.ToString();
            lbl11.Text = dgvValesIng.Rows[p].Cells["T01AL1"].Value.ToString();
            lbl12.Text = dgvValesIng.Rows[p].Cells["MPMSMX"].Value.ToString();
            lbl13.Text = dgvValesIng.Rows[p].Cells["MPMSMN"].Value.ToString();
            lbl14.Text = dgvValesIng.Rows[p].Cells["MPMSEM"].Value.ToString();
            lbl15.Text = dgvValesIng.Rows[p].Cells["MPMPRE"].Value.ToString();
            lbl16.Text = dgvValesIng.Rows[p].Cells["MPMSCO"].Value.ToString();
            lbl17.Text = dgvValesIng.Rows[p].Cells["MPMUBI"].Value.ToString();
            panelDetalle.Visible = true;
            this.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panelDetalle.Visible = false;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            oUtils.DataTableToExcel(Program.dtValesIng);
        }

        private void cboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboBusqueda.SelectedIndex)
            {
                case 0:
                    dv1 = new DataView(Program.dtValesIng);
                    dv1.Sort = "MPSNSA ASC";
                    dgvValesIng.DataSource = dv1;
                    Grilla();
                    break;
                case 1:
                    dv1 = new DataView(Program.dtValesIng);
                    dv1.Sort = "MPSCOD ASC";
                    dgvValesIng.DataSource = dv1;
                    Grilla();
                    break;
                case 2:
                    dv1 = new DataView(Program.dtValesIng);
                    dv1.Sort = "MPMDES ASC";
                    dgvValesIng.DataSource = dv1;
                    Grilla();
                    break;
                case 3:
                    dv1 = new DataView(Program.dtValesIng);
                    dv1.Sort = "DESAREA ASC";
                    dgvValesIng.DataSource = dv1;
                    Grilla();
                    break;
                case 4:
                    dv1 = new DataView(Program.dtValesIng);
                    dv1.Sort = "DESOTR ASC";
                    dgvValesIng.DataSource = dv1;
                    Grilla();
                    break;
                case 5:
                    dv1 = new DataView(Program.dtValesIng);
                    dv1.Sort = "NOMTRAB1 ASC";
                    dgvValesIng.DataSource = dv1;
                    Grilla();
                    break;
                case 6:
                    dv1 = new DataView(Program.dtValesIng);
                    dv1.Sort = "NOMTRAB2 ASC";
                    dgvValesIng.DataSource = dv1;
                    Grilla();
                    break;
                default:
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
                        dv1 = new DataView(Program.dtValesIng);
                        dv1.RowFilter = "MPSNSA LIKE '" + txtBusqueda.Text.Trim() + "%'";
                        dv1.Sort = "MPSNSA ASC";
                        dgvValesIng.DataSource = dv1;
                        Grilla();
                        break;
                    case 1:
                        dv1 = new DataView(Program.dtValesIng);
                        dv1.RowFilter = "MPSCOD LIKE '%" + txtBusqueda.Text.Trim() + "%'";
                        dv1.Sort = "MPSCOD ASC";
                        dgvValesIng.DataSource = dv1;
                        Grilla();
                        break;
                    case 2:
                        dv1 = new DataView(Program.dtValesIng);
                        dv1.RowFilter = "MPMDES LIKE '%" + txtBusqueda.Text.Trim() + "%'";
                        dv1.Sort = "MPMDES ASC";
                        dgvValesIng.DataSource = dv1;
                        Grilla();
                        break;
                    case 3:
                        dv1 = new DataView(Program.dtValesIng);
                        dv1.RowFilter = "DESAREA LIKE '%" + txtBusqueda.Text.Trim() + "%'";
                        dv1.Sort = "DESAREA ASC";
                        dgvValesIng.DataSource = dv1;
                        Grilla();
                        break;
                    case 4:
                        dv1 = new DataView(Program.dtValesIng);
                        dv1.RowFilter = "DESOTR LIKE '%" + txtBusqueda.Text.Trim() + "%'";
                        dv1.Sort = "DESOTR ASC";
                        dgvValesIng.DataSource = dv1;
                        Grilla();
                        break;
                    case 5:
                        dv1 = new DataView(Program.dtValesIng);
                        dv1.RowFilter = "NOMTRAB1 LIKE '%" + txtBusqueda.Text.Trim() + "%'";
                        dv1.Sort = "NOMTRAB1 ASC";
                        dgvValesIng.DataSource = dv1;
                        Grilla();
                        break;
                    case 6:
                        dv1 = new DataView(Program.dtValesIng);
                        dv1.RowFilter = "NOMTRAB2 LIKE '%" + txtBusqueda.Text.Trim() + "%'";
                        dv1.Sort = "NOMTRAB2 ASC";
                        dgvValesIng.DataSource = dv1;
                        Grilla();
                        break;
                    default:
                        break;
                }
            }
            catch { }
        }
    }
}
