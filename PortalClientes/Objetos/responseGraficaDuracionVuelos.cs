using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class responseGraficaDuracionVuelos
    {
        public int noVuelos { get; set; }
        public string descripcionESP { get; set; }
        public string descripcionENG { get; set; }
        public int categoria { get; set; }
        public string idioma { get; set; }
        public List<vuelo> vuelos { get; set; }
    }

    public class vuelo
    {
        public int mes { get; set; }
        public int anio { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public DateTime origenVuelo { get; set; }
        public DateTime destinoVuelo { get; set; }
        public string tiempoVlo { get; set; }
        public int categoria { get; set; }
    }
}