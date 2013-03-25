/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pe.com.almacen.dao;

import java.util.ArrayList;
import pe.com.almacen.bean.Prod;
import pe.com.almacen.bean.ProductoBean;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Ronalc
 */
public class AlmacenDao {

    public int SolicitarProductos(String usuario, ArrayList<ProductoBean> productos) {

        String _usuario = usuario;

        for (ProductoBean productoBean : productos) {

            productoBean.getIdProducto();
            productoBean.getCantidadProducto();

        }

        return 0;
    }

    public ArrayList<Prod> getProducto() {

        System.out.println("Ingreso a getProductoDAO");
        ArrayList<Prod> listaProd = new ArrayList<Prod>();


        try {
            listaProd = obtenerListaProductos();
        } catch (Exception ex) {
            Logger.getLogger(AlmacenDao.class.getName()).log(Level.SEVERE, null, ex);
        }
        return listaProd;
    }

    public ArrayList<Prod> obtenerListaProductos() throws Exception {

        ArrayList<Prod> listaProd = new ArrayList<Prod>();

        Prod p = new Prod();

        Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
        //colocar la dll sqljdbc_auth en system32 de la pc.

        try {
            System.gc();
            //System.loadLibrary("sqljdbc_auth");
        } catch (Exception e) {
            System.out.println("    --> Libreria ya cargada");
        }

        Connection con = DriverManager.getConnection(
                "jdbc:sqlserver://127.0.0.1:1433;"
                + "databaseName=WEBLOGISTICA; integratedSecurity=true");// repalce your databse name and user name

        Statement st = con.createStatement();
        ResultSet rs = st.executeQuery("SELECT "
                + "MPMCOD, "
                + "MPMDES, "
                + "LTRIM(RTRIM(T01AL1)) AS T01AL1, "
                + "MPMSCO, "
                + "MPMSDI, "
                + "MPMCPR, "
                + "MPMCDO, "
                + "MPMUBI, "
                + "MPMCCA, "
                + "MPMPRO, "
                + "MPMCTA "
                + "FROM ALMMMAP LEFT OUTER JOIN "
                + "(SELECT T01ESP,T01AL1,T01AL2,T01NU2 FROM UGT01 WHERE T01IDT='UND' AND T01NU2=1) AS M ON SUBSTRING(CONVERT(VARCHAR(3),MPMUNI),2,2)=M.T01ESP "
                + "WHERE MPMCTA IN (10,11,12,13) AND MPMSTT IN ('M','O')");// replace your
        // table name

        while (rs.next()) {
            p = new Prod();

            String MPMCOD = rs.getString(1);
            p.setMPMCOD(MPMCOD);
            String MPMDES = rs.getString(2);
            p.setMPMDES(MPMDES);
            String T01AL1 = rs.getString(3);
            p.setT01AL1(T01AL1);
            String MPMSCO = rs.getString(4);
            p.setMPMSCO(MPMSCO);
            String MPMSDI = rs.getString(5);
            p.setMPMSDI(MPMSDI);
            String MPMCPR = rs.getString(6);
            p.setMPMCPR(MPMCPR);
            String MPMCDO = rs.getString(7);
            p.setMPMCDO(MPMCDO);
            String MPMUBI = rs.getString(8);
            p.setMPMUBI(MPMUBI);
            String MPMCCA = rs.getString(9);
            p.setMPMCCA(MPMCCA);
            String MPMPRO = rs.getString(10);
            p.setMPMPRO(MPMPRO);
            String MPMCTA = rs.getString(11);
            p.setMPMCTA(MPMCTA);
            listaProd.add(p);
        }

        con.close();

        return listaProd;
    }

    /*public void demoConnection2() throws Exception {
		
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
     */
}
