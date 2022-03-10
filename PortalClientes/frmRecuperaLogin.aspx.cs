using NucleoBase.Core;
using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using PortalClientes.Objetos;
using PortalClientes.Clases;
using PortalClientes.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalClientes
{
    public partial class frmRecuperaLogin : System.Web.UI.Page, IViewRecoveryPass
    {
        #region EVENTOS
        protected void Page_Load(object sender, EventArgs e)
        {
            oPresenter = new RecoveryPass_Presenter(this, new DBLogin());

            sEmail = Request.QueryString["email"];
            sTime = Request.QueryString["timeInterval"];

            string formatString = "ddMMyyHHmm";
            DateTime dt = DateTime.ParseExact(sTime, formatString, null);

            if (DateTime.Now > dt)
            {
                lblMessageConfirm.Text = "El metodo de recuperacion ah expirado, intentalo nuevamente";
                mpeConfirm.Show();
            }

            if (!IsPostBack)
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmaFormulario();
            }
        }

        protected void btnRecuperarContrasena_Click(object sender, EventArgs e)
        {
            try
            {
                iTipoActualizacion = 2;
                if (EsValidoFormulario())
                {
                    if (eNewObj != null)
                        eNewObj(sender, e);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAceptConfirm_Click(object sender, EventArgs e)
        {
            mpeConfirm.Hide();
            Response.Redirect("~/frmLogin.aspx");
        }

        protected void lblIdiomaEspanol_Click(object sender, EventArgs e)
        {
            Utils.Idioma = "es-MX";
            CambiaIdioma();
        }

        protected void lblIdiomaEnglish_Click(object sender, EventArgs e)
        {
            Utils.Idioma = "en-US";
            CambiaIdioma();
        }

        #endregion

        #region METODOS

        private void ArmaFormulario()
        {
            Regex1.ErrorMessage = Properties.Resources.Us_ValidacionContrasena;
            Regex2.ErrorMessage = Properties.Resources.Us_ValidacionConfirmContrasena;
            lblPass.Text = Properties.Resources.Us_Password;
            lblConfirPass.Text = Properties.Resources.Us_ConfirPass;
            lblLoginLossHeader.Text = Properties.Resources.Lo_NuevaContrasena;
            lblRegresarLogin.Text = Properties.Resources.Lo_BackLogin;
            btnRecuperarContrasena.Text = Properties.Resources.Lo_Actualizar;
            lblMessageConfirm.Text = Properties.Resources.Lo_ActConfirmContrasena;
        }

        public bool EsValidoFormulario()
        {
            bool ban = true;

            if (txtPass.Text.S() == string.Empty)
            {
                lblReqPass.Visible = true;
                lblReqPass.Text = Properties.Resources.Cm_CampoReq;
                ban = false;
            }
            else
            {
                lblReqPass.Visible = false;
                lblReqPass.Text = string.Empty;

                if (txtConfirPass.Text.S() == string.Empty)
                {
                    lblReqConfirPass.Visible = true;
                    lblReqConfirPass.Text = Properties.Resources.Cm_CampoReq;
                    ban = false;
                }
                else
                {
                    if (txtPass.Text.S() != txtConfirPass.Text.S())
                    {
                        lblReqConfirPass.Visible = true;
                        lblReqConfirPass.Text = Properties.Resources.Us_ValConfirPass;
                        ban = false;
                    }
                    else
                    {
                        lblReqConfirPass.Visible = false;
                        lblReqConfirPass.Text = string.Empty;
                    }
                }
            }

            return ban;
        }

        public void requestResponse(responceAct response)
        {
            if (response.mensaje == "Operación ejecutada correctamente")
            {          
                mpeConfirm.Show();
            }
        }

        private void CambiaIdioma()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
            ArmaFormulario();
        }

        #endregion

        #region VARIABLES Y PROPIEDADES

        RecoveryPass_Presenter oPresenter;

        public event EventHandler eNewObj;
        public event EventHandler eObjSelected;
        public event EventHandler eSaveObj;
        public event EventHandler eDeleteObj;
        public event EventHandler eSearchObj;

        public string sEmail
        {
            get { return ViewState["VSsEmail"].S(); }
            set { ViewState["VSsEmail"] = value; }
        }

        public string sTime
        {
            get { return ViewState["VSsTime"].S(); }
            set { ViewState["VSsTime"] = value; }
        }

        public string sPassword
        {
            get { return txtPass.Text.S(); }
        }

        public int iTipoActualizacion
        {
            get { return ViewState["VSiTipoActualizacion"].I(); }
            set { ViewState["VSiTipoActualizacion"] = value; }
        }

        #endregion


    }
}