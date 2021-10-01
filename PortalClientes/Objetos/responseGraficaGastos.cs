using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class responseGraficaGastos
    {
        public string rubroEsp { get; set; }
        public string rubroEng { get; set; }
        public double totalMXN { get; set; }
        public double totalUSD { get; set; }
        public List<gasto> Gastos { get; set; }

    }

    public class gasto
    {
        public DateTime fecha { get; set; }
        public string tipoGasto { get; set; }
        public double importe { get; set; }
    }
}