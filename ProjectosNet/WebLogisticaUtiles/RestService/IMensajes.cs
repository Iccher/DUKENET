using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


using RestService.Dominio;
namespace RestService
{
    [ServiceContract]
    public interface IMensajes
    {

        [OperationContract]
        //[WebGet(ResponseFormat = WebMessageFormat.Json)]
        [WebGet]
        string ObtenerSaludo();


        [OperationContract]
        [WebInvoke(Method="GET",UriTemplate="ListarUsuarios", ResponseFormat = WebMessageFormat.Json)]
        List<Usuario> ListarUsuarios();
    }
}
