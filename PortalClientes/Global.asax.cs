using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace PortalClientes
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {

        }

        void Session_Start(object sender, EventArgs e)
        {
            if (Session.IsNewSession)
            {
                HttpContext.Current.Session.Timeout = 10;
            }
            
        }

        void Session_End(object sender, EventArgs e)
        {
            Session["UserIdentity"] = null;
        }
    }
}