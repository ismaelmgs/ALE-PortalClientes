using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalClientes.Clases;

namespace PortalClientes.Views
{
    public partial class frmFinconexion2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgSession.ImageUrl = "~/build/images/sesion_us.jpg";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "closeSession();", true);
        }
    }
}