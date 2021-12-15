using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using PortalClientes.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalClientes.Clases;
using PortalClientes.Objetos;
using NucleoBase.Core;
using System.Drawing;
using System.Data;

namespace PortalClientes.Views
{
    public partial class frmEstadoCuenta : System.Web.UI.Page, IViewEstadoCuenta
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (System.Web.HttpContext.Current.Session["UserIdentity"] == null)
            {
                Response.Redirect("~/Views/frmFinconexion2.aspx");
            }

            oPresenter = new EstadoCuenta_Presenter(this, new DBEstadoCuenta());

            TextBox milabel = (TextBox)this.Master.FindControl("txtLang");
            if (milabel.Text != Utils.Idioma && milabel.Text != string.Empty)
            {
                Utils.Idioma = milabel.Text;
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmarEstadoCuenta();
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmarEstadoCuenta();
            }

            if (!IsPostBack)
            {
                if (eSearchObj != null)
                    eSearchObj(sender, e);
            }
        }

        protected void gvEdoCuenta_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                responseRepEdoCuenta doc = (responseRepEdoCuenta)e.Row.DataItem;
                var existeDoc = doc != null ? doc.docF : 0;

                if (e.Row.RowType == DataControlRowType.Header)
                {
                    e.Row.Cells[0].Text = Properties.Resources.Ec_NombreMes;

                    e.Row.Cells[1].Text = Properties.Resources.Ec_SaldoAnteriorMXN;
                    e.Row.Cells[2].Text = Properties.Resources.Ec_PagosCreditosMXN;
                    e.Row.Cells[3].Text = Properties.Resources.Ec_NuevosCargosMXN;
                    e.Row.Cells[4].Text = Properties.Resources.Ec_SaldoActualMXN;

                    e.Row.Cells[5].Text = Properties.Resources.Ec_SaldoAnteriosUSD;
                    e.Row.Cells[6].Text = Properties.Resources.Ec_PagosCreditosUSD;
                    e.Row.Cells[7].Text = Properties.Resources.Ec_NuevosCargosUSD;
                    e.Row.Cells[8].Text = Properties.Resources.Ec_SaldoActualUSD;
                    e.Row.Cells[9].Text = Properties.Resources.Ec_VerDetalleTitle;
                        e.Row.Cells[10].Text = Properties.Resources.Ec_VerFacturaTitle;
                
                }

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lkb = (LinkButton)e.Row.FindControl("lkbDetalle");
                    lkb.Text = Properties.Resources.Ec_VerDetalle;

                    if(existeDoc == 0)
                    {
                        e.Row.Cells[10].Visible = false;
                    }
                    else
                    {
                        LinkButton lkbvd = (LinkButton)e.Row.FindControl("lkbViewDocument");
                        lkbvd.Text = Properties.Resources.Ec_VerFactura;
                    } 
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvEdoCuenta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            iMes = gvEdoCuenta.DataKeys[e.CommandArgument.S().I()]["Mes"].S().I();
            iAnio = gvEdoCuenta.DataKeys[e.CommandArgument.S().I()]["Anio"].S().I();

            if (e.CommandName == "Detalle")
            {
                Session["tipoTransaccion"] = 13;
                Session["origenData"] = 3;
                
                responseRepEdoCuenta oEC = (responseRepEdoCuenta) oEstados.Where(x => x.mes == iMes).FirstOrDefault();
                if (oEC != null)
                {
                    Session["descripcion"] = ObtienePeriodoEdoCuenta(oEC.mes, oEC.anio);
                    Session["data"] = oEC.olsDetalle;
                    Response.Redirect("frmTransacciones.aspx");
                }
            }

            if(e.CommandName == "ViewDocument")
            {
                if (eSearchObjDocs != null)
                    eSearchObjDocs(sender, e);
            }
        }

        protected void gvDocEdoCuenta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Download")
            {
                
            }
        }

        protected void gvDocEdoCuenta_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = Properties.Resources.Ec_Clave;
                e.Row.Cells[1].Text = Properties.Resources.Ec_RazonSocial;
                e.Row.Cells[2].Text = Properties.Resources.Ec_TipoDocumento;
                e.Row.Cells[3].Text = Properties.Resources.Ec_Anio;
                e.Row.Cells[4].Text = Properties.Resources.Ec_Mes;
                e.Row.Cells[5].Text = Properties.Resources.Ec_Dia;
                e.Row.Cells[6].Text = Properties.Resources.Ec_Download;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lkb = (LinkButton)e.Row.FindControl("lkbDownloadDoc");
                lkb.Text = Properties.Resources.Ec_DownloadDoc;
            }
        }

        #region METODOS
        private void ArmarEstadoCuenta()
        {
            lblTitulo.Text = Properties.Resources.Ec_Titulo;
            lblResumenDeCuenta.Text = Properties.Resources.Ec_ResumenCuenta;
            lblResumenPeriodo.Text = Properties.Resources.Ec_ResumenCuenta;
            lblSaldoActual.Text = Properties.Resources.Ec_SaldoActual;
            lblSaldoActualMXN.Text = Properties.Resources.Ec_SaldoActual;
            lblNuevosCargos.Text = Properties.Resources.Ec_NuevosCargos;
            lblNuevosCargosMXN.Text = Properties.Resources.Ec_NuevosCargos;
            lblPagosPeriodo.Text = Properties.Resources.Ec_PagosPeriodo;
            lblPagosPeriodoMXN.Text = Properties.Resources.Ec_PagosPeriodo;
            lblMontoReq.Text = Properties.Resources.Ec_PagoRequerido;
            lblMontoReqMXN.Text = Properties.Resources.Ec_PagoRequerido;
        }

        public void LlenaEstadoCuenta(EstadoCuenta oEstado)
        {
            lblSaldoActualRes.Text = oEstado.saldoAnteriorUSD.ToString("n");
            lblNuevosCargosRes.Text = oEstado.nuevosCargosUSD.ToString("n");
            lblPagosPeriodoRes.Text = oEstado.pagosCreditosUSD.ToString("n");

            if (oEstado.saldoActalUSD < 0)
                lblMontoReqRes.ForeColor = Color.Green;
            if (oEstado.saldoActalUSD > 0)
                lblMontoReqRes.ForeColor = Color.Red;
            //if (oEstado.saldoActualUSD == 0)
            //    lblMontoReqRes.ForeColor = Color.Black;

            lblMontoReqRes.Text = oEstado.saldoActalUSD.ToString("n");


            lblSaldoActualMXNRes.Text = oEstado.saldoAnteriorMXN.ToString("n");
            lblNuevosCargosMXNRes.Text = oEstado.nuevosCargosMXN.ToString("n");
            lblPagosPeriodoMXNRes.Text = oEstado.pagosCreditosMXN.ToString("n");

            if (oEstado.saldoActalMXN < 0)
                lblMontoReqMXNRes.ForeColor = Color.Green;
            if(oEstado.saldoActalMXN > 0)
                lblMontoReqMXNRes.ForeColor = Color.Red;
            //if (oEstado.saldoActualMXN == 0)
            //    lblMontoReqMXNRes.ForeColor = Color.Black;

            lblMontoReqMXNRes.Text = oEstado.saldoActalMXN.ToString("n");
            lblPeriodo.Text = ObtienePeriodoEdoCuenta(oEstado.mes, oEstado.anio);
        }

        private string ObtienePeriodoEdoCuenta(int iMes, int iAnio)
        {
            string Periodo = string.Empty;
            switch (iMes)
            {
                case 1:
                    Periodo = Properties.Resources.Cm_Enero;
                    break;
                case 2:
                    Periodo = Properties.Resources.Cm_Febrero;
                    break;
                case 3:
                    Periodo = Properties.Resources.Cm_Marzo;
                    break;
                case 4:
                    Periodo = Properties.Resources.Cm_Abril;
                    break;
                case 5:
                    Periodo = Properties.Resources.Cm_Mayo;
                    break;
                case 6:
                    Periodo = Properties.Resources.Cm_Junio;
                    break;
                case 7:
                    Periodo = Properties.Resources.Cm_Julio;
                    break;
                case 8:
                    Periodo = Properties.Resources.Cm_Agosto;
                    break;
                case 9:
                    Periodo = Properties.Resources.Cm_Septiembre;
                    break;
                case 10:
                    Periodo = Properties.Resources.Cm_Octubre;
                    break;
                case 11:
                    Periodo = Properties.Resources.Cm_Noviembre;
                    break;
                case 12:
                    Periodo = Properties.Resources.Cm_Diciembre;
                    break;
            }

            return Periodo + " " + iAnio.S();
        }

        public void LlenaTableEdoCuenta(List<responseRepEdoCuenta> olstRep)
        {
            oEstados = olstRep;

            foreach (responseRepEdoCuenta item in olstRep)
            {
                item.nombreMes = ObtienePeriodoEdoCuenta(item.mes, item.anio);

                foreach (DetalleRepEdoCuenta itemD in item.olsDetalle)
                {
                    itemD.nombreMes = ObtienePeriodoEdoCuenta(itemD.mes, itemD.anio);
                }
            }

            gvEdoCuenta.DataSource = olstRep;
            gvEdoCuenta.DataBind();
        }

        public void LlenaDocsEdoCuenta(List<responseDocumentoF> olstRep)
        {
            gvDocEdoCuenta.DataSource = olstRep;
            gvDocEdoCuenta.DataBind();

            mpeDocsEdoCuenta.Show();
        }
        #endregion

        #region VARIABLES Y PROPIEDADES

        EstadoCuenta_Presenter oPresenter;
        public event EventHandler eNewObj;
        public event EventHandler eObjSelected;
        public event EventHandler eSaveObj;
        public event EventHandler eDeleteObj;
        public event EventHandler eSearchObj;
        public event EventHandler eSearchObjDocs;

        public List<responseRepEdoCuenta> oEstados
        {
            get { return (List<responseRepEdoCuenta>)ViewState["VSEstados"]; }
            set { ViewState["VSEstados"] = value; }
        }

        public int iMes
        {
            get { return ViewState["VSMes"].S().I(); }
            set { ViewState["VSMes"] = value; }
        }

        public int iAnio
        {
            get { return ViewState["VSAnio"].S().I(); }
            set { ViewState["VSAnio"] = value; }
        }

        public int iExisteDoc
        {
            get { return ViewState["VSExisteDoc"].S().I(); }
            set { ViewState["VSExisteDoc"] = value; }
        }

        #endregion
    }
}