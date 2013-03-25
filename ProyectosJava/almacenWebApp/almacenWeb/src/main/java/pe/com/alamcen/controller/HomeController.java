package pe.com.alamcen.controller;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Controller;
import org.springframework.ui.ModelMap;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

import pe.com.alamcen.servicie.ProductosService;


/**
 * Handles requests for the application home page.
 */
@Controller("/welcome")
public class HomeController {

	
	private ProductosService productoService = new ProductosService();
	private static final Logger logger = LoggerFactory
			.getLogger(HomeController.class);

	/**
	 * Simply selects the home view to render by returning its name.
	 */
	@RequestMapping(method = RequestMethod.GET)
	public String printWelcome(ModelMap model) {

		model.addAttribute("message", "Bienvenido al sistema de Almacen de LimaCaucho");
		
		model.addAttribute("productosLista", productoService.getProductos());
		
		return "hello";
		
	}

}
