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
        public Dashboard ObtenerDashboard(string matricula)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Dashboard d = new Dashboard();
            Filtros oLog = new Filtros();
            oLog.filtro = Utils.MatriculaActual;

            TokenWS oToken = Utils.ObtieneToken;

            var client = new RestClient(Helper.D_UrlObtenerDashboard);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", oToken.token);
            request.AddJsonBody(oLog);

            IRestResponse response = client.Execute(request);
            var resp = response.Content;
            d = ser.Deserialize<Dashboard>(resp);

            return d;
        }
    }
}