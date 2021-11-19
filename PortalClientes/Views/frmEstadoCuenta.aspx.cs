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

            if (oEstado.saldoActualUSD < 0)
                lblMontoReqRes.ForeColor = Color.Green;
            if (oEstado.saldoActualUSD > 0)
                lblMontoReqRes.ForeColor = Color.Red;
            //if (oEstado.saldoActualUSD == 0)
            //    lblMontoReqRes.ForeColor = Color.Black;

            lblMontoReqRes.Text = oEstado.saldoActualUSD.ToString("n");


            lblSaldoActualMXNRes.Text = oEstado.saldoAnteriorMXN.ToString("n");
            lblNuevosCargosMXNRes.Text = oEstado.nuevosCargosMXN.ToString("n");
            lblPagosPeriodoMXNRes.Text = oEstado.pagosCreditosMXN.ToString("n");

            if (oEstado.saldoActualMXN < 0)
                lblMontoReqMXNRes.ForeColor = Color.Green;
            if(oEstado.saldoActualMXN > 0)
                lblMontoReqMXNRes.ForeColor = Color.Red;
            //if (oEstado.saldoActualMXN == 0)
            //    lblMontoReqMXNRes.ForeColor = Color.Black;

            lblMontoReqMXNRes.Text = oEstado.saldoActualMXN.ToString("n");
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