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
            if (System.Web.HttpContext.Current.Session["UserIdentity"] == null)
            {
                Response.Redirect("~/Views/frmFinconexion2.aspx");
            }

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
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "openLoading();", true);
                LLenarTuAeronave();
            }
        }

        protected void gvDocumentos_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = Properties.Resources.TabDoc_Nombre;
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;
                e.Row.Cells[3].Text = Properties.Resources.TabDoc_Acciones;

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

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Visible = false;
                e.Row.Cells[2].Visible = false;
            }
        }

        protected void gvDocumentos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "download")
            {
                var index = Convert.ToInt32(e.CommandArgument);

                GridViewRow row = gvDocumentos.Rows[index];

                var nombre = "";
                var ext = "";
                var img = "";
                if (row != null)
                {
                    nombre = gvDocumentos.Rows[row.RowIndex].Cells[0].Text;
                    ext = gvDocumentos.Rows[row.RowIndex].Cells[1].Text;
                    img = gvDocumentos.Rows[row.RowIndex].Cells[2].Text;
                }

                Response.Clear();

                Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", nombre));
                Response.ContentType = "application/octet-stream";

                Byte[] bytes = Convert.FromBase64String(img);
                Response.BinaryWrite(bytes);
                Response.End();
            }
        }

        protected void imbViewDoc_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow row = ((ImageButton)sender).NamingContainer as GridViewRow;
            var nombre = "";
            var ext = "";
            var img = "";
            if (row != null)
            {
                nombre = gvDocumentos.Rows[row.RowIndex].Cells[0].Text;
                ext = gvDocumentos.Rows[row.RowIndex].Cells[1].Text;
                img = gvDocumentos.Rows[row.RowIndex].Cells[2].Text;
            }
            var path = Server.MapPath("/images/documento.pdf");

            HFPath.Value = path;

            File.Delete(path);
            if (!File.Exists(path))
            {
                Byte[] bytes = Convert.FromBase64String(img);
                MemoryStream ms = new MemoryStream(bytes);

                FileStream file = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                ms.WriteTo(file);
                file.Close();
                ms.Close();
            }

            Response.Write("<script language='javascript'>" +
                "setTimeout(" +
                "   function(){" +
                "      window.open('file:///' + document.getElementById('ContentPlaceHolder1_HFPath').value,'_explorer.exe','location=yes,height=570,width=520,scrollbars=yes,status=yes')" +
                "   }, 2000);</script>");
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
            lblPesoMaxDespegueRes.Text = oAero.pesoMaxDespegue.ToString();
            lblPesoMaxAterrizajeRes.Text = oAero.pesoMaxAterrizaje.ToString();
            lblMaxCeroCombustibleRes.Text = oAero.pesoMaxZeroComb.ToString();
            lblPesoBasicoOperacionRes.Text = oAero.pesoBasicoOpe.ToString();
            lblVelocidadRes.Text = oAero.velocidadCrucero.ToString();
            lblMaxAlturaRes.Text = oAero.maxNivelAltura.ToString();

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

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "closeLoading();", true);
        }

        private void ArmaFormulario()
        {
            //txtBusqueda.Attributes.Add("placeholder", Properties.Resources.Cm_Buscador);

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
            lblVelocidad.Text = Properties.Resources.Ta_VelocidadCrucero;
            lblMaxAltura.Text = Properties.Resources.Ta_AltitudMaxima;
            lblPesoMaxDespegue.Text = Properties.Resources.Ta_PesoMaxDesp;
            lblPesoMaxAterrizaje.Text = Properties.Resources.Ta_PesoMaxAter;
            lblMaxCeroCombustible.Text = Properties.Resources.Ta_PesoMaxZeroComb;
            lblPesoBasicoOperacion.Text = Properties.Resources.Ta_PesoBasicoOpe;
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