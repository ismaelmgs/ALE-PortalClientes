using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalClientes.Clases;
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
            TextBox milabel = (TextBox)this.Master.FindControl("txtLang");
            if (milabel.Text != Utils.Idioma && milabel.Text != string.Empty)
            {
                Utils.Idioma = milabel.Text;
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmaReportes();
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmaReportes();
            }

        }

        protected void btnDetReporte_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            string report = button.Attributes["data-report"];
            string rpt = button.Attributes["data-rpt"];

            Session["reporteDetalle"] = report.I();
            Session["isRpt"] = rpt.I();

            Response.Redirect("frmDetalleReportes.aspx");
        }

        private void ArmaReportes()
        {
            lblReportesFijosVariables.Text = Properties.Resources.Re_TituloRep;
            lblReportesFijosVar.Text = Properties.Resources.Re_SeccionGatoFijoVariable;
            lblRepGastosFijosVariables.Text = Properties.Resources.Re_GastosFijoVariable;
            lblRepGastosAeropuerto.Text = Properties.Resources.Re_GastosAeropuerto;
            lblRepGastosProveedor.Text = Properties.Resources.Re_GastosProveedor;
            lblResumenGastosVuelos.Text = Properties.Resources.Re_ResumenGastosVuelos;
            lblDetalleGastosVuelos.Text = Properties.Resources.Re_DetalleGastosVuelos;
        }
    }
}