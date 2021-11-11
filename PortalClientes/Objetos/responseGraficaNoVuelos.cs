using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class responseGraficaNoVuelos
    {
        public string anio { get; set; }
        public int mes { get; set; }
        public string nombreESP { get; set; }
        public string nombreENG { get; set; }
        public List<novuelo> vuelos { get; set; }
        public string idioma { get; set; }
    }

    public class novuelo
    {
        public int id { get; set; }
        public int anio { get; set; }
        public int mes { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public string origenVuelo { get; set; }
        public string detinoVuelo { get; set; }
        public string tiempoVuelo { get; set; }
        public int cantPax { get; set; }
        public string cliente { get; set; }
        public string contrato { get; set; }
    }
}