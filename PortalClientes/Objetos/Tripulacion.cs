using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    [Serializable]
    public class Piloto
    {
        public string codigoPiloto { get; set; }
        public string piloto { get; set; }
        public string licenciaVuelo { get; set; }
        public string tipoLicencia { get; set; }
        public DateTime expiraLicencia { get; set; }
        public string lugarTrabajo { get; set; }
        public string noVisa { get; set; }
        public DateTime fechaExpiraVisa { get; set; }
        public string paisVisa { get; set; }
        public string noPassport { get; set; }
        public DateTime fechaExpiraPass { get; set; }
        public string pais { get; set; }
    }

    [Serializable]
    public class EventosPiloto
    {
        public string codigoPiloto { get; set; }
        public string piloto { get; set; }
        public string temaESP { get; set; }
        public string temaENG { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public string descripcion { get; set; }
    }
}