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
        public int IdUsuario { set; get; }
        public string Correo { set; get; }
        public string Pass { set; get; }
        public string Nombres { set; get; }
        public string ApePat { set; get; }
        public string ApeMat { set; get; }
        public string Puesto { set; get; }
        public string TelefonoMovil { set; get; }
        public string TelefonoOficina { set; get; }
        public string CorreoSecundario { set; get; }
        public int Sts { set; get; }
        public string DescSts { set; get; }
        public string Matriculas { set; get; }
        public string Clientes { set; get; }
        public string UsuarioCreacion { set; get; }
        public DateTime? FechaCreacion { set; get; }
        public string UsuarioModificacion { set; get; }
        public DateTime? FechaModificacion { set; get; }
        public string codigo { set; get; }
        public string mensaje { set; get; }
        public string NombreCliente { set; get; }
        public int tipoActualizacion { get; set; }
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


    [Serializable]
    public class UsuariosCombos
    {
        public int IdUsuario { set; get; }
        public string Nombre { set; get; }
    }
}