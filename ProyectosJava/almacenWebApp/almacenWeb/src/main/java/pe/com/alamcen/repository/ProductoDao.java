package pe.com.alamcen.repository;

import java.util.ArrayList;

import pe.com.alamcen.bean.ProductoBean;

public class ProductoDao {

	/**
	 * @param args
	 */
	public ArrayList<ProductoBean> getProductos(){
		
		ArrayList<ProductoBean> lista = new ArrayList<ProductoBean>();
		
		
		lista.add(new ProductoBean("lapices mongol", "LM01", 50));
		lista.add(new ProductoBean("lapices Tecnico", "LM02", 50));
		lista.add(new ProductoBean("plumones", "LM03", 50));
		lista.add(new ProductoBean("hojas", "LM04", 50));
		lista.add(new ProductoBean("Hojas bond", "LM05", 50));
		lista.add(new ProductoBean("borrador", "LM06", 50));
		
		return lista;
		
	}

}
