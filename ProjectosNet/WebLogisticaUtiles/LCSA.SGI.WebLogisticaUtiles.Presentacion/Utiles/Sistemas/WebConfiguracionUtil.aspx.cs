﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using LCSA.SGI.WebLogisticaUtiles.Bussness;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using LCSA.SGI.WebLogisticaUtiles.Presentacion.Utiles.Sistemas;
using System.Collections.Generic;

namespace LCSA.SGI.WebLogisticaUtiles.Presentacion.Utiles.Sistema
{
    public partial class WebConfiguracionUtil : System.Web.UI.Page
    {
        BTablas objTablas = new BTablas();
        string SQL = "";
        DataTable dtUsuarios = new DataTable();

        DataSet dataSet = new DataSet();

        protected void Page_Load(object sender, EventArgs e)
        {
            SQL = "SELECT CODUSE,CODEMP,NOMEMP FROM ALIUSERS";
            objTablas = new BTablas();
            dtUsuarios = objTablas.Query(SQL);
            //dgvUsuarios.DataSource = dtUsuarios;
            //dgvUsuarios.DataBind();
            HttpWebRequest req = WebRequest.Create("http://localhost:51189/Mensajes.svc/ListarUsuarios") as HttpWebRequest;
            HttpWebResponse res = req.GetResponse() as HttpWebResponse;
            StreamReader reader = new StreamReader(res.GetResponseStream());
            string usuario1 = reader.ReadToEnd();
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Usuario> myNames = js.Deserialize<List<Usuario>>(usuario1);
            dgvUsuarios.DataSource = myNames;
            dgvUsuarios.DataBind();
        }

        


        protected void dgvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvUsuarios.PageIndex = e.NewPageIndex;
            SQL = "SELECT CODUSE,CODEMP,NOMEMP FROM ALIUSERS";
            objTablas = new BTablas();
            dtUsuarios = objTablas.Query(SQL);
            dgvUsuarios.DataSource = dtUsuarios;
            dgvUsuarios.DataBind();
        }

        protected void dgvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //switch (e.CommandName)
            //{
            //    case "Editar":
            //        ////Response.Write("AbrirDialogoModal('WebConfiguracionUtilFloat.aspx')");
            //        //ImageButton imgBoton = new ImageButton();
            //        //string expresion = String.Format("AbrirDialogoModal('WebConfiguracionUtilFloat.aspx');", "");                    
            //        //imgBoton.OnClientClick = expresion;                    
            //        break;
            //    case "Eliminar":
            //        break;
            //}
        }

        protected void dgvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    ////Para llamar al pagina de cambio de clave y pasar el usuario
            //    ImageButton imgBoton = ((ImageButton)e.Row.Cells[2].FindControl("ImageButton1"));
            //    string expresion = String.Format("AbrirDialogoModal('WebConfiguracionUtilFloat.aspx');", "");
            //    imgBoton.OnClientClick = expresion;
            //}
        }
    }
}
