using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace RestService
{
    public class Mensajes : IMensajes
    {
        public string ObtenerSaludo()
        {
            var hora = DateTime.Now.Hour;
            if (hora < 12)
                return "Buenos Dias";
            else if (hora < 19)
                return "Buenas Tardes";
            else
                return "Buenas Noches";
        }
    }
}
