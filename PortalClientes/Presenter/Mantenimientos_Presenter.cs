using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Presenter
{
    public class Mantenimiemntos_Presenter : BasePresenter<iViewMantenimientos>
    {
        private readonly DBMantenimientos oIGesCat;

        public Mantenimiemntos_Presenter(iViewMantenimientos _oIView, DBMantenimientos oGC) : base(_oIView)
        {
            oIGesCat = oGC;

            oIView.eSearchObj += SearchObj_Presenter;
        }

        protected override void SearchObj_Presenter(object sender, EventArgs e)
        {
            //oIView.cargarMantenimientos(oIGesCat.obtenerMttos(oIView.iMeses));
            oIView.cargarMantenimientosDB(oIGesCat.GetMantenimientos(oIView.iMeses));
        }
    }
}