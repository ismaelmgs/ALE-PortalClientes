using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using PortalClientes.Presenter;
using PortalClientes.Clases;
using System;
using System.Web.UI.WebControls;
using PortalClientes.Objetos;
using NucleoBase.Core;
using System.Web.Services;
using System.Collections.Generic;
using System.Web;

namespace PortalClientes.Views
{
    public partial class frmMapaflota : System.Web.UI.Page, IViewMapaFlota
    {
        #region EVENTOS
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["RefUrl"] = Request.Url.ToString();
            if (System.Web.HttpContext.Current.Session["UserIdentity"] == null)
            {
                Response.Redirect("~/Views/frmFinconexion2.aspx");
            }

            oPresenter = new MapaFlota_Presenter(this, new DBMapaFlota());

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

            //if (!IsPostBack)
            //{
            //    LLenarFlota();
            //}
        }


        #endregion

        #region METODOS 

        private void LLenarFlota()
        {
            if (eSearchObj != null)
                eSearchObj(null, EventArgs.Empty);
        }

        public void cargarMapaFlota(MapaFlota oMapaFlota)
        {
            //oFlota = oMapaFlota;
            //Session["detRutas"] = oFlota.detalleRutas;
            //Session["detAeropuertos"] = oFlota.detalleAeropuertos;

            //lblVuelosRes.Text = oFlota.detalleTotalVuelos.numeroVuelos.S();
            //lblHorasVueloRes.Text = oFlota.detalleTotalVuelos.tiempoVolado.S();
            //lblAeropuertosRes.Text = oFlota.detalleTotalVuelos.numAeropuertos.S();
            //lblMiVueloRes.Text = oFlota.detalleTotalVuelos.distanciaVolada.S();

        }

        private void ArmaFormulario()
        {
            lblLocacion.Text = Properties.Resources.MF_Aeropuerto;
            lblRutas.Text = Properties.Resources.MF_Rutas;
            lblPeriodo.Text = Properties.Resources.MF_Periodo;
            lblAeronave.Text = Properties.Resources.MF_Aeronave;
            lblFuenteDatos.Text = Properties.Resources.MF_FuenteDatos;
            //lblTiposVuelo.Text = Properties.Resources.MF_TVuelo;
            lblVuelos.Text = Properties.Resources.MF_Vuelos;
            lblHorasVuelo.Text = Properties.Resources.MF_HVoladas;
            lblAeropuertos.Text = Properties.Resources.MF_Aeropuerto;
            lblMiVuelo.Text = Properties.Resources.MF_Distancia;
            //lblRutass.Text = Properties.Resources.MF_Rutas;
            //lblMultiple.Text = Properties.Resources.MF_Multiple;
            //lblPropietarioTerceros.Text = Properties.Resources.MF_PropietarioTercero;
            //lblPropietarioPrincipal.Text = Properties.Resources.MF_PropietarioPpl;
            //lblTiposRutas.Text = Properties.Resources.MF_TRuta;
            lblEstadosVuelos.Text = Properties.Resources.MF_EstadoVuelos;

            var v2 = ddlMeses.SelectedValue;
            // llenar dropdown filtro
            ddlMeses.Items.Clear();
            ddlMeses.Items.Add(new ListItem(Properties.Resources.FiltroME_3M, "3"));
            ddlMeses.Items.Add(new ListItem(Properties.Resources.FiltroME_6M, "6"));
            ddlMeses.Items.Add(new ListItem(Properties.Resources.FiltroME_12M, "12"));

            if (v2 == "")
            {
                ddlMeses.SelectedIndex = 0;
            }
            else
            {
                ddlMeses.SelectedValue = v2;
            }

            var v3 = ddlAeronave.SelectedValue;
            ddlAeronave.Items.Clear();
            foreach (var item in Utils.Matriculas)
            {
                ddlAeronave.Items.Add(new ListItem(item, item));
            }

            if (v3 == "")
            {
                ddlAeronave.SelectedIndex = 0;
            }
            else
            {
                ddlAeronave.SelectedValue = v3;
            }
        }

        [WebMethod]
        public static MapaFlota getDataMap(string meses, string matricula)
        {
            try
            {
                DBMapaFlota oIGesCat = new DBMapaFlota();

                MapaFlota lrg = new MapaFlota();
                lrg = oIGesCat.obtenerFlota(Convert.ToInt32(meses), matricula);

                return lrg;
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        #endregion

        #region VARIABLES Y PROPIEDADES

        MapaFlota_Presenter oPresenter;
        public event EventHandler eNewObj;
        public event EventHandler eObjSelected;
        public event EventHandler eSaveObj;
        public event EventHandler eDeleteObj;
        public event EventHandler eSearchObj;

        public int iMeses
        {
            get
            {
                return ddlMeses.SelectedValue.S().I();
            }
        }

        public string sMatricula
        {
            get
            {
                return ddlAeronave.SelectedItem.Text.S();
            }
        }

        public MapaFlota oFlota
        {
            get { return (MapaFlota)ViewState["VSoFlota"]; }
            set { ViewState["VSoFlota"] = value; }
        }
        #endregion
    }
}