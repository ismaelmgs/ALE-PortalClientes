using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Presenter
{
    public class Dashboard_Presenter : BasePresenter<IViewDashboard>
    {
        private readonly DBDashboard oIGesCat;

        public Dashboard_Presenter(IViewDashboard oView, DBDashboard oGC) : base(oView)
        {
            oIGesCat = oGC;
        }
    }
}