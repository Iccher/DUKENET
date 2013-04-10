using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Logistica.Ingenieria.Bussiness;


namespace Logistica.Ingenieria.Presentacion.Consultas
{
    public partial class Frm_Consulta_Requerimientos : Form
    {
        public Frm_Consulta_Requerimientos()
        {
            InitializeComponent();
        }


        BTransaccion obTran = new BTransaccion();

        DataTable dtRepuestos = new DataTable();
        DataView dv = new DataView();

        string vTurno = "";

        string CHEKED = "";

        private void Frm_Consulta_Requerimientos_Load(object sender, EventArgs e)
        {
            CHEKED = "'X Generar','Generado Parcial','x Firma Sup.','x Firma Jef.','x Firma Ger.','Generado'";
            CargaGrilla();
            cboBusqueda.SelectedIndex = 1;
            txtBusqueda.Focus();
        }

        void CargaGrilla()
        {
            dgvRequerimientos.GridColor = Color.Red;
            //switch (Program.nivUsu)
            //{
            //    case "3":
            //        //dgvRequerimientos.DataSource = obTran.getConReqArmadoSup(Program.dtCCostos, Program.dtEmpleados, "'1'", "");
            //        obTran = new BTransaccion();
            //        dtRepuestos = obTran.getConReqArmadoSup(Program.dtCCostos, Program.dtEmpleados, "'1'", "");
            //        break;
            //    case "2":
            //        //dgvRequerimientos.DataSource = obTran.getConReqArmadoSup(Program.dtCCostos, Program.dtEmpleados, "'2'", "J");
            //        obTran = new BTransaccion();
            //        //dtRepuestos = obTran.getConReqArmadoSup(Program.dtCCostos, Program.dtEmpleados, "'2'", "J");
            //        dtRepuestos = obTran.getConReqArmadoSup(Program.dtCCostos, Program.dtEmpleados, "'2'", "");
            //        break;
            //    case "1":
            //        //dgvRequerimientos.DataSource = obTran.getConReqArmadoSup(Program.dtCCostos, Program.dtEmpleados, "'3'", "G");
            //        obTran = new BTransaccion();
            //        //dtRepuestos = obTran.getConReqArmadoSup(Program.dtCCostos, Program.dtEmpleados, "'3'", "G");
            //        dtRepuestos = obTran.getConReqArmadoSup(Program.dtCCostos, Program.dtEmpleados, "'3'", "");
            //        break;
            //    case "5":
            //        obTran = new BTransaccion();
            //        dtRepuestos = obTran.getConReqArmadoSup(Program.dtCCostos, Program.dtEmpleados, "'1','2','3','D','SP'", "");
            //        break;
            //}

            obTran = new BTransaccion();
            dtRepuestos = obTran.getConReqArmadoSupFORCONSULTA(Program.dtCCostos, Program.dtEmpleados, "'1','2','3','D','SP','S'", "");
            Grilla();
        }

        void Grilla()
        {
            cboBusqueda.Items.Clear();
            cboBusqueda.Items.Add("Nro.Req");
            cboBusqueda.Items.Add("Solicitante");
            dgvRequerimientos.DataSource = dtRepuestos;

            dgvRequerimientos.Columns["vCodTurno"].Visible = false;
            dgvRequerimientos.Columns["vCodArea"].Visible = false;
            dgvRequerimientos.Columns["vCodAutoriz"].Visible = false;
            dgvRequerimientos.Columns["vCodSolicitud"].Visible = false;
            dgvRequerimientos.Columns["vCodOrdenTrabajo"].Visible = false;
            dgvRequerimientos.Columns["vCodAutorizaSupervisor"].Visible = false;
            dgvRequerimientos.Columns["Recepcion"].Visible = false;
            dgvRequerimientos.Columns["Supervisor"].Visible = false;
            dgvRequerimientos.Columns["Jefe"].Visible = false;
            dgvRequerimientos.Columns["Gerente"].Visible = false;

            dgvRequerimientos.Columns["NROSAL"].Visible = false;
            dgvRequerimientos.Columns["STATUS"].Visible = false;
            dgvRequerimientos.Columns["ESTADO"].Visible = false;
            dgvRequerimientos.Columns["DESSTA"].Visible = false;


            dgvRequerimientos.Columns["NROREQ"].DisplayIndex = 0;
            dgvRequerimientos.Columns["FECREQ"].DisplayIndex = 1;
            dgvRequerimientos.Columns["TURREQ"].DisplayIndex = 2;
            dgvRequerimientos.Columns["AREREQ"].DisplayIndex = 3;
            dgvRequerimientos.Columns["SOLREQ"].DisplayIndex = 4;
            dgvRequerimientos.Columns["ORDREQ"].DisplayIndex = 5;
            dgvRequerimientos.Columns["DESCRIPESTADO"].DisplayIndex = 6;

            dgvRequerimientos.Columns["NROREQ"].HeaderText = "Nro.Req.";
            dgvRequerimientos.Columns["FECREQ"].HeaderText = "Fecha Req.";
            dgvRequerimientos.Columns["TURREQ"].HeaderText = "Turno";
            dgvRequerimientos.Columns["AREREQ"].HeaderText = "Area";
            dgvRequerimientos.Columns["SOLREQ"].HeaderText = "Solicitante";
            dgvRequerimientos.Columns["ORDREQ"].HeaderText = "Ord. Trabajo";
            dgvRequerimientos.Columns["DESCRIPESTADO"].HeaderText = "Situacion";

            dgvRequerimientos.Columns["NROREQ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequerimientos.Columns["FECREQ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequerimientos.Columns["TURREQ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequerimientos.Columns["AREREQ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequerimientos.Columns["SOLREQ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequerimientos.Columns["ORDREQ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequerimientos.Columns["DESCRIPESTADO"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvRequerimientos.Columns["NROREQ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequerimientos.Columns["FECREQ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequerimientos.Columns["TURREQ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRequerimientos.Columns["AREREQ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRequerimientos.Columns["SOLREQ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRequerimientos.Columns["ORDREQ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRequerimientos.Columns["DESCRIPESTADO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvRequerimientos.Columns["NROREQ"].Width = 90;
            dgvRequerimientos.Columns["FECREQ"].Width = 90;
            dgvRequerimientos.Columns["TURREQ"].Width = 80;
            dgvRequerimientos.Columns["AREREQ"].Width = 220;
            dgvRequerimientos.Columns["SOLREQ"].Width = 220;
            dgvRequerimientos.Columns["ORDREQ"].Width = 300;
            dgvRequerimientos.Columns["DESCRIPESTADO"].Width = 100;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            dgvRequerimientos.GridColor = Color.Red;
            switch (cboBusqueda.SelectedIndex)
            {
                case 0:
                    dv = new DataView(dtRepuestos);
                    dv.RowFilter = "NROREQ like '%" + txtBusqueda.Text.ToString() + "%'  and DESCRIPESTADO in (" + CHEKED + ")";
                    dgvRequerimientos.DataSource = dv;
                    break;
                case 1:
                    dv = new DataView(dtRepuestos);
                    dv.RowFilter = "SOLREQ like '%" + txtBusqueda.Text.ToString() + "%'  and DESCRIPESTADO in (" + CHEKED + ")";
                    dgvRequerimientos.DataSource = dv;
                    break;
            }
        }

        private void cboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboBusqueda.SelectedIndex)
            {
                case 0:
                    dv = new DataView(dtRepuestos);
                    dv.Sort = "NROREQ ASC";
                    dgvRequerimientos.DataSource = dv;
                    break;
                case 1:
                    dv = new DataView(dtRepuestos);
                    dv.Sort = "SOLREQ ASC";
                    dgvRequerimientos.DataSource = dv;
                    break;
            }
        }

        private void rdb1_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb1.Checked == true)
            {
                CHEKED = "'X Generar','Generado Parcial','x Firma Sup.','x Firma Jef.','x Firma Ger.','Generado'";
                dv = new DataView(dtRepuestos);
                dv.RowFilter = "NROREQ like '%" + txtBusqueda.Text.ToString() + "%' and DESCRIPESTADO in (" + CHEKED + ")";
                dgvRequerimientos.DataSource = dv;
            }
        }

        private void rdb2_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb2.Checked == true)
            {
                CHEKED = "'Generado Parcial','Generado'";
                dv = new DataView(dtRepuestos);
                dv.RowFilter = "NROREQ like '%" + txtBusqueda.Text.ToString() + "%' and DESCRIPESTADO in (" + CHEKED + ")";
                dgvRequerimientos.DataSource = dv;
            }
        }

        private void rdb3_CheckedChanged(object sender, EventArgs e)
        {
            if (rdb3.Checked == true)
            {
                CHEKED = "'X Generar','x Firma Sup.','x Firma Jef.','x Firma Ger.'";
                dv = new DataView(dtRepuestos);
                dv.RowFilter = "NROREQ like '%" + txtBusqueda.Text.ToString() + "%' and DESCRIPESTADO in (" + CHEKED + ")";
                dgvRequerimientos.DataSource = dv;
            }
        }

        private void dgvRequerimientos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int p = dgvRequerimientos.CurrentRow.Index;
                string CONDICION = dgvRequerimientos.Rows[p].Cells["DESCRIPESTADO"].Value.ToString().Trim();

                Consultas.Frm_Cons_Req_Detalle frm = new Consultas.Frm_Cons_Req_Detalle();

                frm.vCodTurno = Convert.ToDecimal(dgvRequerimientos.Rows[p].Cells["vCodTurno"].Value.ToString());
                frm.vCodArea = Convert.ToDecimal(dgvRequerimientos.Rows[p].Cells["vCodArea"].Value.ToString());
                frm.vCodAutoriz = Convert.ToDecimal(dgvRequerimientos.Rows[p].Cells["vCodAutoriz"].Value.ToString());

                frm.vCodAutorizSupervisor = Convert.ToDecimal(dgvRequerimientos.Rows[p].Cells["vCodAutorizaSupervisor"].Value.ToString());

                frm.vCodSolicitud = Convert.ToDecimal(dgvRequerimientos.Rows[p].Cells["vCodSolicitud"].Value.ToString());
                frm.vCodOrdenTrabajo = Convert.ToDecimal(dgvRequerimientos.Rows[p].Cells["vCodOrdenTrabajo"].Value.ToString());
                frm.vArea = dgvRequerimientos.Rows[p].Cells["AREREQ"].Value.ToString();
                frm.vOrdeTrab = dgvRequerimientos.Rows[p].Cells["ORDREQ"].Value.ToString();
                frm.vTurno = dgvRequerimientos.Rows[p].Cells["TURREQ"].Value.ToString();
                frm.vSolic = dgvRequerimientos.Rows[p].Cells["SOLREQ"].Value.ToString();
                frm.vnroSal = dgvRequerimientos.Rows[p].Cells["NROSAL"].Value.ToString();
                frm.vSTATUS = dgvRequerimientos.Rows[p].Cells["STATUS"].Value.ToString();
                frm.vESTADO = dgvRequerimientos.Rows[p].Cells["DESSTA"].Value.ToString();


                frm.vJefe = dgvRequerimientos.Rows[p].Cells["Jefe"].Value.ToString();
                frm.vGerte = dgvRequerimientos.Rows[p].Cells["Gerente"].Value.ToString();
                frm.Recibido = dgvRequerimientos.Rows[p].Cells["Recepcion"].Value.ToString();
                frm.Situacion = dgvRequerimientos.Rows[p].Cells["DESCRIPESTADO"].Value.ToString();
                frm.vSuperv = dgvRequerimientos.Rows[p].Cells["Supervisor"].Value.ToString();


                frm.ShowDialog();
                this.Cursor = Cursors.Default;


            }
            catch { }
        }



    }
}
