using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NucleoBase.Core;

namespace PortalClientes.Views
{
    public partial class frmReportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["RefUrl"] = Request.UrlReferrer.ToString();
            if (System.Web.HttpContext.Current.Session["UserIdentity"] == null)
            {
                Response.Redirect("~/Views/frmFinconexion2.aspx");
            }
        }

        protected void btnDetReporte_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            string report = button.Attributes["data-report"];

            Session["reporteDetalle"] = report.I();

            Response.Redirect("frmDetalleReportes.aspx");
        }
    }
}