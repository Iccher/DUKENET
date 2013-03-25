package pe.com.alamcen.bean;

public class ProductoBean {

	public String descripcionProducto;
	public String idProducto;
	public int cantidadProducto;
	
	
	public ProductoBean(){};
	
	public ProductoBean(String descripcionProducto, String idProducto,
			int cantidadProducto) {
		super();
		this.descripcionProducto = descripcionProducto;
		this.idProducto = idProducto;
		this.cantidadProducto = cantidadProducto;
	}
	
	public String getDescripcionProducto() {
		return descripcionProducto;
	}
	public void setDescripcionProducto(String descripcionProducto) {
		this.descripcionProducto = descripcionProducto;
	}
	public String getIdProducto() {
		return idProducto;
	}
	public void setIdProducto(String idProducto) {
		this.idProducto = idProducto;
	}
	public int getCantidadProducto() {
		return cantidadProducto;
	}
	public void setCantidadProducto(int cantidadProducto) {
		this.cantidadProducto = cantidadProducto;
	}
	
	
}
