/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package pe.com.almacen.ws.response;

import java.util.ArrayList;
import pe.com.almacen.bean.ProductoBean;

/**
 *
 * @author Ronalc
 */
public class SolicitarRroductosResp {
    
    private int codRetorno;
    private String mensajeRetorno;


    public int getCodRetorno() {
        return codRetorno;
    }

    public void setCodRetorno(int codRetorno) {
        this.codRetorno = codRetorno;
    }

    public String getMensajeRetorno() {
        return mensajeRetorno;
    }

    public void setMensajeRetorno(String mensajeRetorno) {
        this.mensajeRetorno = mensajeRetorno;
    }


}
