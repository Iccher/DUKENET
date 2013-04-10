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
using System.Collections;
using System.Diagnostics;

namespace Logistica.Ingenieria.Presentacion.Consultas
{
    public partial class Frm_Ingreso_AI : Form
    {
        public Frm_Ingreso_AI()
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
            Program.dtValesIng = objBusTab.getConsultaIngresos(mes1, mes2);
            dv1 = new DataView(Program.dtValesIng);
            //dv1.Sort = "NOMTRAB2 ASC";
            dgvValesIng.DataSource = dv1;

            cboBusqueda.Items.Add("Nro.Ingreso");
            cboBusqueda.Items.Add("Codigo Prod.");
            cboBusqueda.Items.Add("Descripción Prod.");
            cboBusqueda.Items.Add("O/C");
            cboBusqueda.Items.Add("Factura");
            cboBusqueda.Items.Add("G/R");
            cboBusqueda.Items.Add("Cod.Prov");
            cboBusqueda.Items.Add("Nom.Prov");


            Grilla(); 
        }

        void Grilla()
        {
            dgvValesIng.Columns["MPICOD"].DisplayIndex = 0;
            dgvValesIng.Columns["MPMDES"].DisplayIndex = 1;
            dgvValesIng.Columns["MPIFNI"].DisplayIndex = 2;
            dgvValesIng.Columns["MPINNI"].DisplayIndex = 3;
            dgvValesIng.Columns["MPICAN"].DisplayIndex = 4;
            dgvValesIng.Columns["MPIIMP"].DisplayIndex = 5;
            dgvValesIng.Columns["MPINOC"].DisplayIndex = 6;
            dgvValesIng.Columns["MPIPRV"].DisplayIndex = 7;
            dgvValesIng.Columns["PRONOM"].DisplayIndex = 8;
            dgvValesIng.Columns["MPINFC"].DisplayIndex = 9;
            dgvValesIng.Columns["MPINGU"].DisplayIndex = 10;
            dgvValesIng.Columns["MPMCTA"].DisplayIndex = 11;
            dgvValesIng.Columns["MPMCCA"].DisplayIndex = 12;
            dgvValesIng.Columns["MPIPRO"].DisplayIndex = 13;
            dgvValesIng.Columns["MPMUNI"].DisplayIndex = 14;
            dgvValesIng.Columns["T01AL1"].DisplayIndex = 15;
            dgvValesIng.Columns["MPMSMX"].DisplayIndex = 16;
            dgvValesIng.Columns["MPMSMN"].DisplayIndex = 17;
            dgvValesIng.Columns["MPMSEM"].DisplayIndex = 18;
            dgvValesIng.Columns["MPMPRE"].DisplayIndex = 19;
            dgvValesIng.Columns["MPMSCO"].DisplayIndex = 20;
            dgvValesIng.Columns["MPMUBI"].DisplayIndex = 21;


            dgvValesIng.Columns["MPIIMP"].Visible = false;
            dgvValesIng.Columns["MPMCCA"].Visible = false;
            dgvValesIng.Columns["MPIPRO"].Visible = false;
            dgvValesIng.Columns["MPMUNI"].Visible = false;
            dgvValesIng.Columns["MPMSMX"].Visible = false;
            dgvValesIng.Columns["MPMSMN"].Visible = false;
            dgvValesIng.Columns["MPMSEM"].Visible = false;
            dgvValesIng.Columns["MPMPRE"].Visible = false;
            dgvValesIng.Columns["MPMSCO"].Visible = false;
            dgvValesIng.Columns["MPMUBI"].Visible = false;

            dgvValesIng.Columns["MPICOD"].HeaderText = "Codigo";
            dgvValesIng.Columns["MPMDES"].HeaderText = "Descripcion";
            dgvValesIng.Columns["MPIFNI"].HeaderText = "Fec.Ing.";
            dgvValesIng.Columns["MPINNI"].HeaderText = "Nro.Ing.";
            dgvValesIng.Columns["MPICAN"].HeaderText = "Cantidad";
            dgvValesIng.Columns["MPINOC"].HeaderText = "O/C";
            dgvValesIng.Columns["MPIPRV"].HeaderText = "Cod.Prov.";
            dgvValesIng.Columns["PRONOM"].HeaderText = "Nom.Prov.";
            dgvValesIng.Columns["MPINFC"].HeaderText = "Factura";
            dgvValesIng.Columns["MPINGU"].HeaderText = "G/R";
            dgvValesIng.Columns["MPMCTA"].HeaderText = "Cuenta";
            dgvValesIng.Columns["T01AL1"].HeaderText = "Unid.Med.";

            dgvValesIng.Columns["MPICOD"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["MPMDES"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["MPIFNI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["MPINNI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["MPICAN"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["MPINOC"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["MPIPRV"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["PRONOM"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["MPINFC"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["MPINGU"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["MPMCTA"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["T01AL1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;



            dgvValesIng.Columns["MPICOD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["MPMDES"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvValesIng.Columns["MPIFNI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["MPINNI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["MPICAN"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvValesIng.Columns["MPINOC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["MPIPRV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["PRONOM"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvValesIng.Columns["MPINFC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvValesIng.Columns["MPINGU"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvValesIng.Columns["MPMCTA"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvValesIng.Columns["T01AL1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;


            dgvValesIng.Columns["MPICAN"].DefaultCellStyle.Format = "##,##.000";

            dgvValesIng.Columns["MPICOD"].Width = 80;
            dgvValesIng.Columns["MPMDES"].Width = 300;
            dgvValesIng.Columns["MPIFNI"].Width = 100;
            dgvValesIng.Columns["MPINNI"].Width = 80;
            dgvValesIng.Columns["MPICAN"].Width = 80;
            dgvValesIng.Columns["MPINOC"].Width = 100;
            dgvValesIng.Columns["MPIPRV"].Width = 80;
            dgvValesIng.Columns["PRONOM"].Width = 250;
            dgvValesIng.Columns["MPINFC"].Width = 120;
            dgvValesIng.Columns["MPINGU"].Width = 100;
            dgvValesIng.Columns["MPMCTA"].Width = 80;
            dgvValesIng.Columns["T01AL1"].Width = 80;
        }

        private void dgvValesIng_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int p = dgvValesIng.CurrentRow.Index;
            lbl1.Text = dgvValesIng.Rows[p].Cells["MPICOD"].Value.ToString() + "  " + dgvValesIng.Rows[p].Cells["MPMDES"].Value.ToString();
            lbl2.Text = dgvValesIng.Rows[p].Cells["MPIFNI"].Value.ToString();
            lbl3.Text = dgvValesIng.Rows[p].Cells["MPINNI"].Value.ToString();
            lbl4.Text = dgvValesIng.Rows[p].Cells["MPICAN"].Value.ToString();
            lbl5.Text = dgvValesIng.Rows[p].Cells["MPIIMP"].Value.ToString();

            lblProv.Text = dgvValesIng.Rows[p].Cells["MPIPRV"].Value.ToString() + "    " + dgvValesIng.Rows[p].Cells["PRONOM"].Value.ToString();

            lblOC.Text = dgvValesIng.Rows[p].Cells["MPINOC"].Value.ToString();
            lblFac.Text = dgvValesIng.Rows[p].Cells["MPINFC"].Value.ToString();
            lblGuia.Text = dgvValesIng.Rows[p].Cells["MPINGU"].Value.ToString();

            lbl9.Text = dgvValesIng.Rows[p].Cells["MPMCCA"].Value.ToString();
            lbl10.Text = dgvValesIng.Rows[p].Cells["MPIPRO"].Value.ToString();
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
                foreach (DataGridViewColumn item in dgvValesIng.Columns)
                {
                    titulos.Add(item.HeaderText);
                    datosTabla.Columns.Add();
                }
                //se crean los renglones de la tabla
                foreach (DataGridViewRow item in dgvValesIng.Rows)
                {
                    DataRow rowx = datosTabla.NewRow();
                    datosTabla.Rows.Add(rowx);
                }
                //se pasan los datos del dataGridView a la tabla
                foreach (DataGridViewColumn item in dgvValesIng.Columns)
                {
                    foreach (DataGridViewRow itemx in dgvValesIng.Rows)
                    {
                        datosTabla.Rows[itemx.Index][item.Index] = dgvValesIng[item.Index, itemx.Index].Value;
                    }
                }
                OF.Export(titulos, datosTabla);
                Process.Start(OF.xpath);
                MessageBox.Show("Procceso Completo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }



        private void cboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboBusqueda.SelectedIndex)
            {
                case 0:
                    dv1 = new DataView(Program.dtValesIng);
                    dv1.Sort = "MPINNI ASC";
                    dgvValesIng.DataSource = dv1;
                    Grilla();
                    break;
                case 1:
                    dv1 = new DataView(Program.dtValesIng);
                    dv1.Sort = "MPICOD ASC";
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
                    dv1.Sort = "MPINOC ASC";
                    dgvValesIng.DataSource = dv1;
                    Grilla();
                    break;
                case 4:
                    dv1 = new DataView(Program.dtValesIng);
                    dv1.Sort = "MPINFC ASC";
                    dgvValesIng.DataSource = dv1;
                    Grilla();
                    break;
                case 5:
                    dv1 = new DataView(Program.dtValesIng);
                    dv1.Sort = "MPINGU ASC";
                    dgvValesIng.DataSource = dv1;
                    Grilla();
                    break;
                case 6:
                    dv1 = new DataView(Program.dtValesIng);
                    dv1.Sort = "MPIPRV ASC";
                    dgvValesIng.DataSource = dv1;
                    Grilla();
                    break;
                default:
                    dv1 = new DataView(Program.dtValesIng);
                    dv1.Sort = "PRONOM ASC";
                    dgvValesIng.DataSource = dv1;
                    Grilla();
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
                        dv1.RowFilter = "MPINNI LIKE '" + txtBusqueda.Text.Trim() + "%'";
                        dv1.Sort = "MPINNI ASC";
                        dgvValesIng.DataSource = dv1;
                        Grilla();
                        break;
                    case 1:
                        dv1 = new DataView(Program.dtValesIng);
                        dv1.RowFilter = "MPICOD LIKE '%" + txtBusqueda.Text.Trim() + "%'";
                        dv1.Sort = "MPICOD ASC";
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
                        dv1.RowFilter = "MPINOC LIKE '%" + txtBusqueda.Text.Trim() + "%'";
                        dv1.Sort = "MPINOC ASC";
                        dgvValesIng.DataSource = dv1;
                        Grilla();
                        break;
                    case 4:
                        dv1 = new DataView(Program.dtValesIng);
                        dv1.RowFilter = "MPINFC LIKE '%" + txtBusqueda.Text.Trim() + "%'";
                        dv1.Sort = "MPINFC ASC";
                        dgvValesIng.DataSource = dv1;
                        Grilla();
                        break;
                    case 5:
                        dv1 = new DataView(Program.dtValesIng);
                        dv1.RowFilter = "MPINGU LIKE '%" + txtBusqueda.Text.Trim() + "%'";
                        dv1.Sort = "MPINGU ASC";
                        dgvValesIng.DataSource = dv1;
                        Grilla();
                        break;
                    case 6:
                        dv1 = new DataView(Program.dtValesIng);
                        dv1.RowFilter = "MPIPRV LIKE '%" + txtBusqueda.Text.Trim() + "%'";
                        dv1.Sort = "MPIPRV ASC";
                        dgvValesIng.DataSource = dv1;
                        Grilla();
                        break;
                    default:
                        dv1 = new DataView(Program.dtValesIng);
                        dv1.RowFilter = "PRONOM LIKE '%" + txtBusqueda.Text.Trim() + "%'";
                        dv1.Sort = "PRONOM ASC";
                        dgvValesIng.DataSource = dv1;
                        Grilla();
                        break;
                }
            }
            catch { }
        }
    }
}
