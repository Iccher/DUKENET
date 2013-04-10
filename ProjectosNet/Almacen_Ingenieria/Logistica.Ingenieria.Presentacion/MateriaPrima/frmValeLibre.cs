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
    public partial class frmValeLibre : Form
    {
        public frmValeLibre()
        {
            InitializeComponent();
        }

        double stock=0;
        string cuenta="";
        string procedencia="";
        int sw = 0;
        int ins = 0;
        public string fecha;
        NReqMatProd obj = new NReqMatProd();
        TControlVB Control = new TControlVB();
        BindingList<EMateria> gr = new BindingList<EMateria>();
        DataTable dtMp = new DataTable();
        List<EMatReq> matP = new List<EMatReq>();
        EMatReq MP = new EMatReq();
         
        private void frmDescomposicion_Load(object sender, EventArgs e)
        {
           
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
                                    
                                        if (dataGridView1[7, i].Value.ToString() != "")
                                        {
                                            inst = obj.insAlmvsal("LAPDMBF1", "20110217", "1421", nroV.ToString(), nit.ToString(), dtp1.Text, cboTurno.SelectedIndex.ToString(), txtCodAut.Text, txtCodSol.Text, dataGridView1[0, i].Value.ToString(), dataGridView1[9, i].Value.ToString(), dataGridView1[8, i].Value.ToString(), dataGridView1[7, i].Value.ToString());
                                            updS = obj.updStockMP(dataGridView1[7, i].Value.ToString(), dataGridView1[0, i].Value.ToString());
                                            insRP = obj.insRegPed("LAPDMBF1", "20110217", dtp1.Text, dataGridView1[0, i].Value.ToString(), dataGridView1[5, i].Value.ToString(), dataGridView1[7, i].Value.ToString(), "4");
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
                            if (beg == 1)
                            {
                                frmReporte frm = new frmReporte();
                                frm.VALE = nroV.ToString();
                                frm.ShowDialog();
                                ins = 1;
                                int upd = obj.updNroVale(nroV.ToString());
                            }
                            txtCodSol.Text = ""; txtNomSol.Text = ""; txtCodAut.Text = ""; txtNomAut.Text = ""; cboTurno.SelectedIndex = 0;
                            if (inst == 1 && updS == 1 && insRP == 1)
                            {
                                MessageBox.Show("El Vale Libre Nro " + nroV.ToString() + " Ha sido Generado...");
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

        private void button4_Click(object sender, EventArgs e)
        {
            dtMp = obj.LstMP();
            dataGridView3.DataSource = dtMp;
            panel3.Visible = true;
            EstiloGrilla3();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void txtMPCod_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtMp, "MPMCOD LIKE '" + txtMPCod.Text + "%'", "MPMSDI DESC", DataViewRowState.OriginalRows);
            dataGridView3.DataSource = dv;
        }

        private void txtMPdes_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtMp, "MPMDES LIKE '" + txtMPdes.Text + "%'", "MPMSDI DESC", DataViewRowState.OriginalRows);
            dataGridView3.DataSource = dv;
        }

        private void dataGridView3_DoubleClick(object sender, EventArgs e)
        {
            txtCodMateria.Text = dataGridView3[0, dataGridView3.CurrentRow.Index].Value.ToString();
            txtDesMateria.Text = dataGridView3[4, dataGridView3.CurrentRow.Index].Value.ToString();
            stock = Convert.ToDouble(dataGridView3[1, dataGridView3.CurrentRow.Index].Value.ToString());
            cuenta = dataGridView3[2, dataGridView3.CurrentRow.Index].Value.ToString();
            procedencia = dataGridView3[3, dataGridView3.CurrentRow.Index].Value.ToString();
            panel3.Visible = false;
            txtMPCod.Text = "";
            txtMPdes.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtCodMateria.Text != "" && txtDesMateria.Text != "" && txtPesMateria.Text != "")
            {
                List<EVmp02> vmp = new List<EVmp02>();
                vmp = obj.LstVmp02A();

                for (int i = 0; i <= matP.Count - 1; i++)
                {
                    if (matP[i].Cod_materia.ToString() == txtCodMateria.Text)
                    {
                        matP.RemoveAt(i);
                    }
                }

                MP = new EMatReq();

                MP.Cod_materia = txtCodMateria.Text;
                MP.Des_materia = txtDesMateria.Text;
                MP.Peso_neto = Convert.ToDouble(txtPesMateria.Text);
                MP.Peso_merma = (Convert.ToDouble(txtPesMateria.Text) * 0.0144369).ToString();
                MP.Peso_exed = (Convert.ToDouble(txtPesMateria.Text) * 0.004424).ToString();
                MP.Canpro = Convert.ToDouble(txtPesMateria.Text);

                if (vmp.Count > 0)
                {
                    for (int t = 0; t <= vmp.Count - 1; t++)
                    {
                        if (txtCodMateria.Text == vmp[t].Vmpcod.ToString())
                        {
                            MP.Vmpdif = Convert.ToDouble(vmp[t].Vmpdif.ToString());
                        }
                        else
                        {
                            MP.Vmpdif = 0;
                        }
                        if (MP.Vmpdif > 0)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    MP.Vmpdif = 0;
                }

                MP.Peso_total = MP.Canpro - MP.Vmpdif;
                MP.Cuenta = cuenta.ToString();
                MP.Procedencia = procedencia.ToString();
                MP.Stock = stock;
                MP.Req = MP.Peso_total;

                matP.Add(MP);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = matP;
                EstiloGrilla();
                txtCodMateria.Text = "";
                txtDesMateria.Text = "";
                txtPesMateria.Text = "";
            }
        }

        private void txtPesMateria_KeyPress(object sender, KeyPressEventArgs e)
        {
            Control.NumeroDec(e, txtPesMateria);
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
            dataGridView1.Columns["peso_total"].DefaultCellStyle.Format = "#,###.##";

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
            dataGridView1.Columns["req"].DefaultCellStyle.Format = "#,###.##";

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

        private void EstiloGrilla3()
        {
            dataGridView3.Columns["MPMCOD"].DisplayIndex = 0;
            dataGridView3.Columns["MPMCOD"].HeaderText = "Codigo";
            dataGridView3.Columns["MPMCOD"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView3.Columns["MPMCOD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView3.Columns["MPMCOD"].Width = 120;
            dataGridView3.Columns["MPMCOD"].ReadOnly = true;

            dataGridView3.Columns["MPMDES"].DisplayIndex = 1;
            dataGridView3.Columns["MPMDES"].HeaderText = "Descripción";
            dataGridView3.Columns["MPMDES"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView3.Columns["MPMDES"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridView3.Columns["MPMDES"].Width = 300;
            dataGridView3.Columns["MPMDES"].ReadOnly = true;

            dataGridView3.Columns["MPMSDI"].DisplayIndex = 2;
            dataGridView3.Columns["MPMSDI"].HeaderText = "Stock";
            dataGridView3.Columns["MPMSDI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView3.Columns["MPMSDI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridView3.Columns["MPMSDI"].Width = 100;
            dataGridView3.Columns["MPMSDI"].ReadOnly = true;
            dataGridView3.Columns["MPMSDI"].DefaultCellStyle.Format = "#,###.##";

            dataGridView3.Columns["MPMCTA"].Visible = false;
            dataGridView3.Columns["MPMPRO"].Visible = false;
        }

    }
}
