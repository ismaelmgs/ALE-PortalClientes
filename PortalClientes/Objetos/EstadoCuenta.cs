using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class EstadoCuenta
    {
        public int mes { set; get; }
        public int anio { set; get; }

        public decimal saldoAnteriorUSD { set; get; }
        public decimal pagosCreditosUSD { set; get; }
        public decimal nuevosCargosUSD { set; get; }
        public decimal saldoActualUSD { set; get; }

        public decimal saldoAnteriorMXN { set; get; }
        public decimal pagosCreditosMXN { set; get; }
        public decimal nuevosCargosMXN { set; get; }
        public decimal saldoActualMXN { set; get; }
    }
}