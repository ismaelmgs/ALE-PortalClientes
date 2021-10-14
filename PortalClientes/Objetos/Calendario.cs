using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    public class Appointment
    {

        public string ID { get; set; } // diferenciar eventos
        public DateTime StartTime { get; set; } // cuando inicia
        public string Label { get; set; } // n/a
        public bool AllDay { get; set; } // si abarca todo el dia
        public DateTime EndTime { get; set; } // cuando finaliza
        public string Description { get; set; } // descripcion
        public string Location { get; set; } // localizacion
        public string Subject { get; set; } // asunto
        public string Status { get; set; } // estado del evento
        public string EventType { get; set; } // tipo de evento
    }
}