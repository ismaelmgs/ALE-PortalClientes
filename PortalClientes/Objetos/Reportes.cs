using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class Reportes
    {
        public List<vuelo> vuelos { get; set; } // tipo transaccion: 1
        public List<gvGastos> gastos { get; set; } // tipo transaccion: 2
        public List<gvGastosProveedor> gastosProv { get; set; } // tipo transaccion: 3
        public List<gvGastosAeropuerto> gastosAe { get; set; } // tipo transaccion: 4
        public List<gvPromedioPax> promedioPax { get; set; } // tipo transaccion: 5
        public List<gvPromedioCosto> promedioCosto { get; set; } // tipo transaccion: 6
        public List<gvhorasVoladas> horasVoladas { get; set; } // tipo transaccion: 7
        public List<gvnoVuelos> numeroVuelos { get; set; } // tipo transaccion: 8
        public List<gvCostosFV> costosFijosVariable { get; set; } // tipo transaccion: 9
        public List<gvGastosT> gastosTotales { get; set; } // tipo transaccion: 10
        public List<gvCostosH> costosHoraVuelo { get; set; } // tipo transaccion: 11
        public List<gvCostosFVH> costosFijosVariableHora { get; set; } // tipo transaccion: 12
        public List<DetalleRepEdoCuenta> detalleEdoCuenta { get; set; } // tipo transaccion: 13
        public List<gvDetGastos> detGastos { get; set; } // tipo transaccion: 14
    }
}