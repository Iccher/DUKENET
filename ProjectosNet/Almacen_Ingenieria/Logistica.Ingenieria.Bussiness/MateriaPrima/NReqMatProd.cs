using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Logistica.Ingenieria.Entity;
using Logistica.Ingenieria.Data;
using System.Data;


namespace Logistica.Ingenieria.Bussiness
{
    public class NReqMatProd
    {
        Data.DReqMatProd obj = new DReqMatProd();
        public List<EPrograma> LstPrograma(string fecha)
        {
            return obj.LstPrograma(fecha);
        }

        public BindingList<EMateria> LstPrograma(string producto, string cantidad)
        {
            return obj.Descomposicion(producto, cantidad);
        }

        //LENADO DE GRILLA CON LA DESCOMPOSICION

        public BindingList<EMateria> Llenado(string fecha)
        {
            List<EPrograma> programa = new List<EPrograma>();
            BindingList<EMateria> materia = new BindingList<EMateria>();
            BindingList<EMateria> materiales = new BindingList<EMateria>();
            EMateria mat = new EMateria();

            programa = obj.LstPrograma(fecha);

            for (int i = 0; i <= programa.Count - 1; i++)
            {
                materia = new BindingList<EMateria>();
                materia = obj.Descomposicion(programa[i].Codigo.ToString(), programa[i].Prog.ToString());

                for (int j = 0; j <= materia.Count - 1; j++)
                {
                    mat = new EMateria();

                    mat.Cod_materia = materia[j].Cod_materia.ToString();
                    mat.Des_materia = materia[j].Des_materia.ToString();
                    mat.Peso_neto = materia[j].Peso_neto.ToString();
                    mat.Peso_merma = materia[j].Peso_merma.ToString();
                    mat.Peso_exed = materia[j].Peso_exed.ToString();
                    mat.Peso_total = materia[j].Peso_total.ToString();
                    materiales.Add(mat);
                }
            }
            return materiales;
        }

       public BindingList<EMatReq> rqMat(BindingList<EMateria> grid)
       {
           List<EVmp02> vmp = new List<EVmp02>();
           vmp = obj.LstVmp02A();
           List<EMateriaPrima> matP=new List<EMateriaPrima>();
           matP=obj.LstStockMP();
           BindingList<EMatReq> matRs = new BindingList<EMatReq>();
           EMatReq matR = new EMatReq();

           for (int i = 0; i <= grid.Count - 1; i++)
           {
               matR = new EMatReq();
               matR.Cod_materia = grid[i].Cod_materia.ToString();
               matR.Des_materia = grid[i].Des_materia.ToString();
               matR.Peso_neto = Convert.ToDouble(grid[i].Peso_neto.ToString());
               matR.Peso_merma = grid[i].Peso_merma.ToString();
               matR.Peso_exed = grid[i].Peso_exed.ToString();
               matR.Canpro = Convert.ToDouble(grid[i].Peso_total.ToString());
               for (int j = 0; j <= matP.Count - 1; j++)
               {
                   if (grid[i].Cod_materia.ToString() == matP[j].Mpmcod.ToString())
                   {
                       matR.Stock = Convert.ToDouble(matP[j].Mpmsdi.ToString());
                       matR.Cuenta = matP[j].Mpmcta.ToString();
                       matR.Procedencia = matP[j].Mpmpro.ToString();
                   }
               }
               if (vmp.Count > 0)
               {
                   for (int t = 0; t <= vmp.Count - 1; t++)
                   {
                       if (grid[i].Cod_materia.ToString() == vmp[t].Vmpcod.ToString())
                       {
                           matR.Vmpdif = Convert.ToDouble(vmp[t].Vmpdif.ToString());
                           matR.Peso_total = Convert.ToDouble(grid[i].Peso_total.ToString()) - Convert.ToDouble(vmp[t].Vmpdif.ToString());
                           matR.Req = Convert.ToDouble(grid[i].Peso_total.ToString()) - Convert.ToDouble(vmp[t].Vmpdif.ToString());
                       }
                       else
                       {
                           matR.Vmpdif = 0;
                           matR.Peso_total = Convert.ToDouble(grid[i].Peso_total.ToString());
                           matR.Req = Convert.ToDouble(grid[i].Peso_total.ToString());
                       }
                       if (matR.Vmpdif > 0)
                       {
                           break;
                       }
                   }
               }
               else
               {
                   matR.Vmpdif = 0;
                   matR.Peso_total = Convert.ToDouble(grid[i].Peso_total.ToString());
                   matR.Req = Convert.ToDouble(grid[i].Peso_total.ToString());
               }
               
               matRs.Add(matR);
           }

           return matRs;
       }

       public DataTable LstTrabajadores()
       {
           return obj.LstTrabajadores();
       }

       public List<EVale> LstValeNro()
       {
           return obj.LstValeNro();
       }

       public int insAlmvsal(string usuario, string fechaS, string hora, string nrovale, string nit, string fechaV, string turno, string autoriz, string solic, string materia, string procedencia, string cuenta, string cantidad)
       {
           return obj.insAlmvsal(usuario, fechaS, hora, nrovale, nit, fechaV, turno, autoriz, solic, materia, procedencia, cuenta, cantidad);
       }

       public int updNroVale(string nro)
       {
           return obj.updNroVale(nro);
       }

       public int updStockMP(string cantidad, string codigo)
       {
           return obj.updStockMP(cantidad, codigo);
       }

       public int insRegPed(string usuario, string fecha, string fecPed, string codigo, string cantidadR, string cantidadD, string tipo)
       {
           return obj.insRegPed(usuario, fecha, fecPed, codigo, cantidadR, cantidadD, tipo);
       }

       public List<EAlmvPed> LstRegPed(string fecha, string codigo, string tipo)
       {
           return obj.LstRegPed(fecha, codigo, tipo);
       }

       public int insVmp02(string codigo, string saldo, string canreq, string candes, string dif)
       {
           return obj.insVmp02(codigo, saldo, canreq, candes, dif);
       }

       public int updVmp02(string candes, string canreq, string codigo)
       {
           return obj.updVmp02(candes, canreq, codigo);
       }

       public DataTable LstVmp02(string codigo)
       {
           return obj.LstVmp02(codigo);
       }

       public List<EMateriaPrima> LstStockMP()
       {
           return obj.LstStockMP();
       }

       public DataTable LstMP()
       {
           return obj.LstMP();
       }

       public List<EVmp02> LstVmp02A()
       {
           return obj.LstVmp02A();
       }

       public List<EReporteVALE> DListarProforma(string nro_VALE)
       {
           return obj.DListarProforma(nro_VALE);
       }
    }
}
