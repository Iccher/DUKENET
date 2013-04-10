using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Net.Mail;

using System.Globalization;
using Logistica.Ingenieria.Bussiness;

namespace Logistica.Ingenieria.Presentacion.Transaccion
{
    public partial class Frm_Aprobacion_Detalle : Form
    {
        public Frm_Aprobacion_Detalle()
        {
            InitializeComponent();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public static Boolean Actualiza;

        public string vnroSal = "";
        public string vArea = "";
        public string vOrdeTrab = "";
        public string vNroOrdeTrab = "";

        public string vTurno = "";
        public string vSolic = "";

        public string vSTATUS = "";
        public string vESTADO = "";

        /*Calculo de Importes a Aprobar*/
        decimal Soles = 0;
        decimal Dolares = 0;
        decimal ImporteAprob = 0;

        DateTime FechaSis = DateTime.Now; 

        BTransaccion obTran = new BTransaccion();

        DataTable dtREQUERIMIENTOSDETALLES = new DataTable();
        private void Frm_Aprobacion_Detalle_Load(object sender, EventArgs e)
        {
            txtDescripcionDPTO.Text = vOrdeTrab;
            txtDpto.Text = vArea;
            txtSolicitante.Text = vSolic;
            dtREQUERIMIENTOSDETALLES = obTran.getConDetalleRequeXCodigo(vnroSal.Trim());
            dgvDetReq.DataSource = dtREQUERIMIENTOSDETALLES;
            dgvDetReq.GridColor = Color.Red;
            Grilla();
            Totales();

            if (Program.nivUsu == "5")
            {
                toolStrip2.Visible = false;
                label18.Visible = false;
            }

            if (Program.nivUsu == "1")
            {
                grpMonto.Visible = true;
            }
            else
            {
                grpAprobacion.Location = new Point(457, 388);
                lblAprobacion.Text = "Supervisor";
                if (Convert.ToDecimal(txtImpAprob.Text) >= Program.LimSuperv)
                {
                    lblAprobacion.Text = "Supervisor-Jefatura";
                }
                if (Convert.ToDecimal(txtImpAprob.Text) >= Program.LimJefe)
                {
                    lblAprobacion.Text = "Supervisor-Jefatura-Gerencia";
                }

                grpAprobacion.Visible = true;
            }

            /*Ingresado para la modificacion de REQUERIMIENTO*/
            if (Program.nivUsu == "3")
            {
                tbsModificar.Enabled = true;
            }

            
       
        }

        void Grilla()
        {
            dgvDetReq.Columns["A12CAD"].Visible = false;
            dgvDetReq.Columns["A12IMP"].Visible = false;
            dgvDetReq.Columns["A12IMD"].Visible = false;

            dgvDetReq.Columns["A12PRO"].Visible = false;
            dgvDetReq.Columns["A12CTA"].Visible = false;
            dgvDetReq.Columns["A12CCA"].Visible = false;
            dgvDetReq.Columns["MPMSCO"].Visible = false;
            dgvDetReq.Columns["MPMSDI"].Visible = false;
            dgvDetReq.Columns["MPMUBI"].Visible = false;

            dgvDetReq.Columns["MPMCPR"].Visible = false;
            dgvDetReq.Columns["MPMCDO"].Visible = false;


            dgvDetReq.Columns["A12COD"].DisplayIndex = 0;
            dgvDetReq.Columns["MPMDES"].DisplayIndex = 1;
            dgvDetReq.Columns["A12CAS"].DisplayIndex = 2;
            dgvDetReq.Columns["T01AL1"].DisplayIndex = 3;

            dgvDetReq.Columns["A12COD"].HeaderText = "Codigo";
            dgvDetReq.Columns["MPMDES"].HeaderText = "Descripción";
            dgvDetReq.Columns["A12CAS"].HeaderText = "Cantidad";
            dgvDetReq.Columns["T01AL1"].HeaderText = "Medida";

            dgvDetReq.Columns["A12COD"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["MPMDES"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["A12CAS"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["T01AL1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDetReq.Columns["A12COD"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetReq.Columns["MPMDES"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgvDetReq.Columns["A12CAS"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDetReq.Columns["T01AL1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvDetReq.Columns["A12COD"].Width = 120;
            dgvDetReq.Columns["MPMDES"].Width = 350;
            dgvDetReq.Columns["A12CAS"].Width = 120;
            dgvDetReq.Columns["T01AL1"].Width = 150;
        }

        void Totales()
        {
            for (int i = 0; i <= dgvDetReq.Rows.Count - 1; i++)
            {
                Soles = Soles + Convert.ToDecimal(dgvDetReq["A12IMP", i].Value.ToString());
                Dolares = Dolares + Convert.ToDecimal(dgvDetReq["A12IMD", i].Value.ToString());
            }
            ImporteAprob = Math.Round((Soles / Program.TipoCambio), 2);

            txtSoles.Text = string.Format("{0:0,0}",Soles);// Convert.ToString(Soles));
            txtDolares.Text = Convert.ToString(Dolares);
            txtImpAprob1.Text = string.Format("{0:0,0}",ImporteAprob);// Convert.ToString(ImporteAprob));


            txtImpAprob.Text = Convert.ToString(ImporteAprob);
        }

        string fecha = "";
        string Hora = "";

        string HoraJef = "";
        string HoraGer = "";

        string DIASEMANA = "";

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            FechaSis = DateTime.Now;

            CultureInfo ci = new CultureInfo("Es-Es");
            DIASEMANA = (ci.DateTimeFormat.GetDayName(FechaSis.DayOfWeek)).Substring(0, 1);
            //DIASEMANA = (ci.DateTimeFormat.GetDayName(FechaSis.DayOfWeek));
            //MessageBox.Show(DIASEMANA);

            fecha = FechaSis.ToShortDateString().Substring(6, 4) + FechaSis.ToShortDateString().Substring(3, 2) + FechaSis.ToShortDateString().Substring(0, 2);
            if (Convert.ToDecimal(FechaSis.Minute.ToString()) <= 9)
            {
                Hora = FechaSis.Hour.ToString() + "0" + FechaSis.Minute.ToString();
            }
            else
            {
                Hora = FechaSis.Hour.ToString() + FechaSis.Minute.ToString();
            }

            if (Convert.ToDecimal(FechaSis.AddMinutes(10).Minute.ToString()) <= 9)
            {
                HoraJef = FechaSis.AddMinutes(10).Hour.ToString() + "0" + FechaSis.AddMinutes(10).Minute.ToString();                
            }
            else
            {
                HoraJef = FechaSis.AddMinutes(10).Hour.ToString() + FechaSis.AddMinutes(10).Minute.ToString();                
            }

            if (Convert.ToDecimal(FechaSis.AddMinutes(20).Minute.ToString()) <= 9)
            {
                HoraGer = FechaSis.AddMinutes(20).Hour.ToString() + "0" + FechaSis.AddMinutes(20).Minute.ToString();
            }
            else
            {
                HoraGer = FechaSis.AddMinutes(20).Hour.ToString() + FechaSis.AddMinutes(20).Minute.ToString();
            }

            int ide = 0;
            if (MessageBox.Show("Desea Aprobar Req.", "Alm.Ing", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                switch (Program.nivUsu)
                {
                    case "3":

                        if ((vTurno == "1er Turno") && (((DIASEMANA != "s") && (DIASEMANA != "d")) && ((DIASEMANA != "S") && (DIASEMANA != "D"))))
                        {
                            if (Convert.ToDecimal(txtImpAprob.Text) >= Program.LimSuperv)
                            {
                                MessageBox.Show("El Req. excede el minimo importe en dolares que ud. puede aprobar, debe esperar a que el jefe encargado apruebe dicho Req. para que se puede generar el VALE de salida Respectivo ", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                obTran = new BTransaccion();
                                ide = obTran.BUpdateSQL("UPDATE " + Program.LibreLALMINGB + ".ALI011UTIL SET A11CA1 = '" + Convert.ToDecimal(Program.codplanillaUSU) + "', A11UA1 = '" + Program.Usuario + "',A11FA1 = '" + fecha + "',A11UH1=" + Convert.ToDecimal(Hora) + ",A11AUT = '" + Convert.ToDecimal(Program.codplanillaUSU) + "',A11EST='2',A11HAJ=" + Convert.ToDecimal(HoraJef) + ",A11HAG=" + Convert.ToDecimal(HoraGer) + " WHERE A11NSA= '" + vnroSal.Trim() + "'");
                                try
                                {
                                    envioCorreo(Program.correo, Program.correo2, "Aprobación de Requerimiento", "Tiene Requerimiento de repuestos pendientes por aprobar -->" + vnroSal.Trim());
                                }
                                catch { }

                            }
                            else
                            {
                                obTran = new BTransaccion();
                                ide = obTran.BUpdateSQL("UPDATE " + Program.LibreLALMINGB + ".ALI011UTIL SET A11CA1 = '" + Convert.ToDecimal(Program.codplanillaUSU) + "', A11UA1 = '" + Program.Usuario + "',A11FA1 = '" + fecha + "',A11UH1=" + Convert.ToDecimal(Hora) + ",A11AUT = '" + Convert.ToDecimal(Program.codplanillaUSU) + "',A11EST='D' WHERE A11NSA= '" + vnroSal.Trim() + "'");
                            }                         
                        }
                        else
                        {
                            if (Convert.ToDecimal(txtImpAprob.Text) >= Program.LimSuperv)
                            {
                                //MessageBox.Show("El Req. excede el minimo importe en dolares que ud. puede aprobar, se podra atender el VALE pero quedara pendiente de aprobar por su jefe respectivo", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                obTran = new BTransaccion();
                                ide = obTran.BUpdateSQL("UPDATE " + Program.LibreLALMINGB + ".ALI011UTIL SET A11CA1 = '" + Convert.ToDecimal(Program.codplanillaUSU) + "', A11UA1 = '" + Program.Usuario + "',A11FA1 = '" + fecha + "',A11UH1=" + Convert.ToDecimal(Hora) + ",A11AUT = '" + Convert.ToDecimal(Program.codplanillaUSU) + "',A11EST='D', A11STT='J' WHERE A11NSA= '" + vnroSal.Trim() + "'");
                                try
                                {
                                    //envioCorreo(Program.correo, Program.correo2, "Aprobación de Requerimiento", "Tiene Requerimiento de repuestos pendientes por aprobar -->" + vnroSal.Trim());
                                }
                                catch { }
                                MessageBox.Show("Puede indicar que generen el VALE respectivo", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            else
                            {
                                obTran = new BTransaccion();
                                ide = obTran.BUpdateSQL("UPDATE " + Program.LibreLALMINGB + ".ALI011UTIL SET A11CA1 = '" + Convert.ToDecimal(Program.codplanillaUSU) + "', A11UA1 = '" + Program.Usuario + "',A11FA1 = '" + fecha + "',A11UH1=" + Convert.ToDecimal(Hora) + ",A11AUT = '" + Convert.ToDecimal(Program.codplanillaUSU) + "',A11EST='D' WHERE A11NSA= '" + vnroSal.Trim() + "'");
                            }
                        }
                        /*MENSAJE DE OKA*/                        
                        if (ide == 1)
                        {                            
                            MessageBox.Show("Req.Aprobado Correctamente", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        } 
                        break;

                    case "2":
                        if (vSTATUS == "S")
                        {
                            if (Convert.ToDecimal(txtImpAprob.Text) >= Program.LimJefe)
                            {
                                MessageBox.Show("El Req. excede el minimo importe en dolares que ud. puede aprobar, debe esperar a que el jefe encargado apruebe dicho Req. para que se puede generar el VALE de salida Respectivo ", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                obTran = new BTransaccion();
                                ide = obTran.BUpdateSQL("UPDATE " + Program.LibreLALMINGB + ".ALI011UTIL SET A11CA2 = '" + Convert.ToDecimal(Program.codplanillaUSU) + "', A11UA2 = '" + Program.Usuario + "',A11FA2 = '" + fecha + "',A11UH2=" + Convert.ToDecimal(Hora) + ",A11AUT = '" + Convert.ToDecimal(Program.codplanillaUSU) + "',A11EST='3' WHERE A11NSA= '" + vnroSal.Trim() + "'");
                                try
                                {
                                    envioCorreo(Program.correo, Program.correo2, "Aprobación de Requerimiento", "Tiene Requerimiento de repuestos pendientes por aprobar -->" + vnroSal.Trim());
                                }catch { }

                            }
                            else
                            {
                                obTran = new BTransaccion();
                                ide = obTran.BUpdateSQL("UPDATE " + Program.LibreLALMINGB + ".ALI011UTIL SET A11CA2 = '" + Convert.ToDecimal(Program.codplanillaUSU) + "', A11UA2 = '" + Program.Usuario + "',A11FA2 = '" + fecha + "',A11UH2=" + Convert.ToDecimal(Hora) + ",A11AUT = '" + Convert.ToDecimal(Program.codplanillaUSU) + "',A11EST='D' WHERE A11NSA= '" + vnroSal.Trim() + "'");
                            }
                        }
                        else
                        {
                            if (Convert.ToDecimal(txtImpAprob.Text) >= Program.LimJefe)
                            {
                                MessageBox.Show("El Req. excede el minimo importe en dolares que ud. puede aprobar, debe esperar a que el jefe encargado apruebe dicho Req. para que se pueda regularizar el VALE de salida Respectivo ", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                obTran = new BTransaccion();
                                ide = obTran.BUpdateSQL("UPDATE " + Program.LibreLALMINGB + ".ALI011UTIL SET A11CA2 = '" + Convert.ToDecimal(Program.codplanillaUSU) + "', A11UA2 = '" + Program.Usuario + "',A11FA2 = '" + fecha + "',A11UH2=" + Convert.ToDecimal(Hora) + ",A11AUT = '" + Convert.ToDecimal(Program.codplanillaUSU) + "', A11STT='G' WHERE A11NSA= '" + vnroSal.Trim() + "'");
                                try
                                {
                                    envioCorreo(Program.correo, Program.correo2, "Aprobación de Requerimiento", "Tiene Requerimiento de repuestos pendientes por aprobar -->" + vnroSal.Trim());
                                }
                                catch { }
                            }
                            else
                            {
                                obTran = new BTransaccion();
                                ide = obTran.BUpdateSQL("UPDATE " + Program.LibreLALMINGB + ".ALI011UTIL SET A11CA2 = '" + Convert.ToDecimal(Program.codplanillaUSU) + "', A11UA2 = '" + Program.Usuario + "',A11FA2 = '" + fecha + "',A11UH2=" + Convert.ToDecimal(Hora) + ",A11AUT = '" + Convert.ToDecimal(Program.codplanillaUSU) + "', A11STT='S' WHERE A11NSA= '" + vnroSal.Trim() + "'");
                            }
                        }

                        if (ide == 1)
                        {
                            MessageBox.Show("Req.Aprobado Correctamente", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;



                    case "1":

                        if (vSTATUS == "S")
                        {
                            obTran = new BTransaccion();
                            ide = obTran.BUpdateSQL("UPDATE " + Program.LibreLALMINGB + ".ALI011UTIL SET A11CA3 = '" + Convert.ToDecimal(Program.codplanillaUSU) + "', A11UA3 = '" + Program.Usuario + "',A11FA3 = '" + fecha + "',A11UH3=" + Convert.ToDecimal(Hora) + ",A11AUT = '" + Convert.ToDecimal(Program.codplanillaUSU) + "',A11EST='D' WHERE A11NSA= '" + vnroSal.Trim() + "'");
                        }
                        else
                        {
                            obTran = new BTransaccion();
                            ide = obTran.BUpdateSQL("UPDATE " + Program.LibreLALMINGB + ".ALI011UTIL SET A11CA3 = '" + Convert.ToDecimal(Program.codplanillaUSU) + "', A11UA3 = '" + Program.Usuario + "',A11FA3 = '" + fecha + "',A11UH3=" + Convert.ToDecimal(Hora) + ",A11AUT = '" + Convert.ToDecimal(Program.codplanillaUSU) + "', A11STT='S' WHERE A11NSA= '" + vnroSal.Trim() + "'");
                        }

                        if (ide == 1)
                        {
                            MessageBox.Show("Req.Aprobado Correctamente", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        break;
                }
            }
            Transaccion.Frm_Aprobacion.Actualiza = true;
            this.Close();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            FechaSis = DateTime.Now; 
            fecha = FechaSis.ToShortDateString().Substring(6, 4) + FechaSis.ToShortDateString().Substring(3, 2) + FechaSis.ToShortDateString().Substring(0, 2);
            Hora = FechaSis.Hour.ToString() + FechaSis.Minute.ToString(); 
            int ide = 0;
            string SQL = "";
            if (MessageBox.Show("Desea Rechazar Req.", "Alm.Ing", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                obTran = new BTransaccion();
                SQL = "UPDATE " + Program.LibreLALMINGB + ".ALI011UTIL SET A11UA1 = '" + Program.Usuario + "',A11UH1=" + Convert.ToDecimal(Hora) + ",A11FA1 = '" + fecha + "',A11AUT = '" + Convert.ToDecimal(Program.codplanillaUSU) + "', A11STT='E' WHERE A11NSA= '" + vnroSal.Trim() + "'";
                ide = obTran.BUpdateSQL(SQL);
            }
            if (ide == 1)
            {
                MessageBox.Show("Req. Rechazado Correctamente", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Transaccion.Frm_Aprobacion.Actualiza = true;
            this.Close();
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

        private void Frm_Aprobacion_Detalle_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void tbsModificar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Frm_Modificacion_Req frm = new Frm_Modificacion_Req();
            frm.vnroSal = vnroSal;
            frm.vOrdeTrab = vNroOrdeTrab;
            frm.dtRequerimientoDetalle = dtREQUERIMIENTOSDETALLES;
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void Frm_Aprobacion_Detalle_Activated(object sender, EventArgs e)
        {
            if (Actualiza == true)
            {
                this.Cursor = Cursors.WaitCursor;


                txtDescripcionDPTO.Text = vOrdeTrab;
                txtDpto.Text = vArea;
                txtSolicitante.Text = vSolic;
                dtREQUERIMIENTOSDETALLES = obTran.getConDetalleRequeXCodigo(vnroSal.Trim());
                dgvDetReq.DataSource = dtREQUERIMIENTOSDETALLES;
                dgvDetReq.GridColor = Color.Red;
                Grilla();
                Totales();

                if (Program.nivUsu == "5")
                {
                    toolStrip2.Visible = false;
                    label18.Visible = false;
                }

                if (Program.nivUsu == "1")
                {
                    grpMonto.Visible = true;
                }
                else
                {
                    grpAprobacion.Location = new Point(457, 388);
                    lblAprobacion.Text = "Supervisor";
                    if (Convert.ToDecimal(txtImpAprob.Text) >= Program.LimSuperv)
                    {
                        lblAprobacion.Text = "Supervisor-Jefatura";
                    }
                    if (Convert.ToDecimal(txtImpAprob.Text) >= Program.LimJefe)
                    {
                        lblAprobacion.Text = "Supervisor-Jefatura-Gerencia";
                    }


                    grpAprobacion.Visible = true;
                }

                /*Ingresado para la modificacion de REQUERIMIENTO*/
                if (Program.nivUsu == "3")
                {
                    tbsModificar.Enabled = true;
                }

                Actualiza = false;
                this.Cursor = Cursors.Default;
            }
        }


    }
}
