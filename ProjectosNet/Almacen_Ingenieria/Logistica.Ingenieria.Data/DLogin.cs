using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;

using System.Data.SqlClient;


namespace Logistica.Ingenieria.Data
{
    public class DLogin
    {

        /*cambiar Libreria*/
        /// <summary>
        /// Actualizacion de tablas del AS400 Principales
        /// </summary>
        string Librelalmingb = "dbo";/*Almacen de Ingenieria LALMINGB*/
        string Librelalmaceb = "dbo";/*Almacen de Ingenieria LALMACEB*/




        DConexion cn = new DConexion();



        public int DLogueaUsuarios(string user, string pass)
        {
            int i = 0;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT * FROM " + Librelalmingb + ".ALIUSERS WHERE CODUSE='" + user + "' AND CODPWD='" + pass + "'";
                cmd.Connection = cn.Conectar;
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.SingleResult);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        i = 1;
                    }
                }
                cmd.Dispose();
                cn.Conectar.Close();
            }
            catch { throw; }
            finally { cn.Conectar.Close(); }
            return i;
        }

        public DataTable DLogUsuaPC(string user, string pass)
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM " + Librelalmingb + ".ALIUSERS WHERE CODUSE='" + user + "' AND CODPWD='" + pass + "' AND ESTADO='A'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }

        public DataTable DConsultaUsuariosCorreo()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM " + Librelalmingb + ".ALIUSERS WHERE FILLER<>'' AND ESTADO='A'", cn.Conectar);
            DataTable tabla = new DataTable();
            da.Fill(tabla);
            return tabla;
        }
    }
}
