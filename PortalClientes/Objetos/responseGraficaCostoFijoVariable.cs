using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class responseGraficaCostoFijoVariable
    {
        public float importe { get; set; }
        public string categoria { get; set; }
        public int idTipoGasto { get; set; }
        public int noGastos { get; set; }
        public List<gastofv> GastoFV { get; set; }
    }

    public class gastofv
    {
        public int idRubro { get; set; }
        public string rubroESP { get; set; }
        public string rubroENG { get; set; }
        public float totalImp { get; set; }
        public string categoria { get; set; }
        public string comentarios { get; set; }
        public int idTipoGasto { get; set; }
        public int mes { get; set; }
        public int anio { get; set; }
        public string nombreESP { get; set; }
        public string nombreENG { get; set; }
    }

    public class GVgastosFV
    {
        public string idRubro { get; set; }
        public string rubro { get; set; }
        public string totalImp { get; set; }
        public string categoria { get; set; }
        public string comentarios { get; set; }
        public string idTipoGasto { get; set; }
        public string mes { get; set; }
        public string anio { get; set; }
        public string nombre { get; set; }
    }
}