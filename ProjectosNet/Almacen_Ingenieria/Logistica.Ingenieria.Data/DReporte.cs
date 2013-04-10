using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Logistica.Ingenieria.Entity;

using System.Data.SqlClient;

namespace Logistica.Ingenieria.Data
{
    public class DReporte
    {
        DConexion cn = new DConexion();
        string Sql = "";

        /*cambiar Libreria*/
        /// <summary>
        /// Actualizacion de tablas del AS400 Principales
        /// </summary>
        string Librelalmingb = "dbo";/*Almacen de Ingenieria LALMINGB*/
        string Librelalmaceb = "dbo";/*Almacen de Ingenieria LALMACEB*/

        public List<EReporteVALE> DListarProformav1(decimal nro_VALE, string AutoEje, string Despachador)
        {
            List<EReporteVALE> oVALES = new List<EReporteVALE>();
            try
            {
                oVALES = new List<EReporteVALE>();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                Sql = "SELECT  " +
" MPSFSA AS FECHA_SALIDA,  " +
" MPSNSA AS NRO_SALIDA,  " +
" ODTCOD AS ORDEN_TRABAJO,  " +
" U.T01AL1  AS AUTORIZACION_EJECUTIVA,  " +
" ODTDPT AS COD_DPTO,  " +
" ODTDES AS EMPLEADO_EN,  " +
" MPMCOD AS COD_PROD,  " +
" MPMDES AS DES_PROD,  " +
" M.T01AL1 AS UND_MED,  " +
" MPSCAN AS CANTIDAD,  " +
" MPMUBI AS UBICACION,  " +
" A.R01CPE AS CODAUTO,A.R01NOM AS NOMAUTO,  " +
" S.R01CPE AS CODSOLI,S.R01NOM AS NOMSOLI,  " +
" 'DDDDDDDDDDDDDDDDD' AS DESPACHADOR   " +
" FROM " + Librelalmingb + ".ALMVSAL LEFT OUTER JOIN  " +
" " + Librelalmingb + ".ALMMMAP ON (MPSCOD=MPMCOD) LEFT OUTER JOIN  " +
" (SELECT T01ESP,T01AL1,T01AL2,T01NU2 FROM LUGTF.UGT01 WHERE T01IDT='UND' AND T01NU2=1) AS M ON SUBSTR(DIGITS(MPMUNI),2,2)=M.T01ESP LEFT OUTER JOIN  " +
" (SELECT ODTSTT, CAST(ODTCOD AS CHAR(3)) AS ODTCOD,CAST(ODTDPT AS CHAR(5)) AS ODTDPT,ODTDES, T01AL1  " +
" FROM " + Librelalmingb + ".AIODET LEFT JOIN LUGTF.UGT01 ON DIGITS(ODTDPT) = T01ESP WHERE T01IDT='CCT') AS U ON (MPSOTR=U.ODTCOD AND MPSARE=U.ODTDPT) LEFT OUTER JOIN  " +
" (SELECT R01CPE,R01NOM FROM QS36F.RIPMGEN5) AS A ON (MPSAUT=A.R01CPE) LEFT OUTER JOIN  " +
" (SELECT R01CPE,R01NOM FROM QS36F.RIPMGEN5) AS S ON (MPSSOL=S.R01CPE)   " +
" WHERE MPMSTT IN ('M','O') AND MPSNSA=" + nro_VALE;
                cmd.CommandText = Sql;
                cmd.Connection = cn.Conectar;
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.SingleResult);
                if (dr.HasRows)
                {
                    EReporteVALE oVALE = new EReporteVALE();
                    while (dr.Read())
                    {
                        oVALE = new EReporteVALE();
                        oVALE.FECHA_SALIDA = dr.GetString(dr.GetOrdinal("FECHA_SALIDA"));
                        oVALE.NRO_VALE_SALIDA = dr.GetString(dr.GetOrdinal("NRO_SALIDA"));
                        oVALE.ORDENTRABAJO = dr.GetString(dr.GetOrdinal("ORDEN_TRABAJO"));
                        oVALE.AUTORIZACION_EJECUTIVA = dr.GetString(dr.GetOrdinal("AUTORIZACION_EJECUTIVA"));
                        oVALE.COD_DPTO = dr.GetString(dr.GetOrdinal("COD_DPTO"));
                        oVALE.EMPLEADO_EN = dr.GetString(dr.GetOrdinal("EMPLEADO_EN"));
                        oVALE.COD_PROD = dr.GetString(dr.GetOrdinal("COD_PROD"));
                        oVALE.DES_PROD = dr.GetString(dr.GetOrdinal("DES_PROD"));
                        oVALE.UND_MED = dr.GetString(dr.GetOrdinal("UND_MED"));
                        oVALE.CANTIDAD = Convert.ToDecimal(dr.GetValue(dr.GetOrdinal("CANTIDAD")));
                        oVALE.UBICACION = dr.GetString(dr.GetOrdinal("UBICACION"));
                        oVALE.COD_AUT = dr.GetString(dr.GetOrdinal("CODAUTO"));
                        oVALE.NOM_AUT = dr.GetString(dr.GetOrdinal("NOMAUTO"));
                        oVALE.COD_SOL = dr.GetString(dr.GetOrdinal("CODSOLI"));
                        oVALE.NOM_SOL = dr.GetString(dr.GetOrdinal("NOMSOLI"));
                        oVALE.DESPACHADOR = dr.GetString(dr.GetOrdinal("DESPACHADOR"));   
                        oVALES.Add(oVALE);
                    }
                }
                cmd.Dispose();
                cn.Conectar.Close();
            }
            catch (Exception ex) { throw; }
            finally { cn.Conectar.Close(); }
            return oVALES;
        }


        public List<EReporteVALE> DListarProforma(decimal nro_VALE, string AutoEje, string Despachador)
        {
            List<EReporteVALE> oVALES = new List<EReporteVALE>();
            try
            {
                oVALES = new List<EReporteVALE>();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                Sql = "SELECT " +
" cast(MPSFSA as varchar(8)) AS FECHA_SALIDA,  " +
" cast(MPSNSA as varchar(10)) AS NRO_SALIDA,    " +
" IsNULL(ODTCOD,'') AS ORDEN_TRABAJO, " +
" IsNULL(U.T01AL1,'') AS AUTORIZACION_EJECUTIVA,   " +
" IsNULL(ODTDPT,'') AS COD_DPTO,   " +
" IsNULL(ODTDES,'') AS EMPLEADO_EN,  " +
"  MPMCOD AS COD_PROD,    " +
"  MPMDES AS DES_PROD,    " +
"  M.T01AL1 AS UND_MED,   " +
"  MPSCAN AS CANTIDAD,   " +
"  MPMUBI AS UBICACION,    " +
"  cast(A.R01CPE as varchar(4)) AS CODAUTO,A.R01NOM AS NOMAUTO,    " +
"  cast(S.R01CPE as varchar(4)) AS CODSOLI,S.R01NOM AS NOMSOLI,   " +
"  'Despachador' AS DESPACHADOR, " +
"  SUBSTRING(CAST(A11FSA AS VARCHAR(8)),7,2) + '/' + SUBSTRING(CAST(A11FSA AS VARCHAR(8)),5,2) +'/'+  SUBSTRING(CAST(A11FSA AS VARCHAR(8)),1,4) + '   ' +    " +
" (CASE WHEN LEN(A11UHM)=4 THEN SUBSTRING(CAST(A11UHM AS VARCHAR(4)),1,2)+':'+ SUBSTRING(CAST(A11UHM AS VARCHAR(4)),3,2) ELSE SUBSTRING(CAST(A11UHM AS VARCHAR(4)),1,1)+':'+ SUBSTRING(CAST(A11UHM AS VARCHAR(4)),2,2) END)  " +
"  AS FECHA_SOL, " +
" SUBSTRING(CAST(A11FA1 AS VARCHAR(8)),7,2) +'/' + SUBSTRING(CAST(A11FA1 AS VARCHAR(8)),5,2) +'/'+   " +
" SUBSTRING(CAST(A11FA1 AS VARCHAR(8)),1,4) + '   ' + SUBSTRING(CAST(A11UH1 AS VARCHAR(4)),1,2)+':'+ SUBSTRING(CAST(A11UH1 AS VARCHAR(4)),3,2) AS FECHA_AUT, " +
"   CODEMP AS CODEMP,  " +
"  NOMEMP AS NOM_REC,    " +
"  SUBSTRING(CAST(A11FVS AS VARCHAR(8)),7,2) +'/' + SUBSTRING(CAST(A11FVS AS VARCHAR(8)),5,2) +'/'+  SUBSTRING(CAST(A11FVS AS VARCHAR(8)),1,4) + '   ' +    " +
" (CASE WHEN LEN(cast(A11HVS as varchar(4)))=4 THEN SUBSTRING(CAST(A11HVS AS VARCHAR(4)),1,2)+':'+ SUBSTRING(CAST(A11HVS AS VARCHAR(4)),3,2) ELSE SUBSTRING(CAST(A11HVS AS VARCHAR(4)),1,1)+':'+ SUBSTRING(CAST(A11HVS AS VARCHAR(4)),2,2) END)  " +
" AS FECHA_DES,   " +
" cast(A11COR as varchar(4)) AS COD_RECIBIDO,  " +
" J.R01NOM AS NOM_RECIBIDO " +
" FROM ALMVSAL LEFT OUTER JOIN " +  
" ALMMMAP ON (MPSCOD=MPMCOD) LEFT OUTER JOIN   " +
" (SELECT T01ESP,T01AL1,T01AL2,T01NU2 FROM UGT01 WHERE T01IDT='UND' AND T01NU2=1) AS M ON SUBSTRING(CONVERT(VARCHAR(6),MPMUNI),1,2)=M.T01ESP LEFT OUTER JOIN  " +
" (SELECT ODTSTT, CAST(ODTCOD AS CHAR(3)) AS ODTCOD,CAST(ODTDPT AS CHAR(5)) AS ODTDPT,ODTDES, T01AL1   " +
" FROM AIODET LEFT JOIN UGT01 ON CONVERT(VARCHAR(6),ODTDPT) = T01ESP WHERE T01IDT='CCT') AS U ON (MPSOTR=U.ODTCOD AND MPSARE=U.ODTDPT) LEFT OUTER JOIN   " +
" (SELECT R01CPE,R01NOM FROM RIPMGEN9) AS A ON (MPSAUT=A.R01CPE) LEFT OUTER JOIN  " +
" (SELECT R01CPE,R01NOM FROM RIPMGEN9) AS S ON (MPSCOR=S.R01CPE) LEFT OUTER JOIN  " +
" ALI011UTIL ON (MPSNSA=A11NVS) LEFT OUTER JOIN  " +
"  (SELECT R01CPE,R01NOM FROM RIPMGEN9) AS J ON (A11COR=J.R01CPE) LEFT OUTER JOIN  " +
" ALIUSERS ON (CODUSE=A11UDE)  " +
"  WHERE MPMSTT IN ('M','O') AND MPSNSA=" + nro_VALE;
                cmd.CommandText = Sql;
                cmd.Connection = cn.Conectar;
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.SingleResult);
                if (dr.HasRows)
                {
                    EReporteVALE oVALE = new EReporteVALE();
                    while (dr.Read())
                    {
                        oVALE = new EReporteVALE();
                        oVALE.FECHA_SALIDA = dr.GetString(dr.GetOrdinal("FECHA_SALIDA"));
                        oVALE.NRO_VALE_SALIDA = dr.GetString(dr.GetOrdinal("NRO_SALIDA"));
                        oVALE.ORDENTRABAJO = dr.GetString(dr.GetOrdinal("ORDEN_TRABAJO"));
                        oVALE.AUTORIZACION_EJECUTIVA = dr.GetString(dr.GetOrdinal("AUTORIZACION_EJECUTIVA"));
                        oVALE.COD_DPTO = dr.GetString(dr.GetOrdinal("COD_DPTO"));
                        oVALE.EMPLEADO_EN = dr.GetString(dr.GetOrdinal("EMPLEADO_EN"));
                        oVALE.COD_PROD = dr.GetString(dr.GetOrdinal("COD_PROD"));
                        oVALE.DES_PROD = dr.GetString(dr.GetOrdinal("DES_PROD"));
                        oVALE.UND_MED = dr.GetString(dr.GetOrdinal("UND_MED"));
                        oVALE.CANTIDAD = Convert.ToDecimal(dr.GetValue(dr.GetOrdinal("CANTIDAD")));
                        oVALE.UBICACION = dr.GetString(dr.GetOrdinal("UBICACION"));
                        oVALE.COD_AUT = dr.GetString(dr.GetOrdinal("CODAUTO"));
                        oVALE.NOM_AUT = dr.GetString(dr.GetOrdinal("NOMAUTO"));
                        oVALE.COD_SOL = dr.GetString(dr.GetOrdinal("CODSOLI"));
                        oVALE.NOM_SOL = dr.GetString(dr.GetOrdinal("NOMSOLI"));
                        oVALE.DESPACHADOR = dr.GetString(dr.GetOrdinal("DESPACHADOR"));

                        oVALE.FECHASOLICITUD = dr.GetString(dr.GetOrdinal("FECHA_SOL"));
                        oVALE.FECHAAUTORIZACION = dr.GetString(dr.GetOrdinal("FECHA_AUT"));
                        oVALE.CODGENERADOR = dr.GetString(dr.GetOrdinal("CODEMP"));
                        oVALE.NOMGENERADOR = dr.GetString(dr.GetOrdinal("NOM_REC"));
                        oVALE.FECHAGENERADOR = dr.GetString(dr.GetOrdinal("FECHA_DES"));
                        oVALE.CODRECIBIDO = dr.GetString(dr.GetOrdinal("COD_RECIBIDO"));
                        oVALE.NOMRECIBIDO = dr.GetString(dr.GetOrdinal("NOM_RECIBIDO")); 
                        oVALES.Add(oVALE);
                    }
                }
                cmd.Dispose();
                cn.Conectar.Close();
            }
            catch (Exception ex) { throw; }
            finally { cn.Conectar.Close(); }
            return oVALES;
        }
    }
}
