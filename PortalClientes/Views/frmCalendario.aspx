<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmCalendario.aspx.cs" Inherits="PortalClientes.Views.frmCalendario" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v18.1, Version=18.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link href="../toastr/toastr.min.css" rel="stylesheet" />--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
    </div>
    <div class="row">
        <div class="col-md-12 col-sm-12">
            <div class="x_panel">
                <div class="x_title">
                    <h2>
                        <asp:Label ID="lblCalendario" runat="server" Text="Calendario" Font-Bold="true"></asp:Label></h2>
                    <%--<ul class="nav navbar-right panel_toolbox">
                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                    <li><a class="close-link"><i class="fa fa-close"></i></a>
                    </li>
                </ul>--%>
                    <div class="clearfix"></div>
                </div>
                <div class="row">
                    <div class="col-md-12">
                        <dx:BootstrapScheduler ID="SchedulerRecurenceInfo" AppointmentDataSourceID="ObjectDataSource1" runat="server" ActiveViewType="month">
                            <Storage>
                                <Appointments AutoRetrieveId="true">
                                    <Mappings AppointmentId="ID" Start="StartTime" End="EndTime" Subject="Subject"
                                        Description="Description" Location="Location"
                                        Type="EventType" Label="Label" Status="Status" />
                                </Appointments>
                            </Storage>
                            <Views>
                                <DayView ResourcesPerPage="1" ShowWorkTimeOnly="true">
                                    <WorkTime Start="8:00" End="19:00" />
                                </DayView>
                                <WorkWeekView ResourcesPerPage="1" ShowWorkTimeOnly="true">
                                    <WorkTime Start="8:00" End="19:00" />
                                </WorkWeekView>
                                <FullWeekView ResourcesPerPage="1" Enabled="true" ShowWorkTimeOnly="true">
                                    <WorkTime Start="8:00" End="19:00" />
                                </FullWeekView>
                                <WeekView ResourcesPerPage="1">
                                </WeekView>
                                <MonthView ResourcesPerPage="1">
                                </MonthView>
                                <TimelineView ResourcesPerPage="1" IntervalCount="1">
                                </TimelineView>
                                <AgendaView ScrollAreaHeight="600">
                                </AgendaView>
                            </Views>
                            <OptionsBehavior ShowViewSelector="true" />
                        </dx:BootstrapScheduler>
                        <asp:ObjectDataSource
                            ID="ObjectDataSource1"
                            runat="server"
                            SelectMethod="getAllAppoinments"
                            TypeName="PortalClientes.Views.frmCalendario" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
    <%--<script src='<%=ResolveUrl("../toastr/toastr.min.js")%>'></script>--%>

    <script type="text/javascript">

        function alertexito(mensaje) {
            toastr.success("Mensaje de exito");
        }

        $(document).ready(function () {
            $('#btnAlerta').click(function () {
                //toastr['warning']('Mensaje de prueba', 'Titulo del mensaje');
                toastr.success("Mensaje de exito");
            });
        });

        //toastr.options = {
        //  "closeButton": true,
        //  "debug": false,
        //  "newestOnTop": false,
        //  "progressBar": true,
        //  "positionClass": "toast-top-right",
        //  "preventDuplicates": false,
        //  "onclick": null,
        //  "showDuration": "3000",
        //  "hideDuration": "3000",
        //  "timeOut": "5000",
        //  "extendedTimeOut": "1000",
        //  "showEasing": "swing",
        //  "hideEasing": "linear",
        //  "showMethod": "fadeIn",
        //  "hideMethod": "fadeOut"
        //}

    </script>
</asp:Content>
