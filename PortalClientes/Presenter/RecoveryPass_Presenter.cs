using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Presenter
{
    public class RecoveryPass_Presenter : BasePresenter<IViewRecoveryPass>
    {
        private readonly DBLogin oIGesCat;

        public RecoveryPass_Presenter(IViewRecoveryPass oView, DBLogin oCI)
            : base(oView)
        {
            oIGesCat = oCI;
        }

        protected override void NewObj_Presenter(object sender, EventArgs e)
        {
            oIView.requestResponse(oIGesCat.ActualizaUsuarios(oIView.sEmail, oIView.sPassword, oIView.iTipoActualizacion));
        }
    }
}