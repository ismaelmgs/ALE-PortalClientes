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
using NucleoBase.Core;
using System.Web.Services;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Data;
using Newtonsoft.Json;
using System.Globalization;

namespace PortalClientes.Views
{
    public partial class frmCalendario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["RefUrl"] = Request.Url.ToString();
            if (System.Web.HttpContext.Current.Session["UserIdentity"] == null)
            {
                Response.Redirect("~/Views/frmFinconexion2.aspx");
            }

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

            Session["dateScheduler"] = 0;

            if (IsPostBack)
            {
                if(hfdate.Value != "")
                {
                    var cadena = hfdate.Value.Split(' ');
                    getMonth(cadena[1]);
                }
            }

            //Scheduler.Start = DateTime.Now.AddMonths(-2);

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

        private void getMonth(string v)
        {
            switch (v)
            {
                case "Jan":
                    Session["dateScheduler"] = 1;
                    break;
                case "Feb":
                    Session["dateScheduler"] = 2;
                    break;
                case "Mar":
                    Session["dateScheduler"] = 3;
                    break;
                case "Apr":
                    Session["dateScheduler"] = 4;
                    break;
                case "May":
                    Session["dateScheduler"] = 5;
                    break;
                case "Jun":
                    Session["dateScheduler"] = 6;
                    break;
                case "Jul":
                    Session["dateScheduler"] = 7;
                    break;
                case "Agu":
                    Session["dateScheduler"] = 8;
                    break;
                case "Sep":
                    Session["dateScheduler"] = 9;
                    break;
                case "Oct":
                    Session["dateScheduler"] = 10;
                    break;
                case "Nov":
                    Session["dateScheduler"] = 11;
                    break;
                case "Dic":
                    Session["dateScheduler"] = 12;
                    break;
            }
        }

        protected void lkbExpPDFRes_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = (DataTable)HttpContext.Current.Session["dataTableItem"];
                string strPath = string.Empty;
                ReportDocument rd = new ReportDocument();
                strPath = Server.MapPath("RPT\\CrystalReport1.rpt");
                strPath = strPath.Replace("\\Views", "");
                rd.Load(strPath, OpenReportMethod.OpenReportByDefault);
                rd.SetDataSource(dt);

                //if (iTipoReporte == 1)
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "DetalleVuelo");
                //else
                //   rd.ExportToHttpResponse(ExportFormatType.Excel, Response, true, "ResumenGastos");
                Response.End();
            }
            catch(Exception ex)
            {

            }
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
            //lblObjetivo.Text = Properties.Resources.Ca_Objetivo;
            lblRegulacion.Text = Properties.Resources.Ca_Regulacion;
            lblEstatus.Text = Properties.Resources.Ca_Estatus;
            lblDescripcion.Text = Properties.Resources.Ca_Descripcion;
            lbldesdeA.Text = Properties.Resources.Ca_SalidaLlegada;
            lblAeropuertoSalida.Text = Properties.Resources.Ca_AeropuertoSalida;
            //lblFueraFechaBloque.Text = Properties.Resources.Ca_FechaFueraBloque;
            //lblFueraTiempoBloque.Text = Properties.Resources.Ca_TiempoFueraBloque;
            lblFechaDeSalida.Text = Properties.Resources.Ca_FechaSalida;
            lblHoraSalida.Text = Properties.Resources.Ca_HoraSalida;
            lblZonaHoraria.Text = Properties.Resources.Ca_ZonaHoraria;
            lblAeropuertoLLegada.Text = Properties.Resources.Ca_AeropuertoLlegada;
            lblFhechaArrivo.Text = Properties.Resources.Ca_FechaArrivo;
            lblHoraArrivo.Text = Properties.Resources.Ca_HoraArrivo;
            //lblFechaBloque.Text = Properties.Resources.Ca_FechaBloque;
            //lblTiempoBloque.Text = Properties.Resources.Ca_HoraBloque;
            lblZonaHorariaLlegada.Text = Properties.Resources.Ca_ZonaHorariaLlegada;
            lblPasajerosGeneral.Text = Properties.Resources.Ca_Pasajeros;
            lblPasajeros.Text = Properties.Resources.Ca_SubPasajeros;
            lblNumeroPasajeros.Text = Properties.Resources.Ca_NumeroPasajeros;
            lblTripulacion.Text = Properties.Resources.Ca_Tripulacion;
            lblTripulacionMiembros.Text = Properties.Resources.Ca_MiembrosTripulacion;
            //lblDatosVuelo.Text = Properties.Resources.Ca_DatosVuelo;
            lblDistancia.Text = Properties.Resources.Ca_Distancia;
            lblDatosTiempoVuelo.Text = Properties.Resources.Ca_TiempoVuelo;
            //lblDatosBloqueTiempo.Text = Properties.Resources.Ca_BloqueTiempo;
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
            //lblCateringTelNotas.Text = Properties.Resources.Ca_NotasCatering;
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
            lblCalendario.Text = Properties.Resources.Ca_TituloCal;
            lblllegadaa.Text = Properties.Resources.Ca_LlegadaA;
        }

        public List<Appointment> getAllAppoinments()
        {
            DBCalendario oIGesCat = new DBCalendario();

            FiltroEvent fg = new FiltroEvent();
            var date = Session["dateScheduler"];

            if(Convert.ToInt32(Session["dateScheduler"]) > 0)
            {
                fg.meses = Convert.ToInt32(Session["dateScheduler"]);
            }
            else
            {
                fg.meses = Convert.ToInt32(DateTime.Now.Month.ToString());
            }

            List<Appointment> ap = new List<Appointment>();

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

        [WebMethod(EnableSession = true)]
        public static DatosModal getDataAppointment(string Id)
        {
            try
            {
                List<DatosCalendario> olst = (List<DatosCalendario>)HttpContext.Current.Session["SSEventos"];
                DataTable dt = (DataTable)JsonConvert.DeserializeObject((String)HttpContext.Current.Session["tableRpt"], (typeof(DataTable)));

                // generamos el item que va al reporte
                string expresion = "legId = " + Id;
                DataTable tblFiltered = dt.Select(expresion).AsEnumerable().CopyToDataTable();
                var item = olst.Find(x => x.legId == Convert.ToInt32(Id));

                tblFiltered.Columns.Add("TiempoVuelo", typeof(System.String));
                tblFiltered.Columns.Add("FechaInicioStr", typeof(System.String));
                tblFiltered.Columns.Add("HoraInicio", typeof(System.String));
                tblFiltered.Columns.Add("FechaFinStr", typeof(System.String));
                tblFiltered.Columns.Add("HoraFin", typeof(System.String));
                tblFiltered.Columns.Add("Matricula", typeof(System.String));
                tblFiltered.Columns.Add("Evento", typeof(System.String));
                tblFiltered.Columns.Add("statusVuelo", typeof(System.String));
                tblFiltered.Columns.Add("idioma", typeof(System.String));

                foreach (DataRow row in tblFiltered.Rows)
                {
                    row["idioma"] = Utils.Idioma;
                    row["TiempoVuelo"] = (item.FechaFin - item.FechaInicio).ToString(@"hh\h\ mm\m\ ");
                    row["FechaInicioStr"] = Utils.Idioma == "es-MX" ? item.FechaInicio.ToLongDateString().ToString(CultureInfo.CreateSpecificCulture("es-MX")) : DevuelveFechaIngles(item.FechaInicio.Day, item.FechaInicio.Month, item.FechaInicio.Year);
                    row["FechaFinStr"] = Utils.Idioma == "es-MX" ? item.FechaFin.ToLongDateString().ToString(CultureInfo.CreateSpecificCulture("es-MX")) : DevuelveFechaIngles(item.FechaFin.Day, item.FechaFin.Month, item.FechaFin.Year);
                    row["HoraInicio"] = item.FechaInicio.ToShortTimeString();
                    row["HoraFin"] = item.FechaFin.ToShortTimeString();
                    row["Matricula"] = Utils.MatriculaActual;
                    row["Evento"] = item.recType == "M" ? "Mantenimiento" : "Vuelo";
                    row["tripStat"] = item.tripStat == "X" ? "Cancelado" : "Pendiente";
                    row["statusVuelo"] = item.FechaInicio < DateTime.Now ? "Completado" : "En Proceso";
                    row["pasajeros"] = string.Join(", ", item.pasajeros.Split('|').ToList());
                    row["piloto"] = item.primerNomPil + " " + item.segNomPil + " " + item.apellidosPil + ", " + item.primerNomCop + " " + item.segNomCop + " " + item.apellidosCop;
                }


                HttpContext.Current.Session["dataTableItem"] = tblFiltered;

                DatosModal dm = new DatosModal();

                if (item != null)
                {
                    dm.origen = item.origen;
                    dm.fboNombreOrigen = item.fboNombreOrigen;
                    dm.destino = item.destino;
                    dm.fboNombreDest = item.fboNombreDest;
                    dm.TiempoVuelo = (item.FechaFin - item.FechaInicio).ToString(@"hh\h\ mm\m\ ");
                    dm.FechaInicio = item.FechaInicio.ToLongDateString();
                    dm.HoraInicio = item.FechaInicio.ToShortTimeString();
                    dm.FechaFin = item.FechaFin.ToLongDateString();
                    dm.HoraFin = item.FechaFin.ToShortTimeString();

                    dm.matricula = Utils.MatriculaActual;
                    dm.recType = item.recType == "M" ? "Mantenimiento" : "Vuelo";
                    dm.tripNum = item.tripNum.S();
                    dm.requestor = item.requestor;
                    dm.requestorName = item.requestorName;
                    dm.cliente = item.cliente;
                    dm.farNum = item.farNum;
                    dm.tripStat = item.tripStat == "X" ? "Cancelado" : "Pendiente";
                    dm.statusVuelo = item.FechaInicio < DateTime.Now ? "Completado" : "En Proceso";
                    dm.fboPhoneOrigen = item.fboPhoneOrigen;
                    dm.fboDirOrigen = item.fboDirOrigen;
                    dm.fboPhoneDest = item.fboPhoneDest;
                    dm.fboDirDest = item.fboDirDest;
                    dm.notes = item.notes;
                    dm.distancia = item.distancia;
                    dm.typeDesc = item.typeDesc;
                    dm.pax = item.pax;
                    dm.pasajeros = string.Join(", ", item.pasajeros.Split('|').ToList());
                    dm.tripulacion = item.primerNomPil + " " + item.segNomPil + " " + item.apellidosPil + ", " + item.primerNomCop + " " + item.segNomCop + " " + item.apellidosCop;
                }

                return dm;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }

        public static string DevuelveFechaIngles(int iDia, int iMes, int iAnio)
        {
            string sFecha = string.Empty;
            string sDia = string.Empty;
            string sMes = string.Empty;

            switch (iDia)
            {
                case 1:
                    sDia = "1st";
                    break;
                case 2:
                    sDia = "2nd";
                    break;
                case 3:
                    sDia = "3rd";
                    break;
                case 4:
                    sDia = "4th";
                    break;
                default:
                    sDia = iDia.ToString() + "th";
                    break;
            }

            switch (iMes)
            {
                case 1:
                    sMes = "January";
                    break;
                case 2:
                    sMes = "February";
                    break;
                case 3:
                    sMes = "March";
                    break;
                case 4:
                    sMes = "April";
                    break;
                case 5:
                    sMes = "May";
                    break;
                case 6:
                    sMes = "June";
                    break;
                case 7:
                    sMes = "July";
                    break;
                case 8:
                    sMes = "August";
                    break;
                case 9:
                    sMes = "September";
                    break;
                case 10:
                    sMes = "October";
                    break;
                case 11:
                    sMes = "November";
                    break;
                case 12:
                    sMes = "December";
                    break;
            }

            sFecha = sMes + " " + sDia + ", " + iAnio.ToString();

            return sFecha;
        }

        private void LlenaModal()
        {
            List<DatosCalendario> olst = (List<DatosCalendario>)Session["SSEventos"];
            int id = Convert.ToInt32(HttpContext.Current.Session["id"]);
            var item = olst.Find(x => x.legId == Convert.ToInt32(id));

            lblClaveCiudadSalida.Text = item.origen;
            lblClaveCiudadSalidaRes.Text = item.fboNombreOrigen;
            lblClaveCiudadLlegada.Text = item.destino;
            lblClaveCiudadLlegadaRes.Text = item.fboNombreDest;
            lblDMASalida.Text = item.FechaInicio.ToLongDateString();
            lblDMAHoraSalida.Text = item.FechaInicio.ToShortTimeString();
            lblDMALLegada.Text = item.FechaFin.ToLongDateString();
            lblDMAHoraLLegada.Text = item.FechaFin.ToShortTimeString();

            lblAeronave.Text = Utils.MatriculaActual;
            lblTipoEventoRes.Text = item.recType == "M" ? "Mantenimiento" : "Vuelo";
            lblViajeNumeroRes.Text = item.tripNum.S();
            lblTipoVueloRes.Text = item.requestor;
            lblNombreContactoRes.Text = item.requestorName;
            lalSolicitanteRes.Text = item.cliente;
            lblRegulacionRes.Text = item.farNum;
            lblEstatusRes.Text = item.tripStat == "X" ? "Cancelado" : "Pendiente";

            if (item.FechaInicio < DateTime.Now)
                lblEstatusRes.Text = "Completado";

            lblAeropuertoSalida.Text = item.origen;
            lblAeropuertoSalidaRes.Text = item.fboNombreOrigen;

            //lblFueraFechaBloqueRes.Text = item.FechaInicio.ToShortDateString();
            //lblFueraTiempoBloqueRes.Text = item.FechaInicio.ToShortTimeString();
            lblFechaDeSalidaRes.Text = item.FechaInicio.ToShortDateString();
            lblHoraSalidaRes.Text = item.FechaInicio.ToShortDateString();
        }

        protected void btnActiveView_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string view = button.Attributes["data-view"];

            setClassBtn();
            button.CssClass = "btn btn-primary";

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

        private void setClassBtn()
        {
            btnActiveDay.CssClass = "btn btn-secondary";
            btnActiveWorkWeek.CssClass = "btn btn-secondary";
            btnActiveMonth.CssClass = "btn btn-secondary";
            btnActiveTimeLine.CssClass = "btn btn-secondary";
            btnActiveAgenda.CssClass = "btn btn-secondary";
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
    }
}