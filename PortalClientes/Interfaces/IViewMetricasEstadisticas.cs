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
        void CargarMetricasEstadisticas(DatosMetricas oLMetEsta);
        void CargarRutasyAeropuertos(RutaAeropuerto ra);

        int iMeses { get; }
        int iMesesMap { get; }
        string sMatricula { get; }

    }
}