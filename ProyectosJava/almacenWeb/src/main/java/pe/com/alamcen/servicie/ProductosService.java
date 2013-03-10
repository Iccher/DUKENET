package pe.com.alamcen.servicie;

import java.util.ArrayList;

import pe.com.alamcen.bean.ProductoBean;
import pe.com.alamcen.dao.ProductoDao;

public class ProductosService {

	
	private ProductoDao productoDao = new ProductoDao();
	/**
	 * @param args
	 */
	public ArrayList<ProductoBean> getProductos(){
		
		return productoDao.getProductos();
		
	}

}
