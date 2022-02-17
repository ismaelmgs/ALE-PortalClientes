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
            oUI.sMatricula = oUs.Matriculas.Split(',').Count() > 0 ? oUs.Matriculas.Split(',')[0] : "";

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

        protected override void SaveObj_Presenter(object sender, EventArgs e)
        {
            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(oIView.sEmail));
            email.From = new MailAddress(ConfigurationManager.AppSettings["EmailSoporte"]);
            email.Subject = "Asunto ( " + DateTime.Now.ToString("dd / MMM / yyy hh:mm:ss") + " ) Recuperacion de Contrasena";
            email.Body = "Cualquier contenido en <b>HTML</b> para enviarlo por correo electrónico. <a href='https://localhost:44305/frmRecuperaLogin.aspx?email="+ oIView.sEmail + "' class='btn btn-primary'>" +
                         "Actualizar Contrasena</a>";
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = ConfigurationManager.AppSettings["host"];
            smtp.Port = 25;
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["EmailSoporte"], ConfigurationManager.AppSettings["passEmailSoporte"]);

            string output = null;

            try
            {
                smtp.Send(email);
                email.Dispose();
                output = "Corre electrónico fue enviado satisfactoriamente.";
            }
            catch (Exception ex)
            {
                output = "Error enviando correo electrónico: " + ex.Message;
            }

            Console.WriteLine(output);
        }

        protected override void NewObj_Presenter(object sender, EventArgs e)
        {
            oIView.goLogin(oIGesCat.ActualizaUsuarios(oIView.sEmail, oIView.sPassword, 2));
        }
    }
}