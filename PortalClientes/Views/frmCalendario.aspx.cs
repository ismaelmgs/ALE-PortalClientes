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

namespace PortalClientes.Views
{
    public partial class frmCalendario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Scheduler.Start = DateTime.Now;

            ApplyOptionsDay(); // configuracion dia

            ApplyOptionsWeek(); // configuracion semana laboral
            ApplyWorkDaysWeek();

            ApplyOptionsMonth(); // configuracion menusal

            ApplyOptionsTimeLine(); // configuracion timeline

            ApplyOptionsAgenda(); // configuracion agenda

            ApplyCommonOptions();

            Scheduler.ApplyChanges(ASPxSchedulerChangeAction.NotifyVisibleIntervalsChanged);
            Scheduler.DataBind();
        }

        void ApplyOptionsDay()
        {
            Scheduler.BeginUpdate();
            try
            {
                DevExpress.Web.ASPxScheduler.DayView dayView = Scheduler.DayView;
                dayView.ShowWorkTimeOnly = true;
                dayView.ShowAllDayArea = true;
                dayView.ShowDayHeaders = true;
                dayView.DayCount = 1;

                dayView.AppointmentDisplayOptions.SnapToCellsMode = 0;
                dayView.AppointmentDisplayOptions.StartTimeVisibility = AppointmentTimeVisibility.Always;
                dayView.AppointmentDisplayOptions.EndTimeVisibility = AppointmentTimeVisibility.Always;
                dayView.AppointmentDisplayOptions.ShowRecurrence = false;
            }
            finally
            {
                Scheduler.EndUpdate();
            }
        }

        void ApplyOptionsWeek()
        {
            WorkWeekView workWeekView = Scheduler.WorkWeekView;

            workWeekView.ShowWorkTimeOnly = true;
            workWeekView.ShowAllDayArea = true;
            workWeekView.ShowDayHeaders = true;
        }

        void ApplyWorkDaysWeek()
        {
            Scheduler.BeginUpdate();
            try
            {
                WorkDaysCollection workDays = Scheduler.WorkDays;
                workDays.Clear();
                workDays.Add(WeekDays.EveryDay);
            }
            finally
            {
                Scheduler.EndUpdate();
            }
        }

        void ApplyOptionsMonth()
        {
            Scheduler.BeginUpdate();
            try
            {
                MonthView monthView = Scheduler.MonthView;
                monthView.ShowWeekend = true;
                monthView.CompressWeekend = false;
                monthView.ShowMoreButtons = false;
                monthView.WeekCount = 5;
                Scheduler.OptionsToolTips.ShowSelectionToolTip = false;
            }
            finally
            {
                Scheduler.EndUpdate();
            }

        }

        void ApplyOptionsTimeLine()
        {
            Scheduler.BeginUpdate();
            try
            {
                TimelineView timelineView = Scheduler.TimelineView;
                AppointmentDisplayOptions aptOptions = timelineView.AppointmentDisplayOptions;
                aptOptions.SnapToCellsMode = AppointmentSnapToCellsMode.Always;
                aptOptions.AppointmentAutoHeight = true;
                aptOptions.AppointmentHeight = 40;
                timelineView.IntervalCount = 10;
                timelineView.DisplayedIntervalCount = 5;
                timelineView.TimeIndicatorDisplayOptions.Visibility = TimeIndicatorVisibility.Always;
            }
            finally
            {
                Scheduler.EndUpdate();
            }
        }

        void ApplyOptionsAgenda()
        {
            Scheduler.BeginUpdate();
            try
            {
                Scheduler.AgendaView.DayCount = 7;
                Scheduler.AgendaView.AllowFixedDayHeaders = true;
                Scheduler.AgendaView.DayHeaderOrientation = AgendaDayHeaderOrientation.Horizontal;

                Scheduler.AgendaView.AppointmentDisplayOptions.ShowTime = true;
                Scheduler.AgendaView.AppointmentDisplayOptions.ShowResource = false;
                Scheduler.AgendaView.AppointmentDisplayOptions.ShowLabel = true;
                Scheduler.AgendaView.AppointmentDisplayOptions.ShowRecurrence = false;
                Scheduler.AgendaView.AppointmentDisplayOptions.StatusDisplayType = AppointmentStatusDisplayType.Bounds;
            }
            finally
            {
                Scheduler.EndUpdate();
            }
        }

        void ApplyCommonOptions()
        {
           // configuracion vista
            Scheduler.OptionsView.AppointmentSelectionAppearanceMode = AppointmentSelectionAppearanceMode.BackgroundOpacity;


            // configuracion dialogos
            Scheduler.OptionsDialogs.AppointmentDialog.Visibility = SchedulerFormVisibility.None;
            Scheduler.OptionsDialogs.RecurrentAppointmentEditDialog.Visibility = SchedulerFormVisibility.None;
            Scheduler.OptionsDialogs.RecurrentAppointmentDeleteDialog.Visibility = SchedulerFormVisibility.None;


            // comportamiento del calendario
            Scheduler.OptionsBehavior.HighlightSelectionHeaders = true;
            Scheduler.OptionsBehavior.ShowViewNavigator = true;
            Scheduler.OptionsBehavior.ShowViewVisibleInterval = false;


            Scheduler.OptionsLoadingPanel.Text = "Cargando eventos";// se puede cambiar con el idioma

            string[] IssueList = { "Completo", "Cancelado", "En Espera" };
            Color[] IssueColorList = { Color.Ivory, Color.Blue, Color.Plum };

            IAppointmentLabelStorage labelStorage = Scheduler.Storage.Appointments.Labels;
            labelStorage.Clear();
            int count = IssueList.Length;
            for (int i = 0; i < count; i++)
            {
                IAppointmentLabel label = labelStorage.CreateNewLabel(i, IssueList[i]);
                label.SetColor(IssueColorList[i]);
                labelStorage.Add(label);
            }

            string[] PaymentStatuses = { "Paid", "Unpaid" };
            Color[] PaymentColorStatuses = { Color.Green, Color.Red };
            
            AppointmentStatusCollection statusColl = Scheduler.Storage.Appointments.Statuses;
            statusColl.Clear();
            count = PaymentStatuses.Length;
            for (int i = 0; i < count; i++)
            {
                AppointmentStatus status = statusColl.CreateNewStatus(i, PaymentStatuses[i], PaymentStatuses[i]);
                status.SetColor(PaymentColorStatuses[i]);
                statusColl.Add(status);
            }
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
            a.EndTime = DateTime.Now.AddHours(1);
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

        protected void btnActiveView_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string view = button.Attributes["data-view"];

            switch (view)
            {
                case "Day": Scheduler.ActiveViewType = SchedulerViewType.Day;
                    break;
                case "WorkWeek":
                    Scheduler.ActiveViewType = SchedulerViewType.WorkWeek;
                    break;
                case "Month":
                    Scheduler.ActiveViewType = SchedulerViewType.Month;
                    break;
                case "Timeline":
                    Scheduler.ActiveViewType = SchedulerViewType.Timeline;
                    break;
                case "Agenda":
                    Scheduler.ActiveViewType = SchedulerViewType.Agenda;
                    break;
            }
       
        }
    }
}