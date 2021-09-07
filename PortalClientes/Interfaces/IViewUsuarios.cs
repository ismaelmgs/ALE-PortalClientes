﻿using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalClientes.Interfaces
{
    public interface IViewUsuarios : IBaseView
    {
        Usuario oUsuario { get; }
        void CargaUsuarios(List<Usuario> oLstUsers);
    }
}
