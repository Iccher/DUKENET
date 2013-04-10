using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Logistica.Ingenieria.Bussiness;
using Logistica.Ingenieria.Entity;
using Logistica.Ingenieria.Utils;

namespace Logistica.Ingenieria.Presentacion
{
    public partial class frmDescomposicion : Form
    {
        public frmDescomposicion()
        {
            InitializeComponent();
        }

        int sw = 0;
        int ins = 0;
        public string fecha;
        NReqMatProd obj = new NReqMatProd();
        TControlVB Control = new TControlVB();
        BindingList<EMateria> gr = new BindingList<EMateria>();
         
        private void frmDescomposicion_Load(object sender, EventArgs e)
        {
            if (MessageBox.Show("El Proceso de descomposición se iniciara. Este proceso puede tardar varios minutos. ¿Desea Continuar?", "Descomposicón", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                dataGridView1.GridColor = Color.Red;
                BindingList<EMateria> mat = new BindingList<EMateria>();
                List<EMateria> matL = new List<EMateria>();
                mat = obj.Llenado(fecha);
                matL = mat.OrderBy(y => y.Cod_materia).ToList();
                dataGridView1.DataSource = matL;
                GroupColumn(dataGridView1, 0, 1);
                rowsBlancos(dataGridView1);
                dataGridView1.DataSource = gr;
                GroupSum(dataGridView1);
                rowsBlancos2(dataGridView1);
                dataGridView1.DataSource = obj.rqMat(gr);
                EstiloGrilla();
                this.Cursor = Cursors.Default;
            }
            else
            {
                this.Close();
            }
        }

        private void GroupColumn(DataGridView grid, int ColumnIndex, int ColumnIndex2)
        {
            string aux = "";
            string aux2 = "";
            double acum = 0;
            double acum2 = 0;
            double acum3 = 0;
            double acum4 = 0;

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.Index == 1)
                {
                    aux = grid[ColumnIndex, row.Index].Value.ToString();
                    aux2 = grid[ColumnIndex2, row.Index].Value.ToString();
                    acum = acum + Convert.ToDouble(grid[2, row.Index].Value.ToString());
                    acum2 = acum2 + Convert.ToDouble(grid[3, row.Index].Value.ToString());
                    acum3 = acum3 + Convert.ToDouble(grid[4, row.Index].Value.ToString());
                    acum4 = acum4 + Convert.ToDouble(grid[5, row.Index].Value.ToString());
                }

                if (row.Index > 0)
                {
                    if (grid[ColumnIndex, row.Index].Value.ToString() == aux)
                    {

                        grid[ColumnIndex, row.Index].Value = null;
                        grid[ColumnIndex2, row.Index].Value = null;
                        acum = acum + Convert.ToDouble(grid[2, row.Index].Value.ToString());
                        grid[2, row.Index].Value = null;
                        acum2 = acum2 + Convert.ToDouble(grid[3, row.Index].Value.ToString());
                        grid[3, row.Index].Value = null;
                        acum3 = acum3 + Convert.ToDouble(grid[4, row.Index].Value.ToString());
                        grid[4, row.Index].Value = null;
                        acum4 = acum4 + Convert.ToDouble(grid[5, row.Index].Value.ToString());
                        grid[5, row.Index].Value = null;
                        if (row.Index == grid.RowCount - 1)
                        {
                            grid[2, row.Index].Value = acum.ToString();
                            grid[3, row.Index].Value = acum2.ToString();
                            grid[4, row.Index].Value = acum3.ToString();
                            grid[5, row.Index].Value = acum4.ToString();
                        }
                    }
                    else
                    {
                        if (row.Index == grid.RowCount - 1)
                        {
                            grid[2, row.Index].Value = acum.ToString();
                            grid[3, row.Index].Value = acum2.ToString();
                            grid[4, row.Index].Value = acum3.ToString();
                            grid[5, row.Index].Value = acum4.ToString();
                        }
                        aux = grid[ColumnIndex, row.Index].Value.ToString();
                        aux2 = grid[ColumnIndex2, row.Index].Value.ToString();
                        grid[2, row.Index - 1].Value = acum.ToString();
                        acum = 0;
                        acum = acum + Convert.ToDouble(grid[2, row.Index].Value.ToString());
                        grid[3, row.Index - 1].Value = acum2.ToString();
                        acum2 = 0;
                        acum2 = acum2 + Convert.ToDouble(grid[3, row.Index].Value.ToString());
                        grid[4, row.Index - 1].Value = acum3.ToString();
                        acum3 = 0;
                        acum3 = acum3 + Convert.ToDouble(grid[4, row.Index].Value.ToString());
                        grid[5, row.Index - 1].Value = acum4.ToString();
                        acum4 = 0;
                        acum4 = acum4 + Convert.ToDouble(grid[5, row.Index].Value.ToString());
                    }

                }
            }
        }

        private void rowsBlancos(DataGridView grid)
        {
            gr = new BindingList<EMateria>();
            EMateria m = new EMateria();

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (grid[2, row.Index].Value != null && grid[3, row.Index].Value != null && grid[4, row.Index].Value != null && grid[5, row.Index].Value!=null)
                {
                    if (grid[0, row.Index].Value != null && grid[1, row.Index].Value != null)
                    {
                        m = new EMateria();
                        m.Cod_materia = grid[0, row.Index].Value.ToString();
                        m.Des_materia = grid[1, row.Index].Value.ToString();
                        m.Peso_neto = grid[2, row.Index].Value.ToString();
                        m.Peso_merma = grid[3, row.Index].Value.ToString();
                        m.Peso_exed = grid[4, row.Index].Value.ToString();
                        m.Peso_total = grid[5, row.Index].Value.ToString();
                        gr.Add(m);
                    }
                    else
                    {
                        m = new EMateria();
                        m.Cod_materia = "";
                        m.Des_materia = "";
                        m.Peso_neto = grid[2, row.Index].Value.ToString();
                        m.Peso_merma = grid[3, row.Index].Value.ToString();
                        m.Peso_exed = grid[4, row.Index].Value.ToString();
                        m.Peso_total = grid[5, row.Index].Value.ToString();
                        gr.Add(m);
                    }
                }
            }

        }

        private void GroupSum(DataGridView grid)
        {
            string aux = "";
            string aux2 = "";
            string aux3 = "";
            string aux4 = "";

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.Index > 0)
                {
                    if (grid[2, row.Index].Value != null && grid[3, row.Index].Value != null && grid[4, row.Index].Value != null && grid[5, row.Index].Value != null)
                    {

                        grid[2, row.Index-1].Value = grid[2, row.Index].Value.ToString();
                        grid[3, row.Index-1].Value = grid[3, row.Index].Value.ToString();
                        grid[4, row.Index-1].Value = grid[4, row.Index].Value.ToString();
                        grid[5, row.Index-1].Value = grid[5, row.Index].Value.ToString();
                        grid[2, row.Index].Value = null;
                        grid[3, row.Index].Value = null;
                        grid[4, row.Index].Value = null;
                        grid[5, row.Index].Value = null;
                    }                   

                }
            }
        }

        private void rowsBlancos2(DataGridView grid)
        {
            gr = new BindingList<EMateria>();
            EMateria m = new EMateria();

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.Index == 1)
                {
                    m = new EMateria();
                    m.Cod_materia = grid[0, row.Index-1].Value.ToString();
                    m.Des_materia = grid[1, row.Index-1].Value.ToString();
                    m.Peso_neto = grid[2, row.Index-1].Value.ToString();
                    m.Peso_merma = grid[3, row.Index-1].Value.ToString();
                    m.Peso_exed = grid[4, row.Index-1].Value.ToString();
                    m.Peso_total = grid[5, row.Index-1].Value.ToString();
                    gr.Add(m);
                }
                if (row.Index > 0)
                {
                    if (grid[2, row.Index].Value != null && grid[3, row.Index].Value != null && grid[4, row.Index].Value != null && grid[5, row.Index].Value != null)
                    {
                        if ((grid[0, row.Index].Value.ToString() != "" && grid[1, row.Index].Value.ToString() != ""))
                        {
                            m = new EMateria();
                            m.Cod_materia = grid[0, row.Index].Value.ToString();
                            m.Des_materia = grid[1, row.Index].Value.ToString();
                            m.Peso_neto = grid[2, row.Index].Value.ToString();
                            m.Peso_merma = grid[3, row.Index].Value.ToString();
                            m.Peso_exed = grid[4, row.Index].Value.ToString();
                            m.Peso_total = grid[5, row.Index].Value.ToString();
                            gr.Add(m);
                        }

                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void txtCodSol_DoubleClick(object sender, EventArgs e)
        {
            sw = 1;
            Program.dt = obj.LstTrabajadores();
            dataGridView2.DataSource = Program.dt;
            EstiloGrilla2();
            panel2.Visible = true;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(Program.dt, "R01CPE LIKE '" + txtCodigo.Text + "%'", "", DataViewRowState.OriginalRows);
            dataGridView2.DataSource = dv;
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(Program.dt, "R01NOM LIKE '" + txtNombre.Text + "%'", "", DataViewRowState.OriginalRows);
            dataGridView2.DataSource = dv;
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            if (sw == 1)
            {
                txtCodSol.Text = dataGridView2[0, dataGridView2.CurrentRow.Index].Value.ToString();
                txtNomSol.Text = dataGridView2[1, dataGridView2.CurrentRow.Index].Value.ToString();
            }

            else if (sw == 2)
            {
                txtCodAut.Text = dataGridView2[0, dataGridView2.CurrentRow.Index].Value.ToString();
                txtNomAut.Text = dataGridView2[1, dataGridView2.CurrentRow.Index].Value.ToString();
            }
            panel2.Visible = false;
            txtCodigo.Text = "";
            txtNombre.Text = "";
        }

        private void txtCodAut_DoubleClick(object sender, EventArgs e)
        {
            sw = 2;
            Program.dt = obj.LstTrabajadores();
            dataGridView2.DataSource = Program.dt; 
            EstiloGrilla2();
            panel2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cboTurno.SelectedIndex != 0 && cboTurno.SelectedIndex != -1)
            {
                if (txtCodSol.Text != "")
                {
                    if (txtCodAut.Text != "")
                    {
                        int updS = 0;
                        int insRP = 0;
                        int inst = 0;
                        int nit = 1;
                        int beg = 0;
                        double vm=0;
                        string NroVale = obj.LstValeNro()[0].Vale.ToString();
                        int nroV = Convert.ToInt32(NroVale) + 1;
                        if (ins == 0)
                        {

                            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                            {
                                if (dataGridView1[8, i].Value.ToString() != "4" && dataGridView1[8, i].Value.ToString() != "5")
                                {
                                    if (obj.LstRegPed(dtp1.Text, dataGridView1[0, i].Value.ToString(), "1").Count <= 0)                                    
                                    {
                                        if (dataGridView1[7, i].Value.ToString() != "")
                                        {
                                            inst = obj.insAlmvsal("LAPDMBF1", "20110217", "1421", nroV.ToString(), nit.ToString(), dtp1.Text, cboTurno.SelectedIndex.ToString(), txtCodAut.Text, txtCodSol.Text, dataGridView1[0, i].Value.ToString(), dataGridView1[9, i].Value.ToString(), dataGridView1[8, i].Value.ToString(), dataGridView1[7, i].Value.ToString());
                                            updS = obj.updStockMP(dataGridView1[7, i].Value.ToString(), dataGridView1[0, i].Value.ToString());
                                            insRP = obj.insRegPed("LAPDMBF1", "20110217", dtp1.Text, dataGridView1[0, i].Value.ToString(), dataGridView1[5, i].Value.ToString(), dataGridView1[7, i].Value.ToString(), "1");
                                            if (obj.LstVmp02(dataGridView1[0, i].Value.ToString()).Rows.Count > 0)
                                            {
                                                obj.updVmp02(dataGridView1[7, i].Value.ToString(), dataGridView1[5, i].Value.ToString(), dataGridView1[0, i].Value.ToString());
                                            }
                                            else
                                            {
                                                vm = Convert.ToDouble(dataGridView1[7, i].Value.ToString()) - Convert.ToDouble(dataGridView1[5, i].Value.ToString());
                                                obj.insVmp02(dataGridView1[0, i].Value.ToString(),dataGridView1[7, i].Value.ToString(),dataGridView1[5, i].Value.ToString(),dataGridView1[7, i].Value.ToString(),vm.ToString());
                                            }
                                            nit = nit + 1;
                                            beg = 1;
                                        }
                                    }
                                }
                            }
                            if (beg == 1)
                            {
                                frmReporte frm = new frmReporte();
                                frm.VALE = nroV.ToString();
                                frm.ShowDialog();
                                ins = 1;
                                int upd = obj.updNroVale(nroV.ToString());
                            }
                            txtCodSol.Text = ""; txtNomSol.Text = ""; txtCodAut.Text = ""; txtNomAut.Text = "";
                            if (inst == 1 && updS == 1 && insRP == 1)
                            {
                                MessageBox.Show("El Vale de Insumos Nro " + nroV.ToString() + " Ha sido Generado...");
                                groupBox1.Text = "Generar Vale de Consumo Cuerdas";
                            }
                            else
                            {
                                if (beg == 0)
                                {
                                    MessageBox.Show("El Vale de este dia ya ha sido generado");
                                }
                                else
                                {
                                    MessageBox.Show("Verificar Informacion...");
                                }
                            }

                        }
                        else if (ins == 1)
                        {
                            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                            {
                                if (dataGridView1[8, i].Value.ToString() == "4")
                                {
                                    if (obj.LstRegPed(dtp1.Text, dataGridView1[0, i].Value.ToString(), "2").Count <= 0)
                                    {
                                        if (dataGridView1[7, i].Value.ToString() != "")
                                        {
                                            inst = obj.insAlmvsal("LAPDMBF1", "20110217", "1421", nroV.ToString(), nit.ToString(), dtp1.Text, cboTurno.SelectedIndex.ToString(), txtCodAut.Text, txtCodSol.Text, dataGridView1[0, i].Value.ToString(), dataGridView1[9, i].Value.ToString(), dataGridView1[8, i].Value.ToString(), dataGridView1[7, i].Value.ToString());
                                            updS = obj.updStockMP(dataGridView1[7, i].Value.ToString(), dataGridView1[0, i].Value.ToString());
                                            insRP = obj.insRegPed("LAPDMBF1", "20110217", dtp1.Text, dataGridView1[0, i].Value.ToString(), dataGridView1[5, i].Value.ToString(), dataGridView1[7, i].Value.ToString(), "2");
                                            if (obj.LstVmp02(dataGridView1[0, i].Value.ToString()).Rows.Count > 0)
                                            {
                                                obj.updVmp02(dataGridView1[7, i].Value.ToString(), dataGridView1[5, i].Value.ToString(), dataGridView1[0, i].Value.ToString());
                                            }
                                            else
                                            {
                                                vm = Convert.ToDouble(dataGridView1[7, i].Value.ToString()) - Convert.ToDouble(dataGridView1[5, i].Value.ToString());
                                                obj.insVmp02(dataGridView1[0, i].Value.ToString(), dataGridView1[7, i].Value.ToString(), dataGridView1[5, i].Value.ToString(), dataGridView1[7, i].Value.ToString(), vm.ToString());
                                            }
                                            nit = nit + 1;
                                            beg = 1;
                                        }
                                    }
                                }
                            }
                            if (beg == 1)
                            {
                                frmReporte frm = new frmReporte();
                                frm.VALE = nroV.ToString();
                                frm.ShowDialog();
                                ins = 2;
                                int upd = obj.updNroVale(nroV.ToString());
                            }
                            txtCodSol.Text = ""; txtNomSol.Text = ""; txtCodAut.Text = ""; txtNomAut.Text = "";
                            if (inst == 1 && updS == 1 && insRP == 1)
                            {
                                MessageBox.Show("El Vale de Cuerdas Nro " + nroV.ToString() + " Ha sido Generado...");
                                groupBox1.Text = "Generar Vale de Consumo Alambres";
                            }
                            else
                            {
                                if (beg == 0)
                                {
                                    MessageBox.Show("El Vale de este dia ya ha sido generado");
                                }
                                else
                                {
                                    MessageBox.Show("Verificar Informacion...");
                                }
                            }
                            
                        }
                        else if (ins == 2)
                        {
                            for (int i = 0; i <= dataGridView1.RowCount - 1; i++)
                            {
                                if (dataGridView1[8, i].Value.ToString() == "5")
                                {
                                    if (obj.LstRegPed(dtp1.Text, dataGridView1[0, i].Value.ToString(), "3").Count <= 0)
                                    {
                                        if (dataGridView1[7, i].Value.ToString() != "")
                                        {
                                            inst = obj.insAlmvsal("LAPDMBF1", "20110217", "1421", nroV.ToString(), nit.ToString(), dtp1.Text, cboTurno.SelectedIndex.ToString(), txtCodAut.Text, txtCodSol.Text, dataGridView1[0, i].Value.ToString(), dataGridView1[9, i].Value.ToString(), dataGridView1[8, i].Value.ToString(), dataGridView1[7, i].Value.ToString());
                                            updS = obj.updStockMP(dataGridView1[7, i].Value.ToString(), dataGridView1[0, i].Value.ToString());
                                            insRP = obj.insRegPed("LAPDMBF1", "20110217", dtp1.Text, dataGridView1[0, i].Value.ToString(), dataGridView1[5, i].Value.ToString(), dataGridView1[7, i].Value.ToString(), "3");
                                            if (obj.LstVmp02(dataGridView1[0, i].Value.ToString()).Rows.Count > 0)
                                            {
                                                obj.updVmp02(dataGridView1[7, i].Value.ToString(), dataGridView1[5, i].Value.ToString(), dataGridView1[0, i].Value.ToString());
                                            }
                                            else
                                            {
                                                vm = Convert.ToDouble(dataGridView1[7, i].Value.ToString()) - Convert.ToDouble(dataGridView1[5, i].Value.ToString());
                                                obj.insVmp02(dataGridView1[0, i].Value.ToString(), dataGridView1[7, i].Value.ToString(), dataGridView1[5, i].Value.ToString(), dataGridView1[7, i].Value.ToString(), vm.ToString());
                                            }
                                            nit = nit + 1;
                                            beg = 1;
                                        }
                                    }
                                }
                            }
                            if (beg == 1)
                            {
                                frmReporte frm = new frmReporte();
                                frm.VALE = nroV.ToString();
                                frm.ShowDialog();
                                ins = 3;
                                int upd = obj.updNroVale(nroV.ToString());
                            }
                            txtCodSol.Text = ""; txtNomSol.Text = ""; txtCodAut.Text = ""; txtNomAut.Text = "";
                            if (inst == 1 && updS == 1 && insRP == 1)
                            {
                                MessageBox.Show("El Vale de Alambre Nro " + nroV.ToString() + " Ha sido Generado...");
                                panel1.Visible = false;
                                this.Close();
                            }
                            else
                            {
                                if (beg == 0)
                                {
                                    MessageBox.Show("El Vale de este dia ya ha sido generado");
                                }
                                else
                                {
                                    MessageBox.Show("Verificar Informacion...");
                                }
                            }

                        }
                    }
                    else
                    {
                        MessageBox.Show("Verificar Autorizante...");
                    }
                }
                else
                {
                    MessageBox.Show("Verificar Solicitante...");
                }
            }
            else
            {
                MessageBox.Show("Verificar Turno...");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void txtCodSol_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control.NumeroDec(e, txtCodSol);
        }

        private void txtCodAut_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control.NumeroDec(e, txtCodAut);
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control.NumeroDec(e, txtCodigo);
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                //dataGridView1[dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex].Value = null;
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show("error");
            }
        }

        private void EstiloGrilla()
        {


            dataGridView1.Columns["cod_materia"].DisplayIndex = 0;
            dataGridView1.Columns["cod_materia"].HeaderText = "Codigo";
            dataGridView1.Columns["cod_materia"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["cod_materia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["cod_materia"].Width = 120;
            dataGridView1.Columns["cod_materia"].ReadOnly = true;

            dataGridView1.Columns["des_materia"].DisplayIndex = 1;
            dataGridView1.Columns["des_materia"].HeaderText = "Descripción";
            dataGridView1.Columns["des_materia"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["des_materia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView1.Columns["des_materia"].Width = 300;
            dataGridView1.Columns["des_materia"].ReadOnly = true;

            dataGridView1.Columns["peso_neto"].DisplayIndex = 2;
            dataGridView1.Columns["peso_neto"].HeaderText = "Peso Producción Requerido";
            dataGridView1.Columns["peso_neto"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["peso_neto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["peso_neto"].Width = 60;
            dataGridView1.Columns["peso_neto"].ReadOnly = true;
            dataGridView1.Columns["peso_neto"].DefaultCellStyle.Format = "#,###.##";

            dataGridView1.Columns["peso_merma"].Visible = false;
            dataGridView1.Columns["peso_exed"].Visible = false;

            dataGridView1.Columns["Canpro"].DisplayIndex = 3;
            dataGridView1.Columns["Canpro"].HeaderText = "Peso Neto Requerido";
            dataGridView1.Columns["Canpro"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Canpro"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Canpro"].Width = 60;
            dataGridView1.Columns["Canpro"].ReadOnly = true;
            dataGridView1.Columns["Canpro"].DefaultCellStyle.Format = "#,###.##";

            dataGridView1.Columns["Vmpdif"].DisplayIndex = 4;
            dataGridView1.Columns["Vmpdif"].HeaderText = "Peso Sobrante";
            dataGridView1.Columns["Vmpdif"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Vmpdif"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["Vmpdif"].Width = 60;
            dataGridView1.Columns["Vmpdif"].ReadOnly = true;
            dataGridView1.Columns["Vmpdif"].DefaultCellStyle.Format = "#,###.##";

            dataGridView1.Columns["peso_total"].DisplayIndex = 5;
            dataGridView1.Columns["peso_total"].HeaderText = "Peso Requerido";
            dataGridView1.Columns["peso_total"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["peso_total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["peso_total"].Width = 60;
            dataGridView1.Columns["peso_total"].ReadOnly = true;
            dataGridView1.Columns["peso_total"].DefaultCellStyle.Format = "#,###";

            dataGridView1.Columns["stock"].DisplayIndex = 6;
            dataGridView1.Columns["stock"].HeaderText = "Stock Disponible";
            dataGridView1.Columns["stock"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["stock"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["stock"].Width = 60;
            dataGridView1.Columns["stock"].ReadOnly = true;
            dataGridView1.Columns["stock"].DefaultCellStyle.Format = "#,###.##";

            dataGridView1.Columns["req"].DisplayIndex = 7;
            dataGridView1.Columns["req"].HeaderText = "Cant. Pedida";
            dataGridView1.Columns["req"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["req"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView1.Columns["req"].Width = 60;
            dataGridView1.Columns["req"].ReadOnly = false;
            dataGridView1.Columns["req"].DefaultCellStyle.Format = "#,###";

            dataGridView1.Columns["cuenta"].DisplayIndex = 8;
            dataGridView1.Columns["cuenta"].Visible = false;

            dataGridView1.Columns["procedencia"].DisplayIndex = 9;
            dataGridView1.Columns["procedencia"].Visible = false;

        }

        private void EstiloGrilla2()
        {
            dataGridView2.Columns["r01cpe"].DisplayIndex = 0;
            dataGridView2.Columns["r01cpe"].HeaderText = "Codigo";
            dataGridView2.Columns["r01cpe"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns["r01cpe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns["r01cpe"].Width = 120;
            dataGridView2.Columns["r01cpe"].ReadOnly = true;

            dataGridView2.Columns["r01nom"].DisplayIndex = 1;
            dataGridView2.Columns["r01nom"].HeaderText = "Nombre";
            dataGridView2.Columns["r01nom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.Columns["r01nom"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView2.Columns["r01nom"].Width = 300;
            dataGridView2.Columns["r01nom"].ReadOnly = true;
        }

        
    }
}
