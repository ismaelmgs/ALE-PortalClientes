using PortalClientes.Clases;
using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NucleoBase.Core;
using RestSharp;
using System.Web.Script.Serialization;
using System.Data;
using NucleoBase.BaseDeDatos;

namespace PortalClientes.DomainModel
{
    public class DBUsuarios
    {
        public BD_SP oDB_SP = new BD_SP();

        public List<Usuario> ObtieneUsuarios()
        {
            try
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
            catch (Exception)
            {

                throw;
            }
        }

        public string InsertaActualizaUsuarios(Usuario oUser)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                TokenWS oToken = Utils.ObtieneToken;

                requestInsertaUsuario oReq = new requestInsertaUsuario();
                oReq.correo = oUser.Correo;
                oReq.pass = oUser.Pass;
                oReq.nombres = oUser.Nombres;
                oReq.apePat = oUser.ApePat;
                oReq.apeMat = oUser.ApeMat;
                oReq.puesto = oUser.Puesto;
                oReq.telefonoMovil = oUser.TelefonoMovil;
                oReq.telefonoOficina = oUser.TelefonoOficina;
                oReq.correoSecundario = oUser.CorreoSecundario;
                oReq.usuarioCreacion = "i.morato";


                var client = new RestClient(Helper.US_UrlInsertaUsuario);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oReq);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;

                return resp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Usuario> ObtieneUsuariosFiltros(string sFiltro)
        {
            try
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
            catch (Exception)
            {

                throw;
            }
        }

        // MATRICULAS
        public List<Matriculas> ObtieneMatriculas()
        {
            try
            {
                List<Matriculas> olstMats = new List<Matriculas>();
                JavaScriptSerializer ser = new JavaScriptSerializer();
                TokenWS oToken = Utils.ObtieneToken;
                requestOpcion oRe = new requestOpcion();
                oRe.opcion = 1;

                var client = new RestClient(Helper.US_UrlConsultaMatriculas);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oRe);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;
                olstMats = ser.Deserialize<List<Matriculas>>(resp);
                
                return olstMats;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Matriculas> DBGetObtieneMatriculasPorUsuario(int iidUsuario)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                List<Matriculas> oMU = new List<Matriculas>();
                FiltroMatUsuario oLog = new FiltroMatUsuario();
                oLog.IdUsuario = iidUsuario;

                TokenWS oToken = Utils.ObtieneToken;
                var client = new RestClient(Helper.D_UrlObtenerMatriculasPorUsuario);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;
                oMU = ser.Deserialize<List<Matriculas>>(resp);

                return oMU;


                //oDB_SP.sConexionSQL = "Data Source=192.168.1.219;Initial Catalog=MexJet360;User ID=sa;Password=SYS.*2015%SQL";

                //return oDB_SP.EjecutarDT("[PortalClientes].[spS_PC_ObtieneMatriculasPorUsuario]", "@IdUsuario", iidUsuario).AsEnumerable().Select(r => new Matriculas()
                //{
                //    IdAeronave = r["IdAeroave"].S().I(),
                //    Serie = r["Serie"].S(),
                //    Matricula = r["Matricula"].S(),
                //    GrupoModelo = r["Descripcion"].S(),
                //}).ToList();
            }
            catch (Exception)
            {

                throw;
            } 
        }
        
        public responseCodigoMensaje DesvinculaUsuariosMatriculas(int iIdUsuario)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                responseCodigoMensaje oCodigo = new responseCodigoMensaje();

                requestUsuarioOpcion oReq = new requestUsuarioOpcion();
                oReq.opcion = 1;
                oReq.idUsuario = iIdUsuario;

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.US_UrlDesvinculaUsuarioMats);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oReq);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;
                oCodigo = ser.Deserialize<responseCodigoMensaje>(resp);

                return oCodigo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public requestIdUsuario RelacionaUsuarioMatriculas(int iIdUsuario, List<int> oLstMats)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                requestIdUsuario oReq = new requestIdUsuario();
                
                foreach (int iAeronave in oLstMats)
                {
                    requestUsuarioMatricula oReqU = new requestUsuarioMatricula();
                    oReqU.idUsuario = iIdUsuario;
                    oReqU.idMatricula = iAeronave;
                    
                    TokenWS oToken = Utils.ObtieneToken;
                    var client = new RestClient(Helper.US_UrlRelacionaUsuarioMats);
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("Authorization", oToken.token);
                    request.AddJsonBody(oReqU);
                    
                    IRestResponse response = client.Execute(request);
                    var resp = response.Content;

                    oReq = ser.Deserialize<requestIdUsuario>(resp);
                }

                return oReq;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // MODULOS
        public List<ModulosUsuario> ObtieneModulos()
        {
            try
            {
                List<ModulosUsuario> olstMods = new List<ModulosUsuario>();
                JavaScriptSerializer ser = new JavaScriptSerializer();
                TokenWS oToken = Utils.ObtieneToken;

                requestIdUsuario oRe = new requestIdUsuario();
                oRe.idUsuario = 0;

                var client = new RestClient(Helper.US_UrlObtieneModPorUser);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oRe);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;
                olstMods = ser.Deserialize<List<ModulosUsuario>>(resp);

                return olstMods;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ModulosUsuario> ObtieneModulosPorUsuario(int iIdUsuario)
        {
            try
            {
                List<ModulosUsuario> olstMods = new List<ModulosUsuario>();
                JavaScriptSerializer ser = new JavaScriptSerializer();
                TokenWS oToken = Utils.ObtieneToken;

                requestIdUsuario oRe = new requestIdUsuario();
                oRe.idUsuario = iIdUsuario;

                var client = new RestClient(Helper.US_UrlObtieneModPorUser);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oRe);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;
                olstMods = ser.Deserialize<List<ModulosUsuario>>(resp);

                return olstMods;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ModulosUsuario> RelacionaModulosUsuario(int iIdUsuario, string sModulos)
        {
            try
            {
                List<ModulosUsuario> olstMods = new List<ModulosUsuario>();
                JavaScriptSerializer ser = new JavaScriptSerializer();
                TokenWS oToken = Utils.ObtieneToken;

                requestModulosUsuario oRe = new requestModulosUsuario();
                oRe.idUsuario = iIdUsuario;
                oRe.modulos = sModulos;

                var client = new RestClient(Helper.US_UrlRelacionaUsuarioMods);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oRe);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;
                olstMods = ser.Deserialize<List<ModulosUsuario>>(resp);

                return olstMods;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ModulosUsuario> ClonaPermisosDeUsuarioUsuario(int iIdUsuarioOrigen, int iIdUsuarioDestino)
        {
            try
            {
                List<ModulosUsuario> olstMods = new List<ModulosUsuario>();
                JavaScriptSerializer ser = new JavaScriptSerializer();
                TokenWS oToken = Utils.ObtieneToken;

                requestUsuarioUsuario oRe = new requestUsuarioUsuario();
                oRe.idUsuarioOrigen = iIdUsuarioOrigen;
                oRe.idUsuarioDestino = iIdUsuarioDestino;

                var client = new RestClient(Helper.US_UrlClonaPermisosUserUser);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oRe);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;
                olstMods = ser.Deserialize<List<ModulosUsuario>>(resp);

                return olstMods;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}