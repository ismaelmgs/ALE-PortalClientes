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
        void LlenaDocsEdoCuenta(List<responseDocumentoF> olstRep);

        void LlenarEdoCuenta(List<responseEdoCuenta> olstRep);
        void LlenarRequiereIVAEdoCuenta(List<RequiereIVA> olstRep);
        void LlenarSubEdoCuenta(SubEdoCuenta olstRep);

        event EventHandler eSearchEdoObj;

        event EventHandler eSearchObjDocs;
        int iMes { get; }
        int iAnio { get; }
        int iExisteDoc { get; }
    }
}
