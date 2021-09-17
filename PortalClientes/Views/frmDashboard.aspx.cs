using PortalClientes.Objetos;
using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using PortalClientes.Presenter;
using PortalClientes.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalClientes.Views
{
    public partial class frmDashboard : System.Web.UI.Page, IViewDashboard
    {
        #region EVENTOS
        protected void Page_Load(object sender, EventArgs e)
        {
            oPresenter = new Dashboard_Presenter(this, new DBDashboard());

            TextBox milabel = (TextBox)this.Master.FindControl("txtLang");
            if (milabel.Text != Utils.Idioma && milabel.Text != string.Empty)
            {
                Utils.Idioma = milabel.Text;
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmarDashboard();
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmarDashboard();
            }
            
            if (!IsPostBack)
            {
                lblMatriculaAeronave.Text = Utils.MatriculaActual;
                LlenarDashboard();
            }
            
        }
        #endregion


        #region METODOS

        public void LlenarDashboard()
        {
            if (eSearchObj != null)
                eSearchObj(null, EventArgs.Empty);
        }

        public void CargarDashboard(Dashboard oDash)
        {
            oDashboard = oDash;

            lblOrigenText.Text = oDashboard.Origen;
            lblDestinoText.Text = oDashboard.Destino;
            lblSalidaText.Text = oDashboard.Salida.ToLongDateString();
            lblLlegoText.Text = oDashboard.Llegada.ToLongDateString();
            lblSaldoNumber.Text = oDashboard.SaldoActual.ToString();
            lblIncVenc90DiasNumber.Text = oDashboard.SaldoAlVencimiento.ToString();
            lblultimaDeclaracionText.Text = oDashboard.SaldoUltimaDeclaracion.ToString();
            lblDeclaracionMesAno1.Text = oDashboard.FechaInicioDeclaracion.ToShortDateString();
            lblDeclaracionMesAno2.Text = oDashboard.FechaFinDeclaracion.ToShortDateString();
        }

        private void ArmarDashboard()
        {
            txtBusqueda.Attributes.Add("placeholder", Properties.Resources.Cm_Buscador);

            lblEstadoDeVuelo.Text = Properties.Resources.Das_EstadoVuelo;
            lblOrigen.Text = Properties.Resources.Das_Origen;
            lblDestino.Text = Properties.Resources.Das_Destino;
            lblSalida.Text = Properties.Resources.Das_Salida;
            lblLlego.Text = Properties.Resources.Das_Llego;
            lblCompleto.Text = Properties.Resources.Das_Completo;
            lblVuelos.Text = Properties.Resources.Das_Vuelos;
            lblHorasVuelo.Text = Properties.Resources.Das_HorasVuelo;
            lblNMVuelo.Text = Properties.Resources.Das_NMVuelo;
            lblResumenDeCuenta.Text = Properties.Resources.Das_ResumenCuenta;
            lblSaldo.Text = Properties.Resources.Das_Saldo;
            lblIncVenc90Dias.Text = Properties.Resources.Das_Ven90dias;
            lblUltimaDeclaracion.Text = Properties.Resources.Das_UltimaDeclaracion;
            lblDeclaracionPara.Text = Properties.Resources.Das_DeclaracionPara;
            lblVence.Text = Properties.Resources.Das_Vence;
        }

        #endregion


        #region VARIABLES Y PROPIEDADES

        Dashboard_Presenter oPresenter;
        public event EventHandler eNewObj;
        public event EventHandler eObjSelected;
        public event EventHandler eSaveObj;
        public event EventHandler eDeleteObj;
        public event EventHandler eSearchObj;

        public Dashboard oDashboard
        {
            get { return (Dashboard)ViewState["VSDashboard"]; }
            set { ViewState["VSDashboard"] = value; }
        }

        public string sMatricula
        {
            get
            {
                return lblMatriculaAeronave.Text;
            }
        }

        #endregion
    }
}