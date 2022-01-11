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

    [Serializable]
    public class FiltroGrafica
    {
        public string matricula { get; set; }
        public string meses { get; set; }
    }

    [Serializable]
    public class FiltroGraficaCC
    {
        public string matricula { get; set; }
        public string meses { get; set; }
        public string claveCliente { get; set; }
    }

    [Serializable]
    public class FiltroGraficaGC
    {
        public string matricula { get; set; }
        public string mes { get; set; }
        public string anio { get; set; }
        public string claveContrato { get; set; }
    }

    [Serializable]
    public class FiltroGraficaFV
    {
        public string matricula { get; set; }
        public string meses { get; set; }
        public string idioma { get; set; }
    }

    [Serializable]
    public class FiltroEvent
    {
        public string matricula { get; set; }
        public int meses { get; set; }
    }

    [Serializable]
    public class FiltroPilotos
    {
        public string matricula { get; set; }
    }

    [Serializable]
    public class FiltroMatUsuario
    {
        public int idUsuario { get; set; }
    }

    [Serializable]
    public class FiltroDocumento
    {
        public string contrato { get; set; }
        public int anio { get; set; }
        public int mes { get; set; }
    }

    public class FiltroEdoCuenta
    {
        public string claveContrato { get; set; }
        public int anio { get; set; }
        public int mes { get; set; }
    }

    public class FiltroSubEdoCuenta
    {
        public string matricula { get; set; }
        public int anio { get; set; }
        public int mes { get; set; }
    }

    public class FiltroReporteEdoCuenta
    {
        public string matriculaActual { get; set; }
    }
}