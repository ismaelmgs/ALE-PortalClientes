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
    public class DBUsuarios
    { 
        public List<Usuario> ObtieneUsuarios()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<Usuario> ListUsers = new List<Usuario>();

            TokenWS oToken = Utils.ObtieneToken;
            
            var client = new RestClient(Helper.US_UrlObtieneUsuarios);
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", oToken.token);

            IRestResponse response = client.Execute(request);
            var resp = response.Content;
            ListUsers = ser.Deserialize<List<Usuario>>(resp);

            return ListUsers;
        }

        public string InsertaActualizaUsuarios(Usuario oUser)
        {
            try
            {
                //TokenWS oToken = Utils.ObtieneToken;
                //HorasDisponibles oHoras = new HorasDisponibles();
                //oHoras.claveCliente = "FARMA";
                //oHoras.tiempoVuelo = "00:50";

                //var client = new RestClient("http://201.163.208.231/WSMorvelRest/ws/getavailabilityhoursfly");
                //var request = new RestRequest(Method.POST);
                //request.AddHeader("Authorization", oToken.token);

                //request.AddJsonBody(oHoras);

                //IRestResponse response = client.Execute(request);
                //var resp = response.Content;

                return string.Empty; //resp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuario> ObtieneUsuariosFiltros(string sFiltro)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<Usuario> oUser = new List<Usuario>();
            Filtros oLog = new Filtros();
            oLog.filtro = sFiltro;

            TokenWS oToken = Utils.ObtieneToken;

            var client = new RestClient(Helper.US_UrlObtieneUsuariosFiltros);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", oToken.token);
            request.AddJsonBody(oLog);

            IRestResponse response = client.Execute(request);
            var resp = response.Content;
            oUser = ser.Deserialize<List<Usuario>>(resp);

            return oUser;
        }
    }

}