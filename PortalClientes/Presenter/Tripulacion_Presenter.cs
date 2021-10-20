using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Presenter
{
    public class Tripulacion_Presenter : BasePresenter<IViewTripulacion>
    {
        private readonly DBTripulacion oIGesCat;

        public Tripulacion_Presenter(IViewTripulacion oView, DBTripulacion oGC) : base(oView)
        {
            oIGesCat = oGC;

            oIView.eSearchObj += SearchObj_Presenter;
        }

        protected override void SearchObj_Presenter(object sender, EventArgs e)
        {
            oIView.CargarEventosTripulacion(oIGesCat.ObtenerEventos());
            oIView.CargarPilotosTripulacion(oIGesCat.ObtenerPilotos());
        }

        protected void eSearchObjEventos_Presenter(object sender, EventArgs e)
        {
            oIView.CargarEventosTripulacion(oIGesCat.ObtenerEventos());
        }

        protected void eSearchObjPilotos_Presenter(object sender, EventArgs e)
        {
            oIView.CargarPilotosTripulacion(oIGesCat.ObtenerPilotos());
        }
    }
}