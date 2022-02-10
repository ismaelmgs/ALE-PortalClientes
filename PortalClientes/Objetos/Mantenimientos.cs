using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Objetos
{
    [Serializable]
    public class Mantenimientos
    {
        public int origNmbr { get; set; }
        public int legNum { get; set; }
        public string dutyType { get; set; }
        public string tipoRec { get; set; }
        public string tripStat { get; set; }
        public string descripcion { get; set; }
        public string notes { get; set; }
        public string depicaoId { get; set; }
        public string arricaoId { get; set; }
        public float elpTime { get; set; }
        public DateTime fechaInicio { get; set; }
        public DateTime fechaFin { get; set; }
        public string tailMnbr { get; set; }
        public string typeDesc { get; set; }
    }
}