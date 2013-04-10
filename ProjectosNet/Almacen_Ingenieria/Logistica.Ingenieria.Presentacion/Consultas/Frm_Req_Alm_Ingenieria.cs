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
    public partial class Frm_Req_Alm_Ingenieria : Form
    {
        public Frm_Req_Alm_Ingenieria()
        {
            InitializeComponent();
        }

        BTablas objTablas = new BTablas();

        string SQL;
        DataTable dtRequisiciones = new DataTable();
        DataTable dtRequiVista = new DataTable();
        TControlVB oUtils = new TControlVB();

        DataView Busqueda = new DataView();

        private void Frm_Req_Alm_Ingenieria_Load(object sender, EventArgs e)
        {
            dgvRequisicones.GridColor = Color.Red;


            //SQL = "SELECT " +
            //    " M.MPMCOD,M.MPMDES,D.RQCCVE,D.RQCSEQ, " +
            //    " D.RQCFES,D.RQCCAN,D.RQCVD1,T.ARTUPC, " +
            //    " D.OCOCVE,D.RQCSID,D.RQCCMT,M.MPMUNI, " +
            //    " M.MPMSCO,MPMSDI,M.MPMPRO,M.MPMSMX,M.MPMSMN,L.DAACVE " +
            //    " FROM " + Program.LibreADAMAD2 + ".TRQCD D," + Program.LibreADAMAD2 + ".TRQCH H," + Program.LibreLALMINGB + ".ALMMMAP M," + Program.LibreADAMAD2 + ".TRLAA L," + Program.LibreADAMAD2 + ".TARTI T " +
            //    " WHERE " +
            //    " D.RQCCVE=H.RQCCVE AND " +
            //    " D.ARTCOD=M.MPMCOD AND " +
            //    " D.ARTCOD=L.ARTCOD AND " +
            //    " D.ARTCOD=T.ARTCOD AND " +
            //    " L.AGACVE='PRO' AND " +
            //    " D.ALMCVE = '4' AND " +
            //    " D.RQCSID NOT IN ('Surtida','Cancel.')";

            SQL = "SELECT " +
                    " M.MPMCOD,M.MPMDES,IFNULL(W.MIDEA1,'') AS DES1,IFNULL(W.MIDEA2,'') AS DES2,IFNULL(W.MIDEA3,'') AS DES3,IFNULL(W.MIDEA4,'') AS DES4,IFNULL(W.MIDEA5,'') AS DES5,IFNULL(W.MIDEA6,'') AS DES6,D.RQCCVE,D.RQCSEQ, " +
                    " D.RQCFES,D.RQCCAN,D.RQCVD1,T.ARTUPC, " +
                    " D.OCOCVE,D.RQCSID,D.RQCCMT,M.MPMUNI, " +
                    " M.MPMSCO,MPMSDI,M.MPMPRO,M.MPMSMX,M.MPMSMN,L.DAACVE " +
                    " FROM " + Program.LibreADAMAD2 + ".TRQCD D," + Program.LibreADAMAD2 + ".TRQCH H," + Program.LibreLALMINGB + ".ALMMMAP M," + Program.LibreADAMAD2 + ".TRLAA L," + Program.LibreADAMAD2 + ".TARTI T," + Program.LibreLALMINGB + ".ALMWCON W " +
                    " WHERE " +
                    " D.RQCCVE=H.RQCCVE AND " +
                    " D.ARTCOD=M.MPMCOD AND " +
                    " D.ARTCOD=W.MIMCOD AND " +
                    " D.ARTCOD=L.ARTCOD AND " +
                    " D.ARTCOD=T.ARTCOD AND " +
                    " L.AGACVE='PRO' AND " +
                    " D.ALMCVE = '4' AND " +
                    " D.RQCSID NOT IN ('Surtida','Cancel.')";


            objTablas = new BTablas();
            dtRequisiciones = objTablas.getSELECTLIBRE(SQL);
            objTablas = new BTablas();
            dtRequiVista = objTablas.getRequisicionesAI(dtRequisiciones, Program.dtUnidMed, Program.dtDescripcionesAdicionales, Program.dtGrupos, Program.dtSubGrupos);


            Grilla();
            //label1.Text = Busqueda.Count.ToString();
            cboBusqueda2.Location = new Point(523, 114);
        }

        void Grilla()
        {                        
            Busqueda = new DataView(dtRequiVista);
            dgvRequisicones.DataSource = Busqueda;

            dgvRequisicones.Columns["Item"].Visible = false;

            dgvRequisicones.Columns["Codigo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequisicones.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequisicones.Columns["Requisicion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequisicones.Columns["FechaReq"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequisicones.Columns["Cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequisicones.Columns["Precio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequisicones.Columns["ValorUCom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequisicones.Columns["OC"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequisicones.Columns["Situacion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequisicones.Columns["Detalle"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequisicones.Columns["Grupo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequisicones.Columns["UndMedida"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequisicones.Columns["Stock"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequisicones.Columns["Procedencia"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequisicones.Columns["TipoCompra"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequisicones.Columns["StockMAX"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequisicones.Columns["StockMIN"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequisicones.Columns["Subgrupo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRequisicones.Columns["Descripcion_Detallada"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            cboBusqueda.Items.Clear();
            cboBusqueda.Items.Add("Codigo");
            cboBusqueda.Items.Add("Descripción");
            cboBusqueda.Items.Add("Fecha Req.");
            cboBusqueda.Items.Add("Situacion");
            cboBusqueda.Items.Add("Stock");

            label1.Text = Busqueda.Count.ToString();


        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            oUtils.DataTableToExcelDATAGRIDVIEW(dgvRequisicones);
            this.Cursor = Cursors.Default;
        }

        private void chkImp_CheckedChanged(object sender, EventArgs e)
        {
            if (chkImp.Checked == true && chkNacionales.Checked == true)
            {
                Busqueda = new DataView(dtRequiVista);
                dgvRequisicones.DataSource = Busqueda;                
            }
            if (chkImp.Checked == true && chkNacionales.Checked == false)
            {
                Busqueda = new DataView(dtRequiVista);
                Busqueda.RowFilter = "TipoCompra in ('Imp')";           
                dgvRequisicones.DataSource = Busqueda;
            }
            if (chkImp.Checked == false && chkNacionales.Checked == true)
            {
                Busqueda = new DataView(dtRequiVista);
                Busqueda.RowFilter = "TipoCompra not in ('Imp')";
                dgvRequisicones.DataSource = Busqueda;
            }
            if (chkImp.Checked == false && chkNacionales.Checked == false)
            {
                Busqueda = new DataView(dtRequiVista);
                Busqueda.RowFilter = "TipoCompra = 'xxx'";
                dgvRequisicones.DataSource = Busqueda;
            }
            label1.Text = Busqueda.Count.ToString();

            cboBusqueda.Items.Clear();
            cboBusqueda.Items.Add("Codigo");
            cboBusqueda.Items.Add("Descripción");
            cboBusqueda.Items.Add("Fecha Req.");
            cboBusqueda.Items.Add("Situacion");
            cboBusqueda.Items.Add("Stock");

            cboBusqueda2.Visible = false;
            txtBusqueda.Visible = false;
            txtNro.Visible = false;
        }

        private void chkNacionales_CheckedChanged(object sender, EventArgs e)
        {
            if (chkImp.Checked == true && chkNacionales.Checked == true)
            {
                Busqueda = new DataView(dtRequiVista);
                dgvRequisicones.DataSource = Busqueda;
            }
            if (chkImp.Checked == true && chkNacionales.Checked == false)
            {
                Busqueda = new DataView(dtRequiVista);
                Busqueda.RowFilter = "TipoCompra = 'IMP'";
                dgvRequisicones.DataSource = Busqueda;
            }
            if (chkImp.Checked == false && chkNacionales.Checked == true)
            {
                Busqueda = new DataView(dtRequiVista);
                Busqueda.RowFilter = "TipoCompra <> 'IMP'";
                dgvRequisicones.DataSource = Busqueda;
            }
            if (chkImp.Checked == false && chkNacionales.Checked == false)
            {
                Busqueda = new DataView(dtRequiVista);
                Busqueda.RowFilter = "TipoCompra = 'xxx'";
                dgvRequisicones.DataSource = Busqueda;
            }
            label1.Text = Busqueda.Count.ToString();

            cboBusqueda.Items.Clear();
            cboBusqueda.Items.Add("Codigo");
            cboBusqueda.Items.Add("Descripción");
            cboBusqueda.Items.Add("Fecha Req.");
            cboBusqueda.Items.Add("Situacion");
            cboBusqueda.Items.Add("Stock");

            cboBusqueda2.Visible = false;
            txtBusqueda.Visible = false;
            txtNro.Visible = false;
        }

        private void cboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboBusqueda.SelectedIndex)
            {
                case 0:
                    if (chkImp.Checked == true && chkNacionales.Checked == true)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.Sort = "Codigo asc";
                        dgvRequisicones.DataSource = Busqueda;
                    }
                    if (chkImp.Checked == true && chkNacionales.Checked == false)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.RowFilter = "TipoCompra = 'IMP'";
                        Busqueda.Sort = "Codigo asc";
                        dgvRequisicones.DataSource = Busqueda;
                    }
                    if (chkImp.Checked == false && chkNacionales.Checked == true)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.RowFilter = "TipoCompra <> 'IMP'";
                        Busqueda.Sort = "Codigo asc";
                        dgvRequisicones.DataSource = Busqueda;
                    }
                    if (chkImp.Checked == false && chkNacionales.Checked == false)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.RowFilter = "TipoCompra = 'xxx'";
                        Busqueda.Sort = "Codigo asc";
                        dgvRequisicones.DataSource = Busqueda;
                    }
                    
                    /**/                    
                    txtBusqueda.Visible = true;
                    txtBusqueda.Text = "";
                    txtBusqueda.Focus();

                    cboBusqueda2.Visible = false;
                    txtNro.Visible = false;

                    break;



                case 1:
                    if (chkImp.Checked == true && chkNacionales.Checked == true)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.Sort = "Descripcion asc";
                        dgvRequisicones.DataSource = Busqueda;
                    }
                    if (chkImp.Checked == true && chkNacionales.Checked == false)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.RowFilter = "TipoCompra = 'IMP'";
                        Busqueda.Sort = "Descripcion asc";
                        dgvRequisicones.DataSource = Busqueda;
                    }
                    if (chkImp.Checked == false && chkNacionales.Checked == true)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.RowFilter = "TipoCompra <> 'IMP'";
                        Busqueda.Sort = "Descripcion asc";
                        dgvRequisicones.DataSource = Busqueda;
                    }
                    if (chkImp.Checked == false && chkNacionales.Checked == false)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.RowFilter = "TipoCompra = 'xxx'";
                        Busqueda.Sort = "Descripcion asc";
                        dgvRequisicones.DataSource = Busqueda;
                    }

                    /**/
                    txtBusqueda.Visible = true;
                    txtBusqueda.Text = "";
                    txtBusqueda.Focus();
                    cboBusqueda2.Visible = false;
                    txtNro.Visible = false;
                    break;


                case 2:
                    if (chkImp.Checked == true && chkNacionales.Checked == true)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.Sort = "FechaReq desc";
                        dgvRequisicones.DataSource = Busqueda;
                    }
                    if (chkImp.Checked == true && chkNacionales.Checked == false)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.RowFilter = "TipoCompra = 'IMP'";
                        Busqueda.Sort = "FechaReq desc";
                        dgvRequisicones.DataSource = Busqueda;
                    }
                    if (chkImp.Checked == false && chkNacionales.Checked == true)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.RowFilter = "TipoCompra <> 'IMP'";
                        Busqueda.Sort = "FechaReq desc";
                        dgvRequisicones.DataSource = Busqueda;
                    }
                    if (chkImp.Checked == false && chkNacionales.Checked == false)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.RowFilter = "TipoCompra = 'xxx'";
                        Busqueda.Sort = "FechaReq desc";
                        dgvRequisicones.DataSource = Busqueda;
                    }


                    /**/
                    /**/
                    txtBusqueda.Visible = false;
                    cboBusqueda2.Visible = true;                    
                    txtNro.Visible = true;
                    txtNro.Text = "";
                    txtNro.Focus();

                    cboBusqueda2.Items.Clear();
                    cboBusqueda2.Items.Add("=");
                    cboBusqueda2.Items.Add(">");
                    cboBusqueda2.Items.Add("<");
                    cboBusqueda2.Items.Add(">=");
                    cboBusqueda2.Items.Add("<=");
                    cboBusqueda2.Items.Add("<>"); 
                    break;


                case 3:
                    if (chkImp.Checked == true && chkNacionales.Checked == true)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.Sort = "Situacion asc";
                        dgvRequisicones.DataSource = Busqueda;
                    }
                    if (chkImp.Checked == true && chkNacionales.Checked == false)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.RowFilter = "TipoCompra = 'IMP'";
                        Busqueda.Sort = "Situacion asc";
                        dgvRequisicones.DataSource = Busqueda;
                    }
                    if (chkImp.Checked == false && chkNacionales.Checked == true)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.RowFilter = "TipoCompra <> 'IMP'";
                        Busqueda.Sort = "Situacion asc";
                        dgvRequisicones.DataSource = Busqueda;
                    }
                    if (chkImp.Checked == false && chkNacionales.Checked == false)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.RowFilter = "TipoCompra = 'xxx'";
                        Busqueda.Sort = "Situacion asc";
                        dgvRequisicones.DataSource = Busqueda;
                    }

                    /**/
                    txtBusqueda.Visible = false;
                    cboBusqueda2.Visible = true;
                    txtNro.Visible = false;

                    cboBusqueda2.Items.Clear();
                    cboBusqueda2.Items.Add("Activa");
                    cboBusqueda2.Items.Add("Asignada");
                    cboBusqueda2.Items.Add("Autoriz");
                    cboBusqueda2.Items.Add("Captura");
                    cboBusqueda2.Items.Add("Cotizar");
                    cboBusqueda2.Items.Add("Firme 1");
                    cboBusqueda2.Items.Add("Firme 3");
                    cboBusqueda2.Items.Add("Firme 4");
                    cboBusqueda2.Items.Add("Obsoleto");
                    cboBusqueda2.Items.Add("Orden");
                    cboBusqueda2.Items.Add("Rechazad");
                    cboBusqueda2.Items.Add("Surt_Par");

                    
                    break;

                case 4:
                    if (chkImp.Checked == true && chkNacionales.Checked == true)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.Sort = "Stock asc";
                        dgvRequisicones.DataSource = Busqueda;
                    }
                    if (chkImp.Checked == true && chkNacionales.Checked == false)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.RowFilter = "TipoCompra = 'IMP'";
                        Busqueda.Sort = "Stock asc";
                        dgvRequisicones.DataSource = Busqueda;
                    }
                    if (chkImp.Checked == false && chkNacionales.Checked == true)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.RowFilter = "TipoCompra <> 'IMP'";
                        Busqueda.Sort = "Stock asc";
                        dgvRequisicones.DataSource = Busqueda;
                    }
                    if (chkImp.Checked == false && chkNacionales.Checked == false)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.RowFilter = "TipoCompra = 'xxx'";
                        Busqueda.Sort = "Stock asc";
                        dgvRequisicones.DataSource = Busqueda;
                    }

                    /**/
                    txtBusqueda.Visible = false;
                    cboBusqueda2.Visible = true;
                    txtNro.Visible = true;
                    txtNro.Text = "";
                    txtNro.Focus();

                    cboBusqueda2.Items.Clear();
                    cboBusqueda2.Items.Add("=");
                    cboBusqueda2.Items.Add(">");
                    cboBusqueda2.Items.Add("<");
                    cboBusqueda2.Items.Add(">=");
                    cboBusqueda2.Items.Add("<=");
                    cboBusqueda2.Items.Add("<>");                    

                    break;
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {
            string texto = txtBusqueda.Text.ToString().Trim();
            switch (cboBusqueda.SelectedIndex)
            {
                case 0:
                    if (chkImp.Checked == true && chkNacionales.Checked == true)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.RowFilter = "Codigo like '%" + texto + "%'";
                        Busqueda.Sort = "Codigo asc";
                        dgvRequisicones.DataSource = Busqueda;
                    }
                    if (chkImp.Checked == true && chkNacionales.Checked == false)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.RowFilter = "TipoCompra = 'IMP' and Codigo like '%" + texto + "%'";
                        Busqueda.Sort = "Codigo asc";
                        dgvRequisicones.DataSource = Busqueda;
                    }
                    if (chkImp.Checked == false && chkNacionales.Checked == true)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.RowFilter = "TipoCompra <> 'IMP' and Codigo like '%" + texto + "%'";
                        Busqueda.Sort = "Codigo asc";
                        dgvRequisicones.DataSource = Busqueda;
                    }
                    if (chkImp.Checked == false && chkNacionales.Checked == false)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.RowFilter = "TipoCompra = 'xxx' and Codigo like '%" + texto + "%'";
                        Busqueda.Sort = "Codigo asc";
                        dgvRequisicones.DataSource = Busqueda;
                    }

                    label1.Text = Busqueda.Count.ToString();
                    break;

                case 1:
                    if (chkImp.Checked == true && chkNacionales.Checked == true)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.RowFilter = "Descripcion like '%" + texto + "%'";
                        Busqueda.Sort = "Descripcion asc";
                        dgvRequisicones.DataSource = Busqueda;
                    }
                    if (chkImp.Checked == true && chkNacionales.Checked == false)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.RowFilter = "TipoCompra = 'IMP' and Descripcion like '%" + texto + "%'";
                        Busqueda.Sort = "Descripcion asc";
                        dgvRequisicones.DataSource = Busqueda;
                    }
                    if (chkImp.Checked == false && chkNacionales.Checked == true)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.RowFilter = "TipoCompra <> 'IMP' and Descripcion like '%" + texto + "%'";
                        Busqueda.Sort = "Descripcion asc";
                        dgvRequisicones.DataSource = Busqueda;
                    }
                    if (chkImp.Checked == false && chkNacionales.Checked == false)
                    {
                        Busqueda = new DataView(dtRequiVista);
                        Busqueda.RowFilter = "TipoCompra = 'xxx' and Descripcion like '%" + texto + "%'";
                        Busqueda.Sort = "Descripcion asc";
                        dgvRequisicones.DataSource = Busqueda;
                    }

                    label1.Text = Busqueda.Count.ToString();
                    break;
            }
        }

        private void cboBusqueda2_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                string texto = cboBusqueda2.Text.ToString().Trim();
                string nro = txtNro.Text.ToString().Trim();

                string concatena = texto + nro;
                switch (cboBusqueda.SelectedIndex)
                {
                    case 3:
                        if (chkImp.Checked == true && chkNacionales.Checked == true)
                        {
                            Busqueda = new DataView(dtRequiVista);
                            Busqueda.RowFilter = "Situacion = '" + texto + "'";
                            Busqueda.Sort = "Situacion asc";
                            dgvRequisicones.DataSource = Busqueda;
                        }
                        if (chkImp.Checked == true && chkNacionales.Checked == false)
                        {
                            Busqueda = new DataView(dtRequiVista);
                            Busqueda.RowFilter = "TipoCompra = 'IMP' and Situacion = '" + texto + "'";
                            Busqueda.Sort = "Situacion asc";
                            dgvRequisicones.DataSource = Busqueda;
                        }
                        if (chkImp.Checked == false && chkNacionales.Checked == true)
                        {
                            Busqueda = new DataView(dtRequiVista);
                            Busqueda.RowFilter = "TipoCompra <> 'IMP' and Situacion = '" + texto + "'";
                            Busqueda.Sort = "Situacion asc";
                            dgvRequisicones.DataSource = Busqueda;
                        }
                        if (chkImp.Checked == false && chkNacionales.Checked == false)
                        {
                            Busqueda = new DataView(dtRequiVista);
                            Busqueda.RowFilter = "TipoCompra = 'xxx' and Situacion = '" + texto + "'";
                            Busqueda.Sort = "Situacion asc";
                            dgvRequisicones.DataSource = Busqueda;
                        }
                        break;

                    case 4:
                        if (chkImp.Checked == true && chkNacionales.Checked == true)
                        {
                            Busqueda = new DataView(dtRequiVista);
                            Busqueda.RowFilter = "Stock " + concatena + "";
                            Busqueda.Sort = "Stock asc";
                            dgvRequisicones.DataSource = Busqueda;
                        }
                        if (chkImp.Checked == true && chkNacionales.Checked == false)
                        {
                            Busqueda = new DataView(dtRequiVista);
                            Busqueda.RowFilter = "TipoCompra = 'IMP' and Stock " + concatena + "";
                            Busqueda.Sort = "Stock asc";
                            dgvRequisicones.DataSource = Busqueda;
                        }
                        if (chkImp.Checked == false && chkNacionales.Checked == true)
                        {
                            Busqueda = new DataView(dtRequiVista);
                            Busqueda.RowFilter = "TipoCompra <> 'IMP' and Stock " + concatena + "";
                            Busqueda.Sort = "Stock asc";
                            dgvRequisicones.DataSource = Busqueda;
                        }
                        if (chkImp.Checked == false && chkNacionales.Checked == false)
                        {
                            Busqueda = new DataView(dtRequiVista);
                            Busqueda.RowFilter = "TipoCompra = 'xxx' and Stock " + concatena + "";
                            Busqueda.Sort = "Stock asc";
                            dgvRequisicones.DataSource = Busqueda;
                        }
                        break;


                    case 2:
                        if (chkImp.Checked == true && chkNacionales.Checked == true)
                        {
                            Busqueda = new DataView(dtRequiVista);
                            Busqueda.RowFilter = "FechaReq " + concatena + "";
                            Busqueda.Sort = "FechaReq asc";
                            dgvRequisicones.DataSource = Busqueda;
                        }
                        if (chkImp.Checked == true && chkNacionales.Checked == false)
                        {
                            Busqueda = new DataView(dtRequiVista);
                            Busqueda.RowFilter = "TipoCompra = 'IMP' and FechaReq " + concatena + "";
                            Busqueda.Sort = "FechaReq asc";
                            dgvRequisicones.DataSource = Busqueda;
                        }
                        if (chkImp.Checked == false && chkNacionales.Checked == true)
                        {
                            Busqueda = new DataView(dtRequiVista);
                            Busqueda.RowFilter = "TipoCompra <> 'IMP' and FechaReq " + concatena + "";
                            Busqueda.Sort = "FechaReq asc";
                            dgvRequisicones.DataSource = Busqueda;
                        }
                        if (chkImp.Checked == false && chkNacionales.Checked == false)
                        {
                            Busqueda = new DataView(dtRequiVista);
                            Busqueda.RowFilter = "TipoCompra = 'xxx' and FechaReq " + concatena + "";
                            Busqueda.Sort = "FechaReq asc";
                            dgvRequisicones.DataSource = Busqueda;
                        }
                        break;


                }
                label1.Text = Busqueda.Count.ToString();
                txtNro.Focus();
            }
            catch { }
        }

        private void txtNro_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string texto = cboBusqueda2.Text.ToString().Trim();
                string nro = txtNro.Text.ToString().Trim();
                string concatena = texto + nro;
                switch (cboBusqueda.SelectedIndex)
                {
                    case 4:
                        if (chkImp.Checked == true && chkNacionales.Checked == true)
                        {
                            Busqueda = new DataView(dtRequiVista);
                            Busqueda.RowFilter = "Stock " + concatena + "";
                            Busqueda.Sort = "Stock asc";
                            dgvRequisicones.DataSource = Busqueda;
                        }
                        if (chkImp.Checked == true && chkNacionales.Checked == false)
                        {
                            Busqueda = new DataView(dtRequiVista);
                            Busqueda.RowFilter = "TipoCompra = 'IMP' and Stock " + concatena + "";
                            Busqueda.Sort = "Stock asc";
                            dgvRequisicones.DataSource = Busqueda;
                        }
                        if (chkImp.Checked == false && chkNacionales.Checked == true)
                        {
                            Busqueda = new DataView(dtRequiVista);
                            Busqueda.RowFilter = "TipoCompra <> 'IMP' and Stock " + concatena + "";
                            Busqueda.Sort = "Stock asc";
                            dgvRequisicones.DataSource = Busqueda;
                        }
                        if (chkImp.Checked == false && chkNacionales.Checked == false)
                        {
                            Busqueda = new DataView(dtRequiVista);
                            Busqueda.RowFilter = "TipoCompra = 'xxx' and Stock " + concatena + "";
                            Busqueda.Sort = "Stock asc";
                            dgvRequisicones.DataSource = Busqueda;
                        }
                        break;

                    case 2:
                        if (chkImp.Checked == true && chkNacionales.Checked == true)
                        {
                            Busqueda = new DataView(dtRequiVista);
                            Busqueda.RowFilter = "FechaReq " + concatena + "";
                            Busqueda.Sort = "FechaReq asc";
                            dgvRequisicones.DataSource = Busqueda;
                        }
                        if (chkImp.Checked == true && chkNacionales.Checked == false)
                        {
                            Busqueda = new DataView(dtRequiVista);
                            Busqueda.RowFilter = "TipoCompra = 'IMP' and FechaReq " + concatena + "";
                            Busqueda.Sort = "FechaReq asc";
                            dgvRequisicones.DataSource = Busqueda;
                        }
                        if (chkImp.Checked == false && chkNacionales.Checked == true)
                        {
                            Busqueda = new DataView(dtRequiVista);
                            Busqueda.RowFilter = "TipoCompra <> 'IMP' and FechaReq " + concatena + "";
                            Busqueda.Sort = "FechaReq asc";
                            dgvRequisicones.DataSource = Busqueda;
                        }
                        if (chkImp.Checked == false && chkNacionales.Checked == false)
                        {
                            Busqueda = new DataView(dtRequiVista);
                            Busqueda.RowFilter = "TipoCompra = 'xxx' and FechaReq " + concatena + "";
                            Busqueda.Sort = "FechaReq asc";
                            dgvRequisicones.DataSource = Busqueda;
                        }
                        break;
                }
                label1.Text = Busqueda.Count.ToString();
            }
            catch { }
        }
        string Requ="";
        string item = "";
        string descripcAdici = "";
        private void dgvRequisicones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                int p = dgvRequisicones.CurrentRow.Index;
                lblCodigo.Text = dgvRequisicones.Rows[p].Cells["Codigo"].Value.ToString().Trim();
                lblDescripcion.Text = dgvRequisicones.Rows[p].Cells["Descripcion"].Value.ToString().Trim();
                lblCantidad.Text = dgvRequisicones.Rows[p].Cells["Cantidad"].Value.ToString().Trim();
                Requ = dgvRequisicones.Rows[p].Cells["Requisicion"].Value.ToString().Trim();
                item = dgvRequisicones.Rows[p].Cells["Item"].Value.ToString().Trim();
                descripcAdici = dgvRequisicones.Rows[p].Cells["DetaAdicional"].Value.ToString().Trim();
                txtDescripcionAdicional.Text = dgvRequisicones.Rows[p].Cells["Descripcion_Detallada"].Value.ToString().Trim();
                label2.Text = "Detalles Adicionales de Req. -->" + Requ + " - " + item;
                panel1.Visible = true;
                if (descripcAdici != "")
                {
                    txtDes.Text = descripcAdici;
                }
                else
                {
                    txtDes.Text = "";
                }            
                txtDes.Focus();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }


        DateTime FechaSis = DateTime.Now;
        string fecha = "";
        string Hora = "";
        private void btnModifica_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            FechaSis = DateTime.Now;
            fecha = FechaSis.ToShortDateString().Substring(6, 4) + FechaSis.ToShortDateString().Substring(3, 2) + FechaSis.ToShortDateString().Substring(0, 2);
            if (Convert.ToDecimal(FechaSis.Minute.ToString()) <= 9) { Hora = FechaSis.Hour.ToString() + "0" + FechaSis.Minute.ToString(); }
            else { Hora = FechaSis.Hour.ToString() + FechaSis.Minute.ToString(); }
            objTablas = new BTablas();
            string SQL = "DELETE FROM " + Program.LibreADAMAD2 + ".TRQCDDES WHERE RQCCVE='" + Requ + "' AND RQCSEQ=" + item;
            int ide = objTablas.BUpdateLIBRE(SQL);
            objTablas = new BTablas();
            SQL =" INSERT INTO " + Program.LibreADAMAD2 + ".TRQCDDES (RQCUSU, RQCUFE, RQCUHM, RQCCVE, RQCSEQ, RQCCOD, RQCDES) " +
                        " VALUES ('" + Program.Usuario + "', " + fecha + ", " + Hora + ", '" + Requ + "', " + item + ", '" + lblCodigo.Text.Trim() + "', '" + txtDes.Text.Trim() + "')";
            int i = objTablas.BUpdateLIBRE(SQL);
            if (i == 1)
            {
                MessageBox.Show("Descripcion Ingresada Correctamente", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panel1.Visible = false;

                objTablas = new BTablas();
                Program.dtDescripcionesAdicionales = objTablas.getSELECTLIBRE("SELECT RQCCVE,RQCSEQ,RQCDES FROM " + Program.LibreADAMAD2 + ".TRQCDDES");

                objTablas = new BTablas();
                dtRequiVista = objTablas.getRequisicionesAI(dtRequisiciones, Program.dtUnidMed, Program.dtDescripcionesAdicionales, Program.dtGrupos, Program.dtSubGrupos);
                
                chkImp.Checked = true;
                chkNacionales.Checked = true;
                cboBusqueda2.Visible = false;
                txtNro.Visible = false;
                txtBusqueda.Visible = false;
                

                Grilla();
            }
            this.Cursor = Cursors.Default;


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            dgvRequisicones.GridColor = Color.Red;
            SQL = "SELECT " +
                    " M.MPMCOD,M.MPMDES,IFNULL(W.MIDEA1,'') AS DES1,IFNULL(W.MIDEA2,'') AS DES2,IFNULL(W.MIDEA3,'') AS DES3,IFNULL(W.MIDEA4,'') AS DES4,IFNULL(W.MIDEA5,'') AS DES5,IFNULL(W.MIDEA6,'') AS DES6,D.RQCCVE,D.RQCSEQ, " +
                    " D.RQCFES,D.RQCCAN,D.RQCVD1,T.ARTUPC, " +
                    " D.OCOCVE,D.RQCSID,D.RQCCMT,M.MPMUNI, " +
                    " M.MPMSCO,MPMSDI,M.MPMPRO,M.MPMSMX,M.MPMSMN,L.DAACVE " +
                    " FROM " + Program.LibreADAMAD2 + ".TRQCD D," + Program.LibreADAMAD2 + ".TRQCH H," + Program.LibreLALMINGB + ".ALMMMAP M," + Program.LibreADAMAD2 + ".TRLAA L," + Program.LibreADAMAD2 + ".TARTI T," + Program.LibreLALMINGB + ".ALMWCON W " +
                    " WHERE " +
                    " D.RQCCVE=H.RQCCVE AND " +
                    " D.ARTCOD=M.MPMCOD AND " +
                    " D.ARTCOD=W.MIMCOD AND " +
                    " D.ARTCOD=L.ARTCOD AND " +
                    " D.ARTCOD=T.ARTCOD AND " +
                    " L.AGACVE='PRO' AND " +
                    " D.ALMCVE = '4' AND " +
                    " D.RQCSID NOT IN ('Surtida','Cancel.')";
            objTablas = new BTablas();
            dtRequisiciones = objTablas.getSELECTLIBRE(SQL);
            objTablas = new BTablas();
            dtRequiVista = objTablas.getRequisicionesAI(dtRequisiciones, Program.dtUnidMed, Program.dtDescripcionesAdicionales, Program.dtGrupos, Program.dtSubGrupos);
            Grilla();
            label1.Text = Busqueda.Count.ToString();
            cboBusqueda2.Location = new Point(523, 114);
            chkImp.Checked = true;
            chkNacionales.Checked = true;
            cboBusqueda2.Visible=false;
            txtNro.Visible=false;
            txtBusqueda.Visible = false;
            Cursor = Cursors.Default;
        }

    }
}