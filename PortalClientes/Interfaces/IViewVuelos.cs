using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Interfaces
{
    public interface IViewVuelos : IBaseView
    {
        List<detVuelos> oDetVuelos { get; set; }
        Vueloo oVuelos { get; }
        string stiempoVuelo { get; set; }
        int iminutos { get; set; }
        void cargarVuelos(Eventoss oVuelos);

    }
}