using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PortalClientes.Clases;
using System.Net.Mail;
using System.Net;
using System.Configuration;
using System.Collections.Specialized;
using System.Text;
using System.Web.Script.Serialization;
using RestSharp;

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
            Usuario oUs = oIGesCat.DBGetValidaAccesoUsuario(oIView.sEmail, oIView.sPassword);
            UserIdentity oUI = new UserIdentity();
            oUI.sNombre = (oUs.Nombres + " " + oUs.ApePat + " " + oUs.ApeMat).Replace("  ", " ");
            oUI.sCorreo = oUs.Correo;
            oUI.sPuesto = oUs.Puesto;
            oUI.sIdioma = Utils.Idioma;
            oUI.iIdUsuario = oUs.IdUsuario;
            oUI.Clientes = oUs.Clientes;
            oUI.NombreCliente = oUs.NombreCliente;
            //oUI.sMatricula = oUs.Matriculas.Split(',').Count() > 0 ? oUs.Matriculas.Split(',')[0] : "";

            List<MatriculasContratoUsuario> olst = new List<MatriculasContratoUsuario>();
            JavaScriptSerializer ser = new JavaScriptSerializer();
            TokenWS oToken = Utils.ObtieneToken;
            requestIdUsuario oRe = new requestIdUsuario();
            oRe.idUsuario = Utils.GetIdEmpUsuario;

            var client = new RestClient(Helper.US_UrlObtieneMatriculasContratos);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", oToken.token);
            request.AddJsonBody(oRe);

            IRestResponse response = client.Execute(request);
            var resp = response.Content;
            olst = ser.Deserialize<List<MatriculasContratoUsuario>>(resp);

            foreach (var item in olst)
            {
                if (item.matriculaDefault == 1)
                {
                    Utils.MatriculaActual = item.matricula;
                    Utils.ClaveContrato = item.claveCliente;
                    Utils.NombreCliente = item.nombre;
                    oUI.sMatricula = item.matricula;
                }
            }

            if (!string.IsNullOrEmpty(oUs.Matriculas))
            {
                List<string> lsMats = new List<string>();
                string[] sMats = oUs.Matriculas.Split(',');
                if (sMats.Length > 0)
                {
                    for (int i = 0; i < sMats.Length; i++)
                    {
                        lsMats.Add(sMats[i]);
                    }
                }

                oUI.lsMatriculas = lsMats;
            }

            oIView.oU = oUI;
            oIView.oUser = oUs;
        }
    }
}