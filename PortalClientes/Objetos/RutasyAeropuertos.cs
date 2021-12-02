using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class RutaAeropuerto
    {
        public List<Rutas> rutas { get; set; }
        public List<Aeropuertos> aeropuertos { get; set; }
    }

    public class Rutas
    {
        public int idAeropuerto { get; set; }
        public string aeronaveMatricula { get; set; }
        public string aorigen_Latitud { get; set; }
        public string aorigen_Longitud { get; set; }
        public string adestino_Latitud { get; set; }
        public string adestino_Longitud { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
    }

    public class Aeropuertos
    {
        public int idAeropuerto { get; set; }
        public string matricula { get; set; }
        public string latitud { get; set; }
        public string longitud { get; set; }
        public string aeropuerto { get; set; } // clave del aeropuerto
        public string descripcion { get; set; } // descripcion del aeropuerto
    }
}