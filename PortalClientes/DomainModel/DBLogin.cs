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

        public bool ValidarUsuario(string sEmail)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                List<Usuario> oUser = new List<Usuario>();
                FiltroEmail oLog = new FiltroEmail();
                oLog.email = sEmail;

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.US_UrlObtieneValidacionUusario);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;
                oUser = ser.Deserialize<List<Usuario>>(resp);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}