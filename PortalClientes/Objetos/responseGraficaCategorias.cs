using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class responseGraficaCategorias
    {
        public string idioma { get; set; }
        public int anio { get; set; }
        public int mes { get; set; }
        public int idRubro { get; set; }
        public string rubroESP { get; set; }
        public string rubroENG { get; set; }
        public float totalMXN { get; set; }
        public float totalUSD { get; set; }
        public List<detalleGastos> detalleGastos { get; set; }
    }

    public class detalleGastos
    {
        public int anio { get; set; }
        public int mes { get; set; }
        public int idRubro { get; set; }
        public string rubroESP { get; set; }
        public string rubroENG { get; set; }
        public float totalMXN { get; set; }
        public float totalUSD { get; set; }
        public DateTime fecha { get; set; }
        public string categoria { get; set; }
        public string tipoGasto { get; set; }
        public string comentarios { get; set; }
        public string mesDesc { get; set; }
    }
}