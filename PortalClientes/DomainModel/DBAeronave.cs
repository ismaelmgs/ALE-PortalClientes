using PortalClientes.Clases;
using PortalClientes.Objetos;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace PortalClientes.DomainModel
{
    public class DBAeronave : DBBase
    {
        public Aeronave ObtenerAeronave()
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
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


                List<FotoAeronave> ls = new List<FotoAeronave>();
                // Carga de Imagenes
                var clientImg = new RestClient(Helper.D_UrlObtenerImagenesAeronave);
                var requestImg = new RestRequest(Method.POST);
                requestImg.AddHeader("Authorization", oToken.token);
                requestImg.AddJsonBody(oLog);

                IRestResponse responseImg = clientImg.Execute(requestImg);
                var respImg = responseImg.Content;

                ls = ser.Deserialize<List<FotoAeronave>>(respImg);

                DataSet ds = oDB_SP.EjecutarDS("[PortalClientes].[spS_PC_ObtenerPDFAeronavePorMatricula]", "@matriculaActual", oLog.matriculaActual);
                DataTable dt = ds.Tables[0];

                 List<FotoAeronave> ls2 = (from DataRow dr in dt.Rows
                       select new FotoAeronave()
                       {
                           IdImagen = Convert.ToInt32(dr["IdImagen"]),
                           NombreImagen = dr["NombreImagen"].ToString(),
                           Extension = dr["Extension"].ToString(),
                           Imagen = dr["Imagen"].ToString(),
                           Descripcion = dr["Descripcion"].ToString()
                       }).ToList();

                foreach(var item in ls2)
                {
                    ls.Add(item);
                }

                a.Imagenes = ls;
                return a;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public FotoAeronave ObtenerDoc(int id)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                FotoAeronave a = new FotoAeronave();
                FiltroImg oLog = new FiltroImg();
                oLog.idImagen = id;

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.D_UrlObtenerDocs);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;
                a = ser.Deserialize<FotoAeronave>(resp);

                return a;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}