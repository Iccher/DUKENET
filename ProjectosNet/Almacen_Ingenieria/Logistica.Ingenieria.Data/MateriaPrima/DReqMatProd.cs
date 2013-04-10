using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using IBM.Data.DB2.iSeries;
using System.Data;
using Logistica.Ingenieria.Entity;

namespace Logistica.Ingenieria.Data
{
    public class DReqMatProd
    {
        iDB2Connection cn = new iDB2Connection("DataSource=LCAUCHO;User ID=lapdwebnet ; Password=licasa2005;");

        public List<EPrograma> LstPrograma(string fecha)
        {


            List<EPrograma> oLoc;

            try
            {
                oLoc = new List<EPrograma>();
                iDB2Command cmd = new iDB2Command();
                cmd.CommandText = "SELECT " +	 
		                            " I02PRODUCT AS CODIGO , " +
		                            " ( I31PROGT3 + I31SUPET3 ) + ( I31PROGT1 + I31SUPET1 ) + ( I31PROGT2 + I31SUPET2 ) AS PROG " +
	                                " FROM LFABRICAB . IPE02L02 " +
	                                " LEFT OUTER JOIN LFABRICAB . IPE31 " +
		                            " ON	( I31FECHA = '" + fecha + " ' AND " +
	                                " I31GRUPO = '24'	AND " +
		                            " I31PRODU = I02PRODUCT) " +
	                                " INNER JOIN LFABRICAB . RMATF69 " +
		                            " ON	RMAT69ANO = ( SELECT MAX ( F69 . RMAT69ANO ) FROM LFABRICAB . RMATF69 F69 ) AND " + 
		                            " RMAT69MES = ( SELECT MAX ( F69 . RMAT69MES ) FROM LFABRICAB . RMATF69 F69 " +
		                            " WHERE F69 . RMAT69ANO = ( SELECT MAX ( F69 . RMAT69ANO ) FROM LFABRICAB . RMATF69 F69))AND " +
		                            " RMAT69PRD = DECIMAL ( I02PRODUCT ) " +
		                            " WHERE ( I31PROGT3 + I31SUPET3 ) + ( I31PROGT1 + I31SUPET1 ) + ( I31PROGT2 + I31SUPET2 )>0 " +
	                                " UNION " +
	                                " SELECT " +
		                            " V86COA AS	CODIGO , " +
		                            " (I31PROGT3 + I31SUPET3 ) + ( I31PROGT1 + I31SUPET1 ) + ( I31PROGT2 + I31SUPET2 ) AS PROG " + 
	                                " FROM LVENTAB . VTM86 " +
	                                " INNER JOIN LFABRICAB . IPE02L02 " +
		                            " ON	DIGITS ( V86PRI ) = I02PRODUCT " +
	                                " INNER JOIN LFABRICAB . RMATF69 " +
		                            " ON	RMAT69ANO = ( SELECT MAX ( F69 . RMAT69ANO ) FROM LFABRICAB . RMATF69 F69 )	AND " +
		                            " RMAT69MES = ( SELECT MAX ( F69 . RMAT69MES ) FROM LFABRICAB . RMATF69 F69 " +
		                            " WHERE F69 . RMAT69ANO = ( SELECT MAX ( F69 . RMAT69ANO ) FROM LFABRICAB . RMATF69 F69 ) )	AND " +
		                            " RMAT69PRD = V86COA " +
	                                " LEFT JOIN LFABRICAB . IPE31 " + 
		                            " ON	I31FECHA = '"+fecha+"'	AND " +
		                            " I31GRUPO = '24'	AND " +
		                            " I31PRODU = DIGITS ( V86COA ) " +
	                                " WHERE ( I31PROGT3 + I31SUPET3 ) + ( I31PROGT1 + I31SUPET1 ) + ( I31PROGT2 + I31SUPET2 )>0 " +
                                    " ORDER BY	1";
                cmd.Connection = cn;
                cmd.Connection.Open();
                iDB2DataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                if (dr.HasRows)
                {
                    EPrograma ooc;
                    while (dr.Read())
                    {
                        ooc = new EPrograma();
                        ooc.Codigo = dr.GetString(dr.GetOrdinal("CODIGO"));
                        ooc.Prog = dr.GetString(dr.GetOrdinal("PROG"));
                        oLoc.Add(ooc);
                    }
                }
                cmd.Dispose();
                cn.Close();
            }
            catch
            {
                throw;
            }
            return oLoc;
        }

        

        public BindingList<EMateria> Descomposicion(string producto, string cantidad)
        {
            BindingList<EMateria> oLoc;

            try
            {
                oLoc = new BindingList<EMateria>();
                iDB2Command cmd = new iDB2Command();
                cmd.CommandText = "SELECT  IFNULL(I01PRODUCT,'') AS PRODUCTO , IFNULL(I04ELECOD,'') AS COD_MATERIA , IFNULL(T . ARTDES,'') DES_MATERIA , IFNULL(DEC ( I04ELEPES , 8 , 6 ),0) * "+cantidad+" AS PESO_NETO , " +
                                    " IFNULL(TRUNC ( ( I04ELEPES * 0.0144369 ) , 6 ),0) * "+cantidad+" AS PESO_MERMA , IFNULL(TRUNC ( ( I04ELEPES * 0.004424 ) , 6 ),0) * "+cantidad+" AS PESO_EXED , " +
	                                " (IFNULL(TRUNC ( TRUNC ( I04ELEPES , 6 ) + TRUNC ( ( I04ELEPES * 0.0144369 ) , 6 ) + TRUNC ( ( I04ELEPES * 0.004424 ) , 6 ) , 6 ),0)) * "+cantidad+" AS PESO_TOTAL , " +
                                    " IFNULL(( SELECT V86PRI FROM LVENTAB . VTM86 WHERE V86COA = INTEGER ( '" + producto + "' ) ),0) AS OTRO " +
	                                " FROM LFABRICAB . IPE01 INNER JOIN LFABRICAB . IPE04 ON I01PRODUCT = I04PRODUCT AND I01VERSION = I04VERSION " +
	                                " INNER JOIN ADAMAD2 . TARTI T ON I04ELECOD = T . ARTCOD " +
	                                " LEFT OUTER JOIN ADAMAD2 . TRLAA A ON I04ELECOD = A . ARTCOD " +
	                                " WHERE I01PRODUCT = '"+producto+"' AND I01ESTADO = 'N' AND I04ELETIP = '01' AND A . AGACVE = 'PRO' ORDER BY 2";
                cmd.Connection = cn;
                cmd.Connection.Open();
                iDB2DataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                if (dr.HasRows)
                {
                    EMateria ooc;
                    while (dr.Read())
                    {
                        ooc = new EMateria();
                        ooc.Cod_materia = dr.GetString(dr.GetOrdinal("COD_MATERIA"));
                        ooc.Des_materia = dr.GetString(dr.GetOrdinal("DES_MATERIA"));
                        ooc.Peso_neto = dr.GetString(dr.GetOrdinal("PESO_NETO"));
                        ooc.Peso_merma = dr.GetString(dr.GetOrdinal("PESO_MERMA"));
                        ooc.Peso_exed = dr.GetString(dr.GetOrdinal("PESO_EXED"));
                        ooc.Peso_total = dr.GetString(dr.GetOrdinal("PESO_TOTAL"));
                        oLoc.Add(ooc);
                    }
                }
                cmd.Dispose();
                cn.Close();
            }
            catch
            {
                throw;
            }
            return oLoc;
        }

        public List<EMateriaPrima> LstStockMP()
        {


            List<EMateriaPrima> oLoc;

            try
            {
                oLoc = new List<EMateriaPrima>();
                iDB2Command cmd = new iDB2Command();
                cmd.CommandText = "SELECT MPMCOD,mpmsdi,mpmcta,mpmpro FROM lalmaceb.almmmap";
                cmd.Connection = cn;
                cmd.Connection.Open();
                iDB2DataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                if (dr.HasRows)
                {
                    EMateriaPrima ooc;
                    while (dr.Read())
                    {
                        ooc = new EMateriaPrima();
                        ooc.Mpmcod = dr.GetString(dr.GetOrdinal("MPMCOD"));
                        ooc.Mpmsdi = dr.GetString(dr.GetOrdinal("mpmsdi"));
                        ooc.Mpmcta = dr.GetString(dr.GetOrdinal("mpmcta"));
                        ooc.Mpmpro = dr.GetString(dr.GetOrdinal("mpmpro"));
                        oLoc.Add(ooc);
                    }
                }
                cmd.Dispose();
                cn.Close();
            }
            catch
            {
                throw;
            }
            return oLoc;
        }

        public DataTable LstTrabajadores()
        {
            iDB2Command cmd = new iDB2Command();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT cast(r01cpe as varchar(20)) as r01cpe,r01nom FROM lripb.ripmgen WHERE r01fce<=0 ORDER BY 1";
            cmd.Connection = cn;
            iDB2DataAdapter da = new iDB2DataAdapter(cmd);
            DataTable ds = new DataTable();
            cmd.Connection.Open();
            da.Fill(ds);
            cn.Close();
            return ds;
        }


        public DataTable LstMP()
        {
            iDB2Command cmd = new iDB2Command();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT MPMCOD,mpmsdi,mpmcta,mpmpro,mpmdes FROM lalmaceb.almmmap";
            cmd.Connection = cn;
            iDB2DataAdapter da = new iDB2DataAdapter(cmd);
            DataTable ds = new DataTable();
            cmd.Connection.Open();
            da.Fill(ds);
            cn.Close();
            return ds;
        }

        public int insAlmvsal(string usuario,string fechaS,string hora,string nrovale,string nit,string fechaV,string turno,string autoriz,string solic,string materia,string procedencia,string cuenta,string cantidad)
        {
            try
            {
                iDB2Command cmd = new iDB2Command();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT INTO TEST1.ALMVSAL (MPSSTT, MPSUID, MPSUFE, MPSUHM, MPSNSA, MPSNIT, MPSTSA, " +
                        " MPSFSA, MPSTUR, MPSARE, MPSAUT, MPSSOL, MPSCOD, MPSCCA, MPSPRO, MPSCTA, MPSCAN, " +
                        " MPSIMP, MPSIMD, MPSOTR, MPSCOR, MPSTIP) " +
                        " VALUES ('S', '"+usuario+"', "+fechaS+", "+hora+", "+nrovale+", "+nit+", 1, "+fechaV+", "+turno+", 54110, "+autoriz+", "+solic+", '"+materia+"', " +
                        " 113, "+procedencia+", "+cuenta+", "+cantidad+", 0, 0, 0, 0, '')";
                cmd.Connection = cn;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch { return 2; }
            finally { cn.Close(); }
        }

        public List<EVale> LstValeNro()
        {


            List<EVale> oLoc;

            try
            {
                oLoc = new List<EVale>();
                iDB2Command cmd = new iDB2Command();
                cmd.CommandText = "SELECT mptdes FROM test1.almtalm WHERE MPTtab='NDO' AND MPTARG='2'";
                cmd.Connection = cn;
                cmd.Connection.Open();
                iDB2DataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                if (dr.HasRows)
                {
                    EVale ooc;
                    while (dr.Read())
                    {
                        ooc = new EVale();
                        ooc.Vale = dr.GetString(dr.GetOrdinal("mptdes"));
                        oLoc.Add(ooc);
                    }
                }
                cmd.Dispose();
                cn.Close();
            }
            catch
            {
                throw;
            }
            return oLoc;
        }


        public int updNroVale(string nro)
        {
            try
            {
                iDB2Command cmd = new iDB2Command();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "UPDATE test1.ALMTALM " +
                                    " SET MPTDES = '" + nro + "' " +
                                    " WHERE MPTtab='NDO' AND MPTARG='2'";
                cmd.Connection = cn;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch { return 2; }
            finally { cn.Close(); }
        }

        public int updStockMP(string cantidad,string codigo)
        {
            try
            {
                iDB2Command cmd = new iDB2Command();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "UPDATE TEST1.ALMMMAP " +
                                " SET MPMSDI = MPMSDI - "+cantidad+" ,MPMSCO=MPMSCO - "+cantidad+" " +
                                " WHERE MPMCOD = '"+codigo+"'";
                cmd.Connection = cn;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch { return 2; }
            finally { cn.Close(); }
        }

        public int insRegPed(string usuario,string fecha,string fecPed,string codigo,string cantidadR,string cantidadD,string tipo)
        {
            try
            {
                iDB2Command cmd = new iDB2Command();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT INTO LALMACEB.ALMVPED (MPSUID,MPSUFE,MPSFSA,MPSCOD,MPSCAR,MPSCAD,MPSTIP) " +
                                  " VALUES('"+usuario+"',"+fecha+","+fecPed+",'"+codigo+"',"+cantidadR+","+cantidadD+",'"+tipo+"')";
                cmd.Connection = cn;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch { return 2; }
            finally { cn.Close(); }
        }

        public List<EAlmvPed> LstRegPed(string fecha,string codigo,string tipo)
        {


            List<EAlmvPed> oLoc;

            try
            {
                oLoc = new List<EAlmvPed>();
                iDB2Command cmd = new iDB2Command();
                cmd.CommandText = "SELECT MPSUID,MPSUFE,MPSFSA,MPSCOD,MPSCAR,MPSCAD,MPSTIP FROM LALMACEB.ALMVPED " +
                                  " WHERE MPSFSA='" + fecha + "' AND MPSTIP='" + tipo + "' AND MPSCOD='"+ codigo +"'";
                cmd.Connection = cn;
                cmd.Connection.Open();
                iDB2DataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                if (dr.HasRows)
                {
                    EAlmvPed ooc;
                    while (dr.Read())
                    {
                        ooc = new EAlmvPed();
                        ooc.Mpsuid = dr.GetString(dr.GetOrdinal("MPSUID"));
                        ooc.Mpsufe = dr.GetString(dr.GetOrdinal("MPSUFE"));
                        ooc.Mpsfsa = dr.GetString(dr.GetOrdinal("MPSFSA"));
                        ooc.Mpscod = dr.GetString(dr.GetOrdinal("MPSCOD"));
                        ooc.Mpscar = dr.GetString(dr.GetOrdinal("MPSCAR"));
                        ooc.Mpscad = dr.GetString(dr.GetOrdinal("MPSCAD"));
                        ooc.Mpstip = dr.GetString(dr.GetOrdinal("MPSTIP"));
                        oLoc.Add(ooc);
                    }
                }
                cmd.Dispose();
                cn.Close();
            }
            catch
            {
                throw;
            }
            return oLoc;
        }

        public int insVmp02(string codigo,string saldo,string canreq,string candes,string dif)
        {
            try
            {
                iDB2Command cmd = new iDB2Command();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "INSERT INTO LALMACEB.VMP02 VALUES ('"+codigo+"',"+saldo+","+canreq+","+candes+","+dif+")";
                cmd.Connection = cn;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch { return 2; }
            finally { cn.Close(); }
        }

        public int updVmp02(string candes,string canreq,string codigo)
        {
            try
            {
                iDB2Command cmd = new iDB2Command();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "UPDATE LALMACEB.VMP02 " +
                                " SET VMPSAL = VMPSAL + "+candes+" " +
	                                " ,VMPREQ = "+canreq+" " +
	                                " ,VMPDES = "+candes+" " +
	                                " ,VMPDIF = "+candes+"-"+canreq+" " +
                                " WHERE VMPCOD = '"+codigo+"'";
                cmd.Connection = cn;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                return 1;
            }
            catch { return 2; }
            finally { cn.Close(); }
        }

        public DataTable LstVmp02(string codigo)
        {
            iDB2Command cmd = new iDB2Command();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM LALMACEB.VMP02 WHERE VMPCOD = '"+codigo+"'";
            cmd.Connection = cn;
            iDB2DataAdapter da = new iDB2DataAdapter(cmd);
            DataTable ds = new DataTable();
            cmd.Connection.Open();
            da.Fill(ds);
            cn.Close();
            return ds;
        }

        public List<EVmp02> LstVmp02A()
        {


            List<EVmp02> oLoc;

            try
            {
                oLoc = new List<EVmp02>();
                iDB2Command cmd = new iDB2Command();
                cmd.CommandText = "SELECT vmpcod,vmpdif FROM LALMACEB.VMP02";
                cmd.Connection = cn;
                cmd.Connection.Open();
                iDB2DataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult);
                if (dr.HasRows)
                {
                    EVmp02 ooc;
                    while (dr.Read())
                    {
                        ooc = new EVmp02();
                        ooc.Vmpcod = dr.GetString(dr.GetOrdinal("vmpcod"));
                        ooc.Vmpdif = dr.GetString(dr.GetOrdinal("vmpdif"));
                        oLoc.Add(ooc);
                    }
                }
                cmd.Dispose();
                cn.Close();
            }
            catch
            {
                throw;
            }
            return oLoc;
        }

        public List<EReporteVALE> DListarProforma(string nro_VALE)
        {
            string Sql;
            List<EReporteVALE> oVALES = new List<EReporteVALE>();
            try
            {
                oVALES = new List<EReporteVALE>();
                iDB2Command cmd = new iDB2Command();
                cmd.CommandType = System.Data.CommandType.Text;
                Sql = "SELECT " +
" MPSFSA AS FECHA_SALIDA, " +
 " MPSNSA AS NRO_SALIDA,  " +
 " ' ' AS ORDEN_TRABAJO, " +
 " ' ' AS AUTORIZACION_EJECUTIVA, " +
  " MPSARE AS COD_DPTO, " +
  " ' ' AS EMPLEADO_EN, " +
  " MPMCOD AS COD_PROD, " +
  " MPMDES AS DES_PROD, " +
  " M.T01AL1 AS UND_MED, " +
  " MPSCAN AS CANTIDAD,  " +
  " ' ' AS UBICACION, " +
  " A.R01CPE AS CODAUTO,A.R01NOM AS NOMAUTO, " +
  " S.R01CPE AS CODSOLI,S.R01NOM AS NOMSOLI, " +
  " 'Despachador' AS DESPACHADOR, " +
  " ' ' AS FECHA_SOL, " +
  " ' ' AS FECHA_AUT, " +
  " ' ' AS CODEMP, " +
  " ' ' AS NOM_REC, " +
  " ' ' AS FECHA_DES, " +
 " ' ' AS COD_RECIBIDO, " +
 " ' ' AS NOM_RECIBIDO " +
 " FROM TEST1.ALMVSAL T LEFT OUTER JOIN " +
 " LALMACEB.ALMMMAP ON (MPSCOD=MPMCOD) LEFT OUTER JOIN " +
 " (SELECT T01ESP,T01AL1,T01AL2,T01NU2 FROM LUGTF.UGT01 WHERE T01IDT='UND') AS M ON DIGITS(MPMUNI)=M.T01ESP " +
 " LEFT OUTER JOIN " +
 " (SELECT R01CPE,R01NOM FROM QS36F.RIPMGEN5) AS A ON (MPSAUT=A.R01CPE) LEFT OUTER JOIN " +
 " (SELECT R01CPE,R01NOM FROM QS36F.RIPMGEN5) AS S ON (MPSSOL=S.R01CPE) " +
 " WHERE MPMSTT IN ('M','O') AND MPSNSA="+nro_VALE+"";
                cmd.CommandText = Sql;
                cmd.Connection = cn;
                cmd.Connection.Open();
                iDB2DataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.SingleResult);
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
                cn.Close();
            }
            catch (Exception ex) { throw; }
            finally { cn.Close(); }
            return oVALES;
        }
    }
}
