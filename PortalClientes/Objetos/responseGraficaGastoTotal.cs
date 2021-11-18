using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class responseGraficaGastoTotal
    {
        public string anio { get; set; }
        public int mes { get; set; }
        public string nombreESP { get; set; }
        public string nombreENG { get; set; }
        public float importe { get; set; }
        public int noGastos { get; set; }
        public string idioma { get; set; }
        public List<gastot> gastos { get; set; }
    }

    public class gastot
    {
        public int idRubro { get; set; }
        public string rubroESP { get; set; }
        public string rubroENG { get; set; }
        public float totalImp { get; set; }
        public string categoriaESP { get; set; }
        public string categoriaENG { get; set; }
        public string comentarios { get; set; }
        public int mes { get; set; }
        public int anio { get; set; }
        public string nombreESP { get; set; }
        public string nombreENG { get; set; }
    }

    public class gvGastosT
    {
        public string rubro { get; set; }
        public float totalImp { get; set; }
        public string categoria { get; set; }
        public string comentarios { get; set; }
        public string mes { get; set; }
        public string anio { get; set; }
    }
}