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
    public class DBMapaFlota
    {
        public MapaFlota obtenerFlota(int imeses, string sMatricula)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                MapaFlota v = new MapaFlota();
                FiltroEvent oLog = new FiltroEvent();
                oLog.matricula = sMatricula;
                oLog.meses = imeses;

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.D_UrlObtenerMapaFlota);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;
                v = ser.Deserialize<MapaFlota>(resp);

                return v;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}