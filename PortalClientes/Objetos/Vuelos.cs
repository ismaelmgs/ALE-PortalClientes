using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    [Serializable]
    public class Eventoss
    {
        public Vueloo totalesEventosMatriculas { get; set; }
        public List<detVuelos> detalleEventosMatriculas { get; set; }
    }

    [Serializable]
    public class Vueloo
    {
        public int? numeroTrips { get; set; }
        public int? numeroVuelos { get; set; }
        public int? aeroVisitados { get; set; }
        public int? numeroPasajeros { get; set; }
    }

    [Serializable]
    public class Vueloss
    {
        public int numTrip { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public string pax { get; set; }
        public string fechaInicio { get; set; }
        public string fechaFin { get; set; }
        public string TiempoVolado { get; set; }
    }

    [Serializable]
    public class detVuelos
    {
        public int tripNum { get; set; }
        public int legNum { get; set; }
        public string dutyType { get; set; }
        public string recType { get; set; }
        public string tripStat { get; set; }
        public string contrato { get; set; }
        public string notes { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public int distancia { get; set; }
        public float elpTime { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string requestor { get; set; }
        public string catCode { get; set; }
        public int pax { get; set; }
        public string farNum { get; set; }
        public string purpose { get; set; }
        public string cliente { get; set; }
        public string matricula { get; set; }
        public string typeDesc { get; set; }
        public string piloto { get; set; }
        public string copiloto { get; set; }
        public int legId { get; set; }
        public string pasajeros { get; set; }
        public string requestorName { get; set; }
        public string primerNomPil { get; set; }
        public string segNomPil { get; set; }
        public string apellidosPil { get; set; }
        public string primerNomCop { get; set; }
        public string segNomCop { get; set; }
        public string apellidosCop { get; set; }
        public string fboNombreOrigen { get; set; }
        public string fboPhoneOrigen { get; set; }
        public string fboDirOrigen { get; set; }
        public string fboNombreDest { get; set; }
        public string fboPhoneDest { get; set; }
        public string fboDirDest { get; set; }
        public string ciudadDestino { get; set; }
    }

    [Serializable]
    public class detalleVuelo
    {
        public string tripNum { get; set; }
        public string legNum { get; set; }
        public string dutyType { get; set; }
        public string recType { get; set; }
        public string tripStat { get; set; }
        public string statusVuelo { get; set; }
        public string contrato { get; set; }
        public string notes { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public int distancia { get; set; }
        public float elpTime { get; set; }
        public string FechaInicio { get; set; }
        public string HoraInicio { get; set; }
        public string FechaFin { get; set; }
        public string HoraFin { get; set; }
        public string requestor { get; set; }
        public string catCode { get; set; }
        public int pax { get; set; }
        public string farNum { get; set; }
        public string purpose { get; set; }
        public string cliente { get; set; }
        public string matricula { get; set; }
        public string typeDesc { get; set; }
        public string piloto { get; set; }
        public string copiloto { get; set; }
        public int legId { get; set; }
        public string pasajeros { get; set; }
        public string requestorName { get; set; }
        public string primerNomPil { get; set; }
        public string segNomPil { get; set; }
        public string apellidosPil { get; set; }
        public string primerNomCop { get; set; }
        public string segNomCop { get; set; }
        public string apellidosCop { get; set; }
        public string fboNombreOrigen { get; set; }
        public string fboPhoneOrigen { get; set; }
        public string fboDirOrigen { get; set; }
        public string fboNombreDest { get; set; }
        public string fboPhoneDest { get; set; }
        public string fboDirDest { get; set; }
        public string tripulacion { get; set; }
        public string TiempoVuelo { get; set; }

    }
}