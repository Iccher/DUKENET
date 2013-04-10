using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


using System.Data;


namespace Logistica.Ingenieria.Presentacion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            Application.Run(new frmLoginLL());

            //Application.Run(new Mantenimientos.Ordenes_Trabajo.FrmOrdenTrabajo());


            //Application.Run(new Reportes.Frm_Reporte_Vale());
            //Application.Run(new Form1());
            //Application.Run(new Frm_pruebaImagenesAVI());

            //Application.Run(new Otros.Frm_Req_Ingenieria());
            //Application.Run(new Otros.Frm_Req_AI_CAB());
        }

        public static string LibreLALMINGB = "DBO";
        public static string LibreLALMACEB = "DBO";
        public static string LibreLUGTF = "DBO";
        public static string LibreADAMAD2 = "DBO";



        public static string Usuario = "";
        public static string Password = "";
        public static string NomUsu = "";
        public static string codplanillaUSU = "";
        public static string correo = "";
        public static string correo2 = "";

        public static string NomCorreo = "";
        public static string NomCorreo2 = "";

        public static decimal TipoCambio = 0;
        public static decimal LimSuperv = 0;
        public static decimal LimJefe = 0;
        public static string nivUsu = "";
        

        //public static DateTime FechaSis = DateTime.Now;
        public static string UsuarioPC = Environment.UserName.ToUpper();
        public static string HostPC = Environment.MachineName.ToUpper();


        public static DataTable dtCCostoLaborales = new DataTable();

        public static DataTable dtEmpleados = new DataTable();
        public static DataTable dtCCostos = new DataTable();
        public static DataTable dtTipSolic = new DataTable();
        public static DataTable dtCtaAlm = new DataTable();

        public static DataTable dtUsuariosConec = new DataTable();
        public static DataView dvUsuariosConec = new DataView();

        public static DataTable dtPermisos = new DataTable();
        public static DataView dvAutorizaciones = new DataView();
        
        public static string Cuentas = "";

        //public static DataTable dtProductos = new DataTable();
        public static DataTable dtDesUnidad = new DataTable();
        public static DataTable dtGrupos = new DataTable();
        public static DataTable dtSubGrupos = new DataTable();

        public static DataTable dtAplicabilidad = new DataTable();
        public static DataTable dtArea = new DataTable();

        public static DataTable dtValesIng = new DataTable();

        public static DataTable dt = new DataTable();

        /*CARGA LAS AUTORIZACIONES DE MODULO*/
        public static DataTable dtOcpiones = new DataTable();
        public static DataTable dtOcpionesxUsuario = new DataTable();


        public static DataTable dtJEFExSUPERVISOR = new DataTable();
        public static DataView dvJefeSupervisor = new DataView();
        public static string SUPERVISORES = "";


        /*carga unidad de medidas almacen de ingenieria*/
        public static DataTable dtUnidMed = new DataTable();
        public static DataTable dtDescripcionesAdicionales = new DataTable();

                
    }
}
