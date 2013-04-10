using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Logistica.Ingenieria.Data;
using Logistica.Ingenieria.Entity;

namespace Logistica.Ingenieria.Bussiness
{
    public class BReporte
    {
        DReporte oRep = new DReporte();
        public List<EReporteVALE> DListarProforma(decimal nro_VALE,string autoeje, string Despachador)
        {
            return oRep.DListarProforma(nro_VALE,autoeje, Despachador);
        }
    }
}
