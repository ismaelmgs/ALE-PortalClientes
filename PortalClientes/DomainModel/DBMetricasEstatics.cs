using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using System.Web.Script.Serialization;
using PortalClientes.Clases;
using PortalClientes.Objetos;

namespace PortalClientes.DomainModel
{
    public class DBMetricasEstatics
    {
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
    }
}