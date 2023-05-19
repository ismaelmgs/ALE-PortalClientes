using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using NucleoBase.Core;

namespace PortalClientes.DomainModel
{
    public class DBReportes : DBBase
    {
        public DataSet GetReporteCostoXHora(int iAnio, string sMatricula)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlConnection cn = new SqlConnection(oDB_SP.sConexionSQL);

                cn.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand("[Principales].[spS_MXJ_ConsultarReporteGastosFijosVariables]", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Anio", SqlDbType.Int);
                    cmd.Parameters.Add("@Matricula", SqlDbType.VarChar);
                    cmd.Parameters["@Anio"].Value = iAnio;
                    cmd.Parameters["@Matricula"].Value = sMatricula;
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