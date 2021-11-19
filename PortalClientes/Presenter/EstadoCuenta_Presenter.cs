using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortalClientes.Clases;

namespace PortalClientes.Presenter
{
    public class EstadoCuenta_Presenter : BasePresenter<IViewEstadoCuenta>
    {
        private readonly DBEstadoCuenta oIGesCat;

        public EstadoCuenta_Presenter(IViewEstadoCuenta oView, DBEstadoCuenta oGC) : base(oView)
        {
            oIGesCat = oGC;

            
        }

        protected override void SearchObj_Presenter(object sender, EventArgs e)
        {
            oIView.LlenaEstadoCuenta(oIGesCat.DBGetObtieneMatricuasPorUsuario(Utils.MatriculaActual));
        }
    }
}