using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Presenter
{
    public class Login_Presenter : BasePresenter<IViewLogin>
    {
        private readonly DBLogin oIGesCat;

        public Login_Presenter(IViewLogin oView, DBLogin oCI)
            : base(oView)
        {
            oIGesCat = oCI;
        }

        protected override void ObjSelected_Presenter(object sender, EventArgs e)
        {
            oIView.oUser = oIGesCat.DBGetValidaAccesoUsuario(oIView.sEmail, oIView.sPassword);
        }
    }
}