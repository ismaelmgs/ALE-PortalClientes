using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalClientes.Clases;



namespace PortalClientes
{
    public partial class frmDefault : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["RefUrl"] = Request.Url.ToString();
            if (System.Web.HttpContext.Current.Session["UserIdentity"] == null)
            {
                Response.Redirect("~/Views/frmFinconexion2.aspx");
            }

            TextBox milabel = (TextBox)this.Master.FindControl("txtLang");
            if (milabel.Text != Utils.Idioma && milabel.Text != string.Empty)
            {
                Utils.Idioma = milabel.Text;
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmarDefault();
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmarDefault();
            }
           
        }

        private void ArmarDefault()
        {
            lblBienvenido.Text = Properties.Resources.Def_Bienvenidos;
            lblEstadoDeCuenta.Text = Properties.Resources.Def_NuestraFlota;
        }
    }
}