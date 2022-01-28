using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    [Serializable]
    public class MapaFlota
    {
        public totales detalleTotalVuelos { get;set;}
        public List<rutas> detalleRutas { get;set; }
        public List<aeropuertos> detalleAeropuertos { get; set; }
    }

    [Serializable]
    public class totales
    {
        public int numeroVuelos { get; set; }
        public int numeroAeropuertos { get; set; }
        public string tiempoVolado { get; set; }
        public string distanciaVolada { get; set; }
    }

    [Serializable]
    public class rutas
    {
        public int tripNum { get; set; }
        public int idAeropuerto { get; set; }
        public string matricula { get; set; }
        public string aorigenLatitud { get; set; }
        public string aorigenLongitud { get; set; }
        public string adestinoLatitud { get; set; }
        public string adestinoLongitud { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
    }

    [Serializable]
    public class aeropuertos
    {
        public string matricula { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string aeropuerto { get; set; }
        public string descripcion { get; set; }
    }

    [Serializable]
    public class MFJson
    {
        public List<rutas> Rutas { get; set; }
        public List<aeropuertos> Aeropuertos { get; set; }
    }
}