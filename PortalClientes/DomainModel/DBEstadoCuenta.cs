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
    public class DBEstadoCuenta : DBBase
    {
        public EstadoCuenta DBGetObtieneMatricuasPorUsuario(string Matricula)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
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
                oLog.claveContrato = filtro.claveContrato;  // nuevo ajustes MOGI  08/11/2022
                //oLog.claveContrato = Utils.ClaveContrato;  // Se cambió para que tome el del parametro filtro

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

        public List<RequiereIVA> ObtenerRequiereIVAEdoCuenta(FiltroSubEdoCuenta filtro)
        {
            try
            {
                DataSet ds = oDB_SP.EjecutarDS("[ClientesCasa].[spS_CC_ObtieneEstadoCuentaVersion1]",
                                               "@Matricula", filtro.matricula,
                                               "@Mes", filtro.mes,
                                               "@Anio", filtro.anio
                                               );
                DataTable dt = ds.Tables[2];

                List<RequiereIVA> req = (from DataRow dr in dt.Rows
                                          select new RequiereIVA()
                                          {
                                              requiereIVA = Convert.ToInt32(dr["RequiereIVA"])
                                          }).ToList();

                return req;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}