using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalClientes.Interfaces
{
    public interface IViewTripulacion : IBaseView
    {
        int iMeses { get; }
        void CargarEventosTripulacion(List<EventosPiloto> oEP);
        void CargarPilotosTripulacion(List<Piloto> oPT);

        event EventHandler eSearchObjEventos;
        
    }
}
