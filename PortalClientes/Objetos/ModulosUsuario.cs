using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    [Serializable]
    public class ModulosUsuario
    {
        public int idModulo { set; get; }
        public string claveModulo { set; get; }
        public string nombreESP { set; get; }
        public string nombreENG { set; get; }
        public string urlPage { set; get; }
        public string icono { set; get; }
        public int sts { set; get; }
        public string codigo { set; get; }
        public string mensaje { set; get; }
    }

    //public class ModulosUsuarioGrid
    //{
    //    public int idModulo { set; get; }
    //    public string claveModulo { set; get; }
    //    public string nombreESP { set; get; }
    //    public string nombreENG { set; get; }
    //    public string urlPage { set; get; }
    //    public string icono { set; get; }
    //    public int sts { set; get; }
    //    public string codigo { set; get; }
    //    public string mensaje { set; get; }

    //    private bool _seleccionado = false;
    //    public bool seleccionado { set { _seleccionado = value; } get { return _seleccionado; } }
    //}
}