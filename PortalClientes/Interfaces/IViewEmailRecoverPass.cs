using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Interfaces
{
    public interface IViewEmailRecoverPass : IBaseView
    {
        string sEmail { get; }
        string sapiKey{ get; }
        string sEmailSoporte { get; }
        string sTemplate { get; }

        event EventHandler eValidateObj;
        void isValidUser(string isValid);
        void setParameters(List<Parametros> lstParameters);
    }
}