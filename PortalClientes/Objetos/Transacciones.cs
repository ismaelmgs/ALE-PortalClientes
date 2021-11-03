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
    }
}