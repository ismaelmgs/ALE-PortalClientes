using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class Transacciones
    {
        public List<vuelo> vuelos { get; set; } // tipo transaccion: 1
        public List<gvGastos> gastos { get; set; } // tipo transaccion: 2
        public List<gvGastosProveedor> gastosProv { get; set; } // tipo transaccion: 3
        public List<gvGastosAeropuerto> gastosAe { get; set; } // tipo transaccion: 4
        public List<gvPromedioPax> promedioPax { get; set; } // tipo transaccion: 5
        public List<gvPromedioCosto> promedioCosto { get; set; } // tipo transaccion: 6
        public List<gvhorasVoladas> horasVoladas { get; set; } // tipo transaccion: 7
        public List<gvnoVuelos> numeroVuelos { get; set; } // tipo transaccion: 8
        public List<gvCostosFV> gastosFijosVariable { get; set; } // tipo transaccion: 7
        public List<gvGastosT> gastosTotales { get; set; } // tipo transaccion: 8
    }
}