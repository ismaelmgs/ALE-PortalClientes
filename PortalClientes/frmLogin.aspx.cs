using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalClientes.Clases;
using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using PortalClientes.Presenter;
using NucleoBase.Core;
using PortalClientes.Objetos;

namespace PortalClientes
{
    public partial class frmLogin : System.Web.UI.Page, IViewLogin
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

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            bool ban = true;
            if (txtUsuarios.Text.S() == string.Empty)
            {
                txtUsuarios.IsValid = false;
                txtUsuarios.ValidationSettings.ErrorText = Utils.Idioma == "es-MX" ? "El campo es requerido" : "This field is required";
                ban = false;
            }

            if (txtPassword.Text.S() == string.Empty)
            {
                txtPassword.IsValid = false;
                txtPassword.ValidationSettings.ErrorText = Utils.Idioma == "es-MX" ? "El campo es requerido" : "This field is required";
                ban = false;
            }

            if (ban)
            {
                if (eObjSelected != null)
                    eObjSelected(sender, e);

                if (oUser.IdUsuario != 0)
                    Response.Redirect("Views/frmUsuarios.aspx");
            }
        }

        #endregion

        #region METODOS

        private void ArmaFormulario()
        {
            txtUsuarios.NullText = Properties.Resources.Lo_Correo;
            txtPassword.NullText = Properties.Resources.Lo_Contrasena;
            btnEntrar.Text = Properties.Resources.Lo_Ingresar;
            lblAcceso.Text = Properties.Resources.Lo_Titulo;
            lblOlvidoPAssword.Text = Properties.Resources.Lo_OlvidoPass;
        }

        private void CambiaIdioma()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
            ArmaFormulario();
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
            get { return txtUsuarios.Text.S(); }
        }

        public string sPassword
        {
            get { return txtPassword.Text.S(); }
        }

        public Usuario oUser
        {
            set { ViewState["VSUsuario"] = value; }
            get { return (Usuario)ViewState["VSUsuario"]; }
        }

        public UserIdentity oU
        {
            set { Session["UserIdentity"] = value; }
            get { return (UserIdentity)Session["UserIdentity"]; }
        }
        #endregion
    }
}