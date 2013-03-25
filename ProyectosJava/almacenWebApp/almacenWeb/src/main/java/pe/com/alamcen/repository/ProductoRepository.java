package pe.com.alamcen.repository;

import org.springframework.data.repository.CrudRepository;
import pe.com.alamcen.bean.ProductoBean;

public interface  ProductoRepository extends CrudRepository<ProductoBean, Long>{
	
}
