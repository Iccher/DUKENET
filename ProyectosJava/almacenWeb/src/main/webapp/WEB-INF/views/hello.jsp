<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>


<html>
<body>
	<h1>${message}</h1>	
	
	<br/><br/>
	<a href="#">Nuevo</a>
	
	<br/><br/>
	<table border="1">
	
	<tr>
		<td><b>Id</b></td>
		<td><b>Descripcion</b></td>
		<td><b>Cantidad</b></td>
		<td><b>Editar</b></td>
		<td><b>Eliminar</b></td>
	</tr>
	
	<c:forEach items="${productosLista}" var="producto">
		
		<tr>
			<td><c:out value="${producto.idProducto}"></c:out></td>
			<td><c:out value="${producto.descripcionProducto}"></c:out></td>
			<td><c:out value="${producto.cantidadProducto}"></c:out></td>
			<td> <a href="#">Editar</a> </td>
			<td> <a href="#">Eliminar</a> </td>
		</tr>

	</c:forEach>
	
	
	</table>
	
</body>
</html>