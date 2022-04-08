using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalClientes
{
    public partial class frmDefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblBienvenido.Text = Properties.Resources.Def_Bienvenidos;
            lblEstadoDeCuenta.Text = Properties.Resources.Def_NuestraFlota;
        }
    }
}