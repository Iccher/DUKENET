using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;


using System.Data.SqlClient;

namespace Logistica.Ingenieria.Data
{
    public class DTablas
    {
        DConexion cn = new DConexion();

        /*cambiar Libreria*/
        /// <summary>
        /// Actualizacion de tablas del AS400 Principales
        /// </summary>
        string Librelalmingb = "dbo";/*Almacen de Ingenieria LALMINGB*/
        string Librelalmaceb = "dbo";/*Almacen de Ingenieria LALMACEB*/
        string Libreadamad2 = "dbo";/*Almacen de Ingenieria LALMACEB*/
        string Librealugtf = "dbo";/*Almacen de Ingenieria LALMACEB*/

        public DataTable getSELECTLIBRE(string SQL)
        {
            //SqlDataAdapter da = new SqlDataAdapter("SELECT R01CPE AS CODIGO,R01NOM AS NOMBRE FROM QS36F.RIPMGEN5 ORDER BY R01CPE", cn.Conectar);
            SqlDataAdapter da = new SqlDataAdapter(SQL, cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }


        public DataTable getCargaEmpleados()
        {
            //SqlDataAdapter da = new SqlDataAdapter("SELECT R01CPE AS CODIGO,R01NOM AS NOMBRE FROM QS36F.RIPMGEN5 ORDER BY R01CPE", cn.Conectar);
            SqlDataAdapter da = new SqlDataAdapter("SELECT R01CPE AS CODIGO,R01NOM AS NOMBRE,R01ACO AS PUESTO FROM DBO.RIPMGEN9 ORDER BY R01CPE", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable getCargaCORREOS()
        {
            //SqlDataAdapter da = new SqlDataAdapter("SELECT R01CPE AS CODIGO,R01NOM AS NOMBRE FROM QS36F.RIPMGEN5 ORDER BY R01CPE", cn.Conectar);
            SqlDataAdapter da = new SqlDataAdapter("SELECT CODEMP,NOMEMP,FILLER FROM " + Librelalmingb + ".ALIUSERS WHERE FILLER<>'' AND ESTADO='A' AND CODUSE IN ('LMAIFCR1','LAGGAAA1','LLCOERG1','LLCOAMR1','LMAIFPR1','LMAIRAP1')", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable getCargaAreas()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT T01ESP,T01AL1 FROM " + Librealugtf + ".UGT01 WHERE T01IDT='CCT' AND T01STT<>'E'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable getCargaAreasxEmpleados()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT T01ESP,T01AL1 FROM " + Librealugtf + ".UGT01 WHERE T01IDT='CCT' AND T01STT<>'E'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

//        public DataTable getCargaCentroCostos()
//        {
//            SqlDataAdapter da = new SqlDataAdapter("SELECT " +
//" ODTSTT, ODTCOD, ODTDPT,ODTDES, T01AL1 " +
//" FROM " + Librelalmingb + ".AIODET LEFT JOIN " + Librealugtf + ".UGT01 ON DIGITS(ODTDPT) = T01ESP WHERE T01IDT='CCT' ORDER BY ODTDPT", cn.Conectar);
//            DataTable tabla = new DataTable();
//            da.Fill(tabla);
//            return tabla;
//        }

        public DataTable getCargaCentroCostos()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT " +
" ODTSTT, CAST(ODTCOD AS CHAR(3)) AS ODTCOD,CAST(ODTDPT AS CHAR(5)) AS ODTDPT,ODTDES, isnull(T01AL1,'') AS T01AL1 " +
" FROM " + Librelalmingb + ".AIODET LEFT JOIN " + Librealugtf + ".UGT01 ON (convert(varchar(6), ODTDPT ) = T01ESP AND T01IDT='CCT') WHERE ODTDPT=0 ORDER BY ODTCOD", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }



        public DataTable getCargaCentroCostosLABORALES()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT RTRIM(DATCVE) AS DATCVE,DATDES FROM dbo.V_TRABAJ WHERE TRAFBA=0 GROUP BY DATCVE,DATDES ORDER BY DATCVE", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }



        public DataTable getCargaTipoSolicitud()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT MPTARG AS CODIGO,MPTDES AS DESCRIPCION FROM " + Librelalmaceb + ".ALMTALM WHERE MPTTAB ='TSA'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable getCargaProductos()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT SUBSTR(MPMCOD,1,2) AS GRUPO,SUBSTR(MPMCOD,1,4) AS SUBGRUPO," + 
" MPMCOD,MPMDES,MPMARE,MPMCTA,MPMPRO,MPMUNI,MPMCCA,MPMTIT,MPMSMX,MPMSMN, " +
" MPMSEM,MPMSCO,MPMSDI,MPMCPR,MPMCDO,MPMAPL,MPMABC,MPMUBI,MPMDPT FROM " + Librelalmingb + ".ALMMMAP", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable getCargaUND()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT T01ESP,T01AL1,T01AL2 FROM " + Librealugtf + ".UGT01 WHERE T01IDT='UND'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable getCargaGRUPOS()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT AIGCOD,AIGDES FROM " + Librelalmingb + ".AIGRUP ORDER BY AIGCOD", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable getCargaSUBGRUPOS()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT AISCOD,AISDES FROM " + Librelalmingb + ".AISUBG", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable getCargaSubGRUPOSxAREA(decimal area)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT aiscod, aisdes FROM " + Librelalmingb + ".aisubg WHERE SUBSTR(AISCOD,1,2)=" + area + " ORDER BY aiscod", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }


        public DataTable getCargaRepuestosxSubGRUPOS(string cod)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT " +
" mpmcod AS Codigo, " +
" mpmdes AS Descripcion, " +
" substring(mpmdes,31,15) AS N_Parte, " +
" mpmuni AS Cod_Und_Med, " +
" t01al2 AS Unid_Med, " +
" mpmubi AS Ubicacion, " +
" IFNULL(arddes,'') AS Descripcion_Tarde, " +
" mpmapl AS Aplicabilidad, " +
" IFNULL(MPDDES,'') AS MPDCOD, " +
"  MPMCPR AS PRECIO " +
" FROM " + Librelalmingb + ".almmmap " +
" LEFT OUTER JOIN " + Libreadamad2 + ".tarde ON mpmcod=artcod AND ardseq=1 " +
" LEFT OUTER JOIN " + Librealugtf + ".ugt01 ON mpmuni=t01esp AND t01nu3=9 " +
" LEFT OUTER JOIN " + Librelalmingb + ".ALMMMAPDES ON MPMCOD=MPDCOD " +
" LEFT OUTER JOIN " + Librelalmingb + ".TABLA_OBS ON MPMCOD=CO_REPUESTO " +
" WHERE mpmpro='3' AND MPMSTT IN ('M','O') AND  SUBSTR(mpmcod,1,4)='" + cod + "' " +
" AND t01idt='UND' AND IFNULL(CO_REPUESTO,'L')='L' " +
" UNION ALL " +
" SELECT " +
" mpmcod AS Codigo, " +
" mpmdes AS Descripcion, " +
" substring(mpmdes,60,1) AS N_Parte, " +
" mpmuni AS Cod_Und_Med, " +
" t01al2 AS Unid_Med, " +
" mpmubi AS Ubicacion, " +
" IFNULL(arddes,'') AS Descripcion_Tarde, " +
" mpmapl AS Aplicabilidad, " +
" IFNULL(MPDDES,'') AS MPDDES, " +
"  MPMCPR AS PRECIO " +
" FROM " + Librelalmingb + ".almmmap " +
" LEFT OUTER JOIN " + Libreadamad2 + ".tarde ON mpmcod=artcod AND ardseq=1 " +
" LEFT OUTER JOIN " + Librealugtf + ".ugt01 ON mpmuni=t01esp AND t01nu3=9 " +
" LEFT OUTER JOIN " + Librelalmingb + ".ALMMMAPDES ON MPMCOD=MPDCOD " +
" LEFT OUTER JOIN " + Librelalmingb + ".TABLA_OBS ON MPMCOD=CO_REPUESTO " +
" WHERE mpmpro<>'3' AND MPMSTT IN ('M','O') AND SUBSTR(mpmcod,1,4)='" + cod + "' " +
" AND t01idt='UND' AND IFNULL(CO_REPUESTO,'L')='L' ", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable getCargaAPLICABILIDAD()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT AITCOD,AITDES FROM " + Librelalmingb + ".AIAPLI", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable getCargaAPLICABILIDADxSubGRUPO(string SubGrupo)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT AITCOD,CAST(SUBSTR(AITCOD,5,4) AS DECIMAL) AS APLI,TRIM(AITDES) AS AITDES FROM " + Librelalmingb + ".AIAPLI WHERE SUBSTR(AITCOD,1,4)='" + SubGrupo + "'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }


        public DataTable getDescriAdicionalMECANICOS(string Cod)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM " + Librelalmingb + ".ALMMMAPDES WHERE MPDCOD='" + Cod + "'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public int DInsertDescriAdicionalMECANICOS(string User,decimal Fecha,decimal Hora,string Cod,string des)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                string sql = "INSERT INTO " + Librelalmingb + ".ALMMMAPDES (MPDUID, MPDUFE, MPDUHM, MPDCOD, MPDDES) VALUES ('" + User + "', " + Fecha + ", " + Hora + ", '" + Cod + "', '" + des + "')";
                cmd.CommandText = sql;
                cmd.Connection = cn.Conectar;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                i = 1;
                cmd.Dispose();
                cn.Conectar.Dispose();
                cn.Conectar.Close();
            }
            catch { throw; }
            return i;
        }


        /// <summary>
        /// ultimo vale de salida
        /// </summary>
        /// <returns></returns>
        public DataTable getUltimoValeSalida()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT A13NVS FROM " + Librelalmingb + ".ALI013UTIL ORDER BY A13NVS desc Fetch first 1 rows only", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }



        public DataTable getArmadoSalidas(string mes)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT MPSNSA,MPSAUT,MPSSOL,MPSARE FROM H" + Librelalmingb + ".MRSA" + mes + " GROUP BY MPSNSA,MPSAUT,MPSSOL,MPSARE", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable getArmadoSalidasACTUAL(string mes)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT MPSNSA,MPSAUT,MPSSOL,MPSARE FROM " + Librelalmingb + ".ALMVSAL GROUP BY MPSNSA,MPSAUT,MPSSOL,MPSARE", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable getArmadoSalidasXProductoPASADO(string mes,decimal vale)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT MPSNSA,MPSUFE,MPSCOD,MPMDES,MPMUNI,IFNULL(T01AL1,'') AS T01AL1,MPMUBI,MPSCCA " +
" FROM H" + Librelalmingb + ".MRSA" + mes + " LEFT OUTER JOIN " +
" " + Librelalmingb + ".ALMMMAP ON MPSCOD=MPMCOD LEFT OUTER JOIN " +
" (SELECT T01ESP,T01AL1,T01AL2,T01NU2 FROM " + Librealugtf + ".UGT01 WHERE T01IDT='UND' AND T01NU2=1) AS M ON SUBSTR(DIGITS(MPMUNI),2,2)=M.T01ESP " +
" WHERE MPSNSA= " + vale, cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable getArmadoSalidasXProductoACTUAL(decimal vale)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT MPSNSA,MPSUFE,MPSCOD,MPMDES,MPMUNI,IFNULL(T01AL1,'') AS T01AL1,MPMUBI,MPSCCA " +
" FROM " + Librelalmingb + ".ALMVSAL LEFT OUTER JOIN " +
" " + Librelalmingb + ".ALMMMAP ON MPSCOD=MPMCOD LEFT OUTER JOIN " +
" (SELECT T01ESP,T01AL1,T01AL2,T01NU2 FROM " + Librealugtf + ".UGT01 WHERE T01IDT='UND' AND T01NU2=1) AS M ON SUBSTR(DIGITS(MPMUNI),2,2)=M.T01ESP " +
" WHERE MPSNSA= " + vale, cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        /*************************************************SELECT CONSULTA FERNANDO CORRALES****************************************************/
        public DataTable getSalidasProductoACTUAL()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT MPSCOD,MPMDES,MPSFSA,MPSNSA,MPSCAN,MPSIMP,MPSARE,MPSCOR,MPSSOL, " +
" MPMCTA,MPMCCA,MPSPRO,MPMUNI,IsNULL(T01AL1,'') AS T01AL1,MPMSMX,MPMSMN,MPMSEM,MPMPRE,MPMSCO,MPMUBI,MPSOTR " +
" FROM " + Librelalmingb + ".ALMVSAL LEFT OUTER JOIN " +
" " + Librelalmingb + ".ALMMMAP ON MPSCOD=MPMCOD LEFT OUTER JOIN " +
" (SELECT T01ESP,T01AL1,T01AL2,T01NU2 FROM " + Librealugtf + ".UGT01 WHERE T01IDT='UND' AND T01NU2=1) AS M ON SUBSTRing(convert(varchar(6),MPMUNI),2,2)=M.T01ESP", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable getSalidasProductoPASADO(string mes)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT MPSCOD,MPMDES,MPSFSA,MPSNSA,MPSCAN,MPSIMP,MPSARE,MPSCOR,MPSSOL, " +
" MPMCTA,MPMCCA,MPSPRO,MPMUNI,IFNULL(T01AL1,'') AS T01AL1,MPMSMX,MPMSMN,MPMSEM,MPMPRE,MPMSCO,MPMUBI,MPSOTR " +
" FROM H" + Librelalmingb + ".MRSA" + mes + " LEFT OUTER JOIN " +
" " + Librelalmingb + ".ALMMMAP ON MPSCOD=MPMCOD LEFT OUTER JOIN " +
" (SELECT T01ESP,T01AL1,T01AL2,T01NU2 FROM " + Librealugtf + ".UGT01 WHERE T01IDT='UND' AND T01NU2=1) AS M ON SUBSTR(DIGITS(MPMUNI),2,2)=M.T01ESP", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }


        public DataTable getIngresoProductoACTUAL()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT MPICOD,MPMDES,MPIFNI,MPINNI,MPICAN,MPIIMP,MPINOC,MPIPRV,PRONOM,MPINFC,MPINGU, " +
" MPMCTA,MPMCCA,MPIPRO,MPMUNI,IFNULL(T01AL1,'') AS T01AL1,MPMSMX,MPMSMN,MPMSEM,MPMPRE,MPMSCO,MPMUBI " +
" FROM " + Librelalmingb + ".ALMVING LEFT OUTER JOIN " +
" " + Librelalmingb + ".ALMMMAP ON MPICOD=MPMCOD LEFT OUTER JOIN " +
" (SELECT T01ESP,T01AL1,T01AL2,T01NU2 FROM " + Librealugtf + ".UGT01 WHERE T01IDT='UND' AND T01NU2=1) AS M ON SUBSTR(DIGITS(MPMUNI),2,2)=M.T01ESP LEFT OUTER JOIN " +
" (SELECT PROCVE,PRONOM FROM " + Libreadamad2 + ".TPROV) AS P ON MPIPRV=PROCVE", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable getIngresoProductoPASADO(string mes)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT MPICOD,MPMDES,MPIFNI,MPINNI,MPICAN,MPIIMP,MPINOC,MPIPRV,PRONOM,MPINFC,MPINGU, " +
" MPMCTA,MPMCCA,MPIPRO,MPMUNI,IFNULL(T01AL1,'') AS T01AL1,MPMSMX,MPMSMN,MPMSEM,MPMPRE,MPMSCO,MPMUBI " +
" FROM H" + Librelalmingb + ".MRIN" + mes + " LEFT OUTER JOIN " +
" " + Librelalmingb + ".ALMMMAP ON MPICOD=MPMCOD LEFT OUTER JOIN " +
" (SELECT T01ESP,T01AL1,T01AL2,T01NU2 FROM " + Librealugtf + ".UGT01 WHERE T01IDT='UND' AND T01NU2=1) AS M ON SUBSTR(DIGITS(MPMUNI),2,2)=M.T01ESP LEFT OUTER JOIN " +
" (SELECT PROCVE,PRONOM FROM " + Libreadamad2 + ".TPROV) AS P ON MPIPRV=PROCVE", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }










        /*************************************************SELECT CONSULTA FERNANDO CORRALES****************************************************/
        /***********************************************************************************************/
        public DataTable getProductosMatrizTecnicos()
        {

            SqlDataAdapter da = new SqlDataAdapter("SELECT MPMCOD,MPMDES,MPMUNI,T01AL1,MPMSCO,MPMSDI,MPMCPR,MPMCDO,MPMUBI " +
            " FROM " + Librelalmingb + ".ALMMMAP LEFT OUTER JOIN " +
            " (SELECT T01ESP,T01AL1,T01AL2,T01NU2 FROM " + Librealugtf + ".UGT01 WHERE T01IDT='UND' AND T01NU2=1) " +
            " AS M ON SUBSTR(DIGITS(MPMUNI),2,2)=M.T01ESP " +
            " WHERE MPMSTT IN ('M','O')", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }
        public DataTable getDescripAdicionales(string CodProd)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM " + Libreadamad2 + ".TARDE WHERE ARTCOD='" + CodProd + "' FETCH " +
            " FIRST 6 ROWS ONLY", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable getProductosAlmacenIngenieriaRPG()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT " +
" MIMSTT,MIMUID,MIMUFE,MIMUHM,MIMCOD,MIMDES,MIDEA1,MIDEA2,MIDEA3,MIDEA4,MIDEA5, " +
" MIDEA6,MIMCTA, " +
" CASE WHEN MIMPRO=1 THEN 'Local' " +
" WHEN MIMPRO=2 THEN 'Local/Importado' " +
" WHEN MIMPRO=3 THEN 'Importado' " +
" ELSE 'Autoconsumo' END AS MIMPRO, " +
" MIMUNI,MIMSCO,MIMSDI,T01AL1 " + 
" FROM " + Librelalmingb + ".ALMWCON LEFT OUTER JOIN " +
" (SELECT T01ESP,T01AL1,T01AL2,T01NU2 FROM " + Librealugtf + ".UGT01 WHERE T01IDT='UND' AND T01NU2=1) AS M ON SUBSTR(DIGITS(MIMUNI),2,2)=M.T01ESP", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable getProductosAlmacenIngenieriaRPGVConsulta(string cuenta)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT " +
" MIMSTT,MIMUID,MIMUFE,MIMUHM,MIMCOD,MIMDES,MIDEA1,MIDEA2,MIDEA3,MIDEA4,MIDEA5, " +
" MIDEA6,MIMCTA, " +
" CASE WHEN MIMPRO=1 THEN 'Local' " +
" WHEN MIMPRO=2 THEN 'Local/Importado' " +
" WHEN MIMPRO=3 THEN 'Importado' " +
" ELSE 'Autoconsumo' END AS MIMPRO, " +
" MIMUNI,MIMSCO,MIMSDI,T01AL1 " +
" FROM " + Librelalmingb + ".ALMWCON LEFT OUTER JOIN " +
" (SELECT T01ESP,T01AL1,T01AL2,T01NU2 FROM " + Librealugtf + ".UGT01 WHERE" +
" T01IDT='UND' AND T01NU2=1) AS M ON SUBSTR(DIGITS(MIMUNI),2,2)=M.T01ESP WHERE MIMCTA IN (" + cuenta + ")", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }
        /************************************************************************************************/
        /*****************************TRANSACCIONES******************************************************/
        public DataTable getProductosRequerimiento(string cuenta)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT " +
" MPMCOD,MPMDES, " +
" RTRIM(T01AL1) AS T01AL1,MPMSCO,MPMSDI,MPMCPR, " +
" MPMCDO,MPMUBI,MPMCCA,MPMPRO,MPMCTA " +
" FROM " + Librelalmingb + ".ALMMMAP LEFT OUTER JOIN " +
" (SELECT T01ESP,T01AL1,T01AL2,T01NU2 FROM " + Librealugtf + ".UGT01 WHERE T01IDT='UND' AND T01NU2=1) AS M ON SUBSTRING(convert(varchar(6),MPMUNI),1,2)=M.T01ESP " +
" WHERE MPMSTT IN ('M','O') AND MPMCTA IN (" + cuenta + ")", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }


        public DataTable getProductosVALESSALIDA(decimal codTRAB)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT MPMCOD,MPMDES, " +
" TRIM(T01AL1) AS T01AL1,MPMSCO,MPMSDI,MPMCPR, " +
" MPMCDO,MPMUBI,MPMCCA,MPMPRO,MPMCTA " +
" FROM " + Librelalmingb + ".ALMHSAL LEFT OUTER JOIN " +
" " + Librelalmingb + ".ALMMMAP ON AISCOD=MPMCOD LEFT OUTER JOIN  " +
" (SELECT T01ESP,T01AL1,T01AL2,T01NU2 FROM " + Librealugtf + ".UGT01 WHERE T01IDT='UND' AND T01NU2=1) AS M ON SUBSTR(DIGITS(MPMUNI),2,2)=M.T01ESP " +
" WHERE MPMSTT IN ('M','O') AND AISCOR= " + codTRAB, cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }



        public DataTable getProductosRequerimientoXCodigo(string CodProd, string cuenta)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT " +
" MPMCOD,MPMDES, " +
" trim(T01AL1) AS T01AL1,MPMSCO,MPMSDI,MPMCPR, " +
" MPMCDO,MPMUBI,MPMCCA,MPMPRO,MPMCTA " +
" FROM " + Librelalmingb + ".ALMMMAP LEFT OUTER JOIN " +
" (SELECT T01ESP,T01AL1,T01AL2,T01NU2 FROM " + Librealugtf + ".UGT01 WHERE T01IDT='UND' AND T01NU2=1) AS M ON SUBSTR(DIGITS(MPMUNI),2,2)=M.T01ESP " +
" WHERE MPMSTT IN ('M','O') AND MPMCOD='" + CodProd + "' AND MPMCTA IN (" + cuenta + ")", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        
        /*Tablas para el proyecto de APROBACION DE REQUSICIONES INGENIERIA*/
        /// <summary>
        /// Recupera todas la requisiciones pendientes
        /// </summary>
        /// <returns></returns>
        public DataTable getRequsicionesAIvvv1111()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT trim(RQCCVE) as RQCCVE,trim(ARTCOD) as ARTCOD,RQCCAN,MPMSDI,IFNULL(MPWCAN,0) as MPWCAN,IFNULL(MPWROT,0) as MPWROT,IFNULL(MPWCOA,0) as MPWCOA, " +
" OCOCVE,RQCSID,TRIM(MPMDES) || '                          Unid.Med :   ' || TRIM(T01AL1) AS MPMDES,RQCFES,MPMSMX,MPMSMN FROM " + Libreadamad2 + ".TRQCDL32 LEFT OUTER JOIN " +
" " + Librelalmingb + ".ALMWUDE ON ARTCOD=MPWCOD LEFT OUTER JOIN " +
" " + Librelalmingb + ".ALMMMAP ON ARTCOD=MPMCOD LEFT OUTER JOIN " +
" (SELECT T01ESP,T01AL1,T01AL2,T01NU2 FROM " + Librealugtf + ".UGT01 WHERE T01IDT='UND' AND T01NU2=1) AS M ON SUBSTR(DIGITS(MPMUNI),2,2)=M.T01ESP " +
" WHERE MPMSTT IN ('M','O')", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable getRequsicionesAIVFINALITY()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT trim(RQCCVE) as RQCCVE,trim(ARTCOD) as ARTCOD,RQCCAN,MPMSDI,IFNULL(MPWCAN,0) as MPWCAN,IFNULL(MPWROT,0) as MPWROT,IFNULL(MPWCOA,0) as MPWCOA, " +
" OCOCVE,RQCSID,TRIM(MPMDES) || '                          Unid.Med :   ' || TRIM(T01AL1) AS MPMDES,RQCFES,MPMSMX,MPMSMN," +
" CASE WHEN MPDSTT='T' THEN 'X Aprobar' " +
" WHEN MPDSTT='A' THEN 'Aprobado' " +
" WHEN MPDSTT='R' THEN 'Rechazado' " +
" ELSE 'X Trabajar' END AS MPDSTT  " +
" FROM " + Libreadamad2 + ".TRQCDL32 LEFT OUTER JOIN " +
" " + Librelalmingb + ".ALMWUDE ON ARTCOD=MPWCOD LEFT OUTER JOIN " +
" " + Librelalmingb + ".ALMMMAP ON ARTCOD=MPMCOD LEFT OUTER JOIN " +
" (SELECT T01ESP,T01AL1,T01AL2,T01NU2 FROM " + Librealugtf + ".UGT01 WHERE T01IDT='UND' AND T01NU2=1) AS M ON SUBSTR(DIGITS(MPMUNI),2,2)=M.T01ESP LEFT OUTER JOIN " +
" " + Librelalmingb + ".ALMWDES ON (RQCCVE=MPDRQC AND ARTCOD=MPDCOD) " +
" WHERE MPMSTT IN ('M','O')", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }


        public DataTable getRequsicionesAI()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT trim(RQCCVE) as RQCCVE,trim(ARTCOD) as ARTCOD,RQCCAN,MPMSDI,IFNULL(MPWCAN,0) as MPWCAN,IFNULL(MPWROT,0) as MPWROT,IFNULL(MPWCOA,0) as MPWCOA, " +
" OCOCVE,RQCSID,TRIM(MPMDES) || '                          Unid.Med :   ' || TRIM(T01AL1) AS MPMDES,RQCFES,MPMSMX,MPMSMN,MPMSEM," +
" CASE WHEN MPDSTT='T' THEN 'X Aprobar' " +
" WHEN MPDSTT='A' THEN 'Aprobado' " +
" WHEN MPDSTT='R' THEN 'Rechazado' " +
" ELSE 'X Trabajar' END AS MPDSTT  " +
" FROM " + Libreadamad2 + ".TRQCDL32 LEFT OUTER JOIN " +
" " + Librelalmingb + ".ALMWUDE ON ARTCOD=MPWCOD LEFT OUTER JOIN " +
" " + Librelalmingb + ".ALMMMAP ON ARTCOD=MPMCOD LEFT OUTER JOIN " +
" (SELECT T01ESP,T01AL1,T01AL2,T01NU2 FROM " + Librealugtf + ".UGT01 WHERE T01IDT='UND' AND T01NU2=1) AS M ON SUBSTR(DIGITS(MPMUNI),2,2)=M.T01ESP LEFT OUTER JOIN " +
" " + Librelalmingb + ".ALMWDES ON (RQCCVE=MPDRQC AND ARTCOD=MPDCOD) " +
" WHERE MPMSTT IN ('M','O') AND IFNULL(MPDSTT,'')<>'T'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }


        public DataTable getRequsicionesAIVAPROBADAS()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT trim(RQCCVE) as RQCCVE,trim(ARTCOD) as ARTCOD,RQCCAN,MPMSDI,IFNULL(MPWCAN,0) as MPWCAN,IFNULL(MPWROT,0) as MPWROT,IFNULL(MPWCOA,0) as MPWCOA, " +
" OCOCVE,RQCSID,TRIM(MPMDES) || '                          Unid.Med :   ' || TRIM(T01AL1) AS MPMDES,RQCFES,MPMSMX,MPMSMN,MPMSEM," +
" CASE WHEN MPDSTT='T' THEN 'X Aprobar' " +
" ELSE 'X Trabajar' END AS MPDSTT  " +
" FROM " + Libreadamad2 + ".TRQCDL32 LEFT OUTER JOIN " +
" " + Librelalmingb + ".ALMWUDE ON ARTCOD=MPWCOD LEFT OUTER JOIN " +
" " + Librelalmingb + ".ALMMMAP ON ARTCOD=MPMCOD LEFT OUTER JOIN " +
" (SELECT T01ESP,T01AL1,T01AL2,T01NU2 FROM " + Librealugtf + ".UGT01 WHERE T01IDT='UND' AND T01NU2=1) AS M ON SUBSTR(DIGITS(MPMUNI),2,2)=M.T01ESP LEFT OUTER JOIN " +
" " + Librelalmingb + ".ALMWDES ON (RQCCVE=MPDRQC AND ARTCOD=MPDCOD) " +
" WHERE MPMSTT IN ('M','O') AND IFNULL(MPDSTT,'')='T'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }
        /// <summary>
        /// Tabla de consumos periodo de años
        /// </summary>
        /// <param name="prod">Producto relacionado con la busqueda de consumo</param>
        /// <returns></returns>
        public DataTable getTablaConsumos(string prod)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM " + Librelalmingb + ".ALMMCON WHERE MPCCOD='" + prod + "' ORDER BY " +
            " MPCACN DESC FETCH FIRST 5 ROW ONLY", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }
        /// <summary>
        /// Tabla de Ingresos periodo de años
        /// </summary>
        /// <param name="prod">producto relaciona con la busqueda de ingreso</param>
        /// <returns></returns>
        public DataTable getTablaIngresos(string prod)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM " + Librelalmingb + ".ALMMING WHERE MPECOD='" + prod + "' ORDER BY " +
            " MPEACN DESC FETCH FIRST 5 ROW ONLY", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }
        /// <summary>
        /// Captura de Años
        /// </summary>
        /// <param name="prod">parametro de producto para el año</param>
        /// <returns></returns>
        public DataTable getTablaAnos(string prod)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT DISTINCT(ANIO) FROM ( " +
" SELECT MPCACN AS ANIO FROM " + Librelalmingb + ".ALMMCON WHERE MPCCOD='" + prod + "' " +
" UNION ALL " +
" SELECT MPEACN AS ANIO FROM " + Librelalmingb + ".ALMMING WHERE MPECOD='" + prod + "' " +
" ) AS M ORDER BY ANIO DESC FETCH FIRST 5 ROW ONLY", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        /// <summary>
        /// Sacamos grupos y subgrupos
        /// </summary>
        /// <param name="prod">parametro de producto para el año</param>
        /// <returns></returns>
        public DataTable getTablaGruSubGru(string prod)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT AIGCOD,AIGDES,AISCOD,AISDES FROM " + Librelalmingb + ".AIGRUP AS N LEFT OUTER JOIN " +
" (SELECT AISCOD,AISDES FROM " + Librelalmingb + ".AISUBG) AS M ON DIGITS(N.AIGCOD)=SUBSTR(M.AISCOD,1,2) WHERE AISCOD = '" + prod + "'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        /// <summary>
        /// Consulta Ordenes de Compra
        /// </summary>
        /// <param name="prod">Producto</param>
        /// <returns></returns>
        public DataTable getTablaOrdenesCompra(string prod)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT OCOCVE, " +
" SUBSTR(OCOFEC,7,2)||'/'||SUBSTR(OCOFEC,5,2)||'/'||SUBSTR(OCOFEC,1,4) AS OCOFEC, " +
" OCOCAN,OCOPRU " +
" FROM " + Libreadamad2 + ".JOCOD WHERE ARTCOD='" + prod + "' ORDER BY OCOFEC DESC  FETCH FIRST 3 ROW ONLY", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }


        public DataTable getBuscaComent(string prod,string REQUI)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM  " + Librelalmingb + ".ALMWDES WHERE MPDCOD='" + prod + "' AND MPDRQC='" + REQUI + "'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }


        public int DInsertDescripcion(string Esta, string Usua, decimal Fech, decimal Hora, string Prod, string Requi, string Entr,string Comen,decimal CanMin,decimal PU,decimal CAN,decimal TOT)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                string sql = "INSERT INTO " + Librelalmingb + ".ALMWDES (MPDSTT, MPDUID, MPDUFE, MPDUHM, MPDCOD, MPDRQC, MPDENT, MPDCOM, MPDPMI, MPDPUN, MPDCAN, MPDTOT) " +
                             " VALUES ('" + Esta + "', '" + Usua + "', " + Fech + ", " + Hora + ", '" + Prod + "', '" + Requi + "', '" + Entr + "', '" + Comen + "', " + CanMin + ", " + PU + ", " + CAN + ", " + TOT + ")";
                cmd.CommandText = sql;
                cmd.Connection = cn.Conectar;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                i = 1;
                cmd.Dispose();
                cn.Conectar.Dispose();
                cn.Conectar.Close();
            }
            catch { throw; }
            return i;
        }

        public int DUpdateDescripcion(string Esta, string Usua, decimal Fech, decimal Hora, string Prod, string Requi)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                string sql = "UPDATE " + Librelalmingb + ".ALMWDES " +
                            " SET MPDSTT = '" + Esta + "' ,MPDUIA = '" + Usua + "' ,MPDUFA = " + Fech + " ,MPDUHA = " + Hora + " " +
                            " WHERE MPDCOD = '" + Prod + "' AND MPDRQC = '" + Requi + "'";
                cmd.CommandText = sql;
                cmd.Connection = cn.Conectar;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                i = 1;
                cmd.Dispose();
                cn.Conectar.Dispose();
                cn.Conectar.Close();
            }
            catch { throw; }
            return i;
        }

        public int DUpdateLIBRE(string SQL)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                string sql = SQL;
                cmd.CommandText = sql;
                cmd.Connection = cn.Conectar;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                i = 1;
                cmd.Dispose();
                cn.Conectar.Dispose();
                cn.Conectar.Close();
            }
            catch { throw; }
            return i;
        }




        /**CONSULTAS VARIAS REPORTES ABC - ASI COMO INGRESOS Y TRANSFERENCIA**/
        public DataTable getConsultaABC(string ANIO)
        {
            string SQL = "SELECT MPMCOD,MPMDES,MPMUNI, " +
" (SELECT T01AL1 FROM " + Librealugtf + ".UGT01 U WHERE U.T01IDT='UND' AND U.T01NU2=1 AND U.T01ESP=MPMUNI) AS DES_UNID, " +
" MPMSCO,MPMSDI,MPMCPR,MPMCDO,MPMABC,  IFNULL((SELECT RQCSID FROM " + Libreadamad2 + ".TRQCD WHERE ALMCVE = '4' AND ARTCOD=MPMCOD ORDER BY RQCFES DESC FETCH FIRST 1 ROW ONLY),'') AS ESTADO, " +
" IFNULL((SELECT RQCCMT FROM " + Libreadamad2 + ".TRQCD WHERE ALMCVE = '4' AND ARTCOD=MPMCOD ORDER BY RQCFES DESC FETCH FIRST 1 ROW ONLY),'') AS ORDEN, " +
" (SELECT TRIM(SUBSTR(MPTDES,0,30)) FROM " + Librelalmaceb + ".ALMTALM WHERE MPTTAB='PRO' AND MPTARG=MPMPRO) AS PROCEDENCIA, " +
" ifnull((SELECT MPKCII FROM H" + Librelalmingb + ".MRKA" + ANIO.Substring(2, 2) + "01 WHERE MPKCOD=MPMCOD),0) AS INV01,ifnull(MPEC01,0) AS ING1,ifnull(MPCC01,0) AS EGR1, " +
" ifnull((SELECT MPKCII FROM H" + Librelalmingb + ".MRKA" + ANIO.Substring(2, 2) + "02 WHERE MPKCOD=MPMCOD),0) AS INV02,ifnull(MPEC02,0) AS ING2,ifnull(MPCC02,0) AS EGR2, " +
" ifnull((SELECT MPKCII FROM H" + Librelalmingb + ".MRKA" + ANIO.Substring(2, 2) + "03 WHERE MPKCOD=MPMCOD),0) AS INV03,ifnull(MPEC03,0) AS ING3,ifnull(MPCC03,0) AS EGR3, " +
" ifnull((SELECT MPKCII FROM H" + Librelalmingb + ".MRKA" + ANIO.Substring(2, 2) + "04 WHERE MPKCOD=MPMCOD),0) AS INV04,ifnull(MPEC04,0) AS ING4,ifnull(MPCC04,0) AS EGR4, " +
" ifnull((SELECT MPKCII FROM H" + Librelalmingb + ".MRKA" + ANIO.Substring(2, 2) + "05 WHERE MPKCOD=MPMCOD),0) AS INV05,ifnull(MPEC05,0) AS ING5,ifnull(MPCC05,0) AS EGR5, " +
" ifnull((SELECT MPKCII FROM H" + Librelalmingb + ".MRKA" + ANIO.Substring(2, 2) + "06 WHERE MPKCOD=MPMCOD),0) AS INV06,ifnull(MPEC06,0) AS ING6,ifnull(MPCC06,0) AS EGR6, " +
" ifnull((SELECT MPKCII FROM H" + Librelalmingb + ".MRKA" + ANIO.Substring(2, 2) + "07 WHERE MPKCOD=MPMCOD),0) AS INV07,ifnull(MPEC07,0) AS ING7,ifnull(MPCC07,0) AS EGR7, " +
" ifnull((SELECT MPKCII FROM H" + Librelalmingb + ".MRKA" + ANIO.Substring(2, 2) + "08 WHERE MPKCOD=MPMCOD),0) AS INV08,ifnull(MPEC08,0) AS ING8,ifnull(MPCC08,0) AS EGR8, " +
" ifnull((SELECT MPKCII FROM H" + Librelalmingb + ".MRKA" + ANIO.Substring(2, 2) + "09 WHERE MPKCOD=MPMCOD),0) AS INV09,ifnull(MPEC09,0) AS ING9,ifnull(MPCC09,0) AS EGR9, " +
" ifnull((SELECT MPKCII FROM H" + Librelalmingb + ".MRKA" + ANIO.Substring(2, 2) + "10 WHERE MPKCOD=MPMCOD),0) AS INV10,ifnull(MPEC10,0) AS ING10,ifnull(MPCC10,0) AS EGR10,  " +
" ifnull((SELECT MPKCII FROM H" + Librelalmingb + ".MRKA" + ANIO.Substring(2, 2) + "11 WHERE MPKCOD=MPMCOD),0) AS INV11,ifnull(MPEC11,0) AS ING11,ifnull(MPCC11,0) AS EGR11,  " +
" ifnull((SELECT MPKCII FROM H" + Librelalmingb + ".MRKA" + ANIO.Substring(2, 2) + "12 WHERE MPKCOD=MPMCOD),0) AS INV12,ifnull(MPEC12,0) AS ING12,ifnull(MPCC12,0) AS EGR12  " +
" FROM " + Librelalmingb + ".ALMMMAP LEFT OUTER JOIN   (SELECT MPECOD,MPEC01,MPEC02,MPEC03,MPEC04,MPEC05,MPEC06,MPEC07,MPEC08,MPEC09,MPEC10,MPEC11,MPEC12 FROM " + Librelalmingb + ".ALMMING WHERE MPEACN=" + ANIO + ") AS I ON MPMCOD=I.MPECOD LEFT OUTER JOIN  (SELECT MPCCOD,MPCC01,MPCC02,MPCC03,MPCC04,MPCC05,MPCC06,MPCC07,MPCC08,MPCC09,MPCC10,MPCC11,MPCC12 FROM " + Librelalmingb + ".ALMMCON WHERE MPCACN=" + ANIO + ") AS C ON MPMCOD=C.MPCCOD";

            SqlDataAdapter da = new SqlDataAdapter(SQL, cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }



    }
}
