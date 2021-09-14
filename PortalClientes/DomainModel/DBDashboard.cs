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
            //JavaScriptSerializer ser = new JavaScriptSerializer();
            Dashboard d = new Dashboard();
            //Filtros oLog = new Filtros();
            //oLog.filtro = matricula;

            //TokenWS oToken = Utils.ObtieneToken;

            //var client = new RestClient(Helper.D_UrlObtenerDashboard);
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("Authorization", oToken.token);
            //request.AddJsonBody(oLog);

            //IRestResponse response = client.Execute(request);
            //var resp = response.Content;
            //dashboard = ser.Deserialize<Dashboard>(resp);

            d.EstadoVuelo = "COMPLETO";

            d.Origen ="CHIHUAHUA";
            d.Destino = "CANCUN";
            d.Salida = new DateTime(2021, 1, 1,11,0,0);
            d.Llegada = new DateTime(2021, 1, 1,14,0,0);
            d.Vuelos = new List<totalesMes>();
            d.Horas = new List<totalesMes>();
            d.NMVuelos = new List<totalesMes>();
            d.Saldo = 345534.58;
            d.ultimoSaldo = 50345.37;
            d.DecalracionActual = new DateTime(2021,1,1);
            d.DecalracionVence = new DateTime(2021, 1, 31);

            return d;
        }
    }
}