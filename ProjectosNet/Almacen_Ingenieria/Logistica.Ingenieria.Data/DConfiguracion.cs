using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.SqlClient;
using System.Data;

namespace Logistica.Ingenieria.Data
{
    public class DConfiguracion
    {
        DConexion cn = new DConexion();
        public DataTable getCargaUsuarios()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT CODUSE, CODPWD, CODEMP, RTRIM(NOMEMP) AS NOMEMP, FILLER FROM dbo.ALIUSERS WHERE ESTADO='A'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }
        public DataTable getCargaAutorizaciones()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM dbo.TAUTUING", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable getCargaCtaAlmacen()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT MPTARG,MPTDES FROM dbo.ALMTALM WHERE MPTTAB='CAI'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public int DInsertUsuario(string Use, string Pwd, string cod, string nom, string fil)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                string sql = "INSERT INTO dbo.ALIUSERS (ESTADO,CODUSE, CODPWD, CODEMP, NOMEMP, FILLER) " +
                " VALUES ('A','" + Use + "', '" + Pwd + "', '" + cod + "', '" + nom + "', '" + fil + "')";

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

        public int DUpdateUsuario(string Use, string Pwd, string cod, string nom,string fil)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                string sql = "UPDATE dbo.ALIUSERS SET " +
                    " CODPWD='" + Pwd + "',CODEMP='" + cod + "',NOMEMP='" + nom + "',FILLER='" + fil + "' " +
                " WHERE CODUSE='" + Use + "'";

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

        public int DDeleteUsuario(string Use)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                string sql = "UPDATE dbo.ALIUSERS SET ESTADO='E' WHERE CODUSE='" + Use + "'";

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


        /***TAUTU ALMACEN DE INGENIERIA***/
        public int DInsertAutor(string CODUSE, string NIVUSU, string CTAALM, string AREUSU)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                string sql = "INSERT INTO dbo.TAUTUING (CODUSE, NIVUSU, CTAALM, AREUSU) " +
                " VALUES ('" + CODUSE + "', '" + NIVUSU + "', '" + CTAALM + "', '" + AREUSU + "')";

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

        public int DDeleteAutor(string CODUSE)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;

                string sql = "DELETE FROM dbo.TAUTUING WHERE CODUSE = '" + CODUSE + "' AND AREUSU=''";

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


        public DataTable getCargaAutori()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT CODUSE,NIVUSU,CTAALM,AREUSU FROM dbo.TAUTUING WHERE AREUSU=''", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }


        /*carga opciones de cargado para el modulo*/

        ///*SELECT * FROM LVENTAB.CVTAF70;
        //SELECT * FROM LALMINGB.CINGF70;/*TABLA DE APLICATIVOS*/
        //SELECT * FROM LVENTAB.CVTAF71;
        //SELECT * FROM LALMINGB.CINGF71;/*TABLA DE OPCIONES*/
        //SELECT * FROM LALMINGB.ALIUSERS;
        //SELECT * FROM LVENTAB.CVTAF73;/*TABLA DE USUARIOS*/
        //SELECT * FROM LALMINGB.CINGF73;/*TABLA USUARIOS APLICATIVO*/
        //SELECT * FROM LALMINGB.ALIUSERS;
        //SELECT * FROM LALMINGB.TAUTUING;*/
        public DataTable getCargaOpcionesModulo()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM dbo.CINGF71 WHERE IDAPLI='RQAIG'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }
        public DataTable getCargaOpcionesModuloXUsuario()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM dbo.CINGF73 WHERE IDAPLI='RQAIG'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable getCargaOpcionesJEFExSUPERVISOR()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM dbo.CINGF74", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        /// <summary>
        /// CARGA EL CORREO PARA EL SUPERVISOR
        /// </summary>
        /// <returns></returns>
        public DataTable getCargaOpcionesSUPERVISORXSOLICITANTE(string codSOLIC)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT CODUSE,NOMEMP,FILLER,IDAPLI FROM dbo.CINGF74 LEFT OUTER JOIN dbo.ALIUSERS AS B ON (IDUSER=B.CODUSE) WHERE IDAPLI='" + codSOLIC + "'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }


        public int DInsertOpcionesxUsuario(string usuario,string opcion)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                string sql = "INSERT INTO dbo.CINGF73 (IDUSER, IDAPLI, IDOPCI) " +
                " VALUES ('" + usuario + "', 'RQAIG', '" + opcion + "')";
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
        public int DDeleteOpcionesxUsuario(string usuario)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                string sql = "DELETE FROM dbo.CINGF73 WHERE IDUSER='" + usuario + "' AND IDAPLI='RQAIG'";
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


        public int DInsertJEFATURAxSUPERVISOR(string usuario, string opcion)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                string sql = "INSERT INTO dbo.CINGF74 (IDUSER, IDAPLI) " +
                " VALUES ('" + usuario + "', '" + opcion + "')";
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
        public int DDeleteJEFATURAxSUPERVISOR(string usuario)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                string sql = "DELETE FROM dbo.CINGF74 WHERE IDUSER='" + usuario + "'";
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
