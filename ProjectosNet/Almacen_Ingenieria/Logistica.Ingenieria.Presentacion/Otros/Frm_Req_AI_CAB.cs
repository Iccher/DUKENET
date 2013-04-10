using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Logistica.Ingenieria.Bussiness;

namespace Logistica.Ingenieria.Presentacion.Otros
{
    public partial class Frm_Req_AI_CAB : Form
    {
        public Frm_Req_AI_CAB()
        {
            InitializeComponent();
        }

        BTablas oBusTab = new BTablas();
        DataTable dtCabReq = new DataTable();
        DataView dv1 = new DataView();
        public static Boolean Actualiza = false;
        private void Frm_Req_AI_CAB_Load(object sender, EventArgs e)
        {
            //cboBusqueda.Items.Clear();
            if (Program.nivUsu == "1")
            {
                radioButton2.Checked = true;
                dtCabReq = oBusTab.getRequsicionesAIVAPROBADAS();                
                dgvReq.GridColor = Color.Red;
            }
            else
            {
                radioButton1.Checked = true;
                dtCabReq = oBusTab.getRequsicionesAI();                
                dgvReq.GridColor = Color.Red;
            }
            Grilla();
        }

        void Grilla()
        {
            dgvReq.DataSource = dtCabReq;
            dgvReq.Columns["REQUI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReq.Columns["CODIGO"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReq.Columns["CANPED"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReq.Columns["DISPO"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReq.Columns["CONSU"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReq.Columns["ROTA"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReq.Columns["ANU"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReq.Columns["OC"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReq.Columns["SITU"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvReq.Columns["ESTADO"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;  
            //cboBusqueda.Items.Add("Requisicion");
            //cboBusqueda.Items.Add("Codigo");
            //cboBusqueda.Items.Add("O/C");
        }

        //void PintarGrilla()
        //{
        //    dgvReq.GridColor = Color.Red;  
        //    for (int i = 0; i <= dgvReq.Rows.Count - 1; i++)
        //    {
        //        //if (Convert.ToDecimal(dgvReq["CANPED", i].Value.ToString()) == 0) { dgvReq.Rows[i].Cells["CANPED"].Style.Format = "#,###.##"; }
        //        //if (Convert.ToDecimal(dgvReq["DISPO", i].Value.ToString()) == 0) { dgvReq.Rows[i].Cells["DISPO"].Style.Format = "#,###.##"; }
        //        //if (Convert.ToDecimal(dgvReq["CONSU", i].Value.ToString()) == 0) { dgvReq.Rows[i].Cells["CONSU"].Style.Format = "#,###.##"; }
        //        //if (Convert.ToDecimal(dgvReq["ROTA", i].Value.ToString()) == 0) { dgvReq.Rows[i].Cells["ROTA"].Style.Format = "#,###.##"; }
        //        //if (Convert.ToDecimal(dgvReq["ANU", i].Value.ToString()) == 0) { dgvReq.Rows[i].Cells["ANU"].Style.Format = "#,###.##"; }

        //        //if (Convert.ToDecimal(dgvReq["CANPED", i].Value.ToString()) != 0) { dgvReq.Rows[i].Cells["CANPED"].Style.ForeColor = Color.Navy; }
        //        //if (Convert.ToDecimal(dgvReq["DISPO", i].Value.ToString()) != 0) { dgvReq.Rows[i].Cells["DISPO"].Style.ForeColor = Color.Navy; }
        //        //if (Convert.ToDecimal(dgvReq["CONSU", i].Value.ToString()) != 0) { dgvReq.Rows[i].Cells["CONSU"].Style.ForeColor = Color.Maroon; }
        //        //if (Convert.ToDecimal(dgvReq["ROTA", i].Value.ToString()) != 0) { dgvReq.Rows[i].Cells["ROTA"].Style.ForeColor = Color.Maroon; }
        //        //if (Convert.ToDecimal(dgvReq["ANU", i].Value.ToString()) != 0) { dgvReq.Rows[i].Cells["ANU"].Style.ForeColor = Color.SeaGreen; }
        //    }
        //}

        private void dgvReq_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int p = dgvReq.CurrentRow.Index;
                Otros.Frm_Req_Ingenieria frm = new Frm_Req_Ingenieria();
                frm.NroReq = dgvReq.Rows[p].Cells["REQUI"].Value.ToString();
                frm.CodProd = dgvReq.Rows[p].Cells["CODIGO"].Value.ToString();
                frm.DesProd = dgvReq.Rows[p].Cells["DESCRI"].Value.ToString();
                frm.CanPed = Convert.ToDecimal(dgvReq.Rows[p].Cells["CANPED"].Value.ToString());
                frm.Fecha = dgvReq.Rows[p].Cells["FECHA"].Value.ToString();
                frm.Stock = Convert.ToDecimal(dgvReq.Rows[p].Cells["DISPO"].Value.ToString());
                frm.StockMAX = Convert.ToDecimal(dgvReq.Rows[p].Cells["SMAX"].Value.ToString());
                frm.StockMIN = Convert.ToDecimal(dgvReq.Rows[p].Cells["SMIN"].Value.ToString());
                frm.StockEME = Convert.ToDecimal(dgvReq.Rows[p].Cells["SEMER"].Value.ToString());
                frm.Situ = dgvReq.Rows[p].Cells["SITU"].Value.ToString();
                frm.Rot = dgvReq.Rows[p].Cells["ROTA"].Value.ToString();
                frm.Estado = dgvReq.Rows[p].Cells["Estado"].Value.ToString();
                frm.ShowDialog();
            }
        }

        DataView dv = new DataView();
        private void cboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboBusqueda.SelectedIndex)
            {
                case 0:
                    dv = new DataView(dtCabReq, "", "RQCCVE ASC", DataViewRowState.OriginalRows);
                    dgvReq.DataSource = dv;
                    break;
                case 1:
                    dv = new DataView(dtCabReq, "", "ARTCOD ASC", DataViewRowState.OriginalRows);
                    dgvReq.DataSource = dv;
                    break;
                case 2:
                    dv = new DataView(dtCabReq, "", "OCOCVE DESC", DataViewRowState.OriginalRows);
                    dgvReq.DataSource = dv;
                    break;
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            switch (cboBusqueda.SelectedIndex)
            {
                case 0:
                    dv = new DataView(dtCabReq, "RQCCVE like '%" + txtBusqueda.Text.ToString() + "%'", "RQCCVE ASC", DataViewRowState.OriginalRows);
                    dgvReq.DataSource = dv;
                    break;
                case 1:
                    dv = new DataView(dtCabReq, "ARTCOD like '" + txtBusqueda.Text.ToString() + "%'", "ARTCOD ASC", DataViewRowState.OriginalRows);
                    dgvReq.DataSource = dv;
                    break;
                case 2:
                    dv = new DataView(dtCabReq, "OCOCVE like '%" + txtBusqueda.Text.ToString() + "%'", "OCOCVE DESC", DataViewRowState.OriginalRows);
                    dgvReq.DataSource = dv;
                    break;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (radioButton1.Checked == true)
            {
                dtCabReq = oBusTab.getRequsicionesAI();
                //cboBusqueda.Items.Clear();
                Grilla();
                dgvReq.GridColor = Color.Red; 
            }
            this.Cursor = Cursors.Default;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (radioButton2.Checked == true)
            {
                dtCabReq = oBusTab.getRequsicionesAIVAPROBADAS();
                //cboBusqueda.Items.Clear();
                Grilla();
                dgvReq.GridColor = Color.Red;
            }
            this.Cursor = Cursors.Default;
        }

        private void Frm_Req_AI_CAB_Activated(object sender, EventArgs e)
        {
            if (Actualiza == true)
            {
                //cboBusqueda.Items.Clear();  
                this.Cursor = Cursors.WaitCursor;
                if (Program.nivUsu == "1")
                {
                    radioButton2.Checked = true;
                    dtCabReq = oBusTab.getRequsicionesAIVAPROBADAS();
                    //cboBusqueda.Items.Clear();                    
                    dgvReq.GridColor = Color.Red;
                }
                else
                {
                    radioButton1.Checked = true;
                    dtCabReq = oBusTab.getRequsicionesAI();
                    //cboBusqueda.Items.Clear();
                    dgvReq.GridColor = Color.Red;
                }
                Grilla();
                this.Cursor = Cursors.Default;
            }
            Actualiza = false;
        }

        private void Frm_Req_AI_CAB_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

    }
}
