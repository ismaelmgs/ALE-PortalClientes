    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class requestUsuarioMatricula
    {
        public int idUsuario { set; get; }
        public int idMatricula { set; get; }
        public string claveCliente { set; get; }
    }
}