using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Logistica.Ingenieria.Bussiness;

namespace Logistica.Ingenieria.Presentacion.Consultas
{
    public partial class Frm_Consulta_Gerencia_Mat_Prima : Form
    {
        public Frm_Consulta_Gerencia_Mat_Prima()
        {
            InitializeComponent();
        }

        BTablas obTran = new BTablas();
        DataTable dtMateriaPrima = new DataTable();

        DataTable dtCuentasMAT = new DataTable();

        DateTime DATE = DateTime.Now;

        string year = "";
        string mes = "";

        string mes1 = "";
        string year1 = "";

        string tabla = "";
        private void Frm_Consulta_Gerencia_Mat_Prima_Load(object sender, EventArgs e)
        {
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
            dataGridView1.DataSource = obTran.getConsultaMateriaPrima(dtMateriaPrima, Program.dtCtaAlm, dtCuentasMAT, dtCosumoMesAnteriorMP, dtIngresoMesAnteriorMP, dtCosumoMesAnteriorAI, dtIngresoMesAnteriorAI, dtCosumoHistoricoMP, dtIngresoHistoricoMP, dtCosumoHistoricoAI, dtIngresoHistoricoAI, anioJ1, anioJ2, anioJ3, mesJ1, mesJ2, mesJ3);
           
        }




        DataTable dtCosumoHistoricoMP = new DataTable();
        DataTable dtCosumoMesAnteriorMP = new DataTable();

        DataTable dtIngresoHistoricoMP = new DataTable();
        DataTable dtIngresoMesAnteriorMP = new DataTable();


        DataTable dtCosumoHistoricoAI = new DataTable();
        DataTable dtCosumoMesAnteriorAI = new DataTable();

        DataTable dtIngresoHistoricoAI = new DataTable();
        DataTable dtIngresoMesAnteriorAI = new DataTable();


        void cargadoDATATABLES(string YEAR1,string YEAR2, string MES,string tabla,string MESANTERIOR)
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


    }
}
