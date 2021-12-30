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
        public const string US_UrlconsultaMatriculasUsuario = "http://201.163.208.231/" + DominioWS + "/ws/pc/consultaMatriculasUsuario";

        public const string US_UrlConsultaModulosPorUsuario = "http://201.163.208.231/" + DominioWS + "/ws/pc/consultaModulosPorUsuario";

        public const string US_UrlRelacionaUsuarioMats = "http://201.163.208.231/" + DominioWS + "/ws/pc/relUsuarioMatriculas";
        public const string US_UrlDesvinculaUsuarioMats = "http://201.163.208.231/" + DominioWS + "/ws/pc/desvinculaMatricula";

        public const string US_UrlObtieneModPorUser = "http://201.163.208.231/" + DominioWS + "/ws/pc/consultaModulosPorUsuario";
        public const string US_UrlRelacionaUsuarioMods = "http://201.163.208.231/" + DominioWS + "/ws/pc/relacionaModulosUsuario";
        public const string US_UrlClonaPermisosUserUser = "http://201.163.208.231/" + DominioWS + "/ws/pc/clonPermisosUsuario";

        public const string D_UrlObtenerDashboard = "http://201.163.208.231/" + DominioWS + "/ws/pc/consultaInfoDashboard";
        public const string D_UrlObtenerAeronave = "http://201.163.208.231/" + DominioWS + "/ws/pc/consultaMatriculaAeronave";


        public const string D_UrlObbtenerGastoRubros = "http://201.163.208.231/" + DominioWS + "/ws/pc/obtieneGastoRubroDetalle";
        public const string D_UrlObbtenerGastoProveedor = "http://201.163.208.231/" + DominioWS + "/ws/pc/obtieneGastosProveedor";
        public const string D_UrlObbtenerGastoAeropuerto = "http://201.163.208.231/" + DominioWS + "/ws/pc/obtieneGastosAeropuerto";
        public const string D_UrlObbtenerTiemposVuelo = "http://201.163.208.231/" + DominioWS + "/ws/pc/obtieneTiemposVuelo";
        public const string D_UrlObbtenerHorasVoladas = "http://201.163.208.231/" + DominioWS + "/ws/pc/obtieneGraficaHorasVoladas";
        public const string D_UrlObbtenerNoVuelos = "http://201.163.208.231/" + DominioWS + "/ws/pc/obtieneGraficaNumeroVuelos";
        public const string D_UrlObbtenerPromedioCostos = "http://201.163.208.231/" + DominioWS + "/ws/pc/obtieneGraficaPromedioCosto";
        public const string D_UrlObbtenerPromedioPasajeros = "http://201.163.208.231/" + DominioWS + "/ws/pc/obtieneGraficaPromedioPax";
        public const string D_UrlObbtenerCostoFijoVariable = "http://201.163.208.231/" + DominioWS + "/ws/pc/obtieneGraficaCostoFijo";
        public const string D_UrlObtieneGastoTotal = "http://201.163.208.231/" + DominioWS + "/ws/pc/obtieneGraficaGastoTotal";
        public const string D_UrlObtieneCostoHoraVuelo = "http://201.163.208.231/" + DominioWS + "/ws/pc/obtieneGraficaCostoHora";
        public const string D_UrlObtieneCostoFijoVariableHora = "http://201.163.208.231/" + DominioWS + "/ws/pc/obtieneGraficaCostoFijoVariableHora"; 
        public const string D_UrlObtieneCategoriasPeriodo = "http://201.163.208.231/" + DominioWS + "/ws/pc/obtieneGastosRubroDetTiempo";
        public const string D_UrlObtieneFacturasContratos = "http://201.163.208.231/" + DominioWS + "/ws/pc/obtieneFacturasContratos";

        public const string D_UrlObtieneRutasAeropuertos = "http://201.163.208.231/" + DominioWS + "/ws/pc/consultaRutaAeropuertosPeriodo";

        public const string D_UrlObtenerImagenesAeronave = "http://201.163.208.231/" + DominioWS + "/ws/pc/consultaImagenesAeronave";

        public const string D_UrlObbtenerEventosPiloto = "http://201.163.208.231/" + DominioWS + "/ws/pc/obtieneEventosPilotos";
        public const string D_UrlObtenerPilotos = "http://201.163.208.231/" + DominioWS + "/ws/pc/obtieneInfoPilotos";

        public const string D_UrlobtieneMetricasEstadisticas = "http://201.163.208.231/" + DominioWS + "/ws/pc/obtieneMetricasEstadisticas";

        public const string D_UrlObtenerMatriculasPorUsuario = "http://201.163.208.231/" + DominioWS + "/ws/pc/ObtenerMatriculasPorUsuario";
        public const string D_UrlObtenerEventosCalendario = "http://201.163.208.231/" + DominioWS + "/ws/pc/obtieneEventosMatriculaCal";

        public const string EC_ObtieneUltimoEdoCuenta = "http://201.163.208.231/" + DominioWS + "/ws/pc/obtieneUltimoEdoCtaMatricula";
        public const string D_UrlObtieneEdoCuenta = "http://201.163.208.231/" + DominioWS + "/ws/pc/consultaTotalesEdoCta";
        public const string D_UrlObtieneSubEdoCuenta = "http://201.163.208.231/" + DominioWS + "/ws/pc/consultaEdoCta";

    }
}