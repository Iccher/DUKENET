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
using Logistica.Ingenieria.UtilsC;

namespace Logistica.Ingenieria.Presentacion.Consultas
{
    public partial class Frm_Consulta_Principal_MP : Form
    {
        public Frm_Consulta_Principal_MP()
        {
            InitializeComponent();
        }


        //Frm_Consulta_Principal_MP

        public string cadena = "";
        public string whereAG = "";



        BTablas obTran = new BTablas();
        DataTable dtMateriaPrima = new DataTable();
        DataTable dtCuentasMAT = new DataTable();
        DateTime DATE = DateTime.Now;
        string year = "";
        string mes = "";
        string mes1 = "";
        string year1 = "";
        string tabla = "";


        public List<String> listCTAALM = new List<string>();

        TControlVB oUtils = new TControlVB();
        TControlC oUtilsC = new TControlC();


        DataTable dtCargaMasivoMP = new DataTable();
        DataView dv = new DataView();

        private void Frm_Consulta_Principal_MP_Load(object sender, EventArgs e)
        {
            nombreMESES();


            year = DATE.Year.ToString();
            if (Convert.ToInt16(DATE.Month.ToString()) <= 9) { mes = "0" + DATE.Month.ToString(); }
            else { mes = DATE.Month.ToString(); }

            year1 = DATE.AddYears(-1).Year.ToString();
            if (Convert.ToInt16(DATE.AddMonths(-1).Month.ToString()) <= 9) { mes1 = "0" + DATE.AddMonths(-1).Month.ToString(); }
            else { mes1 = DATE.AddMonths(-1).Month.ToString(); }


            //tabla = year.Substring(2, 2) + mes1;
            tabla = DATE.AddMonths(-1).ToShortDateString().ToString().Substring(8, 2) + DATE.AddMonths(-1).ToShortDateString().ToString().Substring(3, 2);

            //Regresando tres meses para jalar los consumos e ingresos
            string anioJ1 = DATE.AddMonths(-2).ToShortDateString().ToString().Substring(6, 4);
            string anioJ2 = DATE.AddMonths(-3).ToShortDateString().ToString().Substring(6, 4);
            string anioJ3 = DATE.AddMonths(-4).ToShortDateString().ToString().Substring(6, 4);

            string mesJ1 = DATE.AddMonths(-2).ToShortDateString().ToString().Substring(3, 2);
            string mesJ2 = DATE.AddMonths(-3).ToShortDateString().ToString().Substring(3, 2);
            string mesJ3 = DATE.AddMonths(-4).ToShortDateString().ToString().Substring(3, 2);


            cargadoDATATABLES(year, year1, mes, tabla, mes1);
            //cargadoDATATABLES("2011", "2010", "10", "1109", "09");


            obTran = new BTablas();
            dtCuentasMAT = obTran.getSELECTLIBRE("SELECT MPTARG,MPTDES FROM " + Program.LibreLALMACEB + ".ALMTALM WHERE MPTTAB='CAL'");

            obTran = new BTablas();
            dtMateriaPrima = obTran.getSELECTLIBRE("SELECT " +
" F11.RMAT11COD, " +

" IFNULL((CASE WHEN MPMDES IS NULL THEN (SELECT  MPMDES From BCTSLIB.CRCODAI  " +
" INNER JOIN " + Program.LibreLALMINGB + ".ALMMMAP  ON (TRIM(CRINGC)=TRIM(MPMCOD))  " +
" WHERE  TRIM(CRMATC)=TRIM(F11.RMAT11COD) ) ELSE MPMDES END),'') AS DESCRIPCION, " +


" IFNULL((CASE WHEN MPMSCO IS NULL THEN (SELECT  MPMSCO From BCTSLIB.CRCODAI  " +
" INNER JOIN " + Program.LibreLALMINGB + ".ALMMMAP ON (TRIM(CRINGC)=TRIM(MPMCOD))  " +
" WHERE  TRIM(CRMATC)=TRIM(F11.RMAT11COD) )  ELSE MPMSCO END),0) AS MPMSCO, " +


" IFNULL((CASE WHEN MPMSDI IS NULL THEN (SELECT  MPMSDI  From BCTSLIB.CRCODAI " +
" INNER JOIN " + Program.LibreLALMINGB + ".ALMMMAP ON (TRIM(CRINGC)=TRIM(MPMCOD)) " +
" WHERE  TRIM(CRMATC)=TRIM(F11.RMAT11COD) )   ELSE MPMSDI END),0) AS MPMSDI," +

" IFNULL(RMAT11CAN,0) AS RMAT11CAN, " +

" IFNULL((SELECT DIATRA FROM LVENTAB.DIASREALES WHERE DIAANO='" + year + "' AND DIAMES='" + mes + "'),0) AS DSTOCK, " +

" IFNULL((CASE WHEN (SELECT   ( SUM(MPSCAN))  FROM LALMACEB .ALMVSAL  " +
" WHERE MPSSTT='S' AND TRIM(MPSCOD)=TRIM(F11.RMAT11COD)) IS NULL THEN " +
" (SELECT   ( SUM(MPSCAN)) From BCTSLIB.CRCODAI INNER JOIN " + Program.LibreLALMINGB + ".ALMVSAL ON  " +
" (TRIM(CRINGC)=TRIM(MPSCOD))  WHERE  TRIM(CRMATC)=TRIM(F11.RMAT11COD) )ELSE (SELECT   ( SUM(MPSCAN)) " +
" FROM LALMACEB .ALMVSAL  WHERE MPSSTT='S' AND TRIM(MPSCOD)=TRIM(F11.RMAT11COD))END ),0) AS CONSUMO, " +

" IFNULL((CASE WHEN (SELECT   ( SUM(MPICAN))  " +
" FROM " + Program.LibreLALMACEB + ".ALMVING  WHERE MPISTT='I' AND TRIM(MPICOD)=TRIM(F11.RMAT11COD)) IS NULL THEN   " +
" (SELECT   ( SUM(MPICAN)) From BCTSLIB.CRCODAI " +
" INNER JOIN " + Program.LibreLALMINGB + ".ALMVING  ON (TRIM(CRINGC)=TRIM(MPICOD)) " +
" WHERE  TRIM(CRMATC)=TRIM(F11.RMAT11COD) )  " +
" ELSE (SELECT   ( SUM(MPICAN))  FROM " + Program.LibreLALMACEB + ".ALMVING " +
" WHERE MPISTT='I' AND TRIM(MPICOD)=TRIM(F11.RMAT11COD))END ),0) AS INGRESOS," +

" IFNULL(RMAT11CON,0) AS RMAT11CON ," +

" (CASE WHEN MPMCTA IS NULL THEN (SELECT  MPMCTA From BCTSLIB.CRCODAI " +
" INNER JOIN " + Program.LibreLALMINGB + ".ALMMMAP  ON (TRIM(CRINGC)=TRIM(MPMCOD)) " +
" WHERE  TRIM(CRMATC)=TRIM(F11.RMAT11COD) ) ELSE MPMCTA END) AS CUENTA, " +


" IFNULL((CASE WHEN MPMCTA IS NULL THEN (SELECT  'ING' From BCTSLIB.CRCODAI " +
" INNER JOIN " + Program.LibreLALMINGB + ".ALMMMAP  ON (TRIM(CRINGC)=TRIM(MPMCOD)) " +
" WHERE  TRIM(CRMATC)=TRIM(F11.RMAT11COD) ) ELSE 'MAT' END),'') AS INDICADOR, " +

"  IFNULL((CASE WHEN MPMCTA IS NULL THEN (SELECT TRIM(MPMCOD) From BCTSLIB.CRCODAI  " +
" INNER JOIN " + Program.LibreLALMINGB + ".ALMMMAP  ON (TRIM(CRINGC)=TRIM(MPMCOD))  " +
" WHERE  TRIM(CRMATC)=TRIM(F11.RMAT11COD) ) ELSE 'XX' END),'') AS COD_EQUIV   " +


" FROM LFABRICAB.RMATF11 F11 LEFT JOIN  " + Program.LibreLALMACEB + ".ALMMMAP  ON (TRIM(RMAT11COD)=TRIM(MPMCOD)) " +
" WHERE RMAT11AÑO='" + year + "' AND RMAT11MES='" + mes + "'  and RMAT11TIP='1' ORDER BY RMAT11COD ASC");

            obTran = new BTablas();
            dtCargaMasivoMP  = obTran.getConsultaMateriaPrima(dtMateriaPrima, Program.dtCtaAlm, dtCuentasMAT, dtCosumoMesAnteriorMP, dtIngresoMesAnteriorMP, dtCosumoMesAnteriorAI, dtIngresoMesAnteriorAI, dtCosumoHistoricoMP, dtIngresoHistoricoMP, dtCosumoHistoricoAI, dtIngresoHistoricoAI, anioJ1, anioJ2, anioJ3, mesJ1, mesJ2, mesJ3);



            //dv = new DataView(obTran.getConsultaMateriaPrimaFINAL(listCTAALM, dtCargaMasivoMP));
            dv = new DataView(dtCargaMasivoMP);
            dv.RowFilter = "agotado IN (" + whereAG + ")";
            dv.Sort = "cuentaAlmacen DESC";
            DataTable dt = new DataTable();
            dt = dv.ToTable();
            obTran = new BTablas();
            dgvProductos.DataSource = obTran.getConsultaMateriaPrimaFINAL(listCTAALM, dt);
            //obTran = new BTablas();
            //dgvProductos.DataSource = obTran.getConsultaMateriaPrimaFINAL(listCTAALM, dtCargaMasivoMP);
            Grilla();
           
        }




        DataTable dtCosumoHistoricoMP = new DataTable();
        DataTable dtCosumoMesAnteriorMP = new DataTable();

        DataTable dtIngresoHistoricoMP = new DataTable();
        DataTable dtIngresoMesAnteriorMP = new DataTable();


        DataTable dtCosumoHistoricoAI = new DataTable();
        DataTable dtCosumoMesAnteriorAI = new DataTable();

        DataTable dtIngresoHistoricoAI = new DataTable();
        DataTable dtIngresoMesAnteriorAI = new DataTable();


        void cargadoDATATABLES(string YEAR1, string YEAR2, string MES, string tabla, string MESANTERIOR)
        {
            /*****MATERIA PRIMA**********/
            obTran = new BTablas();
            dtCosumoHistoricoMP = obTran.getSELECTLIBRE("SELECT MPCCOD,MPCACN,MPCC01,MPCC02,MPCC03, " +
" MPCC04,MPCC05,MPCC06,MPCC07,MPCC08, " +
" MPCC09,MPCC10,MPCC11,MPCC12 " +
" FROM " + Program.LibreLALMACEB + ".ALMMCON WHERE MPCACN IN (" + YEAR1 + "," + YEAR2 + ") AND " +
" MPCCOD IN (SELECT DISTINCT(RMAT11COD) FROM LFABRICAB.RMATF11 WHERE RMAT11AÑO='" + YEAR1 + "' AND RMAT11MES='" + MES + "'  and RMAT11TIP='1') " +
" ORDER BY MPCCOD");

            obTran = new BTablas();
            dtCosumoMesAnteriorMP = obTran.getSELECTLIBRE("SELECT MPSCOD,SUM(MPSCAN) CANTIDAD FROM " + Program.LibreLALMACEB + ".ALMV" + tabla + " " +
" WHERE MPSCOD IN (SELECT DISTINCT(RMAT11COD) FROM LFABRICAB.RMATF11 " +
" WHERE RMAT11AÑO='" + YEAR1 + "' AND RMAT11MES='" + MES + "'  and RMAT11TIP='1') " +
" GROUP BY MPSCOD ORDER BY MPSCOD");

            obTran = new BTablas();
            dtIngresoHistoricoMP = obTran.getSELECTLIBRE("SELECT MPECOD,MPEACN,MPEC01,MPEC02,MPEC03, " +
"MPEC04,MPEC05,MPEC06,MPEC07,MPEC08, " +
"MPEC09,MPEC10,MPEC11,MPEC12 " +
"FROM " + Program.LibreLALMACEB + ".ALMMING WHERE MPEACN IN (" + YEAR1 + "," + YEAR2 + ") AND " +
"MPECOD IN (SELECT DISTINCT(RMAT11COD) FROM LFABRICAB.RMATF11 WHERE RMAT11AÑO='" + YEAR1 + "' AND RMAT11MES='" + MES + "'  and RMAT11TIP='1') " +
"ORDER BY MPECOD");

            obTran = new BTablas();
            dtIngresoMesAnteriorMP = obTran.getSELECTLIBRE("SELECT MPICOD,SUM(MPICAN) CANTIDAD FROM " + Program.LibreLALMACEB + ".ALMVI" + MESANTERIOR + " " +
" WHERE MPICOD IN (SELECT DISTINCT(RMAT11COD) FROM LFABRICAB.RMATF11 " +
" WHERE RMAT11AÑO='" + YEAR1 + "' AND RMAT11MES='" + MES + "'  and RMAT11TIP='1')  " +
" GROUP BY MPICOD ORDER BY MPICOD");


            /**ALMACEN DE INGENIERIA**/
            obTran = new BTablas();
            dtCosumoHistoricoAI = obTran.getSELECTLIBRE("SELECT MPCCOD,MPCACN,MPCC01,MPCC02,MPCC03, " +
" MPCC04,MPCC05,MPCC06,MPCC07,MPCC08,  " +
" MPCC09,MPCC10,MPCC11,MPCC12  " +
" FROM " + Program.LibreLALMINGB + ".ALMMCON WHERE MPCACN IN (" + YEAR1 + "," + YEAR2 + ") AND  " +
" MPCCOD IN (SELECT DISTINCT(CRINGC) FROM LFABRICAB.RMATF11 LEFT OUTER JOIN   " +
" BCTSLIB.CRCODAI ON RMAT11COD=CRMATC WHERE RMAT11AÑO='" + YEAR1 + "' AND RMAT11MES='" + MES + "'  and RMAT11TIP='1')  " +
" ORDER BY MPCCOD");

            obTran = new BTablas();
            dtCosumoMesAnteriorAI = obTran.getSELECTLIBRE("SELECT MPSCOD,SUM(MPSCAN) CANTIDAD FROM " + Program.LibreLALMINGB + ".ALMV" + tabla + " " +
" WHERE MPSCOD IN (SELECT DISTINCT(CRINGC) FROM LFABRICAB.RMATF11 LEFT OUTER JOIN " +
" BCTSLIB.CRCODAI ON RMAT11COD=CRMATC WHERE RMAT11AÑO='" + YEAR1 + "' AND RMAT11MES='" + MES + "'  and RMAT11TIP='1')  " +
" GROUP BY MPSCOD ORDER BY MPSCOD");

            obTran = new BTablas();
            dtIngresoHistoricoAI = obTran.getSELECTLIBRE("SELECT MPECOD,MPEACN,MPEC01,MPEC02,MPEC03, " +
" MPEC04,MPEC05,MPEC06,MPEC07,MPEC08, " +
" MPEC09,MPEC10,MPEC11,MPEC12 " +
" FROM " + Program.LibreLALMINGB + ".ALMMING WHERE MPEACN IN (" + YEAR1 + "," + YEAR2 + ") AND " +
" MPECOD IN (SELECT DISTINCT(CRINGC) FROM LFABRICAB.RMATF11 LEFT OUTER JOIN " +
" BCTSLIB.CRCODAI ON RMAT11COD=CRMATC WHERE RMAT11AÑO='" + YEAR1 + "' AND RMAT11MES='" + MES + "'  and RMAT11TIP='1') " +
" ORDER BY MPECOD");

            obTran = new BTablas();
            dtIngresoMesAnteriorAI = obTran.getSELECTLIBRE("SELECT MPICOD,SUM(MPICAN) AS CANTIDAD FROM " + Program.LibreLALMINGB + ".ALMVI" + MESANTERIOR + " " +
" WHERE MPICOD IN (SELECT DISTINCT(CRINGC) FROM LFABRICAB.RMATF11 LEFT OUTER JOIN " +
" BCTSLIB.CRCODAI ON RMAT11COD=CRMATC WHERE RMAT11AÑO='" + YEAR1 + "' AND RMAT11MES='" + MES + "'  and RMAT11TIP='1') " +
" GROUP BY MPICOD ORDER BY MPICOD");
        }



        void Grilla()
        {

            dgvProductos.GridColor = Color.Red;


            dgvProductos.Columns["Codigo"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvProductos.Columns["Descripcion"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvProductos.Columns["Contable"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvProductos.Columns["Disponible"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvProductos.Columns["ReqProd"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvProductos.Columns["FechaQuiebre"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvProductos.Columns["DStck"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvProductos.Columns["agotado"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvProductos.Columns["Consumo"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvProductos.Columns["Consumo1"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvProductos.Columns["Consumo2"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvProductos.Columns["Consumo3"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvProductos.Columns["Consumo4"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvProductos.Columns["Ingreso"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvProductos.Columns["Ingreso1"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvProductos.Columns["Ingreso2"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvProductos.Columns["Ingreso3"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvProductos.Columns["Ingreso4"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvProductos.Columns["CProm"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvProductos.Columns["CuentaAlmacen"].SortMode = DataGridViewColumnSortMode.NotSortable;



            dgvProductos.Columns["Codigo"].Frozen = true;
            dgvProductos.Columns["Descripcion"].Frozen = true;




            dgvProductos.Columns["Codigo"].DisplayIndex = 0;
            dgvProductos.Columns["Descripcion"].DisplayIndex = 1;
            dgvProductos.Columns["Contable"].DisplayIndex = 2;
            dgvProductos.Columns["Disponible"].DisplayIndex = 3;
            dgvProductos.Columns["ReqProd"].DisplayIndex = 4;
            dgvProductos.Columns["FechaQuiebre"].DisplayIndex = 5;
            dgvProductos.Columns["DStck"].DisplayIndex = 6;
            dgvProductos.Columns["agotado"].DisplayIndex = 7;
            dgvProductos.Columns["Consumo"].DisplayIndex = 8;
            dgvProductos.Columns["Consumo1"].DisplayIndex = 9;
            dgvProductos.Columns["Consumo2"].DisplayIndex = 10;
            dgvProductos.Columns["Consumo3"].DisplayIndex = 11;
            dgvProductos.Columns["Consumo4"].DisplayIndex = 12;
            dgvProductos.Columns["Ingreso"].DisplayIndex = 13;
            dgvProductos.Columns["Ingreso1"].DisplayIndex = 14;
            dgvProductos.Columns["Ingreso2"].DisplayIndex = 15;
            dgvProductos.Columns["Ingreso3"].DisplayIndex = 16;
            dgvProductos.Columns["Ingreso4"].DisplayIndex = 17;
            dgvProductos.Columns["CProm"].DisplayIndex = 18;
            dgvProductos.Columns["CuentaAlmacen"].DisplayIndex = 19;


            dgvProductos.Columns["Codigo"].HeaderText = "Codigo";
            dgvProductos.Columns["Descripcion"].HeaderText = "Descripción";
            dgvProductos.Columns["Contable"].HeaderText = "Stock Contable";
            dgvProductos.Columns["Disponible"].HeaderText = "Stock Disponible";
            dgvProductos.Columns["ReqProd"].HeaderText = "Requrimiento Producción Mensual";
            dgvProductos.Columns["FechaQuiebre"].HeaderText = "Fecha Quiebre";
            dgvProductos.Columns["DStck"].HeaderText = "Dias Stock";
            dgvProductos.Columns["agotado"].HeaderText = "Agotad.";
            dgvProductos.Columns["Consumo"].HeaderText = "Cons. al " + nomMES;
            dgvProductos.Columns["Consumo1"].HeaderText = "Consumo " + nomMES1;
            dgvProductos.Columns["Consumo2"].HeaderText = "Consumo. " + nomMES2;
            dgvProductos.Columns["Consumo3"].HeaderText = "Consumo. " + nomMES3;
            dgvProductos.Columns["Consumo4"].HeaderText = "Consumo. " + nomMES4;
            dgvProductos.Columns["Ingreso"].HeaderText = "Ingr. al " + nomMES;
            dgvProductos.Columns["Ingreso1"].HeaderText = "Ingreso. " + nomMES1;
            dgvProductos.Columns["Ingreso2"].HeaderText = "Ingreso. " + nomMES2;
            dgvProductos.Columns["Ingreso3"].HeaderText = "Ingreso. " + nomMES3;
            dgvProductos.Columns["Ingreso4"].HeaderText = "Ingreso. " + nomMES4;
            dgvProductos.Columns["CProm"].HeaderText = "Cosumo Promedio";
            dgvProductos.Columns["CuentaAlmacen"].HeaderText = "Cta.Alm.";

            dgvProductos.Columns["Codigo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["Contable"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["Disponible"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["ReqProd"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["FechaQuiebre"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["DStck"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["agotado"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["Consumo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["Consumo1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["Consumo2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["Consumo3"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["Consumo4"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["Ingreso"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["Ingreso1"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["Ingreso2"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["Ingreso3"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["Ingreso4"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["CProm"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["CuentaAlmacen"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvProductos.Columns["Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;  
            dgvProductos.Columns["Contable"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns["Disponible"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns["ReqProd"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns["FechaQuiebre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["DStck"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns["agotado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProductos.Columns["Consumo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns["Consumo1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns["Consumo2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns["Consumo3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns["Consumo4"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns["Ingreso"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns["Ingreso1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns["Ingreso2"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns["Ingreso3"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns["Ingreso4"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns["CProm"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProductos.Columns["CuentaAlmacen"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;                      
            

            dgvProductos.Columns["Codigo"].Width = 80;
            dgvProductos.Columns["Descripcion"].Width = 200;
            dgvProductos.Columns["Contable"].Width = 60;
            dgvProductos.Columns["Disponible"].Width = 60;
            dgvProductos.Columns["ReqProd"].Width = 90;
            dgvProductos.Columns["FechaQuiebre"].Width = 70;
            dgvProductos.Columns["DStck"].Width = 60;
            dgvProductos.Columns["agotado"].Width = 60;
            dgvProductos.Columns["Consumo"].Width = 60;
            dgvProductos.Columns["Consumo1"].Width = 60;
            dgvProductos.Columns["Consumo2"].Width = 60;
            dgvProductos.Columns["Consumo3"].Width = 60;
            dgvProductos.Columns["Consumo4"].Width = 60;
            dgvProductos.Columns["Ingreso"].Width = 60;
            dgvProductos.Columns["Ingreso1"].Width = 60;
            dgvProductos.Columns["Ingreso2"].Width = 60;
            dgvProductos.Columns["Ingreso3"].Width = 60;
            dgvProductos.Columns["Ingreso4"].Width = 60;
            dgvProductos.Columns["CProm"].Width = 60;
            dgvProductos.Columns["CuentaAlmacen"].Width = 60;


            for (int i = 0; i <= dgvProductos.Rows.Count - 1; i++)
            {
                string valor = dgvProductos["Codigo", i].Value.ToString();
                if (valor == ".")
                {
                    dgvProductos["Descripcion", i].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;                    
                    dgvProductos.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;                    
                }
                else
                {
                    dgvProductos["Descripcion", i].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }    
                valor = dgvProductos["Contable", i].Value.ToString();
                if (valor != "") { dgvProductos["Contable", i].Value = String.Format("{0:0,0}", Convert.ToDouble(valor)); }
                valor = dgvProductos["Disponible", i].Value.ToString();
                if (valor != "") { dgvProductos["Disponible", i].Value = String.Format("{0:0,0}", Convert.ToDouble(valor)); }
                valor = dgvProductos["ReqProd", i].Value.ToString();
                if (valor != "") { dgvProductos["ReqProd", i].Value = String.Format("{0:0,0}", Convert.ToDouble(valor)); }
                valor = dgvProductos["DStck", i].Value.ToString();
                if (valor != "") { dgvProductos["DStck", i].Value = String.Format("{0:0,0}", Convert.ToDouble(valor)); }
                
                valor = dgvProductos["Consumo", i].Value.ToString();
                if (valor != "") { dgvProductos["Consumo", i].Value = String.Format("{0:0,0}", Convert.ToDouble(valor)); dgvProductos["Consumo", i].Style.ForeColor = Color.Maroon; }                valor = dgvProductos["Consumo1", i].Value.ToString();
                if (valor != "") { dgvProductos["Consumo1", i].Value = String.Format("{0:0,0}", Convert.ToDouble(valor)); dgvProductos["Consumo1", i].Style.ForeColor = Color.Maroon; }
                valor = dgvProductos["Consumo2", i].Value.ToString();
                if (valor != "") { dgvProductos["Consumo2", i].Value = String.Format("{0:0,0}", Convert.ToDouble(valor)); dgvProductos["Consumo2", i].Style.ForeColor = Color.Maroon; }
                valor = dgvProductos["Consumo3", i].Value.ToString();
                if (valor != "") { dgvProductos["Consumo3", i].Value = String.Format("{0:0,0}", Convert.ToDouble(valor)); dgvProductos["Consumo3", i].Style.ForeColor = Color.Maroon; }
                valor = dgvProductos["Consumo4", i].Value.ToString();
                if (valor != "") { dgvProductos["Consumo4", i].Value = String.Format("{0:0,0}", Convert.ToDouble(valor)); dgvProductos["Consumo4", i].Style.ForeColor = Color.Maroon; }
                valor = dgvProductos["Ingreso", i].Value.ToString();
                if (valor != "") { dgvProductos["Ingreso", i].Value = String.Format("{0:0,0}", Convert.ToDouble(valor)); dgvProductos["Ingreso", i].Style.ForeColor = Color.Blue; }
                valor = dgvProductos["Ingreso1", i].Value.ToString();
                if (valor != "") { dgvProductos["Ingreso1", i].Value = String.Format("{0:0,0}", Convert.ToDouble(valor)); dgvProductos["Ingreso1", i].Style.ForeColor = Color.Blue; }
                valor = dgvProductos["Ingreso2", i].Value.ToString();
                if (valor != "") { dgvProductos["Ingreso2", i].Value = String.Format("{0:0,0}", Convert.ToDouble(valor)); dgvProductos["Ingreso2", i].Style.ForeColor = Color.Blue; }
                valor = dgvProductos["Ingreso3", i].Value.ToString();
                if (valor != "") { dgvProductos["Ingreso3", i].Value = String.Format("{0:0,0}", Convert.ToDouble(valor)); dgvProductos["Ingreso3", i].Style.ForeColor = Color.Blue; }
                valor = dgvProductos["Ingreso4", i].Value.ToString();
                if (valor != "") { dgvProductos["Ingreso4", i].Value = String.Format("{0:0,0}", Convert.ToDouble(valor)); dgvProductos["Ingreso4", i].Style.ForeColor = Color.Blue; }
                valor = dgvProductos["CProm", i].Value.ToString();
                if (valor != "") { dgvProductos["CProm", i].Value = String.Format("{0:0,0}", Convert.ToDouble(valor)); }


                valor = dgvProductos["agotado", i].Value.ToString();
                if (valor != "") { dgvProductos["agotado", i].Style.ForeColor = Color.Red; }



               
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            oUtils.DataTableToExcelDATAGRIDVIEW(dgvProductos);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dv = new DataView(dtCargaMasivoMP);
            dv.RowFilter = "cuentaAlmacen IN (" + cadena + ") AND agotado in (" + whereAG + ")";
            dv.Sort = "cuentaAlmacen DESC";

            obTran = new BTablas();

            Reportes.FrmReporteMP frm = new Logistica.Ingenieria.Presentacion.Reportes.FrmReporteMP();
            frm.oMP = obTran.ReporteMP(dv);
            frm.ShowDialog();
        }

        string nomMES;
        string nomMES1;
        string nomMES2;
        string nomMES3;
        string nomMES4;
        void nombreMESES()
        {
            nomMES = DATE.ToShortDateString().ToString();
            nomMES1 = NombresMesesCalendar(Convert.ToInt16(DATE.AddMonths(-1).Month.ToString()));
            nomMES2 = NombresMesesCalendar(Convert.ToInt16(DATE.AddMonths(-2).Month.ToString()));
            nomMES3 = NombresMesesCalendar(Convert.ToInt16(DATE.AddMonths(-3).Month.ToString()));
            nomMES4 = NombresMesesCalendar(Convert.ToInt16(DATE.AddMonths(-4).Month.ToString()));
                       
        }



        string NombresMesesCalendar(int mes)
        {
            string nameMES="";
            switch (mes)
            {
                case 1:
                    nameMES = "Enero";
                    break;
                case 2:
                    nameMES = "Febrero";
                    break;
                case 3:
                    nameMES = "Marzo";
                    break;
                case 4:
                    nameMES = "Abril";
                    break;
                case 5:
                    nameMES = "Mayo";
                    break;
                case 6:
                    nameMES = "Junio";
                    break;
                case 7:
                    nameMES = "Julio";
                    break;
                case 8:
                    nameMES = "Agosto";
                    break;
                case 9:
                    nameMES = "Setiembre";
                    break;
                case 10:
                    nameMES = "Octubre";
                    break;
                case 11:
                    nameMES = "Noviembre";
                    break;
                default:
                    nameMES = "Diciembre";
                    break;
            }
            return nameMES;
        }




        
    }
}
