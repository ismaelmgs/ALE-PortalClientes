using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using NucleoBase.Core;
using PortalClientes.Clases;
using PortalClientes.Objetos;

namespace PortalClientes.DomainModel
{
    public class DBTransacciones : DBBase
    {
        public DataTable DBGetDetalleReferencia(string sReferencia, string sMatricula, string sAnio, string sMes)
        {
            try
            {
                return oDB_SP.EjecutarDT("[ClientesCasa].[spS_CC_ObtieneInformacionReferenciaGasto]", "@Referencia", sReferencia
                                                                                                        , "@Matricula", sMatricula
                                                                                                        , "@Mes", sAnio
                                                                                                        , "@Anio", sMes);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataSet DBGetComprobanteXRef(string sReferencia, string sMatricula)
        {
            try
            {
                return oDB_SP.EjecutarDS("[ClientesCasa].[spS_CC_ConsultaGastosReferencia]", "@NoReferencia", sReferencia
                                                                                           , "@Matricula", sMatricula);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}