using NucleoBase.Core;
using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using PortalClientes.Objetos;
using PortalClientes.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalClientes.Clases;

namespace PortalClientes
{
    public partial class frmLoginLoss : System.Web.UI.Page, IViewLogin
    {
       
        #region EVENTOS
        protected void Page_Load(object sender, EventArgs e)
        {
            oPresenter = new Login_Presenter(this, new DBLogin());

            if (!IsPostBack)
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmaFormulario();
            }
        }

        protected void btnEviarContrasena_Click(object sender, EventArgs e)
        {
            if(eSaveObj != null)
                eSaveObj(sender, e);
        }
        #endregion

        #region METODOS

        private void ArmaFormulario()
        {
            lblLoginLossHeader.Text = Properties.Resources.Lo_CamContrasena;
            txtEmail.Text = Properties.Resources.Lo_Correo;
            lblRegresarLogin.Text = Properties.Resources.Lo_BackLogin;
            btnEviarContrasena.Text = Properties.Resources.Lo_Enviar;
        }

        #endregion

        #region VARIABLES Y PROPIEDADES

        Login_Presenter oPresenter;

        public event EventHandler eNewObj;
        public event EventHandler eObjSelected;
        public event EventHandler eSaveObj;
        public event EventHandler eDeleteObj;
        public event EventHandler eSearchObj;

        public string sEmail
        {
            get { return txtEmail.Text.S(); }
        }

        public string sPassword => throw new NotImplementedException();

        public Usuario oUser { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public UserIdentity oU { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #endregion
    }
}