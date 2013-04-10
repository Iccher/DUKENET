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
    public partial class Frm_Aprobacion_Firma_Electronica : Form
    {
        public Frm_Aprobacion_Firma_Electronica()
        {
            InitializeComponent();
        }
        
        BTablas obTran = new BTablas();
        DataTable dtAprobacionVale = new DataTable();
        DataView dv = new DataView();
        public static Boolean Actualiza;


        private void Frm_Aprobacion_Firma_Electronica_Load(object sender, EventArgs e)
        {
            Actualiza = false;

            obTran = new BTablas();
            dtAprobacionVale = obTran.getSELECTLIBRE("SELECT A13NSA,CAST(A13NVS AS CHAR(10)) AS A13NVS,A13FVS,IFNULL(MPSCOR,0) MPSCOR,IFNULL(R01NOM,'') R01NOM, " +
" IFNULL(U1.NOMEMP,'') AS NOMEMP1,A13EST,IFNULL(U2.NOMEMP,'') AS NOMEMP2 " +
" FROM " + Program.LibreLALMINGB + ".ALI013UTIL LEFT OUTER JOIN " +
" " + Program.LibreLALMINGB + ".ALMVSAL ON A13NVS=MPSNSA LEFT OUTER JOIN " +
" LRIPB.RIPMGEN ON MPSCOR=R01CPE LEFT OUTER JOIN " +
" " + Program.LibreLALMINGB + ".ALIUSERS U1 ON A13UDE=U1.CODUSE LEFT OUTER JOIN " +
" " + Program.LibreLALMINGB + ".ALIUSERS U2 ON A13URE=U2.CODUSE " +
" GROUP BY A13NSA,A13NVS,MPSCOR,R01NOM,U1.NOMEMP,A13EST,A13FVS,U2.NOMEMP " +
" ORDER BY A13NVS");
            CargaGrilla();
        }

        void CargaGrilla()
        {
            dgvRequerimientos.GridColor = Color.Red;
            dv = new DataView(dtAprobacionVale, "A13EST=''", "A13FVS DESC", DataViewRowState.OriginalRows);
            dgvRequerimientos.DataSource = dv;
            cboBusqueda.Items.Clear();
            cboBusqueda.Items.Add("Requerimiento");
            cboBusqueda.Items.Add("Nro Vale");

            dgvRequerimientos.Columns["A13NSA"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequerimientos.Columns["A13NVS"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequerimientos.Columns["A13FVS"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequerimientos.Columns["R01NOM"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequerimientos.Columns["NOMEMP1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequerimientos.Columns["NOMEMP2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        private void rdb1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdb1.Checked == true)
                {
                    switch (cboBusqueda.SelectedIndex)
                    {
                        case 0:
                            dv = new DataView(dtAprobacionVale, "A13NSA LIKE '%" + txtBusqueda.Text.Trim() + "%' AND A13EST<>''", "A13FVS DESC", DataViewRowState.OriginalRows);
                            dgvRequerimientos.DataSource = dv;
                            break;
                        case 1:
                            dv = new DataView(dtAprobacionVale, "A13NVS LIKE '%" + txtBusqueda.Text.Trim() + "%' AND A13EST<>''", "A13FVS DESC", DataViewRowState.OriginalRows);
                            dgvRequerimientos.DataSource = dv;
                            break;
                        default:
                            dv = new DataView(dtAprobacionVale, "A13EST<>''", "A13FVS DESC", DataViewRowState.OriginalRows);
                            dgvRequerimientos.DataSource = dv;
                            break;
                    }
                }                
            }
            catch { }
        }


        private void rdb2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdb2.Checked == true)
                {
                    switch (cboBusqueda.SelectedIndex)
                    {
                        case 0:
                            dv = new DataView(dtAprobacionVale, "A13NSA LIKE '%" + txtBusqueda.Text.Trim() + "%' AND A13EST=''", "A13FVS DESC", DataViewRowState.OriginalRows);
                            dgvRequerimientos.DataSource = dv;
                            break;
                        case 1:
                            dv = new DataView(dtAprobacionVale, "A13NVS LIKE '%" + txtBusqueda.Text.Trim() + "%' AND A13EST=''", "A13FVS DESC", DataViewRowState.OriginalRows);
                            dgvRequerimientos.DataSource = dv;
                            break;
                        default:
                            dv = new DataView(dtAprobacionVale, "A13EST=''", "A13FVS DESC", DataViewRowState.OriginalRows);
                            dgvRequerimientos.DataSource = dv;
                            break;
                    }
                }
            }
            catch { }
        }

        private void rdb3_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb3.Checked == true)
            {
                switch (cboBusqueda.SelectedIndex)
                {
                    case 0:
                        dv = new DataView(dtAprobacionVale, "A13NSA LIKE '%" + txtBusqueda.Text.Trim() + "%'", "A13FVS DESC", DataViewRowState.OriginalRows);
                        dgvRequerimientos.DataSource = dv;
                        break;
                    case 1:
                        dv = new DataView(dtAprobacionVale, "A13NVS LIKE '%" + txtBusqueda.Text.Trim() + "%'", "A13FVS DESC", DataViewRowState.OriginalRows);
                        dgvRequerimientos.DataSource = dv;
                        break;
                    default:
                        dv = new DataView(dtAprobacionVale, "", "A13FVS DESC", DataViewRowState.OriginalRows);
                        dgvRequerimientos.DataSource = dv;
                        break;
                }
            }
        }




        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (rdb1.Checked == true)
                {
                    switch (cboBusqueda.SelectedIndex)
                    {
                        case 0:
                            dv = new DataView(dtAprobacionVale, "A13NSA LIKE '%" + txtBusqueda.Text.Trim() + "%' AND A13EST<>''", "A13FVS DESC", DataViewRowState.OriginalRows);
                            dgvRequerimientos.DataSource = dv;
                            break;
                        case 1:
                            dv = new DataView(dtAprobacionVale, "A13NVS LIKE '%" + txtBusqueda.Text.Trim() + "%' AND A13EST<>''", "A13FVS DESC", DataViewRowState.OriginalRows);
                            dgvRequerimientos.DataSource = dv;
                            break;
                        default:
                            dv = new DataView(dtAprobacionVale, "A13EST<>''", "A13FVS DESC", DataViewRowState.OriginalRows);
                            dgvRequerimientos.DataSource = dv;
                            break;
                    }
                }

                if (rdb2.Checked == true)
                {
                    switch (cboBusqueda.SelectedIndex)
                    {
                        case 0:
                            dv = new DataView(dtAprobacionVale, "A13NSA LIKE '%" + txtBusqueda.Text.Trim() + "%' AND A13EST=''", "A13FVS DESC", DataViewRowState.OriginalRows);
                            dgvRequerimientos.DataSource = dv;
                            break;
                        case 1:
                            dv = new DataView(dtAprobacionVale, "A13NVS LIKE '%" + txtBusqueda.Text.Trim() + "%' AND A13EST=''", "A13FVS DESC", DataViewRowState.OriginalRows);
                            dgvRequerimientos.DataSource = dv;
                            break;
                        default:
                            dv = new DataView(dtAprobacionVale, "A13EST=''", "A13FVS DESC", DataViewRowState.OriginalRows);
                            dgvRequerimientos.DataSource = dv;
                            break;
                    }
                }

                if (rdb3.Checked == true)
                {
                    switch (cboBusqueda.SelectedIndex)
                    {
                        case 0:
                            dv = new DataView(dtAprobacionVale, "A13NSA LIKE '%" + txtBusqueda.Text.Trim() + "%'", "A13FVS DESC", DataViewRowState.OriginalRows);
                            dgvRequerimientos.DataSource = dv;
                            break;
                        case 1:
                            dv = new DataView(dtAprobacionVale, "A13NVS LIKE '%" + txtBusqueda.Text.Trim() + "%'", "A13FVS DESC", DataViewRowState.OriginalRows);
                            dgvRequerimientos.DataSource = dv;
                            break;
                        default:
                            dv = new DataView(dtAprobacionVale, "", "A13FVS DESC", DataViewRowState.OriginalRows);
                            dgvRequerimientos.DataSource = dv;
                            break;
                    }
                }


            }
            catch { }
        }

        private void cboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtBusqueda.Text = "";
                if (rdb1.Checked == true)
                {
                    switch (cboBusqueda.SelectedIndex)
                    {
                        case 0:
                            dv = new DataView(dtAprobacionVale, "A13EST<>''", "A13NSA DESC", DataViewRowState.OriginalRows);
                            dgvRequerimientos.DataSource = dv;
                            break;
                        case 1:
                            dv = new DataView(dtAprobacionVale, "A13EST<>''", "A13NVS DESC", DataViewRowState.OriginalRows);
                            dgvRequerimientos.DataSource = dv;
                            break;
                    }
                }

                if (rdb2.Checked == true)
                {
                    switch (cboBusqueda.SelectedIndex)
                    {
                        case 0:
                            dv = new DataView(dtAprobacionVale, "A13EST=''", "A13NSA DESC", DataViewRowState.OriginalRows);
                            dgvRequerimientos.DataSource = dv;
                            break;
                        case 1:
                            dv = new DataView(dtAprobacionVale, "A13EST=''", "A13NVS DESC", DataViewRowState.OriginalRows);
                            dgvRequerimientos.DataSource = dv;
                            break;
                    }
                }

                if (rdb3.Checked == true)
                {
                    switch (cboBusqueda.SelectedIndex)
                    {
                        case 0:
                            dv = new DataView(dtAprobacionVale, "", "A13NSA DESC", DataViewRowState.OriginalRows);
                            dgvRequerimientos.DataSource = dv;
                            break;
                        case 1:
                            dv = new DataView(dtAprobacionVale, "", "A13NVS DESC", DataViewRowState.OriginalRows);
                            dgvRequerimientos.DataSource = dv;
                            break;
                    }
                }
            }
            catch { }
            
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            obTran = new BTablas();
            dtAprobacionVale = obTran.getSELECTLIBRE("SELECT A13NSA,CAST(A13NVS AS CHAR(10)) AS A13NVS,A13FVS,IFNULL(MPSCOR,0) MPSCOR,IFNULL(R01NOM,'') R01NOM, " +
" IFNULL(U1.NOMEMP,'') AS NOMEMP1,A13EST,IFNULL(U2.NOMEMP,'') AS NOMEMP2 " +
" FROM " + Program.LibreLALMINGB + ".ALI013UTIL LEFT OUTER JOIN " +
" " + Program.LibreLALMINGB + ".ALMVSAL ON A13NVS=MPSNSA LEFT OUTER JOIN " +
" LRIPB.RIPMGEN ON MPSCOR=R01CPE LEFT OUTER JOIN " +
" " + Program.LibreLALMINGB + ".ALIUSERS U1 ON A13UDE=U1.CODUSE LEFT OUTER JOIN " +
" " + Program.LibreLALMINGB + ".ALIUSERS U2 ON A13URE=U2.CODUSE " +
" GROUP BY A13NSA,A13NVS,MPSCOR,R01NOM,U1.NOMEMP,A13EST,A13FVS,U2.NOMEMP " +
" ORDER BY A13NVS");
            CargaGrilla();
            txtBusqueda.Text = "";
            rdb2.Checked = true;
            this.Cursor = Cursors.Default;            

        }

        private void dgvRequerimientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                string nroVale = dgvRequerimientos[1, dgvRequerimientos.CurrentCell.RowIndex].Value.ToString();
                
                Frm_Aprobacion_Firma_Electronica_Detalle frm = new Frm_Aprobacion_Firma_Electronica_Detalle();
                frm.nroVale = Convert.ToDecimal(nroVale);                
                frm.ShowDialog();
            }
        }

        private void Frm_Aprobacion_Firma_Electronica_Activated(object sender, EventArgs e)
        {
            if (Actualiza == true)
            {
                this.Cursor = Cursors.WaitCursor;
                obTran = new BTablas();
                dtAprobacionVale = obTran.getSELECTLIBRE("SELECT A13NSA,CAST(A13NVS AS CHAR(10)) AS A13NVS,A13FVS,IFNULL(MPSCOR,0) MPSCOR,IFNULL(R01NOM,'') R01NOM, " +
    " IFNULL(U1.NOMEMP,'') AS NOMEMP1,A13EST,IFNULL(U2.NOMEMP,'') AS NOMEMP2 " +
    " FROM " + Program.LibreLALMINGB + ".ALI013UTIL LEFT OUTER JOIN " +
    " " + Program.LibreLALMINGB + ".ALMVSAL ON A13NVS=MPSNSA LEFT OUTER JOIN " +
    " LRIPB.RIPMGEN ON MPSCOR=R01CPE LEFT OUTER JOIN " +
    " " + Program.LibreLALMINGB + ".ALIUSERS U1 ON A13UDE=U1.CODUSE LEFT OUTER JOIN " +
    " " + Program.LibreLALMINGB + ".ALIUSERS U2 ON A13URE=U2.CODUSE " +
    " GROUP BY A13NSA,A13NVS,MPSCOR,R01NOM,U1.NOMEMP,A13EST,A13FVS,U2.NOMEMP " +
    " ORDER BY A13NVS");
                CargaGrilla();
                txtBusqueda.Text = "";
                rdb2.Checked = true;

                Actualiza = false;

                this.Cursor = Cursors.Default;   
            }
        }

        

        


    }
}
