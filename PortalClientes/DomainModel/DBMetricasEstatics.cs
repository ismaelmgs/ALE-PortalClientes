using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using System.Web.Script.Serialization;
using PortalClientes.Clases;
using PortalClientes.Objetos;
using NucleoBase.BaseDeDatos;
using System.Data;
using NucleoBase.Core;

namespace PortalClientes.DomainModel
{
    public class DBMetricasEstatics
    {
        public BD_SP oDB_SP = new BD_SP();

        public List<responseGraficaGastos> ObtenerGastos(FiltroGraficaGastos filtro)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                List<responseGraficaGastos> d = new List<responseGraficaGastos>();
                FiltroGraficaGastos oLog = new FiltroGraficaGastos();
                oLog = filtro;
                oLog.matricula = Utils.MatriculaActual;
                oLog.idioma = Utils.Idioma;

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.D_UrlObbtenerGastoRubros);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;

                d = ser.Deserialize<List<responseGraficaGastos>>(resp);

                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<responseGraficaProveedores> ObtenerGastosProveedor(FiltroGrafica filtro)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                List<responseGraficaProveedores> d = new List<responseGraficaProveedores>();
                FiltroGrafica oLog = new FiltroGrafica();
                oLog = filtro;
                oLog.matricula = Utils.MatriculaActual;

                oLog.matricula = "XA-CHY";
                oLog.meses = "3";

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.D_UrlObbtenerGastoProveedor);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;

                d = ser.Deserialize<List<responseGraficaProveedores>>(resp);

                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<responseGraficaAeropuerto> ObtenerGastosAeropuerto(FiltroGrafica filtro)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                List<responseGraficaAeropuerto> d = new List<responseGraficaAeropuerto>();
                FiltroGrafica oLog = new FiltroGrafica();
                oLog = filtro;
                oLog.matricula = Utils.MatriculaActual;

                oLog.matricula = "XA-CHY";
                oLog.meses = "3";

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.D_UrlObbtenerGastoAeropuerto);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;

                d = ser.Deserialize<List<responseGraficaAeropuerto>>(resp);

                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<responseGraficaDuracionVuelos> ObtenerDuracionVuelos(FiltroGrafica filtro)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                List<responseGraficaDuracionVuelos> d = new List<responseGraficaDuracionVuelos>();
                FiltroGrafica oLog = new FiltroGrafica();
                oLog = filtro;
                oLog.matricula = Utils.MatriculaActual;

                oLog.matricula = "XA-CHY";
                oLog.meses = "3";

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.D_UrlObbtenerTiemposVuelo);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;

                d = ser.Deserialize<List<responseGraficaDuracionVuelos>>(resp);

                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<responseGraficaHorasVoladas> ObtenerHorasVoladas(FiltroGrafica filtro)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                List<responseGraficaHorasVoladas> d = new List<responseGraficaHorasVoladas>();
                FiltroGrafica oLog = new FiltroGrafica();
                oLog = filtro;
                oLog.matricula = Utils.MatriculaActual;

                oLog.matricula = "XA-CHY";
                oLog.meses = "3";

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.D_UrlObbtenerHorasVoladas);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;

                d = ser.Deserialize<List<responseGraficaHorasVoladas>>(resp);

                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<responseGraficaNoVuelos> ObtenerNoVuelos(FiltroGrafica filtro)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                List<responseGraficaNoVuelos> d = new List<responseGraficaNoVuelos>();
                FiltroGrafica oLog = new FiltroGrafica();
                oLog = filtro;
                oLog.matricula = Utils.MatriculaActual;

                oLog.matricula = "XA-CHY";
                oLog.meses = "3";

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.D_UrlObbtenerNoVuelos);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;

                d = ser.Deserialize<List<responseGraficaNoVuelos>>(resp);

                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<responseGraficaPromedioCostos> ObtenerPromedioCostos(FiltroGrafica filtro)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                List<responseGraficaPromedioCostos> d = new List<responseGraficaPromedioCostos>();
                FiltroGrafica oLog = new FiltroGrafica();
                oLog = filtro;
                oLog.matricula = Utils.MatriculaActual;

                oLog.matricula = "XA-CHY";
                oLog.meses = "3";

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.D_UrlObbtenerPromedioCostos);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;

                d = ser.Deserialize<List<responseGraficaPromedioCostos>>(resp);

                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<responseGraficaPromedioPasajero> obtenerPromedioPasajero(FiltroGrafica filtro)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                List<responseGraficaPromedioPasajero> d = new List<responseGraficaPromedioPasajero>();
                FiltroGrafica oLog = new FiltroGrafica();
                oLog = filtro;
                oLog.matricula = Utils.MatriculaActual;

                oLog.matricula = "XA-CHY";
                oLog.meses = "3";

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.D_UrlObbtenerPromedioPasajeros);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;

                d = ser.Deserialize<List<responseGraficaPromedioPasajero>>(resp);

                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<responseGraficaCostoFijoVariable> obtenerCostosFijoVariable(FiltroGraficaFV filtro)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                List<responseGraficaCostoFijoVariable> d = new List<responseGraficaCostoFijoVariable>();
                FiltroGraficaFV oLog = new FiltroGraficaFV();
                oLog = filtro;
                oLog.matricula = Utils.MatriculaActual;
                oLog.idioma = Utils.Idioma;

                //oLog.matricula = "XA-CHY";
                oLog.meses = "3";

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.D_UrlObbtenerCostoFijoVariable);

                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;

                d = ser.Deserialize<List<responseGraficaCostoFijoVariable>>(resp);

                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<responseGraficaGastoTotal> obtenerGastoTotal(FiltroGrafica filtro)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                List<responseGraficaGastoTotal> d = new List<responseGraficaGastoTotal>();
                FiltroGrafica oLog = new FiltroGrafica();
                oLog = filtro;
                oLog.matricula = Utils.MatriculaActual;

                oLog.matricula = "XA-FLC";
                oLog.meses = "12";

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.D_UrlObtieneGastoTotal);

                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;

                d = ser.Deserialize<List<responseGraficaGastoTotal>>(resp);

                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<responseGraficaCostoHoraVuelo> obtenerCostoHoraVuelo(FiltroGrafica filtro)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                List<responseGraficaCostoHoraVuelo> d = new List<responseGraficaCostoHoraVuelo>();
                FiltroGrafica oLog = new FiltroGrafica();
                oLog = filtro;
                oLog.matricula = Utils.MatriculaActual;

                oLog.matricula = "XA-FLC";
                oLog.meses = "12";

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.D_UrlObtieneCostoHoraVuelo);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;

                d = ser.Deserialize<List<responseGraficaCostoHoraVuelo>>(resp);

                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<responseGraficaCostoFijoVariableHora> obtenerCostoFijoVariableHora(FiltroGraficaFV filtro)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                List<responseGraficaCostoFijoVariableHora> d = new List<responseGraficaCostoFijoVariableHora>();
                FiltroGraficaFV oLog = new FiltroGraficaFV();
                oLog = filtro;
                oLog.matricula = Utils.MatriculaActual;
                oLog.idioma = Utils.Idioma;

                oLog.matricula = "XA-CHY";
                oLog.meses = "3";

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.D_UrlObtieneCostoFijoVariableHora);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;

                d = ser.Deserialize<List<responseGraficaCostoFijoVariableHora>>(resp);

                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<responseGraficaCategorias> obtenerCategoriasPeriodos(FiltroGraficaFV filtro)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                List<responseGraficaCategorias> d = new List<responseGraficaCategorias>();
                FiltroGraficaFV oLog = new FiltroGraficaFV();
                oLog = filtro;
                oLog.matricula = Utils.MatriculaActual;

                oLog.matricula = "XA-FLC";
                //oLog.meses = "12";
                oLog.idioma = Utils.Idioma;

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.D_UrlObtieneCategoriasPeriodo);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;

                d = ser.Deserialize<List<responseGraficaCategorias>>(resp);

                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<rptResumenGastosVuelos> obtenerReporteResumenGastosVuelos(FiltroGraficaCC filtro)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                List<rptResumenGastosVuelos> d = new List<rptResumenGastosVuelos>();
                FiltroGraficaCC oLog = new FiltroGraficaCC();
                oLog = filtro;
                oLog.matricula = Utils.MatriculaActual;

                oLog.matricula = "XA-FLC";
                oLog.meses = "12";
                oLog.claveCliente = "RASSI";

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.D_UrlObtieneRptResumenGastosVuelos);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;

                d = ser.Deserialize<List<rptResumenGastosVuelos>>(resp);

                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public responseDetGastosVuelos obtenerReporteDetalleGastosVuelos(FiltroGraficaCC filtro)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                responseDetGastosVuelos d = new responseDetGastosVuelos();
                FiltroGraficaCC oLog = new FiltroGraficaCC();
                oLog = filtro;
                oLog.matricula = Utils.MatriculaActual;

                oLog.matricula = "XA-FLC";
                oLog.meses = "12";
                oLog.claveCliente = "RASSI";

                //TokenWS oToken = Utils.ObtieneToken;

                //var client = new RestClient(Helper.D_UrlObtieneRptResumenGastosVuelos);
                //var request = new RestRequest(Method.POST);
                //request.AddHeader("Authorization", oToken.token);
                //request.AddJsonBody(oLog);

                //IRestResponse response = client.Execute(request);
                //var resp = response.Content;

                //d = ser.Deserialize<responseDetGastosVuelos>(resp);

                oDB_SP.sConexionSQL = "Data Source=192.168.1.219;Initial Catalog=MexJet360;User ID=sa;Password=SYS.*2015%SQL";
                DataSet ds = oDB_SP.EjecutarDS("[PortalClientes].[spS_PC_ObtieneReporteDetalleGastosVuelos]", "@Matricula", oLog.matricula, "@Meses", oLog.meses, "@ClaveCliente", oLog.claveCliente);
                d.vuelos = new List<vuelos>();
                d.conceptosVuelos = new List<conceptos>();

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    vuelos v = new vuelos();
                    v.anio = row["Anio"].S().I();
                    v.mes = row["Mes"].S().I();
                    v.origenVuelo = row["origenVuelo"].S();
                    v.destinoVuelo = row["destinoVuelo"].S();
                    v.anio = row["tiempoVuelo"].S().I();
                    v.cantPax = row["cantPax"].S().I();
                    v.cliente = row["cliente"].S();
                    v.contrato = row["contrato"].S();

                    d.vuelos.Add(v);
                }

                foreach (DataRow row in ds.Tables[1].Rows)
                {
                    conceptos c = new conceptos();
                    c.idRubro = row["idRubro"].S().I();
                    c.rubroESP = row["rubroESP"].S();
                    c.rubroENG = row["rubroENG"].S();
                    c.totalMXN = row["totalMXN"].S().I();
                    c.totalUSD = row["totalUSD"].S().I();
                    c.fecha = (DateTime)row["fecha"];
                    c.categoria = row["categoria"].S();
                    c.tipoGasto = row["tipodeGasto"].S();
                    c.comentarios = row["comentarios"].S();
                    c.mes = row["mes"].S().I();
                    c.anio = row["Anio"].S().I();

                    d.conceptosVuelos.Add(c);
                }

                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public RutaAeropuerto obtenerRutasAeropuertos (FiltroEvent filtro)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                RutaAeropuerto d = new RutaAeropuerto();
                FiltroEvent oLog = new FiltroEvent();
                oLog = filtro;
                oLog.matricula = Utils.MatriculaActual;

                oLog.matricula = "XA-ALE";
                oLog.meses = 1;

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.D_UrlObtieneRutasAeropuertos);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;

                d = ser.Deserialize<RutaAeropuerto>(resp);

                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DatosMetricas DBGetMetricasEstadisticas(string sMatricula, int iMeses)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                DatosMetricas dm = new DatosMetricas();
                FiltroEvent oLog = new FiltroEvent();
                oLog.matricula = sMatricula;
                oLog.meses = iMeses;

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.D_UrlobtieneMetricasEstadisticas);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;

                dm = ser.Deserialize<DatosMetricas>(resp);

                return dm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}