using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Presenter
{
    public class Usuarios_Presenter :BasePresenter<IViewUsuarios>
    {
        private readonly DBUsuarios oIGesCat;

        public Usuarios_Presenter(IViewUsuarios oView, DBUsuarios oGC) : base(oView)
        {
            oIGesCat = oGC;
            
        }

        protected override void SearchObj_Presenter(object sender, EventArgs e)
        {
           oIView.CargaUsuarios(oIGesCat.ObtieneUsuarios());
        }

        protected override void SaveObj_Presenter(object sender, EventArgs e)
        {
            oIGesCat.InsertaActualizaUsuarios(oIView.oUsuario);
        }
    }
}