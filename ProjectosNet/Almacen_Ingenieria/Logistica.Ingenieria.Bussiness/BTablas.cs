using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Logistica.Ingenieria.Data;
using System.Data;
using Logistica.Ingenieria.Entity;

namespace Logistica.Ingenieria.Bussiness
{
    public class BTablas
    {
        DTablas oDatTab = new DTablas();
        DRPGs oDatRPG = new DRPGs();

        public int BPrograms()
        {
            return oDatRPG.DPrograms("LAPDCOV1", "C123456");
        }
        public DataTable tbldetalle = new DataTable();

        public DataTable getSELECTLIBRE(string SQL)
        {
            return oDatTab.getSELECTLIBRE(SQL);
        }
        public DataTable getCargaCORREOS()
        {
            return oDatTab.getCargaCORREOS();
        }
        public DataTable getCargaEmpleados()
        {
            return oDatTab.getCargaEmpleados();
        }
        public DataTable getCargaAreas()
        {
            return oDatTab.getCargaAreas();
        }
        public DataTable getCargaCentroCostos()
        {
            return oDatTab.getCargaCentroCostos();
        }
        public DataTable getCargaCentroCostosLABORALES()
        {
            return oDatTab.getCargaCentroCostosLABORALES();
        }
        public DataTable getCargaTipoSolicitud()
        {
            return oDatTab.getCargaTipoSolicitud();
        }
        public DataTable getCargaProductos()
        {
            return oDatTab.getCargaProductos();
        }

        public DataTable getCargaUND()
        {
            return oDatTab.getCargaUND();
        }

        public DataTable getCargaGRUPOS()
        {
            return oDatTab.getCargaGRUPOS();
        }

        public DataTable getCargaSUBGRUPOS()
        {
            return oDatTab.getCargaSUBGRUPOS();
        }

        public DataTable getUltimoValeSalida()
        {
            return oDatTab.getUltimoValeSalida();
        }


        public DataTable getCargaSubGRUPOSxAREA(decimal area)
        {
            return oDatTab.getCargaSubGRUPOSxAREA(area);
        }

        public DataTable getCargaRepuestosxSubGRUPOS(string cod)
        {
            return oDatTab.getCargaRepuestosxSubGRUPOS(cod);
        }

        public DataTable getCargaAPLICABILIDAD()
        {
            return oDatTab.getCargaAPLICABILIDAD();
        }

        public DataTable getCargaAPLICABILIDADxSubGRUPO(string SubGrupo)
        {
            return oDatTab.getCargaAPLICABILIDADxSubGRUPO(SubGrupo);
        }


        public DataTable getRepuestosAplicabilidad(DataTable dtRepuestos, DataTable dtAplicabilidad)
        {
            DataTable tbldetalle = new DataTable();
            DataView dvApli = new DataView();
            tbldetalle.Columns.Add(new DataColumn("Codigo", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("N_Parte", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("Cod_Und_Med", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("Unid_Med", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("Ubicacion", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("Precio", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("Descripcion_Tarde", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("Aplicabilidad", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("Cod_Aplicabilidad", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("Des_Aplicabilidad", typeof(string)));

            tbldetalle.Columns.Add(new DataColumn("Des_Mecanicos", typeof(string))); 

            for (int x = 0; x <= dtRepuestos.Rows.Count - 1; x++)
            {
                DataRow fila = tbldetalle.NewRow();
                fila["Codigo"] = dtRepuestos.Rows[x][0].ToString().Trim();
                fila["Descripcion"] = dtRepuestos.Rows[x][1].ToString().Trim();
                fila["N_Parte"] = dtRepuestos.Rows[x][2].ToString().Trim();
                fila["Cod_Und_Med"] = dtRepuestos.Rows[x][3].ToString().Trim();
                fila["Unid_Med"] = dtRepuestos.Rows[x][4].ToString().Trim();
                fila["Ubicacion"] = dtRepuestos.Rows[x][5].ToString().Trim();
                fila["Precio"] = dtRepuestos.Rows[x]["PRECIO"].ToString().Trim();
                fila["Descripcion_Tarde"] = dtRepuestos.Rows[x][6].ToString().Trim();
                fila["Aplicabilidad"] = dtRepuestos.Rows[x][7].ToString().Trim();
                dvApli = new DataView(dtAplicabilidad, "APLI =" + Convert.ToDecimal(dtRepuestos.Rows[x][7].ToString()), "", DataViewRowState.OriginalRows);
                if (dvApli.Count == 0) { fila["Cod_Aplicabilidad"] = ""; fila["Des_Aplicabilidad"] = ""; }
                else { fila["Cod_Aplicabilidad"] = dvApli[0]["AITCOD"].ToString().Trim(); fila["Des_Aplicabilidad"] = dvApli[0]["AITDES"].ToString().Trim(); }

                fila["Des_Mecanicos"] = dtRepuestos.Rows[x][8].ToString().Trim();

                tbldetalle.Rows.Add(fila);
            }
            return tbldetalle;
        }

        public DataTable getDescriAdicionalMECANICOS(string Cod)
        {
            return oDatTab.getDescriAdicionalMECANICOS(Cod);
        }

        public int BInsertDescriAdicionalMECANICOS(string User, decimal Fecha, decimal Hora, string Cod, string des)
        {
            return oDatTab.DInsertDescriAdicionalMECANICOS(User, Fecha, Hora, Cod, des);
        }



        public DataTable getArmado(DataTable dtEmpleados, DataTable dtArea, DateTime mes1, DateTime mes2)
        {
            tbldetalle.Columns.Add(new DataColumn("VALE", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("CODAUTORIZA", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("AUTORIZA", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("CODSOLIC", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("SOLIC", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("CODAREA", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("AREA", typeof(string)));
            DataTable dt1 = new DataTable();
            DataView dv = new DataView();
            string codArea = "";
            string desArea = "";
            string codTrab = "";
            string nomTrab = "";
            string codTrab1 = "";
            string nomTrab1 = "";
            int numDias = CalcularMeses(mes1, mes2);
            for (int i = 1; i <= numDias; i++)
            {
                string mes = "";
                DateTime mesxx = mes1.AddMonths(+i - 1);
                string dtnow = "";

                if (mesxx.Month <= 9)
                {
                    mes = mesxx.Year.ToString().Substring(2, 2) + "0" + mesxx.Month.ToString();
                }
                else
                {
                    mes = mesxx.Year.ToString().Substring(2, 2) + mesxx.Month.ToString();
                }
                if (DateTime.Now.Month <= 9)
                {
                    dtnow = DateTime.Now.Year.ToString().Substring(2, 2) + "0" + DateTime.Now.Month.ToString();
                }
                else
                {
                    dtnow = DateTime.Now.Year.ToString().Substring(2, 2) + DateTime.Now.Month.ToString();
                }

                if (mes == dtnow)
                {
                    dt1 = oDatTab.getArmadoSalidasACTUAL(mes);
                }
                else
                {
                    dt1 = oDatTab.getArmadoSalidas(mes);
                }   

                for (int x = 0; x <= dt1.Rows.Count - 1; x++)
                {
                    /*****************************solicita**********************************/
                    codTrab = dt1.Rows[x][2].ToString();
                    dv = new DataView(dtEmpleados, "CODIGO = '" + codTrab + "' ", "", DataViewRowState.OriginalRows);
                    if (dv.Count > 0) { nomTrab = dv[0][1].ToString().Trim(); } else { nomTrab = ""; }
                    /******************************Area**************************************/
                    codArea = dt1.Rows[x][3].ToString();
                    dv = new DataView(dtArea, "T01ESP = '" + codArea + "' ", "", DataViewRowState.OriginalRows);
                    if (dv.Count > 0) { desArea = dv[0][1].ToString().Trim(); } else { desArea = ""; }
                    /*Autoriza*/
                    codTrab1 = dt1.Rows[x][1].ToString();
                    dv = new DataView(dtEmpleados, "CODIGO = '" + codTrab1 + "' ", "", DataViewRowState.OriginalRows);
                    if (dv.Count > 0) { nomTrab1 = dv[0][1].ToString().Trim(); } else { nomTrab1 = ""; }
                    /*************************************************************************************************/
                    DataRow fila = tbldetalle.NewRow();
                    fila[0] = dt1.Rows[x][0].ToString();
                    fila[1] = codTrab1;
                    fila[2] = nomTrab1;
                    fila[3] = codTrab;
                    fila[4] = nomTrab;
                    fila[5] = codArea;
                    fila[6] = desArea;
                    tbldetalle.Rows.Add(fila);
                }
            }
            return tbldetalle;
        }



        public static int CalcularMeses(DateTime fechaComienzo, DateTime fechaFin)
        {
            fechaComienzo = fechaComienzo.Date;
            fechaFin = fechaFin.Date;
            int count = 0;
            while (fechaComienzo < fechaFin)
            {
                fechaComienzo = fechaComienzo.AddMonths(1);
                count++;
            }
            return count;
        }

        public DataTable getArmadoSalidasXProducto(string mes,decimal vale)
        {
            tbldetalle.Columns.Add(new DataColumn("VALE", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("FECHA", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("CODIGO", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("DESCRIP", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("CODUNI", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("DESUNI", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("UBICAC", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("CTACAR", typeof(string)));

            DataTable dt1 = new DataTable();

            string dtnow = ""; 
            if (DateTime.Now.Month <= 9)
            {
                dtnow = DateTime.Now.Year.ToString().Substring(2, 2) + "0" + DateTime.Now.Month.ToString();
            }
            else
            {
                dtnow = DateTime.Now.Year.ToString().Substring(2, 2) + DateTime.Now.Month.ToString();
            }

            if (mes == dtnow)
            {
                dt1 = oDatTab.getArmadoSalidasXProductoACTUAL(vale);               
            }
            else
            {
                dt1 = oDatTab.getArmadoSalidasXProductoPASADO(mes, vale);
            }



            for (int x = 0; x <= dt1.Rows.Count - 1; x++)
            {
                DataRow fila = tbldetalle.NewRow();
                fila[0] = dt1.Rows[x][0].ToString();
                fila[1] = dt1.Rows[x][1].ToString();
                fila[2] = dt1.Rows[x][2].ToString();
                fila[3] = dt1.Rows[x][3].ToString();
                fila[4] = dt1.Rows[x][4].ToString();
                fila[5] = dt1.Rows[x][5].ToString();
                fila[6] = dt1.Rows[x][6].ToString();
                fila[7] = dt1.Rows[x][7].ToString();
                tbldetalle.Rows.Add(fila);
            }

            return tbldetalle;
        }

        /*Consulta Consumos Almacen de ingenieria*/

        public DataTable getConsultaConsumos(DataTable dtEmpleados, DataTable dtArea,DataTable dtOrdenTrab, DateTime mes1, DateTime mes2)
        {
            tbldetalle.Columns.Add(new DataColumn("MPSCOD", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPMDES", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPSFSA", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPSNSA", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPSCAN", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("MPSIMP", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("MPSARE", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("DESAREA", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPSCOR", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("NOMTRAB1", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPSSOL", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("NOMTRAB2", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPMCTA", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPMCCA", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPSPRO", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPMUNI", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("T01AL1", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPMSMX", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPMSMN", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPMSEM", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPMPRE", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPMSCO", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPMUBI", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPSOTR", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("DESOTR", typeof(string)));

            DataTable dt1 = new DataTable();
            DataView dv = new DataView();

            string MPSCOD = ""; string MPMDES = ""; string MPSFSA = ""; string MPSNSA = ""; decimal MPSCAN = 0; decimal MPSIMP = 0;
            string MPSARE = ""; string MPSCOR = ""; string MPSSOL = ""; string MPMCTA = ""; string MPMCCA = ""; string MPSPRO = "";
            string MPMUNI = ""; string T01AL1 = ""; string MPMSMX = ""; string MPMSMN = ""; string MPMSEM = ""; string MPMPRE = "";
            string MPMSCO = ""; string MPMUBI = ""; string MPSOTR = "";

            string DESAREA = ""; string NOMTRAB1 = ""; string NOMTRAB2 = ""; string DESOTR = "";

            int numDias = CalcularMeses(mes1, mes2);
            for (int i = 1; i <= numDias; i++)
            {
                string mes = ""; DateTime mesxx = mes1.AddMonths(+i - 1); string dtnow = "";
                if (mesxx.Month <= 9){mes = mesxx.Year.ToString().Substring(2, 2) + "0" + mesxx.Month.ToString();}
                else{mes = mesxx.Year.ToString().Substring(2, 2) + mesxx.Month.ToString();}
                if (DateTime.Now.Month <= 9){dtnow = DateTime.Now.Year.ToString().Substring(2, 2) + "0" + DateTime.Now.Month.ToString();}
                else{dtnow = DateTime.Now.Year.ToString().Substring(2, 2) + DateTime.Now.Month.ToString();}
                if (mes == dtnow){dt1 = oDatTab.getSalidasProductoACTUAL();}
                else {dt1 = oDatTab.getSalidasProductoPASADO(mes);}
                for (int x = 0; x <= dt1.Rows.Count - 1; x++)
                {
                    MPSCOD = dt1.Rows[x][0].ToString().Trim();
                    MPMDES = dt1.Rows[x][1].ToString().Trim();
                    MPSFSA = dt1.Rows[x][2].ToString().Trim();
                    MPSNSA = dt1.Rows[x][3].ToString().Trim();
                    MPSCAN = Convert.ToDecimal(dt1.Rows[x][4].ToString());
                    MPSIMP = Convert.ToDecimal(dt1.Rows[x][5].ToString());
                    MPSARE = dt1.Rows[x][6].ToString().Trim();
                    MPSCOR = dt1.Rows[x][7].ToString().Trim();
                    MPSSOL = dt1.Rows[x][8].ToString().Trim();
                    MPMCTA = dt1.Rows[x][9].ToString().Trim();
                    MPMCCA = dt1.Rows[x][10].ToString().Trim();
                    MPSPRO = dt1.Rows[x][11].ToString().Trim();
                    MPMUNI = dt1.Rows[x][12].ToString().Trim();
                    T01AL1 = dt1.Rows[x][13].ToString().Trim();
                    MPMSMX = dt1.Rows[x][14].ToString().Trim();
                    MPMSMN = dt1.Rows[x][15].ToString().Trim();
                    MPMSEM = dt1.Rows[x][16].ToString().Trim();
                    MPMPRE = dt1.Rows[x][17].ToString().Trim();
                    MPMSCO = dt1.Rows[x][18].ToString().Trim();
                    MPMUBI = dt1.Rows[x][19].ToString().Trim();
                    MPSOTR = dt1.Rows[x][20].ToString().Trim();
                    /******************************Area**************************************/
                    dv = new DataView(dtArea, "T01ESP = '" + MPSARE + "' ", "", DataViewRowState.OriginalRows);
                    if (dv.Count > 0) { DESAREA = dv[0][1].ToString().Trim(); } else { DESAREA = ""; }
                    /*****************************solicita**********************************/
                    dv = new DataView(dtEmpleados, "CODIGO = '" + MPSCOR + "' ", "", DataViewRowState.OriginalRows);
                    if (dv.Count > 0) { NOMTRAB1 = dv[0][1].ToString().Trim(); } else { NOMTRAB1 = ""; }
                    /*****************************solicita**********************************/
                    dv = new DataView(dtEmpleados, "CODIGO = '" + MPSSOL + "' ", "", DataViewRowState.OriginalRows);
                    if (dv.Count > 0) { NOMTRAB2 = dv[0][1].ToString().Trim(); } else { NOMTRAB2 = ""; }
                    /*****************************Orden Trabajo**********************************/
                    dv = new DataView(dtOrdenTrab, "ODTCOD = '" + MPSOTR + "' ", "", DataViewRowState.OriginalRows);
                    if (dv.Count > 0) { DESOTR = dv[0][3].ToString().Trim(); } else { DESOTR = ""; }
                    /**************************************************************************************************/
                    DataRow fila = tbldetalle.NewRow();
                    fila["MPSCOD"] = MPSCOD;
                    fila["MPMDES"] = MPMDES;
                    fila["MPSFSA"] = MPSFSA;
                    fila["MPSNSA"] = MPSNSA;
                    fila["MPSCAN"] = MPSCAN;
                    fila["MPSIMP"] = MPSIMP;                    
                    fila["MPSARE"] = MPSARE;
                    fila["DESAREA"] = DESAREA;
                    fila["MPSCOR"] = MPSCOR;
                    fila["NOMTRAB1"] = NOMTRAB1;
                    fila["MPSSOL"] = MPSSOL;
                    fila["NOMTRAB2"] = NOMTRAB2;
                    fila["MPMCTA"] = MPMCTA;
                    fila["MPMCCA"] = MPMCCA;
                    fila["MPSPRO"] = MPSPRO;
                    fila["MPMUNI"] = MPMUNI;
                    fila["T01AL1"] = T01AL1;
                    fila["MPMSMX"] = MPMSMX;
                    fila["MPMSMN"] = MPMSMN;
                    fila["MPMSEM"] = MPMSEM;
                    fila["MPMPRE"] = MPMPRE;
                    fila["MPMSCO"] = MPMSCO;
                    fila["MPMUBI"] = MPMUBI;                    
                    fila["MPSOTR"] = MPSOTR;
                    fila["DESOTR"] = DESOTR;
                    tbldetalle.Rows.Add(fila);                 
                }
            }
            return tbldetalle;
        }

        /**********************************************Consulta Para Planta*************************************/
        public DataTable GetConsultaPlanta()
        {
            
            DataTable tblDetalleC = new DataTable();
            tblDetalleC.Columns.Add(new DataColumn("CODIGO", typeof(string)));
            tblDetalleC.Columns.Add(new DataColumn("DESALM", typeof(string)));
            tblDetalleC.Columns.Add(new DataColumn("DESLOG", typeof(string)));
            tblDetalleC.Columns.Add(new DataColumn("DES2", typeof(string)));
            tblDetalleC.Columns.Add(new DataColumn("DES3", typeof(string)));
            tblDetalleC.Columns.Add(new DataColumn("DES4", typeof(string)));
            tblDetalleC.Columns.Add(new DataColumn("DES5", typeof(string)));
            tblDetalleC.Columns.Add(new DataColumn("DES6", typeof(string)));
            tblDetalleC.Columns.Add(new DataColumn("STCK1", typeof(decimal)));
            tblDetalleC.Columns.Add(new DataColumn("STCK2", typeof(decimal)));
            tblDetalleC.Columns.Add(new DataColumn("PROCED", typeof(string)));
            tblDetalleC.Columns.Add(new DataColumn("UNDMED", typeof(string)));
            DataTable dtProductos = new DataTable();
            DataTable dtDescripAdi = new DataTable();
            dtProductos = oDatTab.getProductosMatrizTecnicos();
            for (int i = 0; i <= dtProductos.Rows.Count - 1; i++)
            {
                DataRow fila = tblDetalleC.NewRow();
                fila["CODIGO"] = dtProductos.Rows[i]["MPMCOD"].ToString().Trim();
                fila["DESALM"] = dtProductos.Rows[i]["MPMDES"].ToString().Trim();
                dtDescripAdi = oDatTab.getDescripAdicionales(fila["CODIGO"].ToString());
                //for (int j = 0; j <= dtDescripAdi.Rows.Count - 1; j++)
                //{
                    switch (dtDescripAdi.Rows.Count)
                    {
                        case 1:
                            fila["DESLOG"] = dtDescripAdi.Rows[0]["ARDDES"].ToString().Trim();
                            fila["DES2"] = "";
                            fila["DES3"] = "";
                            fila["DES4"] = "";
                            fila["DES5"] = "";
                            fila["DES6"] = "";                            
                            break;
                        case 2:
                            fila["DESLOG"] = dtDescripAdi.Rows[0]["ARDDES"].ToString().Trim();
                            fila["DES2"] = dtDescripAdi.Rows[1]["ARDDES"].ToString().Trim();
                            fila["DES3"] = "";
                            fila["DES4"] = "";
                            fila["DES5"] = "";
                            fila["DES6"] = "";
                            break;
                        case 3:
                            fila["DESLOG"] = dtDescripAdi.Rows[0]["ARDDES"].ToString().Trim();
                            fila["DES2"] = dtDescripAdi.Rows[1]["ARDDES"].ToString().Trim();
                            fila["DES3"] = dtDescripAdi.Rows[2]["ARDDES"].ToString().Trim();
                            fila["DES4"] = "";
                            fila["DES5"] = "";
                            fila["DES6"] = "";
                            break;
                        case 4:
                            fila["DESLOG"] = dtDescripAdi.Rows[0]["ARDDES"].ToString().Trim();
                            fila["DES2"] = dtDescripAdi.Rows[1]["ARDDES"].ToString().Trim();
                            fila["DES3"] = dtDescripAdi.Rows[2]["ARDDES"].ToString().Trim();
                            fila["DES4"] = dtDescripAdi.Rows[3]["ARDDES"].ToString().Trim();
                            fila["DES5"] = "";
                            fila["DES6"] = "";
                            break;
                        case 5:
                            fila["DESLOG"] = dtDescripAdi.Rows[0]["ARDDES"].ToString().Trim();
                            fila["DES2"] = dtDescripAdi.Rows[1]["ARDDES"].ToString().Trim();
                            fila["DES3"] = dtDescripAdi.Rows[2]["ARDDES"].ToString().Trim();
                            fila["DES4"] = dtDescripAdi.Rows[3]["ARDDES"].ToString().Trim();
                            fila["DES5"] = dtDescripAdi.Rows[4]["ARDDES"].ToString().Trim(); 
                            fila["DES6"] = "";
                            break;
                        case 6:
                            fila["DESLOG"] = dtDescripAdi.Rows[0]["ARDDES"].ToString().Trim();
                            fila["DES2"] = dtDescripAdi.Rows[1]["ARDDES"].ToString().Trim();
                            fila["DES3"] = dtDescripAdi.Rows[2]["ARDDES"].ToString().Trim();
                            fila["DES4"] = dtDescripAdi.Rows[3]["ARDDES"].ToString().Trim();
                            fila["DES5"] = dtDescripAdi.Rows[4]["ARDDES"].ToString().Trim();
                            fila["DES6"] = dtDescripAdi.Rows[5]["ARDDES"].ToString().Trim();
                            break;
                    }
                //}
                fila["STCK1"] = dtProductos.Rows[i]["MPMSCO"].ToString().Trim();
                fila["STCK2"] = dtProductos.Rows[i]["MPMSDI"].ToString().Trim();
                fila["PROCED"] = "";
                fila["UNDMED"] = dtProductos.Rows[i]["T01AL1"].ToString().Trim();
                tblDetalleC.Rows.Add(fila);
            }
            return tblDetalleC;
        }

        public DataTable getProductosAlmacenIngenieriaRPGVConsulta(string cuenta)
        {
            return oDatTab.getProductosAlmacenIngenieriaRPGVConsulta(cuenta);
        }

        public DataTable GetConsultaPlantaRPG(string user, string pass)
        {
            DataTable tblDetalleRPG = new DataTable();
            //tblDetalleRPG.Columns.Add(new DataColumn("MIMCOD",typeof(string)));
            //tblDetalleRPG.Columns.Add(new DataColumn("MIMDES",typeof(string)));
            //tblDetalleRPG.Columns.Add(new DataColumn("MIDEA1",typeof(string)));
            //tblDetalleRPG.Columns.Add(new DataColumn("MIDEA2",typeof(string)));
            //tblDetalleRPG.Columns.Add(new DataColumn("MIDEA3",typeof(string)));
            //tblDetalleRPG.Columns.Add(new DataColumn("MIDEA4",typeof(string)));
            //tblDetalleRPG.Columns.Add(new DataColumn("MIDEA5",typeof(string)));
            //tblDetalleRPG.Columns.Add(new DataColumn("MIDEA6",typeof(string)));
            //tblDetalleRPG.Columns.Add(new DataColumn("MIMCTA",typeof(string)));
            //tblDetalleRPG.Columns.Add(new DataColumn("MIMPRO",typeof(string)));
            //tblDetalleRPG.Columns.Add(new DataColumn("MIMUNI",typeof(string)));
            //tblDetalleRPG.Columns.Add(new DataColumn("MIMSCO", typeof(decimal)));
            //tblDetalleRPG.Columns.Add(new DataColumn("MIMSDI", typeof(decimal)));

            //int sw = oDatRPG.DPrograms(user, pass);            

            DataTable dtProductos = new DataTable();
            dtProductos = oDatTab.getProductosAlmacenIngenieriaRPG();
            //for (int i = 0; i <= dtProductos.Rows.Count - 1; i++)
            //{
            //    DataRow fila = tblDetalleRPG.NewRow();
            //    fila["MIMCOD"] = dtProductos.Rows[i]["MIMCOD"].ToString().Trim();
            //    fila["MIMDES"] = dtProductos.Rows[i]["MIMDES"].ToString().Trim();
            //    fila["MIDEA1"] = dtProductos.Rows[i]["MIDEA1"].ToString().Trim();
            //    fila["MIDEA2"] = dtProductos.Rows[i]["MIDEA2"].ToString().Trim();
            //    fila["MIDEA3"] = dtProductos.Rows[i]["MIDEA3"].ToString().Trim();
            //    fila["MIDEA4"] = dtProductos.Rows[i]["MIDEA4"].ToString().Trim();
            //    fila["MIDEA5"] = dtProductos.Rows[i]["MIDEA5"].ToString().Trim();
            //    fila["MIDEA6"] = dtProductos.Rows[i]["MIDEA6"].ToString().Trim();
            //    fila["MIMCTA"] = dtProductos.Rows[i]["MIMCTA"].ToString().Trim();
            //    fila["MIMPRO"] = dtProductos.Rows[i]["MIMPRO"].ToString().Trim();
            //    fila["MIMUNI"] = dtProductos.Rows[i]["MIMUNI"].ToString().Trim();
            //    fila["MIMSCO"] = dtProductos.Rows[i]["MIMSCO"];
            //    fila["MIMSDI"] = dtProductos.Rows[i]["MIMSDI"];
            //    tblDetalleRPG.Rows.Add(fila);
            //}
            return dtProductos;
        }
        /****************************TRANSACCIONES***************************************************/
        public DataTable getRequsicionesAIVFINALITY()
        {
            return oDatTab.getRequsicionesAIVFINALITY();
        }
        public DataTable getRequsicionesAI()
        {
            return oDatTab.getRequsicionesAI();
        }
        public DataTable getProductosRequerimiento(string cuenta)
        {
            return oDatTab.getProductosRequerimiento(cuenta);
        }


        public DataTable getProductosVALESSALIDA(decimal codTRAB)
        {
            return oDatTab.getProductosVALESSALIDA(codTRAB);
        }


        public DataTable getProductosRequerimientoXCodigo(string CodProd, string cuenta)
        {
            return oDatTab.getProductosRequerimientoXCodigo(CodProd, cuenta);
        }

        public DataTable getRequsicionesAIVAPROBADAS()
        {
            return oDatTab.getRequsicionesAIVAPROBADAS();
        }

        public DataTable getTablaAnos(string CodProd)
        {
            return oDatTab.getTablaAnos(CodProd);
        }




        /*Tablas para el proyecto de APROBACION DE REQUSICIONES INGENIERIA*/
        /// <summary>
        /// Armado de consumos e ingresos por producto
        /// </summary>
        /// <param name="prod">Producto relacionado con la busqueda de consumo e ingresos</param>
        /// <returns></returns>
        public DataTable getConsumosIngresos(string prod)
        {
            DataTable tblArmado = new DataTable();
            tblArmado.Columns.Add(new DataColumn("MESES", typeof(string)));
            tblArmado.Columns.Add(new DataColumn("INGRESO1", typeof(decimal)));
            tblArmado.Columns.Add(new DataColumn("EGRESO1", typeof(decimal)));
            tblArmado.Columns.Add(new DataColumn("INGRESO2", typeof(decimal)));
            tblArmado.Columns.Add(new DataColumn("EGRESO2", typeof(decimal)));
            tblArmado.Columns.Add(new DataColumn("INGRESO3", typeof(decimal)));
            tblArmado.Columns.Add(new DataColumn("EGRESO3", typeof(decimal)));
            tblArmado.Columns.Add(new DataColumn("INGRESO4", typeof(decimal)));
            tblArmado.Columns.Add(new DataColumn("EGRESO4", typeof(decimal)));
            tblArmado.Columns.Add(new DataColumn("INGRESO5", typeof(decimal)));
            tblArmado.Columns.Add(new DataColumn("EGRESO5", typeof(decimal)));
            DataTable dtAnos = new DataTable();
            DataTable dtIngresos = new DataTable();
            DataTable dtEgresos = new DataTable();
            DataView dvingre = new DataView();
            DataView dvEgre = new DataView();
            oDatTab = new DTablas();
            dtIngresos = oDatTab.getTablaIngresos(prod);
            oDatTab = new DTablas();
            dtEgresos = oDatTab.getTablaConsumos(prod);
            oDatTab = new DTablas();
            dtAnos = oDatTab.getTablaAnos(prod);

            decimal eneIng1 = 0, eneIng2 = 0, eneIng3 = 0, eneIng4 = 0, eneIng5 = 0;
            decimal eneEgr1 = 0, eneEgr2 = 0, eneEgr3 = 0, eneEgr4 = 0, eneEgr5 = 0;
            decimal febIng1 = 0, febIng2 = 0, febIng3 = 0, febIng4 = 0, febIng5 = 0;
            decimal febEgr1 = 0, febEgr2 = 0, febEgr3 = 0, febEgr4 = 0, febEgr5 = 0;
            decimal marIng1 = 0, marIng2 = 0, marIng3 = 0, marIng4 = 0, marIng5 = 0;
            decimal marEgr1 = 0, marEgr2 = 0, marEgr3 = 0, marEgr4 = 0, marEgr5 = 0;
            decimal abrIng1 = 0, abrIng2 = 0, abrIng3 = 0, abrIng4 = 0, abrIng5 = 0;
            decimal abrEgr1 = 0, abrEgr2 = 0, abrEgr3 = 0, abrEgr4 = 0, abrEgr5 = 0;
            decimal mayIng1 = 0, mayIng2 = 0, mayIng3 = 0, mayIng4 = 0, mayIng5 = 0;
            decimal mayEgr1 = 0, mayEgr2 = 0, mayEgr3 = 0, mayEgr4 = 0, mayEgr5 = 0;
            decimal junIng1 = 0, junIng2 = 0, junIng3 = 0, junIng4 = 0, junIng5 = 0;
            decimal junEgr1 = 0, junEgr2 = 0, junEgr3 = 0, junEgr4 = 0, junEgr5 = 0;
            decimal julIng1 = 0, julIng2 = 0, julIng3 = 0, julIng4 = 0, julIng5 = 0;
            decimal julEgr1 = 0, julEgr2 = 0, julEgr3 = 0, julEgr4 = 0, julEgr5 = 0;
            decimal agoIng1 = 0, agoIng2 = 0, agoIng3 = 0, agoIng4 = 0, agoIng5 = 0;
            decimal agoEgr1 = 0, agoEgr2 = 0, agoEgr3 = 0, agoEgr4 = 0, agoEgr5 = 0;
            decimal setIng1 = 0, setIng2 = 0, setIng3 = 0, setIng4 = 0, setIng5 = 0;
            decimal setEgr1 = 0, setEgr2 = 0, setEgr3 = 0, setEgr4 = 0, setEgr5 = 0;
            decimal octIng1 = 0, octIng2 = 0, octIng3 = 0, octIng4 = 0, octIng5 = 0;
            decimal octEgr1 = 0, octEgr2 = 0, octEgr3 = 0, octEgr4 = 0, octEgr5 = 0;
            decimal novIng1 = 0, novIng2 = 0, novIng3 = 0, novIng4 = 0, novIng5 = 0;
            decimal novEgr1 = 0, novEgr2 = 0, novEgr3 = 0, novEgr4 = 0, novEgr5 = 0;
            decimal dicIng1 = 0, dicIng2 = 0, dicIng3 = 0, dicIng4 = 0, dicIng5 = 0;
            decimal dicEgr1 = 0, dicEgr2 = 0, dicEgr3 = 0, dicEgr4 = 0, dicEgr5 = 0;


            for (int i = 0; i <= dtAnos.Rows.Count - 1; i++)
            {
                int per = Convert.ToInt16(dtAnos.Rows[i][0].ToString());
                dvingre = new DataView(dtIngresos, "MPEACN = " + per + "", "MPEACN DESC", DataViewRowState.OriginalRows);
                dvEgre = new DataView(dtEgresos, "MPCACN = " + per + "", "MPCACN DESC", DataViewRowState.OriginalRows);
                switch (i)
                {
                    case 0:
                        if (dvingre.Count > 0) { eneIng1 = Convert.ToDecimal(dvingre[0]["MPEC01"].ToString()); } else { eneIng1 = 0; }
                        if (dvEgre.Count > 0) { eneEgr1 = Convert.ToDecimal(dvEgre[0]["MPCC01"].ToString()); } else { eneEgr1 = 0; }
                        if (dvingre.Count > 0) { febIng1 = Convert.ToDecimal(dvingre[0]["MPEC02"].ToString()); } else { febIng1 = 0; }
                        if (dvEgre.Count > 0) { febEgr1 = Convert.ToDecimal(dvEgre[0]["MPCC02"].ToString()); } else { febEgr1 = 0; }
                        if (dvingre.Count > 0) { marIng1 = Convert.ToDecimal(dvingre[0]["MPEC03"].ToString()); } else { marIng1 = 0; }
                        if (dvEgre.Count > 0) { marEgr1 = Convert.ToDecimal(dvEgre[0]["MPCC03"].ToString()); } else { marEgr1 = 0; }
                        if (dvingre.Count > 0) { abrIng1 = Convert.ToDecimal(dvingre[0]["MPEC04"].ToString()); } else { abrIng1 = 0; }
                        if (dvEgre.Count > 0) { abrEgr1 = Convert.ToDecimal(dvEgre[0]["MPCC04"].ToString()); } else { abrEgr1 = 0; }
                        if (dvingre.Count > 0) { mayIng1 = Convert.ToDecimal(dvingre[0]["MPEC05"].ToString()); } else { mayIng1 = 0; }
                        if (dvEgre.Count > 0) { mayEgr1 = Convert.ToDecimal(dvEgre[0]["MPCC05"].ToString()); } else { mayEgr1 = 0; }
                        if (dvingre.Count > 0) { junIng1 = Convert.ToDecimal(dvingre[0]["MPEC06"].ToString()); } else { junIng1 = 0; }
                        if (dvEgre.Count > 0) { junEgr1 = Convert.ToDecimal(dvEgre[0]["MPCC06"].ToString()); } else { junEgr1 = 0; }
                        if (dvingre.Count > 0) { julIng1 = Convert.ToDecimal(dvingre[0]["MPEC07"].ToString()); } else { julIng1 = 0; }
                        if (dvEgre.Count > 0) { julEgr1 = Convert.ToDecimal(dvEgre[0]["MPCC07"].ToString()); } else { julEgr1 = 0; }
                        if (dvingre.Count > 0) { agoIng1 = Convert.ToDecimal(dvingre[0]["MPEC08"].ToString()); } else { agoIng1 = 0; }
                        if (dvEgre.Count > 0) { agoEgr1 = Convert.ToDecimal(dvEgre[0]["MPCC08"].ToString()); } else { agoEgr1 = 0; }
                        if (dvingre.Count > 0) { setIng1 = Convert.ToDecimal(dvingre[0]["MPEC09"].ToString()); } else { setIng1 = 0; }
                        if (dvEgre.Count > 0) { setEgr1 = Convert.ToDecimal(dvEgre[0]["MPCC09"].ToString()); } else { setEgr1 = 0; }
                        if (dvingre.Count > 0) { octIng1 = Convert.ToDecimal(dvingre[0]["MPEC10"].ToString()); } else { octIng1 = 0; }
                        if (dvEgre.Count > 0) { octEgr1 = Convert.ToDecimal(dvEgre[0]["MPCC10"].ToString()); } else { octEgr1 = 0; }
                        if (dvingre.Count > 0) { novIng1 = Convert.ToDecimal(dvingre[0]["MPEC11"].ToString()); } else { novIng1 = 0; }
                        if (dvEgre.Count > 0) { novEgr1 = Convert.ToDecimal(dvEgre[0]["MPCC11"].ToString()); } else { novEgr1 = 0; }
                        if (dvingre.Count > 0) { dicIng1 = Convert.ToDecimal(dvingre[0]["MPEC12"].ToString()); } else { dicIng1 = 0; }
                        if (dvEgre.Count > 0) { dicEgr1 = Convert.ToDecimal(dvEgre[0]["MPCC12"].ToString()); } else { dicEgr1 = 0; }

                        break;
                    case 1:
                        if (dvingre.Count > 0) { eneIng2 = Convert.ToDecimal(dvingre[0]["MPEC01"].ToString()); } else { eneIng2 = 0; }
                        if (dvEgre.Count > 0) { eneEgr2 = Convert.ToDecimal(dvEgre[0]["MPCC01"].ToString()); } else { eneEgr2 = 0; }
                        if (dvingre.Count > 0) { febIng2 = Convert.ToDecimal(dvingre[0]["MPEC02"].ToString()); } else { febIng2 = 0; }
                        if (dvEgre.Count > 0) { febEgr2 = Convert.ToDecimal(dvEgre[0]["MPCC02"].ToString()); } else { febEgr2 = 0; }
                        if (dvingre.Count > 0) { marIng2 = Convert.ToDecimal(dvingre[0]["MPEC03"].ToString()); } else { marIng2 = 0; }
                        if (dvEgre.Count > 0) { marEgr2 = Convert.ToDecimal(dvEgre[0]["MPCC03"].ToString()); } else { marEgr2 = 0; }
                        if (dvingre.Count > 0) { abrIng2 = Convert.ToDecimal(dvingre[0]["MPEC04"].ToString()); } else { abrIng2 = 0; }
                        if (dvEgre.Count > 0) { abrEgr2 = Convert.ToDecimal(dvEgre[0]["MPCC04"].ToString()); } else { abrEgr2 = 0; }
                        if (dvingre.Count > 0) { mayIng2 = Convert.ToDecimal(dvingre[0]["MPEC05"].ToString()); } else { mayIng2 = 0; }
                        if (dvEgre.Count > 0) { mayEgr2 = Convert.ToDecimal(dvEgre[0]["MPCC05"].ToString()); } else { mayEgr2 = 0; }
                        if (dvingre.Count > 0) { junIng2 = Convert.ToDecimal(dvingre[0]["MPEC06"].ToString()); } else { junIng2 = 0; }
                        if (dvEgre.Count > 0) { junEgr2 = Convert.ToDecimal(dvEgre[0]["MPCC06"].ToString()); } else { junEgr2 = 0; }
                        if (dvingre.Count > 0) { julIng2 = Convert.ToDecimal(dvingre[0]["MPEC07"].ToString()); } else { julIng2 = 0; }
                        if (dvEgre.Count > 0) { julEgr2 = Convert.ToDecimal(dvEgre[0]["MPCC07"].ToString()); } else { julEgr2 = 0; }
                        if (dvingre.Count > 0) { agoIng2 = Convert.ToDecimal(dvingre[0]["MPEC08"].ToString()); } else { agoIng2 = 0; }
                        if (dvEgre.Count > 0) { agoEgr2 = Convert.ToDecimal(dvEgre[0]["MPCC08"].ToString()); } else { agoEgr2 = 0; }
                        if (dvingre.Count > 0) { setIng2 = Convert.ToDecimal(dvingre[0]["MPEC09"].ToString()); } else { setIng2 = 0; }
                        if (dvEgre.Count > 0) { setEgr2 = Convert.ToDecimal(dvEgre[0]["MPCC09"].ToString()); } else { setEgr2 = 0; }
                        if (dvingre.Count > 0) { octIng2 = Convert.ToDecimal(dvingre[0]["MPEC10"].ToString()); } else { octIng2 = 0; }
                        if (dvEgre.Count > 0) { octEgr2 = Convert.ToDecimal(dvEgre[0]["MPCC10"].ToString()); } else { octEgr2 = 0; }
                        if (dvingre.Count > 0) { novIng2 = Convert.ToDecimal(dvingre[0]["MPEC11"].ToString()); } else { novIng2 = 0; }
                        if (dvEgre.Count > 0) { novEgr2 = Convert.ToDecimal(dvEgre[0]["MPCC11"].ToString()); } else { novEgr2 = 0; }
                        if (dvingre.Count > 0) { dicIng2 = Convert.ToDecimal(dvingre[0]["MPEC12"].ToString()); } else { dicIng2 = 0; }
                        if (dvEgre.Count > 0) { dicEgr2 = Convert.ToDecimal(dvEgre[0]["MPCC12"].ToString()); } else { dicEgr2 = 0; }
                        break;
                    case 2:
                        if (dvingre.Count > 0) { eneIng3 = Convert.ToDecimal(dvingre[0]["MPEC01"].ToString()); } else { eneIng3 = 0; }
                        if (dvEgre.Count > 0) { eneEgr3 = Convert.ToDecimal(dvEgre[0]["MPCC01"].ToString()); } else { eneEgr3 = 0; }
                        if (dvingre.Count > 0) { febIng3 = Convert.ToDecimal(dvingre[0]["MPEC02"].ToString()); } else { febIng3 = 0; }
                        if (dvEgre.Count > 0) { febEgr3 = Convert.ToDecimal(dvEgre[0]["MPCC02"].ToString()); } else { febEgr3 = 0; }
                        if (dvingre.Count > 0) { marIng3 = Convert.ToDecimal(dvingre[0]["MPEC03"].ToString()); } else { marIng3 = 0; }
                        if (dvEgre.Count > 0) { marEgr3 = Convert.ToDecimal(dvEgre[0]["MPCC03"].ToString()); } else { marEgr3 = 0; }
                        if (dvingre.Count > 0) { abrIng3 = Convert.ToDecimal(dvingre[0]["MPEC04"].ToString()); } else { abrIng3 = 0; }
                        if (dvEgre.Count > 0) { abrEgr3 = Convert.ToDecimal(dvEgre[0]["MPCC04"].ToString()); } else { abrEgr3 = 0; }
                        if (dvingre.Count > 0) { mayIng3 = Convert.ToDecimal(dvingre[0]["MPEC05"].ToString()); } else { mayIng3 = 0; }
                        if (dvEgre.Count > 0) { mayEgr3 = Convert.ToDecimal(dvEgre[0]["MPCC05"].ToString()); } else { mayEgr3 = 0; }
                        if (dvingre.Count > 0) { junIng3 = Convert.ToDecimal(dvingre[0]["MPEC06"].ToString()); } else { junIng3 = 0; }
                        if (dvEgre.Count > 0) { junEgr3 = Convert.ToDecimal(dvEgre[0]["MPCC06"].ToString()); } else { junEgr3 = 0; }
                        if (dvingre.Count > 0) { julIng3 = Convert.ToDecimal(dvingre[0]["MPEC07"].ToString()); } else { julIng3 = 0; }
                        if (dvEgre.Count > 0) { julEgr3 = Convert.ToDecimal(dvEgre[0]["MPCC07"].ToString()); } else { julEgr3 = 0; }
                        if (dvingre.Count > 0) { agoIng3 = Convert.ToDecimal(dvingre[0]["MPEC08"].ToString()); } else { agoIng3 = 0; }
                        if (dvEgre.Count > 0) { agoEgr3 = Convert.ToDecimal(dvEgre[0]["MPCC08"].ToString()); } else { agoEgr3 = 0; }
                        if (dvingre.Count > 0) { setIng3 = Convert.ToDecimal(dvingre[0]["MPEC09"].ToString()); } else { setIng3 = 0; }
                        if (dvEgre.Count > 0) { setEgr3 = Convert.ToDecimal(dvEgre[0]["MPCC09"].ToString()); } else { setEgr3 = 0; }
                        if (dvingre.Count > 0) { octIng3 = Convert.ToDecimal(dvingre[0]["MPEC10"].ToString()); } else { octIng3 = 0; }
                        if (dvEgre.Count > 0) { octEgr3 = Convert.ToDecimal(dvEgre[0]["MPCC10"].ToString()); } else { octEgr3 = 0; }
                        if (dvingre.Count > 0) { novIng3 = Convert.ToDecimal(dvingre[0]["MPEC11"].ToString()); } else { novIng3 = 0; }
                        if (dvEgre.Count > 0) { novEgr3 = Convert.ToDecimal(dvEgre[0]["MPCC11"].ToString()); } else { novEgr3 = 0; }
                        if (dvingre.Count > 0) { dicIng3 = Convert.ToDecimal(dvingre[0]["MPEC12"].ToString()); } else { dicIng3 = 0; }
                        if (dvEgre.Count > 0) { dicEgr3 = Convert.ToDecimal(dvEgre[0]["MPCC12"].ToString()); } else { dicEgr3 = 0; }
                        break;
                    case 3:
                        if (dvingre.Count > 0) { eneIng4 = Convert.ToDecimal(dvingre[0]["MPEC01"].ToString()); } else { eneIng4 = 0; }
                        if (dvEgre.Count > 0) { eneEgr4 = Convert.ToDecimal(dvEgre[0]["MPCC01"].ToString()); } else { eneEgr4 = 0; }
                        if (dvingre.Count > 0) { febIng4 = Convert.ToDecimal(dvingre[0]["MPEC02"].ToString()); } else { febIng4 = 0; }
                        if (dvEgre.Count > 0) { febEgr4 = Convert.ToDecimal(dvEgre[0]["MPCC02"].ToString()); } else { febEgr4 = 0; }
                        if (dvingre.Count > 0) { marIng4 = Convert.ToDecimal(dvingre[0]["MPEC03"].ToString()); } else { marIng4 = 0; }
                        if (dvEgre.Count > 0) { marEgr4 = Convert.ToDecimal(dvEgre[0]["MPCC03"].ToString()); } else { marEgr4 = 0; }
                        if (dvingre.Count > 0) { abrIng4 = Convert.ToDecimal(dvingre[0]["MPEC04"].ToString()); } else { abrIng4 = 0; }
                        if (dvEgre.Count > 0) { abrEgr4 = Convert.ToDecimal(dvEgre[0]["MPCC04"].ToString()); } else { abrEgr4 = 0; }
                        if (dvingre.Count > 0) { mayIng4 = Convert.ToDecimal(dvingre[0]["MPEC05"].ToString()); } else { mayIng4 = 0; }
                        if (dvEgre.Count > 0) { mayEgr4 = Convert.ToDecimal(dvEgre[0]["MPCC05"].ToString()); } else { mayEgr4 = 0; }
                        if (dvingre.Count > 0) { junIng4 = Convert.ToDecimal(dvingre[0]["MPEC06"].ToString()); } else { junIng4 = 0; }
                        if (dvEgre.Count > 0) { junEgr4 = Convert.ToDecimal(dvEgre[0]["MPCC06"].ToString()); } else { junEgr4 = 0; }
                        if (dvingre.Count > 0) { julIng4 = Convert.ToDecimal(dvingre[0]["MPEC07"].ToString()); } else { julIng4 = 0; }
                        if (dvEgre.Count > 0) { julEgr4 = Convert.ToDecimal(dvEgre[0]["MPCC07"].ToString()); } else { julEgr4 = 0; }
                        if (dvingre.Count > 0) { agoIng4 = Convert.ToDecimal(dvingre[0]["MPEC08"].ToString()); } else { agoIng4 = 0; }
                        if (dvEgre.Count > 0) { agoEgr4 = Convert.ToDecimal(dvEgre[0]["MPCC08"].ToString()); } else { agoEgr4 = 0; }
                        if (dvingre.Count > 0) { setIng4 = Convert.ToDecimal(dvingre[0]["MPEC09"].ToString()); } else { setIng4 = 0; }
                        if (dvEgre.Count > 0) { setEgr4 = Convert.ToDecimal(dvEgre[0]["MPCC09"].ToString()); } else { setEgr4 = 0; }
                        if (dvingre.Count > 0) { octIng4 = Convert.ToDecimal(dvingre[0]["MPEC10"].ToString()); } else { octIng4 = 0; }
                        if (dvEgre.Count > 0) { octEgr4 = Convert.ToDecimal(dvEgre[0]["MPCC10"].ToString()); } else { octEgr4 = 0; }
                        if (dvingre.Count > 0) { novIng4 = Convert.ToDecimal(dvingre[0]["MPEC11"].ToString()); } else { novIng4 = 0; }
                        if (dvEgre.Count > 0) { novEgr4 = Convert.ToDecimal(dvEgre[0]["MPCC11"].ToString()); } else { novEgr4 = 0; }
                        if (dvingre.Count > 0) { dicIng4 = Convert.ToDecimal(dvingre[0]["MPEC12"].ToString()); } else { dicIng4 = 0; }
                        if (dvEgre.Count > 0) { dicEgr4 = Convert.ToDecimal(dvEgre[0]["MPCC12"].ToString()); } else { dicEgr4 = 0; }
                        break;
                    case 4:
                        if (dvingre.Count > 0) { eneIng5 = Convert.ToDecimal(dvingre[0]["MPEC01"].ToString()); } else { eneIng5 = 0; }
                        if (dvEgre.Count > 0) { eneEgr5 = Convert.ToDecimal(dvEgre[0]["MPCC01"].ToString()); } else { eneEgr5 = 0; }
                        if (dvingre.Count > 0) { febIng5 = Convert.ToDecimal(dvingre[0]["MPEC02"].ToString()); } else { febIng5 = 0; }
                        if (dvEgre.Count > 0) { febEgr5 = Convert.ToDecimal(dvEgre[0]["MPCC02"].ToString()); } else { febEgr5 = 0; }
                        if (dvingre.Count > 0) { marIng5 = Convert.ToDecimal(dvingre[0]["MPEC03"].ToString()); } else { marIng5 = 0; }
                        if (dvEgre.Count > 0) { marEgr5 = Convert.ToDecimal(dvEgre[0]["MPCC03"].ToString()); } else { marEgr5 = 0; }
                        if (dvingre.Count > 0) { abrIng5 = Convert.ToDecimal(dvingre[0]["MPEC04"].ToString()); } else { abrIng5 = 0; }
                        if (dvEgre.Count > 0) { abrEgr5 = Convert.ToDecimal(dvEgre[0]["MPCC04"].ToString()); } else { abrEgr5 = 0; }
                        if (dvingre.Count > 0) { mayIng5 = Convert.ToDecimal(dvingre[0]["MPEC05"].ToString()); } else { mayIng5 = 0; }
                        if (dvEgre.Count > 0) { mayEgr5 = Convert.ToDecimal(dvEgre[0]["MPCC05"].ToString()); } else { mayEgr5 = 0; }
                        if (dvingre.Count > 0) { junIng5 = Convert.ToDecimal(dvingre[0]["MPEC06"].ToString()); } else { junIng5 = 0; }
                        if (dvEgre.Count > 0) { junEgr5 = Convert.ToDecimal(dvEgre[0]["MPCC06"].ToString()); } else { junEgr5 = 0; }
                        if (dvingre.Count > 0) { julIng5 = Convert.ToDecimal(dvingre[0]["MPEC07"].ToString()); } else { julIng5 = 0; }
                        if (dvEgre.Count > 0) { julEgr5 = Convert.ToDecimal(dvEgre[0]["MPCC07"].ToString()); } else { julEgr5 = 0; }
                        if (dvingre.Count > 0) { agoIng5 = Convert.ToDecimal(dvingre[0]["MPEC08"].ToString()); } else { agoIng5 = 0; }
                        if (dvEgre.Count > 0) { agoEgr5 = Convert.ToDecimal(dvEgre[0]["MPCC08"].ToString()); } else { agoEgr5 = 0; }
                        if (dvingre.Count > 0) { setIng5 = Convert.ToDecimal(dvingre[0]["MPEC09"].ToString()); } else { setIng5 = 0; }
                        if (dvEgre.Count > 0) { setEgr5 = Convert.ToDecimal(dvEgre[0]["MPCC09"].ToString()); } else { setEgr5 = 0; }
                        if (dvingre.Count > 0) { octIng5 = Convert.ToDecimal(dvingre[0]["MPEC10"].ToString()); } else { octIng5 = 0; }
                        if (dvEgre.Count > 0) { octEgr5 = Convert.ToDecimal(dvEgre[0]["MPCC10"].ToString()); } else { octEgr5 = 0; }
                        if (dvingre.Count > 0) { novIng5 = Convert.ToDecimal(dvingre[0]["MPEC11"].ToString()); } else { novIng5 = 0; }
                        if (dvEgre.Count > 0) { novEgr5 = Convert.ToDecimal(dvEgre[0]["MPCC11"].ToString()); } else { novEgr5 = 0; }
                        if (dvingre.Count > 0) { dicIng5 = Convert.ToDecimal(dvingre[0]["MPEC12"].ToString()); } else { dicIng5 = 0; }
                        if (dvEgre.Count > 0) { dicEgr5 = Convert.ToDecimal(dvEgre[0]["MPCC12"].ToString()); } else { dicEgr5 = 0; }
                        break;
                }
            }

            DataRow fila = tblArmado.NewRow();
            fila["MESES"] = "Enero";
            fila["INGRESO1"] = eneIng1;
            fila["EGRESO1"] = eneEgr1;
            fila["INGRESO2"] = eneIng2;
            fila["EGRESO2"] = eneEgr2;
            fila["INGRESO3"] = eneIng3;
            fila["EGRESO3"] = eneEgr3;
            fila["INGRESO4"] = eneIng4;
            fila["EGRESO4"] = eneEgr4;
            fila["INGRESO5"] = eneIng5;
            fila["EGRESO5"] = eneEgr5;
            tblArmado.Rows.Add(fila);

            fila = tblArmado.NewRow();
            fila["MESES"] = "Febrero";
            fila["INGRESO1"] = febIng1;
            fila["EGRESO1"] = febEgr1;
            fila["INGRESO2"] = febIng2;
            fila["EGRESO2"] = febEgr2;
            fila["INGRESO3"] = febIng3;
            fila["EGRESO3"] = febEgr3;
            fila["INGRESO4"] = febIng4;
            fila["EGRESO4"] = febEgr4;
            fila["INGRESO5"] = febIng5;
            fila["EGRESO5"] = febEgr5;
            tblArmado.Rows.Add(fila);

            fila = tblArmado.NewRow();
            fila["MESES"] = "Marzo";
            fila["INGRESO1"] = marIng1;
            fila["EGRESO1"] = marEgr1;
            fila["INGRESO2"] = marIng2;
            fila["EGRESO2"] = marEgr2;
            fila["INGRESO3"] = marIng3;
            fila["EGRESO3"] = marEgr3;
            fila["INGRESO4"] = marIng4;
            fila["EGRESO4"] = marEgr4;
            fila["INGRESO5"] = marIng5;
            fila["EGRESO5"] = marEgr5;
            tblArmado.Rows.Add(fila);

            fila = tblArmado.NewRow();
            fila["MESES"] = "Abril";
            fila["INGRESO1"] = abrIng1;
            fila["EGRESO1"] = abrEgr1;
            fila["INGRESO2"] = abrIng2;
            fila["EGRESO2"] = abrEgr2;
            fila["INGRESO3"] = abrIng3;
            fila["EGRESO3"] = abrEgr3;
            fila["INGRESO4"] = abrIng4;
            fila["EGRESO4"] = abrEgr4;
            fila["INGRESO5"] = abrIng5;
            fila["EGRESO5"] = abrEgr5;
            tblArmado.Rows.Add(fila);

            fila = tblArmado.NewRow();
            fila["MESES"] = "Mayo";
            fila["INGRESO1"] = mayIng1;
            fila["EGRESO1"] = mayEgr1;
            fila["INGRESO2"] = mayIng2;
            fila["EGRESO2"] = mayEgr2;
            fila["INGRESO3"] = mayIng3;
            fila["EGRESO3"] = mayEgr3;
            fila["INGRESO4"] = mayIng4;
            fila["EGRESO4"] = mayEgr4;
            fila["INGRESO5"] = mayIng5;
            fila["EGRESO5"] = mayEgr5;
            tblArmado.Rows.Add(fila);

            fila = tblArmado.NewRow();
            fila["MESES"] = "Junio";
            fila["INGRESO1"] = junIng1;
            fila["EGRESO1"] = junEgr1;
            fila["INGRESO2"] = junIng2;
            fila["EGRESO2"] = junEgr2;
            fila["INGRESO3"] = junIng3;
            fila["EGRESO3"] = junEgr3;
            fila["INGRESO4"] = junIng4;
            fila["EGRESO4"] = junEgr4;
            fila["INGRESO5"] = junIng5;
            fila["EGRESO5"] = junEgr5;
            tblArmado.Rows.Add(fila);

            fila = tblArmado.NewRow();
            fila["MESES"] = "Julio";
            fila["INGRESO1"] = julIng1;
            fila["EGRESO1"] = julEgr1;
            fila["INGRESO2"] = julIng2;
            fila["EGRESO2"] = julEgr2;
            fila["INGRESO3"] = julIng3;
            fila["EGRESO3"] = julEgr3;
            fila["INGRESO4"] = julIng4;
            fila["EGRESO4"] = julEgr4;
            fila["INGRESO5"] = julIng5;
            fila["EGRESO5"] = julEgr5;
            tblArmado.Rows.Add(fila);

            fila = tblArmado.NewRow();
            fila["MESES"] = "Agosto";
            fila["INGRESO1"] = agoIng1;
            fila["EGRESO1"] = agoEgr1;
            fila["INGRESO2"] = agoIng2;
            fila["EGRESO2"] = agoEgr2;
            fila["INGRESO3"] = agoIng3;
            fila["EGRESO3"] = agoEgr3;
            fila["INGRESO4"] = agoIng4;
            fila["EGRESO4"] = agoEgr4;
            fila["INGRESO5"] = agoIng5;
            fila["EGRESO5"] = agoEgr5;
            tblArmado.Rows.Add(fila);

            fila = tblArmado.NewRow();
            fila["MESES"] = "Setiembre";
            fila["INGRESO1"] = setIng1;
            fila["EGRESO1"] = setEgr1;
            fila["INGRESO2"] = setIng2;
            fila["EGRESO2"] = setEgr2;
            fila["INGRESO3"] = setIng3;
            fila["EGRESO3"] = setEgr3;
            fila["INGRESO4"] = setIng4;
            fila["EGRESO4"] = setEgr4;
            fila["INGRESO5"] = setIng5;
            fila["EGRESO5"] = setEgr5;
            tblArmado.Rows.Add(fila);

            fila = tblArmado.NewRow();
            fila["MESES"] = "Octubre";
            fila["INGRESO1"] = octIng1;
            fila["EGRESO1"] = octEgr1;
            fila["INGRESO2"] = octIng2;
            fila["EGRESO2"] = octEgr2;
            fila["INGRESO3"] = octIng3;
            fila["EGRESO3"] = octEgr3;
            fila["INGRESO4"] = octIng4;
            fila["EGRESO4"] = octEgr4;
            fila["INGRESO5"] = octIng5;
            fila["EGRESO5"] = octEgr5;
            tblArmado.Rows.Add(fila);

            fila = tblArmado.NewRow();
            fila["MESES"] = "Noviembre";
            fila["INGRESO1"] = novIng1;
            fila["EGRESO1"] = novEgr1;
            fila["INGRESO2"] = novIng2;
            fila["EGRESO2"] = novEgr2;
            fila["INGRESO3"] = novIng3;
            fila["EGRESO3"] = novEgr3;
            fila["INGRESO4"] = novIng4;
            fila["EGRESO4"] = novEgr4;
            fila["INGRESO5"] = novIng5;
            fila["EGRESO5"] = novEgr5;
            tblArmado.Rows.Add(fila);

            fila = tblArmado.NewRow();
            fila["MESES"] = "Diciembre";
            fila["INGRESO1"] = dicIng1;
            fila["EGRESO1"] = dicEgr1;
            fila["INGRESO2"] = dicIng2;
            fila["EGRESO2"] = dicEgr2;
            fila["INGRESO3"] = dicIng3;
            fila["EGRESO3"] = dicEgr3;
            fila["INGRESO4"] = dicIng4;
            fila["EGRESO4"] = dicEgr4;
            fila["INGRESO5"] = dicIng5;
            fila["EGRESO5"] = dicEgr5;
            tblArmado.Rows.Add(fila);

            fila = tblArmado.NewRow();
            fila["MESES"] = "T.por Año";
            fila["INGRESO1"] = eneIng1 + febIng1 + marIng1 + abrIng1 + mayIng1 + junIng1 + julIng1 + agoIng1 + setIng1 + octIng1 + novIng1 + dicIng1;
            fila["EGRESO1"] = eneEgr1 + febEgr1 + marEgr1 + abrEgr1 + mayEgr1 + junEgr1 + julEgr1 + agoEgr1 + setEgr1 + octEgr1 + novEgr1 + dicEgr1;
            fila["INGRESO2"] = eneIng2 + febIng2 + marIng2 + abrIng2 + mayIng2 + junIng2 + julIng2 + agoIng2 + setIng2 + octIng2 + novIng2 + dicIng2;
            fila["EGRESO2"] = eneEgr2 + febEgr2 + marEgr2 + abrEgr2 + mayEgr2 + junEgr2 + julEgr2 + agoEgr2 + setEgr2 + octEgr2 + novEgr2 + dicEgr2;
            fila["INGRESO3"] = eneIng3 + febIng3 + marIng3 + abrIng3 + mayIng3 + junIng3 + julIng3 + agoIng3 + setIng3 + octIng3 + novIng3 + dicIng3;
            fila["EGRESO3"] = eneEgr3 + febEgr3 + marEgr3 + abrEgr3 + mayEgr3 + junEgr3 + julEgr3 + agoEgr3 + setEgr3 + octEgr3 + novEgr3 + dicEgr3;
            fila["INGRESO4"] = eneIng4 + febIng4 + marIng4 + abrIng4 + mayIng4 + junIng4 + julIng4 + agoIng4 + setIng4 + octIng4 + novIng4 + dicIng4;
            fila["EGRESO4"] = eneEgr4 + febEgr4 + marEgr4 + abrEgr4 + mayEgr4 + junEgr4 + julEgr4 + agoEgr4 + setEgr4 + octEgr4 + novEgr4 + dicEgr4;
            fila["INGRESO5"] = eneIng5 + febIng5 + marIng5 + abrIng5 + mayIng5 + junIng5 + julIng5 + agoIng5 + setIng5 + octIng5 + novIng5 + dicIng5;
            fila["EGRESO5"] = eneEgr5 + febEgr5 + marEgr5 + abrEgr5 + mayEgr5 + junEgr5 + julEgr5 + agoEgr5 + setEgr5 + octEgr5 + novEgr5 + dicEgr5;
            tblArmado.Rows.Add(fila);

            return tblArmado;
        }

        public DataTable getTablaGruSubGru(string prod)
        {
            return oDatTab.getTablaGruSubGru(prod);
        }

        public DataTable getTablaOrdenesCompra(string prod)
        {
            return oDatTab.getTablaOrdenesCompra(prod);
        }

        public int BInsertDescripcion(string Esta, string Usua, decimal Fech, decimal Hora, string Prod, string Requi, string Entr, string Comen, decimal CanMin, decimal PU, decimal CAN, decimal TOT)
        {
            return oDatTab.DInsertDescripcion(Esta, Usua, Fech, Hora, Prod, Requi, Entr, Comen, CanMin, PU, CAN, TOT);
        }

        public DataTable getBuscaComent(string prod, string REQUI)
        {
            return oDatTab.getBuscaComent(prod, REQUI); 
        }
        public int BUpdateDescripcion(string Esta, string Usua, decimal Fech, decimal Hora, string Prod, string Requi)
        {
            return oDatTab.DUpdateDescripcion(Esta, Usua, Fech, Hora, Prod, Requi);
        }
        public int BUpdateLIBRE(string SQL)
        {
            return oDatTab.DUpdateLIBRE(SQL);
        }




        public DataTable getRequisicionesAI(DataTable dtRequisiciones, DataTable dtUnidadMed,DataTable DescripcionesAdicionales,DataTable dtGrupos,DataTable dtSubgrupos)
        {
            DataTable tbldetalle = new DataTable();

            tbldetalle.Columns.Add(new DataColumn("Codigo", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("Item", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("Requisicion", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("FechaReq", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("Cantidad", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("Precio", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("ValorUCom", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("OC", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("Situacion", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("Detalle", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("Grupo", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("UndMedida", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("Stock", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("Procedencia", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("TipoCompra", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("StockMAX", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("StockMIN", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("Subgrupo", typeof(string)));

            tbldetalle.Columns.Add(new DataColumn("DetaAdicional", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("Descripcion_Detallada", typeof(string)));

            DataView busqueda = new DataView();

            for (int i = 0; i <= dtRequisiciones.Rows.Count - 1; i++)
            {
                DataRow fila = tbldetalle.NewRow();
                fila["Codigo"] = dtRequisiciones.Rows[i]["MPMCOD"].ToString().Trim();
                fila["Descripcion"] = dtRequisiciones.Rows[i]["MPMDES"].ToString().Trim();
                fila["Descripcion_Detallada"] = dtRequisiciones.Rows[i]["DES1"].ToString().Trim() + " " + dtRequisiciones.Rows[i]["DES2"].ToString().Trim() + " " + dtRequisiciones.Rows[i]["DES3"].ToString().Trim() + " " + dtRequisiciones.Rows[i]["DES4"].ToString().Trim() + " " + dtRequisiciones.Rows[i]["DES5"].ToString().Trim() + " " + dtRequisiciones.Rows[i]["DES6"].ToString().Trim();
                fila["Requisicion"] = dtRequisiciones.Rows[i]["RQCCVE"].ToString().Trim();
                fila["Item"] = dtRequisiciones.Rows[i]["RQCSEQ"].ToString().Trim();
                fila["FechaReq"] = dtRequisiciones.Rows[i]["RQCFES"].ToString().Trim();
                fila["Cantidad"] = Convert.ToDecimal(dtRequisiciones.Rows[i]["RQCCAN"].ToString().Trim());
                fila["Precio"] = Convert.ToDecimal(dtRequisiciones.Rows[i]["RQCVD1"].ToString().Trim());
                fila["ValorUCom"] = Convert.ToDecimal(dtRequisiciones.Rows[i]["ARTUPC"].ToString().Trim());
                fila["OC"] = dtRequisiciones.Rows[i]["OCOCVE"].ToString().Trim();
                fila["Situacion"] = dtRequisiciones.Rows[i]["RQCSID"].ToString().Trim();
                fila["Detalle"] = dtRequisiciones.Rows[i]["RQCCMT"].ToString().Trim();

                try
                {
                    decimal COD = Convert.ToDecimal(dtRequisiciones.Rows[i]["MPMCOD"].ToString().Trim().Substring(0, 2));
                    busqueda = new DataView(dtGrupos, "AIGCOD = '" + COD + "'", "", DataViewRowState.OriginalRows);
                    if (busqueda.Count > 0) { fila["Grupo"] = busqueda[0]["AIGDES"].ToString(); }
                }
                catch { }

                try
                {
                    string uniMed = dtRequisiciones.Rows[i]["MPMUNI"].ToString().Trim();
                    busqueda = new DataView(dtUnidadMed, "T01ESP = '" + uniMed + "'", "", DataViewRowState.OriginalRows);
                    if (busqueda.Count > 0) { fila["UndMedida"] = busqueda[0]["T01AL1"].ToString(); }
                    
                }
                catch { }
                fila["Stock"] = dtRequisiciones.Rows[i]["MPMSDI"].ToString().Trim();


                switch (dtRequisiciones.Rows[i]["MPMPRO"].ToString().Trim())
                {
                    case "1":
                        fila["Procedencia"] = "Local";
                        break;
                    case "2":
                        fila["Procedencia"] = "L/I";
                        break;
                    case "3":
                        fila["Procedencia"] = "Imp";
                        break;
                    case "4":
                        fila["Procedencia"] = "Autoconsumo";
                        break;
                    default:
                        fila["Procedencia"] = "No Def.";
                        break;
                }                
                fila["TipoCompra"] = dtRequisiciones.Rows[i]["DAACVE"].ToString().Trim();
                fila["StockMAX"] = dtRequisiciones.Rows[i]["MPMSMX"].ToString().Trim();
                fila["StockMIN"] = dtRequisiciones.Rows[i]["MPMSMN"].ToString().Trim();

                try
                {
                    decimal CODI = Convert.ToDecimal(dtRequisiciones.Rows[i]["MPMCOD"].ToString().Trim().Substring(0, 4));
                    busqueda = new DataView(dtSubgrupos, "AISCOD = '" + CODI + "'", "", DataViewRowState.OriginalRows);
                    if (busqueda.Count > 0) { fila["Subgrupo"] = busqueda[0]["AISDES"].ToString(); }
                }
                catch { }


                try
                {
                    string requi = dtRequisiciones.Rows[i]["RQCCVE"].ToString().Trim();
                    decimal seq = Convert.ToDecimal(dtRequisiciones.Rows[i]["RQCSEQ"].ToString().Trim());
                    busqueda = new DataView(DescripcionesAdicionales, "RQCCVE = '" + requi + "' and RQCSEQ = " + seq + "", "", DataViewRowState.OriginalRows);
                    if (busqueda.Count > 0) { fila["DetaAdicional"] = busqueda[0]["RQCDES"].ToString(); }
                }
                catch { }                
                tbldetalle.Rows.Add(fila);
            }




            //for (int x = 0; x <= dtRepuestos.Rows.Count - 1; x++)
            //{
            //    DataRow fila = tbldetalle.NewRow();
            //    fila["Codigo"] = dtRepuestos.Rows[x][0].ToString().Trim();
            //    fila["Descripcion"] = dtRepuestos.Rows[x][1].ToString().Trim();
            //    fila["N_Parte"] = dtRepuestos.Rows[x][2].ToString().Trim();
            //    fila["Cod_Und_Med"] = dtRepuestos.Rows[x][3].ToString().Trim();
            //    fila["Unid_Med"] = dtRepuestos.Rows[x][4].ToString().Trim();
            //    fila["Ubicacion"] = dtRepuestos.Rows[x][5].ToString().Trim();
            //    fila["Descripcion_Tarde"] = dtRepuestos.Rows[x][6].ToString().Trim();
            //    fila["Aplicabilidad"] = dtRepuestos.Rows[x][7].ToString().Trim();
            //    dvApli = new DataView(dtAplicabilidad, "APLI =" + Convert.ToDecimal(dtRepuestos.Rows[x][7].ToString()), "", DataViewRowState.OriginalRows);
            //    if (dvApli.Count == 0) { fila["Cod_Aplicabilidad"] = ""; fila["Des_Aplicabilidad"] = ""; }
            //    else { fila["Cod_Aplicabilidad"] = dvApli[0]["AITCOD"].ToString().Trim(); fila["Des_Aplicabilidad"] = dvApli[0]["AITDES"].ToString().Trim(); }

            //    fila["Des_Mecanicos"] = dtRepuestos.Rows[x][8].ToString().Trim();

            //    tbldetalle.Rows.Add(fila);
            //}
            return tbldetalle;
        }


        /****************************************************CONSULTA GERENCIAL MATERIA PRIMA*****************************************/


        /// <summary>
        /// CONSULTA GERENCIA MATERIA PRIMA
        /// </summary>
        /// <param name="dtMatPrima">TABLA DE MATERIAS PRIMAS</param>
        /// <returns></returns>
        public DataTable getConsultaMateriaPrima(DataTable dtMatPrima, DataTable dtCuentasAI, DataTable dtCuentasMAT, DataTable dtCosumoMesAnteriorMP, DataTable dtIngresoMesAnteriorMP, DataTable dtCosumoMesAnteriorAI, DataTable dtIngresoMesAnteriorAI, DataTable dtCosumoHistoricoMP, DataTable dtIngresoHistoricoMP, DataTable dtCosumoHistoricoAI, DataTable dtIngresoHistoricoAI, string anioJ1, string anioJ2, string anioJ3, string mesJ1, string mesJ2, string mesJ3)
        {
            DataTable dtDetalle = new DataTable();
            dtDetalle.Columns.Add(new DataColumn("Codigo", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("Contable", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("Disponible", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("ReqProd", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("FechaQuiebre", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("DStck", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("agotado", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("Consumo", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("Consumo1", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("Consumo2", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("Consumo3", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("Consumo4", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("Ingreso", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("Ingreso1", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("Ingreso2", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("Ingreso3", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("Ingreso4", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("CProm", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("CuentaAlmacen", typeof(string)));

            double W1 = 0;
            DateTime getHOY = DateTime.Now;

            string rs0 = "";
            string rs1 = "";
            string rs2 = "";
            string rs3 = "";
            string rs4 = "";
            string rs5 = "";
            string rs6 = "";
            string rs7 = "";
            string rs8 = "";
            string rsCta = "";
            string rsALM = "";


            string rsCodigoEquivalente = "";
            string rsConMesAnterior = "";
            string rsIngMesAnterior = "";


            string rsCon1 = "";
            string rsCon2 = "";
            string rsCon3 = "";

            string rsING1 = "";
            string rsING2 = "";
            string rsING3 = "";


            string CAMPOFORMADO = "";

            Int32 W2 = 0;
            DataView dv = new DataView();

            for (int i = 0; i <= dtMatPrima.Rows.Count - 1; i++)
            {
                rs0 = dtMatPrima.Rows[i]["RMAT11COD"].ToString();
                rs1 = dtMatPrima.Rows[i]["DESCRIPCION"].ToString();
                rs2 = dtMatPrima.Rows[i]["MPMSCO"].ToString();
                rs3 = dtMatPrima.Rows[i]["MPMSDI"].ToString();
                rs4 = dtMatPrima.Rows[i]["RMAT11CAN"].ToString();
                rs5 = dtMatPrima.Rows[i]["DSTOCK"].ToString();
                

                rsCodigoEquivalente = dtMatPrima.Rows[i]["COD_EQUIV"].ToString();                


                rs6 = dtMatPrima.Rows[i]["CONSUMO"].ToString();
                dv = new DataView(dtCosumoMesAnteriorMP, "MPSCOD='" + rs0 + "'", "", DataViewRowState.OriginalRows);
                if (dv.Count > 0) { rsConMesAnterior = dv[0]["CANTIDAD"].ToString(); } else { rsConMesAnterior = ""; }

                dv = new DataView(dtCosumoHistoricoMP, "MPCCOD='" + rs0 + "' AND MPCACN = " + anioJ1 + "", "", DataViewRowState.OriginalRows);
                CAMPOFORMADO = "MPCC" + mesJ1;
                if (dv.Count > 0) { rsCon1 = dv[0][CAMPOFORMADO].ToString(); } else { rsCon1 = ""; }
                dv = new DataView(dtCosumoHistoricoMP, "MPCCOD='" + rs0 + "' AND MPCACN = " + anioJ2 + "", "", DataViewRowState.OriginalRows);
                CAMPOFORMADO = "MPCC" + mesJ2;
                if (dv.Count > 0) { rsCon2 = dv[0][CAMPOFORMADO].ToString(); } else { rsCon2 = ""; }
                dv = new DataView(dtCosumoHistoricoMP, "MPCCOD='" + rs0 + "' AND MPCACN = " + anioJ3 + "", "", DataViewRowState.OriginalRows);
                CAMPOFORMADO = "MPCC" + mesJ3;
                if (dv.Count > 0) { rsCon3 = dv[0][CAMPOFORMADO].ToString(); } else { rsCon3 = ""; }




                rs7 = dtMatPrima.Rows[i]["INGRESOS"].ToString();
                dv = new DataView(dtIngresoMesAnteriorMP, "MPICOD='" + rs0 + "'", "", DataViewRowState.OriginalRows);
                if (dv.Count > 0) { rsIngMesAnterior = dv[0]["CANTIDAD"].ToString(); } else { rsIngMesAnterior = ""; }


                dv = new DataView(dtIngresoHistoricoMP, "MPECOD='" + rs0 + "' AND MPEACN = " + anioJ1 + "", "", DataViewRowState.OriginalRows);
                CAMPOFORMADO = "MPEC" + mesJ1;
                if (dv.Count > 0) { rsING1 = dv[0][CAMPOFORMADO].ToString(); } else { rsING1 = ""; }
                dv = new DataView(dtIngresoHistoricoMP, "MPECOD='" + rs0 + "' AND MPEACN = " + anioJ2 + "", "", DataViewRowState.OriginalRows);
                CAMPOFORMADO = "MPEC" + mesJ2;
                if (dv.Count > 0) { rsING2 = dv[0][CAMPOFORMADO].ToString(); } else { rsING2 = ""; }
                dv = new DataView(dtIngresoHistoricoMP, "MPECOD='" + rs0 + "' AND MPEACN = " + anioJ3 + "", "", DataViewRowState.OriginalRows);
                CAMPOFORMADO = "MPEC" + mesJ3;
                if (dv.Count > 0) { rsING3 = dv[0][CAMPOFORMADO].ToString(); } else { rsING3 = ""; }

                
                
                
                rs8 = dtMatPrima.Rows[i]["RMAT11CON"].ToString();

                rsCta = "0" + dtMatPrima.Rows[i]["CUENTA"].ToString();
                rsALM = dtMatPrima.Rows[i]["INDICADOR"].ToString();

                DataRow fila = dtDetalle.NewRow();

                if (rs0 != "") { fila["Codigo"] = rs0; }
                if (rs1 != "") { fila["Descripcion"] = rs1; }
                if (rs2 != "" && Convert.ToDecimal(rs2) != 0) { fila["Contable"] = rs2; }
                if (rs3 != "" && Convert.ToDecimal(rs3) != 0) { fila["Disponible"] = rs3; }
                if (rs4 != "" && Convert.ToDecimal(rs4) != 0) { fila["ReqProd"] = rs4; }

                /****Fecha de Quiebre******/

                if (Convert.ToDecimal(rs4) != 0 && rs4 != null)
                {
                    W1 = Convert.ToDouble(rs2) / (Convert.ToDouble(rs4) / Convert.ToDouble(rs5));
                    int g = Convert.ToString(W1).IndexOf(".");
                    if (g == -1)
                    {
                        W2 = Convert.ToInt32(Convert.ToString(W1));
                        fila["FechaQuiebre"] = getHOY.AddDays(W2).ToShortDateString().ToString();
                        fila["DStck"] = Convert.ToString(Convert.ToInt32(W1)); 
                    }
                    else
                    {
                        W2 = Convert.ToInt32(Convert.ToString(W1).Substring(0, g));
                        fila["FechaQuiebre"] = getHOY.AddDays(W2).ToShortDateString().ToString();
                        fila["DStck"] = Convert.ToString(Convert.ToInt32(W1));
                    }
                }            
                /**************************/
                if (rs3 == "" || Convert.ToDecimal(rs3) == 0) { fila["agotado"] = "Agotado"; } else { fila["agotado"] = ""; }

                if (rs6 != "" && Convert.ToDecimal(rs6) != 0) { fila["Consumo"] = rs6; }
                if (rs7 != "" && Convert.ToDecimal(rs7) != 0) { fila["Ingreso"] = rs7;  }
                if (rs8 != "" && Convert.ToDecimal(rs8) != 0) { fila["CProm"] = rs8; }

                /*historia de ingresos y egresos*/
                fila["Consumo1"] = rsConMesAnterior;
                fila["Consumo2"] = rsCon1;
                fila["Consumo3"] = rsCon2;
                fila["Consumo4"] = rsCon3;

                fila["Ingreso1"] = rsIngMesAnterior;
                fila["Ingreso2"] = rsING1;
                fila["Ingreso3"] = rsING2;
                fila["Ingreso4"] = rsING3;

                



                switch (rsALM)
                {
                    case "MAT":
                        dv = new DataView(dtCuentasMAT, "MPTARG = '" + rsCta + "'", "", DataViewRowState.OriginalRows);
                        if (dv.Count > 0) { fila["CuentaAlmacen"] = dv[0]["MPTDES"].ToString(); }
                        break;
                    case "ING":
                        //dv = new DataView(dtCuentasAI, "MPTARG = '" + rsCta + "'", "", DataViewRowState.OriginalRows);
                        //if (dv.Count > 0) { fila["CuentaAlmacen"] = dv[0]["MPTDES"].ToString(); }
                        fila["CuentaAlmacen"] = "Bladder";


                        dv = new DataView(dtCosumoMesAnteriorAI, "MPSCOD='" + rsCodigoEquivalente + "'", "", DataViewRowState.OriginalRows);
                        if (dv.Count > 0) { rsConMesAnterior = dv[0]["CANTIDAD"].ToString(); } else { rsConMesAnterior = ""; }

                        dv = new DataView(dtCosumoHistoricoAI, "MPCCOD='" + rsCodigoEquivalente + "' AND MPCACN = " + anioJ1 + "", "", DataViewRowState.OriginalRows);
                        CAMPOFORMADO = "MPCC" + mesJ1;
                        if (dv.Count > 0) { rsCon1 = dv[0][CAMPOFORMADO].ToString(); } else { rsCon1 = ""; }
                        dv = new DataView(dtCosumoHistoricoAI, "MPCCOD='" + rsCodigoEquivalente + "' AND MPCACN = " + anioJ2 + "", "", DataViewRowState.OriginalRows);
                        CAMPOFORMADO = "MPCC" + mesJ2;
                        if (dv.Count > 0) { rsCon2 = dv[0][CAMPOFORMADO].ToString(); } else { rsCon2 = ""; }
                        dv = new DataView(dtCosumoHistoricoAI, "MPCCOD='" + rsCodigoEquivalente + "' AND MPCACN = " + anioJ3 + "", "", DataViewRowState.OriginalRows);
                        CAMPOFORMADO = "MPCC" + mesJ3;
                        if (dv.Count > 0) { rsCon3 = dv[0][CAMPOFORMADO].ToString(); } else { rsCon3 = ""; }




                        dv = new DataView(dtIngresoMesAnteriorAI, "MPICOD='" + rsCodigoEquivalente + "'", "", DataViewRowState.OriginalRows);
                        if (dv.Count > 0) { rsIngMesAnterior = dv[0]["CANTIDAD"].ToString(); } else { rsIngMesAnterior = ""; }

                        dv = new DataView(dtIngresoHistoricoAI, "MPECOD='" + rsCodigoEquivalente + "' AND MPEACN = " + anioJ1 + "", "", DataViewRowState.OriginalRows);
                        CAMPOFORMADO = "MPEC" + mesJ1;
                        if (dv.Count > 0) { rsING1 = dv[0][CAMPOFORMADO].ToString(); } else { rsING1 = ""; }
                        dv = new DataView(dtIngresoHistoricoAI, "MPECOD='" + rsCodigoEquivalente + "' AND MPEACN = " + anioJ2 + "", "", DataViewRowState.OriginalRows);
                        CAMPOFORMADO = "MPEC" + mesJ2;
                        if (dv.Count > 0) { rsING2 = dv[0][CAMPOFORMADO].ToString(); } else { rsING2 = ""; }
                        dv = new DataView(dtIngresoHistoricoAI, "MPECOD='" + rsCodigoEquivalente + "' AND MPEACN = " + anioJ3 + "", "", DataViewRowState.OriginalRows);
                        CAMPOFORMADO = "MPEC" + mesJ3;
                        if (dv.Count > 0) { rsING3 = dv[0][CAMPOFORMADO].ToString(); } else { rsING3 = ""; }




                        fila["Consumo1"] = rsConMesAnterior;
                        fila["Consumo2"] = rsCon1;
                        fila["Consumo3"] = rsCon2;
                        fila["Consumo4"] = rsCon3;

                        fila["Ingreso1"] = rsIngMesAnterior;
                        fila["Ingreso2"] = rsING1;
                        fila["Ingreso3"] = rsING2;
                        fila["Ingreso4"] = rsING3;

                        break;
                    default: 
                        break;
                }
                dtDetalle.Rows.Add(fila);
            }
            return dtDetalle;
        }




        public DataTable getConsultaMateriaPrimaFINAL(List<String> listCTAALM,DataTable dtLISTADOMP)
        {
            DataTable dtDetalle = new DataTable();
            dtDetalle.Columns.Add(new DataColumn("Codigo", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("Contable", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("Disponible", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("ReqProd", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("FechaQuiebre", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("DStck", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("agotado", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("Consumo", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("Consumo1", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("Consumo2", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("Consumo3", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("Consumo4", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("Ingreso", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("Ingreso1", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("Ingreso2", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("Ingreso3", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("Ingreso4", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("CProm", typeof(string)));
            dtDetalle.Columns.Add(new DataColumn("CuentaAlmacen", typeof(string)));

            DataView dv = new DataView();
            

            for (int i = 0; i <= listCTAALM.Count - 1; i++)
            {
                dv = new DataView(dtLISTADOMP);
                dv.RowFilter = "cuentaAlmacen = '" + listCTAALM[i].ToString() + "'";
                dv.Sort = "cuentaAlmacen ASC";                

                if (dv.Count > 0)
                {
                    DataRow fila = dtDetalle.NewRow();
                    fila["Codigo"] = ".";
                    fila["Descripcion"] = listCTAALM[i].ToString().ToUpper();

                    dtDetalle.Rows.Add(fila);
                    for (int j = 0; j <= dv.Count - 1; j++)
                    {
                        DataRow fila1 = dtDetalle.NewRow();
                        fila1["Codigo"] = dv[j]["Codigo"].ToString();
                        fila1["Descripcion"] = dv[j]["Descripcion"].ToString();
                        fila1["Contable"] = dv[j]["Contable"].ToString(); 
                        fila1["Disponible"] = dv[j]["Disponible"].ToString();
                        fila1["ReqProd"] = dv[j]["ReqProd"].ToString(); 
                        fila1["FechaQuiebre"] = dv[j]["FechaQuiebre"].ToString();
                        fila1["DStck"] = dv[j]["DStck"].ToString();
                        fila1["agotado"] = dv[j]["agotado"].ToString();
                        fila1["Consumo"] = dv[j]["Consumo"].ToString(); 
                        fila1["Consumo1"] = dv[j]["Consumo1"].ToString();
                        fila1["Consumo2"] = dv[j]["Consumo2"].ToString(); 
                        fila1["Consumo3"] = dv[j]["Consumo3"].ToString(); 
                        fila1["Consumo4"] = dv[j]["Consumo4"].ToString(); 
                        fila1["Ingreso"] = dv[j]["Ingreso"].ToString(); 
                        fila1["Ingreso1"] = dv[j]["Ingreso1"].ToString(); 
                        fila1["Ingreso2"] = dv[j]["Ingreso2"].ToString(); 
                        fila1["Ingreso3"] = dv[j]["Ingreso3"].ToString(); 
                        fila1["Ingreso4"] = dv[j]["Ingreso4"].ToString();
                        fila1["CProm"] = dv[j]["CProm"].ToString(); 
                        fila1["CuentaAlmacen"] = dv[j]["CuentaAlmacen"].ToString();
                        dtDetalle.Rows.Add(fila1);
                    }
                }
            }
            return dtDetalle;
        }




        public List<EntidadMP> ReporteMP(DataView dvMATERIAPRIMA)
        {
            List<EntidadMP> oMPs = new List<EntidadMP>();

            for (int i = 0; i <= dvMATERIAPRIMA.Count - 1; i++)
            {
                EntidadMP oMP = new EntidadMP();
                oMP.Codigo = dvMATERIAPRIMA[i]["Codigo"].ToString();
                oMP.Descripcion = dvMATERIAPRIMA[i]["Descripcion"].ToString();

                if (dvMATERIAPRIMA[i]["Contable"].ToString().Trim() != "") { oMP.Contable = Convert.ToDecimal(dvMATERIAPRIMA[i]["Contable"].ToString()); }
                else { oMP.Contable = 0; }
                if (dvMATERIAPRIMA[i]["Disponible"].ToString().Trim() != "") { oMP.Disponible = Convert.ToDecimal(dvMATERIAPRIMA[i]["Disponible"].ToString()); }
                else { oMP.Disponible = 0; }
                if (dvMATERIAPRIMA[i]["ReqProd"].ToString().Trim() != "") { oMP.ReqProd = Convert.ToDecimal(dvMATERIAPRIMA[i]["ReqProd"].ToString()); }
                else { oMP.ReqProd = 0; }
                
                oMP.FechaQuiebre = dvMATERIAPRIMA[i]["FechaQuiebre"].ToString();
                
                if (dvMATERIAPRIMA[i]["DStck"].ToString().Trim() != "") { oMP.DStck = Convert.ToDecimal(dvMATERIAPRIMA[i]["DStck"].ToString()); }
                else { oMP.DStck = 0; }

                oMP.Agotado = dvMATERIAPRIMA[i]["agotado"].ToString();

                if (dvMATERIAPRIMA[i]["Consumo"].ToString().Trim() != "") { oMP.Consumo = Convert.ToDecimal(dvMATERIAPRIMA[i]["Consumo"].ToString()); }
                else { oMP.Consumo = 0; }
                if (dvMATERIAPRIMA[i]["Consumo1"].ToString().Trim() != "") { oMP.Consumo1 = Convert.ToDecimal(dvMATERIAPRIMA[i]["Consumo1"].ToString()); }
                else { oMP.Consumo1 = 0; }
                if (dvMATERIAPRIMA[i]["Consumo2"].ToString().Trim() != "") { oMP.Consumo2 = Convert.ToDecimal(dvMATERIAPRIMA[i]["Consumo2"].ToString()); }
                else { oMP.Consumo2 = 0; }
                if (dvMATERIAPRIMA[i]["Consumo3"].ToString().Trim() != "") { oMP.Consumo3 = Convert.ToDecimal(dvMATERIAPRIMA[i]["Consumo3"].ToString()); }
                else { oMP.Consumo3 = 0; }
                if (dvMATERIAPRIMA[i]["Consumo4"].ToString().Trim() != "") { oMP.Consumo4 = Convert.ToDecimal(dvMATERIAPRIMA[i]["Consumo4"].ToString()); }
                else { oMP.Consumo4 = 0; }


                if (dvMATERIAPRIMA[i]["Ingreso"].ToString().Trim() != "") { oMP.Ingreso = Convert.ToDecimal(dvMATERIAPRIMA[i]["Ingreso"].ToString()); }
                else { oMP.Ingreso = 0; }
                if (dvMATERIAPRIMA[i]["Ingreso1"].ToString().Trim() != "") { oMP.Ingreso1 = Convert.ToDecimal(dvMATERIAPRIMA[i]["Ingreso1"].ToString()); }
                else { oMP.Ingreso1 = 0; }
                if (dvMATERIAPRIMA[i]["Ingreso2"].ToString().Trim() != "") { oMP.Ingreso2 = Convert.ToDecimal(dvMATERIAPRIMA[i]["Ingreso2"].ToString()); }
                else { oMP.Ingreso2 = 0; }
                if (dvMATERIAPRIMA[i]["Ingreso3"].ToString().Trim() != "") { oMP.Ingreso3 = Convert.ToDecimal(dvMATERIAPRIMA[i]["Ingreso3"].ToString()); }
                else { oMP.Ingreso3 = 0; }
                if (dvMATERIAPRIMA[i]["Ingreso4"].ToString().Trim() != "") { oMP.Ingreso4 = Convert.ToDecimal(dvMATERIAPRIMA[i]["Ingreso4"].ToString()); }
                else { oMP.Ingreso4 = 0; }
                if (dvMATERIAPRIMA[i]["CProm"].ToString().Trim() != "") { oMP.CProm = Convert.ToDecimal(dvMATERIAPRIMA[i]["CProm"].ToString()); }
                else { oMP.CProm = 0; }
                    

                
                oMP.CuentaAlmacen = dvMATERIAPRIMA[i]["CuentaAlmacen"].ToString();                
                oMPs.Add(oMP);
            }
            return oMPs;

        }




        /**CONSULTAS REPORTES Y OTROS**/

        public DataTable getConsultaABC(string ANIO)
        {
            return oDatTab.getConsultaABC(ANIO);

        }





        /*Consulta Consumos Almacen de ingenieria*/

        public DataTable getConsultaIngresos(DateTime mes1, DateTime mes2)
        {
            tbldetalle.Columns.Add(new DataColumn("MPICOD", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPMDES", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPIFNI", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPINNI", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPICAN", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("MPIIMP", typeof(decimal)));
            tbldetalle.Columns.Add(new DataColumn("MPINOC", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPIPRV", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("PRONOM", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPINFC", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPINGU", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPMCTA", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPMCCA", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPIPRO", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPMUNI", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("T01AL1", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPMSMX", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPMSMN", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPMSEM", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPMPRE", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPMSCO", typeof(string)));
            tbldetalle.Columns.Add(new DataColumn("MPMUBI", typeof(string)));

            DataTable dt1 = new DataTable();


            int numDias = CalcularMeses(mes1, mes2);
            for (int i = 1; i <= numDias; i++)
            {
                string mes = ""; DateTime mesxx = mes1.AddMonths(+i - 1); string dtnow = "";
                if (mesxx.Month <= 9) { mes = mesxx.Year.ToString().Substring(2, 2) + "0" + mesxx.Month.ToString(); }
                else { mes = mesxx.Year.ToString().Substring(2, 2) + mesxx.Month.ToString(); }
                if (DateTime.Now.Month <= 9) { dtnow = DateTime.Now.Year.ToString().Substring(2, 2) + "0" + DateTime.Now.Month.ToString(); }
                else { dtnow = DateTime.Now.Year.ToString().Substring(2, 2) + DateTime.Now.Month.ToString(); }
                if (mes == dtnow) { dt1 = oDatTab.getIngresoProductoACTUAL(); }
                else { dt1 = oDatTab.getIngresoProductoPASADO(mes); }
                for (int x = 0; x <= dt1.Rows.Count - 1; x++)
                {
                    DataRow fila = tbldetalle.NewRow();
                    fila["MPICOD"] = dt1.Rows[x]["MPICOD"].ToString().Trim();
                    fila["MPMDES"] = dt1.Rows[x]["MPMDES"].ToString().Trim();
                    fila["MPIFNI"] = dt1.Rows[x]["MPIFNI"].ToString().Trim();
                    fila["MPINNI"] = dt1.Rows[x]["MPINNI"].ToString().Trim();
                    fila["MPICAN"] = Convert.ToDecimal(dt1.Rows[x]["MPICAN"].ToString().Trim());
                    fila["MPIIMP"] = Convert.ToDecimal(dt1.Rows[x]["MPIIMP"].ToString().Trim());
                    fila["MPINOC"] = dt1.Rows[x]["MPINOC"].ToString().Trim();
                    fila["MPIPRV"] = dt1.Rows[x]["MPIPRV"].ToString().Trim();
                    fila["PRONOM"] = dt1.Rows[x]["PRONOM"].ToString().Trim();
                    fila["MPINFC"] = dt1.Rows[x]["MPINFC"].ToString().Trim();
                    fila["MPINGU"] = dt1.Rows[x]["MPINGU"].ToString().Trim();
                    fila["MPMCTA"] = dt1.Rows[x]["MPMCTA"].ToString().Trim();
                    fila["MPMCCA"] = dt1.Rows[x]["MPMCCA"].ToString().Trim();

                    switch (dt1.Rows[x]["MPIPRO"].ToString().Trim())
                    {
                        case "1": fila["MPIPRO"] = "Local"; break;
                        case "2": fila["MPIPRO"] = "Local-importado"; break;
                        case "3": fila["MPIPRO"] = "Importado"; break;
                        case "4": fila["MPIPRO"] = "Autoconsumo"; break;
                    }



                    //fila["MPIPRO"] = dt1.Rows[x]["MPIPRO"].ToString().Trim();


                    fila["MPMUNI"] = dt1.Rows[x]["MPMUNI"].ToString().Trim();
                    fila["T01AL1"] = dt1.Rows[x]["T01AL1"].ToString().Trim();
                    fila["MPMSMX"] = dt1.Rows[x]["MPMSMX"].ToString().Trim();
                    fila["MPMSMN"] = dt1.Rows[x]["MPMSMN"].ToString().Trim();
                    fila["MPMSEM"] = dt1.Rows[x]["MPMSEM"].ToString().Trim();
                    fila["MPMPRE"] = dt1.Rows[x]["MPMPRE"].ToString().Trim();
                    fila["MPMSCO"] = dt1.Rows[x]["MPMSCO"].ToString().Trim();
                    fila["MPMUBI"] = dt1.Rows[x]["MPMUBI"].ToString().Trim();
                    tbldetalle.Rows.Add(fila);
                }
            }
            return tbldetalle;
        }




    }
}
