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

            oIView.eSearchObjFiltros += eSearchObjFiltros_Presenter;
            oIView.eSearchMatriculas += eSearchMatriculas_Presenter;
        }

        protected override void SearchObj_Presenter(object sender, EventArgs e)
        {
           oIView.CargaUsuarios(oIGesCat.ObtieneUsuariosFiltros(string.Empty));
        }

        protected override void SaveObj_Presenter(object sender, EventArgs e)
        {
            oIGesCat.InsertaActualizaUsuarios(oIView.oUsuario);
        }

        protected void eSearchObjFiltros_Presenter(object sender, EventArgs e)
        {
            oIView.CargaUsuarios(oIGesCat.ObtieneUsuariosFiltros(oIView.sFiltro));
        }

        protected void eSearchMatriculas_Presenter(object sender, EventArgs e)
        {
            oIView.CargaMatriculas(oIGesCat.ObtieneMatriculas());
        }
    }
}