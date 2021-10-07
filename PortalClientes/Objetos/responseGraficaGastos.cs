using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class responseGraficaGastos
    {
        public int idRubro { get; set; }
        public string rubroESP { get; set; }
        public string rubroENG { get; set; }
        public double totalMXN { get; set; }
        public double totalUSD { get; set; }
        public string idioma { get; set; }
        public List<gasto> Gastos { get; set; }

    }

    public class gasto
    {
        public int idRubro { get; set; }
        public string rubroESP { get; set; }
        public string rubroENG { get; set; }
        public double totalMXN { get; set; }
        public double totalUSD { get; set; }
        public string fecha { get; set; }
        public string categoria { get; set; }
        public string tipodeGasto { get; set; }
        public string comentarios { get; set; }
        public string mes { get; set; }
    }

    public class gvGastos
    {
        public int idRubro { get; set; }
        public string Rubro { get; set; }
        public double Total { get; set; }
        public string Fecha { get; set; }
        public string Categoria { get; set; }
        public string tipodeGasto { get; set; }
        public string comentarios { get; set; }
        public string mes { get; set; }
    }

}