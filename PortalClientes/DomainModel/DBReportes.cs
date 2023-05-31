using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using NucleoBase.Core;
using PortalClientes.Clases;
using PortalClientes.Objetos;
using RestSharp;

namespace PortalClientes.DomainModel
{
    public class DBReportes : DBBase
    {
        //public DataSet GetReporteCostoXHora(int iAnio, string sMatricula)
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        SqlConnection cn = new SqlConnection(oDB_SP.sConexionSQL);

        //        cn.Open();

        //        try
        //        {
        //            SqlCommand cmd = new SqlCommand("[Principales].[spS_MXJ_ConsultarReporteGastosFijosVariables]", cn);
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add("@Anio", SqlDbType.Int);
        //            cmd.Parameters.Add("@Matricula", SqlDbType.VarChar);
        //            cmd.Parameters["@Anio"].Value = iAnio;
        //            cmd.Parameters["@Matricula"].Value = sMatricula;
        //            cmd.CommandTimeout = 0;

        //            SqlDataAdapter da = new SqlDataAdapter(cmd);
        //            da.Fill(ds);
        //            cn.Close();
        //            return ds;
        //        }
        //        catch (Exception)
        //        {
        //            throw;
        //        }
        //        finally
        //        {
        //            if (cn != null)
        //            {
        //                cn.Dispose();
        //                cn = null;
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public DataSet GetReporteCostoXHora(int iAnio, string sMatricula)
        {
            try
            {
                DataSet dsReporte = new DataSet();
                responseReporte oReporte = new responseReporte();
                oReporte = ObtenerReportePorHora(iAnio, sMatricula);

                DataTable dt1 = oReporte.oLstGenerales.ConvertListToDataTable();
                DataTable dt2 = oReporte.oLstFijos.ConvertListToDataTable();
                DataTable dt3 = oReporte.oLstVariables.ConvertListToDataTable();
                DataTable dt4 = oReporte.oLstPromedio.ConvertListToDataTable();

                dsReporte.Tables.Add(dt1);
                dsReporte.Tables.Add(dt2);
                dsReporte.Tables.Add(dt3);
                dsReporte.Tables.Add(dt4);

                return dsReporte;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public responseReporte ObtenerReportePorHora(int iAnio, string sMatricula)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                responseReporte dm = new responseReporte();
                FiltroReporte oLog = new FiltroReporte();
                oLog.anio = iAnio;
                oLog.matricula = sMatricula;
                
                Token oToken = Utils.ObtieneTokenPortalClientes;
                var client = new RestClient(Helper.D_UrlobtieneDatosReporteCostoPorHora);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;

                dm = ser.Deserialize<responseReporte>(resp);

                return dm;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}