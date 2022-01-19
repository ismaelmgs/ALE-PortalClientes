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
        public int? noPasajeros { get; set; }
        public int? noTripulacion { get; set; }
        public string Clase { get; set; }
        public string size { get; set; }
        public int? pesoMaxDespegue { get; set; }
        public int? pesoMaxAterrizaje { get; set; }
        public int? pesoMaxZeroComb { get; set; }
        public int? pesoBasicoOpe { get; set; }
        public int? maxNivelAltura { get; set; }
        public string velocidadCrucero { get; set; }
        public IEnumerable<FotoAeronave> Imagenes { get; set; }

    }

    [Serializable]
    public class FotoAeronave
    {
        public string NombreImagen { get; set; }
        public string Extension { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
    }
}