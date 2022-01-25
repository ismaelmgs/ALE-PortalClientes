<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmFlights_Detalle.aspx.cs" Inherits="PortalClientes.Views.frmFlights_Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upaPrincipal" runat="server">
        <ContentTemplate>
            <%--<div class="row">
                <div class="col-md-6">
                    <div class="title_left">
                        <h3><asp:Label ID="lblFligthsDetalleHeader" runat="server" Text=" Vuelos - Detalle" Font-Bold="false"></asp:Label></h3>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="title_right">
                        <%--<div class="col-md-5 col-sm-5   form-group pull-right top_search">
                            <div class="input-group">
                            </div>
                        </div>--
                    </div>
                </div>
            </div>--%>
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2>
                                <asp:Label ID="lblFligthsDetalle" runat="server" Text="Vuelos - Detalle" Font-Bold="true"></asp:Label></h2>
                            <div class="clearfix"></div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
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
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
