using PortalClientes.DomainModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PortalClientes.Presenter
{
    public class Reportes_Presenter
    {
        //public readonly DBReportes oIGestCat;


        public DataSet GetCostoxHora(int iAnio, string sMatricula)
        {
            DataSet ds = new DataSet();
            DBReportes db = new DBReportes();
            ds = db.GetReporteCostoXHora(iAnio, sMatricula);
            return ds;
        }
    }
}