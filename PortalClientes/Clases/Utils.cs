using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NucleoBase.Core;
using RestSharp;
using Newtonsoft.Json;
using System.Web.Script.Serialization;

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

        public static TokenWS ObtieneToken
        {
            get
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                CredencialesWS oCred = new CredencialesWS();
                oCred.username = Globales.GetConfigApp<string>("UsrWs");
                oCred.password = Globales.GetConfigApp<string>("PassWs");

                var client = new RestClient(Helper.UrlToken);
                var request = new RestRequest(Method.POST);
                
                request.AddJsonBody(oCred);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;

                TokenWS oToken = ser.Deserialize<TokenWS>(resp);

                return oToken;
            }
        }

    }
}