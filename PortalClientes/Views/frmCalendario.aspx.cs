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
using DevExpress.Web.ASPxScheduler.Internal;

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

            if (!IsPostBack)
            {

            }

            Scheduler.Start = DateTime.Now.AddMonths(-2);

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

                dayView.AppointmentDisplayOptions.SnapToCellsMode = AppointmentSnapToCellsMode.Auto;
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
                monthView.ShowMoreButtons = true;
                monthView.WeekCount = 4;
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
            Scheduler.OptionsView.AppointmentSelectionAppearanceMode = AppointmentSelectionAppearanceMode.Auto;


            // configuracion dialogos
            Scheduler.OptionsDialogs.AppointmentDialog.Visibility = SchedulerFormVisibility.None;
            Scheduler.OptionsDialogs.RecurrentAppointmentEditDialog.Visibility = SchedulerFormVisibility.None;
            Scheduler.OptionsDialogs.RecurrentAppointmentDeleteDialog.Visibility = SchedulerFormVisibility.None;

            Scheduler.OptionsForms.RecurrentAppointmentEditFormVisibility = SchedulerFormVisibility.None;
            Scheduler.OptionsForms.RecurrentAppointmentDeleteFormVisibility = SchedulerFormVisibility.None;
            Scheduler.OptionsToolTips.ShowAppointmentToolTip = false; // bloquear boton izquierdo de eventos
            Scheduler.OptionsToolTips.ShowSelectionToolTip = false;


            // comportamiento del calendario
            Scheduler.OptionsBehavior.HighlightSelectionHeaders = true;
            Scheduler.OptionsBehavior.ShowViewNavigator = true;
            Scheduler.OptionsBehavior.ShowViewVisibleInterval = true;
            Scheduler.OptionsBehavior.ShowViewSelector = false;


            Scheduler.OptionsLoadingPanel.Text = "Cargando eventos";// se puede cambiar con el idioma

            string[] IssueList = { "Completo", "Cancelado", "En Espera" };
            Color[] IssueColorList = { Color.Ivory, Color.White, Color.Plum };

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
            Color[] PaymentColorStatuses = { Color.Red, Color.Green };

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
            //lblEmail.Text = Properties.Resources.Ca_Email;
            lblDireccion.Text = Properties.Resources.Ca_Direccion;
            //lblNotas.Text = Properties.Resources.Ca_Notas;
            lblLLEgada.Text = Properties.Resources.Ca_LlegadaFBO;
            lblTelLLegada.Text = Properties.Resources.Ca_SegundoTelefono;
            //lblEmailLLegada.Text = Properties.Resources.Ca_SegundoEmail;
            lblDireccioLLegada.Text = Properties.Resources.Ca_SegundaDireccion;
            //lblNotasLLegada.Text = Properties.Resources.Ca_SegundaNotas;
            lblCatering.Text = Properties.Resources.Ca_Catering;
            //lblcateringDos.Text = Properties.Resources.Ca_SubCatering;
            //lblCateringTel.Text = Properties.Resources.Ca_TelefonoCatering;
            //lblCateringTelEmail.Text = Properties.Resources.Ca_EmailCatering;
            lblCateringTelNotas.Text = Properties.Resources.Ca_NotasCatering;
            //lblTransporte.Text = Properties.Resources.Ca_Transporte;
            //lblSalidaTransporte.Text = Properties.Resources.Ca_SalidaTransporte;
            //lblTransporteTel.Text = Properties.Resources.Ca_SalidaTransporteTelefono;
            //lblTransporteTel.Text = Properties.Resources.Ca_SalidaTransporteEmail;
            //lblTransporteNotas.Text = Properties.Resources.Ca_SalidaTransporteNotas;
            //lblTransporteLLegada.Text = Properties.Resources.Ca_LlegadaTransporte;
            //lblTransporteLLegadaTel.Text = Properties.Resources.Ca_LlegadaTransporteTelefono;
            //lblTransporteLLegadaEmail.Text = Properties.Resources.Ca_LlegadaTransporteEmail;
            //lblTransporteLLegadaNotas.Text = Properties.Resources.Ca_LlegadaTransporteNotas;
            btnActiveDay.Text = Properties.Resources.Ca_ActiveDay;
            btnActiveWorkWeek.Text = Properties.Resources.Ca_ActiveWorkWeek;
            btnActiveMonth.Text = Properties.Resources.Ca_ActiveMonth;
            btnActiveTimeLine.Text = Properties.Resources.Ca_ActiveTimeLine;
            btnActiveAgenda.Text = Properties.Resources.Ca_ActiveAgenda;
        }

        public static List<Appointment> getAllAppoinments()
        {
            DBCalendario oIGesCat = new DBCalendario();

            FiltroEvent fg = new FiltroEvent();
            fg.meses = Convert.ToInt32(DateTime.Now.Month.ToString());

            List<Appointment> ap = new List<Appointment>();
            List<DatosCalendario> dc = new List<DatosCalendario>();


            ap = oIGesCat.ObtenerCalendario(fg);

            //List<Appointment> ap = new List<Appointment>();

            //Appointment a = new Appointment();
            //a.ID = 1.ToString();
            //a.StartTime = DateTime.Now;
            //a.EndTime = DateTime.Now.AddHours(1);
            //a.Description = "una descripcion del vuelo";
            //a.Location = "de donde a donde va";
            //a.Subject = "de quien proviene";
            //a.Status = 1;
            //a.AllDay = false;
            //a.EventType = "vuelo";
            //a.Label = 1;
            //ap.Add(a);

            return ap;
        }

        protected void btnActiveView_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string view = button.Attributes["data-view"];

            switch (view)
            {
                case "Day":
                    Scheduler.ActiveViewType = SchedulerViewType.Day;
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

        protected void Scheduler_PopupMenuShowing(object sender, DevExpress.Web.Bootstrap.BootstrapSchedulerPopupMenuShowingEventArgs e)
        {
            //e.Menu.ClientSideEvents.PopUp = "OnClientPopupMenuShowing";

            if (e.Menu.MenuId == DevExpress.XtraScheduler.SchedulerMenuItemId.DefaultMenu)
            {
                e.Menu.Visible = false;
            }

            if (e.Menu.MenuId == DevExpress.XtraScheduler.SchedulerMenuItemId.AppointmentMenu)
            {
                e.Menu.Visible = false;
            }
        }


        protected void OnSchedulerBeforeExecuteCallbackCommand(object sender, DevExpress.Web.ASPxScheduler.SchedulerCallbackCommandEventArgs e)
        {
            if (e.CommandId == "EnableToolTipCallback")
            {
                e.Command = new EnableToolTipCallback(Scheduler);
            }
        }

        public class EnableToolTipCallback : SchedulerCallbackCommand
        {
            public EnableToolTipCallback(ASPxScheduler control)
                : base(control)
            {
            }
            public override void Execute(string parameters)
            {
                base.Execute(parameters);
                string[] args = parameters.Split(new char[] { '=' });
                if (args[0] == "selection")
                {
                    if (args[1] == "false")
                        Control.OptionsToolTips.ShowSelectionToolTip = false;
                    else if (args[1] == "true")
                        Control.OptionsToolTips.ShowSelectionToolTip = true;
                }
                else if (args[0] == "appointment")
                {
                    if (args[1] == "false")
                        Control.OptionsToolTips.ShowAppointmentToolTip = false;
                    else if (args[1] == "true")
                        Control.OptionsToolTips.ShowAppointmentToolTip = true;
                }
                else if (args[0] == "drag")
                {
                    if (args[1] == "false")
                        Control.OptionsToolTips.ShowAppointmentDragToolTip = false;
                    else if (args[1] == "true")
                        Control.OptionsToolTips.ShowAppointmentDragToolTip = true;
                }
                Control.ApplyChanges(ASPxSchedulerChangeAction.All);
            }

            public override string Id
            {
                get { return "EnableToolTipCallback"; }
            }

            protected override void ParseParameters(string parameters)
            {
                //do nothing
            }

            protected override void ExecuteCore()
            {
                //do nothing
            }

        }
    }
}