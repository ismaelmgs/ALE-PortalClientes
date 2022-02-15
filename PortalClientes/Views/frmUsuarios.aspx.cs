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
using DevExpress.Web.Bootstrap;

namespace PortalClientes.Views
{
    public partial class frmUsuarios : System.Web.UI.Page, IViewUsuarios
    {
        #region EVENTOS
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["RefUrl"] = Request.Url.ToString();
            if (System.Web.HttpContext.Current.Session["UserIdentity"] == null)
            {
                Response.Redirect("~/Views/frmFinconexion2.aspx");
            }

            oPresenter = new Usuarios_Presenter(this, new DBUsuarios());

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
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "openLoading();", true);
                LlenaGrid();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "openLoading();", true);
                LlenaGridLocal();
            }
        }
        
        protected void btnBuscar_ServerClick(object sender, EventArgs e)
        {
            try
            {
                if (eSearchObjFiltros != null)
                    eSearchObjFiltros(sender, e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsuarios.PageIndex = e.NewPageIndex;
            LlenaGrid();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            LimpiaCampos();
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
                e.Row.Cells[5].Text = Properties.Resources.Us_Estatus;

            }

            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton imbMats = (ImageButton)e.Row.FindControl("imbAddMats");
                if (imbMats != null)
                {
                    imbMats.ToolTip = Properties.Resources.Us_TtipMats;
                }

                ImageButton imbEditarModulos = (ImageButton)e.Row.FindControl("imbEditarModulos");
                if (imbEditarModulos != null)
                {
                    imbEditarModulos.ToolTip = Properties.Resources.Us_TtipModulos;
                }

                ImageButton imbClonUsuarios = (ImageButton)e.Row.FindControl("imbClonUsuarios");
                if (imbClonUsuarios != null)
                {
                    imbClonUsuarios.ToolTip = Properties.Resources.Us_TtipClonarUsuarios;
                }

                ImageButton imbBanUser = (ImageButton)e.Row.FindControl("imbBanUser");
                if (imbBanUser != null)
                {
                    imbBanUser.ToolTip = Properties.Resources.Us_TtipActivacionUsuario;

                    var status = e.Row.Cells[5].Text;
                    if(status == Properties.Resources.Us_BanUsuActivo)
                    {
                        imbBanUser.ImageUrl = "~/Images/icons/eliminar_usuario.png";
                    }

                    if (status == Properties.Resources.Us_BanUsuInactiv)
                    {
                        imbBanUser.ImageUrl = "~/Images/icons/editar_usuario.png";
                    }
                }
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

        protected void imbAddMats_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow row = ((ImageButton)sender).NamingContainer as GridViewRow;
            if (row != null)
            {
                iIdUsuario = gvUsuarios.DataKeys[row.RowIndex]["IdUsuario"].S().I();
            }

            if (eSearchMatriculas != null)
                eSearchMatriculas(sender, e);

            mpeMats.Show();
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            

            if (e.CommandName == "Modulos")
            {

            }

            if (e.CommandName == "Usuarios")
            {

            }
        }

        protected void btnAceptarMats_Click(object sender, EventArgs e)
        {
            List<Tuple<int, string>> olsMats = new List<Tuple<int, string>>();
            foreach (GridViewRow row in gvMatriculas.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkSeleccione");
                if (chk != null)
                {
                    if (chk.Checked)
                    {
                        olsMats.Add(new Tuple<int, string>(gvMatriculas.DataKeys[row.RowIndex]["IdAeronave"].S().I(), row.Cells[2].Text));
                    }
                }
            }

            olsTV = olsMats;

            if (eSaveMatriculasUsuario != null)
                eSaveMatriculasUsuario(sender, e);

            mpeMats.Hide();
        }

        protected void gvMatriculas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Text = Properties.Resources.Us_Matricula;
                e.Row.Cells[2].Text = Properties.Resources.Us_Contrato;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (oLstMatssUser[e.Row.RowIndex].sts == 1)
                {
                    CheckBox chk = (CheckBox)e.Row.FindControl("chkSeleccione");
                    if (chk != null)
                    {
                        chk.Checked = true;
                    }
                }
            }
        }

        protected void imbEditarModulos_Click(object sender, ImageClickEventArgs e)
        {
            GridViewRow row = ((ImageButton)sender).NamingContainer as GridViewRow;
            if (row != null)
            {
                iIdUsuario = gvUsuarios.DataKeys[row.RowIndex]["IdUsuario"].S().I();
            }

            if (eSearchModulos != null)
                eSearchModulos(sender, e);

            mpeModulos.Show();
        }

        protected void gvModulos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Text = Properties.Resources.Us_Clave;
                e.Row.Cells[2].Text = Properties.Resources.Us_Modulo;
                e.Row.Cells[3].Text = Properties.Resources.Us_ModuloEng;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (oLstModulosUser[e.Row.RowIndex].sts == 1)
                {
                    CheckBox chk = (CheckBox)e.Row.FindControl("chkSeleccione");
                    if (chk != null)
                    {
                        chk.Checked = true;
                    }
                }
            }
        }

        protected void btnAceptarModulos_Click(object sender, EventArgs e)
        {
            List<int> olsMods = new List<int>();
            foreach (GridViewRow row in gvModulos.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkSeleccione");
                if (chk != null)
                {
                    if (chk.Checked)
                    {
                        olsMods.Add(gvModulos.DataKeys[row.RowIndex]["idModulo"].S().I());
                    }
                }
            }

            olst = olsMods;

            if (eSaveModulos != null)
                eSaveModulos(sender, e);

            mpeModulos.Hide();
        }

        protected void imbClonUsuarios_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                GridViewRow row = ((ImageButton)sender).NamingContainer as GridViewRow;
                if (row != null)
                {
                    iIdUsuario = gvUsuarios.DataKeys[row.RowIndex]["IdUsuario"].S().I();

                    lblUsuarioDestinoResp.Text = row.Cells[0].Text + " " + row.Cells[1].Text;
                }

                List<UsuariosCombos> olsCombo = new List<UsuariosCombos>();

                foreach (Usuario item in oLstUsers)
                {
                    UsuariosCombos oUser = new UsuariosCombos();
                    oUser.IdUsuario = item.IdUsuario;
                    oUser.Nombre = item.Nombres + " " + item.ApePat + " | " + item.Puesto;

                    olsCombo.Add(oUser);
                }


                ddlUsuarios.DataSource = olsCombo;
                ddlUsuarios.DataValueField = "IdUsuario";
                ddlUsuarios.DataTextField = "Nombre";
                ddlUsuarios.DataBind();

                ddlUsuarios_SelectedIndexChanged(sender, e);

                upaClonar.Update();
                mpeClonar.Show();
            }
            catch (Exception ex)
            {

            }
        }

        protected void btnAceptarClonar_Click(object sender, EventArgs e)
        {
            iIdUsuarioOrigen = ddlUsuarios.SelectedValue.S().I();

            if (eSaveClonaPermisos != null)
                eSaveClonaPermisos(sender, e);

            mpeClonar.Hide();

            if (eSearchModulos != null)
                eSearchModulos(sender, e);

            mpeModulos.Show();
        }

        protected void btnAceptarBanUsuario_Click(object sender, EventArgs e)
        {
            oUsuario.tipoActualizacion = 2;

            if (eSaveBanUsuario != null)
                eSaveBanUsuario(sender, e);

            LlenaGrid();

            mpeBUsuario.Hide();
        }

        protected void gvModulosUsuario_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = Properties.Resources.Us_Clave;
                e.Row.Cells[1].Text = Properties.Resources.Us_Modulo;
                e.Row.Cells[2].Text = Properties.Resources.Us_ModuloEng;
            }
        }

        protected void ddlUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            iIdUsuarioOrigen = ddlUsuarios.SelectedValue.S().I();

            if (eObjSelected != null)
                eObjSelected(sender, e);
        }

        protected void imbBanUser_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                GridViewRow row = ((ImageButton)sender).NamingContainer as GridViewRow;
                if (row != null)
                {
                    iIdUsuario = gvUsuarios.DataKeys[row.RowIndex]["IdUsuario"].S().I();

                    var usuario = oLstUsers.Find(x => x.IdUsuario == iIdUsuario);
                    oUsuario = usuario;

                    if(usuario != null)
                    {
                        var texto = "";

                        if(Utils.Idioma == "es-MX")
                        {
                            texto = "Usuario " + usuario.Nombres + " " + usuario.ApePat + " " + usuario.ApeMat + " esta " + usuario.stsString.S() + " desea " + (usuario.Sts == 0 ? Properties.Resources.Us_BanUsuActivar : Properties.Resources.Us_BanUsuDesAct);
                        }
                        else
                        {
                            texto = usuario.stsString + " " + usuario.Nombres + " " + usuario.ApePat + " " + usuario.ApeMat + " user  wants to " + (usuario.Sts == 0 ? Properties.Resources.Us_BanUsuActivar : Properties.Resources.Us_BanUsuDesAct) + " it";
                        }

                        lblBanUsuarioRes.Text = texto;
                    }
                }

                upaBanUusario.Update();
                mpeBUsuario.Show();
            }
            catch (Exception ex)
            {

            }
        }

        #endregion


        #region METODOS 
        private void LimpiaCampos()
        {
            txtNombre.Text = string.Empty;
            txtApellidoMat.Text = string.Empty;
            txtApellidoMat.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtPass.Text = string.Empty;
            txtConfirPass.Text = string.Empty;
            txtTelMovil.Text = string.Empty;
            txtCorreoSecundario.Text = string.Empty;
            txtTelefonoOficina.Text = string.Empty;
        }

        private void ArmaFormulario()
        {
            txtBusqueda.Attributes.Add("placeholder", Properties.Resources.Cm_Buscador);
            txtCorreo.Attributes.Add("placeholder", Properties.Resources.CorreoEjemplo);

            lblTituloPagina.Text = Properties.Resources.Us_TituloPagUsuarios;
            lblSubTituloPagina.Text = Properties.Resources.Us_SubTituloPagUsuarios;
            lblNombre.Text = Properties.Resources.Us_Nombre;
            lblApellidoPat.Text = Properties.Resources.Us_ApePat;
            lblApellidoMat.Text = Properties.Resources.Us_ApeMat;
            lblCorreo.Text = Properties.Resources.Correo;
            lblPuesto.Text = Properties.Resources.Us_Puesto;
            lblCorreoSecundario.Text = Properties.Resources.Us_CorreoSecundario;
            lblTelefonoOficina.Text = Properties.Resources.Us_TelefonoOficina;
            lblTituloModalUsuario.Text = Properties.Resources.Us_TituloEdUsuarios;
            btnAceptar.Text = Properties.Resources.Aceptar;
            btnAgregar.Text = Properties.Resources.Us_AltaUsuario;
            lblPass.Text = Properties.Resources.Us_Password;
            lblConfirPass.Text = Properties.Resources.Us_ConfirPass;
            lblTelefonoMovil.Text = Properties.Resources.Us_Celular;

            lblTituloMatriculas.Text = Properties.Resources.Us_TituloMats;
            btnAceptarMats.Text = Properties.Resources.Aceptar;
            btnCancelarMats.Text = Properties.Resources.Cancelar;

            lblTituloModulos.Text = Properties.Resources.Us_TituloModulos;
            btnAceptarModulos.Text = Properties.Resources.Aceptar;
            btnCancelarModulos.Text = Properties.Resources.Cancelar;

            lblTituloClonar.Text = Properties.Resources.Us_TituloClon;
            btnAceptarClonar.Text = Properties.Resources.Aceptar;
            btnCancelarClonar.Text = Properties.Resources.Cancelar;

            lblUsuarioDestino.Text = Properties.Resources.Us_UsuarioDestino;

            Regex1.ErrorMessage = Properties.Resources.Us_ValidacionContrasena;
            Regex2.ErrorMessage = Properties.Resources.Us_ValidacionConfirmContrasena;
            btnAceptarBanUsuario.Text = Properties.Resources.Aceptar;
            btnCancelarBanUsuario.Text = Properties.Resources.Cancelar;
            lblTituloBanUsuario.Text = Properties.Resources.Us_TitelBanUsuario;
        }

        private void LlenaGrid()
        {
            if (eSearchObj != null)
                eSearchObj(null, EventArgs.Empty);
        }

        private void LlenaGridLocal()
        {
            gvUsuarios.DataSource = oLstUsers;
            gvUsuarios.DataBind();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "closeLoading();", true);
        }

        public void CargaUsuarios(List<Usuario> oLst)
        {
            oLstUsers = oLst;

            if (oLst[0].codigo != "0000")
            {
                gvUsuarios.EmptyDataText = "No existen registro para mostrar";
            }

            foreach(var item in oLstUsers)
            {
                item.stsString = item.Sts > 0 ? Properties.Resources.Us_BanUsuActivo : Properties.Resources.Us_BanUsuInactiv;
            }

            gvUsuarios.DataSource = oLstUsers;
            gvUsuarios.DataBind();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "closeLoading();", true);
        }

        public bool EsValidoFormulario()
        {
            bool ban = true;

            if (txtNombre.Text.S() == string.Empty)
            {
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

        public void CargaMatriculas(List<MatriculasUsuario> olstMats)
        {
            if (olstMats.Count > 0)
            {
                oLstMatssUser = olstMats;
                gvMatriculas.DataSource = olstMats;
                gvMatriculas.DataBind();
            }
        }

        public void CargaModulos(List<ModulosUsuario> olstModulos)
        {
            if (olstModulos.Count > 0)
            {
                oLstModulosUser = olstModulos;
                gvModulos.DataSource = oLstModulosUser;
                gvModulos.DataBind();
            }
        }

        public void CargaModulosUsuario(List<ModulosUsuario> olstModulos)
        {
            List<ModulosUsuario> olst = olstModulos.Where(x => x.sts == 1).ToList();

            gvModulosUsuario.DataSource = olst;
            gvModulosUsuario.DataBind();
        }
        #endregion


        #region VARIABLES Y PROPIEDADES

        Usuarios_Presenter oPresenter;
        public event EventHandler eNewObj;
        public event EventHandler eObjSelected;
        public event EventHandler eSaveObj;
        public event EventHandler eDeleteObj;
        public event EventHandler eSearchObj;
        public event EventHandler eSearchObjFiltros;
        public event EventHandler eSearchMatriculas;
        public event EventHandler eSaveMatriculasUsuario;
        public event EventHandler eSearchModulos;
        public event EventHandler eSaveModulos;
        public event EventHandler eSaveClonaPermisos;
        public event EventHandler eSaveBanUsuario;


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
                    Pass = txtPass.Text.S(),
                    TelefonoMovil = txtTelMovil.Text.S(),
                    CorreoSecundario = txtCorreoSecundario.Text.S(),
                    TelefonoOficina = txtTelefonoOficina.Text.S(),
                    tipoActualizacion = 2
                };
            }
            set
            {
                Usuario oUser = (Usuario) value;
                txtNombre.Text = oUser.Nombres;
                txtApellidoPat.Text = oUser.ApePat;
                txtApellidoMat.Text = oUser.ApeMat;
                txtPuesto.Text = oUser.Puesto;
                txtCorreo.Text = oUser.Correo;
                txtPass.Text = oUser.Pass;
                txtTelMovil.Text = oUser.TelefonoMovil;
            }
        }

        public List<Usuario> oLstUsers
        {
            get { return (List<Usuario>)ViewState["VSUsuarios"]; }
            set { ViewState["VSUsuarios"] = value; }
        }

        public List<ModulosUsuario> oLstModulosUser
        {
            get { return (List<ModulosUsuario>)ViewState["VSModulosUsuario"]; }
            set { ViewState["VSModulosUsuario"] = value; }
        }

        public List<MatriculasUsuario> oLstMatssUser
        {
            get { return (List<MatriculasUsuario>)ViewState["VSMatriculasUsuario"]; }
            set { ViewState["VSMatriculasUsuario"] = value; }
        }

        public string sFiltro
        {
            get {
                return txtBusqueda.Text.S();
            }
        }

        public int iIdUsuario
        {
            get { return ViewState["VSIdUsuario"].S().I();}
            set { ViewState["VSIdUsuario"] = value; }
        }

        public List<int> olst
        {
            set { ViewState["VSLista"] = value; }
            get { return (List<int>)ViewState["VSLista"]; }
        }

        public List<Tuple<int, string>> olsTV
        {
            set { ViewState["VSLista"] = value; }
            get { return (List<Tuple<int, string>>)ViewState["VSLista"]; }
        }

        public int iIdUsuarioOrigen
        {
            get { return ViewState["VSIdUsuarioDestino"].S().I(); }
            set { ViewState["VSIdUsuarioDestino"] = value; }
        }



        #endregion
    }
    
}