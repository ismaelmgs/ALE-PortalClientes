using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    [Serializable]
    public class Dashboard
    {

        public string Origen { get; set; }
        public string CiudadOrigen { get; set; }
        public string Destino { get; set; }
        public string CiudadDestino { get; set; }
        public string Salida { get; set; }
        public string Llegada { get; set; }
        public double? SaldoActual { get; set; }
        public double? SaldoAlVencimiento { get; set; }
        public double? SaldoUltimaDeclaracion { get; set; }
        public string FechaInicioDeclaracion { get; set; }
        public string FechaFinDeclaracion { get; set; }
        public string aorigenLatitud { get; set; }
        public string aorigenLongitud { get; set; }
        public string adestinoLatitud { get; set; }
        public string adestinoLongitud { get; set; }


        public List<totalesMes> Vuelos { get; set; }
        public List<totalesMes> Horas { get; set; }
        public List<totalesMes> NMVuelos { get; set; }

    }

    [Serializable]
    public class totalesMes
    {
        public string Mes { get; set; }
        public decimal? total { get; set; }
        public decimal? porcentaje { get; set; }
    }
}