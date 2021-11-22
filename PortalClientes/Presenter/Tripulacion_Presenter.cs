using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortalClientes.Clases;

namespace PortalClientes.Presenter
{
    public class Tripulacion_Presenter : BasePresenter<IViewTripulacion>
    {
        private readonly DBTripulacion oIGesCat;

        public Tripulacion_Presenter(IViewTripulacion oView, DBTripulacion oGC) : base(oView)
        {
            oIGesCat = oGC;
        }

        protected override void SearchObj_Presenter(object sender, EventArgs e)
        {
            Utils.GuardarBitacora("Inicia consulta de eventos ***");
            oIView.CargarEventosTripulacion(oIGesCat.ObtenerEventos(oIView.iMeses));
            Utils.GuardarBitacora("Terminó de consultar eventos ***");

            Utils.GuardarBitacora("Inicia consulta de pilotos");
            oIView.CargarPilotosTripulacion(oIGesCat.ObtenerPilotos());
            Utils.GuardarBitacora("Terminó de consultar pilotos");
        }

        //protected void eSearchObjEventos_Presenter(object sender, EventArgs e)
        //{
        //    oIView.CargarEventosTripulacion(oIGesCat.ObtenerEventos(oIView.iMeses));
        //}

        //protected void eSearchObjPilotos_Presenter(object sender, EventArgs e)
        //{
        //    oIView.CargarPilotosTripulacion(oIGesCat.ObtenerPilotos());
        //}
    }
}