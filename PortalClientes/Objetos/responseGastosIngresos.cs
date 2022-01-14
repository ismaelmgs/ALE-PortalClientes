using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class responseGastosIngresos
    {
        public string facturante { get; set; }
        public string matricula { get; set; }
        public int anio { get; set; }
        public int mes { get; set; }
        public string mesESP { get; set; }
        public string mesENG { get; set; }
        public double totalImpGasto { get; set; }
        public double totalImpPago { get; set; }
        public int noGastos { get; set; }
        public int noPagos { get; set; }

    }

    public class gvGastosIngresos
    {
        public string facturante { get; set; }
        public int anio { get; set; }
        public string mes { get; set; }
        public double totalImpGasto { get; set; }
        public double totalImpPago { get; set; }
        public int noGastos { get; set; }
        public int noPagos { get; set; }
    }
}