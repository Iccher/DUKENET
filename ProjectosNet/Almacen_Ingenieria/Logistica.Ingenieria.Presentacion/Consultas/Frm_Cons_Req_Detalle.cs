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


namespace Logistica.Ingenieria.Presentacion.Consultas
{
    public partial class Frm_Cons_Req_Detalle : Form
    {
        public Frm_Cons_Req_Detalle()
        {
            InitializeComponent();
        }

        public string vSuperv = "";
        public string vJefe = "";
        public string vGerte = "";
        public string Recibido = "";
        public string Situacion = "";


        public decimal vCodTurno = 0;
        public decimal vCodArea = 0;
        public decimal vCodAutoriz = 0;
        public decimal vCodAutorizSupervisor = 0;
        public decimal vCodSolicitud = 0;
        public decimal vCodOrdenTrabajo = 0;


        public string vnroSal = "";
        public string vArea = "";
        public string vOrdeTrab = "";
        public string vTurno = "";
        public string vSolic = "";

        public string vSTATUS = "";
        public string vESTADO = "";
        /**********CODIGO DE RECIBE***********/
        private decimal vCodRecibe = 0;

        /*Calculo de Importes a Aprobar*/
        decimal Soles = 0;
        decimal Dolares = 0;
        decimal ImporteAprob = 0;

        BTransaccion obTran = new BTransaccion();
        TControlVB oControl = new TControlVB();


        private void Frm_Cons_Req_Detalle_Load(object sender, EventArgs e)
        {
            txtSuperv.Text = vSuperv.Trim();
            txtJefe.Text = vJefe.Trim();
            txtGerente.Text = vGerte.Trim();
            txtRecibido.Text = Recibido.Trim();
            txtSitu.Text = Situacion.Trim();

            txtDescripcionDPTO.Text = vOrdeTrab;
            txtDpto.Text = vArea;
            txtSolicitante.Text = vSolic;

            obTran = new BTransaccion();
            dgvDetReq.DataSource = obTran.getConDetalleRequeXCodigo(vnroSal);
            dgvDetReq.GridColor = Color.Red;
            Grilla();
            Totales(); 
        }


        void Grilla()
        {
            dgvDetReq.Columns["A12IMP"].Visible = false;
            dgvDetReq.Columns["A12IMD"].Visible = false;
            dgvDetReq.Columns["A12PRO"].Visible = false;
            dgvDetReq.Columns["A12CTA"].Visible = false;
            dgvDetReq.Columns["A12CCA"].Visible = false;
            dgvDetReq.Columns["MPMSCO"].Visible = false;


            dgvDetReq.Columns["A12COD"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvDetReq.Columns["MPMDES"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvDetReq.Columns["A12CAS"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvDetReq.Columns["A12CAD"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvDetReq.Columns["T01AL1"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvDetReq.Columns["MPMUBI"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvDetReq.Columns["MPMSDI"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvDetReq.Columns["A12COD"].DisplayIndex = 0;
            dgvDetReq.Columns["MPMDES"].DisplayIndex = 1;
            dgvDetReq.Columns["MPMUBI"].DisplayIndex = 2;
            dgvDetReq.Columns["MPMSDI"].DisplayIndex = 3;
            dgvDetReq.Columns["A12CAS"].DisplayIndex = 4;
            dgvDetReq.Columns["A12CAD"].DisplayIndex = 5;
            dgvDetReq.Columns["T01AL1"].DisplayIndex = 6;


            dgvDetReq.Columns["A12COD"].HeaderText = "Codigo";
            dgvDetReq.Columns["MPMDES"].HeaderText = "Descripción";
            dgvDetReq.Columns["MPMUBI"].HeaderText = "Ubicación";
            dgvDetReq.Columns["MPMSDI"].HeaderText = "Stock";
            dgvDetReq.Columns["A12CAS"].HeaderText = "Cant.Solic.";
            dgvDetReq.Columns["A12CAD"].HeaderText = "Cant.Atend.";
            dgvDetReq.Columns["T01AL1"].HeaderText = "Medida";

            dgvDetReq.Columns["A12COD"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["MPMDES"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["MPMUBI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["MPMSDI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["A12CAS"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["A12CAD"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["T01AL1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDetReq.Columns["A12COD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["MPMDES"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDetReq.Columns["MPMUBI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDetReq.Columns["MPMSDI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetReq.Columns["A12CAS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetReq.Columns["A12CAD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetReq.Columns["T01AL1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvDetReq.Columns["MPMSDI"].DefaultCellStyle.BackColor = Color.NavajoWhite;

            dgvDetReq.Columns["A12COD"].ReadOnly = true;
            dgvDetReq.Columns["MPMDES"].ReadOnly = true;
            dgvDetReq.Columns["MPMUBI"].ReadOnly = true;
            dgvDetReq.Columns["MPMSDI"].ReadOnly = true;
            dgvDetReq.Columns["A12CAS"].ReadOnly = true;
            dgvDetReq.Columns["A12CAD"].ReadOnly = true;
            dgvDetReq.Columns["T01AL1"].ReadOnly = true;

            dgvDetReq.Columns["A12COD"].Width = 120;
            dgvDetReq.Columns["MPMDES"].Width = 350;
            dgvDetReq.Columns["MPMUBI"].Width = 105;
            dgvDetReq.Columns["MPMSDI"].Width = 60;
            dgvDetReq.Columns["A12CAS"].Width = 60;
            dgvDetReq.Columns["A12CAD"].Width = 70;
            dgvDetReq.Columns["T01AL1"].Width = 105;

        }

        void Totales()
        {
            for (int i = 0; i <= dgvDetReq.Rows.Count - 1; i++)
            {
                Soles = Soles + Convert.ToDecimal(dgvDetReq["A12IMP", i].Value.ToString());
                Dolares = Dolares + Convert.ToDecimal(dgvDetReq["A12IMD", i].Value.ToString());
            }
            ImporteAprob = Math.Round((Soles / Program.TipoCambio), 2);

            txtSoles.Text = Convert.ToString(Soles);
            txtDolares.Text = Convert.ToString(Dolares);
            txtImpAprob.Text = Convert.ToString(ImporteAprob);
        }
    }
}
