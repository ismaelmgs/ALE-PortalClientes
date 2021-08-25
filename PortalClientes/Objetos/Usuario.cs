using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class Usuario
    {
        public string IdUsuario { set; get; }
        public string Correo { set; get; }
        public string Pass { set; get; }
        public string Nombres { set; get; }
        public string ApePat { set; get; }
        public string ApeMat { set; get; }
        public string Puesto { set; get; }
    }
}