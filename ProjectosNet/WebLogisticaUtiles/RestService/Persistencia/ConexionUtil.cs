using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestService.Persistencia
{
    public class ConexionUtil
    {
        public static string cadena
        {
            get
            {
                return "Data Source = .; Initial Catalog = WEBLOGISTICA; Integrated Security = SSPI;";
            }
        }
    }
}