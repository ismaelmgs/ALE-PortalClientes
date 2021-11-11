using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class responseGraficaHorasVoladas
    {
        public int anio { get; set; }
        public string mes { get; set; }
        public string nombreESP { get; set; }
        public string nombreENG { get; set; }
        public double totalTiempo { get; set; }
        public List<Hora> horasVoladas { get; set; }
        public string idioma { get; set; }
    }
    public class Hora
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