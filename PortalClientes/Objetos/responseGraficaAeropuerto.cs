using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class responseGraficaAeropuerto
    {
        public int noVuelos { get; set; }
        public double totalMXN { get; set; }
        public double totalUSD { get; set; }
        public string aeropuerto { get; set; }
        public string Descripcion { get; set; }
        public string idioma { get; set; }
        public List<gastoAeropuerto> gastos { get; set; }
    }

    public class gastoAeropuerto
    {
        public int? idRubro { get; set; }
        public string rubroESP { get; set; }
        public string rubroENG { get; set; }
        public double totalMXN { get; set; }
        public double totalUSD { get; set; }
        public string tipoMoneda { get; set; }
        public int? mes { get; set; }
        public int? anio { get; set; }
        public int? noPierna { get; set; }
        public string proveedor { get; set; }
        public int? idProveedor { get; set; }
        public string categoria { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }

    }

    public class gvGastosAeropuerto
    {
        public int IdRubro { get; set; }
        public string Rubro { get; set; }
        public double Total { get; set; }
        public string TipoMoneda { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }
        public int NoPierna { get; set; }
        public string Proveedor { get; set; }
        public string Categoria { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
    }
}