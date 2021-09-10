using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Clases
{
    public class Helper
    {
        public const string Usuarios = "U1";
        public const string Dashboard = "D1";
        public const string Aeronaves = "A1";
        public const string Calendario = "C1";
        public const string EstadoCuenta = "E1";
        public const string Tripulacion = "T1";
        public const string Metricas = "M1";

        public const string DominioWS = "WSMorvelRestDev";

        public const string UrlToken = "http://201.163.208.231/" + DominioWS + "/ws/authentica";
        public const string UrlLogin = "http://201.163.208.231/WSMorvelRestDev/ws/pc/valAccesoUsuarios";
        public const string US_UrlObtieneUsuarios = "http://201.163.208.231/WSMorvelRestDev/ws/pc/obtieneUsuarios";
        public const string US_UrlObtieneUsuariosFiltros = "http://201.163.208.231/WSMorvelRestDev/ws/pc/consultaUsuariosFiltros";
    }
}