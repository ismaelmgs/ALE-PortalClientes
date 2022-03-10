using NucleoBase.Core;
using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using PortalClientes.Objetos;
using PortalClientes.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalClientes.Clases;
using System.Collections.Specialized;
using System.Configuration;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;

namespace PortalClientes
{
    public partial class frmLoginLoss : System.Web.UI.Page, IViewEmailRecoverPass
    {
       
        #region EVENTOS
        protected void Page_Load(object sender, EventArgs e)
        {
            oPresenter = new EmailRecoveryPass_Presenter(this, new DBLogin());

            if (!IsPostBack)
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmaFormulario();
            }
        }

        protected void btnEviarContrasena_Click(object sender, EventArgs e)
        {
            try
            {
                if (eValidateObj != null)
                    eValidateObj(sender, e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        protected void btnAceptConfirm_Click(object sender, EventArgs e)
        {
            mpeConfirm.Hide();
            Response.Redirect("~/frmLogin.aspx");
        }

        protected void lblIdiomaEspanol_Click(object sender, EventArgs e)
        {
            Utils.Idioma = "es-MX";
            CambiaIdioma();
        }

        protected void lblIdiomaEnglish_Click(object sender, EventArgs e)
        {
            Utils.Idioma = "en-US";
            CambiaIdioma();
        }

        #endregion

        #region METODOS

        private void ArmaFormulario()
        {
            lblLoginLossHeader.Text = Properties.Resources.Lo_CamContrasena;
            txtEmail.NullText = Properties.Resources.Lo_Correo;
            lblRegresarLogin.Text = Properties.Resources.Lo_BackLogin;
            btnEviarContrasena.Text = Properties.Resources.Lo_Enviar;
            lblMessageConfirm.Text = Properties.Resources.MsjActEmail;
            btnAceptConfirm.Text = Properties.Resources.Lo_BtnEntendido;
        }

        public void setParameters(List<Parametros> lstParameteres)
        {
            foreach(Parametros p in lstParameteres)
            {
                if (p.Nombre == "apiKey")
                    sapiKey = p.Valor;

                if (p.Nombre == "EmailSoporte")
                    sEmailSoporte = p.Valor;

                if (p.Nombre == "template")
                    sTemplate = p.Valor;
            }
        }

        public void isValidUser(string nombre)
        {
            if (nombre != "")
            {
                NameValueCollection values = new NameValueCollection();
                values.Add("apikey", sapiKey);//ConfigurationManager.AppSettings["apiKey"]);
                values.Add("from", sEmailSoporte);//onfigurationManager.AppSettings["EmailSoporte"]);
                values.Add("fromName", "MexJet");
                values.Add("to", sEmail);
                values.Add("subject", "recuperación de contraseña");
                values.Add("isTransactional", "true");
                values.Add("template", sTemplate);// ConfigurationManager.AppSettings["template"]);
                values.Add("merge_firstname", nombre);
                values.Add("merge_email", sEmail);
                values.Add("merge_timeInterval", DateTime.Now.AddHours(2).ToString("ddMMyyHHmm"));
                values.Add("merge_accountaddress", sEmail);

                string address = "https://api.elasticemail.com/v2/email/send";

                string response = Send(address, values);

                JavaScriptSerializer ser = new JavaScriptSerializer();
                Success s = new Success();
                s = ser.Deserialize<Success>(response);

                if (s.success)
                {
                    mpeConfirm.Show();
                }

                Console.WriteLine(response);
            }
            else
            {
                mpeConfirm.Show();
            }
        }

        static string Send(string address, NameValueCollection values)
        {
            using (WebClient client = new WebClient())
            {
                try
                {
                    byte[] apiResponse = client.UploadValues(address, values);
                    return Encoding.UTF8.GetString(apiResponse);

                }
                catch (Exception ex)
                {
                    return "Exception caught: " + ex.Message + "\n" + ex.StackTrace;
                }
            }
        }

        private void CambiaIdioma()
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
            ArmaFormulario();
        }

        #endregion

        #region VARIABLES Y PROPIEDADES

        EmailRecoveryPass_Presenter oPresenter;

        public event EventHandler eNewObj;
        public event EventHandler eObjSelected;
        public event EventHandler eSaveObj;
        public event EventHandler eDeleteObj;
        public event EventHandler eSearchObj;
        public event EventHandler eValidateObj;

        public string sEmail
        {
            get { return txtEmail.Text.S(); }
        }

        public string sapiKey
        {
            get { return ViewState["sVSsapiKey"].S(); }
            set { ViewState["sVSsapiKey"] = value; }
        }

        public string sTemplate
        {
            get { return ViewState["sVSsTemplate"].S(); }
            set { ViewState["sVSsTemplate"] = value; }
        }

        public string sEmailSoporte
        {
            get { return ViewState["sVsEmailSoporte"].S(); }
            set { ViewState["sVsEmailSoporte"] = value; }
        }

        public class Success
        {
            public bool success { get; set; }
            public Data data { get; set; }

        }

        public class Data
        {
            public string transactionid { get; set; }
            public string messageid { get; set; }
        }

        #endregion


    }
}