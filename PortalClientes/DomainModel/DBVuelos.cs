using PortalClientes.Clases;
using PortalClientes.Objetos;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace PortalClientes.DomainModel
{
    public class DBVuelos
    {
        public Eventoss obtenerVuelos(int imeses)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                Eventoss v = new Eventoss();
                FiltroGrafica oLog = new FiltroGrafica();
                oLog.matricula = Utils.MatriculaActual;
                oLog.meses = imeses.ToString();

                //TokenWS oToken = Utils.ObtieneToken;
                Token oToken = Utils.ObtieneTokenPortalClientes;

                var client = new RestClient(Helper.D_UrlObtenerVuelos);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;
                v = ser.Deserialize<Eventoss>(resp);

                return v;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}