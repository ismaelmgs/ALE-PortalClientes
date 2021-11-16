using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class responseGraficaPromedioCostos
    {
        public string mes { get; set; }
        public string anio { get; set; }
        public float importeProm { get; set; }
        public int totalVlos { get; set; }
        public string nombreESP { get; set; }
        public string nombreENG { get; set; }
        public string idioma { get; set; }
        public List<costosProm> costos { get; set; }
    }

    public class costosProm
    {
        public int idRubro { get; set; }
        public string rubroESP { get; set; }
        public string rubroENG { get; set; }
        public float importe { get; set; }
        public string categoriaESP { get; set; }
        public string categoriaENG { get; set; }
        public string tipodeGasto { get; set; }
        public string tipoMoneda { get; set; }
        public string comentarios { get; set; }
        public int mes { get; set; }
        public string anio { get; set; }
    }

    public class gvPromedioCosto
    {
        public string rubro { get; set; }
        public float importe { get; set; }
        public string categoria { get; set; }
        public string tipodeGasto { get; set; }
        public string comentarios { get; set; }
        public string mes { get; set; }
        public string anio { get; set; }
    }
}