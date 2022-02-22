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
            tipoActualizacion = 1; // Actualizar datos del usuario
            if (eSaveObj != null)
                eSaveObj(sender, e);
        }

        protected void btnEditarPass_Click(object sender, EventArgs e)
        {
            try
            {
                if (EsValidoFormulario())
                {
                    tipoActualizacion = 2; // Actualizar contrasena del usuario
                    oUsuario.tipoActualizacion = tipoActualizacion;
                    oUsuario.Nombres = txtPass.Text;

                    if (eSaveObj != null)
                        eSaveObj(sender, e);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        protected void btnEditMatDefault_Click(object sender, EventArgs e)
        {
            tipoActualizacion = 3; // Actualizar contrasena del usuario
            oUsuario.tipoActualizacion = tipoActualizacion;

            if (eSaveObj != null)
                eSaveObj(sender, e);
        }

        protected void gvMatriculas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = Properties.Resources.Us_Matricula;
                e.Row.Cells[1].Text = Properties.Resources.Us_Contrato;
                //e.Row.Cells[2].Text = Properties.Resources.Us_Name;
                //e.Row.Cells[3].Text = Properties.Resources.Us_MatDefault;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (oLstMatriculas[e.Row.RowIndex].matriculaDefault == 1)
                {
                    CheckBox chk = (CheckBox)e.Row.FindControl("chkSeleccione");
                    if (chk != null)
                    {
                        chk.Checked = true;
                        smatricula = e.Row.Cells[0].Text;
                    }
                }
            }
        }

        protected void gvMatriculas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void chkSeleccione_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkApproved = (CheckBox)sender;
            GridViewRow gridViewRow = (GridViewRow)chkApproved.Parent.Parent;
            smatricula = gridViewRow.Cells[0].Text;

            foreach (GridViewRow row in gvMatriculas.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkSeleccione");
                if (chk != null)
                {
                    if (chk.Checked && row.Cells[0].Text != smatricula)
                    {
                        chk.Checked = false;
                    }
                }
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
            lblEditarPass.Text = Properties.Resources.Us_ActContrasena;
            lblPass.Text = Properties.Resources.Us_Password;
            lblConfirPass.Text = Properties.Resources.Us_ConfirPass;
            lblEdisionUsuarioHeader.Text = Properties.Resources.Us_AdminCta;
            lblEditarUsuario.Text = Properties.Resources.Us_ActInfo;

            Regex1.ErrorMessage = Properties.Resources.Us_ValidacionContrasena;
            Regex2.ErrorMessage = Properties.Resources.Us_ValidacionConfirmContrasena;

            txtCorreo.Enabled = false;
        }

        private void LlenaFormulario()
        {
            oUsuario = (Usuario)System.Web.HttpContext.Current. Session["VSUsuario"];
            oLstMatriculas = (List<MatriculasContratoUsuario>)System.Web.HttpContext.Current.Session["LstMatriculas"];
            gvMatriculas.DataSource = (List<MatriculasContratoUsuario>)System.Web.HttpContext.Current.Session["LstMatriculas"];
            gvMatriculas.DataBind();
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

        public void recargarPagina(responceAct resp)
        {
            if (resp.mensaje == "Operación ejecutada correctamente")
            {
                System.Web.HttpContext.Current.Session["VSUsuario"] = oUsuario;
                lblMessageConfirm.Text = "¡Usuario Actulizado con Exito! <br /> Para ver los cambios reflejados es necesario iniciar sesion nuevamente.";
                mpeConfirm.Show();
            }
            else
            {
                Response.Redirect("~/Views/frmEditusuario.aspx");
            }
        }

        public void msjContrasena(responceAct resp)
        {
            if (resp.mensaje == "Operación ejecutada correctamente")
            {
                System.Web.HttpContext.Current.Session["VSUsuario"] = oUsuario;
                lblMessageConfirm.Text = "¡Contraseña Actualizada con Exito! <br /> Para ver los cambios reflejados es necesario iniciar sesion nuevamente.";
                mpeConfirm.Show();
            }
            else
            {
                Response.Redirect("~/Views/frmEditusuario.aspx");
            }
        }

        public void msjMatriculas(responceAct resp)
        {
            if (resp.mensaje == "Operación ejecutada correctamente")
            {
                System.Web.HttpContext.Current.Session["VSUsuario"] = oUsuario;
                lblMessageConfirm.Text = "¡Matricula Default Actualizada con Exito! <br /> Para ver los cambios reflejados es necesario iniciar sesion nuevamente.";
                mpeConfirm.Show();
            }
            else
            {
                Response.Redirect("~/Views/frmEditusuario.aspx");
            }
        }

        #endregion


        #region VARIABLES Y PROPIEDADES

        public Usuario oUsuario
        {
            get
            {
                return new Usuario()
                {
                    Nombres = tipoActualizacion == 1 ? txtNombre.Text.S() : txtPass.Text.S(),
                    ApePat = txtApellidoPat.Text.S(),
                    ApeMat = txtApellidoMat.Text.S(),
                    Puesto = txtPuesto.Text.S(),
                    Correo = txtCorreo.Text.S(),
                    TelefonoMovil = txtTelMovil.Text.S(),
                    CorreoSecundario = txtCorreoSecundario.Text.S(),
                    TelefonoOficina = txtTelefonoOficina.Text.S(),
                    tipoActualizacion = tipoActualizacion
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

        public int tipoActualizacion
        {
            get { return ViewState["VStipoActualizacion"].S().I(); }
            set { ViewState["VStipoActualizacion"] = value; }
        }

        public string smatricula
        {
            get { return ViewState["VSmatricula"].S(); }
            set { ViewState["VSmatricula"] = value; }
        }

        public List<MatriculasContratoUsuario> oLstMatriculas
        {
            get { return (List<MatriculasContratoUsuario>)ViewState["VSoLstMatriculas"]; }
            set { ViewState["VSoLstMatriculas"] = value; }
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