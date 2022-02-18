using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Presenter
{
    public class EmailRecoveryPass_Presenter : BasePresenter<IViewEmailRecoverPass>
    {
        private readonly DBLogin oIGesCat;

        public EmailRecoveryPass_Presenter(IViewEmailRecoverPass oView, DBLogin oCI)
            : base(oView)
        {
            oIGesCat = oCI;
            oIView.eValidateObj += eValidateObj_Presenter;
        }

        protected void eValidateObj_Presenter(object sender, EventArgs e)
        {
            oIView.isValidUser(oIGesCat.ValidarUsuario(oIView.sEmail));
        }
    }
}