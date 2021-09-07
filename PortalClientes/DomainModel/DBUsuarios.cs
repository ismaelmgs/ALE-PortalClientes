using PortalClientes.Clases;
using PortalClientes.Objetos;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NucleoBase.Core;

namespace PortalClientes.DomainModel
{
    public class DBUsuarios
    { 
        public List<Usuario> ObtieneUsuarios()
        {
            List<Usuario> ListUsers = new List<Usuario>();
            for (int i = 1; i <= 25; i++)
            {
                Usuario oUser = new Usuario();
                oUser.Correo = "Correo" + i.S();
                oUser.Nombres = "Nombres " + i.S();
                oUser.ApePat = "Paterno " + i.S();
                oUser.ApeMat = "Materno " + i.S();
                oUser.Puesto = "Puesto " + i.S();

                ListUsers.Add(oUser);
            }

            return ListUsers;
        }

        public string InsertaActualizaUsuarios(Usuario oUser)
        {
            try
            {
                TokenWS oToken = Utils.ObtieneToken;
                HorasDisponibles oHoras = new HorasDisponibles();
                oHoras.claveCliente = "FARMA";
                oHoras.tiempoVuelo = "00:50";

                var client = new RestClient("http://201.163.208.231/WSMorvelRest/ws/getavailabilityhoursfly");
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);

                request.AddJsonBody(oHoras);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;

                return resp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


    public class HorasDisponibles
    {
        public string claveCliente { set; get; }
        public string tiempoVuelo { set; get; }
    }
}