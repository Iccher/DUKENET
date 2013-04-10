using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cwbx;

namespace Logistica.Ingenieria.Data
{
    public class DRPGs
    {
        cwbx.AS400System as400 = new AS400System();
        cwbx.SystemNames WSystemName = new SystemNames();
        cwbx.Program wpgm = new Program();
        cwbx.ProgramParameters Wparms = new ProgramParameters();
        cwbx.StringConverter WstrCvtr = new StringConverter();

        public int DPrograms(string user, string pass)
        {
            int sw = 0;
            try
            {
                as400 = new AS400System();
                wpgm.system = as400;
                //Extrae nombre del servidor Client Express
                as400.Define(WSystemName.DefaultSystem);
                //Ingreso de Usuario y Contraseña
                as400.UserID = user;
                as400.Password = pass;
                as400.PromptMode = cwbcoPromptModeEnum.cwbcoPromptAlways;
                as400.DefaultUserMode = cwbcoDefaultUserModeEnum.cwbcoDefaultUserIgnore;
                //logueo
                as400.Signon();

                Wparms.Clear();
                wpgm.libraryName = "LALMINGB";
                wpgm.ProgramName = "WVTF0114CL";
                wpgm.Call(Wparms);
                //desconectar los servicios
                as400.Disconnect(cwbcoServiceEnum.cwbcoServiceAll);
                sw = 2;
            }
            catch (Exception ex)
            {
                sw = 1;
            }
            return sw;
        }
    }
}
