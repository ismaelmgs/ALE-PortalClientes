using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortalClientes.DomainModel;
using PortalClientes.Interfaces;

namespace PortalClientes.Presenter
{
    public class MapaFlota_Presenter : BasePresenter<IViewMapaFlota>
    {
        private readonly DBMapaFlota oIGesCat;

        public MapaFlota_Presenter(IViewMapaFlota _oIView, DBMapaFlota oGC) : base(_oIView)
        {
            oIGesCat = oGC;

            oIView.eSearchObj += SearchObj_Presenter;
        }

        protected override void SearchObj_Presenter(object sender, EventArgs e)
        {
            oIView.cargarMapaFlota(oIGesCat.obtenerFlota(oIView.iMeses));
        }
    }
}