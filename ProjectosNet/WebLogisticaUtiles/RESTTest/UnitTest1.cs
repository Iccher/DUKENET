using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.IO;

namespace RESTTest
{
    [TestClass]
    public class MensajesTest
    {
        [TestMethod]
        public void ObtenerSaludoTest()
        {
            HttpWebRequest req = WebRequest.Create("http://localhost:51189/Mensajes.svc/ObtenerSaludo") as HttpWebRequest;
            HttpWebResponse res = req.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string saludo = reader.ReadToEnd();
            int hora = DateTime.Now.Hour;
            //if (hora < 12)
            //    Assert.AreEqual(saludo, "\"Buenos dias\"");
            //else if (hora < 19)
            //    Assert.AreEqual(saludo, "\"Buenos tardes\"");
            //else
            //    Assert.AreEqual(saludo, "\"Buenos noches\"");
        }
    }
}
