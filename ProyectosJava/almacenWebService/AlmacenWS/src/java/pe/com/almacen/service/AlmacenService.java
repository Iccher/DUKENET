/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pe.com.almacen.service;

import java.util.ArrayList;
import pe.com.almacen.bean.Prod;
import pe.com.almacen.dao.AlmacenDao;
import pe.com.almacen.bean.ProductoBean;


/**
 *
 * @author Ronalc
 */
public class AlmacenService {
    
    private AlmacenDao dao = new AlmacenDao();
    
    public int solicitarProducto(String nombreUsuario,ArrayList<ProductoBean> productos){
        
        return dao.SolicitarProductos(nombreUsuario, productos);
    }
    
    public ArrayList<Prod> obtenerProductos(){
        
        return dao.getProducto(); 
        
    }
}
