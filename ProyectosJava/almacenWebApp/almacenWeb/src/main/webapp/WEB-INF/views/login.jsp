<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core"%>
<html>
<head>
<title>Login Page</title>
<style>
.errorblock {
	color: #ff0000;
	background-color: #ffEEEE;
	border: 3px solid #ff0000;
	padding: 8px;
	margin: 16px;
}
</style>
</head>
<body onload='document.f.j_username.focus();'>
	
	<h3>Almacen LimaCaucho - Login </h3>

	<c:if test="${not empty error}">
		<div class="errorblock">
			Su acceso no fue exitoso, intente nuevamente.<br /> Causa :
			${sessionScope["SPRING_SECURITY_LAST_EXCEPTION"].message}
		</div>
	</c:if>

	<form name='f' action="<c:url value='j_spring_security_check' />"
		method='POST'>

		<table>
			<tr>
				<td>Usuario:</td>
				<td><input type='text' name='j_username' value=''></td>
			</tr>
			<tr>
				<td>Password:</td>
				<td><input type='password' name='j_password' /></td>
			</tr>
			<tr>
				<td colspan='2'><input name="submit" type="submit"
					value="submit" /></td>
			</tr>
			
		</table>

	</form>
</body>
</html>