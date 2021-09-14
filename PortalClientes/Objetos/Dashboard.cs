using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    [Serializable]
    public class Dashboard
    {
        public string EstadoVuelo { get; set; }

        public string Origen { get; set; }
        public string Destino { get; set; }
        public DateTime Salida { get; set; }
        public DateTime Llegada { get; set; }
        public List<totalesMes> Vuelos { get; set; }
        public List<totalesMes> Horas { get; set; }
        public List<totalesMes> NMVuelos { get; set; }

        public double Saldo { get; set; }
        public double ultimoSaldo { get; set; }
        public DateTime DecalracionActual { get; set; }
        public DateTime DecalracionVence { get; set; }


    }

    [Serializable]
    public class totalesMes
    {
        public string Mes { get; set; }
        public int total { get; set; }
        public int porcentaje { get; set; }
    }
}