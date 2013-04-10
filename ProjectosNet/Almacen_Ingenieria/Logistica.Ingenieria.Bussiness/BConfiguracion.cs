using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Logistica.Ingenieria.Data;
using System.Data;

namespace Logistica.Ingenieria.Bussiness
{
    public class BConfiguracion
    {
        DConfiguracion objData = new DConfiguracion();

        public DataTable getCargaUsuarios()
        {
            return objData.getCargaUsuarios();
        }
        public DataTable getCargaAutorizaciones()
        {
            return objData.getCargaAutorizaciones();
        }
        public int BInsertUsuario(string Use, string Pwd, string cod, string nom, string fil)
        {
            return objData.DInsertUsuario(Use, Pwd, cod, nom, fil);
        }
        public int BUpdateUsuario(string Use, string Pwd, string cod, string nom, string fil)
        {
            return objData.DUpdateUsuario(Use, Pwd, cod, nom, fil);
        }
        public int BDeleteUsuario(string Use)
        {
            return objData.DDeleteUsuario(Use);
        }

        public DataTable getCargaCtaAlmacen()
        {
            return objData.getCargaCtaAlmacen();
        }

        /*********TAUTO ALMACEN DE INGENIERIA**************/
        public int BInsertAutor(string CODUSE, string NIVUSU, string CTAALM, string AREUSU)
        {
            return objData.DInsertAutor(CODUSE, NIVUSU, CTAALM, AREUSU);
        }

        public int BDeleteAutor(string CODUSE)
        {
            return objData.DDeleteAutor(CODUSE);
        }

        public DataTable getCargaAutori()
        {
            return objData.getCargaAutori();
        }

        /*OPCIONES DE MODULO*/
        public DataTable getCargaOpcionesModulo()
        {
            return objData.getCargaOpcionesModulo();
        }

        public DataTable getCargaOpcionesModuloXUsuario()
        {
            return objData.getCargaOpcionesModuloXUsuario();
        }
        public DataTable getCargaOpcionesJEFExSUPERVISOR()
        {
            return objData.getCargaOpcionesJEFExSUPERVISOR();
        }

        public DataTable getCargaOpcionesSUPERVISORXSOLICITANTE(string codSOLIC)
        {
            return objData.getCargaOpcionesSUPERVISORXSOLICITANTE(codSOLIC);
        }

        public int BInsertOpcionesxUsuario(string usuario,string opcion)
        {
            return objData.DInsertOpcionesxUsuario(usuario, opcion);
        }
        public int BDeleteOpcionesxUsuario(string usuario)
        {
            return objData.DDeleteOpcionesxUsuario(usuario);
        }

        public int BDeleteJEFATURAxSUPERVISOR(string usuario)
        {
            return objData.DDeleteJEFATURAxSUPERVISOR(usuario);
        }

        public int BInsertJEFATURAxSUPERVISOR(string usuario, string opcion)
        {
            return objData.DInsertJEFATURAxSUPERVISOR(usuario, opcion);
        }


    }
}
