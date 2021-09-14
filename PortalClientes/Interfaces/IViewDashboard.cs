using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalClientes.Interfaces
{
    public interface IViewDashboard : IBaseView
    {
        Dashboard oDashboard { get; }
        string sMatricula { get; }
        void CargarDashboard(Dashboard oDash);
    }
}
