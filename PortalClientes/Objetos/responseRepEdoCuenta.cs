using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class responseRepEdoCuenta
    {
        private List<DetalleRepEdoCuenta> _olsDetalle = new List<DetalleRepEdoCuenta>();

        public string nombreMes { set; get; }
        public int mes { set; get; }
        public int anio { set; get; }
        public string matricula { set; get; }
        public decimal saldoAnteriorMXN { set; get; }
        public decimal pagosCreditoMXN { set; get; }
        public decimal nuevosCargosMXN { set; get; }
        public decimal saldoActualMXN { set; get; }
        public decimal saldoAnteriorUSD { set; get; }
        public decimal pagosCreditoUSD { set; get; }
        public decimal nuevosCargosUSD { set; get; }
        public decimal saldoActualUSD { set; get; }
        
        public List<DetalleRepEdoCuenta> olsDetalle { get => _olsDetalle; set => _olsDetalle = value; }
    }

    public class DetalleRepEdoCuenta
    {
        public int mes { set; get; }
        public int anio { set; get; }
        public string tipoMoneda { set; get; }
        public string fecha { set; get; }
        public string noReferencia { set; get; }
        public string tipoGasto { set; get; }
        public string concepto { set; get; }
        public string rubro { set; get; }
        public string detalle { set; get; }
        public string proveedor { set; get; }
        public decimal importe { set; get; }
    }
}