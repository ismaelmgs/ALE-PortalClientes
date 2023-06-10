using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using PortalClientes.Presenter;
using PortalClientes.Clases;
using System;
using PortalClientes.Objetos;
using System.Linq;
using System.IO;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.UI;
using System.Collections.Generic;
using NucleoBase.Core;
using DevExpress.Office.Utils;

namespace PortalClientes.Views
{
    public partial class frmFlights : System.Web.UI.Page, IViewVuelos
    {
        #region EVENTOS
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["RefUrl"] = Request.Url.ToString();
            if (System.Web.HttpContext.Current.Session["UserIdentity"] == null)
            {
                Response.Redirect("~/Views/frmFinconexion2.aspx");
            }

            oPresenter = new Vuelos_Presenter(this, new DBVuelos());

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

            if (!IsPostBack)
            {
                
                LLenarVuelo();
            }
        }

        protected void DDFiltroMeses_SelectedIndexChanged(object sender, EventArgs e)
        {
            LLenarVuelo();
        }

        protected void gvVuelos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = Properties.Resources.Fl_NumTripTitle;
                e.Row.Cells[1].Text = Properties.Resources.Fl_OrigenTitle;
                e.Row.Cells[2].Text = Properties.Resources.Fl_DestinoTitle;
                e.Row.Cells[3].Text = Properties.Resources.Fl_NoPaxTitle;
                e.Row.Cells[4].Text = Properties.Resources.Fl_FechaITitle;
                e.Row.Cells[5].Text = Properties.Resources.Fl_FechaFTitle;
                e.Row.Cells[6].Text = Properties.Resources.Fl_TiempoVolTitle;
                e.Row.Cells[7].Text = Properties.Resources.Fl_DetalleTitle;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lkb = (LinkButton)e.Row.FindControl("lkbDetalle");
                lkb.Text = Properties.Resources.Fl_VerDetalle;
            }
        }

        protected void gvVuelos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "detail")
            {
                var index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gvVuelos.Rows[index];
                var numTrip = Convert.ToInt32(row.Cells[0].Text);

                Session["detVuelo"] = oDetVuelos.FirstOrDefault(i => i.tripNum == numTrip);
                Response.Redirect("~/Views/frmFlights_Detalle.aspx");
            }
        }

        protected void gvVuelos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvVuelos.PageIndex = e.NewPageIndex;
            LlenarGV();
        }

        #endregion


        #region METODOS 

        private void LlenarGV()
        {
            List<Vueloss> lVuelos = new List<Vueloss>();

            foreach (detVuelos item in oDetVuelos)
            {

                var fechaSalida = "";
                var fechaLlegada = "";

                if (Utils.Idioma == "es-MX")
                {
                    fechaSalida = item.FechaInicio.ToString("dd/MM/yyyy HH:mm");
                    fechaLlegada = item.FechaFin.ToString("dd/MM/yyyy HH:mm");
                }
                else
                {
                    fechaSalida = item.FechaInicio.ToString("MM/dd/yyyy HH:mm");
                    fechaLlegada = item.FechaFin.ToString("MM/dd/yyyy HH:mm");
                }

                Vueloss v = new Vueloss();
                v.numTrip = item.tripNum;
                v.origen = item.origen;
                v.destino = item.destino;
                v.pax = item.pax.ToString();
                v.fechaInicio = fechaSalida;
                v.fechaFin = fechaLlegada;
                v.TiempoVolado = tiempoVolado(item.FechaInicio, item.FechaFin);

                lVuelos.Add(v);
            }

            gvVuelos.DataSource = lVuelos;
            gvVuelos.DataBind();
        }

        public void LLenarVuelo()
        {
            if (eSearchObj != null)
                eSearchObj(null, EventArgs.Empty);
        }

        private void ArmaFormulario()
        {
            lblNumViajes.Text = Properties.Resources.Fl_NoViajes;
            lblNumVuelos.Text = Properties.Resources.Fl_NoVuelos;
            lblAeropuertosVisitados.Text = Properties.Resources.Fl_NoAeVisit;
            lblHorasVuelo.Text = Properties.Resources.Fl_HorasVoladas;
            lblTotalPasajeros.Text = Properties.Resources.Fl_TotalPax;
            lblFlightsDos.Text = Properties.Resources.Fl_Vuelos;

            DDFiltroMeses.Attributes.Add("onchange", "ShowLoadingPanel();");

            var v2 = DDFiltroMeses.SelectedValue;
            // llenar dropdown filtro
            DDFiltroMeses.Items.Clear();
            DDFiltroMeses.Items.Add(new ListItem(Properties.Resources.FiltroME_MA, "0"));
            DDFiltroMeses.Items.Add(new ListItem(Properties.Resources.FiltroME_1M, "1"));
            DDFiltroMeses.Items.Add(new ListItem(Properties.Resources.FiltroME_2M, "2"));
            DDFiltroMeses.Items.Add(new ListItem(Properties.Resources.FiltroME_3M, "3"));

            if (v2 == "")
            {
                DDFiltroMeses.SelectedIndex = 0;
            }
            else
            {
                DDFiltroMeses.SelectedValue = v2;
            }
        }

        public void cargarVuelos(Eventoss ov)
        {
            if(ov.detalleEventosMatriculas != null && ov.totalesEventosMatriculas != null)
            {
                iminutos = 0;
                stiempoVuelo = "";
                oVuelos = ov.totalesEventosMatriculas;
                List<Vueloss> lVuelos = new List<Vueloss>();
                //List<detVuelos> oDetVuelos = new List<detVuelos>();
                oDetVuelos = ov.detalleEventosMatriculas;

                if (oDetVuelos.Count > 0)
                {
                    foreach (detVuelos item in oDetVuelos)
                    {

                        var fechaSalida = "";
                        var fechaLlegada = "";

                        if (Utils.Idioma == "es-MX")
                        {
                            fechaSalida = item.FechaInicio.ToString("dd/MM/yyyy HH:mm");
                            fechaLlegada = item.FechaFin.ToString("dd/MM/yyyy HH:mm");
                        }
                        else
                        {
                            fechaSalida = item.FechaInicio.ToString("MM/dd/yyyy HH:mm");
                            fechaLlegada = item.FechaFin.ToString("MM/dd/yyyy HH:mm");
                        }

                        Vueloss v = new Vueloss();
                        v.numTrip = item.tripNum;
                        v.origen = item.origen;
                        v.destino = item.destino;
                        v.pax = item.pax.ToString();
                        v.fechaInicio = fechaSalida;
                        v.fechaFin = fechaLlegada;
                        v.TiempoVolado = tiempoVolado(item.FechaInicio, item.FechaFin);

                        lVuelos.Add(v);
                    }
                }


                lblNumViajesRes.Text = oVuelos.numeroTrips.Value.ToString();
                lblNumVuelosRes.Text = oVuelos.numeroVuelos.Value.ToString();
                lblAeropuertosVisitadosRes.Text = oVuelos.aeroVisitados.Value.ToString();
                lblHorasVueloRes.Text = tiempoTotal();
                lblTotalPasajerosRes.Text = oVuelos.numeroPasajeros.Value.ToString();

                gvVuelos.DataSource = lVuelos;
                gvVuelos.DataBind();
            }
            
        }

        private string tiempoVolado(DateTime fechaInicio, DateTime fechaFin)
        {
            var tiempoVuelo = "";

            TimeSpan tiempo = fechaFin - fechaInicio;
            tiempoVuelo = tiempo.ToString(@"hh\:mm");
            SumatoriaTiempos(tiempoVuelo);
            return tiempoVuelo; 
        }

        private void SumatoriaTiempos(string tiempo)
        {
            var min = 0;

            List<string> data = tiempo.Split(':').ToList();
            var entHoras = Convert.ToInt32(data[0]);
            var entMin = Convert.ToInt32(data[1]);

            min += entHoras > 0 ? entHoras * 60 : 0;
            min += entMin > 0 ? entMin : 0;

            iminutos += min;
        }

        private string tiempoTotal()
        {
            var min_a_Horas = iminutos / 60;
            var rest_min = iminutos - (min_a_Horas * 60);

            return min_a_Horas + ":" + rest_min;
        }

        #endregion

        #region VARIABLES Y PROPIEDADES

        Vuelos_Presenter oPresenter;
        public event EventHandler eNewObj;
        public event EventHandler eObjSelected;
        public event EventHandler eSaveObj;
        public event EventHandler eDeleteObj;
        public event EventHandler eSearchObj;

        public Vueloo oVuelos
        {
            get { return (Vueloo)ViewState["VSVuelo"]; }
            set { ViewState["VSVuelo"] = value; }
        }

        public List<detVuelos> oDetVuelos
        {
            get { return (List<detVuelos>)ViewState["VSDetVuelo"]; }
            set { ViewState["VSDetVuelo"] = value; }
        }

        public string stiempoVuelo
        {
            get { return (string)ViewState["VSstiempoVuelo"]; }
            set { ViewState["VSstiempoVuelo"] = value; }
        }

        public int iminutos
        {
            get { return (int)ViewState["VSiminutos"]; }
            set { ViewState["VSiminutos"] = value; }
        }

        public int iMeses
        {
            get
            {
                return DDFiltroMeses.SelectedValue.S().I();
            }
        }
        #endregion
    }
}