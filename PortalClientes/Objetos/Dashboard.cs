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
        public DateTime Salida { get; set; }
        public DateTime Llegada { get; set; }
        public double SaldoActual { get; set; }
        public double SaldoAlVencimiento { get; set; }
        public double SaldoUltimaDeclaracion { get; set; }
        public DateTime FechaInicioDeclaracion { get; set; }
        public DateTime FechaFinDeclaracion { get; set; }


        public List<totalesMes> Vuelos { get; set; }
        public List<totalesMes> Horas { get; set; }
        public List<totalesMes> NMVuelos { get; set; }

    }

    [Serializable]
    public class totalesMes
    {
        public string Mes { get; set; }
        public decimal total { get; set; }
        public decimal porcentaje { get; set; }
    }
}