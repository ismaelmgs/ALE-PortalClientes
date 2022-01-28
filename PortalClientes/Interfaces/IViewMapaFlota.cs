using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Interfaces
{
    public interface IViewMapaFlota : IBaseView
    {
        MapaFlota oFlota { get; set; }
        void cargarMapaFlota(MapaFlota oMapaFlota);
        int iMeses { get; }
        string sMatricula { get; }
    }
}