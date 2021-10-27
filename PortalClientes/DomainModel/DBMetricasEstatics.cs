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

        public List<responseGraficaGastos> ObtenerGastosProveedor(FiltroGraficaGastos filtro)
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

        public List<responseGraficaGastos> ObtenerGastosAeropuerto(FiltroGraficaGastos filtro)
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

        public List<responseGraficaGastos> ObtenerDuracionVuelos(FiltroGraficaGastos filtro)
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

        public DatosMetricas DBGetMetricasEstadisticas(string sMatricula, int iMeses)
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
    }
}