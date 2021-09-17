using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalClientes.Clases;

namespace PortalClientes.Views
{
    public partial class frmTuAeronave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox milabel = (TextBox)this.Master.FindControl("txtLang");
            if (milabel.Text != Utils.Idioma && milabel.Text != string.Empty)
            {
                Utils.Idioma = milabel.Text;
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmaFormulario();
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmaFormulario();
            }
        }



        #region METODOS 
        private void ArmaFormulario()
        {
            txtBusqueda.Attributes.Add("placeholder", Properties.Resources.Cm_Buscador);

            lblTitulo.Text = Properties.Resources.Ta_Titulo;
            lblTuAeronave.Text = Properties.Resources.Ta_Subtitulo;
            lblEspecificaciones.Text = Properties.Resources.Ta_TituloTab1;
            lblDocumentos.Text = Properties.Resources.Ta_TituloTab2;
            lblFabricante.Text = Properties.Resources.Ta_Fabricante;
            lblYear.Text = Properties.Resources.Ta_Anio;
            lblModelo.Text = Properties.Resources.Ta_Modelo;
            lblRegistro.Text = Properties.Resources.Ta_NoRegistro;
            lblSerie.Text = Properties.Resources.Ta_NoSerie;
            lblCapacidad.Text = Properties.Resources.Ta_Capacidad;
            lblPasajeros.Text = Properties.Resources.Ta_Pasajeros;
            lblTripulacion.Text = Properties.Resources.Ta_Tripulacion;
            lblDimencionesExt.Text = Properties.Resources.Ta_DimensionesE;
            lblDimencionesInt.Text = Properties.Resources.Ta_DimensionesI;
            lblMaxFuel.Text = Properties.Resources.Ta_MaxCombustible;
            lblMinFuel.Text = Properties.Resources.Ta_MinCombustible;
            lblVelocidad.Text = Properties.Resources.Ta_VelocidadCrucero;
            lblMaxAltura.Text = Properties.Resources.Ta_AltitudMaxima;
            lblTipoCombustible.Text = Properties.Resources.Ta_TipoCombustible;
            lblRendimiento.Text = Properties.Resources.Ta_Rendimiento;
            lblDistancia.Text = Properties.Resources.Ta_Distancia;
            lblPeso.Text = Properties.Resources.Ta_Peso;
        }

        #endregion
    }
}