﻿using PortalClientes.Objetos;
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
                if (Session["data"] != null)
                {
                    var tipo = Convert.ToInt32(Session["tipoTransaccion"]);
                    var od = Convert.ToInt32(Session["origenData"]);

                    Transacciones transacciones = new Transacciones();
                    if (tipo == 1)
                    {
                        transacciones.gastos = (List<gvGastos>)Session["data"];
                        LlenarGV(transacciones, tipo);
                    }

                    else if (tipo == 2)
                    {
                        transacciones.gastosAe = (List<gvGastosAeropuerto>)Session["data"];
                        LlenarGV(transacciones, tipo);
                    }

                    else if (tipo == 3)
                    {
                        transacciones.gastosProv = (List<gvGastosProveedor>)Session["data"];
                        LlenarGV(transacciones, tipo);
                    }

                    else if (tipo == 4)
                    {
                        transacciones.vuelos = (List<vuelo>)Session["data"];
                        LlenarGV(transacciones, tipo);
                    }

                    if (od == 1)
                    {
                        btnRegresarMeEs.Visible = false;
                        btnRegresarDash.Visible = true;
                    }
                    else
                    {
                        btnRegresarMeEs.Visible = true;
                        btnRegresarDash.Visible = false;
                    }
                } 
            }
        }

        protected void gvGastos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                var tipo = Convert.ToInt32(Session["tipoTransaccion"]);

                if (tipo == 1)
                {
                    e.Row.Cells[0].Text = Properties.Resources.TabTran_Mes;
                    e.Row.Cells[1].Text = Properties.Resources.TabTran_Rubro;
                    e.Row.Cells[2].Text = Properties.Resources.TabTran_Total;
                    e.Row.Cells[3].Text = Properties.Resources.TabTran_Fecha;
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
                    e.Row.Cells[0].Text = Properties.Resources.TabTran_Mes;
                    e.Row.Cells[1].Text = Properties.Resources.TabTran_Anio;
                    e.Row.Cells[2].Text = Properties.Resources.TabTran_Origen;
                    e.Row.Cells[3].Text = Properties.Resources.TabTran_Destino;
                    e.Row.Cells[4].Text = Properties.Resources.TabTran_IVuelo; 
                    e.Row.Cells[5].Text = Properties.Resources.TabTran_FVuelo;
                    e.Row.Cells[6].Text = Properties.Resources.TabTran_TVuelo;
                    e.Row.Cells[7].Text = Properties.Resources.TabTran_Categoria;
                }             
            }
        }

        protected void gvGastos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            var tipo = Convert.ToInt32(Session["tipoTransaccion"]);
            Transacciones transacciones = new Transacciones();
            gvGastos.PageIndex = e.NewPageIndex;
            if (tipo == 1)
            {
                transacciones.gastos = (List<gvGastos>)Session["data"];
                LlenarGV(transacciones, tipo);
            }

            else if (tipo == 2)
            {
                transacciones.gastosAe = (List<gvGastosAeropuerto>)Session["data"];
                LlenarGV(transacciones, tipo);
            }

            else if (tipo == 3)
            {
                transacciones.gastosProv = (List<gvGastosProveedor>)Session["data"];
                LlenarGV(transacciones, tipo);
            }

            else if (tipo == 4)
            {
                transacciones.gastos = (List<gvGastos>)Session["data"];
                LlenarGV(transacciones, tipo);
            }

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
        private void LlenarGV(Transacciones transacciones, int tipoTransaccion)
        {
            var contMeses = 0;
            var totalTransacciones = 0.0;
            var promedio = 0.0;
            var totalRegistros = 0;

            gvGastos.DataSource = null;

            if (tipoTransaccion == 1)
            {
                totalRegistros = transacciones.gastos.Count();
                contMeses = transacciones.gastos.GroupBy(r => r.mes).Count();
                totalTransacciones = transacciones.gastos.Sum(x => x.Total);
                promedio = totalTransacciones / contMeses;

                BoundField clm = new BoundField();
                clm.DataField = "mes";
                gvGastos.Columns.Add(clm);

                BoundField clm3 = new BoundField();
                clm3.DataField = "Rubro";
                gvGastos.Columns.Add(clm3);

                BoundField clm4 = new BoundField();
                clm4.DataField = "Total";
                clm4.DataFormatString = "{0:C2}";
                gvGastos.Columns.Add(clm4);

                BoundField clm5 = new BoundField();
                clm5.DataField = "Fecha";
                gvGastos.Columns.Add(clm5);

                BoundField clm6 = new BoundField();
                clm6.DataField = "Categoria";
                gvGastos.Columns.Add(clm6);

                BoundField clm7 = new BoundField();
                clm7.DataField = "tipodeGasto";
                gvGastos.Columns.Add(clm7);

                BoundField clm8 = new BoundField();
                clm8.DataField = "comentarios";
                gvGastos.Columns.Add(clm8);

                gvGastos.DataSource = transacciones.gastos.OrderBy(x => x.Fecha).ToList(); //.GroupBy(r => r.mes).Select(x => x.First());
                gvGastos.DataBind();
            }
            else if (tipoTransaccion == 2)
            {
                totalRegistros = transacciones.gastosAe.Count();
                contMeses = transacciones.gastosAe.GroupBy(r => r.Mes).Count();
                totalTransacciones = transacciones.gastosAe.Sum(x => x.Total);
                promedio = totalTransacciones / contMeses;

                BoundField clm = new BoundField();
                clm.DataField = "mes";
                gvGastos.Columns.Add(clm);

                BoundField clm3 = new BoundField();
                clm3.DataField = "Rubro";
                gvGastos.Columns.Add(clm3);

                BoundField clm4 = new BoundField();
                clm4.DataField = "Total";
                clm4.DataFormatString = "{0:c}";
                gvGastos.Columns.Add(clm4);

                BoundField clm6 = new BoundField();
                clm6.DataField = "Anio";
                gvGastos.Columns.Add(clm6);

                BoundField clm7 = new BoundField();
                clm7.DataField = "NoPierna";
                gvGastos.Columns.Add(clm7);

                BoundField clm8 = new BoundField();
                clm8.DataField = "Proveedor";
                gvGastos.Columns.Add(clm8);

                BoundField clm9 = new BoundField();
                clm9.DataField = "Categoria";
                gvGastos.Columns.Add(clm9);

                BoundField clm10 = new BoundField();
                clm10.DataField = "Origen";
                gvGastos.Columns.Add(clm10);

                BoundField clm11 = new BoundField();
                clm11.DataField = "Destino";
                gvGastos.Columns.Add(clm11);

                gvGastos.DataSource = transacciones.gastosAe.OrderBy(x => x.Mes).ToList(); //.GroupBy(r => r.mes).Select(x => x.First());
                gvGastos.DataBind();
            }
            else if (tipoTransaccion == 3)
            {
                totalRegistros = transacciones.gastosProv.Count();
                contMeses = transacciones.gastosProv.GroupBy(r => r.Mes).Count();
                totalTransacciones = transacciones.gastosProv.Sum(x => x.Total);
                promedio = totalTransacciones / contMeses;

                BoundField clm = new BoundField();
                clm.DataField = "mes";
                gvGastos.Columns.Add(clm);

                BoundField clm3 = new BoundField();
                clm3.DataField = "Rubro";
                gvGastos.Columns.Add(clm3);

                BoundField clm4 = new BoundField();
                clm4.DataField = "Total";
                clm4.DataFormatString = "{0:c}";
                gvGastos.Columns.Add(clm4);

                BoundField clm6 = new BoundField();
                clm6.DataField = "Anio";
                gvGastos.Columns.Add(clm6);

                BoundField clm7 = new BoundField();
                clm7.DataField = "NoPierna";
                gvGastos.Columns.Add(clm7);

                BoundField clm8 = new BoundField();
                clm8.DataField = "Proveedor";
                gvGastos.Columns.Add(clm8);

                BoundField clm9 = new BoundField();
                clm9.DataField = "Categoria";
                gvGastos.Columns.Add(clm9);

                BoundField clm10 = new BoundField();
                clm10.DataField = "Origen";
                gvGastos.Columns.Add(clm10);

                BoundField clm11 = new BoundField();
                clm11.DataField = "Destino";
                gvGastos.Columns.Add(clm11);

                gvGastos.DataSource = transacciones.gastosProv.OrderBy(x => x.Mes).ToList(); //.GroupBy(r => r.mes).Select(x => x.First());
                gvGastos.DataBind();
            }
            else if (tipoTransaccion == 4)
            {
                totalRegistros = transacciones.vuelos.Count();
                contMeses = transacciones.vuelos.GroupBy(r => r.mes).Count();
                totalTransacciones = 0;//transacciones.vuelos.Sum(x => x.Total);
                promedio = 0;// totalTransacciones / contMeses;

                BoundField clm = new BoundField();
                clm.DataField = "mes";
                gvGastos.Columns.Add(clm);

                BoundField clm2 = new BoundField();
                clm2.DataField = "anio";
                gvGastos.Columns.Add(clm2);

                BoundField clm3 = new BoundField();
                clm3.DataField = "origen";
                gvGastos.Columns.Add(clm3);

                BoundField clm4 = new BoundField();
                clm4.DataField = "destino";
                gvGastos.Columns.Add(clm4);

                BoundField clm5 = new BoundField();
                clm5.DataField = "origenVuelo";
                gvGastos.Columns.Add(clm5);

                BoundField clm6 = new BoundField();
                clm6.DataField = "destinoVuelo";
                gvGastos.Columns.Add(clm6);

                BoundField clm7 = new BoundField();
                clm7.DataField = "tiempoVlo";
                gvGastos.Columns.Add(clm7);

                BoundField clm8 = new BoundField();
                clm8.DataField = "categoria";
                gvGastos.Columns.Add(clm8);

                gvGastos.DataSource = transacciones.vuelos.OrderBy(x => x.mes).ToList(); //.GroupBy(r => r.mes).Select(x => x.First());
                gvGastos.DataBind();
            }

            lblTotalTrasnRes.Text = totalRegistros.S();
            lblTotalRes.Text = totalTransacciones.ToString("C", CultureInfo.CreateSpecificCulture("es-MX"));
            lblPromedioRes.Text = promedio.ToString("C", CultureInfo.CreateSpecificCulture("es-MX"));
            
        }

        private void ArmarTransacciones()
        {
            lblTransacciones.Text = Properties.Resources.TabTransacciones + " - " + Session["title"];
            lblTitulo.Text = Properties.Resources.TabTransacciones;

            lblTotalTrasn.Text = Properties.Resources.TabTran_NoGastos;
            lblTotal.Text = Properties.Resources.TabTran_MontoTotal;
            lblPromedio.Text = Properties.Resources.TabTran_PromedioMens;
        }

        public string MonthName(int month)
        {
            DateTimeFormatInfo dtinfo = new CultureInfo("es-ES", false).DateTimeFormat;
            return dtinfo.GetMonthName(month);
        }

        [WebMethod]
        public static void ObtenerTransacciones(List<gasto> gastos, List<gastoAeropuerto> gastosAe, List<gastoProveedor> gastosProv, List<vuelo> vuelos, int tipoTrans, string tipoDet, string descES, string descEN, int origen)
        {
            // tipo transaccion: 1 gastos
            // tipo transaccion: 2 gastosAe
            // tipo transaccion: 3 gastosProv
            // tipo transaccion: 4 vuelos

            List<gvGastos> gv = new List<gvGastos>();
            List<gvGastosAeropuerto> gva = new List<gvGastosAeropuerto>();
            List<gvGastosProveedor> gvp = new List<gvGastosProveedor>();
            List<vuelo> gvv = new List<vuelo>();

            DateTimeFormatInfo month = null;

            if(Utils.Idioma == "es-MX")
            {
                month = new CultureInfo("es-ES", false).DateTimeFormat;
            }
            else
            {
                month = new CultureInfo("en-US", false).DateTimeFormat;
            }
                

            if (tipoTrans == 1)
            {
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

                HttpContext.Current.Session["data"] = gv;
            }

            else if (tipoTrans == 2)
            {
                foreach (var item in gastosAe)
                {
                    gvGastosAeropuerto g = new gvGastosAeropuerto();
                    g.IdRubro = item.idRubro.Value;
                    g.Rubro = Utils.Idioma == "es-MX" ? item.rubroESP : item.rubroENG;
                    g.Total = item.totalMXN;
                    g.Mes = month.GetMonthName(item.mes.Value);
                    g.Anio = item.anio.HasValue ? item.anio.Value : 0;
                    g.NoPierna = item.noPierna.HasValue ? item.noPierna.Value : 0;
                    g.Proveedor = item.proveedor;
                    g.Categoria = item.categoria;
                    g.Origen = item.origen;
                    g.TipoMoneda = item.tipoMoneda;
                    g.Destino = item.destino;

                    gva.Add(g);
                }

                HttpContext.Current.Session["data"] = gva;
            }

            else if (tipoTrans == 3)
            {
                foreach (var item in gastosProv)
                {
                    gvGastosProveedor g = new gvGastosProveedor();
                    g.IdRubro = item.idRubro.Value;
                    g.Rubro = Utils.Idioma == "es-MX" ? item.rubroESP : item.rubroENG;
                    g.Total = item.totalMXN;
                    g.Mes = month.GetMonthName(item.mes.Value);
                    g.Anio = item.anio.HasValue ? item.anio.Value : 0;
                    g.NoPierna = item.noPierna.HasValue ? item.noPierna.Value : 0;
                    g.Proveedor = item.proveedor;
                    g.Categoria = item.categoria;
                    g.Origen = item.origen;
                    g.TipoMoneda = item.tipoMoneda;
                    g.Destino = item.destino;

                    gvp.Add(g);
                }

                HttpContext.Current.Session["data"] = gvp;
            }

            else if (tipoTrans == 4)
            {
                foreach (var item in vuelos)
                {
                    vuelo g = new vuelo();
                    g.mes = month.GetMonthName(Convert.ToInt32(item.mes));
                    g.anio = item.anio;
                    g.origen = item.origen;
                    g.destino = item.destino;
                    g.origenVuelo = Convert.ToDateTime(item.origenVuelo).ToString("dd/MM/yyyy HH:mm");
                    g.destinoVuelo = Convert.ToDateTime(item.destinoVuelo).ToString("dd/MM/yyyy HH:mm");
                    g.tiempoVlo = item.tiempoVlo;
                    g.categoria = item.categoria;

                    gvv.Add(g);
                }

                HttpContext.Current.Session["data"] = gvv;
            }


            var descripcion = Utils.Idioma == "es-MX" ? CultureInfo.CurrentCulture.TextInfo.ToTitleCase(descES.ToLower()) : CultureInfo.CurrentCulture.TextInfo.ToTitleCase(descEN.ToLower());

            HttpContext.Current.Session["origenData"] = origen;
            HttpContext.Current.Session["tipoTransaccion"] = tipoTrans;
            HttpContext.Current.Session["title"] = descripcion + " - " + tipoDet;
            HttpContext.Current.Session["titleFile"] = descripcion + "_" + tipoDet;
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


                gvGastos.AllowPaging = false;
                var tipo = Convert.ToInt32(Session["tipoTransaccion"]);
                Transacciones transacciones = new Transacciones();
                if (tipo == 1)
                {
                    transacciones.gastos = (List<gvGastos>)Session["data"];
                    LlenarGV(transacciones, tipo);
                }

                else if (tipo == 2)
                {
                    transacciones.gastosAe = (List<gvGastosAeropuerto>)Session["data"];
                    LlenarGV(transacciones, tipo);
                }

                else if (tipo == 3)
                {
                    transacciones.gastosProv = (List<gvGastosProveedor>)Session["data"];
                    LlenarGV(transacciones, tipo);
                }

                else if (tipo == 4)
                {
                    transacciones.vuelos = (List<vuelo>)Session["data"];
                    LlenarGV(transacciones, tipo);
                }


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


                gvGastos.AllowPaging = false;
                var tipo = Convert.ToInt32(Session["tipoTransaccion"]);
                Transacciones transacciones = new Transacciones();
                if (tipo == 1)
                {
                    transacciones.gastos = (List<gvGastos>)Session["data"];
                    LlenarGV(transacciones, tipo);
                }

                else if (tipo == 2)
                {
                    transacciones.gastosAe = (List<gvGastosAeropuerto>)Session["data"];
                    LlenarGV(transacciones, tipo);
                }

                else if (tipo == 3)
                {
                    transacciones.gastosProv = (List<gvGastosProveedor>)Session["data"];
                    LlenarGV(transacciones, tipo);
                }

                else if (tipo == 4)
                {
                    transacciones.vuelos = (List<vuelo>)Session["data"];
                    LlenarGV(transacciones, tipo);
                }


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
    }
}