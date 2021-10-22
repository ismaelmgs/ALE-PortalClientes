using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RestSharp;
using System.Web.Script.Serialization;
using PortalClientes.Clases;
using PortalClientes.Objetos;
using NucleoBase.BaseDeDatos;
using System.Data;
using NucleoBase.Core;

namespace PortalClientes.DomainModel
{
    public class DBMetricasEstatics
    {
        public BD_SP oDB_SP = new BD_SP();

        public List<responseGraficaGastos> ObtenerGastos(FiltroGraficaGastos filtro)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            ser.MaxJsonLength = 500000000;
            List<responseGraficaGastos> d = new List<responseGraficaGastos>();
            FiltroGraficaGastos oLog = new FiltroGraficaGastos();
            oLog = filtro;
            oLog.matricula = Utils.MatriculaActual;
            oLog.idioma = Utils.Idioma;

            TokenWS oToken = Utils.ObtieneToken;

            var client = new RestClient(Helper.D_UrlObbtenerGastoRubros);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", oToken.token);
            request.AddJsonBody(oLog);

            IRestResponse response = client.Execute(request);
            var resp = response.Content;

            d = ser.Deserialize<List<responseGraficaGastos>>(resp);

            return d;
        }

        public List<DatosMetricas> DBGetMetricasEstadisticas(string sMatricula, int iMeses)
        {
            oDB_SP.sConexionSQL = "Data Source=192.168.1.219;Initial Catalog=MexJet360;User ID=sa;Password=SYS.*2015%SQL";

            var res = oDB_SP.EjecutarDT("[PortalClientes].[spS_PC_ObtieneMetricasEstadisticas]", "@matricula", sMatricula, "@meses", iMeses);

            if(res.Rows.Count > 0)
            {
                return res.AsEnumerable().Select(r => new DatosMetricas()
                {
                    GastoTotalFijoMXN = r["GastoTotalFijoMXN"].S().Db(),
                    GastoTotalFijoUSD = r["GastoTotalFijoUSD"].S().Db(),
                    GastoTotalVarMXN = r["GastoTotalVarMXN"].S().Db(),
                    GastoTotalVarUSD = r["GastoTotalVarUSD"].S().Db(),
                    NumeroVuelos = r["NumeroVuelos"].S().I(),
                    TotalPasajeros = r["TotalPasajeros"].S().I(),
                    HorasVoladas = r["HorasVoladas"].S().Db(),
                    CostoPorHoraMXN = r["CostoPorHoraMXN"].S().Db(),
                    CostoPorHoraUSD = r["CostoPorHoraUSD"].S().Db(),
                    CostoPorMillaMXN = r["CostoPorMillaMXN"].S().Db(),
                    CostoPorMillaUSD = r["CostoPorMillaUSD"].S().Db(),
                    TiempoPromedio = r["TiempoPromedio"].S(),
                    DistanciaPromedio = r["DistanciaPromedio"].S().Db(),
                    PaxPromedio = r["PaxPromedio"].S().Db(),
                    PromedioMXN = r["PromedioMXN"].S().Db(),
                    PromedioUSD = r["PromedioUSD"].S().Db(),
                }).ToList();
            }
            else
            {
                return null;
            }
            
        }
    }
}