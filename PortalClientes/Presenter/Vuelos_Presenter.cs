using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Presenter
{
    public class Vuelos_Presenter : BasePresenter<IViewVuelos>
    {
        private readonly DBVuelos oIGesCat;

        public Vuelos_Presenter(IViewVuelos _oIView, DBVuelos oGC) : base(_oIView)
        {
            oIGesCat = oGC;

            oIView.eSearchObj += SearchObj_Presenter;
        }

        protected override void SearchObj_Presenter(object sender, EventArgs e)
        {
            oIView.cargarVuelos(oIGesCat.obtenerVuelos(oIView.iMeses));
        }
    }
}