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
                }

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lkb = (LinkButton)e.Row.FindControl("lkbDetalle");
                    lkb.Text = Properties.Resources.Ec_VerDetalle;
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
            foreach (responseRepEdoCuenta item in olstRep)
            {
                item.nombreMes = ObtienePeriodoEdoCuenta(item.mes, item.anio);
            }

            gvEdoCuenta.DataSource = olstRep;
            gvEdoCuenta.DataBind();
        }
        #endregion

        #region VARIABLES Y PROPIEDADES

        EstadoCuenta_Presenter oPresenter;
        public event EventHandler eNewObj;
        public event EventHandler eObjSelected;
        public event EventHandler eSaveObj;
        public event EventHandler eDeleteObj;
        public event EventHandler eSearchObj;

        #endregion

    }
}