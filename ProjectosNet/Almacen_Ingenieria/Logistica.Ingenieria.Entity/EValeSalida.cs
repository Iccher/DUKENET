using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logistica.Ingenieria.Entity
{
    public class EValeSalida
    {
        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        private string userID;
        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        private decimal fechaModif;
        public decimal FechaModif
        {
            get { return fechaModif; }
            set { fechaModif = value; }
        }
        private decimal horaMin;
        public decimal HoraMin
        {
            get { return horaMin; }
            set { horaMin = value; }
        }
        private decimal nroVale;
        public decimal NroVale
        {
            get { return nroVale; }
            set { nroVale = value; }
        }
        private decimal item;
        public decimal Item
        {
            get { return item; }
            set { item = value; }
        }
        private decimal tipoSalida;
        public decimal TipoSalida
        {
            get { return tipoSalida; }
            set { tipoSalida = value; }
        }
        private decimal fechaSalidad;
        public decimal FechaSalidad
        {
            get { return fechaSalidad; }
            set { fechaSalidad = value; }
        }
        private decimal turno;
        public decimal Turno
        {
            get { return turno; }
            set { turno = value; }
        }

        private decimal codArea;
        public decimal CodArea
        {
            get { return codArea; }
            set { codArea = value; }
        }
        private decimal codAutoriza;
        public decimal CodAutoriza
        {
            get { return codAutoriza; }
            set { codAutoriza = value; }
        }
        private decimal codSolicita;
        public decimal CodSolicita
        {
            get { return codSolicita; }
            set { codSolicita = value; }
        }
        private string codMateriaPrima;
        public string CodMateriaPrima
        {
            get { return codMateriaPrima; }
            set { codMateriaPrima = value; }
        }
        private decimal ctaCargo;
        public decimal CtaCargo
        {
            get { return ctaCargo; }
            set { ctaCargo = value; }
        }
        private decimal procedencia;
        public decimal Procedencia
        {
            get { return procedencia; }
            set { procedencia = value; }
        }
        private decimal ctaAlmacen;
        public decimal CtaAlmacen
        {
            get { return ctaAlmacen; }
            set { ctaAlmacen = value; }
        }
        private decimal cantidad;
        public decimal Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
        private decimal importeS;
        public decimal ImporteS
        {
            get { return importeS; }
            set { importeS = value; }
        }
        private decimal importeD;
        public decimal ImporteD
        {
            get { return importeD; }
            set { importeD = value; }
        }
        private decimal orderTrabajo;
        public decimal OrderTrabajo
        {
            get { return orderTrabajo; }
            set { orderTrabajo = value; }
        }
        private decimal codRecibe;
        public decimal CodRecibe
        {
            get { return codRecibe; }
            set { codRecibe = value; }
        }
        private string tipoAlmacen;
        public string TipoAlmacen
        {
            get { return tipoAlmacen; }
            set { tipoAlmacen = value; }
        }    
    }
}
