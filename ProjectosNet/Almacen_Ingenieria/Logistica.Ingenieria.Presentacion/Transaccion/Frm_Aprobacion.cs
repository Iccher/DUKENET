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
    public partial class Frm_Aprobacion : Form
    {
        public Frm_Aprobacion()
        {
            InitializeComponent();
        }

        BTransaccion obTran = new BTransaccion();

        DataTable dtRepuestos = new DataTable();
        DataView dv = new DataView();

        public static Boolean Actualiza;

        string vTurno = "";

        private void Frm_Aprobacion_Load(object sender, EventArgs e)
        {
            CargaGrilla();
            cboBusqueda.SelectedIndex = 1;
            txtBusqueda.Focus();
        }


        void ApruebaReqAuto()
        {
            DateTime FechaSis = DateTime.Now; 
            int flag1 = 0;
            decimal fecha = Convert.ToDecimal(FechaSis.ToShortDateString().Substring(6, 4) + FechaSis.ToShortDateString().Substring(3, 2) + FechaSis.ToShortDateString().Substring(0, 2));
            decimal fecha1 = 0;
            string flag = "";
            decimal Soles = 0;
            decimal ImporteAprob = 0;
            string codReq = "";
            decimal horaJef = 0;
            decimal horaGer = 0;
            decimal HoraActual = 0;
            string sql = "";
            string ESTADO = "";

            if (Convert.ToDecimal(FechaSis.Minute.ToString()) <= 9)
            {
                HoraActual = Convert.ToDecimal(FechaSis.Hour.ToString() + "0" + FechaSis.Minute.ToString());
            }
            else
            {
                HoraActual = Convert.ToDecimal(FechaSis.Hour.ToString() + FechaSis.Minute.ToString());
            }      
            DataTable dtReqxAprAut = new DataTable();
            obTran = new BTransaccion();
            dtReqxAprAut = obTran.getConReqXAprAutomatico();

            for (int i = 0; i <= dtReqxAprAut.Rows.Count - 1; i++)
            {
                vTurno = dtReqxAprAut.Rows[i]["A11TUR"].ToString();
                fecha1 = Convert.ToDecimal(dtReqxAprAut.Rows[i]["A11FSA"].ToString());
                if (vTurno == "1")
                {
                    Soles = Convert.ToDecimal(dtReqxAprAut.Rows[i]["A11IMS"].ToString());
                    ESTADO = dtReqxAprAut.Rows[i]["A11EST"].ToString();
                    codReq = dtReqxAprAut.Rows[i]["A11NSA"].ToString();
                    horaJef = Convert.ToDecimal(dtReqxAprAut.Rows[i]["A11HAJ"].ToString());
                    horaGer = Convert.ToDecimal(dtReqxAprAut.Rows[i]["A11HAG"].ToString());
                    ImporteAprob = Math.Round((Soles / Program.TipoCambio), 2);
                    if (ImporteAprob >= Program.LimSuperv) { flag = "JEF"; }
                    if (ImporteAprob >= Program.LimJefe) { flag = "GER"; }

                    if (fecha1 == fecha)
                    {
                        if (flag == "GER")
                        {
                            if (HoraActual >= horaGer)
                            {
                                obTran = new BTransaccion();
                                sql = "UPDATE " + Program.LibreLALMINGB + ".ALI011UTIL SET A11CA3 = 0, A11UA3 = 'AUTOMATICO',A11FA3 = '" + fecha + "',A11UH3=" + Convert.ToDecimal(HoraActual) + ",A11EST='D' WHERE A11NSA= '" + codReq.Trim() + "'";
                                flag1 = obTran.BUpdateSQL(sql);
                            }
                            else
                            {
                                if ((HoraActual >= horaJef) && ESTADO=="2")
                                {
                                    obTran = new BTransaccion();
                                    sql = "UPDATE " + Program.LibreLALMINGB + ".ALI011UTIL SET A11CA2 = 0, A11UA2 = 'AUTOMATICO',A11FA2 = '" + fecha + "',A11UH2=" + Convert.ToDecimal(HoraActual) + ",A11EST='3' WHERE A11NSA= '" + codReq.Trim() + "'";
                                    flag1 = obTran.BUpdateSQL(sql);
                                }
                                else { }
                            }
                        }
                        if (flag == "JEF")
                        {
                            if (HoraActual >= horaJef)
                            {
                                obTran = new BTransaccion();
                                sql = "UPDATE " + Program.LibreLALMINGB + ".ALI011UTIL SET A11CA2 = 0, A11UA2 = 'AUTOMATICO',A11FA2 = '" + fecha + "',A11UH2=" + Convert.ToDecimal(HoraActual) + ",A11EST='D' WHERE A11NSA= '" + codReq.Trim() + "'";
                                flag1 = obTran.BUpdateSQL(sql);
                            }
                            else { }
                        }
                    }
                    else
                    {
                        if (flag == "GER")
                        {
                            obTran = new BTransaccion();
                            sql = "UPDATE " + Program.LibreLALMINGB + ".ALI011UTIL SET A11CA3 = 0, A11UA3 = 'AUTOMATICO',A11FA3 = '" + fecha + "',A11UH3=" + Convert.ToDecimal(HoraActual) + ",A11EST='D' WHERE A11NSA= '" + codReq.Trim() + "'";
                            flag1 = obTran.BUpdateSQL(sql);
                        }
                        if (flag == "JEF")
                        {
                            obTran = new BTransaccion();
                            sql = "UPDATE " + Program.LibreLALMINGB + ".ALI011UTIL SET A11CA2 = 0, A11UA2 = 'AUTOMATICO',A11FA2 = '" + fecha + "',A11UH2=" + Convert.ToDecimal(HoraActual) + ",A11EST='D' WHERE A11NSA= '" + codReq.Trim() + "'";
                            flag1 = obTran.BUpdateSQL(sql);
                        }
                    }
                }
            }
        }




        void CargaGrilla()
        {
            dgvRequerimientos.GridColor = Color.Red;
            switch (Program.nivUsu)
            {
                case "3":
                    //dgvRequerimientos.DataSource = obTran.getConReqArmadoSup(Program.dtCCostos, Program.dtEmpleados, "'1'", "");
                    //ApruebaReqAuto();
                    obTran = new BTransaccion();
                    dtRepuestos = obTran.getConReqArmadoSup(Program.dtCCostos, Program.dtEmpleados, "'1'", "",Program.dtCCostoLaborales);
                    break;
                case "2":
                    //dgvRequerimientos.DataSource = obTran.getConReqArmadoSup(Program.dtCCostos, Program.dtEmpleados, "'2'", "J");
                    //ApruebaReqAuto();
                    obTran = new BTransaccion();
                    //dtRepuestos = obTran.getConReqArmadoSup(Program.dtCCostos, Program.dtEmpleados, "'2'", "J");
                    dtRepuestos = obTran.getConReqArmadoJEFATURA(Program.dtCCostos, Program.dtEmpleados, "'2'", "", Program.SUPERVISORES);
                    break;
                case "1":
                    //dgvRequerimientos.DataSource = obTran.getConReqArmadoSup(Program.dtCCostos, Program.dtEmpleados, "'3'", "G");
                    //ApruebaReqAuto();
                    obTran = new BTransaccion();
                    //dtRepuestos = obTran.getConReqArmadoSup(Program.dtCCostos, Program.dtEmpleados, "'3'", "G");
                    dtRepuestos = obTran.getConReqArmadoSup(Program.dtCCostos, Program.dtEmpleados, "'3'", "", Program.dtCCostoLaborales);
                    break;
                case "5":
                    //dgvRequerimientos.DataSource = obTran.getConReqArmadoSup(Program.dtCCostos, Program.dtEmpleados, "'D','SP'", "");
                    ApruebaReqAuto();
                    obTran = new BTransaccion();
                    dtRepuestos = obTran.getConReqArmadoSup(Program.dtCCostos, Program.dtEmpleados, "'1','2','3','D','SP'", "", Program.dtCCostoLaborales);
                    break;
            }
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
            dgvRequerimientos.Columns["FECREQ"].HeaderText = "Fec.Req.";
            dgvRequerimientos.Columns["TURREQ"].HeaderText = "Turno";
            dgvRequerimientos.Columns["AREREQ"].HeaderText = "Area";
            dgvRequerimientos.Columns["SOLREQ"].HeaderText = "Solicitante";
            dgvRequerimientos.Columns["ORDREQ"].HeaderText = "Orden";
            dgvRequerimientos.Columns["DESCRIPESTADO"].HeaderText = "Situacion";

            dgvRequerimientos.Columns["NROREQ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequerimientos.Columns["FECREQ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequerimientos.Columns["TURREQ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequerimientos.Columns["AREREQ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequerimientos.Columns["SOLREQ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequerimientos.Columns["ORDREQ"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequerimientos.Columns["DESCRIPESTADO"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvRequerimientos.Columns["NROREQ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRequerimientos.Columns["FECREQ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequerimientos.Columns["TURREQ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRequerimientos.Columns["AREREQ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRequerimientos.Columns["SOLREQ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRequerimientos.Columns["ORDREQ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvRequerimientos.Columns["DESCRIPESTADO"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvRequerimientos.Columns["NROREQ"].Width = 130;
            dgvRequerimientos.Columns["FECREQ"].Width = 80;
            dgvRequerimientos.Columns["TURREQ"].Width = 70;
            dgvRequerimientos.Columns["AREREQ"].Width = 220;
            dgvRequerimientos.Columns["SOLREQ"].Width = 220;
            dgvRequerimientos.Columns["ORDREQ"].Width = 300;
            dgvRequerimientos.Columns["DESCRIPESTADO"].Width = 80;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvRequerimientos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;                
                int p = dgvRequerimientos.CurrentRow.Index;

                string CONDICION = dgvRequerimientos.Rows[p].Cells["DESCRIPESTADO"].Value.ToString().Trim();

                if ((Program.nivUsu != "5") || (CONDICION == "x Firma Sup." || CONDICION == "x Firma Jef." || CONDICION == "x Firma Ger."))
                {
                    Transaccion.Frm_Aprobacion_Detalle frm = new Logistica.Ingenieria.Presentacion.Transaccion.Frm_Aprobacion_Detalle();
                    frm.vArea = dgvRequerimientos.Rows[p].Cells["AREREQ"].Value.ToString();
                    frm.vOrdeTrab = dgvRequerimientos.Rows[p].Cells["ORDREQ"].Value.ToString();
                    frm.vTurno = dgvRequerimientos.Rows[p].Cells["TURREQ"].Value.ToString();
                    frm.vSolic = dgvRequerimientos.Rows[p].Cells["SOLREQ"].Value.ToString();
                    frm.vnroSal = dgvRequerimientos.Rows[p].Cells["NROSAL"].Value.ToString();
                    frm.vSTATUS = dgvRequerimientos.Rows[p].Cells["STATUS"].Value.ToString();
                    frm.vESTADO = dgvRequerimientos.Rows[p].Cells["DESSTA"].Value.ToString();
                    frm.vNroOrdeTrab = dgvRequerimientos.Rows[p].Cells["vCodOrdenTrabajo"].Value.ToString();
                    
                    frm.ShowDialog();
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    Transaccion.Frm_Generacion_Vale frm = new Logistica.Ingenieria.Presentacion.Transaccion.Frm_Generacion_Vale();

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

                    frm.vPARCIALES = dgvRequerimientos.Rows[p].Cells["DESCRIPESTADO"].Value.ToString();
                    frm.vNroOrdeTrab = dgvRequerimientos.Rows[p].Cells["vCodOrdenTrabajo"].Value.ToString();
                    frm.ShowDialog();
                    this.Cursor = Cursors.Default;
                }
            }
            catch { }
        }

        private void Frm_Aprobacion_Activated(object sender, EventArgs e)
        {
            if (Actualiza == true)
            {
                CargaGrilla();
                Actualiza = false;
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

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            dgvRequerimientos.GridColor = Color.Red;
            switch (cboBusqueda.SelectedIndex)
            {
                case 0:
                    dv = new DataView(dtRepuestos);
                    dv.RowFilter = "NROREQ like '%" + txtBusqueda.Text.ToString() + "%'";
                    dgvRequerimientos.DataSource = dv;
                    break;
                case 1:
                    dv = new DataView(dtRepuestos);
                    dv.RowFilter = "SOLREQ like '%" + txtBusqueda.Text.ToString() + "%'";
                    dgvRequerimientos.DataSource = dv;
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            CargaGrilla();
            cboBusqueda.SelectedIndex = 1;
            txtBusqueda.Focus();
            this.Cursor = Cursors.Default;
        }

        private void Frm_Aprobacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void dgvRequerimientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
