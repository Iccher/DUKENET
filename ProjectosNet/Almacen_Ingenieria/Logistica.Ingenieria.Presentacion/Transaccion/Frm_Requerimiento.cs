using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Logistica.Ingenieria.Utils;
using Logistica.Ingenieria.Bussiness;

using Logistica.Ingenieria.Entity;
using System.Net.Mail;
using System.Net;

namespace Logistica.Ingenieria.Presentacion
{
    public partial class Frm_Requerimiento : Form
    {
        public Frm_Requerimiento()
        {
            InitializeComponent();
        }
        BConfiguracion oBusConf = new BConfiguracion();
        BTablas objBus = new BTablas();
        TControlVB oControl = new TControlVB();
        DataView dv = new DataView();
        //Variables DataRow
        static decimal Cantidad = 0;
        static decimal TotalS = 0;
        static decimal TotalD = 0;
        DataTable tbldetalle;
        DataRow dr;

        string codEmpleado = "";
        string vCodigoProd = "";
        string vDescripcion = "";
        decimal vStockC = 0;
        decimal vStockD = 0;
        string vUndMed = "";
        decimal vPrecioSoles = 0;
        decimal vPrecioDolares = 0;
        string vUbicacion = "";

        decimal vProcedencia = 0;
        decimal vCtaAlmacen = 0;
        decimal vCuentaCargo = 0;

        /******Transaccion******************************/
        BTransaccion objTran = new BTransaccion();
        EReqCabecera eCabReq = new EReqCabecera();
        EReqDetalle EDetReq = new EReqDetalle();
        /***********************************************/

        string codSolicita = "";
        decimal turno = 0;
        DateTime FechaSis = DateTime.Now; 
        private void Frm_Requerimiento_Load(object sender, EventArgs e)
        {
            dgvDetReq.GridColor = Color.Red;            
            txtSolicitante.Text = Program.dvUsuariosConec[0]["NOMEMP"].ToString();
            codSolicita = Program.dvUsuariosConec[0]["CODEMP"].ToString();
            FormatoGrilla();
            decimal hor1 = FechaSis.Hour;            
            if (hor1 >= 7 && hor1 < 15)
            {
                txtTurno.Text = "1er Turno";
                turno = 1;
            }
            if (hor1 >= 15 && hor1 < 23)
            {
                txtTurno.Text = "2do Turno";
                turno = 2;
            }

            if ((hor1 >= 1 && hor1 < 7) || hor1 == 23 || hor1 == 24)
            {
                txtTurno.Text = "3er Turno";
                turno = 3;
            }
        }

        DataView dv1 = new DataView();
        private void btnOrden_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Frm_Busqueda frm = new Frm_Busqueda();
            //OT = Orden de Trabajo
            frm.Busqueda = "OT";
            frm.ShowDialog();
            txtOrden.Text = frm.vOrdenTrabajo;
            txtCodDpto.Text = frm.vCodDpto;
            txtDescripcionDPTO.Text = frm.vequipo;
            txtDpto.Text = frm.vdpto;
            if ((frm.vOrdenTrabajo.Trim() == "0") || (frm.vOrdenTrabajo.Trim() == "99"))
            {
                try
                {
                    dv1 = new DataView(Program.dtEmpleados, "CODIGO = '" + Program.codplanillaUSU + "'", "", DataViewRowState.OriginalRows);
                    if (dv1.Count > 0)
                    {
                        txtCodDpto.Text = dv1[0]["PUESTO"].ToString().Trim();
                    }
                    dv1 = new DataView(Program.dtArea, "T01ESP = '" + txtCodDpto.Text + "'", "", DataViewRowState.OriginalRows);
                    if (dv1.Count > 0)
                    {
                        txtDpto.Text = dv1[0]["T01AL1"].ToString().Trim();
                    }
                }
                catch { txtCodDpto.Text = ""; txtDpto.Text = ""; }
            }
            this.Cursor = Cursors.Default;   
        }

        private void txtOrden_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {

                    dv = new DataView(Program.dtCCostos, "ODTCOD = '" + txtOrden.Text.ToString() + "'", "ODTCOD ASC", DataViewRowState.OriginalRows);
                    if (dv.Count >= 1)
                    {
                        txtCodDpto.Text = dv[0][2].ToString();
                        txtDescripcionDPTO.Text = dv[0][3].ToString();
                        txtDpto.Text = dv[0][4].ToString();

                        if ((txtCodDpto.Text.Trim() == "0") || (txtCodDpto.Text.Trim() == "99"))
                        {
                            try
                            {
                                dv1 = new DataView(Program.dtEmpleados, "CODIGO = '" + Program.codplanillaUSU + "'", "", DataViewRowState.OriginalRows);
                                if (dv1.Count > 0)
                                {
                                    txtCodDpto.Text = dv1[0]["PUESTO"].ToString().Trim();
                                }
                                dv1 = new DataView(Program.dtArea, "T01ESP = '" + txtCodDpto.Text + "'", "", DataViewRowState.OriginalRows);
                                if (dv1.Count > 0)
                                {
                                    txtDpto.Text = dv1[0]["T01AL1"].ToString().Trim();
                                }
                            }
                            catch { txtCodDpto.Text = ""; txtDpto.Text = ""; }
                        }
                    }
                    else
                    {

                        MessageBox.Show("No Existe Orden Trabajo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtOrden.Text = "";
                        txtOrden.Focus();
                        txtCodDpto.Text = "";
                        txtDescripcionDPTO.Text = "";
                        txtDpto.Text = "";
                    }
                }
                oControl.Numero(e, txtOrden);
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Frm_Busqueda frm = new Frm_Busqueda();
            //OT = Orden de Trabajo
            frm.Busqueda = "AU";
            frm.ShowDialog();
            txtAutorizacion.Text = frm.vEmpleado;
            codEmpleado = frm.vCodEmpleado;
            this.Cursor = Cursors.Default; 
        }

        private void btnHelpCodProd_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Transaccion.Frm_Productos_AI frm = new Logistica.Ingenieria.Presentacion.Transaccion.Frm_Productos_AI();
            frm.ShowDialog();
            vCodigoProd = frm.vCodigoProd.Trim();
            vDescripcion = frm.vDescripcion.Trim();
            vStockC = frm.vStockC;
            vStockD = frm.vStockD;
            vUndMed = frm.vUndMed.Trim();
            vPrecioSoles = frm.vPrecioSoles;
            vPrecioDolares = frm.vPrecioDolares;
            vUbicacion = frm.vUbicacion.Trim();

            vCuentaCargo = frm.vCuentaCargo;
            vCtaAlmacen = frm.vCtaAlmacen;
            vProcedencia = frm.vProcedencia;

            TxtCodProd.Text = vCodigoProd.Trim();
            txtDesProd.Text = vDescripcion.Trim();            
            if (txtDesProd.Text != "")
            {
                txtCantidad.Enabled = true;
                lblUndMed.Text = vUndMed;
                txtCantidad.Focus();
            }        
            
            this.Cursor = Cursors.Default; 
        }

        private void FormatoGrilla()
        {
            tbldetalle = new DataTable("tabll1");
            tbldetalle.Columns.Add(new DataColumn("codProd", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("desProd", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("PrecioS", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("PrecioD", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("Cantidad", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("UndMeda", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("TotalS", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("TotalD", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("stockD", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("stockC", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("vCuentaCargo", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("vCtaAlmacen", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("vProcedencia", typeof(decimal)));


            tbldetalle.PrimaryKey = new DataColumn[] { tbldetalle.Columns[0] };
            dgvDetReq.DataSource = tbldetalle;

            dgvDetReq.Columns["codProd"].HeaderText = "Producto";
            dgvDetReq.Columns["desProd"].HeaderText = "Descripcion";
            dgvDetReq.Columns["PrecioS"].HeaderText = "Precio S/.";
            dgvDetReq.Columns["PrecioD"].HeaderText = "Precio $/.";
            dgvDetReq.Columns["Cantidad"].HeaderText = "Cantidad";
            dgvDetReq.Columns["UndMeda"].HeaderText = "Unid. Med.";
            dgvDetReq.Columns["TotalS"].HeaderText = "Total S/.";
            dgvDetReq.Columns["TotalD"].HeaderText = "Total $/.";
            dgvDetReq.Columns["stockD"].HeaderText = "Stck.Con.";
            dgvDetReq.Columns["stockC"].HeaderText = "Stck.Dis.";

            dgvDetReq.Columns["codProd"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["desProd"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["PrecioS"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["PrecioD"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["Cantidad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["UndMeda"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["TotalS"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["TotalD"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["stockD"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["stockC"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDetReq.Columns["codProd"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["desProd"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDetReq.Columns["PrecioS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["PrecioD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["Cantidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetReq.Columns["UndMeda"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDetReq.Columns["TotalS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["TotalD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["stockD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["stockC"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dgvDetReq.Columns["codProd"].Width = 150;
            dgvDetReq.Columns["desProd"].Width = 300; 
            dgvDetReq.Columns["Cantidad"].Width = 100;
            dgvDetReq.Columns["UndMeda"].Width = 100;
            dgvDetReq.Columns["stockD"].Width = 100;
            dgvDetReq.Columns["stockC"].Width = 100;

            dgvDetReq.Columns["PrecioS"].Visible = false;
            dgvDetReq.Columns["PrecioD"].Visible = false;
            dgvDetReq.Columns["TotalS"].Visible = false;
            dgvDetReq.Columns["TotalD"].Visible = false;
            dgvDetReq.Columns["vCuentaCargo"].Visible = false;
            dgvDetReq.Columns["vCtaAlmacen"].Visible = false;
            dgvDetReq.Columns["vProcedencia"].Visible = false;

            dgvDetReq.Columns["PrecioS"].DefaultCellStyle.Format = "0,0.00";
            dgvDetReq.Columns["PrecioD"].DefaultCellStyle.Format = "0,0.00";

            dgvDetReq.Columns["Cantidad"].DefaultCellStyle.Format = "0.000";

            dgvDetReq.Columns["stockD"].DefaultCellStyle.Format = "0,0.00";
            dgvDetReq.Columns["stockC"].DefaultCellStyle.Format = "0,0.00";
            dgvDetReq.Columns["TotalS"].DefaultCellStyle.Format = "0,0.00";
            dgvDetReq.Columns["TotalD"].DefaultCellStyle.Format = "0,0.00";

        }

        void Agregar()
        {
            CalcularDatarow();
            try
            {
                string cantiText = txtCantidad.Text.Trim();
                string codProd = TxtCodProd.Text.Trim();
                string DesProd = txtDesProd.Text.Trim();

                if ((cantiText != "") && (cantiText != "0"))
                {
                    //if (Convert.ToInt16(txtCanProd.Text) > wStock)
                    //{
                    //    MessageBox.Show("No cuenta con el Stock Suficiente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //    LimpiarProductos();
                    //    return;
                    //}
                    dr = tbldetalle.NewRow();
                    //dr["codProd"] = TxtCodProd.Text.Trim();
                    dr["codProd"] = vCodigoProd;
                    dr["desProd"] = vDescripcion;
                    dr["PrecioS"] = vPrecioSoles;
                    dr["PrecioD"] = vPrecioDolares;
                    dr["Cantidad"] = Cantidad;
                    dr["UndMeda"] = vUndMed;
                    dr["TotalS"] = TotalS;
                    dr["TotalD"] = TotalD;
                    dr["stockD"] = vStockD;
                    dr["stockC"] = vStockC;
                    dr["vProcedencia"] = vProcedencia;
                    dr["vCtaAlmacen"] = vCtaAlmacen;
                    dr["vCuentaCargo"] = vCuentaCargo;
                    tbldetalle.Rows.Add(dr);
                    tbldetalle.AcceptChanges();
                    LimpiarProd();
                    CalcularTotal();
                }
                else
                {
                    MessageBox.Show("Ingrese Cantidad", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCantidad.Text = "";
                    txtCantidad.Focus();
                }
            }
            catch
            {
                if (MessageBox.Show("El producto ya Existe Desea Actualizar los cambios", "Actualizar", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    dr = tbldetalle.Rows.Find(TxtCodProd.Text.ToString());
                    dr.BeginEdit();
                    dr["codProd"] = TxtCodProd.Text.Trim();
                    dr["desProd"] = vDescripcion;
                    dr["PrecioS"] = vPrecioSoles;
                    dr["PrecioD"] = vPrecioDolares;
                    dr["Cantidad"] = Cantidad;
                    dr["UndMeda"] = vUndMed;
                    dr["TotalS"] = TotalS;
                    dr["TotalD"] = TotalD;
                    dr["stockD"] = vStockD;
                    dr["stockC"] = vStockC;
                    dr["vProcedencia"] = vProcedencia;
                    dr["vCtaAlmacen"] = vCtaAlmacen;
                    dr["vCuentaCargo"] = vCuentaCargo;
                    dr.EndEdit();
                    tbldetalle.AcceptChanges();
                    LimpiarProd();
                    CalcularTotal();
                }
            }


        }

        void CalcularDatarow()
        {
            if (txtCantidad.Text != "") { Cantidad = Convert.ToDecimal(txtCantidad.Text); }
            TotalS = Math.Round((Cantidad * vPrecioSoles), 3);
            TotalD = Math.Round((Cantidad * vPrecioDolares), 3);
        }
        private void CalcularTotal()
        {
            try
            {
                string TotalTS = tbldetalle.Compute("sum(TotalS)", "") == null ? "0" : tbldetalle.Compute("sum(TotalS)", "").ToString();
                string TotalTD = tbldetalle.Compute("sum(TotalD)", "") == null ? "0" : tbldetalle.Compute("sum(TotalD)", "").ToString();
                txtTotalS.Text = TotalTS;
                txtTotalD.Text = TotalTD;
            }
            catch { throw; }
        }
        private void LimpiarProd()
        {
            vCodigoProd = "";
            vDescripcion = "";
            vStockC = 0;
            vStockD = 0;
            vUndMed = "";
            vPrecioSoles = 0;
            vPrecioDolares = 0;
            vUbicacion = "";

            lblUndMed.Text = "";

            TxtCodProd.Text = "";
            txtDesProd.Text = "";
            txtCantidad.Text = "";
            txtCantidad.Enabled = false;
            TxtCodProd.Focus();
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Agregar();
        }        

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetReq.Rows.Count >= 1)
                {
                    if (MessageBox.Show("Desea Eliminar Producto", "Eliminar", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        string naza = dgvDetReq[0, dgvDetReq.CurrentCell.RowIndex].Value.ToString();
                        dr = tbldetalle.Rows.Find(Convert.ToString(naza));
                        dr.Delete();
                        tbldetalle.AcceptChanges();
                        CalcularTotal();
                    }
                }
            }
            catch { }
        }

        private void TxtCodProd_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    if (TxtCodProd.Text != "")
                    {
                        objBus = new BTablas();
                        DataTable dtProdBusq = new DataTable();
                        dtProdBusq = objBus.getProductosRequerimientoXCodigo(TxtCodProd.Text.Trim(), Program.Cuentas);
                        if (dtProdBusq.Rows.Count > 0)
                        {
                            vCodigoProd = dtProdBusq.Rows[0]["MPMCOD"].ToString();
                            vDescripcion = dtProdBusq.Rows[0]["MPMDES"].ToString();
                            vStockC = Convert.ToDecimal(dtProdBusq.Rows[0]["MPMSCO"]);
                            vStockD = Convert.ToDecimal(dtProdBusq.Rows[0]["MPMSDI"]);
                            vUndMed = dtProdBusq.Rows[0]["T01AL1"].ToString();
                            vPrecioSoles = Convert.ToDecimal(dtProdBusq.Rows[0]["MPMCPR"]);
                            vPrecioDolares = Convert.ToDecimal(dtProdBusq.Rows[0]["MPMCDO"]); 
                            vUbicacion = dtProdBusq.Rows[0]["MPMUBI"].ToString();
                            vCuentaCargo = Convert.ToDecimal(dtProdBusq.Rows[0]["MPMCCA"].ToString());
                            vCtaAlmacen = Convert.ToDecimal(dtProdBusq.Rows[0]["MPMCTA"].ToString());
                            vProcedencia = Convert.ToDecimal(dtProdBusq.Rows[0]["MPMPRO"].ToString());


                            txtCantidad.Enabled = true;
                            txtCantidad.Focus();
                            TxtCodProd.Text = vCodigoProd;
                            txtDesProd.Text = vDescripcion;
                        }
                        else
                        {
                            TxtCodProd.Text = "";
                            TxtCodProd.Focus();
                            MessageBox.Show("Cod.Prod. No Existe", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingresar Cod.Prod.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                oControl.Numero(e, TxtCodProd);                
            }
            catch { }
        }


        void Busqueda_Productos(string CodProd)
        {
            this.Cursor = Cursors.WaitCursor;
            objBus = new BTablas();
            DataTable dtProdBusq = new DataTable();
            dtProdBusq = objBus.getProductosRequerimientoXCodigo(CodProd, Program.Cuentas);
            if (dtProdBusq.Rows.Count > 0)
            {
                vCodigoProd = dtProdBusq.Rows[0]["MPMCOD"].ToString();
                vDescripcion = dtProdBusq.Rows[0]["MPMDES"].ToString();
                vStockC = Convert.ToDecimal(dtProdBusq.Rows[0]["MPMSCO"]);
                vStockD = Convert.ToDecimal(dtProdBusq.Rows[0]["MPMSDI"]);
                vUndMed = dtProdBusq.Rows[0]["T01AL1"].ToString();
                vPrecioSoles = Convert.ToDecimal(dtProdBusq.Rows[0]["MPMCPR"]);
                vPrecioDolares = Convert.ToDecimal(dtProdBusq.Rows[0]["MPMCDO"]);
                vUbicacion = dtProdBusq.Rows[0]["MPMUBI"].ToString();
                vCuentaCargo = Convert.ToDecimal(dtProdBusq.Rows[0]["MPMCCA"].ToString());
                vCtaAlmacen = Convert.ToDecimal(dtProdBusq.Rows[0]["MPMCTA"].ToString());
                vProcedencia = Convert.ToDecimal(dtProdBusq.Rows[0]["MPMPRO"].ToString());

                TxtCodProd.Text = vCodigoProd;
                txtDesProd.Text = vDescripcion;
                if (txtDesProd.Text != "")
                {
                    txtCantidad.Enabled = true;
                    lblUndMed.Text = vUndMed;
                    txtCantidad.Focus();
                }
                this.Cursor = Cursors.Default;                
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    Agregar();
                }
            }
            catch { }
            /****Validar para ingresar decimales o no segun el tipo de Unidad Medida*/
            oControl.NumeroDec(e, txtCantidad);
            /****Validar para ingresar decimales o no segun el tipo de Unidad Medida*/
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if ((txtOrden.Text != "") || (dgvDetReq.Rows.Count>0))
            {
                if (MessageBox.Show("Se perderán los cambios...", "Requerimiento", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            if ((txtOrden.Text != "") || (dgvDetReq.Rows.Count > 0))
            {
                if (MessageBox.Show("Se perderán los cambios...", "Requerimiento", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
        }

        private void txtOrden_TextChanged(object sender, EventArgs e)
        {
            try
            {
                    dv = new DataView(Program.dtCCostos, "ODTCOD = '" + txtOrden.Text.ToString() + "'", "ODTCOD ASC", DataViewRowState.OriginalRows);
                    if (dv.Count >= 1)
                    {
                        txtCodDpto.Text = dv[0][2].ToString();
                        txtDescripcionDPTO.Text = dv[0][3].ToString();
                        txtDpto.Text = dv[0][4].ToString();

                        if ((txtCodDpto.Text.Trim() == "0") || (txtCodDpto.Text.Trim() == "99"))
                        {
                            try
                            {
                                dv1 = new DataView(Program.dtEmpleados, "CODIGO = '" + Program.codplanillaUSU + "'", "", DataViewRowState.OriginalRows);
                                if (dv1.Count > 0)
                                {
                                    txtCodDpto.Text = dv1[0]["PUESTO"].ToString().Trim();
                                }
                                dv1 = new DataView(Program.dtArea, "T01ESP = '" + txtCodDpto.Text + "'", "", DataViewRowState.OriginalRows);
                                if (dv1.Count > 0)
                                {
                                    txtDpto.Text = dv1[0]["T01AL1"].ToString().Trim();
                                }
                            }
                            catch { txtCodDpto.Text = ""; txtDpto.Text = ""; }
                        }
                    }
                    else
                    {
                        //MessageBox.Show("No Existe Orden Trabajo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //txtOrden.Text = "";
                        //txtOrden.Focus();
                        txtCodDpto.Text = "";
                        txtDescripcionDPTO.Text = "";
                        txtDpto.Text = "";
                    }
            }
            catch { }
        }

        string fecha = "";
        string Hora = "";
        string nroReq = "";
        string Nro = "";
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            FechaSis = DateTime.Now; 
            if (txtOrden.Text == "") { MessageBox.Show("Ingresar Orden Trabajo", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Error); txtOrden.Focus(); this.Cursor = Cursors.Default; return; }
            if (dgvDetReq.Rows.Count == 0) { MessageBox.Show("Ingresar Items", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Error); TxtCodProd.Focus(); this.Cursor = Cursors.Default; return; }

            string Hostmaquina = Program.Usuario.Trim();
            if (MessageBox.Show("Se Procedera a Grabar Req.", "Alm.Ing", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                objTran = new BTransaccion();
                switch (Hostmaquina)
                {
                    case "PCFME1":
                        Nro = objTran.getCorrelativoReq(Program.HostPC.Trim()).Rows[0]["CORR"].ToString();
                        nroReq = Program.HostPC.Trim() + " - " + Nro;
                        break;
                    case "PCFME2":
                        Nro = objTran.getCorrelativoReq(Program.HostPC.Trim()).Rows[0]["CORR"].ToString();
                        nroReq = Program.HostPC.Trim() + " - " + Nro;
                        break;
                    case "PCFME3":
                        Nro = objTran.getCorrelativoReq(Program.HostPC.Trim()).Rows[0]["CORR"].ToString();
                        nroReq = Program.HostPC.Trim() + " - " + Nro;
                        break;
                    default:
                        Nro = objTran.getCorrelativoReq("PCOTR1").Rows[0]["CORR"].ToString();
                        nroReq = Hostmaquina + " - " + Nro;
                        break;
                }
                int h = 0;
                switch (Hostmaquina)
                {
                    case "PCFME1":
                        h = objTran.BUpdateCorrelativo(Nro, Program.HostPC.Trim());
                        break;
                    case "PCFME2":
                        h = objTran.BUpdateCorrelativo(Nro, Program.HostPC.Trim());
                        break;
                    case "PCFME3":
                        h = objTran.BUpdateCorrelativo(Nro, Program.HostPC.Trim());
                        break;
                    default:
                        h = objTran.BUpdateCorrelativo(Nro, "PCOTR1");
                        break;
                }
                fecha = FechaSis.ToShortDateString().Substring(6, 4) + FechaSis.ToShortDateString().Substring(3, 2) + FechaSis.ToShortDateString().Substring(0, 2);
                Hora = FechaSis.Hour.ToString() + FechaSis.Minute.ToString(); 
                GrabarCabecera();
                GrabaDetalle();

                formatoCorreo(nroReq);

                objTran = new BTransaccion();
                MessageBox.Show("Requerimiento Ingresado Correctamente " + nroReq.Trim(), "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                this.Close();
            }
            this.Cursor = Cursors.Default;
        }

        void GrabarCabecera()
        {
            eCabReq = new EReqCabecera();
            eCabReq.Situacion = "S";
            eCabReq.NroRequerimiento = nroReq;
            eCabReq.TipoSalida = 1;
            eCabReq.FechaSalida = Convert.ToDecimal(fecha);
            eCabReq.Turno = turno;
            eCabReq.Area = Convert.ToDecimal(txtCodDpto.Text);
            eCabReq.Autorizado = Convert.ToDecimal(Program.codplanillaUSU);//Convert.ToDecimal(codEmpleado);
            eCabReq.Solicitante = Convert.ToDecimal(codSolicita);
            eCabReq.OrdenTrabajo = Convert.ToDecimal(txtOrden.Text);
            /********Verificarlo************/
            eCabReq.Recibido = 0;
            eCabReq.TipoAlmacen = "";
            /******************************/
            eCabReq.ImpSoles = Convert.ToDecimal(txtTotalS.Text);
            eCabReq.ImpDolares = Convert.ToDecimal(txtTotalD.Text);
            eCabReq.UserGenera = Program.Usuario;
            /*******************Actualizacion************************/
            eCabReq.CodUserGenera = Convert.ToDecimal(codSolicita);
            eCabReq.CodUserAprueba1 = 0;
            eCabReq.CodUserAprueba2 = 0;
            eCabReq.CodUserAprueba3 = 0;



            eCabReq.UserAprueba1 = "";
            eCabReq.UserAprueba2 = "";
            eCabReq.UserAprueba3 = "";
            /********************************************************/
            eCabReq.FechaGenera = fecha;
            /*******************Actualizacion************************/
            eCabReq.FechaAprueba1 = "";
            eCabReq.FechaAprueba2 = "";
            eCabReq.FechaAprueba3 = "";
            /********************************************************/
            eCabReq.HoraMinuto = Convert.ToDecimal(Hora);
            /*******************Actualizacion************************/
            eCabReq.Estado = "1";
            eCabReq.NroValeSalida = 0;
            eCabReq.FechaValeSalida = 0;
            eCabReq.HoraValeSalida = 0;
            eCabReq.UsuarioDespacha = "";
            /********************************************************/
            objTran = new BTransaccion();
            int i = objTran.BInsertCabReq(eCabReq);
        }
        void GrabaDetalle()
        {
            for (int i = 0; i <= dgvDetReq.Rows.Count - 1; i++)
            {
                EDetReq = new EReqDetalle();
                EDetReq.Situacion = "S";
                EDetReq.NroReqSalida = nroReq;
                EDetReq.NroItem = Convert.ToDecimal(i + 1);
                EDetReq.CodMatPrima = dgvDetReq["codProd", i].Value.ToString();
                EDetReq.CtaCargo = Convert.ToDecimal(dgvDetReq["vCuentaCargo", i].Value.ToString());
                EDetReq.Procedencia = Convert.ToDecimal(dgvDetReq["vProcedencia", i].Value.ToString());
                EDetReq.CtaAlmacen = Convert.ToDecimal(dgvDetReq["vCtaAlmacen", i].Value.ToString());
                EDetReq.CantidadSoli = Convert.ToDecimal(dgvDetReq["Cantidad", i].Value.ToString());
                /*******************Actualizacion************************/
                EDetReq.CantidadAte = 0;
                /********************************************************/
                EDetReq.ImpSoles = Convert.ToDecimal(dgvDetReq["TotalS", i].Value.ToString());
                EDetReq.ImpDolares = Convert.ToDecimal(dgvDetReq["TotalD", i].Value.ToString());
                /*******************Actualizacion************************/
                EDetReq.Estado = "1";
                EDetReq.NroValeSalida = 0;
                EDetReq.FechaSalida = 0;
                EDetReq.HoraSalida = 0;
                EDetReq.UserDespacha = "";
                /********************************************************/
                objTran = new BTransaccion();
                int j = objTran.BInsertDetReq(EDetReq);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Transaccion.Frm_Productos_AI_A2 frm = new Logistica.Ingenieria.Presentacion.Transaccion.Frm_Productos_AI_A2();
            frm.ShowDialog();
            vCodigoProd = frm.vCodigoProd.Trim();
            Busqueda_Productos(vCodigoProd);
            this.Cursor = Cursors.Default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Transaccion.Frm_Productos_AI frm = new Logistica.Ingenieria.Presentacion.Transaccion.Frm_Productos_AI();
            frm.TIPOCONSULTA = "REQ";
            frm.ShowDialog();
            vCodigoProd = frm.vCodigoProd.Trim();
            vDescripcion = frm.vDescripcion.Trim();
            vStockC = frm.vStockC;
            vStockD = frm.vStockD;
            vUndMed = frm.vUndMed.Trim();
            vPrecioSoles = frm.vPrecioSoles;
            vPrecioDolares = frm.vPrecioDolares;
            vUbicacion = frm.vUbicacion.Trim();
            vCuentaCargo = frm.vCuentaCargo;
            vCtaAlmacen = frm.vCtaAlmacen;
            vProcedencia = frm.vProcedencia;
            TxtCodProd.Text = vCodigoProd.Trim();
            txtDesProd.Text = vDescripcion.Trim();  
            if (txtDesProd.Text != "")
            {
                txtCantidad.Enabled = true;
                lblUndMed.Text = vUndMed;
                txtCantidad.Focus();
            }            
            this.Cursor = Cursors.Default; 
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Transaccion.Frm_Grupo frm = new Logistica.Ingenieria.Presentacion.Transaccion.Frm_Grupo();
            frm.variableForm = "REQUI";
            frm.ShowDialog();
            vCodigoProd = frm.vCodigoProd.Trim();            
            Busqueda_Productos(vCodigoProd);
            this.Cursor = Cursors.Default;
        }

        private void Frm_Requerimiento_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        void formatoCorreo(string NroRequi)
        {
            /*ENVIO DE CORREO*/
            DataTable dtCorreoSup = new DataTable();
            StringBuilder mensaje = new StringBuilder();
            mensaje.Append(Program.NomCorreo + " ha realizado la requisicion  : " + NroRequi + " con los siguientes ITEMS : \n\n");
            for (int i = 0; i <= dgvDetReq.Rows.Count - 1; i++)
            {
                mensaje.Append(dgvDetReq["codProd", i].Value.ToString().Trim() + " - " + dgvDetReq["desProd", i].Value.ToString().Trim() + " ----> " + dgvDetReq["Cantidad", i].Value.ToString().Trim() + "\n");                                
            }
            mensaje.Append("\n porfavor si seria tan amable de aprobar o desaprobar.");
            oBusConf = new BConfiguracion();
            dtCorreoSup = oBusConf.getCargaOpcionesSUPERVISORXSOLICITANTE(Program.Usuario);
            if (dtCorreoSup.Rows.Count > 0)
            {
                envioCorreo("sistemas@limacaucho.com.pe", dtCorreoSup.Rows[0]["FILLER"].ToString().Trim(), "Requerimiento Pendientes por Aprobar", mensaje.ToString());
            }
        }

        void envioCorreo(string emisor, string receptor, string asunto, string mensaje1)
        {
            string servidor = "limacaucho.com.pe";
            //Crea el mensaje estableciendo quién lo manda y quién lo recibe
            //MailMessage mensaje = new MailMessage(emisor.Text, receptor.Text, asunto.Text, mensaje.Text);

            //MailMessage mensaje = new MailMessage("iespinoza@limacaucho.com.pe", "iespinoza@limacaucho.com.pe", "xxxxx", "xxxxxxxxxx");
            MailMessage mensaje = new MailMessage(emisor, receptor, asunto, mensaje1);
            //Envía el mensaje.
            SmtpClient cliente = new SmtpClient(servidor);
            //Añade credenciales si el servidor lo requiere.
            cliente.Credentials = CredentialCache.DefaultNetworkCredentials;
            cliente.Send(mensaje);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Frm_Busqueda frm = new Frm_Busqueda();
            //OT = Orden de Trabajo
            frm.Busqueda = "CCT";
            frm.ShowDialog();
            txtCodDpto.Text = frm.vCentroCosto.Trim();
            txtDpto.Text = frm.vDescriCentroCosto.Trim();
            this.Cursor = Cursors.Default;

        }




    }
}
