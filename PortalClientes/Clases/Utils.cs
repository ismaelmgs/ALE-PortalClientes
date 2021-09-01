using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NucleoBase.Core;

namespace PortalClientes.Clases
{
    public static class Utils
    {
        public static string Idioma
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["Idioma"] == null)
                    System.Web.HttpContext.Current.Session["Idioma"] = "es-MX";

                //if (System.Web.HttpContext.Current.Session["UserIdentity"] == null)
                //{
                //    UserIdentity oUsuario = new UserIdentity();
                //    oUsuario.sIdioma = System.Web.HttpContext.Current.Session["Idioma"].S();
                //    System.Web.HttpContext.Current.Session["UserIdentity"] = oUsuario;
                //}
                //else
                //{
                //    UserIdentity oUsuario = (UserIdentity)System.Web.HttpContext.Current.Session["UserIdentity"];
                //    oUsuario.sIdioma = System.Web.HttpContext.Current.Session["Idioma"].S();
                //    System.Web.HttpContext.Current.Session["UserIdentity"] = oUsuario;
                //}

                return System.Web.HttpContext.Current.Session["Idioma"].S();
            }
            set
            {
                //if (System.Web.HttpContext.Current.Session["UserIdentity"] == null)
                //{
                //    UserIdentity oUsuario = new UserIdentity();
                //    oUsuario.sIdioma = "es-MX";
                //    System.Web.HttpContext.Current.Session["UserIdentity"] = oUsuario;
                //}

                System.Web.HttpContext.Current.Session["Idioma"] = value;
            }
        }

        public static string ResxPlaceholder
        {
            get
            {
                return Properties.Resources.Us_ApeMat;
            }
        }

        public static int GetIdEmpUsuario
        {
            get
            {
                if (System.Web.HttpContext.Current.Session["UserIdentity"] == null)
                {
                    UserIdentity oUsuario = new UserIdentity();
                    oUsuario.iIdUsuario = 1;
                    System.Web.HttpContext.Current.Session["UserIdentity"] = oUsuario;
                }

                return ((UserIdentity)System.Web.HttpContext.Current.Session["UserIdentity"]).iIdUsuario;
            }
        }
    }
}