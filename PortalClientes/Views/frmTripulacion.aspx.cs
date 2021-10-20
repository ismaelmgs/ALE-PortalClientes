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
    public partial class frmTripulacion : System.Web.UI.Page, IViewTripulacion
    {
        #region EVENTOS
        protected void Page_Load(object sender, EventArgs e)
        {
            oPresenter = new Tripulacion_Presenter(this, new DBTripulacion());

            TextBox milabel = (TextBox)this.Master.FindControl("txtLang");
            if (milabel.Text != Utils.Idioma && milabel.Text != string.Empty)
            {
                Utils.Idioma = milabel.Text;
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmarTripulacion();
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmarTripulacion();
            }

            if (!IsPostBack)
            {
                LlenarTripulacion();
            }
        }

        #endregion

        #region METODOS

        public void LlenarTripulacion()
        {
            if (eSearchObj != null)
                eSearchObj(null, EventArgs.Empty);
        }

        private void ArmarTripulacion()
        {
            txtBusqueda.Attributes.Add("placeholder", Properties.Resources.Cm_Buscador);

        //    lblEstadoDeVuelo.Text = Properties.Resources.Das_EstadoVuelo;
        //    lblSalida.Text = Properties.Resources.Das_Salida;
        //    lblLlego.Text = Properties.Resources.Das_Llego;
        //    lblCompleto.Text = Properties.Resources.Das_Completo;
        //    lblVuelos.Text = Properties.Resources.Das_Vuelos;
        //    lblHorasVuelo.Text = Properties.Resources.Das_HorasVuelo;
        //    lblNMVuelo.Text = Properties.Resources.Das_NMVuelo;
        //    lblResumenDeCuenta.Text = Properties.Resources.Das_ResumenCuenta;
        //    lblSaldo.Text = Properties.Resources.Das_Saldo;
        //    lblIncVenc90Dias.Text = Properties.Resources.Das_Ven90dias;
        //    lblUltimaDeclaracion.Text = Properties.Resources.Das_UltimaDeclaracion;
        //    lblDeclaracionPara.Text = Properties.Resources.Das_DeclaracionPara;
        //    lblVence.Text = Properties.Resources.Das_Vence;

        //    var vPeriodo = ddlPeriodo.SelectedValue;
        //    // llenar dropdown Periodo
        //    ddlPeriodo.Items.Clear();
        //    ddlPeriodo.Items.Add(new ListItem(Properties.Resources.Das_Manual, "0"));
        //    ddlPeriodo.Items.Add(new ListItem(Properties.Resources.Das_Mensual, "1"));
        //    ddlPeriodo.Items.Add(new ListItem(Properties.Resources.Das_Trimestral, "3"));
        //    ddlPeriodo.Items.Add(new ListItem(Properties.Resources.Das_Semestral, "6"));
        //    ddlPeriodo.Items.Add(new ListItem(Properties.Resources.Das_Anual, "12"));

        //    if (vPeriodo == "")
        //    {
        //        ddlPeriodo.SelectedIndex = 3;
        //    }
        //    else
        //    {
        //        ddlPeriodo.SelectedValue = vPeriodo;
        //    }

        //    var vTR = ddlTipoRubro.SelectedValue;
        //    // llenar dropdown Tipo Rubro
        //    ddlTipoRubro.Items.Clear();
        //    ddlTipoRubro.Items.Add(new ListItem(Properties.Resources.Das_Fijo, "1"));
        //    ddlTipoRubro.Items.Add(new ListItem(Properties.Resources.Das_Variable, "2"));
        //    ddlTipoRubro.Items.Add(new ListItem(Properties.Resources.Das_Todos, "3"));

        //    if (vPeriodo == "")
        //    {
        //        ddlTipoRubro.SelectedIndex = 2;
        //    }
        //    else
        //    {
        //        ddlTipoRubro.SelectedValue = vTR;
        //    }

        //    lblCostosCat.Text = Properties.Resources.Das_CostoCategoria;
        }

        public void CargarEventosTripulacion(List<EventosPiloto> oEP)
        {
            oLstEventosPiloto = oEP;
            gvEventos.DataSource = oEP;
            gvEventos.DataBind();
        }

        public void CargarPilotosTripulacion(List<Piloto> oPT)
        {
            oLstPilotos = oPT;
            gvPilotos.DataSource = oPT;
            gvPilotos.DataBind();
        }

        private void LlenaGridEventosLocal()
        {
            gvEventos.DataSource = oLstEventosPiloto;
            gvEventos.DataBind();
        }

        private void LlenaGridPilotosLocal()
        {
            gvPilotos.DataSource = oLstPilotos;
            gvPilotos.DataBind();
        }

        protected void gvEventos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvEventos.PageIndex = e.NewPageIndex;
            LlenaGridEventosLocal();
        }

        protected void gvEventos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = Properties.Resources.TabEventTri_FechaInicio;
                e.Row.Cells[1].Text = Properties.Resources.TabEventTri_FechaFin;
                e.Row.Cells[2].Text = Properties.Resources.TabEventTri_CodPiloto;
                e.Row.Cells[3].Text = Properties.Resources.TabEventTri_MiembroTri;
                e.Row.Cells[4].Text = Properties.Resources.TabEventTri_Tipo;
                e.Row.Cells[5].Text = Properties.Resources.TabEventTri_Tipo;
                e.Row.Cells[6].Text = Properties.Resources.TabEventTri_Desc;

                if (Utils.Idioma == "es-MX")
                {
                    e.Row.Cells[4].Visible = true;
                    e.Row.Cells[5].Visible = false;
                }
                else
                {
                    e.Row.Cells[4].Visible = false;
                    e.Row.Cells[5].Visible = true;
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (Utils.Idioma == "es-MX")
                {
                    e.Row.Cells[4].Visible = true;
                    e.Row.Cells[5].Visible = false;
                }
                else
                {
                    e.Row.Cells[4].Visible = false;
                    e.Row.Cells[5].Visible = true;
                }
            }
        }

        protected void gvPilotos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPilotos.PageIndex = e.NewPageIndex;
            LlenaGridPilotosLocal();
        }

        protected void gvPilotos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = Properties.Resources.TabPilTri_CodPiloto;
                e.Row.Cells[1].Text = Properties.Resources.TabPilTri_Nombre;
                e.Row.Cells[2].Text = Properties.Resources.TabPilTri_Licencia;
                e.Row.Cells[3].Text = Properties.Resources.TabPilTri_TipoLicencia;
                e.Row.Cells[4].Text = Properties.Resources.TabPilTri_LugarTrabajo;
                e.Row.Cells[5].Text = Properties.Resources.TabPilTri_NoVisa;
                e.Row.Cells[6].Text = Properties.Resources.TabPilTri_ExpVisa;
                e.Row.Cells[7].Text = Properties.Resources.TabPilTri_PaisVisa;
                e.Row.Cells[8].Text = Properties.Resources.TabPilTri_NoPassport;
                e.Row.Cells[9].Text = Properties.Resources.TabPilTri_FechaExpiraPass;

            }
        }

        #endregion

        #region VARIABLES Y PROPIEDADES

        Tripulacion_Presenter oPresenter;

        public event EventHandler eObjSelected;
        public event EventHandler eSearchObj;
        public event EventHandler eNewObj;
        public event EventHandler eSaveObj;
        public event EventHandler eDeleteObj;

        public List<Piloto> oLstPilotos
        {
            get { return (List<Piloto>)ViewState["VSPilotos"]; }
            set { ViewState["VSPilotos"] = value; }
        }

        public List<EventosPiloto> oLstEventosPiloto
        {
            get { return (List<EventosPiloto>)ViewState["VSEventosPiloto"]; }
            set { ViewState["VSEventosPiloto"] = value; }
        }

        #endregion

    }
}