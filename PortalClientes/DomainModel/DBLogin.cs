using PortalClientes.Objetos;
using PortalClientes.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using RestSharp;

namespace PortalClientes.DomainModel
{
    public class DBLogin
    {
        public Usuario DBGetValidaAccesoUsuario(string sUsuario, string sPassword)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                List<Usuario> oUser = new List<Usuario>();
                Login oLog = new Login();
                oLog.email = sUsuario;
                oLog.password = sPassword;

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.UrlLogin);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;
                oUser = ser.Deserialize<List<Usuario>>(resp);

                return oUser.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public responceAct ActualizaUsuarios(string sEmail, string spass, int tipoActualizacion)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                TokenWS oToken = Utils.ObtieneToken;

                responceAct res = new responceAct();

                requestActualizaUsuario oReq = new requestActualizaUsuario();
                oReq.email = sEmail;
                oReq.nombre = spass;
                oReq.opcion = tipoActualizacion;


                var client = new RestClient(Helper.US_UrlActualizaUsuario);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oReq);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;
                res = ser.Deserialize<responceAct>(resp);

                return res;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public string ValidarUsuario(string sEmail)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                nombreUsuario n = new nombreUsuario();
                FiltroEmail oLog = new FiltroEmail();
                oLog.email = sEmail;

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.US_UrlObtieneValidacionUusario);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;
                n = ser.Deserialize<nombreUsuario>(resp);

                return n.nombre;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<Parametros> getParameters()
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                List<Parametros> p = new List<Parametros>();

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.US_UrlObtieneParametros);
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", oToken.token);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;
                p = ser.Deserialize<List<Parametros>>(resp);

                return p;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}