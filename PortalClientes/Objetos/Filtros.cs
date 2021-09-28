using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    [Serializable]
    public class Filtros
    {
        public string filtro { set; get; }
    }

    [Serializable]
    public class FiltroMat
    {
        public string matriculaActual { get; set; }
        public string idioma { get; set; }
    }
}