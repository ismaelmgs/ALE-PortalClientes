using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Interfaces
{
    public interface IViewRecoveryPass : IBaseView
    {
        string sEmail { get; }
        string sTime { get; }
        string sPassword { get; }
        int iTipoActualizacion { get; }
        void requestResponse(responceAct response);
    }
}