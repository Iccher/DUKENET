using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logistica.Ingenieria.Entity
{
    public class EReporteVALE
    {
        //FECHA_SALIDA NUMERIC (8, 0),
        //NRO_SALIDA NUMERIC (10, 0),
        //ORDEN_TRABAJO CHAR (3),
        //AUTORIZACION_EJECUTIVA VARCHAR (7),
        //COD_DPTO CHAR (5),
        //EMPLEADO_EN CHAR (60),
        //COD_PROD CHAR (11),
        //DES_PROD CHAR (50),
        //UND_MED CHAR (30),
        //CANTIDAD DECIMAL (11, 3),
        //UBICACION CHAR (5),
        //CODAUTO NUMERIC (4, 0),
        //NOMAUTO CHAR (30),
        //CODSOLI NUMERIC (4, 0),
        //NOMSOLI CHAR (30),
        //DESPACHADOR VARCHAR (7)
        private string fECHA_SALIDA;
        public string FECHA_SALIDA
        {
            get { return fECHA_SALIDA; }
            set { fECHA_SALIDA = value; }
        }
        private string nRO_VALE_SALIDA;
        public string NRO_VALE_SALIDA
        {
            get { return nRO_VALE_SALIDA; }
            set { nRO_VALE_SALIDA = value; }
        }
        private string oRDENTRABAJO;
        public string ORDENTRABAJO
        {
            get { return oRDENTRABAJO; }
            set { oRDENTRABAJO = value; }
        }
        private string aUTORIZACION_EJECUTIVA;
        public string AUTORIZACION_EJECUTIVA
        {
            get { return aUTORIZACION_EJECUTIVA; }
            set { aUTORIZACION_EJECUTIVA = value; }
        }
        private string cOD_DPTO;
        public string COD_DPTO
        {
            get { return cOD_DPTO; }
            set { cOD_DPTO = value; }
        }
        private string eMPLEADO_EN;
        public string EMPLEADO_EN
        {
            get { return eMPLEADO_EN; }
            set { eMPLEADO_EN = value; }
        }
        private string cOD_PROD;
        public string COD_PROD
        {
            get { return cOD_PROD; }
            set { cOD_PROD = value; }
        }
        private string dES_PROD;
        public string DES_PROD
        {
            get { return dES_PROD; }
            set { dES_PROD = value; }
        }
        private string uND_MED;
        public string UND_MED
        {
            get { return uND_MED; }
            set { uND_MED = value; }
        }
        private decimal cANTIDAD;
        public decimal CANTIDAD
        {
            get { return cANTIDAD; }
            set { cANTIDAD = value; }
        }
        private string uBICACION;
        public string UBICACION
        {
            get { return uBICACION; }
            set { uBICACION = value; }
        }
        private string cOD_AUT;
        public string COD_AUT
        {
            get { return cOD_AUT; }
            set { cOD_AUT = value; }
        }
        private string nOM_AUT;
        public string NOM_AUT
        {
            get { return nOM_AUT; }
            set { nOM_AUT = value; }
        }
        private string cOD_SOL;
        public string COD_SOL
        {
            get { return cOD_SOL; }
            set { cOD_SOL = value; }
        }
        private string nOM_SOL;
        public string NOM_SOL
        {
            get { return nOM_SOL; }
            set { nOM_SOL = value; }
        }
        private string dESPACHADOR;
        public string DESPACHADOR
        {
            get { return dESPACHADOR; }
            set { dESPACHADOR = value; }
        }



        private string fECHASOLICITUD;
        public string FECHASOLICITUD
        {
            get { return fECHASOLICITUD; }
            set { fECHASOLICITUD = value; }
        }
        private string fECHAAUTORIZACION;
        public string FECHAAUTORIZACION
        {
            get { return fECHAAUTORIZACION; }
            set { fECHAAUTORIZACION = value; }
        }
        private string cODGENERADOR;
        public string CODGENERADOR
        {
            get { return cODGENERADOR; }
            set { cODGENERADOR = value; }
        }
        private string nOMGENERADOR;
        public string NOMGENERADOR
        {
            get { return nOMGENERADOR; }
            set { nOMGENERADOR = value; }
        }
        private string fECHAGENERADOR;
        public string FECHAGENERADOR
        {
            get { return fECHAGENERADOR; }
            set { fECHAGENERADOR = value; }
        }
        private string cODRECIBIDO;
        public string CODRECIBIDO
        {
            get { return cODRECIBIDO; }
            set { cODRECIBIDO = value; }
        }
        private string nOMRECIBIDO;
        public string NOMRECIBIDO
        {
            get { return nOMRECIBIDO; }
            set { nOMRECIBIDO = value; }
        }


    }
}
