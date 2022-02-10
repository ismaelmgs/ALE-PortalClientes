using PortalClientes.Clases;
using PortalClientes.Objetos;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace PortalClientes.DomainModel
{
    public class DBMantenimientos
    {
        public List<Mantenimientos> obtenerMttos(int imeses)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                List<Mantenimientos> m = new List<Mantenimientos>();
                FiltroGrafica oLog = new FiltroGrafica();
                oLog.matricula = Utils.MatriculaActual;
                oLog.meses = imeses.ToString();

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.D_UrlObtenerMttos);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;
                m = ser.Deserialize<List<Mantenimientos>>(resp);

                return m;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}