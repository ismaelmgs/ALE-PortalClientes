using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Clases
{
    public class Helper_Mensajes
    {
        public string DevuelveMensajeError(string sCodigoError)
        {
            string sIdioma = Utils.Idioma;
            string sMensaje = string.Empty;
            switch (sCodigoError)
            {
                case "9999":
                    switch (sIdioma)
                    {
                        case "es-MX":
                            sMensaje = "El usuario y contraseña no existen.";
                            break;
                        case "en-US":
                            sMensaje = "";
                            break;
                    }
                    break;
            }

            return sMensaje;
        }
    }
}