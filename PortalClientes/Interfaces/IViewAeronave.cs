﻿using PortalClientes.Objetos;
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
    }
}