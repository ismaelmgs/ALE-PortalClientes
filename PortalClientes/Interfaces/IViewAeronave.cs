using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Interfaces
{
    public interface IViewAeronave : IBaseView
    {
        Aeronave oAeronave { get; }
        void CargarAeronave(Aeronave oAeronave);
        void descargarDocumento(FotoAeronave oDoc);
        event EventHandler eGetObj;
        int idImagen { get; set; }
    }
}