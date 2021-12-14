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
            catch (Exception)
            {

                throw;
            }
        }

        public List<responseRepEdoCuenta> DBGetObtieneUltimosEdoCuentaMatricula()
        {
            try
            {
                List<responseRepEdoCuenta> ols = new List<responseRepEdoCuenta>();

                oDB_SP.sConexionSQL = "Data Source=192.168.1.219;Initial Catalog=MexJet360;User ID=sa;Password=SYS.*2015%SQL";
                DataSet ds = oDB_SP.EjecutarDS("[PortalClientes].[spS_PC_ObtieneReportesEstadosDeCuentaMatricula]", "@Matricula", Utils.MatriculaActual);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    responseRepEdoCuenta oRes = new responseRepEdoCuenta();
                    oRes.mes = row["Mes"].S().I();
                    oRes.anio = row["Anio"].S().I();
                    oRes.saldoAnteriorMXN = row["SaldoAnteriorMXN"].S().D();
                    oRes.pagosCreditoMXN = row["PagosCreditoMXN"].S().D();
                    oRes.nuevosCargosMXN = row["NuevosCargosMXN"].S().D();
                    oRes.saldoActualMXN = row["SaldoActualMXN"].S().D();
                    oRes.saldoAnteriorUSD = row["SaldoAnteriorUSD"].S().D();
                    oRes.pagosCreditoUSD = row["PagosCreditoUSD"].S().D();
                    oRes.nuevosCargosUSD = row["NuevosCargosUSD"].S().D();
                    oRes.saldoActualUSD = row["SaldoActualUSD"].S().D();
                    oRes.docF = row["DocF"].S().I();

                    foreach (DataRow row2 in ds.Tables[1].Rows)
                    {
                        DetalleRepEdoCuenta oDet = new DetalleRepEdoCuenta();
                        oDet.mes = row2["Mes"].S().I();
                        oDet.anio = row2["Anio"].S().I();
                        oDet.tipoMoneda = row2["TipoMoneda"].S();
                        oDet.fecha = row2["Fecha"].S();
                        oDet.noReferencia = row2["NoReferencia"].S();
                        oDet.tipoGasto = row2["TipoGasto"].S();
                        oDet.concepto = row2["Concepto"].S();
                        oDet.rubro = row2["Rubro"].S();
                        oDet.detalle = row2["Detalle"].S();
                        oDet.proveedor = row2["Proveedor"].S();
                        oDet.importe = row2["Importe"].S().D();

                        oRes.olsDetalle.Add(oDet);
                    }

                    ols.Add(oRes);
                }

                return ols;
            }
            catch (Exception e)
            {

                throw;
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
                oLog.matricula = Utils.MatriculaActual;

                oLog.matricula = "XA-CHY";
                oLog.mes = "3";

                TokenWS oToken = Utils.ObtieneToken;

                var client = new RestClient(Helper.D_UrlObbtenerGastoProveedor); /*FALTA URL DE DOCF*/
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oLog);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;

                d = ser.Deserialize<List<responseDocumentoF>>(resp);

                return d;
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}