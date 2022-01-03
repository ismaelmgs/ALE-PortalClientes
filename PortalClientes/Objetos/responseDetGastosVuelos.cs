using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class responseDetGastosVuelos
    {
        public List<vuelos> vuelos { get; set; }
        public List<conceptos> conceptosVuelos { get; set; }
    }

    public class vuelos
    {
        public int anio { get; set; }
        public int mes { get; set; }
        public string origenVuelo { get; set; }
        public string destinoVuelo { get; set; }
        public string tiempoVuelo { get; set; }
        public int cantPax { get; set; }
        public string cliente { get; set; }
        public string contrato { get; set; }
    }

    public class conceptos
    {
        public int idRubro { get; set; }
        public string rubroESP { get; set; }
        public string rubroENG { get; set; }
        public double totalMXN { get; set; }
        public double totalUSD { get; set; }
        public DateTime fecha { get; set; }
        public string categoria { get; set; }
        public string tipoGasto { get; set; }
        public string comentarios { get; set; }
        public int mes { get; set; }
        public int anio { get; set; }
    }

    public class detGastosVuelos
    {
        public List<gvTitulosVuelos> titulos { get; set; }
        public List<gvVuelos> gvVuelos { get; set; }
        public List<gvConcepto> gvConceptos { get; set; }
    }

    public class gvTitulosVuelos
    {
        public string tituloLink { get; set; }
        public string mes { get; set; }
    }

    public class gvVuelos
    {
        public string origen { get; set; }
        public string destino { get; set; }
        public string tiempoVuelo { get; set; }
        public int pasajeros { get; set; }
        public string contrato { get; set; }
        public string mes { get; set; }
    }

    public class gvConcepto
    {
        public string rubro { get; set; }
        public double totalMXN { get; set; }
        public double totalUSD { get; set; }
        public string fecha { get; set; }
        public string categoria { get; set; }
        public string comentarios { get; set; }
    }
}