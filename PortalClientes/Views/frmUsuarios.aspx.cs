using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NucleoBase.Core;

namespace PortalClientes.Views
{
    public partial class frmUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenaGrid();
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
        }

        protected void btnBuscar_ServerClick(object sender, EventArgs e)
        {

        }

        protected void gvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsuarios.PageIndex = e.NewPageIndex;
            LlenaGrid();
        }
    }
}