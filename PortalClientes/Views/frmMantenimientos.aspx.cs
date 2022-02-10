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
using System.Web;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace PortalClientes.Views
{
    public partial class frmMantenimientos : System.Web.UI.Page, iViewMantenimientos
    {
        #region EVENTOS
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["RefUrl"] = Request.RawUrl.ToString();
            if (System.Web.HttpContext.Current.Session["UserIdentity"] == null)
            {
                Response.Redirect("~/Views/frmFinconexion2.aspx");
            }

            oPresenter = new Mantenimiemntos_Presenter(this, new DBMantenimientos());

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
                LLenarMttos();
            }
        }

        protected void btnExc_Click(object sender, EventArgs e)
        {
            try
            {
                exportarExcel();
            }
            catch (Exception ex)
            {
                string strError = ex.Message;
            }
        }

        protected void btnPdf_Click(object sender, EventArgs e)
        {
            try
            {
                exportarPDF();
            }
            catch (Exception ex)
            {
                string strError = ex.Message;
            }
        }

        protected void gvMttos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = Properties.Resources.Mtto_origNmbr;
                e.Row.Cells[1].Text = Properties.Resources.Mtto_descripcion;
                e.Row.Cells[2].Text = Properties.Resources.Mtto_notes;
                e.Row.Cells[3].Text = Properties.Resources.Mtto_fechaInicio;
                e.Row.Cells[4].Text = Properties.Resources.Mtto_fechaFin;
            }
        }

        protected void gvMttos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMttos.PageIndex = e.NewPageIndex;
            LlenarGV();
        }

        private void LlenarGV()
        {
            gvMttos.DataSource = oMttos;
            gvMttos.DataBind();
        }

        protected void DDFiltroMeses_SelectedIndexChanged(object sender, EventArgs e)
        {
            LLenarMttos();
        }

        #endregion


        #region METODOS 

        private void ArmaFormulario()
        {
            lblMantenimientos.Text = Properties.Resources.Mtto_title;
            lblMantenimientosHeader.Text = Properties.Resources.Mtto_title;

            DDFiltroMeses.Attributes.Add("onchange", "ShowLoadingPanel();");

            var v2 = DDFiltroMeses.SelectedValue;
            // llenar dropdown filtro
            DDFiltroMeses.Items.Clear();
            DDFiltroMeses.Items.Add(new ListItem(Properties.Resources.FiltroME_12M, "12"));
            DDFiltroMeses.Items.Add(new ListItem(Properties.Resources.FiltroME_6M, "6"));

            if (v2 == "")
            {
                DDFiltroMeses.SelectedIndex = 0;
            }
            else
            {
                DDFiltroMeses.SelectedValue = v2;
            }
        }

        public void cargarMantenimientos(List<Mantenimientos> oMttoss)
        {
            oMttos = oMttoss;

            gvMttos.DataSource = oMttoss;
            gvMttos.DataBind();
        }

        public void LLenarMttos()
        {
            if (eSearchObj != null)
                eSearchObj(null, EventArgs.Empty);
        }

        private void exportarPDF()
        {
            Response.Clear();
            Response.Buffer = true;
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", nameFile(1)));
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                gvMttos.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gvMttos.HeaderRow.Cells)
                {
                    cell.BackColor = gvMttos.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gvMttos.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvMttos.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvMttos.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gvMttos.AllowPaging = false;
                gvMttos.DataBind();
                gvMttos.RenderControl(hw);

                StringReader sr = new StringReader(sw.ToString());
                iTextSharp.text.Document pdfDoc = new iTextSharp.text.Document(iTextSharp.text.PageSize.A4, 10f, 10f, 10f, 0f);
                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                pdfDoc.Open();
                htmlparser.Parse(sr);
                pdfDoc.Close();
                Response.Write(pdfDoc);
                Response.End();
            }
        }

        private void exportarExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", nameFile(2)));
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                gvMttos.AllowPaging = false;

                gvMttos.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gvMttos.HeaderRow.Cells)
                {
                    cell.BackColor = gvMttos.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gvMttos.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvMttos.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvMttos.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gvMttos.RenderControl(hw);

                string style = @"<style> .textmode { } </style>";
                Response.Write(sw.ToString());
                Response.End();
            }
        }

        private string nameFile(int tipoDocumento)
        {
            var nameFile = "";
            nameFile = Utils.Idioma == "es-MX" ? "Pilotos Tripulacion Matricula " : "Pilot Crew Tail number ";
            nameFile += Utils.MatriculaActual + " " + fechaConsulta(DDFiltroMeses.SelectedValue) + (tipoDocumento == 1 ? ".pdf" : ".xls");

            return nameFile;
        }

        private string fechaConsulta(string selectedValue)
        {
            var fecha = "";
            switch (selectedValue)
            {
                case "12":
                    fecha = Properties.Resources.FiltroME_12M;
                    break;
                case "6":
                    fecha = Properties.Resources.FiltroME_6M;
                    break;
            }

            return fecha;
        }

        #endregion

        #region VARIABLES Y PROPIEDADES

        Mantenimiemntos_Presenter oPresenter;

        public List<Mantenimientos> oMttos
        {
            get { return (List<Mantenimientos>)ViewState["VSMttos"]; }
            set { ViewState["VSMttos"] = value; }
        }

        public int iMeses
        {
            get
            {
                return DDFiltroMeses.SelectedValue.S().I();
            }
        }

        public event EventHandler eNewObj;
        public event EventHandler eObjSelected;
        public event EventHandler eSaveObj;
        public event EventHandler eDeleteObj;
        public event EventHandler eSearchObj;
        #endregion
    }
}