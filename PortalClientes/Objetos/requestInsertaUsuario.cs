using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class requestInsertaUsuario
    {
        public string correo { set; get; }
        public string pass { set; get; }
        public string nombres { set; get; }
        public string apePat { set; get; }
        public string apeMat { set; get; }
        public string puesto { set; get; }
        public string telefonoMovil { set; get; }
        public string telefonoOficina { set; get; }
        public string correoSecundario { set; get; }
        public string usuarioCreacion { set; get; }
    }
}