<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmCalendario.aspx.cs" Inherits="PortalClientes.Views.frmCalendario" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v18.1, Version=18.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register TagPrefix="cc1" Namespace="DevExpress.XtraScheduler" Assembly="DevExpress.XtraScheduler.v18.1.Core, Version=18.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dxwschs" Namespace="DevExpress.Web.ASPxScheduler" Assembly="DevExpress.Web.ASPxScheduler.v18.1, Version=18.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v18.1, Version=18.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        //function OnGetAppointmentProps(values) {
        //    var formatter = new ASPx.DateFormatter();
        //    formatter.SetFormatString("dd.MM.yyyy HH:mm");
        //    $("#infoSubject").html(values ? values[0] : "");
        //    $("#infoLocation").html(values ? values[1] : "");
        //    $("#infoStartTime").html(values ? formatter.Format(values[2]) : "");
        //    $("#infoEndTime").html(values ? formatter.Format(values[3]) : "");
        //    $("#infoDescription").html(values ? values[4] : "");
        //}
        function ClickAppointment(scheduler, a) {
            //console.log(a.appointmentId);
            // if (a != null) {
            //    scheduler.GetAppointmentProperties(a.appointmentId, 'Subject;Location;Start;End;Description', OnGetAppointmentProps);
            //} else
            //    OnGetAppointmentProps(null);
            "use strict";
            var modalId = '<%=modalDescription.ClientID%>';
            var modal = $find(modalId);
            modal.show();

        }
        function CloseModal() {
            "use strict";
            var modalId = '<%=modalDescription.ClientID%>';
            var modal = $find(modalId);
            modal.hide();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <!-- Button trigger modal -->
    <%-- <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
        Modal
    </button>


    <div class="row">
        <div class="col-md-6">
            <div class="title_left">
                <h3>Calendario</h3>
            </div>
        </div>
        <div class="col-md-6">
            <div class="title_right">
                <div class="col-md-5 col-sm-5   form-group pull-right top_search">
                    <div class="input-group">
                        <asp:TextBox ID="txtBusqueda" runat="server" CssClass="form-control" placeholder="Buscar..."></asp:TextBox>
                        <span class="input-group-btn">
                            <button id="btnBuscar" class="btn btn-default" type="button">
                                <i class="fa fa-search" aria-hidden="true"></i>
                            </button>
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </div>--%>
    <div class="row">
        <div class="col-md-12 col-sm-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>
                        <asp:Label ID="lblCalendario" runat="server" Text="Calendario" Font-Bold="true"></asp:Label></h2>
                    <div class="clearfix"></div>
                </div>
                <div class="row">

                    <div class="col-md-12" style="text-align: right;">
                        <asp:Button runat="server" ID="btnActiveDay" OnClick="btnActiveView_Click" data-view="Day" Text="Hoy" CssClass="btn btn-secondary" />
                        <asp:Button runat="server" ID="btnActiveWorkWeek" OnClick="btnActiveView_Click" data-view="WorkWeek" Text="Semanal" CssClass="btn btn-secondary" />
                        <asp:Button runat="server" ID="btnActiveMonth" OnClick="btnActiveView_Click" data-view="Month" Text="Mensual" CssClass="btn btn-secondary" />
                        <asp:Button runat="server" ID="btnActiveTimeLine" OnClick="btnActiveView_Click" data-view="Timeline" Text="TimeLine" CssClass="btn btn-secondary" />
                        <asp:Button runat="server" ID="btnActiveAgenda" OnClick="btnActiveView_Click" data-view="Agenda" Text="Agenda" CssClass="btn btn-secondary" />
                        <dx:BootstrapScheduler ID="Scheduler" AppointmentDataSourceID="ObjectDataSource" runat="server" ActiveViewType="month"
                            OnPopupMenuShowing="Scheduler_PopupMenuShowing">
                            <Storage>
                                <Appointments AutoRetrieveId="true">
                                    <Mappings AppointmentId="ID" Start="StartTime" End="EndTime" Subject="Subject"
                                        Description="Description" Location="Location"
                                        Type="EventType" Label="Label" Status="Status" />
                                </Appointments>
                            </Storage>
                            <ClientSideEvents
                                AppointmentClick="function(s, e) { ClickAppointment(s, e); }" />
                            <OptionsToolTips ShowAppointmentToolTip="false" />
                            <Views>
                                <DayView>
                                    <WorkTime Start="00:00:00" End="23:59:59" />
                                </DayView>
                                <WorkWeekView ResourcesPerPage="1">
                                    <WorkTime Start="00:00:00" End="23:59:59" />
                                </WorkWeekView>
                                <WeekView Enabled="false" />
                                <FullWeekView Enabled="false">
                                </FullWeekView>
                                <MonthView ResourcesPerPage="1">
                                    <AppointmentDisplayOptions StartTimeVisibility="Never" EndTimeVisibility="Never" StatusDisplayType="Bounds" />
                                    <CellAutoHeightOptions Mode="LimitHeight" MinHeight="140" />
                                </MonthView>
                                <TimelineView ResourcesPerPage="1">
                                </TimelineView>
                                <AgendaView Enabled="true">
                                    <%--<AgendaViewStyles ScrollAreaHeight="600">
                                    </AgendaViewStyles>--%>
                                </AgendaView>
                            </Views>
                            <Storage EnableReminders="false" />
                        </dx:BootstrapScheduler>
                        <asp:ObjectDataSource
                            ID="ObjectDataSource"
                            runat="server"
                            SelectMethod="getAllAppoinments"
                            TypeName="PortalClientes.Views.frmCalendario" />
                    </div>
                </div>
            </div>
        </div>
    </div>


    <asp:HiddenField ID="hdTargetDescription" runat="server" />
    <cc1:ModalPopupExtender ID="modalDescription" runat="server" TargetControlID="hdTargetDescription"
        PopupControlID="pnlDescription" BackgroundCssClass="overlayy">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlDescription" runat="server" BorderColor="" BackColor="White" Height="" HorizontalAlign="Center"
        Width="" CssClass="modal-derecha anim_RLR">
        <asp:UpdatePanel ID="upaUsuario" runat="server">
            <ContentTemplate>
                
                    <asp:Button ID="Button1" runat="server" CssClass="btn" Text="X" Font-Bold="true" OnClientClick="CloseModal();" Style="z-index: 2000; right: 13px; margin-top: 10px; position: absolute; color: #ffffff;" />
                    <h5 class="modal-title" style="color:#ffffff;background-color:#2a3f54;width:100%;height:70px;padding-top:15px;">
                                <asp:Label ID="lblDetallesVuelo" runat="server" Text="Detalles de Vuelo" Font-Bold="true"></asp:Label></h5>
                    <!-- inicio contenido modal RLR-->
                    <div style="padding:5px;">
                        <div class="row">
                        <div class="col-md-9" style="text-align: left;">
                            
                        </div>
                        <div class="col-md-3" style="text-align: right;">
                            <asp:LinkButton ID="btnExcel" runat="server" Text="<i class='fa fa-file-pdf-o' style='color:#73879c;font-size:25px;'></i>" CssClass="btn" />
                            <asp:LinkButton ID="btnPDF" runat="server" Text="<i class='fa fa-print' style='color:#73879c;font-size:25px;'></i>" CssClass="btn" />
                        </div>
                    </div>
                    <hr style="border-bottom: 2px solid #E6E9ED; margin-top: -1px;" />

                    <div>
                        <div class="row">
                            <div class="col-md-4" style="text-align: center;">
                                <asp:Label ID="lblClaveCiudadSalida" runat="server" Text="KTEB" Font-Bold="false" Style="font-size: 20px;"></asp:Label><br />
                                <asp:Label ID="lblClaveCiudadSalidaRes" runat="server" Text="Teterboro" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-4" style="text-align: center; padding-top: 10px;">
                                <span style="background-color: #efefef; padding: 5px; border-radius: 50%;">
                                    <i class="fa fa-check"></i>
                                </span>
                                <br />
                                <asp:Label ID="lblTiempoVuelo" runat="server" Text="02h 40m" Font-Bold="false"></asp:Label>
                            </div>
                            <div class="col-md-4" style="text-align: center;">
                                <asp:Label ID="lblClaveCiudadLlegada" runat="server" Text="KMTH" Font-Bold="false" Style="font-size: 20px;"></asp:Label><br />
                                <asp:Label ID="lblClaveCiudadLlegadaRes" runat="server" Text="The Florida Keys Marathon" Font-Bold="false" Style=""></asp:Label>
                            </div>
                        </div>
                        <br />
                        <hr style="border-bottom: 1px solid #E6E9ED; margin: 0px;" />
                        <div class="row">
                            <div class="col-md-4" style="text-align: center;">
                                <asp:Label ID="lblDMASalida" runat="server" Text="4 Abr. 2021" Font-Bold="false" Style=""></asp:Label>&nbsp;
                    <asp:Label ID="lblDMAHoraSalida" runat="server" Text="04:00 am EDT" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-4" style="text-align: center;">
                                &nbsp;
                            </div>
                            <div class="col-md-4" style="text-align: center;">
                                <asp:Label ID="lblDMALLegada" runat="server" Text="4 Abr. 2021" Font-Bold="false" Style=""></asp:Label>&nbsp;
                    <asp:Label ID="lblDMAHoraLLegada" runat="server" Text="06:00 am EDT" Font-Bold="false" Style=""></asp:Label>
                            </div>
                        </div>
                        <hr style="border-bottom: 1px solid #E6E9ED; margin: 0px;" />
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <h2 style="color: #BDBDBD;">
                                    <asp:Label ID="lblInformacionGeneral" runat="server" Text="Información General" Font-Bold="true"></asp:Label>
                                </h2>
                                <hr style="border-bottom: 1px solid #E6E9ED; margin-top: -1px;" />
                            </div>
                        </div>
                        <div class="row" style="background-color: #00000008;">
                            <div class="col" style="text-align: left;">&nbsp;</div>
                            <div class="col-md-3" style="text-align: left;">
                                <i class="fa fa-plane"></i>
                                <asp:Label ID="lblAeronave" runat="server" Text="Aeronave" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-5" style="text-align: center;">
                                <asp:Label ID="lblAeronaveRes" runat="server" Text="N849WC" Font-Bold="true" Style=""></asp:Label>
                            </div>
                            <div class="col" style="text-align: left;">&nbsp;</div>
                        </div>
                        <br />
                        <div class="row" style="background-color: #00000008;">


                            <div class="col-md-3" style="text-align: left; border: 1px solid #ffffff;">
                                <i class="fa fa-space-shuttle"></i>
                                <asp:Label ID="lblTipoEvento" runat="server" Text="Tipo de Evento" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-3" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblTipoEventoRes" runat="server" Text="Vuelo" Font-Bold="true" Style=""></asp:Label>
                            </div>
                            <div class="col-md-3" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblViajeNumero" runat="server" Text="Viaje Número" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-3" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblViajeNumeroRes" runat="server" Text="1000012-21" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="background-color: #00000008;">


                            <div class="col-md-3" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblTipoVuelo" runat="server" Text="Tipo de Vuelo" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-3" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblTipoVueloRes" runat="server" Text="Dueño - Abordo" Font-Bold="true" Style=""></asp:Label>
                            </div>
                            <div class="col-md-3" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblNombreContacto" runat="server" Text="Nombre de Contacto" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-3" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblNombreContactoRes" runat="server" Text="Empresa Inc." Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="background-color: #00000008;">

                            <div class="col-md-3" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lalSolicitante" runat="server" Text="Solicitante" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-3" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lalSolicitanteRes" runat="server" Text="Jhonson Thomas" Font-Bold="true" Style=""></asp:Label>
                            </div>
                            <div class="col-md-3" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblObjetivo" runat="server" Text="Objetivo" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-3" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblObjetivoRes" runat="server" Text="---" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="background-color: #00000008;">

                            <div class="col-md-3" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblRegulacion" runat="server" Text="Regulación" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-3" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblRegulacionRes" runat="server" Text="Part 91" Font-Bold="true" Style=""></asp:Label>
                            </div>
                            <div class="col-md-3" style="text-align: left; border-bottom: 1px solid #ffffff;">
                                <asp:Label ID="lblEstatus" runat="server" Text="Estatus" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-3" style="text-align: left; border-bottom: 1px solid #ffffff;">
                                <asp:Label ID="lblEstatusRes" runat="server" Text="Completado" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <br />
                        <div class="row" style="background-color: #00000008;">
                            <div class="col">&nbsp;</div>
                            <div class="col-md-3" style="text-align: left; border-bottom: 1px solid #ffffff;">
                                <i class="fa fa-align-justify"></i>
                                <asp:Label ID="lblDescripcion" runat="server" Text="Descripción" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-5" style="text-align: left; border-bottom: 1px solid #ffffff;">
                                <asp:Label ID="lblDescripcionRes" runat="server" Text="viaje de negocios: CFO Meeting " Font-Bold="true" Style=""></asp:Label>
                            </div>
                            <div class="col">&nbsp;</div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <h2 style="color: #BDBDBD;">
                                    <asp:Label ID="lbldesdeA" runat="server" Text="Salida de: &#x2794; Llegada a:" Font-Bold="true"></asp:Label>
                                </h2>
                                <hr style="border-bottom: 1px solid #E6E9ED; margin-top: -1px;" />
                            </div>
                        </div>
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <span style="font-size: 18px;">&#x1f6eb;&#xfe0e;</span>
                                <asp:Label ID="lblAeropuertoSalida" runat="server" Text="Aeropuerto de Salida" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-8" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblAeropuertoSalidaRes" runat="server" Text="Teterboro, Teterboro, US (KTEB)" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblFueraFechaBloque" runat="server" Text="Fecha Fuera del Bloque" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-2" style="text-align: left; border: 1px solid #ffffff;">
                                <i class="fa fa-calendar"></i>
                                <asp:Label ID="lblFueraFechaBloqueRes" runat="server" Text="04/04/2021" Font-Bold="true" Style=""></asp:Label>
                            </div>
                            <div class="col-md-4" style="text-align: left; border-bottom: 1px solid #ffffff;">
                                <asp:Label ID="lblFueraTiempoBloque" runat="server" Text="Tiempo Fuera Bloque" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-2" style="text-align: left; border-bottom: 1px solid #ffffff;">
                                <i class="fa fa-clock-o"></i>
                                <asp:Label ID="lblFueraTiempoBloqueRes" runat="server" Text="03:52 am" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblFechaDeSalida" runat="server" Text="Fecha de Salida" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-2" style="text-align: left; border: 1px solid #ffffff;">
                                <i class="fa fa-calendar"></i>
                                <asp:Label ID="lblFechaDeSalidaRes" runat="server" Text="04/04/2021" Font-Bold="true" Style=""></asp:Label>
                            </div>
                            <div class="col-md-4" style="text-align: left; border-bottom: 1px solid #ffffff;">
                                <asp:Label ID="lblHoraSalida" runat="server" Text="Hora de Salida" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-2" style="text-align: left; border-bottom: 1px solid #ffffff;">
                                <i class="fa fa-clock-o"></i>
                                <asp:Label ID="lblHoraSalidaRes" runat="server" Text="04:00 am" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblZonaHoraria" runat="server" Text="Zona Horaria" Font-Bold="false" Style=""></asp:Label>
                                <i class="fa fa-globe"></i>
                            </div>
                            <div class="col-md-8" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblZonaHorariaRes" runat="server" Text="Tiempo Local" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <br />
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <i class="fa fa-map-marker"></i>
                                <asp:Label ID="lblAeropuertoLLegada" runat="server" Text="Aeropuerto de Llegada" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-8" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblAeropuertoLLegadaRes" runat="server" Text="The Florida Keys Marathon, Marathon, US (KMTH)" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblFhechaArrivo" runat="server" Text="Fecha de Arrivo" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-2" style="text-align: left; border: 1px solid #ffffff;">
                                <i class="fa fa-calendar"></i>
                                <asp:Label ID="lblFhechaArrivoRes" runat="server" Text="04/04/2021" Font-Bold="true" Style=""></asp:Label>
                            </div>
                            <div class="col-md-4" style="text-align: left; border-bottom: 1px solid #ffffff;">
                                <asp:Label ID="lblHoraArrivo" runat="server" Text="Hora de Arrivo" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-2" style="text-align: left; border-bottom: 1px solid #ffffff;">
                                <i class="fa fa-clock-o"></i>
                                <asp:Label ID="lblHoraArrivoRes" runat="server" Text="06:40 am" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblFechaBloque" runat="server" Text="Fecha de Bloque" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-2" style="text-align: left; border: 1px solid #ffffff;">
                                <i class="fa fa-calendar"></i>
                                <asp:Label ID="lblFechaBloqueRes" runat="server" Text="04/04/2021" Font-Bold="true" Style=""></asp:Label>
                            </div>
                            <div class="col-md-4" style="text-align: left; border-bottom: 1px solid #ffffff;">
                                <asp:Label ID="lblTiempoBloque" runat="server" Text="Hora de Bloque" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-2" style="text-align: left; border-bottom: 1px solid #ffffff;">
                                <i class="fa fa-clock-o"></i>
                                <asp:Label ID="Label11" runat="server" Text="04:00 am" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblZonaHorariaLlegada" runat="server" Text="Zona Horaria" Font-Bold="false" Style=""></asp:Label>
                                <i class="fa fa-globe"></i>
                            </div>
                            <div class="col-md-8" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="Label13" runat="server" Text="Tiempo Local" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <h2 style="color: #BDBDBD;">
                                    <asp:Label ID="lblPasajerosGeneral" runat="server" Text="Pasajeros" Font-Bold="true"></asp:Label>
                                </h2>
                                <hr style="border-bottom: 1px solid #E6E9ED; margin-top: -1px;" />
                            </div>
                        </div>
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <i class="fa fa-group"></i>
                                <asp:Label ID="lblPasajeros" runat="server" Text="Pasajeros" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-8" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblPasajerosResUno" runat="server" Text="Nombre 0" Font-Bold="true" Style=""></asp:Label>
                                <asp:Label ID="lblPasajerosResDos" runat="server" Text="Nombre 2" Font-Bold="true" Style=""></asp:Label>
                                <asp:Label ID="lblPasajerosRestres" runat="server" Text="Nombre 3" Font-Bold="true" Style=""></asp:Label>
                                <asp:Label ID="lblPasajerosResCuatro" runat="server" Text="Nombre 4" Font-Bold="true" Style=""></asp:Label>
                                <asp:Label ID="lblPasajerosResCinco" runat="server" Text="Nombre 5" Font-Bold="true" Style=""></asp:Label>
                                <asp:Label ID="lblPasajerosResSeis" runat="server" Text="Nombre 6" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblNumeroPasajeros" runat="server" Text="Número Pasajeros" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-8" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblNumeroPasajerosRes" runat="server" Text="6" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <h2 style="color: #BDBDBD;">
                                    <asp:Label ID="lblTripulacion" runat="server" Text="Tripulación" Font-Bold="true"></asp:Label>
                                </h2>
                                <hr style="border-bottom: 1px solid #E6E9ED; margin-top: -1px;" />
                            </div>
                        </div>
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <i class="fa fa-male"></i>
                                <asp:Label ID="lblTripulacionMiembros" runat="server" Text="Miembros Tripulación" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-8" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblTrpulacionUno" runat="server" Text="Tripulación 0" Font-Bold="true" Style=""></asp:Label>
                                <asp:Label ID="lblTrpulacionDos" runat="server" Text="Tripulación 2" Font-Bold="true" Style=""></asp:Label>
                                <asp:Label ID="lblTrpulacionTres" runat="server" Text="Tripulación 3" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <h2 style="color: #BDBDBD;">
                                    <asp:Label ID="lblDatosVuelo" runat="server" Text="Datos de Vuelo" Font-Bold="true"></asp:Label>
                                </h2>
                                <hr style="border-bottom: 1px solid #E6E9ED; margin-top: -1px;" />
                            </div>
                        </div>
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <span style="font-size: 18px;">&#x2b6c;</span>&nbsp;&nbsp;<asp:Label ID="lblDistancia" runat="server" Text="Distancia" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-8" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblDistanciaRes" runat="server" Text="1,181.9" Font-Bold="true" Style=""></asp:Label>
                                <asp:Label ID="lblMillas" runat="server" Text="mi" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblDatosTiempoVuelo" runat="server" Text="Tiempo de Vuelo" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-8" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblDatosTiempoVueloRes" runat="server" Text="2h 40m" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblDatosBloqueTiempo" runat="server" Text="Bloque de Tiempo" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-8" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblDatosBloqueTiempoRes" runat="server" Text="3h 01m" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <h2 style="color: #BDBDBD;">
                                    <asp:Label ID="lblFBO" runat="server" Text="FBO" Font-Bold="true"></asp:Label>
                                </h2>
                                <hr style="border-bottom: 1px solid #E6E9ED; margin-top: -1px;" />
                            </div>
                        </div>
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <span style="font-size: 18px;">&#x1f6eb;&#xfe0e;</span>
                                <asp:Label ID="lblSalidaFBO" runat="server" Text="Salida FBO" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-8" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblSalidaFBORes" runat="server" Text="Portside, Inc" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblTel" runat="server" Text="Teléfono" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-8" style="text-align: left; border: 1px solid #ffffff;">
                                <i class="fa fa-phone"></i>
                                <asp:Label ID="lblTelRes" runat="server" Text="415.849.1909" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <%--<div class="row" style="background-color:#00000008;">
                <div class="col-md-4" style="text-align:left; border:1px solid #ffffff;">
                    <asp:Label ID="lblEmail" runat="server" Text="Email" Font-Bold="false" style=""></asp:Label>
                </div>
                <div class="col-md-8" style="text-align:left; border:1px solid #ffffff;">
                    <i class="fa fa-envelope-o"></i> <asp:Label ID="lblEmailRes" runat="server" Text="support@ale.com" Font-Bold="true" style=""></asp:Label>
                </div>
            </div>--%>
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblDireccion" runat="server" Text="Dirección" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-8" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblDireccionRes" runat="server" Text="Dirección completa" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <%--<div class="row" style="background-color:#00000008;">
                <div class="col-md-4" style="text-align:left; border:1px solid #ffffff;">
                    <asp:Label ID="lblNotas" runat="server" Text="Notas" Font-Bold="false" style=""></asp:Label>
                </div>
                <div class="col-md-8" style="text-align:left; border:1px solid #ffffff;">
                    <asp:Label ID="lblNotasRes" runat="server" Text="---" Font-Bold="true" style=""></asp:Label>
                </div>
            </div>--%>
                        <br />
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <span style="font-size: 18px;">&#x1f6eb;&#xfe0e;</span>
                                <asp:Label ID="lblLLEgada" runat="server" Text="LLegada FBO" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-8" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblLLEgadaRes" runat="server" Text="Portside, Inc" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblTelLLegada" runat="server" Text="Teléfono" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-8" style="text-align: left; border: 1px solid #ffffff;">
                                <i class="fa fa-phone"></i>
                                <asp:Label ID="lblTelLLegadaRes" runat="server" Text="415.849.1909" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <%--<div class="row" style="background-color:#00000008;">
                <div class="col-md-4" style="text-align:left; border:1px solid #ffffff;">
                    <asp:Label ID="lblEmailLLegada" runat="server" Text="Email" Font-Bold="false" style=""></asp:Label>
                </div>
                <div class="col-md-8" style="text-align:left; border:1px solid #ffffff;">
                    <i class="fa fa-envelope-o"></i> <asp:Label ID="lblEmailLLegadaRes" runat="server" Text="support@ale.com" Font-Bold="true" style=""></asp:Label>
                </div>
            </div>--%>
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblDireccioLLegada" runat="server" Text="Dirección" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-8" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblDireccioLLegadaRes" runat="server" Text="Dirección completa" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <%--<div class="row" style="background-color:#00000008;">
                <div class="col-md-4" style="text-align:left; border:1px solid #ffffff;">
                    <asp:Label ID="lblNotasLLegada" runat="server" Text="Notas" Font-Bold="false" style=""></asp:Label>
                </div>
                <div class="col-md-8" style="text-align:left; border:1px solid #ffffff;">
                    <asp:Label ID="lblNotasLLegadaRes" runat="server" Text="---" Font-Bold="true" style=""></asp:Label>
                </div>
            </div>--%>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <h2 style="color: #BDBDBD;">
                                    <asp:Label ID="lblCatering" runat="server" Text="Catering y Transporte" Font-Bold="true"></asp:Label>
                                </h2>
                                <hr style="border-bottom: 1px solid #E6E9ED; margin-top: -1px;" />
                            </div>
                        </div>
                        <%--<div class="row" style="background-color:#00000008;">
                <div class="col-md-4" style="text-align:left; border:1px solid #ffffff;">
                    <i class="fa fa-cutlery"></i> <asp:Label ID="lblcateringDos" runat="server" Text="Catering" Font-Bold="false" style=""></asp:Label>
                </div>
                <div class="col-md-8" style="text-align:left; border:1px solid #ffffff;">
                    <asp:Label ID="lblcateringDosRes" runat="server" Text="Portside, Inc" Font-Bold="true" style=""></asp:Label>
                </div>
            </div>
            <div class="row" style="background-color:#00000008;">
                <div class="col-md-4" style="text-align:left; border:1px solid #ffffff;">
                    <asp:Label ID="lblCateringTel" runat="server" Text="Teléfono" Font-Bold="false" style=""></asp:Label>
                </div>
                <div class="col-md-8" style="text-align:left; border:1px solid #ffffff;">
                    <i class="fa fa-phone"></i> <asp:Label ID="lblCateringTelRes" runat="server" Text="415.849.1909" Font-Bold="true" style=""></asp:Label>
                </div>
            </div>
            <div class="row" style="background-color:#00000008;">
                <div class="col-md-4" style="text-align:left; border:1px solid #ffffff;">
                    <asp:Label ID="lblCateringTelEmail" runat="server" Text="Email" Font-Bold="false" style=""></asp:Label>
                </div>
                <div class="col-md-8" style="text-align:left; border:1px solid #ffffff;">
                    <i class="fa fa-envelope-o"></i> <asp:Label ID="lblCateringTelEmailRes" runat="server" Text="support@ale.com" Font-Bold="true" style=""></asp:Label>
                </div>
            </div>--%>
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <i class="fa fa-cutlery"></i>- <i class="fa fa-car"></i>
                                <asp:Label ID="lblCateringTelNotas" runat="server" Text="Notas" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-8" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblCateringTelNotasRes" runat="server" Text="---" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <%--<br />
            <div class="row">
                <div class="col-md-12">
                    <h2 style="color:#BDBDBD;">
                        <asp:Label ID="lblTransporte" runat="server" Text="Transporte" Font-Bold="true"></asp:Label>
                    </h2>
                    <hr style="border-bottom: 1px solid #E6E9ED; margin-top:-1px;" />
                </div>
            </div>
            <div class="row" style="background-color:#00000008;">
                <div class="col-md-4" style="text-align:left; border:1px solid #ffffff;">
                    <i class="fa fa-car"></i> <asp:Label ID="lblSalidaTransporte" runat="server" Text="Salida Transporte" Font-Bold="false" style=""></asp:Label>
                </div>
                <div class="col-md-8" style="text-align:left; border:1px solid #ffffff;">
                    <asp:Label ID="lblSalidaTransporteRes" runat="server" Text="Portside, Inc" Font-Bold="true" style=""></asp:Label>
                </div>
            </div>
            <div class="row" style="background-color:#00000008;">
                <div class="col-md-4" style="text-align:left; border:1px solid #ffffff;">
                    <asp:Label ID="lblTransporteTel" runat="server" Text="Teléfono" Font-Bold="false" style=""></asp:Label>
                </div>
                <div class="col-md-8" style="text-align:left; border:1px solid #ffffff;">
                    <i class="fa fa-phone"></i> <asp:Label ID="lblTransporteTelRes" runat="server" Text="415.849.1909" Font-Bold="true" style=""></asp:Label>
                </div>
            </div>
            <div class="row" style="background-color:#00000008;">
                <div class="col-md-4" style="text-align:left; border:1px solid #ffffff;">
                    <asp:Label ID="lblTransporteEmail" runat="server" Text="Email" Font-Bold="false" style=""></asp:Label>
                </div>
                <div class="col-md-8" style="text-align:left; border:1px solid #ffffff;">
                    <i class="fa fa-envelope-o"></i> <asp:Label ID="lblTransporteEmailRes" runat="server" Text="support@ale.com" Font-Bold="true" style=""></asp:Label>
                </div>
            </div>
            <div class="row" style="background-color:#00000008;">
                <div class="col-md-4" style="text-align:left; border:1px solid #ffffff;">
                    <asp:Label ID="lblTransporteNotas" runat="server" Text="Notas" Font-Bold="false" style=""></asp:Label>
                </div>
                <div class="col-md-8" style="text-align:left; border:1px solid #ffffff;">
                    <asp:Label ID="lblTransporteNotasRes" runat="server" Text="---" Font-Bold="true" style=""></asp:Label>
                </div>
            </div>
            <br />
            <div class="row" style="background-color:#00000008;">
                <div class="col-md-4" style="text-align:left; border:1px solid #ffffff;">
                    <i class="fa fa-car"></i> <asp:Label ID="lblTransporteLLegada" runat="server" Text="LLegada Transporte" Font-Bold="false" style=""></asp:Label>
                </div>
                <div class="col-md-8" style="text-align:left; border:1px solid #ffffff;">
                    <asp:Label ID="lblTransporteLLegadaRes" runat="server" Text="Portside, Inc" Font-Bold="true" style=""></asp:Label>
                </div>
            </div>
            <div class="row" style="background-color:#00000008;">
                <div class="col-md-4" style="text-align:left; border:1px solid #ffffff;">
                    <asp:Label ID="lblTransporteLLegadaTel" runat="server" Text="Teléfono" Font-Bold="false" style=""></asp:Label>
                </div>
                <div class="col-md-8" style="text-align:left; border:1px solid #ffffff;">
                    <i class="fa fa-phone"></i> <asp:Label ID="lblTransporteLLegadaTelRes" runat="server" Text="415.849.1909" Font-Bold="true" style=""></asp:Label>
                </div>
            </div>
            <div class="row" style="background-color:#00000008;">
                <div class="col-md-4" style="text-align:left; border:1px solid #ffffff;">
                    <asp:Label ID="lblTransporteLLegadaEmail" runat="server" Text="Email" Font-Bold="false" style=""></asp:Label>
                </div>
                <div class="col-md-8" style="text-align:left; border:1px solid #ffffff;">
                    <i class="fa fa-envelope-o"></i> <asp:Label ID="lblTransporteLLegadaEmailRes" runat="server" Text="support@ale.com" Font-Bold="true" style=""></asp:Label>
                </div>
            </div>
            <div class="row" style="background-color:#00000008;">
                <div class="col-md-4" style="text-align:left; border:1px solid #ffffff;">
                    <asp:Label ID="lblTransporteLLegadaNotas" runat="server" Text="Notas" Font-Bold="false" style=""></asp:Label>
                </div>
                <div class="col-md-8" style="text-align:left; border:1px solid #ffffff;">
                    <asp:Label ID="lblTransporteLLegadaNotasRes" runat="server" Text="---" Font-Bold="true" style=""></asp:Label>
                </div>
            </div>--%>
                        <br />
                    </div>
                    <!-- fin contenido modal RLR-->
                </div>
                <div class="modal-footer">
                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-secondary" Text="Cerrar" Font-Bold="true" OnClientClick="CloseModal();" />

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
