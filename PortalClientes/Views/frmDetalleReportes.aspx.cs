using PortalClientes.Objetos;
using PortalClientes.Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NucleoBase.Core;
using System.Globalization;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Threading;
using PortalClientes.Interfaces;
using PortalClientes.Presenter;
using PortalClientes.DomainModel;

namespace PortalClientes.Views
{
    public partial class frmDetalleReportes : System.Web.UI.Page, IViewDetalleReportes
    {
        #region EVENTOS
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["RefUrl"] = Request.UrlReferrer.ToString();
            if (System.Web.HttpContext.Current.Session["UserIdentity"] == null)
            {
                Response.Redirect("~/Views/frmFinconexion2.aspx");
            }

            oPresenter = new DetalleReportes_Presenter(this, new DBMetricasEstatics());

            iReporte = (int)Session["reporteDetalle"];

            lblTransacciones.Text = GenerateTitle(true, iReporte);

            TextBox milabel = (TextBox)this.Master.FindControl("txtLang");
            if (milabel.Text != Utils.Idioma && milabel.Text != string.Empty)
            {
                Utils.Idioma = milabel.Text;
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmarDetalleReportes();
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmarDetalleReportes();
            }

            if (Utils.Idioma == "es-MX")
            {
                btnRegresar.Visible = true;
                btnRegresarEng.Visible = false;
            }
            else
            {
                btnRegresar.Visible = false;
                btnRegresarEng.Visible = true;
            }

            if (!IsPostBack)
            {
                //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "openLoading();", true);
                if (eSearchObj != null)
                    eSearchObj(sender, e);
            }

        }

        protected void gvdetReportes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var tipo = Convert.ToInt32(Session["tipoReporte"]);
            Reportes reporte = new Reportes();
            gvdetReportes.Columns.Clear();
            gvdetReportes.PageIndex = e.NewPageIndex;

            if(tipo == 1)
            {
                reporte.costosFijosVariable = (List<gvCostosFV>)Session["data"];
                LlenarGV(reporte, tipo);
            }

            else if (tipo == 2)
            {
                reporte.gastosAe = (List<gvGastosAeropuerto>)Session["data"];
                LlenarGV(reporte, tipo);
            }

            else if (tipo == 3)
            {
                reporte.gastosProv = (List<gvGastosProveedor>)Session["data"];
                LlenarGV(reporte, tipo);
            }
        }

        protected void gvdetReportes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                var tipo = Convert.ToInt32(Session["tipoReporte"]);

                if(tipo == 1)
                {
                    e.Row.Cells[0].Text = Properties.Resources.TabTran_Mes;
                    e.Row.Cells[1].Text = Properties.Resources.TabTran_Anio;
                    e.Row.Cells[2].Text = Properties.Resources.TabTran_Rubro;
                    e.Row.Cells[3].Text = Properties.Resources.TabTran_Importe;
                    e.Row.Cells[4].Text = Properties.Resources.TabTran_Categoria;
                    e.Row.Cells[5].Text = Properties.Resources.TabTran_TGasto;
                    e.Row.Cells[6].Text = Properties.Resources.TabTran_Comentario;
                }

                else if (tipo == 2)
                {
                    e.Row.Cells[0].Text = Properties.Resources.TabTran_Mes;
                    e.Row.Cells[1].Text = Properties.Resources.TabTran_Rubro;
                    e.Row.Cells[2].Text = Properties.Resources.TabTran_Total;
                    e.Row.Cells[3].Text = Properties.Resources.TabTran_Anio;
                    e.Row.Cells[4].Text = Properties.Resources.TabTran_NoPierna;
                    e.Row.Cells[5].Text = Properties.Resources.TabTran_Proveedor;
                    e.Row.Cells[6].Text = Properties.Resources.TabTran_Categoria;
                    e.Row.Cells[7].Text = Properties.Resources.TabTran_Origen;
                    e.Row.Cells[8].Text = Properties.Resources.TabTran_Destino;
                }

                else if (tipo == 3)
                {
                    e.Row.Cells[0].Text = Properties.Resources.TabTran_Mes;
                    e.Row.Cells[1].Text = Properties.Resources.TabTran_Rubro;
                    e.Row.Cells[2].Text = Properties.Resources.TabTran_Total;
                    e.Row.Cells[3].Text = Properties.Resources.TabTran_Anio;
                    e.Row.Cells[4].Text = Properties.Resources.TabTran_NoPierna;
                    e.Row.Cells[5].Text = Properties.Resources.TabTran_Proveedor;
                    e.Row.Cells[6].Text = Properties.Resources.TabTran_Categoria;
                    e.Row.Cells[7].Text = Properties.Resources.TabTran_Origen;
                    e.Row.Cells[8].Text = Properties.Resources.TabTran_Destino;
                }
            }
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Session["titleFile"] = GenerateTitle(false, iReporte);
                exportarExcel();
            }
            catch (Exception ex)
            {
                string strError = ex.Message;
            }
        }

        protected void btnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                Session["titleFile"] = GenerateTitle(false, iReporte);
                exportarPDF();
            }
            catch (Exception ex)
            {
                string strError = ex.Message;
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            return;
        }

        #endregion

        #region METODOS

        private string GenerateTitle(bool tipoT, int reporte)
        {
            var title = Utils.Idioma == "es-MX" ? "Reporte " : "Report "; ;

            switch (reporte)
            {
                case 1:
                    title += Utils.Idioma == "es-MX" ? "Costo Fijo y Variable" : "Fixed and Variable Cost";
                    break;
                case 2:
                    title += Utils.Idioma == "es-MX" ? "Gastos por Aeropuerto" : "Expenses by Airport";
                    break;
                case 3:
                    title += Utils.Idioma == "es-MX" ? "Gastos por Proveedor" : "Expenses by Vendor";
                    break;
            }

            if (tipoT)
            {
                title += " - " + Utils.MatriculaActual;
            }
            else
            {
                title += "_" + Utils.MatriculaActual;
            }

            return title;
        }

        private void ArmarDetalleReportes()
        {
            lblTitulo.Text = Properties.Resources.DetRpt_Title;
            switch (iReporte)
            {
                case 4:
                    lblTotalTrasn.Text = Properties.Resources.TabTran_NoVuelos;
                    lblTotal.Text = Properties.Resources.TabTran_TiempoTotVuelo;
                    lblPromedio.Text = Properties.Resources.TabTran_PromedioVuelo;
                    break;
                case 5:
                    lblTotalTrasn.Text = Properties.Resources.TabTran_NoVuelos;
                    lblTotal.Text = Properties.Resources.TabTran_promedioPax;
                    lblPromedio.Text = Properties.Resources.TabTran_TiempoTotVuelo;
                    break;
                case 7:
                    lblTotalTrasn.Text = Properties.Resources.TabTran_NoVuelos;
                    lblTotal.Text = Properties.Resources.TabTran_TiempoTotVuelo;
                    lblPromedio.Text = Properties.Resources.TabTran_PromedioVuelo;
                    break;
                case 8:
                    lblTotalTrasn.Text = Properties.Resources.TabTran_NoVuelos;
                    lblTotal.Text = Properties.Resources.TabTran_TiempoTotVuelo;
                    lblPromedio.Text = Properties.Resources.TabTran_PromedioVuelo;
                    break;
                case 12:
                    lblTotalTrasn.Text = Properties.Resources.TabTran_MontoTotal;
                    lblTotal.Text = Properties.Resources.TabTran_CostoHV;
                    lblPromedio.Text = Properties.Resources.TabTran_TiempoTotVuelo;
                    break;
                default:
                    lblTotalTrasn.Text = Properties.Resources.TabTran_NoGastos;
                    lblTotal.Text = Properties.Resources.TabTran_MontoTotal;
                    lblPromedio.Text = Properties.Resources.TabTran_PromedioMens;
                    break;
            }
        }

        public void CargarReporteGastosFV(List<responseGraficaCostoFijoVariable> orptCostoFijoVariable)
        {
            DateTimeFormatInfo month = null;
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            var reporte = 1;

            Session["tipoReporte"] = reporte;

            if (Utils.Idioma == "es-MX")
            {
                month = new CultureInfo("es-ES", false).DateTimeFormat;
            }
            else
            {
                month = new CultureInfo("en-US", false).DateTimeFormat;
            }

            List<gvCostosFV> gvgfv = new List<gvCostosFV>();
            foreach (var i in orptCostoFijoVariable)
            {
                foreach(var item in i.costos)
                {
                    gvCostosFV gfv = new gvCostosFV();
                    gfv.rubro = Utils.Idioma == "es-MX" ? item.rubroESP : item.rubroENG;
                    gfv.totalImp = item.totalImp;
                    gfv.categoria = item.categoria;
                    gfv.comentarios = item.comentarios;
                    gfv.idTipoGasto = item.idTipoGasto.S();
                    gfv.mes = textInfo.ToTitleCase(month.GetMonthName(Convert.ToInt32(item.mes)));
                    gfv.anio = item.anio.S();

                    gvgfv.Add(gfv);
                } 
            }

            Reportes r = new Reportes();
            Session["data"] = gvgfv;
            r.costosFijosVariable = gvgfv;

            LlenarGV(r, reporte);
        }

        public void CargarReporteGastosAe(List<responseGraficaAeropuerto> orptAeropuerto)
        {
            DateTimeFormatInfo month = null;
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            var reporte = 2;

            Session["tipoReporte"] = reporte;

            if (Utils.Idioma == "es-MX")
            {
                month = new CultureInfo("es-ES", false).DateTimeFormat;
            }
            else
            {
                month = new CultureInfo("en-US", false).DateTimeFormat;
            }

            List<gvGastosAeropuerto> gva = new List<gvGastosAeropuerto>();
            foreach (var i in orptAeropuerto)
            {
                foreach (var item in i.gastos)
                {
                    gvGastosAeropuerto g = new gvGastosAeropuerto();
                    g.IdRubro = item.idRubro.Value;
                    g.Rubro = Utils.Idioma == "es-MX" ? item.rubroESP : item.rubroENG;
                    g.Total = item.totalMXN;
                    g.Mes = textInfo.ToTitleCase(month.GetMonthName(item.mes.Value));
                    g.Anio = item.anio.HasValue ? item.anio.Value : 0;
                    g.NoPierna = item.noPierna.HasValue ? item.noPierna.Value : 0;
                    g.Proveedor = item.proveedor;
                    g.Categoria = item.categoria;
                    g.Origen = item.origen;
                    g.TipoMoneda = item.tipoMoneda;
                    g.Destino = item.destino;

                    gva.Add(g);
                }
            }

            Reportes r = new Reportes();
            Session["data"] = gva;
            r.gastosAe = gva;

            LlenarGV(r, reporte);
        }

        public void CargarReporteGastosProve(List<responseGraficaProveedores> orptProveedores)
        {
            DateTimeFormatInfo month = null;
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            var reporte = 3;

            Session["tipoReporte"] = reporte;

            if (Utils.Idioma == "es-MX")
            {
                month = new CultureInfo("es-ES", false).DateTimeFormat;
            }
            else
            {
                month = new CultureInfo("en-US", false).DateTimeFormat;
            }

            List<gvGastosProveedor> gvp = new List<gvGastosProveedor>();
            foreach(var i in orptProveedores)
            {
                foreach (var item in i.gastos)
                {
                    gvGastosProveedor g = new gvGastosProveedor();
                    g.IdRubro = item.idRubro.Value;
                    g.Rubro = Utils.Idioma == "es-MX" ? item.rubroESP : item.rubroENG;
                    g.Total = item.totalMXN;
                    g.Mes = textInfo.ToTitleCase(month.GetMonthName(item.mes.Value));
                    g.Anio = item.anio.HasValue ? item.anio.Value : 0;
                    g.NoPierna = item.noPierna.HasValue ? item.noPierna.Value : 0;
                    g.Proveedor = item.proveedor;
                    g.Categoria = item.categoria;
                    g.Origen = item.origen;
                    g.TipoMoneda = item.tipoMoneda;
                    g.Destino = item.destino;

                    gvp.Add(g);
                }
            }

            Reportes r = new Reportes();
            Session["data"] = gvp;
            r.gastosProv = gvp;

            LlenarGV(r, reporte);
        }

        private void LlenarGV(Reportes reportes, int tipo)
        {
            var contMeses = 0;
            var totalTransacciones = 0.0;
            var totalTiempoVuelo = "00:00";
            var TiempoVueloProm = "00:00";
            var promedio = 0.0;
            var totalRegistros = 0;
            var dataOpt = (camposOpcionales)Session["dataOpt"];

            gvdetReportes.DataSource = null;
            gvdetReportes.Columns.Clear();

            if (tipo == 1)
            {
                totalRegistros = reportes.costosFijosVariable.Count();
                contMeses = reportes.costosFijosVariable.Count();
                totalTransacciones = reportes.costosFijosVariable.Sum(x => x.totalImp);
                promedio = totalTransacciones / totalRegistros;

                BoundField clm = new BoundField();
                clm.DataField = "mes";
                gvdetReportes.Columns.Add(clm);

                BoundField clm2 = new BoundField();
                clm2.DataField = "anio";
                gvdetReportes.Columns.Add(clm2);

                BoundField clm3 = new BoundField();
                clm3.DataField = "rubro";
                gvdetReportes.Columns.Add(clm3);

                BoundField clm4 = new BoundField();
                clm4.DataField = "totalImp";
                clm4.DataFormatString = "{0:c}";
                gvdetReportes.Columns.Add(clm4);

                BoundField clm5 = new BoundField();
                clm5.DataField = "categoria";
                gvdetReportes.Columns.Add(clm5);

                BoundField clm6 = new BoundField();
                clm6.DataField = "idTipoGasto";
                gvdetReportes.Columns.Add(clm6);

                BoundField clm7 = new BoundField();
                clm7.DataField = "comentarios";
                gvdetReportes.Columns.Add(clm7);

                gvdetReportes.DataSource = reportes.costosFijosVariable.OrderBy(x => x.mes).ToList(); //.GroupBy(r => r.mes).Select(x => x.First());
                gvdetReportes.DataBind();

                lblTotalTrasnRes.Text = totalRegistros.S();
                lblTotalRes.Text = totalTransacciones.ToString("C", CultureInfo.CreateSpecificCulture("es-MX")) + " MXN";
                lblPromedioRes.Text = promedio.ToString("C", CultureInfo.CreateSpecificCulture("es-MX")) + " MXN";
            }
            else if (tipo == 2)
            {
                totalRegistros = reportes.gastosAe.Count();
                contMeses = reportes.gastosAe.Count();
                totalTransacciones = reportes.gastosAe.Sum(x => x.Total);
                promedio = totalTransacciones / contMeses;

                BoundField clm = new BoundField();
                clm.DataField = "mes";
                gvdetReportes.Columns.Add(clm);

                BoundField clm3 = new BoundField();
                clm3.DataField = "Rubro";
                gvdetReportes.Columns.Add(clm3);

                BoundField clm4 = new BoundField();
                clm4.DataField = "Total";
                clm4.DataFormatString = "{0:c}";
                gvdetReportes.Columns.Add(clm4);

                BoundField clm6 = new BoundField();
                clm6.DataField = "Anio";
                gvdetReportes.Columns.Add(clm6);

                BoundField clm7 = new BoundField();
                clm7.DataField = "NoPierna";
                gvdetReportes.Columns.Add(clm7);

                BoundField clm8 = new BoundField();
                clm8.DataField = "Proveedor";
                gvdetReportes.Columns.Add(clm8);

                BoundField clm9 = new BoundField();
                clm9.DataField = "Categoria";
                gvdetReportes.Columns.Add(clm9);

                BoundField clm10 = new BoundField();
                clm10.DataField = "Origen";
                gvdetReportes.Columns.Add(clm10);

                BoundField clm11 = new BoundField();
                clm11.DataField = "Destino";
                gvdetReportes.Columns.Add(clm11);

                gvdetReportes.DataSource = reportes.gastosAe.OrderBy(x => x.Mes).ToList(); //.GroupBy(r => r.mes).Select(x => x.First());
                gvdetReportes.DataBind();

                lblTotalTrasnRes.Text = totalRegistros.S();
                lblTotalRes.Text = totalTransacciones.ToString("C", CultureInfo.CreateSpecificCulture("es-MX")) + " MXN";
                lblPromedioRes.Text = promedio.ToString("C", CultureInfo.CreateSpecificCulture("es-MX")) + " MXN";
            }
            else if(tipo == 3)
            {
                totalRegistros = reportes.gastosProv.Count();
                contMeses = reportes.gastosProv.Count();
                totalTransacciones = reportes.gastosProv.Sum(x => x.Total);
                promedio = totalTransacciones / contMeses;

                BoundField clm = new BoundField();
                clm.DataField = "mes";
                gvdetReportes.Columns.Add(clm);

                BoundField clm3 = new BoundField();
                clm3.DataField = "Rubro";
                gvdetReportes.Columns.Add(clm3);

                BoundField clm4 = new BoundField();
                clm4.DataField = "Total";
                clm4.DataFormatString = "{0:c}";
                gvdetReportes.Columns.Add(clm4);

                BoundField clm6 = new BoundField();
                clm6.DataField = "Anio";
                gvdetReportes.Columns.Add(clm6);

                BoundField clm7 = new BoundField();
                clm7.DataField = "NoPierna";
                gvdetReportes.Columns.Add(clm7);

                BoundField clm8 = new BoundField();
                clm8.DataField = "Proveedor";
                gvdetReportes.Columns.Add(clm8);

                BoundField clm9 = new BoundField();
                clm9.DataField = "Categoria";
                gvdetReportes.Columns.Add(clm9);

                BoundField clm10 = new BoundField();
                clm10.DataField = "Origen";
                gvdetReportes.Columns.Add(clm10);

                BoundField clm11 = new BoundField();
                clm11.DataField = "Destino";
                gvdetReportes.Columns.Add(clm11);

                gvdetReportes.DataSource = reportes.gastosProv.OrderBy(x => x.Mes).ToList(); //.GroupBy(r => r.mes).Select(x => x.First());
                gvdetReportes.DataBind();

                lblTotalTrasnRes.Text = totalRegistros.S();
                lblTotalRes.Text = totalTransacciones.ToString("C", CultureInfo.CreateSpecificCulture("es-MX")) + " MXN";
                lblPromedioRes.Text = promedio.ToString("C", CultureInfo.CreateSpecificCulture("es-MX")) + " MXN";
            }
        }

        private void exportarExcel()
        {
            var nameFile = "Transacciones_" + (string)Session["titleFile"] + ".xls";
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", nameFile));
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                gvdetReportes.AllowPaging = false;
                var tipo = Convert.ToInt32(Session["tipoReporte"]);
                Reportes reportes = new Reportes();
                if (tipo == 1)
                {
                    reportes.costosFijosVariable = (List<gvCostosFV>)Session["data"];
                    LlenarGV(reportes, tipo);
                }

                else if (tipo == 2)
                {
                    reportes.gastosAe = (List<gvGastosAeropuerto>)Session["data"];
                    LlenarGV(reportes, tipo);
                }

                else if (tipo == 3)
                {
                    reportes.gastosProv = (List<gvGastosProveedor>)Session["data"];
                    LlenarGV(reportes, tipo);
                }

                gvdetReportes.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gvdetReportes.HeaderRow.Cells)
                {
                    cell.BackColor = gvdetReportes.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gvdetReportes.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvdetReportes.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvdetReportes.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gvdetReportes.RenderControl(hw);

                string style = @"<style> .textmode { } </style>";
                Response.Write(sw.ToString());
                //Response.Output.Write();
                //Response.Flush();
                Response.End();
            }
        }

        private void exportarPDF()
        {
            var nameFile = "Transacciones_" + (string)Session["titleFile"] + ".pdf";
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", nameFile));
            Response.Charset = "";
            Response.ContentType = "application/octet-stream";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                gvdetReportes.AllowPaging = false;
                var tipo = Convert.ToInt32(Session["tipoReporte"]);
                Reportes reportes = new Reportes();
                if (tipo == 1)
                {
                    reportes.costosFijosVariable = (List<gvCostosFV>)Session["data"];
                    LlenarGV(reportes, tipo);
                }

                else if (tipo == 2)
                {
                    reportes.gastosAe = (List<gvGastosAeropuerto>)Session["data"];
                    LlenarGV(reportes, tipo);
                }

                else if (tipo == 3)
                {
                    reportes.gastosProv = (List<gvGastosProveedor>)Session["data"];
                    LlenarGV(reportes, tipo);
                }

                gvdetReportes.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gvdetReportes.HeaderRow.Cells)
                {
                    cell.BackColor = gvdetReportes.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gvdetReportes.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvdetReportes.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvdetReportes.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gvdetReportes.RenderControl(hw);

                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A4.Rotate(), 10f, 10f, 100f, 0f);
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

        DetalleReportes_Presenter oPresenter;
        public event EventHandler eSearchObj;
        public event EventHandler eNewObj;
        public event EventHandler eObjSelected;
        public event EventHandler eSaveObj;
        public event EventHandler eDeleteObj;

        public int iReporte
        {
            get { return (int)ViewState["VSReporte"]; }
            set { ViewState["VSReporte"] = value; }
        }

        #endregion

    }
}