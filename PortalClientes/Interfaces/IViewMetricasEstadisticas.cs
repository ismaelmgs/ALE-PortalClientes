using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Interfaces
{
    public interface IViewMetricasEstadisticas : IBaseView
    {
        DatosMetricas oMetEsta { get; }
        void CargarMetricasEstadisticas(List<DatosMetricas> oLMetEsta);

        int iMeses { get; }
        string sMatricula { get; }

    }
}