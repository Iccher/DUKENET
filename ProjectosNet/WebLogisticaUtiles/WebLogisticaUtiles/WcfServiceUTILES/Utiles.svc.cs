using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

using System.Data;
using System.Data.SqlClient;


namespace WcfServiceUTILES
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    public class Utiles : IUtiles
    {
        SqlConnection cn = new SqlConnection("Data Source = .; Initial Catalog = WEBLOGISTICA; Integrated Security = SSPI;");

        public DataTable ListarArticulosUtiles(string SQL)
        {
            DataTable dtArticulos = new DataTable("Articulos");
            SqlDataAdapter da = new SqlDataAdapter(SQL, cn);
            da.Fill(dtArticulos);

            BasicHttpBinding binding = new BasicHttpBinding();
            // Use double the default value
            binding.MaxReceivedMessageSize = 65536 * 2;

            return dtArticulos;

        }
    }
}
