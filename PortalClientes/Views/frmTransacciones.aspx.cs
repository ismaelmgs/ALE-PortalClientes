using PortalClientes.Objetos;
using PortalClientes.Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Web.Services;
using DevExpress.Web;
using NucleoBase.Core;
using System.Globalization;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

namespace PortalClientes.Views
{

    class Meses
    {
        string mes { set; get; }
    }
    public partial class frmTransacciones : System.Web.UI.Page
    {

        #region EVENTOS
        protected void Page_Load(object sender, EventArgs e)
        {

            //oPresenter = new Transacciones_Presenter(this, new DBTransacciones());

            TextBox milabel = (TextBox)this.Master.FindControl("txtLang");
            if (milabel.Text != Utils.Idioma && milabel.Text != string.Empty)
            {
                Utils.Idioma = milabel.Text;
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmarTransacciones();
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmarTransacciones();
            }

            if (!IsPostBack)
            {
                if (Session["gvGastos"] != null)
                {
                    List<gvGastos> values = (List<gvGastos>)Session["gvGastos"];
                    LlenarGV(values);
                }
                
            }

        }

        protected void gvGastos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = Properties.Resources.TabTran_Mes;
                e.Row.Cells[1].Text = Properties.Resources.TabTran_idRubro;
                e.Row.Cells[2].Text = Properties.Resources.TabTran_Rubro;
                e.Row.Cells[3].Text = Properties.Resources.TabTran_Total;
                e.Row.Cells[4].Text = Properties.Resources.TabTran_Fecha;
                e.Row.Cells[5].Text = Properties.Resources.TabTran_Categoria;
                e.Row.Cells[6].Text = Properties.Resources.TabTran_TGasto;
                e.Row.Cells[7].Text = Properties.Resources.TabTran_Comentario;


                //e.Row.Cells[1].Text = Properties.Resources.TabTran_Mes;
                //e.Row.Cells[2].Text = Properties.Resources.TabTran_Mes;
            }

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    GridView gvDetalle = (GridView)e.Row.FindControl("gvGastosDetalle");
            //    if (gvDetalle != null)
            //    {
            //        List<gvGastos> olsGastos = (List<gvGastos>)Session["gvGastos"];
            //        string smes = olsGastos[e.Row.RowIndex].mes.S();

            //        gvDetalle.DataSource = olsGastos.Where(r => r.mes == smes);
            //        gvDetalle.DataBind();
            //    }
            //}
        }

        protected void gvGastos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGastos.PageIndex = e.NewPageIndex;
            LlenarGV((List<gvGastos>)Session["gvGastos"]);
        }

        protected void btnExcel_Click(object sender, EventArgs e)
        {
            exportarExcel();
        }

        protected void btnPDF_Click(object sender, EventArgs e)
        {
            exportarPDF();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            return;
        }

        #endregion


        #region METODOS
        private void LlenarGV(List<gvGastos> gv)
        {
            var contMeses = gv.GroupBy(r => r.mes).Count();
            var totalTransacciones = gv.Sum(x => x.Total);
            var promedio = totalTransacciones / contMeses;

            lblTotalTrasnRes.Text = gv.Count().S();
            lblTotalRes.Text = totalTransacciones.ToString("C", CultureInfo.CreateSpecificCulture("es-MX"));
            lblPromedioRes.Text = promedio.ToString("C", CultureInfo.CreateSpecificCulture("es-MX"));


            gvGastos.DataSource = gv.OrderBy(x => x.Fecha).ToList(); //.GroupBy(r => r.mes).Select(x => x.First());
            gvGastos.DataBind();
        }

        //protected void gvGastosDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.Header)
        //    {
        //        //e.Row.Cells[0].Text = Properties.Resources.TabTran_idRubro;
        //        //e.Row.Cells[1].Text = Properties.Resources.TabTran_Rubro;
        //        //e.Row.Cells[2].Text = Properties.Resources.TabTran_Total;
        //        //e.Row.Cells[3].Text = Properties.Resources.TabTran_Fecha;
        //        //e.Row.Cells[4].Text = Properties.Resources.TabTran_Categoria;
        //        //e.Row.Cells[5].Text = Properties.Resources.TabTran_TGasto;
        //        //e.Row.Cells[6].Text = Properties.Resources.TabTran_Comentario;
        //        //e.Row.Cells[7].Text = Properties.Resources.TabTran_Mes;

        //        e.Row.Cells[1].Text = Properties.Resources.TabTran_Mes;
        //        e.Row.Cells[2].Text = Properties.Resources.TabTran_Mes;
        //    }

        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        GridView gvDetalle = (GridView)e.Row.FindControl("gvGastosDetalle");
        //        if (gvDetalle != null)
        //        {
        //            List<gvGastos> olsGastos = (List<gvGastos>)Session["gvGastos"];
        //            string smes = olsGastos[e.Row.RowIndex].mes.S();

        //            gvDetalle.DataSource = olsGastos.Where(r => r.mes == smes);
        //            gvDetalle.DataBind();
        //        }
        //    }
        //}

        private void ArmarTransacciones()
        {
            txtBusqueda.Attributes.Add("placeholder", Properties.Resources.Cm_Buscador);

            lblTransacciones.Text = Properties.Resources.TabTransacciones + " - " + Session["titleGastos"];
            lblTitulo.Text = Properties.Resources.TabTransacciones;

            lblTotalTrasn.Text = Properties.Resources.TabTran_NoGastos;
            lblTotal.Text = Properties.Resources.TabTran_MontoTotal;
            lblPromedio.Text = Properties.Resources.TabTran_PromedioMens;

            //lblSalida.Text = Properties.Resources.Das_Salida;
            //lblLlego.Text = Properties.Resources.Das_Llego;s
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
        }

        [WebMethod]
        public static void ObtenerTransacciones(List<gasto> gastos, string tipoDet, string rubroEsp, string rubroEng)
        {
            List<gvGastos> gv = new List<gvGastos>();
            foreach (var item in gastos)
            {
                gvGastos g = new gvGastos();
                if (tipoDet == "MXN" && item.totalUSD == 0 && item.totalMXN > 0)
                {
                    g.idRubro = item.idRubro;
                    g.Rubro = Utils.Idioma == "es-MX" ? item.rubroESP : item.rubroENG;
                    g.Total = item.totalMXN;
                    g.Fecha = item.fecha;
                    g.Categoria = item.categoria;
                    g.tipodeGasto = item.tipodeGasto;
                    g.comentarios = item.comentarios;
                    g.mes = item.mes;

                    gv.Add(g);
                }

                if (tipoDet == "USD" && item.totalMXN == 0 && item.totalUSD > 0)
                {
                    g.idRubro = item.idRubro;
                    g.Rubro = Utils.Idioma == "es-MX" ? item.rubroESP : item.rubroENG;
                    g.Total = item.totalUSD;
                    g.Fecha = item.fecha;
                    g.Categoria = item.categoria;
                    g.tipodeGasto = item.tipodeGasto;
                    g.comentarios = item.comentarios;
                    g.mes = item.mes;

                    gv.Add(g);
                }

            }

            var idiomaRubro = Utils.Idioma == "es-MX" ? CultureInfo.CurrentCulture.TextInfo.ToTitleCase(rubroEsp.ToLower()) : CultureInfo.CurrentCulture.TextInfo.ToTitleCase(rubroEsp.ToLower());

            HttpContext.Current.Session["gvGastos"] = gv;
            HttpContext.Current.Session["titleGastos"] = idiomaRubro + " - " + tipoDet;
            HttpContext.Current.Session["titleGastosExcel"] = idiomaRubro + "_" + tipoDet;
        }

        private void exportarExcel()
        {
            var nameFile = "Transacciones_" + (string)Session["titleGastosExcel"] + ".xls";
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", nameFile));
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);


                gvGastos.AllowPaging = false;
                List<gvGastos> values = (List<gvGastos>)Session["gvGastos"];
                LlenarGV(values);


                gvGastos.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gvGastos.HeaderRow.Cells)
                {
                    cell.BackColor = gvGastos.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gvGastos.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvGastos.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvGastos.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gvGastos.RenderControl(hw);

                string style = @"<style> .textmode { } </style>";
                Response.Write(sw.ToString());
                //Response.Output.Write();
                //Response.Flush();
                Response.End();
            }
        }

        private void exportarPDF()
        {
            var nameFile = "Transacciones_" + (string)Session["titleGastosExcel"] + ".pdf";
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment;filename={0}", nameFile));
            Response.Charset = "";
            Response.ContentType = "application/octet-stream";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);


                gvGastos.AllowPaging = false;
                List<gvGastos> values = (List<gvGastos>)Session["gvGastos"];
                LlenarGV(values);


                gvGastos.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gvGastos.HeaderRow.Cells)
                {
                    cell.BackColor = gvGastos.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gvGastos.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvGastos.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvGastos.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gvGastos.RenderControl(hw);

                StringReader sr = new StringReader(sw.ToString());
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 100f, 0f);
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
    }
}