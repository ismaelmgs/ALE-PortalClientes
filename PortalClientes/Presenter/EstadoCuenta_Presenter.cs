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
        }

        protected override void SearchObj_Presenter(object sender, EventArgs e)
        {
            oIView.LlenaEstadoCuenta(oIGesCat.DBGetObtieneMatricuasPorUsuario(Utils.MatriculaActual));
            oIView.LlenaTableEdoCuenta(oIGesCat.DBGetObtieneUltimosEdoCuentaMatricula());
        }

        protected void eSearchObjDocs_Presenter(object sender, EventArgs e)
        {
            FiltroDocumento f = new FiltroDocumento();
            f.anio = oIView.iAnio;
            f.mes = oIView.iMes;
            f.matricula = Utils.MatriculaActual;

            oIView.LlenaDocsEdoCuenta(oIGesCat.ObtenerDocumentoF(f));
        }
    }
}