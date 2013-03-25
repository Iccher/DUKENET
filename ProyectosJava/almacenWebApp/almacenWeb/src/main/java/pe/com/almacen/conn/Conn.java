package pe.com.almacen.conn;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;

public class Conn {

	public static void main(String args[]) throws Exception {
		
		Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
		
		//colocar la dll sqljdbc_auth en system32 de la pc.
		System.loadLibrary("sqljdbc_auth");
		
		Connection con = DriverManager.getConnection(
				"jdbc:sqlserver://127.0.0.1:1433;" + 
		"databaseName=WEBLOGISTICA; integratedSecurity=true");// repalce your databse name and user name
		
		Statement st = con.createStatement();
		ResultSet rs = st.executeQuery("Select * from ALIUSERS");// replace your
																// table name
		
		while (rs.next()) {
			String s1 = rs.getString(1);
			String s2 = rs.getString(2);
			
			System.out.println("UserID:" + s1 + "Password:" + s2);
			
		}
		
		con.close();
	}
}
