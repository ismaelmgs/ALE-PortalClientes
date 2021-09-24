using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    [Serializable]
    public class MenuDinamico
    {
        public string urlPage { set; get; }
        public string style { set; get; }
        public string nombreESP { set; get; }
        public string nombreUSD { set; get; }
    }


}