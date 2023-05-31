using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class responseReporte
    {
        public List<DataGeneral> oLstGenerales { get; set; }
        public List<DataFijo> oLstFijos { get; set; }
        public List<DataVariable> oLstVariables { get; set; }
        public List<DataPromedioTotal> oLstPromedio { get; set; }
    }
    public class DataGeneral
    {
        public string Mes { get; set; }
        public double Capital { get; set; }
        public double Seguros { get; set; }
        public double Adiestramiento { get; set; }
        public double Tripulacion { get; set; }
        public double Cuota { get; set; }
        public double Hangar { get; set; }
        public double TotalFijo { get; set; }
        public double Combustible { get; set; }
        public double Viaje { get; set; }
        public double Mantenimiento { get; set; }
        public double Impuesto_Derecho { get; set; }
        public double Diversos { get; set; }
        public double TotalVariable { get; set; }
        public double TotalGeneral { get; set; }
    }
    public class DataFijo
    {
        public string Rubro { get; set; }
        public double ImporteUSD { get; set; }
        public double CostoXHoraUSD { get; set; }
    }
    public class DataVariable
    {
        public string Rubro { get; set; }
        public double ImporteUSD { get; set; }
        public double CostoXHoraUSD { get; set; }
    }
    public class DataPromedioTotal
    {
        public string Mes { get; set; }
        public string Total { get; set; }
    }
}