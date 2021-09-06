using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class Usuario
    {
        public string Correo { set; get; }
        public string Pass { set; get; }
        public string Nombres { set; get; }
        public string ApePat { set; get; }
        public string ApeMat { set; get; }
        public string Puesto { set; get; }
        public string TelefonoMovil { set; get; }
        public string TelefonoOficina { set; get; }
        public string CorreoSecundario { set; get; }
        public string UsuarioCreacion { set; get; }
    }

    public class UsuarioClientes
    {
        public int IdUsuario { set; get; }
        public int IdCliente { set; get; }
    }

    public class UsuarioMatriculas
    {
        public int IdUsuario { set; get; }
        public int IdMatricula { set; get; }
    }
}