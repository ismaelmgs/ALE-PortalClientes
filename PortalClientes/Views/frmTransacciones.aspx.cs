using PortalClientes.Objetos;
using PortalClientes.Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace PortalClientes.Views
{
    public partial class frmTransacciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //oPresenter = new Transacciones_Presenter(this, new DBTransacciones());

            TextBox milabel = (TextBox)this.Master.FindControl("txtLang");
            if (milabel.Text != Utils.Idioma && milabel.Text != string.Empty)
            {
                Utils.Idioma = milabel.Text;
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmarTransacciones();
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmarTransacciones();
            }

            if (!IsPostBack)
            {
                LlenarTransacciones(Request);
            }

        }

        #region METODOS
        public void LlenarTransacciones(HttpRequest request)
        {
            using (var reader = new StreamReader(request.InputStream))
            {
                var content = reader.ReadToEnd();
                List<gasto> gastos = new List<gasto>();
                gastos = JsonConvert.DeserializeObject<List<gasto>>(content.ToString());

            }
        }

        private void ArmarTransacciones()
        {
            txtBusqueda.Attributes.Add("placeholder", Properties.Resources.Cm_Buscador);

            //lblEstadoDeVuelo.Text = Properties.Resources.Das_EstadoVuelo;
            //lblSalida.Text = Properties.Resources.Das_Salida;
            //lblLlego.Text = Properties.Resources.Das_Llego;
            //lblCompleto.Text = Properties.Resources.Das_Completo;
            //lblVuelos.Text = Properties.Resources.Das_Vuelos;
            //lblHorasVuelo.Text = Properties.Resources.Das_HorasVuelo;
            //lblNMVuelo.Text = Properties.Resources.Das_NMVuelo;
            //lblResumenDeCuenta.Text = Properties.Resources.Das_ResumenCuenta;
            //lblSaldo.Text = Properties.Resources.Das_Saldo;
            //lblIncVenc90Dias.Text = Properties.Resources.Das_Ven90dias;
            //lblUltimaDeclaracion.Text = Properties.Resources.Das_UltimaDeclaracion;
            //lblDeclaracionPara.Text = Properties.Resources.Das_DeclaracionPara;
            //lblVence.Text = Properties.Resources.Das_Vence;
        }

        #endregion
    }
}