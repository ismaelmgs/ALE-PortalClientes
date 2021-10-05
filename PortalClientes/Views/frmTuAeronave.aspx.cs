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

namespace PortalClientes.Views
{
    public partial class frmTuAeronave : System.Web.UI.Page, IViewAeronave
    {

        #region EVENTOS
        protected void Page_Load(object sender, EventArgs e)
        {
            oPresenter = new Aeronave_Presenter(this, new DBAeronave());    

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
                LLenarTuAeronave();
            }
        }

        protected void gvDocumentos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = Properties.Resources.TabDoc_Nombre;
                e.Row.Cells[1].Text = Properties.Resources.TabDoc_Acciones;

                ImageButton imbMats = (ImageButton)e.Row.FindControl("imbViewDoc");
                if (imbMats != null)
                {
                    imbMats.ToolTip = Properties.Resources.TabDoc_VIewDoc;
                }

                ImageButton imbEditarModulos = (ImageButton)e.Row.FindControl("imbDownloadDoc");
                if (imbEditarModulos != null)
                {
                    imbEditarModulos.ToolTip = Properties.Resources.TabDoc_DownDoc;
                }

            }
        }

        protected void imbViewDoc_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow row = ((ImageButton)sender).NamingContainer as GridViewRow;
            if (row != null)
            {
                var nombre = gvDocumentos.DataKeys[row.RowIndex]["NombreImagen"];
            }

        }

        protected void imbDownloadDoc_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow row = ((ImageButton)sender).NamingContainer as GridViewRow;
            if (row != null)
            {
                var nombre = gvDocumentos.DataKeys[row.RowIndex]["NombreImagen"];
            }

        }

        #endregion


        #region METODOS 

        public void LLenarTuAeronave()
        {
            if (eSearchObj != null)
                eSearchObj(null, EventArgs.Empty);
        }

        public void CargarAeronave(Aeronave oAero)
        {
            oAeronave = oAero;

            lblMatriculaTuAeronave.Text = oAero.nombreAeronave;
            lblFabricanteResp.Text = oAero.Fabricante;
            lblYearResp.Text = oAero.Anio;
            lblModeloResp.Text = oAero.Modelo;
            lblRegistroResp.Text = oAero.noRegistro;
            lblSerieResp.Text = oAero.noSerie;
            lblPasajerosResp.Text = oAero.noPasajeros.ToString();
            lblTripulacionRes.Text = oAero.noTripulacion.ToString();
            lblDimencionesExtRes.Text = oAero.dimencionesExteriores;
            lblDimencionesIntRes.Text = oAero.dimencionesInteriores;
            lblMaxFuelResp.Text = oAero.maxGasolina.ToString();
            lblMinFuelResp.Text = oAero.minGasolina.ToString();
            lblVelocidadRes.Text = oAero.velocidadCrucero.ToString();
            lblMaxAlturaRes.Text = oAero.altitudMaxima.ToString();
            lblTipoCombustibleRes.Text = oAero.tipoGasolina;
            lblRendimientoRes.Text = oAero.Rendimiento.ToString();
            lblDistanciaRes.Text = oAero.Distancia.ToString();
            lblPesoRes.Text = oAero.Peso.ToString();

            var sHtml = "<ol class='carousel-indicators'>";
            var sHtmlCarousel = "<div class='carousel-inner'>";       

            var element = 0;
            var ImgCount = 0;
            List<FotoAeronave> Lfa = new List<FotoAeronave>();
            foreach (var item in oAeronave.Imagenes)
            {
                if(item.Extension != ".pdf")
                {
                    var imgSrc = String.Format("data:image/png;base64,{0}", item.Imagen);

                    if (element == 0)
                    {
                        sHtml += "<li data-target='#ContentPlaceHolder1_carouselExampleIndicators' data-slide-to='" + element + "' class='active'></li>";
                        sHtmlCarousel += "<div class='carousel-item active'>" +
                                         "<img class='d-block w-100' src='" + imgSrc + "' alt='slide " + (element) + "'>" +
                                         "</div>";
                    }
                    else
                    {
                        sHtml += "<li data-target='#ContentPlaceHolder1_carouselExampleIndicators' data-slide-to='" + element + "'></li>";
                        sHtmlCarousel += "<div class='carousel-item'>" +
                                         "<img class='d-block w-100' src='" + imgSrc + "' alt='slide " + (element) + "'>" +
                                         "</div>";
                    }

                    if ((element + 1) == oAeronave.Imagenes.Where(x => x.Extension != ".pdf").Count())
                    {
                        sHtmlCarousel += "</div>";
                        sHtml += "</ol>";

                        sHtml += sHtmlCarousel;

                        sHtml += "<a class='carousel-control-prev' href='#ContentPlaceHolder1_carouselExampleIndicators' role='button' data-slide='prev'>" +
                                "<span class='carousel-control-prev-icon' aria-hidden='true'></span>" +
                                "<span class='sr-only'>Previous</span></a>" +
                                "<a class='carousel-control-next' href='#ContentPlaceHolder1_carouselExampleIndicators' role='button' data-slide='next'>" +
                                "<span class='carousel-control-next-icon' aria-hidden='true'></span>" +
                                "<span class='sr-only'>Next</span></a>";
                    }

                    element++;
                    ImgCount++;
                }
                else
                {
                    FotoAeronave fa = new FotoAeronave();
                    fa.NombreImagen = item.NombreImagen;
                    fa.Extension = item.Extension;
                    fa.Imagen = item.Imagen;

                    Lfa.Add(fa);
                }
            }

            gvDocumentos.DataSource = Lfa;
            gvDocumentos.DataBind();

            if (ImgCount == 0)
            {
                sHtml += "<li data-target='#ContentPlaceHolder1_carouselExampleIndicators' data-slide-to='0' class='active'></li></ol>";
                sHtmlCarousel += "<div class='carousel-item active'>" +
                                 "<img class='d-block w-100' src='../build/images/no_image.jpg' alt='slide 0'>" +
                                 "</div></div>";

                sHtml += sHtmlCarousel;

                sHtml += "<a class='carousel-control-prev' href='#ContentPlaceHolder1_carouselExampleIndicators' role='button' data-slide='prev'>" +
                        "<span class='carousel-control-prev-icon' aria-hidden='true'></span>" +
                        "<span class='sr-only'>Previous</span></a>" +
                        "<a class='carousel-control-next' href='#ContentPlaceHolder1_carouselExampleIndicators' role='button' data-slide='next'>" +
                        "<span class='carousel-control-next-icon' aria-hidden='true'></span>" +
                        "<span class='sr-only'>Next</span></a>";
            }

            carouselExampleIndicators.InnerHtml = sHtml;
        }

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

        #region VARIABLES Y PROPIEDADES

        Aeronave_Presenter oPresenter;
        public event EventHandler eNewObj;
        public event EventHandler eObjSelected;
        public event EventHandler eSaveObj;
        public event EventHandler eDeleteObj;
        public event EventHandler eSearchObj;

        public Aeronave oAeronave
        {
            get { return (Aeronave)ViewState["VSAeronave"]; }
            set { ViewState["VSAeronave"] = value; }
        }

        #endregion
    }
}