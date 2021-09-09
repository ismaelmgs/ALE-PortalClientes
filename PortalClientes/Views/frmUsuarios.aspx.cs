using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NucleoBase.Core;
using PortalClientes.Clases;
using PortalClientes.Interfaces;
using PortalClientes.Presenter;
using PortalClientes.DomainModel;
using System.ComponentModel.DataAnnotations;

namespace PortalClientes.Views
{
    public partial class frmUsuarios : System.Web.UI.Page, IViewUsuarios
    {
        #region EVENTOS
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["UserIdentity"] == null)
            //    Response.Redirect("frmLogin.aspx");

            oPresenter = new Usuarios_Presenter(this, new DBUsuarios());

            TextBox milabel = (TextBox)this.Master.FindControl("txtLang");
            if (milabel.Text != Utils.Idioma)
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



            LlenaGrid();
        }
        
        protected void btnBuscar_ServerClick(object sender, EventArgs e)
        {

        }

        protected void gvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsuarios.PageIndex = e.NewPageIndex;
            LlenaGrid();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            mpeUsuario.Show();
        }

        protected void gvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = Properties.Resources.Us_Nombre;
                e.Row.Cells[1].Text = Properties.Resources.Us_ApePat;
                e.Row.Cells[2].Text = Properties.Resources.Us_ApeMat;
                e.Row.Cells[3].Text = Properties.Resources.Correo;
                e.Row.Cells[4].Text = Properties.Resources.Us_Puesto;
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if(EsValidoFormulario())
                {
                    if (eSaveObj != null)
                        eSaveObj(sender, e);

                    mpeUsuario.Hide();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region METODOS 
        private void ArmaFormulario()
        {
            txtBusqueda.Attributes.Add("placeholder", Properties.Resources.Cm_Buscador);
            txtCorreo.Attributes.Add("placeholder", Properties.Resources.CorreoEjemplo);

            lblTituloPagina.Text = Properties.Resources.Us_TituloPagUsuarios;
            lblSubTituloPagina.Text = Properties.Resources.Us_SubTituloPagUsuarios;
            txtNombre.Caption = Properties.Resources.Us_Nombre;
            lblApellidoPat.Text = Properties.Resources.Us_ApePat;
            lblApellidoMat.Text = Properties.Resources.Us_ApeMat;
            lblCorreo.Text = Properties.Resources.Correo;
            lblPuesto.Text = Properties.Resources.Us_Puesto;
            lblTituloModalUsuario.Text = Properties.Resources.Us_TituloEdUsuarios;
            btnAceptar.Text = Properties.Resources.Aceptar;
            //btnCancelar.Text = Properties.Resources.Cancelar;
            btnAgregar.Text = Properties.Resources.Us_AltaUsuario;
            lblPass.Text = Properties.Resources.Us_Password;
            lblConfirPass.Text = Properties.Resources.Us_ConfirPass;
            lblTelefonoMovil.Text = Properties.Resources.Us_Celular;
        
        }

        private void LlenaGrid()
        {
            if (eSearchObj != null)
                eSearchObj(null, EventArgs.Empty);
        }

        public void CargaUsuarios(List<Usuario> oLst)
        {
            oLstUsers = oLst;
            gvUsuarios.DataSource = oLstUsers;
            gvUsuarios.DataBind();
        }

        public bool EsValidoFormulario()
        {
            bool ban = true;

            if (txtNombre.Text.S() == string.Empty)
            {
                txtNombre.IsValid = false;
                lblReqNombre.Visible = true;
                lblReqNombre.Text = Properties.Resources.Cm_CampoReq;
                ban = false;
            }
            else
            {
                lblReqNombre.Visible = false;
                lblReqNombre.Text = string.Empty;
            }

            if (txtCorreo.Text.S() == string.Empty)
            {
                lblReqCorreo.Visible = true;
                lblReqCorreo.Text = Properties.Resources.Cm_CampoReq;
                ban = false;
            }
            else
            {
                if (new EmailAddressAttribute().IsValid(txtCorreo.Text.S()))
                {
                    lblReqCorreo.Visible = false;
                    lblReqCorreo.Text = string.Empty;
                }
                else
                {
                    lblReqCorreo.Visible = true;
                    lblReqCorreo.Text = Properties.Resources.Us_ValCorreo;
                    ban = false;
                }
            }

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
        #endregion


        #region VARIABLES Y PROPIEDADES

        Usuarios_Presenter oPresenter;
        public event EventHandler eNewObj;
        public event EventHandler eObjSelected;
        public event EventHandler eSaveObj;
        public event EventHandler eDeleteObj;
        public event EventHandler eSearchObj;

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
                    TelefonoMovil = txtTelMovil.Text.S()
                };
            }
        }

        public List<Usuario> oLstUsers
        {
            get { return (List<Usuario>)ViewState["VSUsuarios"]; }
            set { ViewState["VSUsuarios"] = value; }
        }
        
        #endregion
    }
    
}