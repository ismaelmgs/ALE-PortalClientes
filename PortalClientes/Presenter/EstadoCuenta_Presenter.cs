using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortalClientes.Clases;
using PortalClientes.Objetos;

namespace PortalClientes.Presenter
{
    public class EstadoCuenta_Presenter : BasePresenter<IViewEstadoCuenta>
    {
        private readonly DBEstadoCuenta oIGesCat;

        public EstadoCuenta_Presenter(IViewEstadoCuenta oView, DBEstadoCuenta oGC) : base(oView)
        {
            oIGesCat = oGC;

            oIView.eSearchObjDocs += eSearchObjDocs_Presenter;
            oIView.eSearchEdoObj += eSearchEdoObj_Presenter;
        }

        protected override void SearchObj_Presenter(object sender, EventArgs e)
        {
            oIView.LlenaEstadoCuenta(oIGesCat.DBGetObtieneMatricuasPorUsuario(Utils.MatriculaActual));
            FiltroReporteEdoCuenta F = new FiltroReporteEdoCuenta(); 
            oIView.LlenaTableEdoCuenta(oIGesCat.DBGetObtieneUltimosEdoCuentaMatricula(F));
        }

        protected void eSearchObjDocs_Presenter(object sender, EventArgs e)
        {
            FiltroDocumento f = new FiltroDocumento();
            f.anio = oIView.iAnio;
            f.mes = oIView.iMes;
            f.contrato = Utils.ClaveContrato;

            oIView.LlenaDocsEdoCuenta(oIGesCat.ObtenerDocumentoF(f));
        }

        protected void eSearchEdoObj_Presenter(object sender, EventArgs e)
        {
            FiltroEdoCuenta F = new FiltroEdoCuenta();
            F.anio = oIView.iAnio;
            F.mes = oIView.iMes;
            if (Utils.ClaveContrato == "RASSI")
            {
                F.claveContrato = "RAS7X";
                //F.claveContrato = Utils.ClaveContrato;
            }
            else
                F.claveContrato = Utils.ClaveContrato;
            FiltroSubEdoCuenta Fsub = new FiltroSubEdoCuenta();
            Fsub.anio = oIView.iAnio;
            Fsub.mes = oIView.iMes;
            oIView.LlenarEdoCuenta(oIGesCat.ObtenerEstadoCuenta(F));
            oIView.LlenarSubEdoCuenta(oIGesCat.ObtenerSubEstadoCuenta(Fsub));
            oIView.LlenarRequiereIVAEdoCuenta(oIGesCat.ObtenerRequiereIVAEdoCuenta(Fsub));

            //oIView.LlenaDocsEdoCuenta(oIGesCat.ObtenerDocumentoF(f));
        }
    }
}