using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Interfaces
{
    public interface IViewUser : IBaseView
    {
        Usuario oUsuario { get; set; }
        void recargarPagina(responceAct resp);
    }
}