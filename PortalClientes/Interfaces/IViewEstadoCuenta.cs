using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalClientes.Interfaces
{
    public interface IViewEstadoCuenta : IBaseView
    {
        void LlenaEstadoCuenta(EstadoCuenta oEstado);
        void LlenaTableEdoCuenta(List<responseRepEdoCuenta> olstRep);
        void LlenaDocsEdoCuenta(List<responseRepEdoCuenta> olstRep);

    }
}
