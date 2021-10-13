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
using System.Web.Services;
using System.Web.Script.Services;
using System.Globalization;

namespace PortalClientes.Views
{
    public partial class frmMetricasEstadisticas : System.Web.UI.Page
    {
        #region EVENTOS
        protected void Page_Load(object sender, EventArgs e)
        {
            //oPresenter = new Dashboard_Presenter(this, new DBDashboard());

            TextBox milabel = (TextBox)this.Master.FindControl("txtLang");
            if (milabel.Text != Utils.Idioma && milabel.Text != string.Empty)
            {
                Utils.Idioma = milabel.Text;
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmarMetricasEstadisticas();
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmarMetricasEstadisticas();
            }

            if (!IsPostBack)
            {
                //LlenarDashboard();
            }
        }

        #endregion

        #region METODOS

        public void LlenarMetricasEstadisticas()
        {
            if (eSearchObj != null)
                eSearchObj(null, EventArgs.Empty);
        }

        private void ArmarMetricasEstadisticas()
        {
            txtBusqueda.Attributes.Add("placeholder", Properties.Resources.Cm_Buscador);

            //lblEstadoDeVuelo.Text = Properties.Resources.Das_EstadoVuelo;
            //lblSalida.Text = Properties.Resources.Das_Salida;
            //lblLlego.Text = Properties.Resources.Das_Llego;
            //lblCompleto.Text = Properties.Resources.Das_Completo;
            //lblVuelos.Text = Properties.Resources.Das_Vuelos;
            //lblHorasVuelo.Text = Properties.Resources.Das_HorasVuelo;
            //lblNMVuelo.Text = Properties.Resources.Das_NMVuelo;
            //lblResumenDeCuenta.Text = Properties.Resources.Das_ResumenCuenta;
            //lblSaldo.Text = Properties.Resources.Das_Saldo;
            //lblIncVenc90Dias.Text = Properties.Resources.Das_Ven90dias;
            //lblUltimaDeclaracion.Text = Properties.Resources.Das_UltimaDeclaracion;
            //lblDeclaracionPara.Text = Properties.Resources.Das_DeclaracionPara;
            //lblVence.Text = Properties.Resources.Das_Vence;

            var vPeriodo = ddlPeriodo.SelectedValue;
            // llenar dropdown Periodo
            ddlPeriodo.Items.Clear();
            ddlPeriodo.Items.Add(new ListItem(Properties.Resources.Das_Manual, "0"));
            ddlPeriodo.Items.Add(new ListItem(Properties.Resources.Das_Mensual, "1"));
            ddlPeriodo.Items.Add(new ListItem(Properties.Resources.Das_Trimestral, "3"));
            ddlPeriodo.Items.Add(new ListItem(Properties.Resources.Das_Semestral, "6"));
            ddlPeriodo.Items.Add(new ListItem(Properties.Resources.Das_Anual, "12"));

            if (vPeriodo == "")
            {
                ddlPeriodo.SelectedIndex = 3;
            }
            else
            {
                ddlPeriodo.SelectedValue = vPeriodo;
            }

            var vTR = ddlTipoRubro.SelectedValue;
            // llenar dropdown Tipo Rubro
            ddlTipoRubro.Items.Clear();
            ddlTipoRubro.Items.Add(new ListItem(Properties.Resources.Das_Fijo, "1"));
            ddlTipoRubro.Items.Add(new ListItem(Properties.Resources.Das_Variable, "2"));
            ddlTipoRubro.Items.Add(new ListItem(Properties.Resources.Das_Todos, "3"));

            if (vPeriodo == "")
            {
                ddlTipoRubro.SelectedIndex = 2;
            }
            else
            {
                ddlTipoRubro.SelectedValue = vTR;
            }

            //lblCostosCat.Text = Properties.Resources.Das_CostoCategoria;
        }

        [WebMethod]
        public static List<responseGraficaGastos> GetGastos(string meses, DateTime? fechaInicial, DateTime? fechaFinal, string rubro, int tipoRubro)
        {
            DBDashboard oIGesCat = new DBDashboard();

            FiltroGraficaGastos fg = new FiltroGraficaGastos();
            fg.meses = meses;
            fg.fechaInicial = fechaInicial;
            fg.fechaFinal = fechaFinal;
            fg.rubro = 5; // modificar despues
            fg.tipoRubro = tipoRubro;

            List<responseGraficaGastos> lrg = new List<responseGraficaGastos>();
            lrg = oIGesCat.ObtenerGastos(fg);

            if (lrg.Count() > 0)
            {
                lrg[0].idioma = Utils.Idioma;
            }

            return lrg;
        }
        #endregion

        #region VARIABLES Y PROPIEDADES

        public event EventHandler eSearchObj;

        #endregion
    }
}