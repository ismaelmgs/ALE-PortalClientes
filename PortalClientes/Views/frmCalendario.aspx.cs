using DevExpress.Web.ASPxScheduler;
using DevExpress.XtraScheduler;
using PortalClientes.DomainModel;
using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Appointment = PortalClientes.Objetos.Appointment;
using PortalClientes.Clases;

namespace PortalClientes.Views
{
    public partial class frmCalendario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox milabel = (TextBox)this.Master.FindControl("txtLang");
            if (milabel.Text != Utils.Idioma && milabel.Text != string.Empty)
            {
                Utils.Idioma = milabel.Text;
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmaCalendario();
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmaCalendario();
            }


            SchedulerRecurenceInfo.Start = DateTime.Now;

            //SchedulerRecurenceInfo.Storage.Appointments.Clear();

            string[] IssueList = { "Completo", "Cancelado", "En Espera" };
            Color[] IssueColorList = { Color.Ivory, Color.Blue, Color.Plum };
            string[] PaymentStatuses = { "Paid", "Unpaid" };
            Color[] PaymentColorStatuses = { Color.Green, Color.Red };


            IAppointmentLabelStorage labelStorage = SchedulerRecurenceInfo.Storage.Appointments.Labels;
            labelStorage.Clear();
            int count = IssueList.Length;
            for (int i = 0; i < count; i++)
            {
                IAppointmentLabel label = labelStorage.CreateNewLabel(i, IssueList[i]);
                label.SetColor(IssueColorList[i]);
                labelStorage.Add(label);
            }
            AppointmentStatusCollection statusColl = SchedulerRecurenceInfo.Storage.Appointments.Statuses;
            statusColl.Clear();
            count = PaymentStatuses.Length;
            for (int i = 0; i < count; i++)
            {
                AppointmentStatus status = statusColl.CreateNewStatus(i, PaymentStatuses[i], PaymentStatuses[i]);
                status.SetColor(PaymentColorStatuses[i]);
                statusColl.Add(status);
            }
        }

        protected void btnAlerta2_Click(object sender, EventArgs e)
        {
            MostrarMensaje("Mensaje de exito!", "Aviso");
        }

        public void MostrarMensaje(string sMensaje, string sCaption)
        {
            sMensaje = "alertexito('" + sMensaje + "');";
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "alertexito", sMensaje, true);
        }

        private void ArmaCalendario()
        {
            lblDetallesVuelo.Text = Properties.Resources.Ca_DetalleVuelo;
            lblInformacionGeneral.Text = Properties.Resources.Ca_InformacionGeneral;
            lblAeronave.Text = Properties.Resources.Ca_Aeronave;
            lblTipoEvento.Text = Properties.Resources.Ca_TipoEvento;
            lblViajeNumero.Text = Properties.Resources.Ca_ViajeNumero;
            lblTipoVuelo.Text = Properties.Resources.Ca_TipoVuelo;
            lblNombreContacto.Text = Properties.Resources.Ca_NombreContacto;
            lalSolicitante.Text = Properties.Resources.Ca_Solicitante;
            lblObjetivo.Text = Properties.Resources.Ca_Objetivo;
            lblRegulacion.Text = Properties.Resources.Ca_Regulacion;
            lblEstatus.Text = Properties.Resources.Ca_Estatus;
            lblDescripcion.Text = Properties.Resources.Ca_Descripcion;
            lbldesdeA.Text = Properties.Resources.Ca_SalidaLlegada;
            lblAeropuertoSalida.Text = Properties.Resources.Ca_AeropuertoSalida;
            lblFueraFechaBloque.Text = Properties.Resources.Ca_FechaFueraBloque;
            lblFueraTiempoBloque.Text = Properties.Resources.Ca_TiempoFueraBloque;
            lblFechaDeSalida.Text = Properties.Resources.Ca_FechaSalida;
            lblHoraSalida.Text = Properties.Resources.Ca_HoraSalida;
            lblZonaHoraria.Text = Properties.Resources.Ca_ZonaHoraria;
            lblAeropuertoLLegada.Text = Properties.Resources.Ca_AeropuertoLlegada;
            lblFhechaArrivo.Text = Properties.Resources.Ca_FechaArrivo;
            lblHoraArrivo.Text = Properties.Resources.Ca_HoraArrivo;
            lblFechaBloque.Text = Properties.Resources.Ca_FechaBloque;
            lblTiempoBloque.Text = Properties.Resources.Ca_HoraBloque;
            lblZonaHorariaLlegada.Text = Properties.Resources.Ca_ZonaHorariaLlegada;
            lblPasajerosGeneral.Text = Properties.Resources.Ca_Pasajeros;
            lblPasajeros.Text = Properties.Resources.Ca_SubPasajeros;
            lblNumeroPasajeros.Text = Properties.Resources.Ca_NumeroPasajeros;
            lblTripulacion.Text = Properties.Resources.Ca_Tripulacion;
            lblTripulacionMiembros.Text = Properties.Resources.Ca_MiembrosTripulacion;
            lblDatosVuelo.Text = Properties.Resources.Ca_DatosVuelo;
            lblDistancia.Text = Properties.Resources.Ca_Distancia;
            lblDatosTiempoVuelo.Text = Properties.Resources.Ca_TiempoVuelo;
            lblDatosBloqueTiempo.Text = Properties.Resources.Ca_BloqueTiempo;
            lblFBO.Text = Properties.Resources.Ca_FBO;
            lblSalidaFBO.Text = Properties.Resources.Ca_SalidaFBO;
            lblTel.Text = Properties.Resources.Ca_Telefono;
            lblEmail.Text = Properties.Resources.Ca_Email;
            lblDireccion.Text = Properties.Resources.Ca_Direccion;
            lblNotas.Text = Properties.Resources.Ca_Notas;
            lblLLEgada.Text = Properties.Resources.Ca_LlegadaFBO;
            lblTelLLegada.Text = Properties.Resources.Ca_SegundoTelefono;
            lblEmailLLegada.Text = Properties.Resources.Ca_SegundoEmail;
            lblDireccioLLegada.Text = Properties.Resources.Ca_SegundaDireccion;
            lblNotasLLegada.Text = Properties.Resources.Ca_SegundaNotas;
            lblCatering.Text = Properties.Resources.Ca_Catering;
            lblcateringDos.Text = Properties.Resources.Ca_SubCatering;
            lblCateringTel.Text = Properties.Resources.Ca_TelefonoCatering;
            lblCateringTelEmail.Text = Properties.Resources.Ca_EmailCatering;
            lblCateringTelNotas.Text = Properties.Resources.Ca_NotasCatering;
            lblTransporte.Text = Properties.Resources.Ca_Transporte;
            lblSalidaTransporte.Text = Properties.Resources.Ca_SalidaTransporte;
            lblTransporteTel.Text = Properties.Resources.Ca_SalidaTransporteTelefono;
            lblTransporteTel.Text = Properties.Resources.Ca_SalidaTransporteEmail;
            lblTransporteNotas.Text = Properties.Resources.Ca_SalidaTransporteNotas;
            lblTransporteLLegada.Text = Properties.Resources.Ca_LlegadaTransporte;
            lblTransporteLLegadaTel.Text = Properties.Resources.Ca_LlegadaTransporteTelefono;
            lblTransporteLLegadaEmail.Text = Properties.Resources.Ca_LlegadaTransporteEmail;
            lblTransporteLLegadaNotas.Text = Properties.Resources.Ca_LlegadaTransporteNotas;
        }

        public static List<Appointment> getAllAppoinments()
        {
            DBCalendario oIGesCat = new DBCalendario();

            FiltroEvent fg = new FiltroEvent();
            fg.meses = Convert.ToInt32(DateTime.Now.Month.ToString());

            List<Appointment> ap = new List<Appointment>();
            ap = oIGesCat.ObtenerCalendario(fg);

            //List<Appointment> ap = new List<Appointment>();

            Appointment a = new Appointment();
            a.ID = 1.ToString();
            a.StartTime = DateTime.Now;
            a.EndTime = DateTime.Now.AddHours(5);
            a.Description = "una descripcion del vuelo";
            a.Location = "de donde a donde va";
            a.Subject = "de quien proviene";
            a.Status = 1;
            a.AllDay = false;
            a.EventType = "vuelo";
            a.Label = 1;
            ap.Add(a);

            return ap;
        }
    }
}