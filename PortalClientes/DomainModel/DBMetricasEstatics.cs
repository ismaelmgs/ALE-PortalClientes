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
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
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

                oLog.matricula = "XA-CHY";
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
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
            }

        }

        public List<responseGraficaCategorias> obtenerCategoriasPeriodos(FiltroEvent filtro)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                List<responseGraficaCategorias> d = new List<responseGraficaCategorias>();
                FiltroEvent oLog = new FiltroEvent();
                oLog = filtro;
                oLog.matricula = Utils.MatriculaActual;

                oLog.matricula = "XA-ALE";
                oLog.meses = 1;

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
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                throw;
            }

        }
    }
}