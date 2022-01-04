using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    [Serializable]
    public class responseRepEdoCuenta
    {
        private List<detalleEdoCta> _olsDetalle = new List<detalleEdoCta>();

        public string nombreMes { set; get; }
        public int mes { set; get; }
        public int anio { set; get; }
        public string matricula { set; get; }
        public string contrato { set; get; }
        public int docF { set; get; }
        public string saldoAnteriorMXN { set; get; }
        public string pagosCreditoMXN { set; get; }
        public string nuevosCargosMXN { set; get; }
        public string saldoActualMXN { set; get; }
        public string saldoAnteriorUSD { set; get; }
        public string pagosCreditoUSD { set; get; }
        public string nuevosCargosUSD { set; get; }
        public string saldoActualUSD { set; get; }              

        public List<detalleEdoCta> olsDetalle { get => _olsDetalle; set => _olsDetalle = value; }
    }

    [Serializable]
    public class detalleEdoCta
    {
        public string nombreMes { set; get; } 
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
    public class responseDocumentoF
    {
        public string Clave { get; set; }
        public string RazonSocial { get; set; }
        public string TipoDocumento { get; set; }
        public int Folio { get; set; }
        public int Anio { get; set; }
        public int Mes { get; set; }
        public int Dia { get; set; }
        public DateTime fechaDocumento { get; set; }
    }

    public class responseEdoCuenta
    {
        public string idSaldosEdoCuenta { set; get; }
        public string claveContrato { set; get; }
        public string TipoMoneda { set; get; }
        public int mes { set; get; }
        public int anio { set; get; }
        public decimal saldoAnterior { set; get; }
        public decimal pagosCreditos { set; get; }
        public decimal nuevosCargos { set; get; }
        public decimal saldoActual { set; get; }
        public decimal existeMesActual { set; get; }
        public decimal existeMesAnterior { set; get; }
    }

    public class ResponseSubEdoCuenta
    {
        public string fecha { set; get; }
        public string numReferencia { set; get; }
        public string tipoGasto { set; get; }
        public string concepto { set; get; }
        public string rubro { set; get; }
        public string detalle { set; get; }
        public string proveedor { set; get; }
        public decimal importe { set; get; }
    }

    public class SubEdoCuenta
    {
        public List<ResponseSubEdoCuenta> estadoCuentaMXN { set; get; }
        public List<ResponseSubEdoCuenta> estadoCuentaUSD { set; get; }
    }
}