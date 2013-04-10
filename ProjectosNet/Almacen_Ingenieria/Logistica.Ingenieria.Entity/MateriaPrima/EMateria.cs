using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logistica.Ingenieria.Entity
{
    public class EMateria
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
        private string peso_neto;

        public string Peso_neto
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
        private string peso_total;

        public string Peso_total
        {
            get { return peso_total; }
            set { peso_total = value; }
        }
    }

}
