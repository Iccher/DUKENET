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

using Logistica.Ingenieria.Bussiness;
using Logistica.Ingenieria.Utils;
namespace Logistica.Ingenieria.Presentacion.Otros
{
    public partial class Frm_Req_Ingenieria : Form
    {
        public Frm_Req_Ingenieria()
        {
            InitializeComponent();
        }

        BTablas oBuss = new BTablas();
        DataTable dtPeriodo = new DataTable();
        TControlVB oControl = new TControlVB();

        public string NroReq = "";
        public string CodProd = "";
        public string DesProd = "";
        public decimal CanPed = 0;
        public string Fecha = "";
        public decimal Stock = 0;
        public decimal StockMAX = 0;
        public decimal StockMIN = 0;
        public decimal StockEME = 0;

        decimal StockMAXA = 0;
        decimal StockMINA = 0;
        decimal StockEMEA = 0;  

        public string Situ = "";
        public string Rot = "";

        public string Estado = "";

        DateTime FechaSis = DateTime.Now;
        DataTable dtComent = new DataTable();

        private void Frm_Req_Ingenieria_Load(object sender, EventArgs e)
        {
            lblRemitente.Text = Program.correo.ToString().Trim();
            txtremitente.Text = Program.NomCorreo.ToString().Trim();

            if (Estado == "X Trabajar")
            {
                Text = "Historial de Ing / Egr  -  " + Estado;
                txtEntrega.CharacterCasing = CharacterCasing.Upper;
                txtPedMin.Focus();
                lblCantUNIT.Text = "";
                lblPU.Text = "";
                lblTotal.Text = "";
            }

            if (Program.nivUsu == "5")
            {
                if (Estado == "X Aprobar")
                {
                    oBuss = new BTablas();
                    dtComent = oBuss.getBuscaComent(CodProd, NroReq);
                    if (dtComent.Rows.Count > 0)
                    {
                        txtPedMin.Text = dtComent.Rows[0]["MPDPMI"].ToString();
                        txtCoti.Text = dtComent.Rows[0]["MPDPUN"].ToString();
                        txtEntrega.Text = dtComent.Rows[0]["MPDENT"].ToString();
                        txtPedMin.Enabled = false;
                        txtCoti.Enabled = false;
                        txtEntrega.Enabled = false;
                        button2.Enabled = true;
                    }
                    button2.Enabled = false;
                    button1.Enabled = false;
                }
            }
            else
            {
                if (Estado == "X Aprobar")
                {
                    oBuss = new BTablas();
                    dtComent = oBuss.getBuscaComent(CodProd, NroReq);
                    if (dtComent.Rows.Count > 0)
                    {
                        txtPedMin.Text = dtComent.Rows[0]["MPDPMI"].ToString();
                        txtCoti.Text = dtComent.Rows[0]["MPDPUN"].ToString();
                        txtEntrega.Text = dtComent.Rows[0]["MPDENT"].ToString();
                        txtPedMin.Enabled = false;
                        txtCoti.Enabled = false;
                        txtEntrega.Enabled = false;
                        button2.Enabled = true;
                    }
                }
            }



            if (Estado == "Aprobado" || Estado == "Rechazado")
            {
                oBuss = new BTablas();
                dtComent = oBuss.getBuscaComent(CodProd, NroReq);
                if (dtComent.Rows.Count > 0)
                {
                    txtPedMin.Text = dtComent.Rows[0]["MPDPMI"].ToString();
                    txtCoti.Text = dtComent.Rows[0]["MPDPUN"].ToString();
                    txtEntrega.Text = dtComent.Rows[0]["MPDENT"].ToString();
                    txtPedMin.Enabled = false;
                    txtCoti.Enabled = false;
                    txtEntrega.Enabled = false;
                    button1.Enabled = false;
                }
            }

            


            lblCodProd.Text = CodProd;
            lblDesProd.Text = DesProd;
            lblNroReq.Text = NroReq;
            lblCanPed.Text = Convert.ToString(CanPed);
            lblFecha.Text = Fecha.Substring(6, 2) + "/" + Fecha.Substring(4, 2) + "/" + Fecha.Substring(0, 4);
            lblStckACT.Text = Convert.ToString(Stock);
            lblSitu.Text = Situ;
            if (Convert.ToDecimal(Rot) > 0)
            {
                if (Convert.ToDecimal(Rot) == 1) { lblRota.Text = String.Format("{0:0}", Convert.ToDouble(Rot)) + " Mes"; }
                else { lblRota.Text = String.Format("{0:0}", Convert.ToDouble(Rot)) + " Meses"; }
            }
            else
            {
                lblRota.Text = "";
            }
            //lblSMax.Text =  String.Format("{0:0}", Convert.ToDouble(StockMAX));
            //lblSMin.Text =  String.Format("{0:0}", Convert.ToDouble(StockMIN));

            txtSMax.Text = String.Format("{0:0.00}", Convert.ToDouble(StockMAX));
            txtSMin.Text = String.Format("{0:0.00}", Convert.ToDouble(StockMIN));
            txtSEme.Text = String.Format("{0:0.00}", Convert.ToDouble(StockEME));

            StockMAXA = StockMAX;
            StockMINA = StockMIN;
            StockEMEA = StockEME;

            try
            {
                oBuss = new BTablas();
                lblMaquina.Text = oBuss.getTablaGruSubGru(CodProd.Substring(0, 4)).Rows[0]["AISDES"].ToString();
            }
            catch { }

            oBuss = new BTablas();
            dataGridView1.DataSource = oBuss.getConsumosIngresos(CodProd);
            oBuss = new BTablas();
            dtPeriodo = oBuss.getTablaAnos(CodProd);
            dgvOrdenes.DataSource = oBuss.getTablaOrdenesCompra(CodProd);
            dataGridView1.GridColor = Color.Red;
            dgvOrdenes.GridColor = Color.Red;

            for (int i = 0; i <= dtPeriodo.Rows.Count - 1; i++)
            {
                switch (i)
                {
                    case 0:
                        lblanio1.Text = "Año " + dtPeriodo.Rows[i][0].ToString();
                        break;
                    case 1:
                        lblanio2.Text = "Año " + dtPeriodo.Rows[i][0].ToString();
                        break;
                    case 2:
                        lblanio3.Text = "Año " + dtPeriodo.Rows[i][0].ToString();
                        break;
                    case 3:
                        lblanio4.Text = "Año " + dtPeriodo.Rows[i][0].ToString();
                        break;
                    case 4:
                        lblanio5.Text = "Año " + dtPeriodo.Rows[i][0].ToString();
                        break;
                }
            }


            dgvOrdenes.Columns["OC"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdenes.Columns["FECORD"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdenes.Columns["CANTIDAD"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvOrdenes.Columns["PU"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns["ingreso1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["ingreso2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["ingreso3"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["ingreso4"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["ingreso5"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridView1.Columns["egreso1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["egreso2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["egreso3"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["egreso4"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["egreso5"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                if (Convert.ToDecimal(dataGridView1["ingreso1", i].Value.ToString()) == 0) { dataGridView1.Rows[i].Cells["ingreso1"].Style.Format = "#,###.##"; }//dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Navy; }
                if (Convert.ToDecimal(dataGridView1["ingreso2", i].Value.ToString()) == 0) { dataGridView1.Rows[i].Cells["ingreso2"].Style.Format = "#,###.##"; }
                if (Convert.ToDecimal(dataGridView1["ingreso3", i].Value.ToString()) == 0) { dataGridView1.Rows[i].Cells["ingreso3"].Style.Format = "#,###.##"; }
                if (Convert.ToDecimal(dataGridView1["ingreso4", i].Value.ToString()) == 0) { dataGridView1.Rows[i].Cells["ingreso4"].Style.Format = "#,###.##"; }
                if (Convert.ToDecimal(dataGridView1["ingreso5", i].Value.ToString()) == 0) { dataGridView1.Rows[i].Cells["ingreso5"].Style.Format = "#,###.##"; }

                if (Convert.ToDecimal(dataGridView1["egreso1", i].Value.ToString()) == 0) { dataGridView1.Rows[i].Cells["egreso1"].Style.Format = "#,###.##"; }
                if (Convert.ToDecimal(dataGridView1["egreso2", i].Value.ToString()) == 0) { dataGridView1.Rows[i].Cells["egreso2"].Style.Format = "#,###.##"; }
                if (Convert.ToDecimal(dataGridView1["egreso3", i].Value.ToString()) == 0) { dataGridView1.Rows[i].Cells["egreso3"].Style.Format = "#,###.##"; }
                if (Convert.ToDecimal(dataGridView1["egreso4", i].Value.ToString()) == 0) { dataGridView1.Rows[i].Cells["egreso4"].Style.Format = "#,###.##"; }
                if (Convert.ToDecimal(dataGridView1["egreso5", i].Value.ToString()) == 0) { dataGridView1.Rows[i].Cells["egreso5"].Style.Format = "#,###.##"; }

                if (Convert.ToDecimal(dataGridView1["ingreso1", i].Value.ToString()) != 0) { dataGridView1.Rows[i].Cells["ingreso1"].Style.ForeColor = Color.Navy; }
                if (Convert.ToDecimal(dataGridView1["ingreso2", i].Value.ToString()) != 0) { dataGridView1.Rows[i].Cells["ingreso2"].Style.ForeColor = Color.Navy; }
                if (Convert.ToDecimal(dataGridView1["ingreso3", i].Value.ToString()) != 0) { dataGridView1.Rows[i].Cells["ingreso3"].Style.ForeColor = Color.Navy; }
                if (Convert.ToDecimal(dataGridView1["ingreso4", i].Value.ToString()) != 0) { dataGridView1.Rows[i].Cells["ingreso4"].Style.ForeColor = Color.Navy; }
                if (Convert.ToDecimal(dataGridView1["ingreso5", i].Value.ToString()) != 0) { dataGridView1.Rows[i].Cells["ingreso5"].Style.ForeColor = Color.Navy; }

                if (Convert.ToDecimal(dataGridView1["egreso1", i].Value.ToString()) != 0) { dataGridView1.Rows[i].Cells["egreso1"].Style.ForeColor = Color.Maroon; }
                if (Convert.ToDecimal(dataGridView1["egreso2", i].Value.ToString()) != 0) { dataGridView1.Rows[i].Cells["egreso2"].Style.ForeColor = Color.Maroon; }
                if (Convert.ToDecimal(dataGridView1["egreso3", i].Value.ToString()) != 0) { dataGridView1.Rows[i].Cells["egreso3"].Style.ForeColor = Color.Maroon; }
                if (Convert.ToDecimal(dataGridView1["egreso4", i].Value.ToString()) != 0) { dataGridView1.Rows[i].Cells["egreso4"].Style.ForeColor = Color.Maroon; }
                if (Convert.ToDecimal(dataGridView1["egreso5", i].Value.ToString()) != 0) { dataGridView1.Rows[i].Cells["egreso5"].Style.ForeColor = Color.Maroon; }

                if (dataGridView1["meses", i].Value.ToString() == "T.por Año") 
                { 
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;
                    dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Navy;
                }//dataGridView1.Rows[i].Cells["meses"].Style.BackColor = Color.Navy; }
            }
            Calculo();
        }

        decimal cantMin = 0;
        decimal cant = 0;
        decimal PU1 = 0;

        void Calculo()
        {
            cantMin = 0;
            cant = 0;
            PU1 = 0;

            if (txtPedMin.Text == "") { cantMin = 0; }
            else { cantMin = Convert.ToDecimal(txtPedMin.Text); }
            if (lblCanPed.Text == "") { cant = 0; }
            else { cant = Convert.ToDecimal(lblCanPed.Text); }
            if (txtCoti.Text == "") { PU1 = 0; }
            else { PU1 = Convert.ToDecimal(txtCoti.Text); }

            if ((cantMin < cant) || (cantMin == 0)) { lblCantUNIT.Text = String.Format("{0:0.00}", Convert.ToDouble(cant)); }
            else { lblCantUNIT.Text = String.Format("{0:0.00}", Convert.ToDouble(cantMin)); }

            lblPU.Text = String.Format("{0:0.00}", Convert.ToDouble(PU1));

            lblTotal.Text = String.Format("{0:0.00}", (PU1 * Convert.ToDecimal(lblCantUNIT.Text)));


            
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Calculo();
        }

        private void txtPedMin_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    txtCoti.Focus();
                }
            }
            catch { }
            /****Validar para ingresar decimales o no segun el tipo de Unidad Medida*/
            oControl.NumeroDec(e, txtPedMin);
        }

        private void txtCoti_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 13)
                {
                    Calculo();
                }
            }
            catch { }
            /****Validar para ingresar decimales o no segun el tipo de Unidad Medida*/
            oControl.NumeroDec(e, txtCoti);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal fecha = Convert.ToDecimal(FechaSis.ToShortDateString().Substring(6, 4) + FechaSis.ToShortDateString().Substring(3, 2) + FechaSis.ToShortDateString().Substring(0, 2));
            decimal Hora = Convert.ToDecimal(FechaSis.Hour.ToString() + FechaSis.Minute.ToString());
            if (Estado == "X Trabajar")
            {
                if ((txtPedMin.Text != "") && (txtPedMin.Text != "0"))
                {
                    if (Convert.ToDecimal(lblCantUNIT.Text) > Convert.ToDecimal(txtPedMin.Text))
                    {
                        MessageBox.Show("Porfavor Verifique Cantidad MINIMA", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtPedMin.Focus();
                        return;
                    }
                }
                if (Convert.ToDecimal(lblPU.Text) == 0)
                {
                    MessageBox.Show("Porfavor Ingrese Cotizacion", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtCoti.Focus();
                    return;
                }
                if (txtEntrega.Text == "")
                {
                    MessageBox.Show("Ingrese dias Entrega", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtEntrega.Focus();
                    return;
                }

                if (MessageBox.Show("Desea Trabajar la Requisicion", "Alm.Ing", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    oBuss = new BTablas();
                    int i = oBuss.BInsertDescripcion("T", Program.Usuario, fecha, Hora, lblCodProd.Text.Trim(), lblNroReq.Text.Trim(), txtEntrega.Text.Trim(), "", cantMin, Convert.ToDecimal(lblPU.Text), cant, Convert.ToDecimal(lblTotal.Text));
                    MessageBox.Show("Se trabajo con exito", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (MessageBox.Show("Desea Enviar Correo Electronico", "Alm.Ing", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        txtasunto.Text = "Aprobacion de Requisicion " + NroReq;
                        txtmensaje.Text = "Ud tiene una requisicion pendiente " + NroReq;
                        panel1.Visible = true;
                    }
                    else
                    {
                        Otros.Frm_Req_AI_CAB.Actualiza = true;
                        this.Close();
                    }
                }
            }
            else
            {
                if (STT == "C")
                {
                    if (MessageBox.Show("Desea Aprobar la Requisicion y a la vez Actualizar los STOCK's", "Alm.Ing", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        oBuss = new BTablas();
                        int i = oBuss.BUpdateDescripcion("A", Program.Usuario, fecha, Hora, lblCodProd.Text.Trim(), lblNroReq.Text.Trim());
                        oBuss = new BTablas();
                        string SQL = "UPDATE " + Program.LibreLALMINGB + ".ALMWDES SET MPDEST='C',MPDSMX=" + Convert.ToDecimal(txtSMax.Text.Trim()) + ",MPDSXA=" + StockMAXA + ",MPDSMN=" + Convert.ToDecimal(txtSMin.Text.Trim()) + ",MPDSMA=" + StockMINA + ",MPDSEM=" + Convert.ToDecimal(txtSEme.Text.Trim()) + ",MPDSEA=" + StockEMEA + " WHERE MPDCOD = '" + lblCodProd.Text.Trim() + "' AND MPDRQC = '" + lblNroReq.Text.Trim() + "'";
                        int j = oBuss.BUpdateLIBRE(SQL);
                        oBuss = new BTablas();
                        string SQL1 = "UPDATE " + Program.LibreLALMINGB + ".ALMMMAP SET  MPMSMX =" + Convert.ToDecimal(txtSMax.Text.Trim()) + ",MPMSMN = " + Convert.ToDecimal(txtSMin.Text.Trim()) + "	,MPMSEM = " + Convert.ToDecimal(txtSEme.Text.Trim()) + " WHERE MPMCOD = '" + lblCodProd.Text.Trim() + "'";
                        int k = oBuss.BUpdateLIBRE(SQL1);
                        MessageBox.Show("Se trabajo con exito", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                        Otros.Frm_Req_AI_CAB.Actualiza = true;
                        this.Close();
                    }
                }
                else
                {
                    if (MessageBox.Show("Desea Aprobar la Requisicion", "Alm.Ing", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        oBuss = new BTablas();
                        int i = oBuss.BUpdateDescripcion("A", Program.Usuario, fecha, Hora, lblCodProd.Text.Trim(), lblNroReq.Text.Trim());
                        MessageBox.Show("Se trabajo con exito", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //if (MessageBox.Show("Desea Enviar Correo Electronico", "Alm.Ing", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        //{
                        //    txtasunto.Text = "Aprobacion de Requisicion " + NroReq;
                        //    txtmensaje.Text = "La requisicion " + NroReq + " ha sido aprobada";
                        //    panel1.Visible = true;
                        //}
                        //else
                        //{
                        Otros.Frm_Req_AI_CAB.Actualiza = true;
                        this.Close();
                        //}
                    }
                }
            }
            
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea Borrar", "Alm.Ing", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                txtPedMin.Text = "";
                txtCoti.Text = "";
                Calculo();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            decimal fecha = Convert.ToDecimal(FechaSis.ToShortDateString().Substring(6, 4) + FechaSis.ToShortDateString().Substring(3, 2) + FechaSis.ToShortDateString().Substring(0, 2));
            decimal Hora = Convert.ToDecimal(FechaSis.Hour.ToString() + FechaSis.Minute.ToString());
            if (Estado == "X Aprobar")
            {
                if (MessageBox.Show("Desea Rechazar la Requisicion", "Alm.Ing", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    oBuss = new BTablas();
                    int i = oBuss.BUpdateDescripcion("R", Program.Usuario, fecha, Hora, lblCodProd.Text.Trim(), lblNroReq.Text.Trim());
                    MessageBox.Show("La requisición ha sido Rechazada", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (MessageBox.Show("Desea Enviar Correo Electronico", "Alm.Ing", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        //txtasunto.Text = "Rechazo de la Requisicion ---> " + NroReq;
                        //txtmensaje.Text = "La requisicion " + NroReq + " ha sido rechazada";
                        //panel1.Visible = true;

                        txtasunto.Text = "Rechazo de la Requisicion ---> " + NroReq;
                        txtmensaje.Text = "La requisicion " + NroReq + " ha sido rechazada";
                        Otros.CorreoForm frm = new CorreoForm();
                        frm.Asunto = "Rechazo de la Requisicion ---> " + NroReq;
                        frm.Mensaje = "La requisicion " + NroReq + " ha sido rechazada";
                        frm.ShowDialog();
                        this.Close();
                        


                    }
                    else
                    {
                        Otros.Frm_Req_AI_CAB.Actualiza = true;
                        this.Close();
                    }                    
                }
            }
        }

        void envioCorreo(string emisor,string receptor,string asunto,string mensaje1)
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

        //private void button3_Click(object sender, EventArgs e)
        //{
        //    envioCorreo();
        //}

        private void button5_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("No Desea Enviar Correo", "Alm.Ing", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Otros.Frm_Req_AI_CAB.Actualiza = true;
                this.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtremitente.Text == "")
            {
                MessageBox.Show("Ingrese Remitente", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtremitente.Focus();
                return;
            }
            if (txtdestinatario.Text == "")
            {
                MessageBox.Show("Ingrese Destinatario", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtdestinatario.Focus();
                return;
            }
            if (txtasunto.Text == "")
            {
                MessageBox.Show("Ingrese Asunto", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtasunto.Focus();
                return;
            }
            if (txtmensaje.Text == "")
            {
                MessageBox.Show("Ingrese Mensaje", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtmensaje.Focus();
                return;
            }
            if (MessageBox.Show("Desea Enviar Correo", "Alm.Ing", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                envioCorreo(lblRemitente.Text, lblDestinatario.Text, txtasunto.Text, txtmensaje.Text);
                MessageBox.Show("Se envio Correo", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Otros.Frm_Req_AI_CAB.Actualiza = true;
                this.Close();
            }
        }

        private void btnOrden_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Frm_Busqueda frm = new Frm_Busqueda();
            //OT = Orden de Trabajo
            frm.Busqueda = "COR";
            frm.ShowDialog();
            lblDestinatario.Text = frm.vCodEmpleado;
            txtdestinatario.Text = frm.vEmpleado;
            txtasunto.Focus();
            this.Cursor = Cursors.Default; 
        }

        string STT = "";
        private void chk1_CheckedChanged(object sender, EventArgs e)
        {
            if (chk1.Checked == true)
            {
                STT = "C";
                txtSEme.Enabled = true;
                txtSMin.Enabled = true;
                txtSMax.Enabled = true;
            }
            else
            {
                STT = "";
                txtSEme.Enabled = false;
                txtSMin.Enabled = false;
                txtSMax.Enabled = false;
            }
        }

        private void Frm_Req_Ingenieria_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtasunto.Text = "Rechazo de la Requisicion ---> " + NroReq;
            txtmensaje.Text = "La requisicion " + NroReq + " ha sido rechazada";
            Otros.CorreoForm frm = new CorreoForm();
            frm.Asunto = "Rechazo de la Requisicion ---> " + NroReq;
            frm.Mensaje = "La requisicion " + NroReq + " ha sido rechazada";
            frm.ShowDialog();   
        }


    }
}
