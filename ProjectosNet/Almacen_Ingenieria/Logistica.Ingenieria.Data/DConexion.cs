using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using cwbx;
using System.Configuration;

using System.Data.SqlClient;

namespace Logistica.Ingenieria.Data
{
    public class DConexion
    {
        private SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["Cn"].ConnectionString);
        public SqlConnection Conectar
        {
            get
            {
                return cn;
            }
        } 
    }
}
