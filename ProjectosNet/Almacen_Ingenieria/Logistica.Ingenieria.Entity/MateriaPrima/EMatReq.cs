using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logistica.Ingenieria.Entity
{
    public class EMatReq
    {
        private string cod_materia;

        public string Cod_materia
        {
            get { return cod_materia; }
            set { cod_materia = value; }
        }
        private string des_materia;

        public string Des_materia
        {
            get { return des_materia; }
            set { des_materia = value; }
        }
        private double peso_neto;

        public double Peso_neto
        {
            get { return peso_neto; }
            set { peso_neto = value; }
        }
        private string peso_merma;

        public string Peso_merma
        {
            get { return peso_merma; }
            set { peso_merma = value; }
        }
        private string peso_exed;

        public string Peso_exed
        {
            get { return peso_exed; }
            set { peso_exed = value; }
        }
        private double peso_total;

        public double Peso_total
        {
            get { return peso_total; }
            set { peso_total = value; }
        }

        private double stock;

        public double Stock
        {
            get { return stock; }
            set { stock = value; }
        }

        private double req;

        public double Req
        {
            get { return req; }
            set { req = value; }
        }

        private string cuenta;

        public string Cuenta
        {
            get { return cuenta; }
            set { cuenta = value; }
        }
        private string procedencia;

        public string Procedencia
        {
            get { return procedencia; }
            set { procedencia = value; }
        }

        private double vmpdif;

        public double Vmpdif
        {
            get { return vmpdif; }
            set { vmpdif = value; }
        }

        private double canpro;

        public double Canpro
        {
            get { return canpro; }
            set { canpro = value; }
        }
    }

}
