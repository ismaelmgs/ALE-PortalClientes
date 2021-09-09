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
    }
}