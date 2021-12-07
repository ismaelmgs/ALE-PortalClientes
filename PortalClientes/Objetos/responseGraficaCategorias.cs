using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class responseGraficaCategorias
    {
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

    public class detalleGastosTran
    {
        public int anio { get; set; }
        public int mes { get; set; }
        public int idRubro { get; set; }
        public string rubroESP { get; set; }
        public string rubroENG { get; set; }
        public float totalMXN { get; set; }
        public float totalUSD { get; set; }
        public string fecha { get; set; }
        public string categoria { get; set; }
        public string tipoGasto { get; set; }
        public string comentarios { get; set; }
        public string mesDesc { get; set; }
    }

    public class dataGrafica
    {
        public string idioma { get; set; }
        public string[,] datosM { get; set; }
        public string[,] datosU { get; set; }
        public string[] conceptos { get; set; }
        public List<responseGraficaCategorias> response { get; set; }
    }

    public class gvDetGastos
    {
        public string anio { get; set; }
        public string mes { get; set; }
        public string rubro { get; set; }
        public float total { get; set; }
        public string categoria { get; set; }
        public string tipoGasto { get; set; }
        public string comentarios { get; set; }
    }
}