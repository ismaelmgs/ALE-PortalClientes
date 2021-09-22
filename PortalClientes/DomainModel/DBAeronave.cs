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
    public class DBAeronave
    {
        public Aeronave ObtenerAeronave()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            Aeronave a = new Aeronave();
            FiltroMat oLog = new FiltroMat();
            oLog.matriculaActual = Utils.MatriculaActual;

            TokenWS oToken = Utils.ObtieneToken;

            var client = new RestClient(Helper.D_UrlObtenerAeronave);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", oToken.token);
            request.AddJsonBody(oLog);

            IRestResponse response = client.Execute(request);
            var resp = response.Content;
            a = ser.Deserialize<Aeronave>(resp);

            //a.nombreAeronave = "Infinity 200-F";
            //a.Fabricante = "EpicGames";
            //a.Anio = "2021";
            //a.Modelo = "200-F jet";
            //a.noRegistro = "345-g-33";
            //a.noSerie = "3449-f9997-38";
            //a.noPasajeros = 22;
            //a.noTripulacion = 2;
            //a.dimencionesExteriores = "25";
            //a.dimencionesInteriores = "20";
            //a.maxGasolina = 20000;
            //a.minGasolina = 1000;
            //a.velocidadCrucero = 880;
            //a.altitudMaxima = 15000;
            //a.tipoGasolina = "Premium";
            //a.Rendimiento = 120;
            //a.Distancia = 25000;
            //a.Peso = 120;

            return a;
        }
    }
}