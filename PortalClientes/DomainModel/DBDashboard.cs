using PortalClientes.Clases;
using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NucleoBase.Core;
using RestSharp;
using System.Web.Script.Serialization;

namespace PortalClientes.DomainModel
{
    public class DBDashboard
    {
        public Dashboard ObtenerDashboard()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Dashboard d = new Dashboard();
            FiltroMat oLog = new FiltroMat();
            oLog.matriculaActual = Utils.MatriculaActual;
            oLog.idioma = Utils.Idioma;

            TokenWS oToken = Utils.ObtieneToken;

            var client = new RestClient(Helper.D_UrlObtenerDashboard);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", oToken.token);
            request.AddJsonBody(oLog);

            IRestResponse response = client.Execute(request);
            var resp = response.Content;
            d = ser.Deserialize<Dashboard>(resp);

            return d;
        }

        public List<responseGraficaGastos> ObtenerGastos(FiltroGraficaGastos filtro)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
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
    }
}