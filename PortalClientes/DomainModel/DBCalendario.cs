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
    public class DBCalendario
    {
        public List<Appointment> ObtenerCalendario(FiltroEvent ev)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<Appointment> d = new List<Appointment>();
            FiltroEvent oLog = new FiltroEvent();
            oLog = ev;
            oLog.matricula = Utils.MatriculaActual;

            TokenWS oToken = Utils.ObtieneToken;

            var client = new RestClient(Helper.D_UrlObtenerEventosCalendario);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", oToken.token);
            request.AddJsonBody(oLog);

            IRestResponse response = client.Execute(request);
            var resp = response.Content;
            d = ser.Deserialize<List<Appointment>>(resp);

            return d;
        }
    }
}