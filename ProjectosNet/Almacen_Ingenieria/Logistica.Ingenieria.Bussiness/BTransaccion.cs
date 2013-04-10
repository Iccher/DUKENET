using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Logistica.Ingenieria.Data;
using Logistica.Ingenieria.Entity;
using System.Data;

namespace Logistica.Ingenieria.Bussiness
{
    public class BTransaccion
    {
        DTransacciones objTran = new DTransacciones();
        public DataTable getCorrelativoReq(string HostPC)
        {
            return objTran.getCorrelativoReq(HostPC);
        }
        public int BUpdateCorrelativo(string Corr, string HostPC)
        {
            return objTran.DUpdateCorrelativo(Corr, HostPC);
        }
        public int BInsertCabReq(EReqCabecera eReqCab)
        {
            return objTran.DInsertCabReq(eReqCab);
        }

        public int BUpdateSQL(string sql)
        {
            return objTran.DUpdateSQL(sql);
        }

        public int BInsertDetReq(EReqDetalle eReqDet)
        {
            return objTran.DInsertDetReq(eReqDet);
        }

        public int BInsertDetReqAUDITADO(EReqDetalle eReqDet, string Obs,string usu)
        {
            return objTran.DInsertDetReqAUDITADO(eReqDet, Obs, usu);
        }

        public DataTable getConRequermientos(string situacion, string estado,string status)
        {
            return objTran.getConRequermientos(situacion, estado, status);
        }

        public DataTable getConRequermientosJFATURA(string situacion, string estado, string status,string SUPERV)
        {
            return objTran.getConRequermientosJFATURA(situacion, estado, status, SUPERV);
        }

        public DataTable getConRequermientosFORCONSULTA(string situacion, string estado, string status)
        {
            return objTran.getConRequermientosFORCONSULTA(situacion, estado, status);
        }

        public DataTable getConReqXAprAutomatico()
        {
            return objTran.getConReqXAprAutomatico();
        }

        public DataTable getConDetalleRequermientos()
        {
            return objTran.getConDetalleRequermientos();
        }

        public DataTable getConDetalleRequeXCodigo(string nroSal)
        {
            return objTran.getConDetalleRequeXCodigo(nroSal);
        }

        public DataTable getConReqArmadoSup(DataTable dtCentroCostos, DataTable dtEmpleados, string estado, string status, DataTable dtCentroCostosLaborales)
        {
            DataTable tblArmado = new DataTable();
            tblArmado.Columns.Add(new DataColumn("NROREQ", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("FECREQ", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("TURREQ", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("AREREQ", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("SOLREQ", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("ORDREQ", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("NROSAL", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("STATUS", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("ESTADO", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("DESSTA", typeof(string)));

            tblArmado.Columns.Add(new DataColumn("vCodTurno", typeof(decimal)));
            tblArmado.Columns.Add(new DataColumn("vCodArea", typeof(decimal)));
            tblArmado.Columns.Add(new DataColumn("vCodAutoriz", typeof(decimal)));
            tblArmado.Columns.Add(new DataColumn("vCodSolicitud", typeof(decimal)));

            tblArmado.Columns.Add(new DataColumn("vCodAutorizaSupervisor", typeof(decimal)));

            tblArmado.Columns.Add(new DataColumn("vCodOrdenTrabajo", typeof(decimal)));

            tblArmado.Columns.Add(new DataColumn("DESCRIPESTADO", typeof(string)));

            



            DataTable dtRequerimientos = new DataTable();
            
            dtRequerimientos = getConRequermientos("E", estado, status);

            DataView dvCentroCostos = new DataView();
            DataView dvEmpleado = new DataView();

            string turno = "";

            for (int i = 0; i <= dtRequerimientos.Rows.Count - 1; i++)
            {
                DataRow fila = tblArmado.NewRow();
                fila["NROREQ"] = dtRequerimientos.Rows[i]["A11NSA"].ToString().Trim();
                fila["FECREQ"] = dtRequerimientos.Rows[i]["A11FSA"].ToString().Substring(6, 2) + "/" + dtRequerimientos.Rows[i]["A11FSA"].ToString().Substring(4, 2) + "/" + dtRequerimientos.Rows[i]["A11FSA"].ToString().Substring(0, 4);
                switch (dtRequerimientos.Rows[i]["A11TUR"].ToString())
                {
                    case "1":
                        turno = "1er Turno";
                        break;
                    case "2":
                        turno = "2do Turno";
                        break;
                    case "3":
                        turno = "3er Turno";
                        break;
                }
                fila["TURREQ"] = turno;
                dvCentroCostos = new DataView(dtCentroCostosLaborales, "DATCVE = '" + dtRequerimientos.Rows[i]["A11ARE"] + "'", "", DataViewRowState.OriginalRows);     
                if (dvCentroCostos.Count > 0)
                {
                    fila["AREREQ"] = dvCentroCostos[0]["DATDES"].ToString().Trim();
                    fila["ORDREQ"] = "PEDIDOS SIN O/T (USO PERSONAL)";
                }
                else
                {
                    fila["AREREQ"] = "Are no Especificada";
                    fila["ORDREQ"] = "PEDIDOS SIN O/T (USO PERSONAL)";
                }

                



                string COD = dtRequerimientos.Rows[i]["A11SOL"].ToString();
                try
                {
                    dvEmpleado = new DataView(dtEmpleados, "CODIGO = " + dtRequerimientos.Rows[i]["A11SOL"] + "", "", DataViewRowState.OriginalRows);
                    fila["SOLREQ"] = dvEmpleado[0]["NOMBRE"].ToString().Trim();
                }
                catch { }


                fila["NROSAL"] = dtRequerimientos.Rows[i]["A11NSA"].ToString().Trim();
                fila["STATUS"] = dtRequerimientos.Rows[i]["A11STT"].ToString().Trim();
                fila["ESTADO"] = dtRequerimientos.Rows[i]["A11EST"].ToString().Trim();

                string Status = fila["STATUS"].ToString().Trim() + " - " + fila["ESTADO"].ToString().Trim();

                switch (Status.ToString())
                {
                    case "S - D":
                        fila["DESCRIPESTADO"] = "X Generar";
                        break;
                    case "J - D":
                        fila["DESCRIPESTADO"] = "X Generar";
                        break;
                    case "G - D":
                        fila["DESCRIPESTADO"] = "X Generar";
                        break;
                    case "S - SP":
                        fila["DESCRIPESTADO"] = "Generado Parcial";
                        break;
                    case "S - 1":
                        fila["DESCRIPESTADO"] = "x Firma Sup.";
                        break;
                    case "S - 2":
                        fila["DESCRIPESTADO"] = "x Firma Jef.";
                        break;
                    case "S - 3":
                        fila["DESCRIPESTADO"] = "x Firma Ger.";
                        break;
                    default :
                        fila["DESCRIPESTADO"] = "Generado Parcial";
                        break;
                    //case "D":
                    //    fila["DESCRIPESTADO"] = "";
                    //    break;
                    //case "D":
                    //    fila["DESCRIPESTADO"] = "por Generar";
                    //    break;
                    //default:
                    //    fila["DESCRIPESTADO"] = "Pend.Firma";
                    //    break;
                }

                switch (fila["STATUS"].ToString().Trim())
                {
                    case "S":
                        fila["DESSTA"] = "Activo";
                        break;
                    default:
                        fila["DESSTA"] = "Pend.Firma";
                        break;
                }

                fila["vCodTurno"] = Convert.ToDecimal(dtRequerimientos.Rows[i]["A11TUR"]);
                fila["vCodArea"] = Convert.ToDecimal(dtRequerimientos.Rows[i]["A11ARE"]);
                fila["vCodAutoriz"] = Convert.ToDecimal(dtRequerimientos.Rows[i]["A11AUT"]);
                fila["vCodSolicitud"] = Convert.ToDecimal(dtRequerimientos.Rows[i]["A11SOL"]);
                fila["vCodOrdenTrabajo"] = Convert.ToDecimal(dtRequerimientos.Rows[i]["A11OTR"]);


                fila["vCodAutorizaSupervisor"] = Convert.ToDecimal(dtRequerimientos.Rows[i]["A11CA1"]);




                tblArmado.Rows.Add(fila);
            }
            return tblArmado;
        }

        /*Actualizacion de tablas principales del AS400*/
        public DataTable getCorrelativoVALESALIDA()
        {
            return objTran.getCorrelativoVALESALIDA();
        }
        public int BUpdateCorrelativoVALESALIDA(string Corr)
        {
            return objTran.DUpdateCorrelativoVALESALIDA(Corr);
        }
        public int BInsertValeSalida(EValeSalida eValeSal)
        {
            return objTran.DInsertValeSalida(eValeSal);
        }
        public int BActStockALMMMAP(EValeSalida eValeSal)
        {
            return objTran.DActStockALMMMAP(eValeSal);
        }


        public DataTable getConReqArmadoSupFORCONSULTA(DataTable dtCentroCostos, DataTable dtEmpleados, string estado, string status)
        {
            DataTable tblArmado = new DataTable();
            tblArmado.Columns.Add(new DataColumn("NROREQ", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("FECREQ", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("TURREQ", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("AREREQ", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("SOLREQ", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("ORDREQ", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("NROSAL", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("STATUS", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("ESTADO", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("DESSTA", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("vCodTurno", typeof(decimal)));
            tblArmado.Columns.Add(new DataColumn("vCodArea", typeof(decimal)));
            tblArmado.Columns.Add(new DataColumn("vCodAutoriz", typeof(decimal)));
            tblArmado.Columns.Add(new DataColumn("vCodSolicitud", typeof(decimal)));
            tblArmado.Columns.Add(new DataColumn("vCodAutorizaSupervisor", typeof(decimal)));
            tblArmado.Columns.Add(new DataColumn("vCodOrdenTrabajo", typeof(decimal)));
            tblArmado.Columns.Add(new DataColumn("DESCRIPESTADO", typeof(string)));

            tblArmado.Columns.Add(new DataColumn("Recepcion", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("Supervisor", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("Jefe", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("Gerente", typeof(string)));

            DataTable dtRequerimientos = new DataTable();
            dtRequerimientos = getConRequermientos("E", estado, status);
            DataView dvCentroCostos = new DataView();
            DataView dvEmpleado = new DataView();

            string turno = "";

            for (int i = 0; i <= dtRequerimientos.Rows.Count - 1; i++)
            {
                DataRow fila = tblArmado.NewRow();
                fila["NROREQ"] = dtRequerimientos.Rows[i]["A11NSA"].ToString().Trim();
                fila["FECREQ"] = dtRequerimientos.Rows[i]["A11FSA"].ToString().Substring(6, 2) + "/" + dtRequerimientos.Rows[i]["A11FSA"].ToString().Substring(4, 2) + "/" + dtRequerimientos.Rows[i]["A11FSA"].ToString().Substring(0, 4);
                switch (dtRequerimientos.Rows[i]["A11TUR"].ToString())
                {
                    case "1":
                        turno = "1er Turno";
                        break;
                    case "2":
                        turno = "2do Turno";
                        break;
                    case "3":
                        turno = "3er Turno";
                        break;
                }
                fila["TURREQ"] = turno;
                dvCentroCostos = new DataView(dtCentroCostos, "ODTCOD = '" + dtRequerimientos.Rows[i]["A11OTR"] + "'", "", DataViewRowState.OriginalRows);
                if (dvCentroCostos.Count > 0)
                {
                    fila["AREREQ"] = dvCentroCostos[0]["T01AL1"].ToString().Trim();
                    fila["ORDREQ"] = dvCentroCostos[0]["ODTDES"].ToString();
                }
                else
                {
                    fila["AREREQ"] = "";
                    fila["ORDREQ"] = "";
                }
                dvEmpleado = new DataView(dtEmpleados, "CODIGO = " + dtRequerimientos.Rows[i]["A11SOL"] + "", "", DataViewRowState.OriginalRows);

                try
                {
                    fila["SOLREQ"] = dvEmpleado[0]["NOMBRE"].ToString().Trim();
                }
                catch { }

                fila["NROSAL"] = dtRequerimientos.Rows[i]["A11NSA"].ToString().Trim();
                fila["STATUS"] = dtRequerimientos.Rows[i]["A11STT"].ToString().Trim();
                fila["ESTADO"] = dtRequerimientos.Rows[i]["A11EST"].ToString().Trim();

                string Status = fila["STATUS"].ToString().Trim() + " - " + fila["ESTADO"].ToString().Trim();

                switch (Status.ToString())
                {
                    case "S - D":
                        fila["DESCRIPESTADO"] = "X Generar";
                        break;
                    case "J - D":
                        fila["DESCRIPESTADO"] = "X Generar";
                        break;
                    case "G - D":
                        fila["DESCRIPESTADO"] = "X Generar";
                        break;
                    case "S - SP":
                        fila["DESCRIPESTADO"] = "Generado Parcial";
                        break;
                    case "S - 1":
                        fila["DESCRIPESTADO"] = "x Firma Sup.";
                        break;
                    case "S - 2":
                        fila["DESCRIPESTADO"] = "x Firma Jef.";
                        break;
                    case "S - 3":
                        fila["DESCRIPESTADO"] = "x Firma Ger.";
                        break;
                    case "S - S":
                        fila["DESCRIPESTADO"] = "Generado";
                        break;
                }

                switch (fila["STATUS"].ToString().Trim())
                {
                    case "S":
                        fila["DESSTA"] = "Activo";
                        break;
                    default:
                        fila["DESSTA"] = "Pend.Firma";
                        break;
                }

                fila["vCodTurno"] = Convert.ToDecimal(dtRequerimientos.Rows[i]["A11TUR"]);
                fila["vCodArea"] = Convert.ToDecimal(dtRequerimientos.Rows[i]["A11ARE"]);
                fila["vCodAutoriz"] = Convert.ToDecimal(dtRequerimientos.Rows[i]["A11AUT"]);
                fila["vCodSolicitud"] = Convert.ToDecimal(dtRequerimientos.Rows[i]["A11SOL"]);
                fila["vCodOrdenTrabajo"] = Convert.ToDecimal(dtRequerimientos.Rows[i]["A11OTR"]);
                fila["vCodAutorizaSupervisor"] = Convert.ToDecimal(dtRequerimientos.Rows[i]["A11CA1"]);

                dvEmpleado = new DataView(dtEmpleados, "CODIGO = " + dtRequerimientos.Rows[i]["A11COR"] + "", "", DataViewRowState.OriginalRows);
                if (dvEmpleado.Count > 0) { fila["Recepcion"] = dvEmpleado[0]["NOMBRE"].ToString().Trim(); } else { fila["Recepcion"] = ""; }

                dvEmpleado = new DataView(dtEmpleados, "CODIGO = " + dtRequerimientos.Rows[i]["A11CA1"] + "", "", DataViewRowState.OriginalRows);
                if (dvEmpleado.Count > 0) { fila["Supervisor"] = dvEmpleado[0]["NOMBRE"].ToString().Trim(); } else { fila["Supervisor"] = ""; }

                dvEmpleado = new DataView(dtEmpleados, "CODIGO = " + dtRequerimientos.Rows[i]["A11CA2"] + "", "", DataViewRowState.OriginalRows);
                if (dvEmpleado.Count > 0) { fila["Jefe"] = dvEmpleado[0]["NOMBRE"].ToString().Trim(); } else { fila["Jefe"] = "AUTOMATICO"; }

                dvEmpleado = new DataView(dtEmpleados, "CODIGO = " + dtRequerimientos.Rows[i]["A11CA3"] + "", "", DataViewRowState.OriginalRows);
                if (dvEmpleado.Count > 0) { fila["Gerente"] = dvEmpleado[0]["NOMBRE"].ToString().Trim(); } else { fila["Gerente"] = "AUTOMATICO"; }

                tblArmado.Rows.Add(fila);
            }
            return tblArmado;
        }

        public DataTable getConReqArmadoJEFATURA(DataTable dtCentroCostos, DataTable dtEmpleados, string estado, string status,string SUPERV)
        {
            DataTable tblArmado = new DataTable();
            tblArmado.Columns.Add(new DataColumn("NROREQ", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("FECREQ", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("TURREQ", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("AREREQ", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("SOLREQ", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("ORDREQ", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("NROSAL", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("STATUS", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("ESTADO", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("DESSTA", typeof(string)));

            tblArmado.Columns.Add(new DataColumn("vCodTurno", typeof(decimal)));
            tblArmado.Columns.Add(new DataColumn("vCodArea", typeof(decimal)));
            tblArmado.Columns.Add(new DataColumn("vCodAutoriz", typeof(decimal)));
            tblArmado.Columns.Add(new DataColumn("vCodSolicitud", typeof(decimal)));

            tblArmado.Columns.Add(new DataColumn("vCodAutorizaSupervisor", typeof(decimal)));

            tblArmado.Columns.Add(new DataColumn("vCodOrdenTrabajo", typeof(decimal)));

            tblArmado.Columns.Add(new DataColumn("DESCRIPESTADO", typeof(string)));





            DataTable dtRequerimientos = new DataTable();

            dtRequerimientos = getConRequermientosJFATURA("E", estado, status, SUPERV);

            DataView dvCentroCostos = new DataView();
            DataView dvEmpleado = new DataView();

            string turno = "";

            for (int i = 0; i <= dtRequerimientos.Rows.Count - 1; i++)
            {
                DataRow fila = tblArmado.NewRow();
                fila["NROREQ"] = dtRequerimientos.Rows[i]["A11NSA"].ToString().Trim();
                fila["FECREQ"] = dtRequerimientos.Rows[i]["A11FSA"].ToString().Substring(6, 2) + "/" + dtRequerimientos.Rows[i]["A11FSA"].ToString().Substring(4, 2) + "/" + dtRequerimientos.Rows[i]["A11FSA"].ToString().Substring(0, 4);
                switch (dtRequerimientos.Rows[i]["A11TUR"].ToString())
                {
                    case "1":
                        turno = "1er Turno";
                        break;
                    case "2":
                        turno = "2do Turno";
                        break;
                    case "3":
                        turno = "3er Turno";
                        break;
                }
                fila["TURREQ"] = turno;
                dvCentroCostos = new DataView(dtCentroCostos, "ODTCOD = '" + dtRequerimientos.Rows[i]["A11OTR"] + "'", "", DataViewRowState.OriginalRows);
                if (dvCentroCostos.Count > 0)
                {
                    fila["AREREQ"] = dvCentroCostos[0]["T01AL1"].ToString().Trim();
                    fila["ORDREQ"] = dvCentroCostos[0]["ODTDES"].ToString();
                }
                else
                {
                    fila["AREREQ"] = "";
                    fila["ORDREQ"] = "";
                }
                dvEmpleado = new DataView(dtEmpleados, "CODIGO = " + dtRequerimientos.Rows[i]["A11SOL"] + "", "", DataViewRowState.OriginalRows);
                fila["SOLREQ"] = dvEmpleado[0]["NOMBRE"].ToString().Trim();
                fila["NROSAL"] = dtRequerimientos.Rows[i]["A11NSA"].ToString().Trim();
                fila["STATUS"] = dtRequerimientos.Rows[i]["A11STT"].ToString().Trim();
                fila["ESTADO"] = dtRequerimientos.Rows[i]["A11EST"].ToString().Trim();

                string Status = fila["STATUS"].ToString().Trim() + " - " + fila["ESTADO"].ToString().Trim();

                switch (Status.ToString())
                {
                    case "S - D":
                        fila["DESCRIPESTADO"] = "X Generar";
                        break;
                    case "J - D":
                        fila["DESCRIPESTADO"] = "X Generar";
                        break;
                    case "G - D":
                        fila["DESCRIPESTADO"] = "X Generar";
                        break;
                    case "S - SP":
                        fila["DESCRIPESTADO"] = "Generado Parcial";
                        break;
                    case "S - 1":
                        fila["DESCRIPESTADO"] = "x Firma Sup.";
                        break;
                    case "S - 2":
                        fila["DESCRIPESTADO"] = "x Firma Jef.";
                        break;
                    case "S - 3":
                        fila["DESCRIPESTADO"] = "x Firma Ger.";
                        break;

                    //case "D":
                    //    fila["DESCRIPESTADO"] = "";
                    //    break;
                    //case "D":
                    //    fila["DESCRIPESTADO"] = "por Generar";
                    //    break;
                    //default:
                    //    fila["DESCRIPESTADO"] = "Pend.Firma";
                    //    break;
                }


                switch (fila["STATUS"].ToString().Trim())
                {
                    case "S":
                        fila["DESSTA"] = "Activo";
                        break;
                    default:
                        fila["DESSTA"] = "Pend.Firma";
                        break;
                }

                fila["vCodTurno"] = Convert.ToDecimal(dtRequerimientos.Rows[i]["A11TUR"]);
                fila["vCodArea"] = Convert.ToDecimal(dtRequerimientos.Rows[i]["A11ARE"]);
                fila["vCodAutoriz"] = Convert.ToDecimal(dtRequerimientos.Rows[i]["A11AUT"]);
                fila["vCodSolicitud"] = Convert.ToDecimal(dtRequerimientos.Rows[i]["A11SOL"]);
                fila["vCodOrdenTrabajo"] = Convert.ToDecimal(dtRequerimientos.Rows[i]["A11OTR"]);


                fila["vCodAutorizaSupervisor"] = Convert.ToDecimal(dtRequerimientos.Rows[i]["A11CA1"]);




                tblArmado.Rows.Add(fila);
            }
            return tblArmado;
        }


    }
}
