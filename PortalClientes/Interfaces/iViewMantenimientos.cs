using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PortalClientes.Interfaces
{
    public interface iViewMantenimientos : IBaseView
    {
        List<Mantenimientos> oMttos { get; set; }
        void cargarMantenimientos(List<Mantenimientos> oMttos);
        void cargarMantenimientosDB(DataTable dtMttos);
        int iMeses { get; }
    }
}