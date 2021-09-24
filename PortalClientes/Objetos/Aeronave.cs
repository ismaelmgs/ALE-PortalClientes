using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    [Serializable]
    public class Aeronave
    {
        public string nombreAeronave { get; set; }
        public string Fabricante { get; set; }
        public string Anio { get; set; }
        public string Modelo { get; set; }
        public string noRegistro { get; set; }
        public string noSerie { get; set; }
        public int noPasajeros { get; set; }
        public int noTripulacion { get; set; }
        public string dimencionesExteriores { get; set; }
        public string dimencionesInteriores { get; set; }
        public int maxGasolina { get; set; }
        public int minGasolina { get; set; }
        public int velocidadCrucero { get; set; }
        public int altitudMaxima { get; set; }
        public string tipoGasolina { get; set; }
        public int Rendimiento { get; set; }
        public int Distancia { get; set; }
        public int Peso { get; set; }
        public IEnumerable<FotoAeronave> Imagenes { get; set; }

    }

    [Serializable]
    public class FotoAeronave
    {
        public string NombreImagen { get; set; }
        public string Extension { get; set; }
        public string Imagen { get; set; }
    }
}