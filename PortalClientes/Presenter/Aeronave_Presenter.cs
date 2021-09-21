using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Presenter
{
    public class Aeronave_Presenter : BasePresenter<IViewAeronave>
    {
        private readonly DBAeronave oIGesCat;

        public Aeronave_Presenter(IViewAeronave oView, DBAeronave oGC) : base(oView)
        {
            oIGesCat = oGC;

            oIView.eSearchObj += SearchObj_Presenter;
        }

        protected override void SearchObj_Presenter(object sender, EventArgs e)
        {
            oIView.CargarAeronave(oIGesCat.ObtenerAeronave());
        }
    }
}