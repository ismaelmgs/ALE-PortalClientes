using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalClientes.Views
{
    public partial class frmErrorconexion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegresarLogin_Click(object sender, EventArgs e)
        {
            object refUrl = Session["RefUrl"];
            if (refUrl != null)
                Response.Redirect((string)refUrl);
        }
    }
}