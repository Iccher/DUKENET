using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Logistica.Ingenieria.Bussiness;


using System.Net;
using System.Net.Mail;
using Logistica.Ingenieria.Presentacion.Sistema;
using System.Messaging;
using System.Messaging;




namespace Logistica.Ingenieria.Presentacion
{
    public partial class Frm_Menu : Form
    {
        public Frm_Menu()
        {
            InitializeComponent();
        }

        BTablas oBusTab = new BTablas();
        BConfiguracion oBusConf = new BConfiguracion();

        DataView dvOpcionesxUsuario = new DataView();


        private void Frm_Menu_Load(object sender, EventArgs e)
        {
            Program.TipoCambio = Convert.ToDecimal("2.80");
            Program.LimSuperv = Convert.ToDecimal("20");
            Program.LimJefe = Convert.ToDecimal("80");

            //UsuarioSistema.Text = Program.Usuario;
            //fecha.Text = DateTime.Now.ToShortDateString();
            oBusTab = new BTablas();
            Program.dtCCostos = oBusTab.getCargaCentroCostos();
            oBusTab = new BTablas();
            Program.dtCCostoLaborales = oBusTab.getCargaCentroCostosLABORALES();
            oBusTab = new BTablas();
            Program.dtEmpleados = oBusTab.getCargaEmpleados();
            oBusTab = new BTablas();
            Program.dtTipSolic = oBusTab.getCargaTipoSolicitud();
            oBusConf = new BConfiguracion();
            Program.dtCtaAlm = oBusConf.getCargaCtaAlmacen();
            oBusConf = new BConfiguracion();
            Program.dtUsuariosConec = oBusConf.getCargaUsuarios();
            Program.dvUsuariosConec = new DataView(Program.dtUsuariosConec, "CODUSE = '" + Program.Usuario + "'", "", DataViewRowState.OriginalRows);
            oBusConf = new BConfiguracion();
            Program.dtPermisos = oBusConf.getCargaAutori();
            Program.dvAutorizaciones = new DataView(Program.dtPermisos, "CODUSE = '" + Program.Usuario + "'", "", DataViewRowState.OriginalRows);
            
            if (Program.dvAutorizaciones.Count > 0)
            {
                for (int i = 0; i <= Program.dvAutorizaciones.Count - 1; i++)
                {
                    if (i == 0)
                    {
                        Program.Cuentas = Convert.ToString(Convert.ToDecimal(Program.dvAutorizaciones[i]["CTAALM"].ToString()));                     
                    }
                    else
                    {
                        Program.Cuentas = Program.Cuentas + "," + Convert.ToString(Convert.ToDecimal(Program.dvAutorizaciones[i]["CTAALM"].ToString()));
                    }
                }
                Program.nivUsu = Convert.ToString(Convert.ToDecimal(Program.dvAutorizaciones[0]["NIVUSU"].ToString()));
                //MessageBox.Show(Program.Cuentas + " --> " + Program.nivUsu);
            }           
            

            if (Program.nivUsu == "5")
            {
                RQG02.ToolTipText = "Generacion Vale";
                RQG02.Text = "Generacion Vale";
            }
            //Program.dtProductos = oBusTab.getCargaProductos();
            //Program.dtDesUnidad = oBusTab.getCargaUND();
            oBusTab = new BTablas();
            Program.dtGrupos = oBusTab.getCargaGRUPOS();
            oBusTab = new BTablas();
            Program.dtSubGrupos = oBusTab.getCargaSUBGRUPOS();

            Program.dtArea = oBusTab.getCargaAreas();
            oBusConf = new BConfiguracion();
            Program.dtOcpiones = oBusConf.getCargaOpcionesModulo();
            oBusConf = new BConfiguracion();
            Program.dtOcpionesxUsuario = oBusConf.getCargaOpcionesModuloXUsuario();
            dvOpcionesxUsuario = new DataView(Program.dtOcpionesxUsuario, "IDUSER = '" + Program.Usuario + "'", "", DataViewRowState.OriginalRows);
            CargaAutorizaciones();


            oBusConf = new BConfiguracion();
            Program.dtJEFExSUPERVISOR = oBusConf.getCargaOpcionesJEFExSUPERVISOR();
            Program.dvJefeSupervisor = new DataView(Program.dtJEFExSUPERVISOR, "IDUSER = '" + Program.Usuario + "'", "", DataViewRowState.OriginalRows);

            if (Program.dvJefeSupervisor.Count > 0)
            {
                for (int i = 0; i <= Program.dvJefeSupervisor.Count - 1; i++)
                {
                    if (i == 0)
                    {
                        Program.SUPERVISORES = "'" + Program.dvJefeSupervisor[i]["IDAPLI"].ToString().Trim() + "'";
                    }
                    else
                    {
                        Program.SUPERVISORES = Program.SUPERVISORES + "," + "'" + Program.dvJefeSupervisor[i]["IDAPLI"].ToString().Trim() + "'";
                    }
                }
            }

            if (Program.Usuario == "LAPDCOV1")
            {
                string mensa = RecepcionarMensaje();
                if (mensa != "")
                {
                    MessageBox.Show(mensa, "Implmentacion de Mensajeria", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }


        }

        public static string RecepcionarMensaje()
        {
            string menTotal = "";
            Mens alerta = new Mens();
            string rutaCola = @".\private$\iespinoza";
            if(!MessageQueue.Exists(rutaCola))
                MessageQueue.Create(rutaCola);
            MessageQueue cola = new MessageQueue(rutaCola);
            cola.Formatter = new XmlMessageFormatter(new Type[] { typeof(Mens) });
            Int64 size = Convert.ToInt64(cola.GetAllMessages().Length.ToString());

            for (int i = 0; i <= size - 1; i++)
            {
                System.Messaging.Message mensaje = cola.Receive();
                alerta = (Mens)mensaje.Body;
                menTotal = menTotal + alerta.mesaj.ToString() + "\r";
            }


            return menTotal;
        }

        public class Mens
        {
            public string mesaj {get; set;}
        }



        void CargaAutorizaciones()
        {
            ToolStripMenuItem item=new ToolStripMenuItem();
            ToolStripMenuItem item1 = this.menuStrip1.Items[0] as ToolStripMenuItem;
            ToolStripMenuItem item2 = this.menuStrip1.Items[1] as ToolStripMenuItem;
            ToolStripMenuItem item3 = this.menuStrip1.Items[2] as ToolStripMenuItem;
            if (dvOpcionesxUsuario.Count > 0)
            {
                for (int i = 0; i <= dvOpcionesxUsuario.Count - 1; i++)
                {
                    string opcion = dvOpcionesxUsuario[i]["IDOPCI"].ToString();
                    string opcion1 = dvOpcionesxUsuario[i]["IDOPCI"].ToString() + "S";
                    string opcion2 = dvOpcionesxUsuario[i]["IDOPCI"].ToString() + "T";

                    //if ((opcion!="RQG06") && (opcion!="RQG07"))
                    //{
                    //    toolStrip1.Items[opcion].Enabled = true;
                    //}
                    //try { toolStrip1.Items[opcion].Enabled = true; }
                    //catch { }
                    //try { item1.DropDownItems[opcion1].Enabled = true; }
                    //catch { }
                    //try { item2.DropDownItems[opcion1].Enabled = true; }
                    //catch { }
                    //try { item3.DropDownItems[opcion1].Enabled = true; }
                    //catch { }
                    try { toolStrip1.Items[opcion].Visible = true; }
                    catch { }
                    try { toolStrip1.Items[opcion2].Visible = true; }
                    catch { }
                    try { item1.DropDownItems[opcion1].Visible = true; }
                    catch { }
                    try { item2.DropDownItems[opcion1].Visible = true; }
                    catch { }
                    try { item3.DropDownItems[opcion1].Visible = true; }
                    catch { }
                }
            }
        }




        private void BuscarControl(Control.ControlCollection Controles)
        {
            

            //foreach (ToolStripMenuItem mnuitOpcion in this.menuStrip1.Items)
            //{
            //    // cambiar el tipo de letra
            //    mnuitOpcion.Font = fntTipoLetra;

            //    // si esta opción despliega un submenú
            //    // llamar a un método para hacer cambios
            //    // en las opciones del submenú
            //    if (mnuitOpcion.DropDownItems.Count > 0)
            //    {
            //        this.CambiarOpcionesMenu(mnuitOpcion.DropDownItems, fntOriginal);
            //    }
            //}


            //foreach (ToolStripMenuItem mnuitOpcion in this.menuStrip1.Items)
            //{
            //    MessageBox.Show(mnuitOpcion.Name.ToString());
            //    mnuitOpcion.DropDownItems[
            //}
            //foreach (ToolStrip mnuitOpcion in this.toolStrip1.Items)
            //{
            //    MessageBox.Show(mnuitOpcion.Name.ToString());
            //}

            //foreach (Control c in Controles)
            //{
            //    if (c is MenuStrip)
            //    {
            //        string name = c.Name;
            //    }
            //    if (c is ToolStrip)
            //    {
            //        ToolStrip toolStrip = c as ToolStrip;
            //        string name = c.Name;
            //    }
            //}
        }





        private void tsbFactura_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Frm_Requerimiento frm = new Frm_Requerimiento();
            frm.ShowDialog();
            this.Cursor = Cursors.Default;   
        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Frm_Requerimiento frm = new Frm_Requerimiento();
            frm.ShowDialog();
            this.Cursor = Cursors.Default;  
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pruebaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;
            //Frm_Periodo frm = new Frm_Periodo();
            //frm.vVar = "FECHAS";
            //frm.ShowDialog();
            //this.Cursor = Cursors.Default;
        }

        private void consumosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Frm_Periodo frm = new Frm_Periodo();
            frm.vVar = "CONSUMO";
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void consumosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Frm_Periodo frm = new Frm_Periodo();
            frm.vVar = "CONSUMO";
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //DataTable dtCorreoSup = new DataTable();
            //oBusConf = new BConfiguracion();
            //dtCorreoSup = oBusConf.getCargaOpcionesSUPERVISORXSOLICITANTE(Program.Usuario);
            //if (dtCorreoSup.Rows.Count > 0)
            //{
            //    envioCorreo("sistemas@limacaucho.com.pe", dtCorreoSup.Rows[0]["FILLER"].ToString().Trim(), "aprobacion de requisicion", "aprobacion de requisicon de " + Program.NomCorreo);
            //}

            //StringBuilder mensaje = new StringBuilder();
            //mensaje.Append("HOLA \n");
            //mensaje.Append("COMO ESTAS");
            //MessageBox.Show(mensaje.ToString());

            Application.Exit();

            //envioCorreo(Program.NomCorreo, Program.correo2, "Aprobación de Requerimiento", "Tiene Requerimiento de repuestos pendientes por aprobar");
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


        private void tbsConsulta_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Consultas.Frm_Consulta_Requerimientos frm = new Logistica.Ingenieria.Presentacion.Consultas.Frm_Consulta_Requerimientos();
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Frm_Configuracion frm = new Frm_Configuracion();
            frm.ShowDialog();
            this.Cursor = Cursors.Default;   
        }

        private void tbsAprobacion_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Transaccion.Frm_Aprobacion frm = new Logistica.Ingenieria.Presentacion.Transaccion.Frm_Aprobacion();
            frm.ShowDialog();
            this.Cursor = Cursors.Default;  
        }

        private void aprobaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Transaccion.Frm_Aprobacion frm = new Logistica.Ingenieria.Presentacion.Transaccion.Frm_Aprobacion();
            frm.ShowDialog();
            this.Cursor = Cursors.Default;  
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Transaccion.Frm_Aprobacion_Firma_Electronica frm = new Logistica.Ingenieria.Presentacion.Transaccion.Frm_Aprobacion_Firma_Electronica();
            frm.ShowDialog();
            this.Cursor = Cursors.Default; 
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Consultas.Frm_Seleccion_CCT frm = new Logistica.Ingenieria.Presentacion.Consultas.Frm_Seleccion_CCT();
            frm.ShowDialog();
            this.Cursor = Cursors.Default; 
        }

        private void genValeMPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Transaccion.Frm_Aprobacion_Firma_Electronica frm = new Logistica.Ingenieria.Presentacion.Transaccion.Frm_Aprobacion_Firma_Electronica(); 
            frm.ShowDialog();
            this.Cursor = Cursors.Default; 
        }

        private void genValeManualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Consultas.Frm_Seleccion_CCT frm = new Logistica.Ingenieria.Presentacion.Consultas.Frm_Seleccion_CCT();
            frm.ShowDialog();
            this.Cursor = Cursors.Default; 
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Consultas.Frm_Consulta_Requerimientos frm = new Logistica.Ingenieria.Presentacion.Consultas.Frm_Consulta_Requerimientos();
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void RQG08S_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Otros.Frm_Req_AI_CAB frm = new Logistica.Ingenieria.Presentacion.Otros.Frm_Req_AI_CAB();
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void cambioContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Frm_Contrasena frm = new Frm_Contrasena();
            frm.ShowDialog();
            this.Cursor = Cursors.Default;   
        }

        private void Frm_Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void RQG09S_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            oBusTab = new BTablas();
            decimal nroVale = Convert.ToDecimal(oBusTab.getUltimoValeSalida().Rows[0]["A13NVS"].ToString());
            //decimal nroVale = 2011090851;
            Reportes.Frm_Reporte_Vale frmRep = new Logistica.Ingenieria.Presentacion.Reportes.Frm_Reporte_Vale();
            frmRep.nro_Vale = nroVale;
            frmRep.observacion = "COPIA DE VALE";
            frmRep.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void RQG10S_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            oBusTab = new BTablas();
            Program.dtUnidMed = oBusTab.getSELECTLIBRE("SELECT T01ESP,T01AL1 FROM " + Program.LibreLUGTF + ".UGT01 U WHERE U.T01IDT='UND' AND U.T01NU2=1");
            oBusTab = new BTablas();
            Program.dtDescripcionesAdicionales = oBusTab.getSELECTLIBRE("SELECT RQCCVE,RQCSEQ,RQCDES FROM " + Program.LibreADAMAD2 + ".TRQCDDES");
            Consultas.Frm_Req_Alm_Ingenieria frm = new Logistica.Ingenieria.Presentacion.Consultas.Frm_Req_Alm_Ingenieria();

            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void RQG11S_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Consultas.Frm_Anio_ABC frm = new Logistica.Ingenieria.Presentacion.Consultas.Frm_Anio_ABC();
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
            
        }

        private void ingresosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Frm_Periodo frm = new Frm_Periodo();
            frm.vVar = "INGRESO";
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void RQG13S_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int i = oBusTab.BPrograms();
            Transaccion.Frm_Grupo frm = new Logistica.Ingenieria.Presentacion.Transaccion.Frm_Grupo();
            frm.variableForm = "CONSU";
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void RQG14S_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Mantenimientos.Ordenes_Trabajo.FrmOrdenTrabajo frm = new Logistica.Ingenieria.Presentacion.Mantenimientos.Ordenes_Trabajo.FrmOrdenTrabajo();       
            frm.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void asignacionCCTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Frm_Asign_CCT frm = new Frm_Asign_CCT();
            frm.ShowDialog();
            this.Cursor = Cursors.Default; 
        }

    }
}
