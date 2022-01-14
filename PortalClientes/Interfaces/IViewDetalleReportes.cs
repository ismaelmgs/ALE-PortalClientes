using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Interfaces
{
    public interface IViewDetalleReportes : IBaseView
    {
        void CargarReporteGastosFV(List<responseGraficaCostoFijoVariable> orptCostoFijoVariable);
        void CargarReporteGastosAe(List<responseGraficaAeropuerto> orptAeropuerto);
        void CargarReporteGastosProve(List<responseGraficaProveedores> orptProveedores);
        void CargarReporteResumenGastosVuelos(List<rptResumenGastosVuelos> orptResumenGastosVuelos);
        void CargarReporteDetalleGastosVuelos(responseDetGastosVuelos orptDetalleGastosVuelos);
        void CargarReporteGastosCombustible(List<responseGastosCombustibleVuelos> orptComb);
        void CargarReporteGastosIngresos(List<responseGastosIngresos> orptGastosIng);
        int iReporte { get; }
        int ianio { get; set; }
        int imes { get; set; }
    }
}