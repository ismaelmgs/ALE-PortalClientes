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