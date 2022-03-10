<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmCalendario.aspx.cs" Inherits="PortalClientes.Views.frmCalendario" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v18.1, Version=18.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register TagPrefix="cc1" Namespace="DevExpress.XtraScheduler" Assembly="DevExpress.XtraScheduler.v18.1.Core, Version=18.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dxwschs" Namespace="DevExpress.Web.ASPxScheduler" Assembly="DevExpress.Web.ASPxScheduler.v18.1, Version=18.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v18.1, Version=18.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../build/js/scheduler.js?n=1"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upaPrincipal" runat="server">
        <ContentTemplate>
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
                                <div class="row">
                                    <div class="col-md-4" style="text-align: left;">
                                        <h2 style="color: #008000;font-weight: bold;"><span style="border:1px solid #008000; border-radius:50%; padding:1px;background-color:#008000; color:#ffffff;">&nbsp;&nbsp;!&nbsp;&nbsp;</span>&nbsp;<asp:Label ID="lblDeClickVerEvento" runat="server" Text="De click en el evento para ver la información" Font-Bold="true"></asp:Label> </h2>
                                    </div>
                                    <div class="col-md-8" style="text-align: right;">
                                        <asp:Button runat="server" ID="btnActiveDay" OnClick="btnActiveView_Click" data-view="Day" Text="Hoy" CssClass="btn btn-secondary" Visible="false"  />
                                        <asp:Button runat="server" ID="btnActiveWorkWeek" OnClick="btnActiveView_Click" data-view="WorkWeek" Text="Semanal" CssClass="btn btn-secondary" Visible="false"  />
                                        <!--<asp:Button runat="server" ID="btnActiveMonth" OnClick="btnActiveView_Click" data-view="Month" Text="Mensual" CssClass="btn btn-primary" /> -->
                                        <asp:Button runat="server" ID="btnActiveTimeLine" OnClick="btnActiveView_Click" data-view="Timeline" Text="TimeLine" CssClass="btn btn-secondary" Visible="false"  />
                                        <asp:Button runat="server" ID="btnActiveAgenda" OnClick="btnActiveView_Click" data-view="Agenda" Text="Agenda" CssClass="btn btn-secondary" Visible="false" />    
                                    </div>
                                </div>
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
                                        AppointmentClick="function(s, e) { ClickAppointment(s, e); }"
                                        MouseUp="function(s, e) { Click(s, e,9); }" />
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
                                            <CellAutoHeightOptions Mode="LimitHeight" MinHeight="100" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:HiddenField ID="hfdate" runat="server" />
    <asp:HiddenField ID="hdTargetDescription" runat="server" />
    <cc1:ModalPopupExtender ID="modalDescription" runat="server" TargetControlID="hdTargetDescription"
        PopupControlID="pnlDescription" BackgroundCssClass="overlayy">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlDescription" runat="server" BorderColor="" BackColor="White" Height="" HorizontalAlign="Center"
        Width="" CssClass="modal-derecha anim_RLR">
        <asp:UpdatePanel ID="upaUsuario" runat="server">
            <ContentTemplate>

                <asp:Button ID="Button1" runat="server" CssClass="btn" Text="X" Font-Bold="true" OnClientClick="CloseModal();" Style="z-index: 2000; right: 13px; margin-top: 10px; position: absolute; color: #ffffff;" />
                <h5 class="modal-title" style="color: #ffffff; background-color: #2a3f54; width: 100%; height: 70px; padding-top: 15px;">
                    <asp:Label ID="lblDetallesVuelo" runat="server" Text="Detalles de Vuelo" Font-Bold="true"></asp:Label></h5>
                <!-- inicio contenido modal RLR-->
                <div style="padding: 5px;">
                    <div class="row">
                        <div class="col-md-9" style="text-align: left;">
                        </div>
                        <div class="col-md-3" style="text-align: right;">
                            <asp:LinkButton ID="btnExcel" runat="server" Text="<i class='fa fa-file-pdf-o' style='color:#73879c;font-size:25px;'></i>" CssClass="btn" OnClientClick="LoadingTime(15)" OnClick="lkbExpPDFRes_Click" />
                            <%--<asp:LinkButton ID="btnPDF" runat="server" Text="<i class='fa fa-print' style='color:#73879c;font-size:25px;'></i>" CssClass="btn" />--%>
                        </div>
                    </div>
                    <hr style="border-bottom: 2px solid #E6E9ED; margin-top: -1px;" />

                    <div>
                        <div class="row">
                            <div class="col-md-4" style="text-align: center;">
                                <asp:Label ID="lblClaveCiudadSalida" runat="server" Text="KTEB" Font-Bold="false" Style="font-size: 20px; font-weight:bold;"></asp:Label><br />
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
                                <asp:Label ID="lblClaveCiudadLlegada" runat="server" Text="KMTH" Font-Bold="false" Style="font-size: 20px; font-weight:bold;"></asp:Label><br />
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
                                <i class="fa fa-plane"></i>
                                <asp:Label ID="lblAeronave" runat="server" Text="Aeronave" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-3" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblAeronaveRes" runat="server" Text="N849WC" Font-Bold="true" Style=""></asp:Label>
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
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-3" style="text-align: left; border: 1px solid #ffffff;">
                                <span style="font-size: 18px;">&#x2b6c;</span>&nbsp;&nbsp;<asp:Label ID="lblDistancia" runat="server" Text="Distancia" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-3" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblDistanciaRes" runat="server" Text="1,181.9" Font-Bold="true" Style=""></asp:Label>
                                <asp:Label ID="lblMillas" runat="server" Text="mi" Font-Bold="true" Style=""></asp:Label>
                            </div>
                            <div class="col-md-3" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblDatosTiempoVuelo" runat="server" Text="Tiempo de Vuelo" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-3" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblDatosTiempoVueloRes" runat="server" Text="2h 40m" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <br />
                        <div class="row" style="background-color: #00000008;">
                            <div class="col">&nbsp;</div>
                            <div class="col-md-4" style="text-align: center; border-bottom: 1px solid #ffffff;">
                                <i class="fa fa-align-justify"></i>
                                <asp:Label ID="lblDescripcion" runat="server" Text="Descripción" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-4" style="text-align: center; border-bottom: 1px solid #ffffff;">
                                <asp:Label ID="lblDescripcionRes" runat="server" Text="viaje de negocios: CFO Meeting " Font-Bold="true" Style=""></asp:Label>
                            </div>
                            <div class="col">&nbsp;</div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <h2 style="color: #BDBDBD;">
                                    <asp:Label ID="lbldesdeA" runat="server" Text="Salida de:" Font-Bold="true"></asp:Label>
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
                            <div class="col-md-3" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblFechaDeSalida" runat="server" Text="Fecha de Salida" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-5" style="text-align: left; border: 1px solid #ffffff;">
                                <i class="fa fa-calendar"></i>
                                <asp:Label ID="lblFechaDeSalidaRes" runat="server" Text="04/04/2021" Font-Bold="true" Style=""></asp:Label>
                            </div>
                            <div class="col-md-2" style="text-align: left; border-bottom: 1px solid #ffffff;">
                                <asp:Label ID="lblHoraSalida" runat="server" Text="Hora de Salida" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-2" style="text-align: left; border-bottom: 1px solid #ffffff;">
                                <i class="fa fa-clock-o"></i>
                                <asp:Label ID="lblHoraSalidaRes" runat="server" Text="04:00 am" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-3" style="text-align: left; border: 1px solid #ffffff;">
                                <i class="fa fa-globe"></i>
                                <asp:Label ID="lblZonaHoraria" runat="server" Text="Zona Horaria" Font-Bold="false" Style=""></asp:Label>

                            </div>
                            <div class="col-md-9" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblZonaHorariaRes" runat="server" Text="Tiempo Local" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <br />
                        <h2 style="color: #BDBDBD;">
                            <asp:Label ID="lblllegadaa" runat="server" Text="Llegada a:" Font-Bold="true"></asp:Label>
                        </h2>
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <span style="font-size: 18px;">&#x1f6ec;&#xfe0e;</span>
                                <asp:Label ID="lblAeropuertoLLegada" runat="server" Text="Aeropuerto de Llegada" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-8" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblAeropuertoLLegadaRes" runat="server" Text="The Florida Keys Marathon, Marathon, US (KMTH)" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-3" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblFhechaArrivo" runat="server" Text="Fecha de Arrivo" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-5" style="text-align: left; border: 1px solid #ffffff;">
                                <i class="fa fa-calendar"></i>
                                <asp:Label ID="lblFechaArrivoRes" runat="server" Text="04/04/2021" Font-Bold="true" Style=""></asp:Label>
                            </div>
                            <div class="col-md-2" style="text-align: left; border-bottom: 1px solid #ffffff;">
                                <asp:Label ID="lblHoraArrivo" runat="server" Text="Hora de Arrivo" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-2" style="text-align: left; border-bottom: 1px solid #ffffff;">
                                <i class="fa fa-clock-o"></i>
                                <asp:Label ID="lblHoraArrivoRes" runat="server" Text="06:40 am" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <i class="fa fa-globe"></i>
                                <asp:Label ID="lblZonaHorariaLlegada" runat="server" Text="Zona Horaria" Font-Bold="false" Style=""></asp:Label>
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
                                <asp:Label ID="lblNumeroPasajeros" runat="server" Text="Número Pasajeros" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-8" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblNumeroPasajerosRes" runat="server" Text="6" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <i class="fa fa-group"></i>
                                <asp:Label ID="lblPasajeros" runat="server" Text="Pasajeros" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-8" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblPasajerosRes" runat="server" Text="Nombre 0" Font-Bold="true" Style=""></asp:Label>
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
                                <asp:Label ID="lblTrpulacionRes" runat="server" Text="Tripulación 0" Font-Bold="true" Style=""></asp:Label>
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
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblDireccion" runat="server" Text="Dirección" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-8" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblDireccionRes" runat="server" Text="Dirección completa" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <br />
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <span style="font-size: 18px;">&#x1f6ec;&#xfe0e;</span>
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
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblDireccioLLegada" runat="server" Text="Dirección" Font-Bold="false" Style=""></asp:Label>
                            </div>
                            <div class="col-md-8" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblDireccioLLegadaRes" runat="server" Text="Dirección completa" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <h2 style="color: #BDBDBD;">
                                    <asp:Label ID="lblCatering" runat="server" Text="Catering y Transporte" Font-Bold="true"></asp:Label>
                                </h2>
                                <hr style="border-bottom: 1px solid #E6E9ED; margin-top: -1px;" />
                            </div>
                        </div>
                        <div class="row" style="background-color: #00000008;">
                            <div class="col-md-4" style="text-align: left; border: 1px solid #ffffff;">
                                <i class="fa fa-cutlery"></i>- <i class="fa fa-car"></i>
                                <%--<asp:Label ID="lblCateringTelNotas" runat="server" Text="Notas" Font-Bold="false" Style=""></asp:Label>--%>
                            </div>
                            <div class="col-md-8" style="text-align: left; border: 1px solid #ffffff;">
                                <asp:Label ID="lblCateringTelNotasRes" runat="server" Text="---" Font-Bold="true" Style=""></asp:Label>
                            </div>
                        </div>
                        <br />
                    </div>
                    <!-- fin contenido modal RLR-->
                </div>
                <div class="modal-footer">
                    <asp:Button ID="Button2" runat="server" CssClass="btn btn-secondary" Text="Cerrar" Font-Bold="true" OnClientClick="CloseModal();" />
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="btnExcel" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
