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

        protected void gvGastos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvGastos.PageIndex = e.NewPageIndex;
            LlenarGV((List<gvGastos>)Session["gvGastos"]);
        }

        #endregion


        #region METODOS
        private void LlenarGV(List<gvGastos> gv)
        {
            gvGastos.DataSource = gv.OrderBy(x => x.Fecha); //.GroupBy(r => r.mes).Select(x => x.First());
            gvGastos.DataBind();
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

            lblTransacciones.Text = Properties.Resources.TabTransacciones;
            //lblSalida.Text = Properties.Resources.Das_Salida;
            //lblLlego.Text = Properties.Resources.Das_Llego;
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
        public static void ObtenerTransacciones(List<gasto> gastos, string tipoDet)
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

            HttpContext.Current.Session["gvGastos"] = gv;
        }

        #endregion



    }
}