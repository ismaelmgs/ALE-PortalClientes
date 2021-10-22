using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
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
        }

        protected override void SearchObj_Presenter(object sender, EventArgs e)
        {
            oIView.CargarMetricasEstadisticas(oIGesCat.DBGetMetricasEstadisticas(oIView.sMatricula,oIView.iMeses));
        }
    }
}