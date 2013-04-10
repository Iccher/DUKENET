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

namespace Logistica.Ingenieria.Presentacion.Transaccion
{
    public partial class Frm_Generacion_Vale : Form
    {
        public Frm_Generacion_Vale()
        {
            InitializeComponent();
        }

        public decimal vCodTurno = 0;
        public decimal vCodArea = 0;
        public decimal vCodAutoriz = 0;
        public decimal vCodAutorizSupervisor = 0;
        public decimal vCodSolicitud = 0;
        public decimal vCodOrdenTrabajo = 0;


        public string vnroSal = "";
        public string vArea = "";
        public string vOrdeTrab = "";
        public string vNroOrdeTrab = "";
        public string vTurno = "";
        public string vSolic = "";

        public string vSTATUS = "";
        public string vESTADO = "";

        public string vPARCIALES = "";
        /**********CODIGO DE RECIBE***********/
        private decimal vCodRecibe = 0;

        /*Calculo de Importes a Aprobar*/
        decimal Soles = 0;
        decimal Dolares = 0;
        decimal ImporteAprob = 0;

        BTransaccion obTran = new BTransaccion();
        TControlVB oControl = new TControlVB();
        EValeSalida eVale = new EValeSalida();
        EReqDetalle eReqDet = new EReqDetalle();

        DateTime FechaSis = DateTime.Now;

        public static Boolean Actualiza;
        DataTable dtREQUERIMIENTOSDETALLES = new DataTable();

        private void Frm_Generacion_Vale_Load(object sender, EventArgs e)
        {
            txtDescripcionDPTO.Text = vOrdeTrab;
            txtDpto.Text = vArea;
            txtSolicitante.Text = vSolic;
            obTran = new BTransaccion();
            dtREQUERIMIENTOSDETALLES = obTran.getConDetalleRequeXCodigo(vnroSal);
            dgvDetReq.DataSource = dtREQUERIMIENTOSDETALLES;
            dgvDetReq.GridColor = Color.Red;
            Grilla();
            Totales();

            /*Ingresado para la modificacion de REQUERIMIENTO*/
            if (Program.Usuario == "LMAIFCR1")
            {
                toolStripButton6.Enabled = true;
            }
        }
        void Grilla()
        {
            dgvDetReq.Columns["A12IMP"].Visible = false;
            dgvDetReq.Columns["A12IMD"].Visible = false;
            dgvDetReq.Columns["A12PRO"].Visible = false;
            dgvDetReq.Columns["A12CTA"].Visible = false;
            dgvDetReq.Columns["A12CCA"].Visible = false;
            dgvDetReq.Columns["MPMSCO"].Visible = false;

            dgvDetReq.Columns["MPMCPR"].Visible = false;
            dgvDetReq.Columns["MPMCDO"].Visible = false;

            dgvDetReq.Columns["A12COD"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvDetReq.Columns["MPMDES"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvDetReq.Columns["A12CAS"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvDetReq.Columns["A12CAD"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvDetReq.Columns["CantiAted"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvDetReq.Columns["T01AL1"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvDetReq.Columns["MPMUBI"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvDetReq.Columns["MPMSDI"].SortMode = DataGridViewColumnSortMode.NotSortable;

            dgvDetReq.Columns["A12COD"].DisplayIndex = 0;
            dgvDetReq.Columns["MPMDES"].DisplayIndex = 1;
            dgvDetReq.Columns["MPMUBI"].DisplayIndex = 2;
            dgvDetReq.Columns["MPMSDI"].DisplayIndex = 3;
            dgvDetReq.Columns["A12CAS"].DisplayIndex = 4;
            dgvDetReq.Columns["A12CAD"].DisplayIndex = 5;
            dgvDetReq.Columns["CantiAted"].DisplayIndex = 6;
            dgvDetReq.Columns["T01AL1"].DisplayIndex = 7;

            
            dgvDetReq.Columns["A12COD"].HeaderText = "Codigo";
            dgvDetReq.Columns["MPMDES"].HeaderText = "Descripción";
            dgvDetReq.Columns["MPMUBI"].HeaderText = "Ubicación";
            dgvDetReq.Columns["MPMSDI"].HeaderText = "Stock";
            dgvDetReq.Columns["A12CAS"].HeaderText = "Cant.Solic.";
            dgvDetReq.Columns["A12CAD"].HeaderText = "Cant.Atend.";
            dgvDetReq.Columns["CantiAted"].HeaderText = "Cantidad";
            dgvDetReq.Columns["T01AL1"].HeaderText = "Medida";

            dgvDetReq.Columns["A12COD"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["MPMDES"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["MPMUBI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["MPMSDI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["A12CAS"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["A12CAD"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["CantiAted"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["T01AL1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDetReq.Columns["A12COD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["MPMDES"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDetReq.Columns["MPMUBI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDetReq.Columns["MPMSDI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetReq.Columns["A12CAS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetReq.Columns["A12CAD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetReq.Columns["CantiAted"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetReq.Columns["T01AL1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvDetReq.Columns["CantiAted"].DefaultCellStyle.BackColor = Color.Gainsboro;
            dgvDetReq.Columns["MPMSDI"].DefaultCellStyle.BackColor = Color.NavajoWhite;

            dgvDetReq.Columns["A12COD"].ReadOnly = true;
            dgvDetReq.Columns["MPMDES"].ReadOnly = true;
            dgvDetReq.Columns["MPMUBI"].ReadOnly = true;
            dgvDetReq.Columns["MPMSDI"].ReadOnly = true;
            dgvDetReq.Columns["A12CAS"].ReadOnly = true;
            dgvDetReq.Columns["A12CAD"].ReadOnly = true;
            dgvDetReq.Columns["CantiAted"].ReadOnly = false;
            dgvDetReq.Columns["T01AL1"].ReadOnly = true;

            dgvDetReq.Columns["A12COD"].Width = 120;
            dgvDetReq.Columns["MPMDES"].Width = 350;
            dgvDetReq.Columns["MPMUBI"].Width = 105;
            dgvDetReq.Columns["MPMSDI"].Width = 60;
            dgvDetReq.Columns["A12CAS"].Width = 60;
            dgvDetReq.Columns["A12CAD"].Width = 70;
            dgvDetReq.Columns["CantiAted"].Width = 70;
            dgvDetReq.Columns["T01AL1"].Width = 105;

            for (int i = 0; i <= dgvDetReq.Rows.Count - 1; i++)
            {
                dgvDetReq["CantiAted", i].Value = "";
            }
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

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDetReq_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int columnIndex = dgvDetReq.CurrentCell.ColumnIndex;
            if (dgvDetReq.Columns[columnIndex].Name == "CantiAted")
            {
                DataGridViewTextBoxEditingControl dText = (DataGridViewTextBoxEditingControl)e.Control;

                dText.KeyPress -= new KeyPressEventHandler(dText_KeyPress);
                dText.KeyPress += new KeyPressEventHandler(dText_KeyPress);
            }            
        }

        void dText_KeyPress(object sender, KeyPressEventArgs e)
        {
            int columnIndex = dgvDetReq.CurrentCell.ColumnIndex;
            if (dgvDetReq.Columns[columnIndex].Name == "CantiAted")
            {
                if (((e.KeyChar) < 48 && e.KeyChar != 8 && e.KeyChar != 46) || (e.KeyChar > 57))
                {
                    //MessageBox.Show("No se Permiten Letras");
                    e.Handled = true;
                }                
                // e.KeyChar.IsDigit(e.KeyChar);
                //oControl.NumeroDec(e, e.KeyChar);
                //e.KeyChar = char.ToUpper(e.KeyChar);
            }
        }

        decimal canTotal = 0;
        string flat = "";
        void ValidarGrilla()
        {
            decimal can1 = 0;
            decimal can2 = 0;
            canTotal = 0;
            for (int i = 0; i <= dgvDetReq.Rows.Count - 1; i++)
            {
                can1 = Convert.ToDecimal(dgvDetReq["A12CAS", i].Value.ToString()) - Convert.ToDecimal(dgvDetReq["A12CAD", i].Value.ToString());         
                
                if (dgvDetReq["CantiAted", i].Value.ToString() == "")
                {
                    can2 = 0;                    
                }
                else
                {
                    can2 = Math.Round(Convert.ToDecimal(dgvDetReq["CantiAted", i].Value.ToString()), 3);
                    dgvDetReq["CantiAted", i].Value = Math.Round(Convert.ToDecimal(dgvDetReq["CantiAted", i].Value.ToString()), 3).ToString();
                }
                /*Validacion de Cantidad Atendida con lo pedido*/
                if (can2 > can1)
                {
                    dgvDetReq["CantiAted", i].Style.BackColor = Color.Red;
                }
                else
                {
                    dgvDetReq["CantiAted", i].Style.BackColor = Color.Gainsboro;
                }                

                canTotal = canTotal + can2;
            }

            for (int i = 0; i <= dgvDetReq.Rows.Count - 1; i++)
            {
                if (dgvDetReq["CantiAted", i].Style.BackColor == Color.Red)
                {
                    MessageBox.Show("Porfavor Corregir la cantidad a atender es mayor a la Solicitada", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    flat = "NO";
                    break;
                }
                else
                {
                    flat = "SI";
                }
            }
            
        }

        string fecha = "";
        string Hora = "";
        string usu = "";
        decimal nroVale = 0;
        string estado = "S";
        private void toolStripButton3_Click(object sender, EventArgs e)
        {

            ValidarGrilla();
            if (vCodRecibe == 0) { MessageBox.Show("Ingresar Codigo de la persona que Recibe Respuesto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

            if (flat != "NO")
            {
                if (canTotal == 0)
                {
                    MessageBox.Show("Porfavor Ingresra Cantidades a Atender Para Generar el VALE respectivo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    /*validaciones*/
                    decimal can1 = 0;
                    decimal can2 = 0;
                    for (int i = 0; i <= dgvDetReq.Rows.Count - 1; i++)
                    {
                        can1 = Convert.ToDecimal(dgvDetReq["A12CAS", i].Value.ToString()) - Convert.ToDecimal(dgvDetReq["A12CAD", i].Value.ToString());
                        if (dgvDetReq["CantiAted", i].Value.ToString() == "")
                        {
                            can2 = 0;
                        }
                        else
                        {
                            can2 = Math.Round(Convert.ToDecimal(dgvDetReq["CantiAted", i].Value.ToString()), 3);
                        }

                        /*Validacion de STOCK con el sistema*/
                        decimal stock = Math.Round(Convert.ToDecimal(dgvDetReq["MPMSDI", i].Value.ToString()), 3);
                        if (can2 > stock)
                        {
                            dgvDetReq["CantiAted", i].Style.BackColor = Color.Aquamarine;
                            MessageBox.Show("No tiene Stock", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error); return; 
                        }
                        else
                        {
                            dgvDetReq["CantiAted", i].Style.BackColor = Color.Gainsboro;
                        }
                        /*validacion de Requerimientos Parciales*/
                        
                        //canTotal = canTotal + can2;
                    }
                    //if (canTotal == 0) { MessageBox.Show("Porfavor Ingresra Cantidades a Atender Para Generar el VALE respectivo", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); return; }
                    /*******************************************/
                    for (int i = 0; i <= dgvDetReq.Rows.Count - 1; i++)
                    {
                        can1 = Convert.ToDecimal(dgvDetReq["A12CAS", i].Value.ToString()) - Convert.ToDecimal(dgvDetReq["A12CAD", i].Value.ToString());
                        if (dgvDetReq["CantiAted", i].Value.ToString() == "")
                        {
                            can2 = 0;
                        }
                        else
                        {
                            can2 = Math.Round(Convert.ToDecimal(dgvDetReq["CantiAted", i].Value.ToString()), 3);
                        }
                        if (can2 < can1)
                        {
                            MessageBox.Show("Este Requerimiento se Atendera Parcialmente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            estado = "SP";
                            break;
                        }
                    }



                    this.Cursor = Cursors.WaitCursor;
                    fecha = FechaSis.ToShortDateString().Substring(6, 4) + FechaSis.ToShortDateString().Substring(3, 2) + FechaSis.ToShortDateString().Substring(0, 2);

                    if (Convert.ToDecimal(FechaSis.Minute.ToString()) <= 9)
                    {
                        Hora = FechaSis.Hour.ToString() + "0" + FechaSis.Minute.ToString();
                    }
                    else
                    {
                        Hora = FechaSis.Hour.ToString() + FechaSis.Minute.ToString();
                    }
                    usu = Program.Usuario;                    
                    string est = estado;
                    if (MessageBox.Show("Se Procedera a Generar VALE", "Alm.Ing", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        obTran = new BTransaccion();
                        nroVale = Convert.ToDecimal(obTran.getCorrelativoVALESALIDA().Rows[0]["CORR"].ToString());
                        obTran = new BTransaccion();
                        int corr = obTran.BUpdateCorrelativoVALESALIDA(nroVale.ToString());
                        ActualizaBD();
                        if (corr == 1)
                        {
                            MessageBox.Show("El Vale Nro : " + Convert.ToString(nroVale) + " se genero exitosamente", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        Reportes.Frm_Reporte_Vale frmRep = new Logistica.Ingenieria.Presentacion.Reportes.Frm_Reporte_Vale();
                        frmRep.nro_Vale = nroVale;
                        frmRep.observacion = txtObs.Text.Trim().ToUpper();
                        frmRep.ShowDialog();
                    }                    
                    this.Cursor = Cursors.Default;
                    Transaccion.Frm_Aprobacion.Actualiza = true;
                    this.Close();
                }
            }
            
        }

        void ActualizaBD()
        {
            obTran = new BTransaccion();
            int j = obTran.BUpdateSQL("UPDATE " + Program.LibreLALMINGB + ".ALI011UTIL SET A11EST='" + estado + "',A11NVS=" + nroVale + ",A11FVS=" + fecha + ",A11HVS=" + Hora + ",A11UDE='" + Program.Usuario + "',A11COR=" + vCodRecibe + " WHERE A11NSA='" + vnroSal + "'");
            decimal can1 = 0;
            decimal can2 = 0;
            decimal item = 0;
            string MatPrima = "";

            for (int i = 0; i <= dgvDetReq.Rows.Count - 1; i++)
            {
                can1 = Convert.ToDecimal(dgvDetReq["A12CAS", i].Value.ToString()) - Convert.ToDecimal(dgvDetReq["A12CAD", i].Value.ToString());
                if ((dgvDetReq["CantiAted", i].Value.ToString() != "") && (dgvDetReq["CantiAted", i].Value.ToString() != "0"))
                {
                    item = item + 1;
                    can2 = Math.Round(Convert.ToDecimal(dgvDetReq["CantiAted", i].Value.ToString()), 3);
                    MatPrima = dgvDetReq["A12COD", i].Value.ToString();
                    obTran = new BTransaccion();
                    int K = obTran.BUpdateSQL("UPDATE " + Program.LibreLALMINGB + ".ALI012UTIL SET A12CAD= A12CAD + " + can2 + ",A12NVS=" + nroVale + ",A12FVS=" + fecha + ",A12HVS=" + Hora + ",A12UDE='" + Program.Usuario + "',A12COR=" + vCodRecibe + " WHERE A12NSA= '" + vnroSal + "' AND A12COD='" + MatPrima + "'");

                    eVale = new EValeSalida();
                    eVale.Status="S";
                    eVale.UserID = Program.Usuario;
                    eVale.FechaModif = Convert.ToDecimal(fecha);
                    eVale.HoraMin = Convert.ToDecimal(Hora);
                    eVale.NroVale=nroVale;
                    eVale.Item = item;
                    eVale.TipoSalida = 1;
                    eVale.FechaSalidad = Convert.ToDecimal(fecha);
                    eVale.Turno = vCodTurno;
                    eVale.CodArea = vCodArea;                    
                    eVale.CodMateriaPrima = MatPrima;

                    string ctaAlm = dgvDetReq["A12CTA", i].Value.ToString();
                    switch (ctaAlm)
                    {
                        case "10":
                            eVale.CtaCargo = 10;
                            break;
                        case "11":
                            eVale.CtaCargo = 12;
                            break;                            
                        case "12":
                            eVale.CtaCargo = 14;
                            break;
                        case "13":
                            eVale.CtaCargo = 16;
                            break;
                        default:
                            eVale.CtaCargo = Convert.ToDecimal(dgvDetReq["A12CCA", i].Value.ToString());
                            break;
                    }
                    eVale.Procedencia = Convert.ToDecimal(dgvDetReq["A12PRO", i].Value.ToString());
                    eVale.CtaAlmacen = Convert.ToDecimal(dgvDetReq["A12CTA", i].Value.ToString());
                    eVale.Cantidad = can2;
                    eVale.ImporteS = Math.Round(Convert.ToDecimal(dgvDetReq["A12IMP", i].Value.ToString()), 2);
                    eVale.ImporteD = Math.Round(Convert.ToDecimal(dgvDetReq["A12IMD", i].Value.ToString()), 2);
                    eVale.OrderTrabajo = vCodOrdenTrabajo;

                    /*ANTERIOR                    
                    eVale.CodAutoriza = vCodAutoriz;
                    eVale.CodSolicita = vCodSolicitud;
                    eVale.CodRecibe = vCodRecibe;
                    */

                    eVale.CodAutoriza = vCodAutoriz;
                    eVale.CodSolicita = vCodAutorizSupervisor;
                    eVale.CodRecibe = vCodSolicitud;
                    eVale.TipoAlmacen = "";//Convert.ToString(vnroSal);


                    eReqDet = new EReqDetalle();
                    eReqDet.NroReqSalida = vnroSal;
                    eReqDet.CodMatPrima = MatPrima;
                    eReqDet.CantidadAte = can2;
                    eReqDet.NroValeSalida = nroVale;
                    eReqDet.FechaSalida = Convert.ToDecimal(fecha);
                    eReqDet.UserDespacha = Program.Usuario;


                    obTran = new BTransaccion();
                    int p = obTran.BInsertDetReqAUDITADO(eReqDet, txtObs.Text.Trim().ToUpper(), Convert.ToString(vCodRecibe).ToString().Trim());
                    obTran = new BTransaccion();
                    int h = obTran.BInsertValeSalida(eVale);
                    obTran = new BTransaccion();
                    int g = obTran.BActStockALMMMAP(eVale);
                }                                              
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Frm_Busqueda frm = new Frm_Busqueda();
            //OT = Orden de Trabajo
            frm.Busqueda = "AU";
            frm.ShowDialog();
            txtRecibido.Text = frm.vEmpleado;
            if (frm.vCodEmpleado == "") { frm.vCodEmpleado = "0"; }
            vCodRecibe = Convert.ToDecimal(frm.vCodEmpleado);

            this.Cursor = Cursors.Default; 
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //if (vPARCIALES == "Generado Parcial")
            //{
            //    MessageBox.Show("Comienza a elminar parciales BABOSO");
            //}
            //else
            //{
                fecha = FechaSis.ToShortDateString().Substring(6, 4) + FechaSis.ToShortDateString().Substring(3, 2) + FechaSis.ToShortDateString().Substring(0, 2);
                Hora = FechaSis.Hour.ToString() + FechaSis.Minute.ToString();
                int ide = 0;
                string SQL = "";
                if (MessageBox.Show("Desea Rechazar Req.", "Alm.Ing", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    obTran = new BTransaccion();
                    SQL = "UPDATE " + Program.LibreLALMINGB + ".ALI011UTIL SET A11UDE = '" + Program.Usuario + "',A11HVS=" + Convert.ToDecimal(Hora) + ",A11FVS = '" + fecha + "', A11STT='E' WHERE A11NSA= '" + vnroSal.Trim() + "'";
                    ide = obTran.BUpdateSQL(SQL);
                }
                if (ide == 1)
                {
                    MessageBox.Show("Req. Rechazado Correctamente", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                Transaccion.Frm_Aprobacion.Actualiza = true;
                this.Close();
            //}


        }

        private void Frm_Generacion_Vale_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Frm_Modificacion_Req frm = new Frm_Modificacion_Req();
            frm.vnroSal = vnroSal;
            frm.vOrdeTrab = vNroOrdeTrab;
            frm.dtRequerimientoDetalle = dtREQUERIMIENTOSDETALLES;
            frm.ShowDialog();
        }

        private void Frm_Generacion_Vale_Activated(object sender, EventArgs e)
        {
            if (Actualiza == true)
            {

                txtDescripcionDPTO.Text = vOrdeTrab;
                txtDpto.Text = vArea;
                txtSolicitante.Text = vSolic;
                obTran = new BTransaccion();
                dtREQUERIMIENTOSDETALLES = obTran.getConDetalleRequeXCodigo(vnroSal);
                dgvDetReq.DataSource = dtREQUERIMIENTOSDETALLES;
                dgvDetReq.GridColor = Color.Red;
                Grilla();
                Totales();

                Actualiza = false;
            }
        }


    }
}
