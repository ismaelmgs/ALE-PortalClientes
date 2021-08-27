using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NucleoBase.Core;
using PortalClientes.Clases;

namespace PortalClientes.Views
{
    public partial class frmUsuarios : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox milabel = (TextBox)this.Master.FindControl("txtLang");
            if (milabel.Text != Utils.Idioma)
            {
                Utils.Idioma = milabel.Text;
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmaFormulario();
            }
            
            LlenaGrid();
        }

        private void ArmaFormulario()
        {
            lblNombre.Text = Properties.Resources.Nombre;
            lblApellidoPat.Text = Properties.Resources.ApePat;
            lblApellidoMat.Text = Properties.Resources.ApeMat;
            lblCorreo.Text = Properties.Resources.Correo;
            lblPuesto.Text = Properties.Resources.Puesto;
            lblTituloModalUsuario.Text = Properties.Resources.TituloEdUsuarios;
            btnAceptar.Text = Properties.Resources.Aceptar;
            btnCancelar.Text = Properties.Resources.Cancelar;
            btnAgregar.Text = Properties.Resources.AltaUsuario;
        }

        private void LlenaGrid()
        {
            List<Usuario> ListUsers = new List<Usuario>();
            for (int i = 1; i <= 25; i++)
            {
                Usuario oUser = new Usuario();
                oUser.Correo = "Correo" + i.S();
                oUser.Nombres = "Nombres " + i.S();
                oUser.ApePat = "Paterno " + i.S();
                oUser.ApeMat = "Materno " + i.S();
                oUser.Puesto = "Puesto " + i.S();

                ListUsers.Add(oUser);
            }

            gvUsuarios.DataSource = ListUsers;
            gvUsuarios.DataBind();
            gvusuarios2.DataSource = ListUsers;
            gvusuarios2.DataBind();
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
                e.Row.Cells[0].Text = Properties.Resources.Nombre;
                e.Row.Cells[1].Text = Properties.Resources.ApePat;
                e.Row.Cells[2].Text = Properties.Resources.ApeMat;
                e.Row.Cells[3].Text = Properties.Resources.Correo;
                e.Row.Cells[4].Text = Properties.Resources.Puesto;
            }
        }
    }
}