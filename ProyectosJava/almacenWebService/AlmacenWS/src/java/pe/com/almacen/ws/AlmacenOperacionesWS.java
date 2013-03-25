/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pe.com.almacen.ws;

import java.util.ArrayList;
import javax.jws.WebService;
import javax.jws.WebMethod;
import javax.jws.WebParam;
import pe.com.almacen.bean.Prod;
import pe.com.almacen.bean.ProductoBean;
import pe.com.almacen.service.AlmacenService;
import pe.com.almacen.ws.response.SolicitarRroductosResp;

/**
 *
 * @author Ronalc
 */
@WebService(serviceName = "almacenOperacionesWS")
public class AlmacenOperacionesWS {

    private AlmacenService service = new AlmacenService();
    /**
     * This is a sample web service operation
     */
    @WebMethod(operationName = "solicitarProductos")
    public SolicitarRroductosResp hello(@WebParam(name = "nombreUsuario") String nombreUsuario, @WebParam(name = "productos") ArrayList<ProductoBean> productos ) {
        
        SolicitarRroductosResp response = new SolicitarRroductosResp();
        int codigoRespuesta = service.solicitarProducto(nombreUsuario, productos);
        
        response.setCodRetorno(codigoRespuesta);
        response.setMensajeRetorno("RespuestaExitosa");
        
        return response;
    }
    
    @WebMethod(operationName = "obtenerProdutos")
    public ArrayList<Prod> obtenerProductos(){ 
        return service.obtenerProductos();
        
    }
    
    
}
