using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class responseGraficaGastos
    {
        public int idRubro { get; set; }
        public string rubroEsp { get; set; }
        public string rubroEng { get; set; }
        public double totalMXN { get; set; }
        public double totalUSD { get; set; }
        public List<gasto> Gastos { get; set; }

    }

    public class gasto
    {
        public int idRubro { get; set; }
        public string rubroEsp { get; set; }
        public string rubroEng { get; set; }
        public double totalMXN { get; set; }
        public double totalUSD { get; set; }
        public DateTime fecha { get; set; }
        public string categoria { get; set; }
        public string tipodeGasto { get; set; }
        public string comentarios { get; set; }
        public string mes { get; set; }
    }
}