using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    [Serializable]
    public class UserIdentity
    {
        public int iIdUsuario { set; get; }
        public string sNombre { set; get; }
        public string sPuesto { set; get; }
        public string sCorreo { set; get; }
        public string sIdioma { set; get; }
        public List<string> lsMatriculas { set; get; }
        public string sMatricula { set; get; }
        public string Clientes { set; get; }
        public string NombreCliente { set; get; }
    }
}