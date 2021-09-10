using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalClientes.Interfaces
{
    public interface IViewLogin : IBaseView
    {
        string sEmail { get; }
        string sPassword { get; }
        Usuario oUser { set; get; }
        UserIdentity oU { set; get; }
    }
}
