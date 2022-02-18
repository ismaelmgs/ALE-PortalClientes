using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Interfaces
{
    public interface IViewEmailRecoverPass : IBaseView
    {
        string sEmail { get; }
        event EventHandler eValidateObj;
        void isValidUser(string isValid);
    }
}