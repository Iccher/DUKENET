using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;

namespace Logistica.Ingenieria.Presentacion.Otros
{
    public partial class CorreoForm : Form
    {
        public CorreoForm()
        {
            InitializeComponent();
        }

        public string Asunto = "";
        public string Mensaje = "";
        private void CorreoForm_Load(object sender, EventArgs e)
        {
            lblRemitente.Text = Program.correo.ToString().Trim();
            txtremitente.Text = Program.NomCorreo.ToString().Trim();
            txtasunto.Text = Asunto;
            txtmensaje.Text = Mensaje;
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
                for (int i = 0; i <= arregloCorreo.Count - 1; i++)
                {
                    envioCorreo(lblRemitente.Text, arregloCorreo[i].ToString(), txtasunto.Text, txtmensaje.Text);
                }
                //envioCorreo(lblRemitente.Text, lblDestinatario.Text, txtasunto.Text, txtmensaje.Text);
                MessageBox.Show("Se envio Correo", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Otros.Frm_Req_AI_CAB.Actualiza = true;
                this.Close();
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

        List<string> arregloCorreo = new List<string>();
        List<string> arregloCorreo2 = new List<string>();
        private void btnOrden_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Frm_Busqueda frm = new Frm_Busqueda();
            //OT = Orden de Trabajo
            frm.Busqueda = "COR";
            frm.ShowDialog();            
            arregloCorreo.Add(frm.vCodEmpleado);
            arregloCorreo2.Add(frm.vEmpleado);
            txtdestinatario.Text = "";
            for (int i = 0; i <= arregloCorreo2.Count - 1; i++)
            {
                if (i == 0)
                {
                    txtdestinatario.Text = "<" + arregloCorreo2[i].ToString().Trim() +">";
                }
                else
                {
                    txtdestinatario.Text = txtdestinatario.Text.Trim() + "  ;  " + "<" + arregloCorreo2[i].ToString().Trim() + ">";
                }
                
            }
            txtasunto.Focus();
            this.Cursor = Cursors.Default; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtdestinatario.Text = "";
            lblDestinatario.Text = "";
            arregloCorreo = new List<string>();
            arregloCorreo2 = new List<string>();
        }
    }
}
