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

        public const string DominioWS = "WSMorvelRest";         //PRODUCCION
        //public const string DominioWS = "WSMorvelRestDev";    //DESARROLLO

        public const string UrlToken = "http://201.163.208.231/" + DominioWS + "/ws/authentica";
        public const string UrlLogin = "http://201.163.208.231/" + DominioWS + "/ws/pc/valAccesoUsuarios";
        public const string US_UrlObtieneUsuarios = "http://201.163.208.231/" + DominioWS + "/ws/pc/obtieneUsuarios";
        public const string US_UrlObtieneUsuariosFiltros = "http://201.163.208.231/" + DominioWS + "/ws/pc/consultaUsuariosFiltros";
        public const string US_UrlInsertaUsuario = "http://201.163.208.231/" + DominioWS + "/ws/pc/insertaUsuarios";
        public const string US_UrlConsultaMatriculas = "http://201.163.208.231/" + DominioWS + "/ws/pc/consultaMatriculas";
        
        public const string US_UrlConsultaModulosPorUsuario = "http://201.163.208.231/" + DominioWS + "/ws/pc/consultaModulosPorUsuario";

        public const string US_UrlRelacionaUsuarioMats = "http://201.163.208.231/" + DominioWS + "/ws/pc/relUsuarioMatriculas";
        public const string US_UrlDesvinculaUsuarioMats = "http://201.163.208.231/" + DominioWS + "/ws/pc/desvinculaMatricula";

        public const string US_UrlObtieneModPorUser = "http://201.163.208.231/" + DominioWS + "/ws/pc/consultaModulosPorUsuario";
        public const string US_UrlRelacionaUsuarioMods = "http://201.163.208.231/" + DominioWS + "/ws/pc/relacionaModulosUsuario";
        public const string US_UrlClonaPermisosUserUser = "http://201.163.208.231/" + DominioWS + "/ws/pc/clonPermisosUsuario";

        public const string D_UrlObtenerDashboard = "http://201.163.208.231/" + DominioWS + "/ws/pc/consultaInfoDashboard";
        public const string D_UrlObtenerAeronave = "http://201.163.208.231/" + DominioWS + "/ws/pc/consultaMatriculaAeronave";


        public const string D_UrlObbtenerGastoRubros = "http://201.163.208.231/" + DominioWS + "/ws/pc/obtieneGastoRubroDetalle";
        public const string D_UrlObtenerImagenesAeronave = "http://201.163.208.231/" + DominioWS + "/ws/pc/consultaImagenesAeronave";

    }
}