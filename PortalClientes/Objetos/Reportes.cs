using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class Reportes
    {
        public List<vuelo> vuelos { get; set; }
        public List<gvGastos> gastos { get; set; }
        public List<gvGastosProveedor> gastosProv { get; set; }
        public List<gvGastosAeropuerto> gastosAe { get; set; }
        public List<gvPromedioPax> promedioPax { get; set; }
        public List<gvPromedioCosto> promedioCosto { get; set; }
        public List<gvhorasVoladas> horasVoladas { get; set; }
        public List<gvnoVuelos> numeroVuelos { get; set; }
        public List<gvCostosFV> costosFijosVariable { get; set; }
        public List<gvGastosT> gastosTotales { get; set; }
        public List<gvCostosH> costosHoraVuelo { get; set; }
        public List<gvCostosFVH> costosFijosVariableHora { get; set; }
        public List<detalleEdoCta> detalleEdoCuenta { get; set; }
        public List<gvDetGastos> detGastos { get; set; }
        public List<gvGastosCombustible> gastoCombustible { get; set; }
        public List<rptResumenGastosVuelos> resumenGastosVuelos { get; set; }
        public detGastosVuelos detalleGastosVuelos { get; set; }
    }

    public class rptResumenGastosVuelos
    {
        public int anio { get; set; }
        public int mes { get; set; }
        public int vuelos { get; set; }
        public float totalMXN { get; set; }
        public float totalUSD { get; set; }
        public string nombreESP { get; set; }
        public string nombreENG { get; set; }
        public string idioma { get; set; }
    }
}