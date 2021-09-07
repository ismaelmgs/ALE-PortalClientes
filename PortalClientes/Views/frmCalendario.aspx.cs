using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalClientes.Views
{
    public partial class frmCalendario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAlerta2_Click(object sender, EventArgs e)
        {
            MostrarMensaje("Mensaje de exito!", "Aviso");
        }

        public void MostrarMensaje(string sMensaje, string sCaption)
        {
            sMensaje = "alertexito('" + sMensaje + "');";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alertexito", sMensaje, true);
        }
    }
}