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

    public class requestActualizaUsuario
    {
        public string email { set; get; }
        public int opcion { get; set; }
        public string nombre { set; get; }
        public string primeroApe { set; get; }
        public string segundoApe { set; get; }
        public string puesto { set; get; }
        public string telefonoMovil { set; get; }
        public string telefonoOficina { set; get; }
        public string correoSecundario { set; get; }
        public string usuarioModifica { set; get; }
    }

    public class responceAct
    {
        public string mensaje { get; set; }
        public int operacion { get; set; }
    }
}