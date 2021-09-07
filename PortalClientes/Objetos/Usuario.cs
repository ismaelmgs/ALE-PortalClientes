using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PortalClientes.Objetos
{
    [Serializable]
    public class Usuario
    {
        public string Correo { set; get; }
        public string Pass { set; get; }

        [Required(ErrorMessageResourceType = typeof(Properties.Resources), ErrorMessageResourceName = "Cm_CampoReq")]
        public string Nombres { set; get; }

        public string ApePat { set; get; }
        public string ApeMat { set; get; }
        public string Puesto { set; get; }
        public string TelefonoMovil { set; get; }
        public string TelefonoOficina { set; get; }
        public string CorreoSecundario { set; get; }
        public string UsuarioCreacion { set; get; }
    }


    [Serializable]
    public class UsuarioClientes
    {
        public int IdUsuario { set; get; }
        public int IdCliente { set; get; }
    }

    [Serializable]
    public class UsuarioMatriculas
    {
        public int IdUsuario { set; get; }
        public int IdMatricula { set; get; }
    }
}