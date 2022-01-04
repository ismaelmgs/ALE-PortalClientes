using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class Transacciones
    {
        public List<vuelo> vuelos { get; set; } // tipo transaccion: 1
        public List<gvGastos> gastos { get; set; } // tipo transaccion: 2
        public List<gvGastosProveedor> gastosProv { get; set; } // tipo transaccion: 3
        public List<gvGastosAeropuerto> gastosAe { get; set; } // tipo transaccion: 4
        public List<gvPromedioPax> promedioPax { get; set; } // tipo transaccion: 5
        public List<gvPromedioCosto> promedioCosto { get; set; } // tipo transaccion: 6
        public List<gvhorasVoladas> horasVoladas { get; set; } // tipo transaccion: 7
        public List<gvnoVuelos> numeroVuelos { get; set; } // tipo transaccion: 8
        public List<gvCostosFV> costosFijosVariable { get; set; } // tipo transaccion: 9
        public List<gvGastosT> gastosTotales { get; set; } // tipo transaccion: 10
        public List<gvCostosH> costosHoraVuelo { get; set; } // tipo transaccion: 11
        public List<gvCostosFVH> costosFijosVariableHora { get; set; } // tipo transaccion: 12
        public List<detalleEdoCta> detalleEdoCuenta { get; set; } // tipo transaccion: 13
        public List<gvDetGastos> detGastos { get; set; } // tipo transaccion: 14
    }

    public class camposOpcionales
    {
        public string campo1 { get; set; }
        public string campo2 { get; set; }
        public string campo3 { get; set; }
        public string campo4 { get; set; }
        public string campo5 { get; set; }
        public string campo6 { get; set; }
        public string campo7 { get; set; }
        public string campo8 { get; set; }
        public string campo9 { get; set; }
        public string campo10 { get; set; }
    }
}