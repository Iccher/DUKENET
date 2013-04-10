using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

using Logistica.Ingenieria.Data;

namespace Logistica.Ingenieria.Bussiness
{
    public class BLogin
    {
        DLogin objDao = new DLogin();

        public int BLogueaUsuarios(string user, string pass)
        {
            return objDao.DLogueaUsuarios(user, pass);
        }

        public DataTable DLogUsuaPC(string user, string pass)
        {
            return objDao.DLogUsuaPC(user, pass);
        }

        public DataTable BConsultaUsuariosCorreo()
        {
            return objDao.DConsultaUsuariosCorreo();
        }
    }
}
