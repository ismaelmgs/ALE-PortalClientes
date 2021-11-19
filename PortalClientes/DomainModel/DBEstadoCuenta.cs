using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NucleoBase.Core;
using System.Data;

namespace PortalClientes.DomainModel
{
    public class DBEstadoCuenta : DBBase
    {
        public EstadoCuenta DBGetObtieneMatricuasPorUsuario(string Matricula)
        {
            oDB_SP.sConexionSQL = "Data Source=192.168.1.219;Initial Catalog=MexJet360;User ID=sa;Password=SYS.*2015%SQL";

            return oDB_SP.EjecutarDT("[PortalClientes].[spS_PC_ObtieneUltimoEdoCuentaMatricula]", "@Matricula", Matricula).AsEnumerable().Select(r => new EstadoCuenta()
            {
                mes = r["Mes"].S().I(),
                anio = r["Anio"].S().I(),
                saldoAnteriorUSD = r["SaldoAnteriorUSD"].S().D(),
                pagosCreditosUSD = r["PagosCreditosUSD"].S().D(),
                nuevosCargosUSD = r["NuevosCargosUSD"].S().D(),
                saldoActualUSD = r["SaldoActalUSD"].S().D(),
                saldoAnteriorMXN = r["SaldoAnteriorMXN"].S().D(),
                pagosCreditosMXN = r["PagosCreditosMXN"].S().D(),
                nuevosCargosMXN = r["NuevosCargosMXN"].S().D(),
                saldoActualMXN = r["SaldoActalMXN"].S().D()

            }).FirstOrDefault();
        }
    }
}