using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NucleoBase.Core;
using System.Data;
using System.Web.Script.Serialization;
using PortalClientes.Clases;
using RestSharp;


namespace PortalClientes.DomainModel
{
    public class DBEstadoCuenta : System.Web.UI.Page
    {
        public EstadoCuenta DBGetObtieneMatricuasPorUsuario(string Matricula)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                EstadoCuenta ec = new EstadoCuenta();
                RequestMatricula oMat = new RequestMatricula();
                oMat.matricula = Utils.MatriculaActual;
                
                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.EC_ObtieneUltimoEdoCuenta);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oMat);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;
                ec = ser.Deserialize<EstadoCuenta>(resp);

                Session["tableRpt"] = ec;

                return ec;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<responseRepEdoCuenta> DBGetObtieneUltimosEdoCuentaMatricula(FiltroReporteEdoCuenta filtro)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                List<responseRepEdoCuenta> d = new List<responseRepEdoCuenta>();
                FiltroReporteEdoCuenta oLog = new FiltroReporteEdoCuenta();
                oLog = filtro;

                oLog.matriculaActual = Utils.MatriculaActual;

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.D_UrlconsultaReporteEdoCtaMatricula);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;

                d = ser.Deserialize<List<responseRepEdoCuenta>>(resp);

                return d;               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<responseDocumentoF> ObtenerDocumentoF(FiltroDocumento filtro)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                List<responseDocumentoF> d = new List<responseDocumentoF>();
                FiltroDocumento oLog = new FiltroDocumento();
                oLog = filtro;

                oLog.mes = 12;
                oLog.anio = 2021;

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.D_UrlObtieneFacturasContratos);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;

                d = ser.Deserialize<List<responseDocumentoF>>(resp);

                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<responseEdoCuenta> ObtenerEstadoCuenta(FiltroEdoCuenta filtro)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                List<responseEdoCuenta> d = new List<responseEdoCuenta>();
                FiltroEdoCuenta oLog = new FiltroEdoCuenta();
                oLog = filtro;

                oLog.mes = filtro.mes;
                oLog.anio = filtro.anio;
                oLog.claveContrato = Utils.ClaveContrato;

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.D_UrlObtieneEdoCuenta);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;

                d = ser.Deserialize<List<responseEdoCuenta>>(resp);

                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public SubEdoCuenta ObtenerSubEstadoCuenta(FiltroSubEdoCuenta filtro)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                SubEdoCuenta d = new SubEdoCuenta();
                FiltroSubEdoCuenta oLog = new FiltroSubEdoCuenta();
                oLog = filtro;

                oLog.mes = filtro.mes;
                oLog.anio = filtro.anio;
                oLog.matricula = Utils.MatriculaActual;

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.D_UrlObtieneSubEdoCuenta);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;

                d = ser.Deserialize<SubEdoCuenta> (resp);

                return d;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}