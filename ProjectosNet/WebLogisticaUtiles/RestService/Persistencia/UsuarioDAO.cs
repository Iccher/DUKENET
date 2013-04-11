using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestService.Dominio;
using System.Data.SqlClient;

namespace RestService.Persistencia
{
    public class UsuarioDAO
    {
        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> oUsu = new List<Usuario>();
            Usuario usu;
            string sql = "SELECT CODEMP,NOMEMP FROM ALIUSERS";
            using (SqlConnection con = new SqlConnection(ConexionUtil.cadena))
            {
                con.Open();
                using (SqlCommand comm = new SqlCommand(sql, con))
                {
                    using (SqlDataReader resultado = comm.ExecuteReader())
                    {
                        
                        while (resultado.Read())
                        {
                            usu = new Usuario();
                            usu.Codigo = resultado.GetString(resultado.GetOrdinal("CODEMP")).Trim();
                            usu.Nombre = resultado.GetString(resultado.GetOrdinal("NOMEMP")).Trim();
                            oUsu.Add(usu);
                        }
                    }
                }
            }
            return oUsu;
        }




    }
}