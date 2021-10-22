using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    [Serializable]
    public class DatosMetricas
    {
        public double GastoTotalFijoMXN { get; set; }
        public double GastoTotalFijoUSD { get; set; }
        public double GastoTotalVarMXN { get; set; }
        public double GastoTotalVarUSD { get; set; }
        public int NumeroVuelos { get; set; }
        public int TotalPasajeros { get; set; }
        public double HorasVoladas { get; set; }
        public double CostoPorHoraMXN { get; set; }
        public double CostoPorHoraUSD { get; set; }
        public double CostoPorMillaMXN { get; set; }
        public double CostoPorMillaUSD { get; set; }
        public string TiempoPromedio { get; set; }
        public double DistanciaPromedio { get; set; }
        public double PaxPromedio { get; set; }
        public double PromedioMXN { get; set; }
        public double PromedioUSD { get; set; }

    }
}