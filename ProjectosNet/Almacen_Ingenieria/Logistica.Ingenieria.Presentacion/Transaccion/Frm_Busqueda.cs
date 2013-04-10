using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Logistica.Ingenieria.Bussiness;

namespace Logistica.Ingenieria.Presentacion
{
    public partial class Frm_Busqueda : Form
    {
        public Frm_Busqueda()
        {
            InitializeComponent();
        }

        BTablas oBusTab = new BTablas();
        DataView dv = new DataView();
        public string Busqueda;

        public string vOrdenTrabajo = "";
        public string vCodDpto = "";
        public string vequipo = "";
        public string vdpto = "";

        public string vCodEmpleado = "";
        public string vEmpleado = "";

        public string vCentroCosto = "";
        public string vDescriCentroCosto = "";

        DataTable dtCorreo = new DataTable();

        private void Frm_Busqueda_Load(object sender, EventArgs e)
        {
            dgvBusqueda.GridColor = Color.Red;
            if (Busqueda == "OT")
            {
                OrdenTrabajo();
                cboBusqueda.SelectedIndex = 2;
                txtBusqueda.Focus();
            }
            if ((Busqueda == "AU") || (Busqueda == "US"))
            {
                EmpleadosAutorizacion();
                cboBusqueda.SelectedIndex = 1;
                txtBusqueda.Focus();
            }
            if (Busqueda == "COR")
            {
                CargaCorreos();
                cboBusqueda.SelectedIndex = 1;
                txtBusqueda.Focus();
            }
            if (Busqueda == "CCT")
            {
                CargaCCT();
                cboBusqueda.SelectedIndex = 1;
                txtBusqueda.Focus();
            }
        }

        DataTable dtCentroCOSTO = new DataTable();
        void CargaCCT()
        {
            Text = "Centro de Costos";
            lblBusqueda.Text = "Centro de Costos";
            oBusTab = new BTablas();
            //dtCentroCOSTO = oBusTab.getSELECTLIBRE("SELECT TRIM(DATCVE) AS DATCVE,DATDES FROM ADAMPERUV2.V_TRABAJ WHERE TRAFBA=0 GROUP BY DATCVE,DATDES ORDER BY DATCVE");
            dtCentroCOSTO = oBusTab.getSELECTLIBRE("SELECT TRIM(T01ESP) AS DATCVE,T01AL1 AS DATDES FROM LUGTF.UGT01 WHERE T01IDT='CCT' AND T01STT<>'E' AND T01AL1 NOT LIKE '--%' ORDER BY T01ESP");
            dgvBusqueda.DataSource = dtCentroCOSTO;

            cboBusqueda.Items.Add("Codigo");
            cboBusqueda.Items.Add("Centro Costo");

            dgvBusqueda.Columns["foto"].Visible = false;
            dgvBusqueda.Columns["DATCVE"].DisplayIndex = 0;
            dgvBusqueda.Columns["DATCVE"].HeaderText = "Cod.Costo";

            dgvBusqueda.Columns["DATDES"].DisplayIndex = 1;
            dgvBusqueda.Columns["DATDES"].HeaderText = "Descripcion";

            dgvBusqueda.Columns["DATCVE"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBusqueda.Columns["DATDES"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvBusqueda.Columns["DATCVE"].Width = 80;
            dgvBusqueda.Columns["DATDES"].Width = 350;

        }

        void OrdenTrabajo()
        {
            Text = "Orden de Trabajo";
            lblBusqueda.Text = "Ordenes de Trabajo";
            oBusTab = new BTablas();
            dgvBusqueda.DataSource = Program.dtCCostos;

            cboBusqueda.Items.Add("Orden Trabajo");
            cboBusqueda.Items.Add("Codigo Area");
            cboBusqueda.Items.Add("Equipo");
            cboBusqueda.Items.Add("Desc. Area");

            dgvBusqueda.Columns["foto"].Visible = false;

            dgvBusqueda.Columns["ODTSTT"].DisplayIndex = 0;
            dgvBusqueda.Columns["ODTSTT"].Visible = false;

            dgvBusqueda.Columns["ODTCOD"].DisplayIndex = 1;
            dgvBusqueda.Columns["ODTDPT"].DisplayIndex = 2;
            dgvBusqueda.Columns["ODTDES"].DisplayIndex = 3;
            dgvBusqueda.Columns["T01AL1"].DisplayIndex = 4;

            dgvBusqueda.Columns["ODTCOD"].HeaderText = "Cod.Ord.";
            dgvBusqueda.Columns["ODTDPT"].HeaderText = "Cod.Dpto";
            dgvBusqueda.Columns["ODTDES"].HeaderText = "Equipo";
            dgvBusqueda.Columns["T01AL1"].HeaderText = "Dpto";

            dgvBusqueda.Columns["ODTCOD"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBusqueda.Columns["ODTDPT"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBusqueda.Columns["ODTDES"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBusqueda.Columns["T01AL1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvBusqueda.Columns["ODTCOD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBusqueda.Columns["ODTDPT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBusqueda.Columns["ODTDES"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvBusqueda.Columns["T01AL1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvBusqueda.Columns["ODTCOD"].Width = 80;
            dgvBusqueda.Columns["ODTDPT"].Width = 80;
            dgvBusqueda.Columns["ODTDES"].Width = 300;
            dgvBusqueda.Columns["T01AL1"].Width = 150;
        }


        void EmpleadosAutorizacion()
        {
            Text = "Empleados Autorizacion";
            lblBusqueda.Text = "Autorizacion";
            oBusTab = new BTablas();
            dgvBusqueda.DataSource = Program.dtEmpleados;

            cboBusqueda.Items.Add("Codigo");
            cboBusqueda.Items.Add("Nombre");

            dgvBusqueda.Columns["foto"].Visible = true;
            dgvBusqueda.Columns["foto"].DisplayIndex = 1;


            dgvBusqueda.Columns["CODIGO"].DisplayIndex = 0;
            dgvBusqueda.Columns["CODIGO"].Visible = false;

            

            dgvBusqueda.Columns["NOMBRE"].DisplayIndex = 1;
            dgvBusqueda.Columns["NOMBRE"].HeaderText = "Nombre Trabj.";

            dgvBusqueda.Columns["NOMBRE"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBusqueda.Columns["NOMBRE"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvBusqueda.Columns["NOMBRE"].Width = 450;
            dgvBusqueda.Columns["foto"].Width = 100;

        }

        void CargaCorreos()
        {
            Text = "Empleados Correos";
            lblBusqueda.Text = "Correos Empleados";
            oBusTab = new BTablas();
            dtCorreo = oBusTab.getCargaCORREOS();
            dgvBusqueda.DataSource = dtCorreo;

            cboBusqueda.Items.Add("Codigo");
            cboBusqueda.Items.Add("Nombre");

            //CODEMP,NOMEMP,FILLER
            dgvBusqueda.Columns["FILLER"].Visible = false;


            dgvBusqueda.Columns["foto"].Visible = true;
            dgvBusqueda.Columns["foto"].DisplayIndex = 1;

            dgvBusqueda.Columns["CODEMP"].DisplayIndex = 0;
            dgvBusqueda.Columns["CODEMP"].Visible = false;

            dgvBusqueda.Columns["NOMEMP"].DisplayIndex = 1;
            dgvBusqueda.Columns["NOMEMP"].HeaderText = "Nombre Trabj.";

            dgvBusqueda.Columns["NOMEMP"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBusqueda.Columns["NOMEMP"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvBusqueda.Columns["NOMEMP"].Width = 450;
            dgvBusqueda.Columns["foto"].Width = 100;
        }

        private void cboBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (Busqueda == "OT")
            {
                switch (cboBusqueda.SelectedIndex)
                {
                    case 0:
                        dv = new DataView(Program.dtCCostos, "", "ODTCOD ASC", DataViewRowState.OriginalRows);
                        dgvBusqueda.DataSource = dv;
                        dgvBusqueda.Columns["ODTCOD"].DisplayIndex = 1;
                        dgvBusqueda.Columns["ODTDPT"].DisplayIndex = 2;
                        dgvBusqueda.Columns["ODTDES"].DisplayIndex = 3;
                        dgvBusqueda.Columns["T01AL1"].DisplayIndex = 4;
                        break;
                    case 1:
                        dv = new DataView(Program.dtCCostos, "", "ODTDPT ASC", DataViewRowState.OriginalRows);
                        dgvBusqueda.DataSource = dv;
                        dgvBusqueda.Columns["ODTCOD"].DisplayIndex = 2;
                        dgvBusqueda.Columns["ODTDPT"].DisplayIndex = 1;
                        dgvBusqueda.Columns["ODTDES"].DisplayIndex = 3;
                        dgvBusqueda.Columns["T01AL1"].DisplayIndex = 4;
                        break;
                    case 2:
                        dv = new DataView(Program.dtCCostos, "", "ODTDES ASC", DataViewRowState.OriginalRows);
                        dgvBusqueda.DataSource = dv;
                        dgvBusqueda.Columns["ODTCOD"].DisplayIndex = 2;
                        dgvBusqueda.Columns["ODTDPT"].DisplayIndex = 3;
                        dgvBusqueda.Columns["ODTDES"].DisplayIndex = 1;
                        dgvBusqueda.Columns["T01AL1"].DisplayIndex = 4;
                        break;
                    case 3:
                        dv = new DataView(Program.dtCCostos, "", "T01AL1 ASC", DataViewRowState.OriginalRows);
                        dgvBusqueda.DataSource = dv;
                        dgvBusqueda.Columns["ODTCOD"].DisplayIndex = 2;
                        dgvBusqueda.Columns["ODTDPT"].DisplayIndex = 3;
                        dgvBusqueda.Columns["ODTDES"].DisplayIndex = 4;
                        dgvBusqueda.Columns["T01AL1"].DisplayIndex = 1;
                        break;
                }
            }

            if (Busqueda == "AU")
            {
                switch (cboBusqueda.SelectedIndex)
                {
                    case 0:
                        dv = new DataView(Program.dtEmpleados, "", "CODIGO ASC", DataViewRowState.OriginalRows);
                        dgvBusqueda.DataSource = dv;
                        break;
                    case 1:
                        dv = new DataView(Program.dtEmpleados, "", "NOMBRE ASC", DataViewRowState.OriginalRows);
                        dgvBusqueda.DataSource = dv;
                        break;
                }
            }

            if (Busqueda == "COR")
            {
                switch (cboBusqueda.SelectedIndex)
                {
                    case 0:
                        dv = new DataView(dtCorreo, "", "CODEMP ASC", DataViewRowState.OriginalRows);
                        dgvBusqueda.DataSource = dv;
                        break;
                    case 1:
                        dv = new DataView(dtCorreo, "", "NOMEMP ASC", DataViewRowState.OriginalRows);
                        dgvBusqueda.DataSource = dv;
                        break;
                }
            }

            if (Busqueda == "CCT")
            {
                switch (cboBusqueda.SelectedIndex)
                {
                    case 0:
                        dv = new DataView(dtCentroCOSTO, "", "DATCVE ASC", DataViewRowState.OriginalRows);
                        dgvBusqueda.DataSource = dv;
                        break;
                    case 1:
                        dv = new DataView(dtCentroCOSTO, "", "DATDES ASC", DataViewRowState.OriginalRows);
                        dgvBusqueda.DataSource = dv;
                        break;
                }
            }
        }

        private void txtBusqueda_TextChanged(object sender, EventArgs e)
        {

            try
            {
                dgvBusqueda.GridColor = Color.Red;
                if (Busqueda == "OT")
                {
                    switch (cboBusqueda.SelectedIndex)
                    {
                        case 0:
                            dv = new DataView(Program.dtCCostos, "ODTCOD like '%" + txtBusqueda.Text.ToString() + "%'", "ODTCOD ASC", DataViewRowState.OriginalRows);
                            dgvBusqueda.DataSource = dv;
                            dgvBusqueda.Columns["ODTCOD"].DisplayIndex = 1;
                            dgvBusqueda.Columns["ODTDPT"].DisplayIndex = 2;
                            dgvBusqueda.Columns["ODTDES"].DisplayIndex = 3;
                            dgvBusqueda.Columns["T01AL1"].DisplayIndex = 4;
                            break;
                        case 1:
                            dv = new DataView(Program.dtCCostos, "ODTDPT like '%" + txtBusqueda.Text.ToString() + "%'", "ODTDPT ASC", DataViewRowState.OriginalRows);
                            dgvBusqueda.DataSource = dv;
                            dgvBusqueda.Columns["ODTCOD"].DisplayIndex = 2;
                            dgvBusqueda.Columns["ODTDPT"].DisplayIndex = 1;
                            dgvBusqueda.Columns["ODTDES"].DisplayIndex = 3;
                            dgvBusqueda.Columns["T01AL1"].DisplayIndex = 4;
                            break;
                        case 2:
                            dv = new DataView(Program.dtCCostos, "ODTDES like '%" + txtBusqueda.Text.ToString() + "%'", "ODTDES ASC", DataViewRowState.OriginalRows);
                            dgvBusqueda.DataSource = dv;
                            dgvBusqueda.Columns["ODTCOD"].DisplayIndex = 2;
                            dgvBusqueda.Columns["ODTDPT"].DisplayIndex = 3;
                            dgvBusqueda.Columns["ODTDES"].DisplayIndex = 1;
                            dgvBusqueda.Columns["T01AL1"].DisplayIndex = 4;
                            break;
                        case 3:
                            dv = new DataView(Program.dtCCostos, "T01AL1 like '%" + txtBusqueda.Text.ToString() + "%'", "T01AL1 ASC", DataViewRowState.OriginalRows);
                            dgvBusqueda.DataSource = dv;
                            dgvBusqueda.Columns["ODTCOD"].DisplayIndex = 2;
                            dgvBusqueda.Columns["ODTDPT"].DisplayIndex = 3;
                            dgvBusqueda.Columns["ODTDES"].DisplayIndex = 4;
                            dgvBusqueda.Columns["T01AL1"].DisplayIndex = 1;
                            break;
                    }
                }
                if ((Busqueda == "AU") || (Busqueda == "US"))
                {
                    try
                    {
                        switch (cboBusqueda.SelectedIndex)
                        {
                            case 0:
                                dv = new DataView(Program.dtEmpleados, "CODIGO = '" + txtBusqueda.Text.ToString() + "'", "CODIGO ASC", DataViewRowState.OriginalRows);
                                dgvBusqueda.DataSource = dv;
                                break;
                            case 1:
                                dv = new DataView(Program.dtEmpleados, "NOMBRE like '%" + txtBusqueda.Text.ToString() + "%'", "NOMBRE ASC", DataViewRowState.OriginalRows);
                                dgvBusqueda.DataSource = dv;
                                break;
                        }
                    }
                    catch
                    {
                        dv = new DataView(Program.dtEmpleados, "", "CODIGO ASC", DataViewRowState.OriginalRows);
                        dgvBusqueda.DataSource = dv;
                    }
                }

                if (Busqueda == "COR")
                {
                    try
                    {
                        switch (cboBusqueda.SelectedIndex)
                        {
                            case 0:
                                dv = new DataView(dtCorreo, "CODEMP = '" + txtBusqueda.Text.ToString() + "'", "CODEMP ASC", DataViewRowState.OriginalRows);
                                dgvBusqueda.DataSource = dv;
                                break;
                            case 1:
                                dv = new DataView(dtCorreo, "NOMEMP like '%" + txtBusqueda.Text.ToString() + "%'", "NOMEMP ASC", DataViewRowState.OriginalRows);
                                dgvBusqueda.DataSource = dv;
                                break;
                        }
                    }
                    catch
                    {
                        dv = new DataView(dtCorreo, "", "CODEMP ASC", DataViewRowState.OriginalRows);
                        dgvBusqueda.DataSource = dv;
                    }
                }


                if (Busqueda == "CCT")
                {
                    switch (cboBusqueda.SelectedIndex)
                    {
                        case 0:
                            dv = new DataView(dtCentroCOSTO, "DATCVE = '" + txtBusqueda.Text.ToString() + "'", "DATCVE ASC", DataViewRowState.OriginalRows);
                            dgvBusqueda.DataSource = dv;
                            break;
                        case 1:
                            dv = new DataView(dtCentroCOSTO, "DATDES like '%" + txtBusqueda.Text.ToString() + "%'", "DATDES ASC", DataViewRowState.OriginalRows);
                            dgvBusqueda.DataSource = dv;
                            break;
                    }
                    
                }

            }
            catch { }


        }

        private void dgvBusqueda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Busqueda == "OT")
            {
                try
                {
                    int p = dgvBusqueda.CurrentRow.Index;
                    vOrdenTrabajo = dgvBusqueda.Rows[p].Cells["ODTCOD"].Value.ToString();
                    vCodDpto = dgvBusqueda.Rows[p].Cells["ODTDPT"].Value.ToString();
                    vequipo = dgvBusqueda.Rows[p].Cells["ODTDES"].Value.ToString();
                    vdpto = dgvBusqueda.Rows[p].Cells["T01AL1"].Value.ToString();
                    this.Close();
                }
                catch { }
            }
            if ((Busqueda == "AU") || (Busqueda == "US"))
            {
                try
                {
                    int p = dgvBusqueda.CurrentRow.Index;
                    vCodEmpleado = dgvBusqueda.Rows[p].Cells["CODIGO"].Value.ToString();
                    vEmpleado = dgvBusqueda.Rows[p].Cells["NOMBRE"].Value.ToString();  
                    this.Close();
                }
                catch { }
            }

            if (Busqueda == "COR")
            {
                try
                {
                    int p = dgvBusqueda.CurrentRow.Index;
                    vEmpleado = dgvBusqueda.Rows[p].Cells["NOMEMP"].Value.ToString();
                    vCodEmpleado = dgvBusqueda.Rows[p].Cells["FILLER"].Value.ToString();
                    this.Close();
                }
                catch { }
            }


            if (Busqueda == "CCT")
            {
                try
                {
                    int p = dgvBusqueda.CurrentRow.Index;
                    vCentroCosto = dgvBusqueda.Rows[p].Cells["DATCVE"].Value.ToString();
                    vDescriCentroCosto = dgvBusqueda.Rows[p].Cells["DATDES"].Value.ToString();
                    this.Close();
                }
                catch { }
            }
 

        }

        private void dgvBusqueda_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((Busqueda == "AU") || (Busqueda == "US"))
            {
                if (e.ColumnIndex == 0)
                {
                    int p = dgvBusqueda.CurrentRow.Index;
                    string cod = dgvBusqueda.Rows[p].Cells["CODIGO"].Value.ToString();
                    string nom = dgvBusqueda.Rows[p].Cells["NOMBRE"].Value.ToString();
                    Transaccion.Frm_FotoTrab frm = new Logistica.Ingenieria.Presentacion.Transaccion.Frm_FotoTrab();
                    frm.codTrab = cod.Trim();
                    frm.nomTrab = nom.Trim();
                    frm.ShowDialog();
                }
            }
            else
            {
                if (e.ColumnIndex == 0)
                {
                    int p = dgvBusqueda.CurrentRow.Index;
                    string cod = dgvBusqueda.Rows[p].Cells["CODEMP"].Value.ToString();
                    string nom = dgvBusqueda.Rows[p].Cells["NOMEMP"].Value.ToString();
                    Transaccion.Frm_FotoTrab frm = new Logistica.Ingenieria.Presentacion.Transaccion.Frm_FotoTrab();
                    frm.codTrab = cod.Trim();
                    frm.nomTrab = nom.Trim();
                    frm.ShowDialog();
                }
            }
        }

        private void Frm_Busqueda_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }


    }
}
