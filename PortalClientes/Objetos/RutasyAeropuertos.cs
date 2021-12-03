using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    [Serializable]
    public class RutaAeropuerto
    {
        public List<Rutas> rutaAeropuertoPeriodoA { get; set; }
        public List<Aeropuertos> rutaAeropuertoPeriodoB { get; set; }
    }

    [Serializable]
    public class Rutas
    {
        public int idAeropuerto { get; set; }
        public string aeronaveMatricula { get; set; }
        public float? aorigenLatitud { get; set; }
        public float? aorigenLongitud { get; set; }
        public float? adestinoLatitud { get; set; }
        public float? adestinoLongitud { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
    }

    [Serializable]
    public class Aeropuertos
    {
        public int idAeropuerto { get; set; }
        public string matricula { get; set; }
        public float? latitud { get; set; }
        public float? longitud { get; set; }
        public string aeropuerto { get; set; } // clave del aeropuerto
        public string descripcion { get; set; } // descripcion del aeropuerto
    }

    [Serializable]
    public class gvRutas
    {
        public string rutas { get; set; }
    }

    [Serializable]
    public class gvAeropuertos
    {
        public string aeropuerto { get; set; }
        public string clave { get; set; }
    }
}