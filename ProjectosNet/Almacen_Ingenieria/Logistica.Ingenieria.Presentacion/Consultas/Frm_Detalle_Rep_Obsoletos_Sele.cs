using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;

using Logistica.Ingenieria.Bussiness;
using System.Net.Mail;
using System.Net;

namespace Logistica.Ingenieria.Presentacion.Consultas
{
    public partial class Frm_Detalle_Rep_Obsoletos_Sele : Form
    {
        public Frm_Detalle_Rep_Obsoletos_Sele()
        {
            InitializeComponent();
        }

        public List<String> objLISTDet = new List<string>();
        public DataTable dtRepDetalle = new DataTable();

        DataView dv = new DataView();

        BTablas objTablas = new BTablas();
        private void Frm_Detalle_Rep_Obsoletos_Sele_Load(object sender, EventArgs e)
        {
            Grilla();
        }

        void Grilla()
        {
            string whereIN = "''";
            if (objLISTDet.Count > 0)
            {
                whereIN = "";
                for (int i = 0; i <= objLISTDet.Count - 1; i++)
                {
                    if (i == 0) { whereIN = "'" + objLISTDet[i].ToString().Trim() + "'"; }
                    else { whereIN = whereIN + ",'" + objLISTDet[i].ToString().Trim() + "'"; }
                }
            }
            dv = new DataView(dtRepDetalle);
            dv.RowFilter = "Codigo in (" + whereIN + ")";
            dv.Sort = "codigo asc";
            dgvDetalleRep.DataSource = dv;
            dgvDetalleRep.GridColor = Color.Red;


            dgvDetalleRep.Columns["Codigo"].ReadOnly = true;
            dgvDetalleRep.Columns["Descripcion"].ReadOnly = true;
            dgvDetalleRep.Columns["Unid_Med"].ReadOnly = true;
            dgvDetalleRep.Columns["Precio"].ReadOnly = true;


            dgvDetalleRep.Columns["Codigo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalleRep.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalleRep.Columns["Unid_Med"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDetalleRep.Columns["Precio"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void dgvDetalleRep_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
                return;


            if (e.ColumnIndex == 0)
            {
                int p = dgvDetalleRep.CurrentRow.Index;
                string cod = dgvDetalleRep.Rows[p].Cells["Codigo"].Value.ToString();
                string nom = dgvDetalleRep.Rows[p].Cells["Descripcion"].Value.ToString();
                Transaccion.Frm_FotoArt frm = new Logistica.Ingenieria.Presentacion.Transaccion.Frm_FotoArt();
                frm.codProd = cod;
                frm.nomprod = nom;
                frm.ShowDialog();
            }
        }


        void CargarEXCEL()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                ArrayList titulos = new ArrayList();
                DataTable datosTabla = new DataTable();
                //Especificar rutal del archivo con extencion de excel.
                OtrosFormatos OF = new OtrosFormatos(Application.StartupPath + @"\\test.xls");

                //obtenemos los titulos del grid y creamos las columnas de la tabla
                foreach (DataGridViewColumn item in dgvDetalleRep.Columns)
                {
                    titulos.Add(item.HeaderText);
                    datosTabla.Columns.Add();
                }
                //se crean los renglones de la tabla
                foreach (DataGridViewRow item in dgvDetalleRep.Rows)
                {
                    DataRow rowx = datosTabla.NewRow();
                    datosTabla.Rows.Add(rowx);
                }
                //se pasan los datos del dataGridView a la tabla
                foreach (DataGridViewColumn item in dgvDetalleRep.Columns)
                {
                    foreach (DataGridViewRow itemx in dgvDetalleRep.Rows)
                    {
                        datosTabla.Rows[itemx.Index][item.Index] = dgvDetalleRep[item.Index, itemx.Index].Value;
                    }
                }
                OF.Export(titulos, datosTabla);
                Process.Start(OF.xpath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Cursor = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            CargarEXCEL();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDetalleRep.Rows.Count >= 1)
                {
                    if (MessageBox.Show("Desea Eliminar Repuesto", "Eliminar", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        string naza = dgvDetalleRep[1, dgvDetalleRep.CurrentCell.RowIndex].Value.ToString();
                        objLISTDet.Remove(naza);
                        Grilla();
                    }
                }
            }
            catch { }
        }

        string fecha = "";
        DateTime FechaSis = DateTime.Now;
        int Val = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            fecha = FechaSis.ToShortDateString().Substring(6, 4) + FechaSis.ToShortDateString().Substring(3, 2) + FechaSis.ToShortDateString().Substring(0, 2);


            string mensaje = "Modulo de Ingenieria " + "\n\n" + " - Poner obsoletos los siguientes ITEMS ---> \n\n";
            string descri = "";
            for (int i = 0; i <= dgvDetalleRep.Rows.Count - 1; i++)
            {
                string codRep = dgvDetalleRep["Codigo", i].Value.ToString();
                objTablas = new BTablas();
                Val = objTablas.BUpdateLIBRE("INSERT INTO " + Program.LibreLALMINGB + ".TABLA_OBS (FE_FECHA, NO_USUARIO, CO_REPUESTO) VALUES ('" + fecha + "', '" + Program.Usuario + "', '" + codRep + "')");
                descri = dgvDetalleRep["Codigo", i].Value.ToString() + "     " + dgvDetalleRep["Descripcion", i].Value.ToString();
                mensaje = mensaje + "   " +  descri + "\n";
            }

            mensaje = mensaje + "\n" + Program.NomCorreo;
            if (Val == 1)
            {
                envioCorreo(Program.correo, "fcorrales@limacaucho.com.pe", "Modulo Ing. --> Productos Obsoletos", mensaje);
                envioCorreo(Program.correo, "razabache@limacaucho.com.pe", "Modulo Ing. --> Productos Obsoletos", mensaje);
                MessageBox.Show("Se Ingreso Correctamente", "Alm.Ing", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
            Consultas.Frm_RepuestoXMaquina.Actualiza = true;
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
    }
}
