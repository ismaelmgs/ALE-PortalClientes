using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Presenter
{
    public class User_Presenter : BasePresenter<IViewUser>
    {
        private readonly DBUsuarios oIGesCat;

        public User_Presenter(IViewUser oView, DBUsuarios oGC) : base(oView)
        {
            oIGesCat = oGC;

            oIView.eSaveObj += SaveObj_Presenter;
        }

        protected override void SaveObj_Presenter(object sender, EventArgs e)
        {
            if(oIView.tipoActualizacion == 1)
            {
                oIView.recargarPagina(oIGesCat.ActualizaUsuarios(oIView.oUsuario));
            }
            else
            {
                oIView.msjContrasena(oIGesCat.ActualizaUsuarios(oIView.oUsuario));
            }
        }
    }
}