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
using System.Threading;
using System.Configuration;

namespace PortalClientes.Views
{
    public partial class frmDashboard : System.Web.UI.Page, IViewDashboard
    {
        #region EVENTOS
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["RefUrl"] = Request.Url.ToString();
            oPresenter = new Dashboard_Presenter(this, new DBDashboard());

            if (System.Web.HttpContext.Current.Session["UserIdentity"] == null)
            {
                Response.Redirect("~/Views/frmFinconexion2.aspx");
            }

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
                //string script = "alert('hola que hace');";
                //ScriptManager.RegisterStartupScript(this, typeof(Page), Guid.NewGuid().ToString(), script, true);
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
            DateTimeFormatInfo month = null;
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;

            if (Utils.Idioma == "es-MX")
            {
                month = new CultureInfo("es-ES", false).DateTimeFormat;
            }
            else
            {
                month = new CultureInfo("en-US", false).DateTimeFormat;
            }

            oDashboard = oDash;
            var fechaSalida = "";
            var fechaLlegada = "";

            if(Utils.Idioma == "es-MX")
            {
                fechaSalida = String.Format("{0} de {1} de {2} {3}", Convert.ToDateTime(oDashboard.Salida).ToString("dd"), Convert.ToDateTime(oDashboard.Salida).ToString("MMMM"), Convert.ToDateTime(oDashboard.Salida).ToString("yyyy"), Convert.ToDateTime(oDashboard.Salida).ToString("HH:mm"));
                fechaLlegada = String.Format("{0} de {1} de {2} {3}", Convert.ToDateTime(oDashboard.Llegada).ToString("dd"), Convert.ToDateTime(oDashboard.Llegada).ToString("MMMM"), Convert.ToDateTime(oDashboard.Llegada).ToString("yyyy"), Convert.ToDateTime(oDashboard.Llegada).ToString("HH:mm"));
            }
            else
            {
                fechaSalida = String.Format("{0} {1} {2} {3}", Convert.ToDateTime(oDashboard.Salida).ToString("dd"), Convert.ToDateTime(oDashboard.Salida).ToString("MMM"), Convert.ToDateTime(oDashboard.Salida).ToString("yyyy"), Convert.ToDateTime(oDashboard.Salida).ToString("HH:mm"));
                fechaLlegada = String.Format("{0} {1} {2} {3}", Convert.ToDateTime(oDashboard.Llegada).ToString("dd"), Convert.ToDateTime(oDashboard.Llegada).ToString("MMM"), Convert.ToDateTime(oDashboard.Llegada).ToString("yyyy"), Convert.ToDateTime(oDashboard.Llegada).ToString("HH:mm"));
            }

            lblOrigen.Text = oDashboard.CiudadOrigen;
            lblDestino.Text = oDashboard.CiudadDestino;
            lblOrigenText.Text = oDashboard.Origen;
            lblDestinoText.Text = oDashboard.Destino;
            lblSalidaText.Text = fechaSalida;
            lblLlegoText.Text = fechaLlegada;
            lblSaldoNumber.Text = oDashboard.saldoActualMXN.HasValue ? string.Format("{0:#,0.##}", Decimal.Round(oDashboard.saldoActualMXN.Value, 2)) : "0";
            //lblIncVenc90DiasNumber.Text = oDashboard.SaldoAlVencimiento.HasValue ? oDashboard.SaldoAlVencimiento.Value.ToString() : "0";
            lblultimaDeclaracionText.Text = oDashboard.saldoActualUSD.HasValue ? string.Format("{0:#,0.##}", Decimal.Round(oDashboard.saldoActualUSD.Value, 2)) : "0";
            //lblDeclaracionMesAno1.Text = Convert.ToDateTime(oDashboard.FechaInicioDeclaracion).ToString("dd/MM/yyyy");
            //lblDeclaracionMesAno2.Text = Convert.ToDateTime(oDashboard.FechaFinDeclaracion).ToString("dd/MM/yyyy");

            var mes = oDashboard.mesPeriodo > 0 ? textInfo.ToTitleCase(month.GetMonthName(oDashboard.mesPeriodo.Value)) : "";

            if(mes != ""){
                //lblDeclaracionPara.Text = Utils.Idioma == "es-MX" ? "Periodo al mes de " + mes + " del " + oDashboard.anioPeriodo.ToString() : "Period to " + mes + " " + oDashboard.anioPeriodo.Value.ToString();
                //lblIncVenc90Dias.Text = Utils.Idioma == "es-MX" ? "Periodo al mes de " + mes + " del " + oDashboard.anioPeriodo.ToString() : "Period to " + mes + " " + oDashboard.anioPeriodo.Value.ToString();
                lblResumenDeCuenta.Text = Utils.Idioma == "es-MX" ? "Periodo al mes de " + mes + " del " + oDashboard.anioPeriodo.ToString() + " - " : "Period to " + mes + " " + oDashboard.anioPeriodo.Value.ToString() + " - ";

            }
            else
            {
                //lblDeclaracionPara.Text = "";
                //lblIncVenc90Dias.Text = "";
                lblResumenDeCuenta.Text = "";
            }
            

            //coordenadas
            HFoLat.Value = oDashboard.aorigenLatitud != null ? oDashboard.aorigenLatitud : "0";
            HFoLon.Value = oDashboard.aorigenLongitud != null ? oDashboard.aorigenLongitud : "0";
            HFdLat.Value = oDashboard.adestinoLatitud != null ? oDashboard.adestinoLatitud : "0";
            HFdLon.Value = oDashboard.adestinoLongitud != null ? oDashboard.adestinoLongitud : "0";

            var count = 0;

            foreach(var i in oDashboard.Vuelos)
            {
                if(count == 0)
                {
                    lblMes01Vuelo.Text = i.Mes;
                    lblMes01VueloNum.Text = Convert.ToInt32(i.total).ToString();
                    barV1.Position = i.porcentaje.Value;


                    count += 1;
                }
                else if (count == 1)
                {
                    lblMes02Vuelo.Text = i.Mes;
                    lblMes02VueloNum.Text = Convert.ToInt32(i.total).ToString();
                    BarV2.Position = i.porcentaje.Value;
                    count += 1;
                }
                else if (count == 2)
                {
                    lblMes03Vuelo.Text = i.Mes;
                    lblMes03VueloNum.Text = Convert.ToInt32(i.total).ToString();
                    BarV3.Position = i.porcentaje.Value;
                    count = 0;
                }
            }

            foreach (var i in oDashboard.Horas)
            {
                if (count == 0)
                {
                    lblMes01bVuelo.Text = i.Mes;
                    lblMes01bVueloNum.Text = FormatoHora(i.total);
                    BarH1.Position = i.porcentaje.Value;

                    count += 1;
                }
                else if (count == 1)
                {
                    lblMes02bVuelo.Text = i.Mes;
                    lblMes02bVueloNum.Text = FormatoHora(i.total);
                    BarH2.Position = i.porcentaje.Value;
                    count += 1;
                }
                else if (count == 2)
                {
                    lblMes03bVuelo.Text = i.Mes;
                    lblMes03bVueloNum.Text = FormatoHora(i.total);
                    BarH3.Position = i.porcentaje.Value;
                    count = 0;
                }
            }

            foreach (var i in oDashboard.NMVuelos)
            {
                if (count == 0)
                {
                    lblMes01cVuelo.Text = i.Mes;
                    lblMes01cVueloNum.Text = Convert.ToInt32(i.total).ToString();
                    BarNM1.Position = i.porcentaje.Value;

                    count += 1;
                }
                else if (count == 1)
                {
                    lblMes02cVuelo.Text = i.Mes;
                    lblMes02cVueloNum.Text = Convert.ToInt32(i.total).ToString();
                    BarNM2.Position = i.porcentaje.Value;
                    count += 1;
                }
                else if (count == 2)
                {
                    lblMes03cVuelo.Text = i.Mes;
                    lblMes03cVueloNum.Text = Convert.ToInt32(i.total).ToString();
                    BarNM3.Position = i.porcentaje.Value;
                    count = 0;
                }
            }

            //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "initialize();", true);
        }

        private string FormatoHora(decimal? total)
        {
            var formato = "0:00";
            if (total > 0){
                var horas = total / 60;
                var minutos = total % 60;

                formato = horas > 0 ? Convert.ToInt32(Math.Truncate(horas.Value)).ToString() : "00";
                formato += minutos > 0 ? ":" + Convert.ToInt32(minutos.Value).ToString() : ":00" ;
            }

            return formato;
        }

        private void ArmarDashboard()
        {
           // txtBusqueda.Attributes.Add("placeholder", Properties.Resources.Cm_Buscador);

            lblEstadoDeVuelo.Text = Properties.Resources.Das_EstadoVuelo;
            lblSalida.Text = Properties.Resources.Das_Salida;
            lblLlego.Text = Properties.Resources.Das_Llego;
            lblCompleto.Text = Properties.Resources.Das_Completo;
            lblVuelos.Text = Properties.Resources.Das_Vuelos;
            lblHorasVuelo.Text = Properties.Resources.Das_HorasVuelo;
            lblNMVuelo.Text = Properties.Resources.Das_NMVuelo;
            lblResumenDeCuenta.Text = Properties.Resources.Das_ResumenCuenta;
            lblSaldo.Text = Properties.Resources.Das_Saldo;
            //lblIncVenc90Dias.Text = Properties.Resources.Das_Ven90dias;
            lblUltimaDeclaracion.Text = Properties.Resources.Das_UltimaDeclaracion;
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

            lblHeaderDudasAclaraciones.Text = Properties.Resources.Du_Dudas;
            lblFavorComunicarse.Text = Properties.Resources.Du_FavorCom;
            lblALTel.Text = Properties.Resources.Du_AlTel;
            var NombreAyuda = ConfigurationManager.AppSettings["NombreAyuda"];
            var TelAyuda = ConfigurationManager.AppSettings["Tel"];
            var linkTel = ConfigurationManager.AppSettings["linkTel"];
            lblNombreAyuda.Text = NombreAyuda;
            lblTel.Text = TelAyuda;
            hrefTel.HRef = linkTel;

            if (vPeriodo== "")
            {
                ddlPeriodo.SelectedIndex = 1;
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

            lblCostosCat.Text = Properties.Resources.Das_CostoCategoria + "  ";
        }

        [WebMethod(EnableSession = true)]
        public static List<responseGraficaGastos> GetGastos(string meses, string rubro, int tipoRubro)
        {
            DBDashboard oIGesCat = new DBDashboard();

            FiltroGraficaGastos fg = new FiltroGraficaGastos();
            fg.meses = meses;
            fg.fechaInicial = DateTime.Now;
            fg.fechaFinal = DateTime.Now;
            fg.rubro = 5; // modificar despues
            fg.tipoRubro = tipoRubro;

            List<responseGraficaGastos> lrg = new List<responseGraficaGastos>();
            lrg = oIGesCat.ObtenerGastos(fg);

            if ( lrg.Count() > 0 )
            {
                lrg[0].idioma = Utils.Idioma;
            }
            
            return lrg;
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

        #endregion
    }
}