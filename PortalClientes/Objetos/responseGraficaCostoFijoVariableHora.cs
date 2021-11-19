using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class responseGraficaCostoFijoVariableHora
    {
        public float totalCosto { get; set; }
        public string categoria { get; set; }
        public int idTipoGasto { get; set; }
        public int noGastos { get; set; }
        public int mes { get; set; }
        public int anio { get; set; }
        public float totalTiempo { get; set; }
        public float costoHoraVuelo { get; set; }
        public string idioma { get; set; }
        public List<costofvh> gastos { get; set; }
    }

    public class costofvh
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

    public class gvCostosFVH
    {
        public string rubro { get; set; }
        public float totalImp { get; set; }
        public string categoria { get; set; }
        public string comentarios { get; set; }
        public string mes { get; set; }
        public string anio { get; set; }
    }
}