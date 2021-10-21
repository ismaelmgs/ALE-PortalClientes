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
    public class DBTripulacion
    {
        public List<EventosPiloto> ObtenerEventos(int meses)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<EventosPiloto> ep = new List<EventosPiloto>();
            FiltroEvent oLog = new FiltroEvent();
            oLog.matricula = Utils.MatriculaActual;
            oLog.meses = meses;

            TokenWS oToken = Utils.ObtieneToken;

            var client = new RestClient(Helper.D_UrlObbtenerEventosPiloto);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", oToken.token);
            request.AddJsonBody(oLog);

            IRestResponse response = client.Execute(request);
            var resp = response.Content;
            ep = ser.Deserialize<List<EventosPiloto>>(resp);

            return ep;
        }

        public List<Piloto> ObtenerPilotos()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<Piloto> p = new List<Piloto>();
            FiltroPilotos oLog = new FiltroPilotos();
            oLog.matricula = Utils.MatriculaActual;

            TokenWS oToken = Utils.ObtieneToken;

            var client = new RestClient(Helper.D_UrlObtenerPilotos);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", oToken.token);
            request.AddJsonBody(oLog);

            IRestResponse response = client.Execute(request);
            var resp = response.Content;
            p = ser.Deserialize<List<Piloto>>(resp);

            return p;
        }

    }
}