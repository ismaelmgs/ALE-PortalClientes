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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;

namespace PortalClientes.Views
{
    public partial class frmDetalleReportes : System.Web.UI.Page, IViewDetalleReportes
    {
        #region EVENTOS
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["RefUrl"] = Request.Url.ToString();
            if (System.Web.HttpContext.Current.Session["UserIdentity"] == null)
            {
                Response.Redirect("~/Views/frmFinconexion2.aspx");
            }

            oPresenter = new DetalleReportes_Presenter(this, new DBMetricasEstatics());

            iReporte = (int)Session["reporteDetalle"];
            iisRpt = (int)Session["isRpt"];

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

            else if (tipo == 4)
            {
                reporte.resumenGastosVuelos = (List<rptResumenGastosVuelos>)Session["data"];
                LlenarGV(reporte, tipo);
            }

            else if (tipo == 5)
            {
                reporte.detalleGastosVuelos = (detGastosVuelos)Session["data"];
                LlenarGV(reporte, tipo);
            }

            else if (tipo == 6)
            {
                reporte.gastoCombustible = (List<gvGastosCombustible>)Session["data"];
                LlenarGV(reporte, tipo);
            }
        }

        protected void gvdetReportes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var tipo = Convert.ToInt32(Session["tipoReporte"]);
            if (e.Row.RowType == DataControlRowType.Header)
            {
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

                else if (tipo == 4)
                {
                    e.Row.Cells[0].Text = Properties.Resources.TabTran_Anio;
                    e.Row.Cells[1].Text = Properties.Resources.TabTran_Mes;
                    e.Row.Cells[2].Text = Properties.Resources.TabTran_NoVuelos;
                    e.Row.Cells[3].Text = Properties.Resources.TabTran_TotalMxn;
                    e.Row.Cells[4].Text = Properties.Resources.TabTran_TotalUsd;
                }

                else if (tipo == 5)
                {
                    e.Row.Cells[0].Text = Properties.Resources.TabTran_Mes;
                    e.Row.Cells[0].Visible = false;
                }

                else if (tipo == 6)
                {
                    e.Row.Cells[0].Text = Properties.Resources.TabTran_Mes;
                    e.Row.Cells[1].Text = Properties.Resources.TabTran_Anio;
                    e.Row.Cells[2].Text = Properties.Resources.TabTran_Referencia;
                    e.Row.Cells[3].Text = Properties.Resources.TabTran_TGasto;
                    e.Row.Cells[4].Text = Properties.Resources.TabTran_Proveedor;
                    e.Row.Cells[5].Text = Properties.Resources.TabTran_Importe;
                    e.Row.Cells[6].Text = Properties.Resources.TabTran_Comentario;
                    e.Row.Cells[7].Text = Properties.Resources.TabTran_Origen;
                    e.Row.Cells[8].Text = Properties.Resources.TabTran_Destino;
                }
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if(tipo == 5)
                {
                    e.Row.Cells[0].Visible = false;
                }
            }
        }

        protected void gvdetRepConceptos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var tipo = Convert.ToInt32(Session["tipoReporte"]);
            Reportes reporte = new Reportes();
            gvdetRepConceptos.Columns.Clear();
            gvdetRepConceptos.PageIndex = e.NewPageIndex;

            if (tipo == 5)
            {
                reporte.detalleGastosVuelos = (detGastosVuelos)Session["data"];
                LlenarGVS(reporte, tipo);
            }
        }

        protected void gvdetRepConceptos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var tipo = Convert.ToInt32(Session["tipoReporte"]);
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = Properties.Resources.TabTran_Rubro;
                e.Row.Cells[1].Text = Properties.Resources.TabTran_TotalMxn;
                e.Row.Cells[2].Text = Properties.Resources.TabTran_TotalUsd;
                e.Row.Cells[3].Text = Properties.Resources.TabTran_Fecha;
                e.Row.Cells[4].Text = Properties.Resources.TabTran_Categoria;
                e.Row.Cells[5].Text = Properties.Resources.TabTran_Comentario;
            }
        }

        private void Lb_Command(object sender, CommandEventArgs e)
        {
            var value = e.CommandArgument;
            Session["mesSeleccionado"] = value;
            var tipo = Convert.ToInt32(Session["tipoReporte"]);
            Reportes reporte = new Reportes();

            lblVueloMes.Text = value.S();

            if (tipo == 5)
            {
                reporte = (Reportes)Session["data"];
                LlenarGVSv(reporte, tipo, value.S());
            }

            mpeVuelosMes.Show();
        }

        protected void gvdetReportes_RowCreated(object sender, GridViewRowEventArgs e)
        {
            var tipo = Convert.ToInt32(Session["tipoReporte"]);

            if (tipo == 5)
            {
                Reportes r = (Reportes)Session["data"];
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    TableCell tc = new TableCell();
                    tc.Text = Properties.Resources.TabTran_Mes;
                    tc.Style.Add("font-weight", "bold");
                    e.Row.Cells.Add(tc);
                }

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lb = new LinkButton();
                    lb.ID = "lnkB" + e.Row.RowIndex;
                    lb.Visible = true;
                    lb.Text = r.detalleGastosVuelos.titulos[e.Row.RowIndex].tituloLink;
                    lb.CommandArgument = r.detalleGastosVuelos.titulos[e.Row.RowIndex].mes;
                    lb.Command += Lb_Command;

                    TableCell tc = new TableCell();
                    tc.Width = 300;
                    tc.Controls.Add(lb);
                    e.Row.Cells.Add(tc);
                    e.Row.Cells[0].Visible = false;
                }
            }
        }

        protected void gvVuelos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var tipo = Convert.ToInt32(Session["tipoReporte"]);
            var mes = (Session["mesSeleccionado"]).ToString();
            Reportes reporte = new Reportes();
            gvVuelos.Columns.Clear();
            gvVuelos.PageIndex = e.NewPageIndex;

            if (tipo == 5)
            {
                reporte = (Reportes)Session["data"];
                LlenarGVSv(reporte, tipo, mes);
            }
        }

        protected void gvVuelos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            var tipo = Convert.ToInt32(Session["tipoReporte"]);
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = Properties.Resources.TabTran_Mes;
                e.Row.Cells[1].Text = Properties.Resources.TabTran_Origen;
                e.Row.Cells[2].Text = Properties.Resources.TabTran_Destino;
                e.Row.Cells[3].Text = Properties.Resources.TabTran_TiempoVuelo;
                e.Row.Cells[4].Text = Properties.Resources.TabTran_CPax;
                e.Row.Cells[5].Text = Properties.Resources.TabTran_Contrato;
            }
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Session["titleFile"] = GenerateTitle(false, iReporte);
                if (iisRpt > 0)
                {
                    generarRpt(1);
                }
                else
                {
                    exportarExcel();
                }
                
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
                if (iisRpt > 0)
                {
                    generarRpt(2);
                }
                else
                {
                    exportarPDF();
                }
                
            }
            catch (Exception ex)
            {
                string strError = ex.Message;
            }
        }

        private void generarRpt(int tipo)
        {
            DataSet ds = GenerarDT();
            string strPath = string.Empty;
            ReportDocument rd = new ReportDocument();
            strPath = Server.MapPath("RPT\\rptResumenGastosVuelos.rpt");
            strPath = strPath.Replace("\\Views", "");
            rd.Load(strPath, OpenReportMethod.OpenReportByDefault);
            rd.SetDataSource(ds);

            if(tipo == 1)
            {
                rd.ExportToHttpResponse(ExportFormatType.Excel, Response, true, (string)Session["titleFile"]);
            }
            else
            {
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, (string)Session["titleFile"]);
            }

            Response.End();
        }

        private DataSet GenerarDT()
        {
            DataSet ds = new DataSet();
            List<rptResumenGastosVuelos> rgv = (List<rptResumenGastosVuelos>)Session["data"];
            DataTable dt = new DataTable();
            dt.TableName = "tablaDatos";
            dt.Columns.Add("Anio", typeof(System.String));
            dt.Columns.Add("Mes", typeof(System.String));
            dt.Columns.Add("NoVuelos", typeof(System.String));
            dt.Columns.Add("TotalMXN", typeof(System.Decimal));
            dt.Columns.Add("TotalUSD", typeof(System.Decimal));

            foreach(var item in rgv)
            {
                DataRow row = dt.NewRow();

                row["Anio"] = item.anio;
                row["Mes"] = Utils.Idioma == "es-MX" ? item.nombreESP : item.nombreENG;
                row["NoVuelos"] = item.vuelos;
                row["TotalMXN"] = item.totalMXN;
                row["TotalUSD"] = item.totalUSD;

                dt.Rows.Add(row);
            }

            ds.Tables.Add(dt);

            DataTable dtTotales = new DataTable();
            dtTotales.TableName = "Totales";
            dtTotales.Columns.Add("TotalesMXN", typeof(System.Decimal));
            dtTotales.Columns.Add("TotalesUSD", typeof(System.Decimal));

            DataRow row2 = dtTotales.NewRow();
            row2["TotalesMXN"] = rgv.Sum(x => x.totalMXN);
            row2["TotalesUSD"] = rgv.Sum(x => x.totalUSD);
            dtTotales.Rows.Add(row2);

            ds.Tables.Add(dtTotales);

            DataTable dtTGenerales = new DataTable();
            dtTGenerales.TableName = "Generales";
            dtTGenerales.Columns.Add("Anio", typeof(System.String));
            dtTGenerales.Columns.Add("Periodo", typeof(System.String));
            dtTGenerales.Columns.Add("Idioma", typeof(System.String));

            DataRow row3 = dtTGenerales.NewRow();
            row3["Anio"] = DateTime.Now.Year.S();
            row3["Periodo"] = Utils.Idioma == "es-MX" ? "Anual" : "Annual";
            row3["Idioma"] = Utils.Idioma;
            dtTGenerales.Rows.Add(row3);

            ds.Tables.Add(dtTGenerales);


            return ds;
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            return;
        }

        protected void btnsalir_Click(object sender, EventArgs e)
        {
            mpeVuelosMes.Hide();
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
                case 4:
                    title += Utils.Idioma == "es-MX" ? "Resumen de Gastos / Vuelos" : "Summary of Expenses / Flights";
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
            btnsalir.Text = Properties.Resources.Cancelar;

            switch (iReporte)
            {
                case 4:
                    lblTotalTrasn.Text = Properties.Resources.TabTran_NoVuelos;
                    lblTotal.Text = Properties.Resources.TabTran_TotalMxn;
                    lblPromedio.Text = Properties.Resources.TabTran_TotalUsd;
                    break;
                case 5:
                    lblTotalTrasn.Text = Properties.Resources.TabTran_NoVuelos;
                    lblTotal.Text = Properties.Resources.TabTran_TotalMxn;
                    lblPromedio.Text = Properties.Resources.TabTran_TotalUsd;
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

        public void CargarReporteResumenGastosVuelos(List<rptResumenGastosVuelos> orptResumenGastosVuelos)
        {
            var reporte = 4;
            Session["tipoReporte"] = reporte;

            Reportes r = new Reportes();
            Session["data"] = orptResumenGastosVuelos;
            r.resumenGastosVuelos = orptResumenGastosVuelos;

            LlenarGV(r, reporte);
        }

        public void CargarReporteDetalleGastosVuelos(responseDetGastosVuelos orptDetalleGastosVuelos)
        {
            DateTimeFormatInfo month = null;
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            var reporte = 5;

            Session["tipoReporte"] = reporte;

            if (Utils.Idioma == "es-MX")
            {
                month = new CultureInfo("es-ES", false).DateTimeFormat;
            }
            else
            {
                month = new CultureInfo("en-US", false).DateTimeFormat;
            }

            detGastosVuelos detGV = new detGastosVuelos();
            detGV.gvVuelos = new List<gvVuelos>();
            detGV.titulos = new List<gvTitulosVuelos>();
            detGV.gvConceptos = new List<gvConcepto>();

            List<int> meses = new List<int>();
            meses = orptDetalleGastosVuelos.reporteDetalleGastosVuelosHOUT.Select(x => x.mes).Distinct().ToList();

            foreach(var m in meses)
            {
                var mes = textInfo.ToTitleCase(month.GetMonthName(m));

                gvTitulosVuelos tv = new gvTitulosVuelos();
                tv.tituloLink = Utils.Idioma == "es-MX" ? orptDetalleGastosVuelos.reporteDetalleGastosVuelosHOUT.Where(j => j.mes == m).Count().S() + " vuelos en " + mes : mes + " " + orptDetalleGastosVuelos.reporteDetalleGastosVuelosHOUT.Where(j => j.mes == m).Count().S() + "Flights";
                tv.mes = mes;
                detGV.titulos.Add(tv);

                foreach (var item in orptDetalleGastosVuelos.reporteDetalleGastosVuelosHOUT.Where(x => x.mes == m))
                {
                    gvVuelos gvv = new gvVuelos();
                    gvv.origen = item.origen;
                    gvv.destino = item.destino;
                    gvv.tiempoVuelo = item.tiempoVuelo;
                    gvv.pasajeros = item.cantPax;
                    gvv.contrato = item.contrato;
                    gvv.mes = mes;
                    detGV.gvVuelos.Add(gvv);
                }
            }

            foreach (var item in orptDetalleGastosVuelos.reporteDetalleGastosVuelosDOUT)
            {
                gvConcepto gvc = new gvConcepto();
                gvc.rubro = Utils.Idioma == "es-MX" ? item.rubroESP : item.rubroENG;
                gvc.totalMXN = item.totalMXN;
                gvc.totalUSD = item.totalUSD;
                gvc.fecha = item.fecha.ToString("dd/MM/yyyy");
                gvc.categoria = item.categoria;
                gvc.comentarios = item.comentarios;
                detGV.gvConceptos.Add(gvc);
            }

            Reportes r = new Reportes();
            r.detalleGastosVuelos = detGV;
            Session["data"] = r;

            LlenarGV(r, reporte);
        }

        public void CargarReporteGastosCombustible(List<responseGastosCombustibleVuelos> orptComb)
        {
            DateTimeFormatInfo month = null;
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            var reporte = 6;

            Session["tipoReporte"] = reporte;

            if (Utils.Idioma == "es-MX")
            {
                month = new CultureInfo("es-ES", false).DateTimeFormat;
            }
            else
            {
                month = new CultureInfo("en-US", false).DateTimeFormat;
            }

            List<gvGastosCombustible> gvc = new List<gvGastosCombustible>();
            foreach (var i in orptComb)
            {
                gvGastosCombustible g = new gvGastosCombustible();
                g.referencia = i.referencia;
                g.tipoGasto = i.tipoGasto;
                g.comentarios = i.comentarios;
                g.proveedor = i.proveedor;
                g.anio = i.anio;
                g.mes = textInfo.ToTitleCase(month.GetMonthName(i.mes));
                g.importe = i.importe;
                g.origen = i.origen;
                g.destino = i.destino;
               
                gvc.Add(g);
            }

            Reportes r = new Reportes();
            Session["data"] = gvc;
            r.gastoCombustible = gvc;

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

            gvdetRepConceptos.Visible = false;

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
                lblTotalRes.Text = totalTransacciones.ToString() + " MXN";
                lblPromedioRes.Text = promedio.ToString() + " MXN";
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
                lblTotalRes.Text = totalTransacciones.ToString() + " MXN";
                lblPromedioRes.Text = promedio.ToString() + " MXN";
            }
            else if (tipo == 3)
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
                lblTotalRes.Text = totalTransacciones.ToString() + " MXN";
                lblPromedioRes.Text = promedio.ToString() + " MXN";
            }
            else if (tipo == 4)
            {
                totalRegistros = reportes.resumenGastosVuelos.Sum(x => x.vuelos);
                contMeses = reportes.resumenGastosVuelos.Count();
                totalTransacciones = reportes.resumenGastosVuelos.Sum(x => x.totalMXN);
                promedio = reportes.resumenGastosVuelos.Sum(x => x.totalUSD);

                BoundField clm = new BoundField();
                clm.DataField = "anio";
                gvdetReportes.Columns.Add(clm);

                BoundField clm3 = new BoundField();
                if(Utils.Idioma == "es-MX"){
                    clm3.DataField = "nombreESP";
                    gvdetReportes.Columns.Add(clm3);
                }
                else
                {
                    clm3.DataField = "nombreENG";
                    gvdetReportes.Columns.Add(clm3);
                }
               
                BoundField clm4 = new BoundField();
                clm4.DataField = "vuelos";
                gvdetReportes.Columns.Add(clm4);

                BoundField clm6 = new BoundField();
                clm6.DataField = "totalMXN";
                clm6.DataFormatString = "{0:c}";
                gvdetReportes.Columns.Add(clm6);

                BoundField clm7 = new BoundField();
                clm7.DataField = "totalUSD";
                clm7.DataFormatString = "{0:c}";
                gvdetReportes.Columns.Add(clm7);

                gvdetReportes.DataSource = reportes.resumenGastosVuelos.OrderBy(x => x.mes).ToList(); //.GroupBy(r => r.mes).Select(x => x.First());
                gvdetReportes.DataBind();

                lblTotalTrasnRes.Text = totalRegistros.S();
                lblTotalRes.Text = totalTransacciones.ToString() + " MXN";
                lblPromedioRes.Text = promedio.ToString() + " USD";
            }
            else if (tipo == 5)
            {
                totalRegistros = reportes.detalleGastosVuelos.gvVuelos.Count();
                //contMeses = reportes.resumenGastosVuelos.Count();
                totalTransacciones = reportes.detalleGastosVuelos.gvConceptos.Sum(x => x.totalMXN);
                promedio = reportes.detalleGastosVuelos.gvConceptos.Sum(x => x.totalUSD);

                BoundField clm = new BoundField();
                clm.DataField = "mes";
                gvdetReportes.Columns.Add(clm);

                gvdetReportes.DataSource = reportes.detalleGastosVuelos.titulos.OrderBy(x => x.mes).ToList(); //.GroupBy(r => r.mes).Select(x => x.First());
                gvdetReportes.DataBind();

                lblTotalTrasnRes.Text = totalRegistros.S();
                lblTotalRes.Text = totalTransacciones.ToString() + " MXN";
                lblPromedioRes.Text = promedio.ToString() + " USD";

                LlenarGVS(reportes, tipo);
            }
            else if (tipo == 6)
            {
                totalRegistros = reportes.gastoCombustible.Count();
                contMeses = reportes.gastoCombustible.Count();
                totalTransacciones = reportes.gastoCombustible.Sum(x => x.importe);
                promedio = totalTransacciones / contMeses;

                BoundField clm = new BoundField();
                clm.DataField = "mes";
                gvdetReportes.Columns.Add(clm);

                BoundField clm3 = new BoundField();
                clm3.DataField = "anio";
                gvdetReportes.Columns.Add(clm3);


                BoundField clm6 = new BoundField();
                clm6.DataField = "referencia";
                gvdetReportes.Columns.Add(clm6);

                BoundField clm7 = new BoundField();
                clm7.DataField = "tipoGasto";
                gvdetReportes.Columns.Add(clm7);

                BoundField clm8 = new BoundField();
                clm8.DataField = "proveedor";
                gvdetReportes.Columns.Add(clm8);

                BoundField clm4 = new BoundField();
                clm4.DataField = "importe";
                clm4.DataFormatString = "{0:c}";
                gvdetReportes.Columns.Add(clm4);

                BoundField clm9 = new BoundField();
                clm9.DataField = "comentarios";
                gvdetReportes.Columns.Add(clm9);

                BoundField clm10 = new BoundField();
                clm10.DataField = "origen";
                gvdetReportes.Columns.Add(clm10);

                BoundField clm11 = new BoundField();
                clm11.DataField = "destino";
                gvdetReportes.Columns.Add(clm11);

                gvdetReportes.DataSource = reportes.gastoCombustible.OrderBy(x => x.mes).ToList(); //.GroupBy(r => r.mes).Select(x => x.First());
                gvdetReportes.DataBind();

                lblTotalTrasnRes.Text = totalRegistros.S();
                lblTotalRes.Text = totalTransacciones.ToString() + " MXN";
                lblPromedioRes.Text = promedio.ToString() + " MXN";
            }
        }

        private void LlenarGVS(Reportes reportes, int tipo)
        {
            gvdetRepConceptos.Visible = true;
            gvdetRepConceptos.DataSource = null;
            gvdetRepConceptos.Columns.Clear();

            if (tipo == 5)
            {

                BoundField clm = new BoundField();
                clm.DataField = "rubro";
                gvdetRepConceptos.Columns.Add(clm);

                BoundField clm2 = new BoundField();
                clm2.DataField = "totalMXN";
                gvdetRepConceptos.Columns.Add(clm2);

                BoundField clm3 = new BoundField();
                clm3.DataField = "totalUSD";
                gvdetRepConceptos.Columns.Add(clm3);

                BoundField clm4 = new BoundField();
                clm4.DataField = "fecha";
                gvdetRepConceptos.Columns.Add(clm4);

                BoundField clm5 = new BoundField();
                clm5.DataField = "categoria";
                gvdetRepConceptos.Columns.Add(clm5);

                BoundField clm6 = new BoundField();
                clm6.DataField = "comentarios";
                gvdetRepConceptos.Columns.Add(clm6);

                gvdetRepConceptos.DataSource = reportes.detalleGastosVuelos.gvConceptos.ToList();
                gvdetRepConceptos.DataBind();

            }
        }

        private void LlenarGVSv(Reportes reportes, int tipo, string mes)
        {
            gvVuelos.Visible = true;
            gvVuelos.DataSource = null;
            gvVuelos.Columns.Clear();

            if (tipo == 5)
            {

                BoundField clm = new BoundField();
                clm.DataField = "mes";
                gvVuelos.Columns.Add(clm);

                BoundField clm2 = new BoundField();
                clm2.DataField = "origen";
                gvVuelos.Columns.Add(clm2);

                BoundField clm3 = new BoundField();
                clm3.DataField = "destino";
                gvVuelos.Columns.Add(clm3);

                BoundField clm4 = new BoundField();
                clm4.DataField = "tiempoVuelo";
                gvVuelos.Columns.Add(clm4);

                BoundField clm5 = new BoundField();
                clm5.DataField = "pasajeros";
                gvVuelos.Columns.Add(clm5);

                BoundField clm6 = new BoundField();
                clm6.DataField = "contrato";
                gvVuelos.Columns.Add(clm6);

                gvVuelos.DataSource = mes != "" ? reportes.detalleGastosVuelos.gvVuelos.Where(i => i.mes == mes).ToList() : reportes.detalleGastosVuelos.gvVuelos.ToList();
                gvVuelos.DataBind();

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

                else if (tipo == 6)
                {
                    reportes.gastoCombustible = (List<gvGastosCombustible>)Session["data"];
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

                else if (tipo == 6)
                {
                    reportes.gastoCombustible = (List<gvGastosCombustible>)Session["data"];
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

        public int iisRpt
        {
            get { return (int)ViewState["VSIsReport"]; }
            set { ViewState["VSIsReport"] = value; }
        }

        #endregion
    }
}