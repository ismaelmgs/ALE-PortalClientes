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

    [Serializable]
    public class FiltroGraficaGastos
    {
        public string matricula { get; set; }
        public string meses { get; set; }
        public DateTime? fechaInicial { get; set; }
        public DateTime? fechaFinal { get; set; }
        public int rubro { get; set; }
        public string idioma { get; set; }
        public int tipoRubro { get; set; } // 1.fijo 2. var 3. todos
    }
}