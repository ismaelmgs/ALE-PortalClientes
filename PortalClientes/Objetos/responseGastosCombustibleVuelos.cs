using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class responseGastosCombustibleVuelos
    {
        public int idGasto { get; set; }
        public string matricula { get; set; }
        public string referencia { get; set; }
        public string tipodeGasto { get; set; }
        public string tipoGasto { get; set; }
        public string comentarios { get; set; }
        public string proveedor { get; set; }
        public int anio { get; set; }
        public int mes { get; set; }
        public string tipoMoneda { get; set; }
        public double importe { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
    }

    public class gvGastosCombustible
    {
        public int referencia { get; set; }
        public string tipoGasto { get; set; }
        public string comentarios { get; set; }
        public string proveedor { get; set; }
        public int anio { get; set; }
        public string mes { get; set; }
        public double importe { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
    }
}