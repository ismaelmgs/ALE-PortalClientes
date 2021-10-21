using PortalClientes.Objetos;
using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using PortalClientes.Presenter;
using PortalClientes.Clases;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using NucleoBase.Core;

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

        protected void btnPDFEvent_Click(object sender, EventArgs e)
        {
            exportarPDF("Evento");
        }

        protected void btnExcelEvent_Click(object sender, EventArgs e)
        {
            exportarExcel("Evento");
        }

        protected void btnExcelPilotos_Click(object sender, EventArgs e)
        {
            exportarExcel("Piloto");
        }

        protected void btnPDFPilotos_Click(object sender, EventArgs e)
        {
            exportarPDF("Piloto");
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (eSearchObj != null)
                    eSearchObj(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region METODOS

        public override void VerifyRenderingInServerForm(Control control)
        {
            return;
        }

        public void LlenarTripulacion()
        {
            if (eSearchObj != null)
                eSearchObj(null, EventArgs.Empty);
        }

        private void ArmarTripulacion()
        {
            txtBusqueda.Attributes.Add("placeholder", Properties.Resources.Cm_Buscador);

            lblTripulacion.Text = Properties.Resources.TitleTripulacion;
            lblTitleTripulacion.Text = Properties.Resources.TitleTripulacion;
            lblPanelEventos.Text = Properties.Resources.PTEventos;
            lblPanelListado.Text = Properties.Resources.PTListado;
            btnFiltrarTripulacion.Text = Properties.Resources.BTFiltro;

            var v = ddlFiltro.SelectedValue;
            // llenar dropdown Tipo Rubro
            ddlFiltro.Items.Clear();
            ddlFiltro.Items.Add(new ListItem(Properties.Resources.FiltroEvenTri_MA, "0"));
            ddlFiltro.Items.Add(new ListItem(Properties.Resources.FiltroEvenTri_1M, "1"));
            ddlFiltro.Items.Add(new ListItem(Properties.Resources.FiltroEvenTri_2M, "2"));
            ddlFiltro.Items.Add(new ListItem(Properties.Resources.FiltroEvenTri_3M, "3"));

            if (v == "")
            {
                ddlFiltro.SelectedIndex = 0;
            }
            else
            {
                ddlFiltro.SelectedValue = v;
            }

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

        private void exportarExcel(string tipo)
        {
            var nameFile = "";
            if (tipo == "Piloto")
            {
                nameFile = "TripulacionPilotosMat-" + Utils.MatriculaActual + ".xls";
            }
            else
            {
                nameFile = "TripulacionEventosMat-" + Utils.MatriculaActual + ".xls";
            }
                
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", nameFile));
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridView gv = null;

                if (tipo == "Piloto")
                {
                    gv = gvPilotos;
                    LlenaGridPilotosLocal();
                }
                else
                {
                    gv = gvEventos;
                    LlenaGridEventosLocal();
                }

                gv.AllowPaging = false;

                gv.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gv.HeaderRow.Cells)
                {
                    cell.BackColor = gv.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gv.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gv.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gv.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gv.RenderControl(hw);

                string style = @"<style> .textmode { } </style>";
                Response.Write(sw.ToString());
                Response.End();
            }
        }

        private void exportarPDF(string tipo)
        {
            var nameFile = "";
            if (tipo == "Piloto")
            {
                nameFile = "TripulacionPilotosMat-"+ Utils.MatriculaActual +".pdf";
            }
            else
            {
                nameFile = "TripulacionEventosMat-" + Utils.MatriculaActual + ".pdf";
            }

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", nameFile));
            Response.Charset = "";
            Response.ContentType = "application/octet-stream";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                GridView gv = null;
                if (tipo == "Piloto")
                {
                    gv = gvPilotos;
                    LlenaGridPilotosLocal();
                }
                else
                {
                    gv = gvEventos;
                    LlenaGridEventosLocal();
                }

                gv.AllowPaging = false;

                gv.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gv.HeaderRow.Cells)
                {
                    cell.BackColor = gv.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gv.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gv.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gv.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gv.RenderControl(hw);

                StringReader sr = new StringReader(sw.ToString());
                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4.Rotate(), 10f, 10f, 100f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                Response.Write(pdfDoc);
                Response.End();
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
        public event EventHandler eSearchObjEventos;


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

        public int iMeses
        {
            get
            {
                return ddlFiltro.SelectedValue.S().I();
            }
        }

        #endregion
    }
}