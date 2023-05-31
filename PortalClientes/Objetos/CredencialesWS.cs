using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    [Serializable]
    public class CredencialesWS
    {
        public string username { set; get; }
        public string password { set; get; }
    }

    [Serializable]
    public class TokenWS
    {
        public string token { set; get; }
    }


    [Serializable]
    public class Credenciales
    {
        public string UserName { set; get; }
        public string Password { set; get; }
    }
    [Serializable]
    public class Token
    {
        public string nombre { set; get; }
        public string token { set; get; }
        public string codRespuesta { set; get; }
        public string descRespuesta { set; get; }
    }
}