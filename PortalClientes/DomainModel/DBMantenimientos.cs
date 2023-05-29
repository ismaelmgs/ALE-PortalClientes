using PortalClientes.Clases;
using PortalClientes.Objetos;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace PortalClientes.DomainModel
{
    public class DBMantenimientos : DBBase
    {
        public List<Mantenimientos> obtenerMttos(int imeses)
        {
            try
            {
                JavaScriptSerializer ser = new JavaScriptSerializer();
                ser.MaxJsonLength = 500000000;
                List<Mantenimientos> m = new List<Mantenimientos>();
                FiltroGrafica oLog = new FiltroGrafica();
                oLog.matricula = Utils.MatriculaActual;
                oLog.meses = imeses.ToString();

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.D_UrlObtenerMttos);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;
                m = ser.Deserialize<List<Mantenimientos>>(resp);

                return m;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetMantenimientos(int meses)
        {
            try
            {
                DataTable ds = new DataTable();
                SqlConnection cn = new SqlConnection(oDB_SP.sConexionSQL);

                cn.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("[PortalClientes].[spS_PC_ObtieneEventosMantenimientos]", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@matricula", SqlDbType.VarChar);
                    cmd.Parameters.Add("@meses", SqlDbType.VarChar);
                    cmd.Parameters["@matricula"].Value = Utils.MatriculaActual;
                    cmd.Parameters["@meses"].Value = meses.ToString();
                    cmd.CommandTimeout = 0;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    cn.Close();
                    return ds;
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (cn != null)
                    {
                        cn.Dispose();
                        cn = null;
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}