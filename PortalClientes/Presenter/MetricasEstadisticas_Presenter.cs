using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Presenter
{
    public class MetricasEstadisticas_Presenter : BasePresenter<IViewMetricasEstadisticas>
    {
        private readonly DBMetricasEstatics oIGesCat;

        public MetricasEstadisticas_Presenter(IViewMetricasEstadisticas oView, DBMetricasEstatics oGC) : base(oView)
        {
            oIGesCat = oGC;

            oIView.eSearchObj += SearchObj_Presenter;
            oIView.eSearchObjRA += SearchObjRA_Presenter;
        }

        protected override void SearchObj_Presenter(object sender, EventArgs e)
        {
            oIView.CargarMetricasEstadisticas(oIGesCat.DBGetMetricasEstadisticas(oIView.sMatricula,oIView.iMeses));

            FiltroEvent fe = new FiltroEvent();
            fe.matricula = oIView.sMatricula;
            fe.meses = oIView.iMesesMap;

            oIView.CargarRutasyAeropuertos(oIGesCat.obtenerRutasAeropuertos(fe));
        }

        protected void SearchObjRA_Presenter(object sender, EventArgs e)
        {

            FiltroEvent fe = new FiltroEvent();
            fe.matricula = oIView.sMatricula;
            fe.meses = oIView.iMesesMap;

            oIView.CargarRutasyAeropuertos(oIGesCat.obtenerRutasAeropuertos(fe));
        }
    }
}