using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

using Logistica.Ingenieria.Entity;

namespace Logistica.Ingenieria.Data
{
    public class DTransacciones
    {
        DConexion cn = new DConexion();

        /// <summary>
        /// Trabajo sobre tablas nuevas 
        /// </summary>
        /// <returns></returns>
        /// 

        /*cambiar Libreria*/
        /// <summary>
        /// Actualizacion de tablas del AS400 Principales
        /// </summary>
        string Librelalmingb = "dbo";/*Almacen de Ingenieria LALMINGB*/
        string Librelalmaceb = "dbo";/*Almacen de Ingenieria LALMACEB*/

        public DataTable getCorrelativoReq(string HostPC)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT (MPTDES + 1) AS CORR FROM " + Librelalmingb + ".ALMTALMWEB WHERE MPTTAB='NDI' AND MPTARG='" + HostPC + "'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public int DUpdateCorrelativo(string Corr, string HostPC)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                string sql = "UPDATE " + Librelalmingb + ".ALMTALMWEB SET MPTDES='" + Corr + "' WHERE MPTTAB='NDI' AND MPTARG='" + HostPC + "'";
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

        public int DInsertCabReq(EReqCabecera eReqCab)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                string sql = "INSERT INTO " + Librelalmingb + ".ALI011UTIL ( " +
" A11STT, A11NSA, A11TSA, A11FSA, A11TUR, " +
" A11ARE, A11AUT, A11SOL, A11OTR, A11COR, " +
" A11TIP, A11IMS, A11IMD, A11UGE, A11UA1, " +
" A11UA2, A11UA3, A11FGE, A11FA1, A11FA2, " +
" A11FA3, A11UHM, A11EST, A11NVS, A11FVS, " +
" A11HVS, A11UDE, A11CGE, A11CA1, A11CA2, A11CA3) " +
" VALUES " +
" ('" + eReqCab.Situacion + "', '" + eReqCab.NroRequerimiento + "', " + eReqCab.TipoSalida + ", " + eReqCab.FechaSalida + ", " + eReqCab.Turno + ", " +
" " + eReqCab.Area + ", " + eReqCab.Autorizado + ", " + eReqCab.Solicitante + ", " + eReqCab.OrdenTrabajo + ", " + eReqCab.Recibido + ", " +
" '" + eReqCab.TipoAlmacen + "', " + eReqCab.ImpSoles + ", " + eReqCab.ImpDolares + ", '" + eReqCab.UserGenera + "', '" + eReqCab.UserAprueba1 + "', " +
" '" + eReqCab.UserAprueba2 + "', '" + eReqCab.UserAprueba3 + "', '" + eReqCab.FechaGenera + "', '" + eReqCab.FechaAprueba1 + "', '" + eReqCab.FechaAprueba2 + "', " +
" '" + eReqCab.FechaAprueba3 + "', " + eReqCab.HoraMinuto + ", '" + eReqCab.Estado + "', " + eReqCab.NroValeSalida + ", " + eReqCab.FechaValeSalida + ", " +
" " + eReqCab.HoraValeSalida + ", '" + eReqCab.UsuarioDespacha + "'," + eReqCab.CodUserGenera + "," + eReqCab.CodUserAprueba1 + "," + eReqCab.CodUserAprueba2 + "," + eReqCab.CodUserAprueba3 + ") ";

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


        public int DUpdateSQL(string sql)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
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

        public int DInsertDetReq(EReqDetalle eReqDet)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                string sql = "INSERT INTO " + Librelalmingb + ".ALI012UTIL " +
" (A12STT, A12NSA, A12NIT, A12COD, A12CCA, " +
" A12PRO, A12CTA, A12CAS, A12CAD, A12IMP, " +
" A12IMD, A12EST, A12NVS, A12FVS, A12HVS, A12UDE) " +
" VALUES " +
" ('" + eReqDet.Situacion + "', '" + eReqDet.NroReqSalida + "', " + eReqDet.NroItem + ", '" + eReqDet.CodMatPrima + "', " + eReqDet.CtaCargo + ", " +
" " + eReqDet.Procedencia + ", " + eReqDet.CtaAlmacen + ", " + eReqDet.CantidadSoli + ", " + eReqDet.CantidadAte + ", " + eReqDet.ImpSoles + ", " +
" " + eReqDet.ImpDolares + ", '" + eReqDet.Estado + "', " + eReqDet.NroValeSalida + ", " + eReqDet.FechaSalida + ", " + eReqDet.HoraSalida + ", '" + eReqDet.UserDespacha + "')";

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


        public int DInsertDetReqAUDITADO(EReqDetalle eReqDet, string Obs, string usu)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                string sql = "INSERT INTO " + Librelalmingb + ".ALI013UTIL " +
" (A13NSA, A13COD, " +
" A13CAD, A13NVS, A13FVS, A13UDE, A13OBS, A13EST,A13URE) " +
" VALUES " +
" ('" + eReqDet.NroReqSalida + "','" + eReqDet.CodMatPrima + "', " + eReqDet.CantidadAte + ", " + eReqDet.NroValeSalida + ", " + eReqDet.FechaSalida + ",'" + eReqDet.UserDespacha + "','" + Obs + "','R','" + usu + "')";

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

        /*CONSULTA PARA APROBACION*/
        public DataTable getConRequermientos(string situacion, string estado,string status)
        {
            string sql = " SELECT * FROM " + Librelalmingb + ".ALI011UTIL " +
            " WHERE (A11STT<>'" + situacion + "') AND (A11EST IN (" + estado + ") OR A11STT='" + status + "') ";



            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM " + Librelalmingb + ".ALI011UTIL " +
            " WHERE (A11STT<>'" + situacion + "') AND (A11EST IN (" + estado + ") OR A11STT='" + status + "')", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }


        public DataTable getConRequermientosJFATURA(string situacion, string estado, string status, string SUPERV)
        {
            string SQL11 = "SELECT * FROM " + Librelalmingb + ".ALI011UTIL " +
            " WHERE (A11STT<>'" + situacion + "') AND (A11EST IN (" + estado + ") OR A11STT='" + status + "') AND A11UA1 IN (" + SUPERV + ")";




            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM " + Librelalmingb + ".ALI011UTIL " +
            " WHERE (A11STT<>'" + situacion + "') AND (A11EST IN (" + estado + ") OR A11STT='" + status + "') AND A11UA1 IN (" + SUPERV + ")", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }


        public DataTable getConRequermientosFORCONSULTA(string situacion, string estado, string status)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT " +
"	A11STT,	A11NSA,	A11TSA,	A11FSA,	A11TUR,	A11ARE,	A11AUT,	A11SOL,	A11OTR,	A11COR,	A11TIP,	A11IMS,	A11IMD," +
"	A11CGE,	A11UGE,	A11CA1,	A11UA1,	A11CA2,	A11UA2,	A11CA3,	A11UA3,	A11FGE,	A11FA1,	A11UH1,	A11FA2,	A11UH2," +
"	A11FA3,	A11UH3,	A11UHM,	A11EST,	A11NVS,	A11FVS,	A11HVS,	A11UDE,	A11HAJ,	A11HAG, " +
"	IFNULL(S.R01NOM,'') AS NOM_RECIBIDO," +
"	IFNULL(SUP.R01NOM,'') AS SUPERVISOR," +
"	IFNULL(JEF.R01NOM,'AUTOMATICO') AS JEFE," +
"	IFNULL(GER.R01NOM,'AUTOMATICO') AS GERENTE" +
" FROM " + Librelalmingb + ".ALI011UTIL R LEFT OUTER JOIN" +
" lripb.ripmgen9 S ON R.A11COR=S.R01CPE LEFT OUTER JOIN" +
" lripb.ripmgen9 SUP ON R.A11CA1=SUP.R01CPE LEFT OUTER JOIN" +
" lripb.ripmgen9 JEF ON R.A11CA2=JEF.R01CPE LEFT OUTER JOIN" +
" lripb.ripmgen9 GER ON R.A11CA3=GER.R01CPE " +
            " WHERE (A11STT<>'" + situacion + "') AND (A11EST IN (" + estado + ") OR A11STT='" + status + "')", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable getConReqXAprAutomatico()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM " + Librelalmingb + ".ALI011UTIL WHERE A11STT='S' AND A11EST IN ('2','3')", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable getConDetalleRequermientos()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM " + Librelalmingb + ".ALI011UTIL LEFT OUTER JOIN " +
            " " + Librelalmingb + ".ALI012UTIL ON A11NSA=A12NSA " +
            " WHERE A11STT<>'E'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable getConDetalleRequeXCodigo(string nroSal)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT " +
" Rtrim(A12COD) as A12COD,Rtrim(MPMDES) as MPMDES,A12CAS,Rtrim(T01AL1) as T01AL1,A12CAD,A12IMP,A12IMD,A12PRO,A12CTA,A12CCA,MPMSCO,MPMSDI,MPMUBI,MPMCPR,MPMCDO " +
" FROM " + Librelalmingb + ".ALI012UTIL LEFT OUTER JOIN " +
" " + Librelalmingb + ".ALMMMAP ON (A12COD=MPMCOD AND A12CTA=MPMCTA AND A12PRO=MPMPRO AND A12CCA=MPMCCA) LEFT OUTER JOIN " +
" (SELECT T01ESP,T01AL1,T01AL2,T01NU2 FROM UGT01 WHERE T01IDT='UND' AND T01NU2=1) AS M ON SUBSTRING(CONVERT(VARCHAR(6),MPMUNI),1,2)=M.T01ESP " +
" WHERE MPMSTT IN ('M','O') AND A12NSA= '" + nroSal + "'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable getCorrelativoVALESALIDA()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT (MPTDES + 1) AS CORR  FROM " + Librelalmaceb + ".ALMTALM WHERE MPTTAB='NDI' AND MPTARG='2'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public int DUpdateCorrelativoVALESALIDA(string Corr)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                string sql = "UPDATE " + Librelalmaceb + ".ALMTALM SET MPTDES='" + Corr + "' WHERE MPTTAB='NDI' AND MPTARG='2'";
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

        public int DInsertValeSalida(EValeSalida eValeSal)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                string sql = "INSERT INTO " + Librelalmingb + ".ALMVSAL (MPSSTT, MPSUID, MPSUFE, MPSUHM, MPSNSA, MPSNIT, MPSTSA, MPSFSA, MPSTUR, MPSARE, MPSAUT, " +
" MPSSOL, MPSCOD, MPSCCA, MPSPRO, MPSCTA, MPSCAN, MPSIMP, MPSIMD, MPSOTR, MPSCOR, MPSTIP) " +
" VALUES ('" + eValeSal.Status + "','" + eValeSal.UserID + "'," + eValeSal.FechaModif + ", " +
" " + eValeSal.HoraMin + "," + eValeSal.NroVale + "," + eValeSal.Item + "," + eValeSal.TipoSalida + ", " +
" " + eValeSal.FechaSalidad + "," + eValeSal.Turno + "," + eValeSal.CodArea + "," + eValeSal.CodAutoriza + ", " +
" " + eValeSal.CodSolicita + ",'" + eValeSal.CodMateriaPrima + "'," + eValeSal.CtaCargo + "," + eValeSal.Procedencia + ", " +
" " + eValeSal.CtaAlmacen + "," + eValeSal.Cantidad + "," + eValeSal.ImporteS + "," + eValeSal.ImporteD + ", " +
" " + eValeSal.OrderTrabajo + "," + eValeSal.CodRecibe + ",'" + eValeSal.TipoAlmacen + "')";

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

        public int DActStockALMMMAP(EValeSalida eValeSal)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                string sql = "UPDATE " + Librelalmingb + ".ALMMMAP SET MPMSCO=MPMSCO - " + eValeSal.Cantidad + ",MPMSDI=MPMSDI - " + eValeSal.Cantidad + " WHERE MPMCOD='" + eValeSal.CodMateriaPrima + "'";

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

        


    }
}
