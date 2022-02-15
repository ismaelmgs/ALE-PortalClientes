using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalClientes.Clases;
using PortalClientes.Interfaces;
using PortalClientes.Presenter;
using PortalClientes.DomainModel;
using PortalClientes.Objetos;
using NucleoBase.Core;

namespace PortalClientes.Views
{
    public partial class frmEditusuario : System.Web.UI.Page, IViewUser
    {
        #region EVENTOS
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["RefUrl"] = Request.Url.ToString();
            if (System.Web.HttpContext.Current.Session["UserIdentity"] == null)
            {
                Response.Redirect("~/Views/frmFinconexion2.aspx");
            }

            oPresenter = new User_Presenter(this, new DBUsuarios());

            TextBox milabel = (TextBox)this.Master.FindControl("txtLang");
            if (milabel.Text != Utils.Idioma && milabel.Text != string.Empty)
            {
                Utils.Idioma = milabel.Text;
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmaFormulario();
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmaFormulario();
            }

            if (!IsPostBack)
            {
                LlenaFormulario();
            }
        }

        protected void btnEditarUsuario_Click(object sender, EventArgs e)
        {
            if (eSaveObj != null)
                eSaveObj(sender, e);
        }

        public void recargarPagina(responceAct resp)
        {
            if(resp.mensaje == "Operación ejecutada correctamente")
            {
                System.Web.HttpContext.Current.Session["VSUsuario"] = oUsuario;
                lblMessageConfirm.Text = "Usurio Guardado con Exito!, Para ver los cambios reflejados es necesario iniciar sesion nuevamente.";
                mpeConfirm.Show();
            }
            else
            {
                Response.Redirect("~/Views/frmEditusuario.aspx");
            }
        }

        #endregion


        #region METODOS

        private void ArmaFormulario()
        {
            txtCorreo.Attributes.Add("placeholder", Properties.Resources.CorreoEjemplo);
            lblNombre.Text = Properties.Resources.Us_Nombre;
            lblApellidoPat.Text = Properties.Resources.Us_ApePat;
            lblApellidoMat.Text = Properties.Resources.Us_ApeMat;
            lblCorreo.Text = Properties.Resources.Correo;
            lblPuesto.Text = Properties.Resources.Us_Puesto;
            lblCorreoSecundario.Text = Properties.Resources.Us_CorreoSecundario;
            lblTelefonoOficina.Text = Properties.Resources.Us_TelefonoOficina;
            lblTelefonoMovil.Text = Properties.Resources.Us_Celular;
            btnAceptConfirm.Text = Properties.Resources.Aceptar;

            txtCorreo.Enabled = false;
        }

        private void LlenaFormulario()
        {
            oUsuario = (Usuario)System.Web.HttpContext.Current.Session["VSUsuario"];
        }

        #endregion


        #region VARIABLES Y PROPIEDADES

        public Usuario oUsuario
        {
            get
            {
                return new Usuario()
                {
                    Nombres = txtNombre.Text.S(),
                    ApePat = txtApellidoPat.Text.S(),
                    ApeMat = txtApellidoMat.Text.S(),
                    Puesto = txtPuesto.Text.S(),
                    Correo = txtCorreo.Text.S(),
                    TelefonoMovil = txtTelMovil.Text.S(),
                    CorreoSecundario = txtCorreoSecundario.Text.S(),
                    TelefonoOficina = txtTelefonoOficina.Text.S(),
                    tipoActualizacion = 1
                };
            }
            set
            {
                Usuario oUser = (Usuario)value;
                txtNombre.Text = oUser.Nombres;
                txtApellidoPat.Text = oUser.ApePat;
                txtApellidoMat.Text = oUser.ApeMat;
                txtPuesto.Text = oUser.Puesto;
                txtCorreo.Text = oUser.Correo;
                txtTelMovil.Text = oUser.TelefonoMovil;
                txtTelefonoOficina.Text = oUser.TelefonoOficina;
                txtCorreoSecundario.Text = oUser.CorreoSecundario;
            }
        }

        public event EventHandler eNewObj;
        public event EventHandler eObjSelected;
        public event EventHandler eSaveObj;
        public event EventHandler eDeleteObj;
        public event EventHandler eSearchObj;

        User_Presenter oPresenter;

        #endregion
    }
}