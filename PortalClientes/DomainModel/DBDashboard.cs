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
            Dashboard d = new Dashboard();
            FiltroGraficaGastos oLog = new FiltroGraficaGastos();
            oLog = filtro;
            oLog.matricula = Utils.MatriculaActual;
            oLog.idioma = Utils.Idioma;

            TokenWS oToken = Utils.ObtieneToken;

            var client = new RestClient(Helper.D_UrlObtenerDashboard);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", oToken.token);
            request.AddJsonBody(oLog);

            //IRestResponse response = client.Execute(request);
            //var resp = response.Content;
            //d = ser.Deserialize<Dashboard>(resp);

            //return d;

            List<responseGraficaGastos> lrg = new List<responseGraficaGastos>();

            var item = new responseGraficaGastos();
            item.rubroEsp = "Tripulacion";
            item.rubroEng = "Crew";
            item.totalMXN = 330000.00;
            item.totalUSD = 10000.00;
            lrg.Add(item);

            item = new responseGraficaGastos();
            item.rubroEsp = "Capital";
            item.rubroEng = "Capital";
            item.totalMXN = 150000.00;
            item.totalUSD = 12000.00;
            lrg.Add(item);

            item = new responseGraficaGastos();
            item.rubroEsp = "Combustible";
            item.rubroEng = "Fuel";
            item.totalMXN = 33000.00;
            item.totalUSD = 15000.00;
            lrg.Add(item);

            item = new responseGraficaGastos();
            item.rubroEsp = "DIVERSOS";
            item.rubroEng = "DIVERSOS";
            item.totalMXN = 120000.00;
            item.totalUSD = 6000.00;
            lrg.Add(item);


            return lrg;
        }
    }
}