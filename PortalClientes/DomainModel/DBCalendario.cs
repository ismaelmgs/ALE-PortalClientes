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
    public class DBCalendario : System.Web.UI.Page
    {
        public List<Appointment> ObtenerCalendario(FiltroEvent ev)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                List<DatosCalendario> d = new List<DatosCalendario>();
                List<Appointment> dc = new List<Appointment>();
                FiltroEvent oLog = new FiltroEvent();
                oLog = ev;
                oLog.matricula = "XA-CHY";// Utils.MatriculaActual;

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.D_UrlObtenerEventosCalendario);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;
                d = ser.Deserialize<List<DatosCalendario>>(resp);

                Session["SSEventos"] = d;
                Session["tableRpt"] = resp;

                foreach (var item in d)
                {
                    Appointment data = new Appointment();
                    data.ID = item.legId.S();
                    data.StartTime = item.FechaInicio;
                    data.EndTime = item.FechaFin;
                    data.Description = item.recType == "M" ? "Mantenimiento" : "Vuelo";
                    data.Location = item.origen + " - " + item.destino;
                    data.Subject = item.requestorName;
                    data.Status = 1;
                    data.AllDay = false;
                    data.EventType = item.recType;
                    data.Label = 1;

                    dc.Add(data);
                }

                return dc;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}