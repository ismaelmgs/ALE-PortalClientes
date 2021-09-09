using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    [Serializable]
    public class Login
    {
        public string email { set; get; }
        public string password { set; get; }
    }
}