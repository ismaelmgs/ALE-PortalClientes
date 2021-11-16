using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class responseGraficaPromedioPasajero
    {
        public string mes { get; set; }
        public string anio { get; set; }
        public string nombreESP { get; set; }
        public string nombreENG { get; set; }
        public float totalPax { get; set; }
        public int numVuelos { get; set; }
        public float promPax { get; set; }
        public string idioma { get; set; }
        public List<pasajero> pax { get; set; }
    }

    public class pasajero
    {
        public int id { get; set; }
        public int anio { get; set; }
        public int mes { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public string origenVuelo { get; set; }
        public string destinoVuelo { get; set; }
        public string tiempoVuelo { get; set; }
        public float cantPax { get; set; }
        public string cliente { get; set; }
        public string contrato { get; set; }
    }

    public class gvPromedioPax
    {
        public string anio { get; set; }
        public string mes { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public string fechaOrigen { get; set; }
        public string fechaDestino { get; set; }
        public string tiempoVuelo { get; set; }
        public string cantPax { get; set; }
        public string cliente { get; set; }
        public string contrato { get; set; }
    }
}