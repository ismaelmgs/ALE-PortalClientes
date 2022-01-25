<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmFlights.aspx.cs" Inherits="PortalClientes.Views.frmFlights" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upaPrincipal" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-6">
                    <div class="title_left">
                        <h3><asp:Label ID="lblFligthsHeader" runat="server" Text=" Vuelos" Font-Bold="false"></asp:Label></h3>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="row">
                            <div class="col-md-12">
                                <div>
                                    <br />
                                    <div class="row" style="margin: 5px;">
                                        <%--<div class="col-md-1 tile_count">&nbsp;</div>--%>
                                        <div class="col-md tile_count">
                                            <div class="tile_stats_count" style="text-align: center; background-image: none !important; border: 0px;">
                                                <span class="count_top">
                                                    <asp:Label ID="lblNumViajes" runat="server" Text=" Número de Viajes" Font-Bold="false"></asp:Label></span>
                                                <div class="count">
                                                    <asp:Label ID="lblNumViajesRes" runat="server" Text=" 00" Font-Bold="true" CssClass="count"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md tile_count">
                                            <div class="tile_stats_count" style="text-align: center; background-image: none !important; border: 0px;">
                                                <span class="count_top">
                                                    <asp:Label ID="lblNumVuelos" runat="server" Text=" Número de Vuelos" Font-Bold="false"></asp:Label></span>
                                                <div class="count">
                                                    <asp:Label ID="lblNumVuelosRes" runat="server" Text=" 00" Font-Bold="true" CssClass="count"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md tile_count">
                                            <div class="tile_stats_count" style="text-align: center; background-image: none !important; border: 0px;">
                                                <span class="count_top">
                                                    <asp:Label ID="lblAeropuertosVisitados" runat="server" Text=" Aeropuertos Visitados" Font-Bold="false"></asp:Label></span>
                                                <div class="count">
                                                    <asp:Label ID="lblAeropuertosVisitadosRes" runat="server" Text=" 00" Font-Bold="true" CssClass="count"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md tile_count">
                                            <div class="tile_stats_count" style="text-align: center; background-image: none !important; border: 0px;">
                                                <span class="count_top">
                                                    <asp:Label ID="lblHorasVuelo" runat="server" Text=" Horas de Vuelo" Font-Bold="false"></asp:Label></span>
                                                <div class="count">
                                                    <asp:Label ID="lblHorasVueloRes" runat="server" Text=" 20h 40m" Font-Bold="true" CssClass="count"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md tile_count">
                                            <div class="tile_stats_count" style="text-align: center; background-image: none !important; border: 0px;">
                                                <span class="count_top">
                                                    <asp:Label ID="lblTotalPasajeros" runat="server" Text=" Total de pasajeros" Font-Bold="false"></asp:Label></span>
                                                <div class="count">
                                                    <asp:Label ID="lblTotalPasajerosRes" runat="server" Text=" 000" Font-Bold="true" CssClass="count"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <%--<div class="col-md-1 tile_count">&nbsp;</div>--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                    <div class="x_panel">
                        <div class="x_title">
                            <div class="row">
                                <div class="col-md-6">
                                    <h2>
                                        <asp:Label ID="lblFlightsDos" runat="server" Text="Flights" Font-Bold="true"></asp:Label>
                                    </h2>
                                </div>
                                <div class="col-md-6">
                                    <asp:DropDownList ID="DDFiltroMeses" runat="server" AutoPostBack="true" CssClass="form-control" Width="100%" OnSelectedIndexChanged="DDFiltroMeses_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                        <div class="clearfix"></div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="table-responsive">
                            <div class="card-box table-responsive">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="gvVuelos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" ChildrenAsTriggers="False"
                                            AllowPaging="true" OnRowDataBound="gvVuelos_RowDataBound" onRowCommand="gvVuelos_RowCommand" EmptyDataText="No Registros">
                                            <HeaderStyle />
                                            <RowStyle />
                                            <AlternatingRowStyle />
                                            <Columns>
                                                <asp:BoundField DataField="numTrip" />
                                                <asp:BoundField DataField="origen" />
                                                <asp:BoundField DataField="destino" />
                                                <asp:BoundField DataField="pax" />
                                                <asp:BoundField DataField="fechaInicio" />
                                                <asp:BoundField DataField="FechaFin" />
                                                <asp:BoundField DataField="TiempoVolado" />
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                    <ItemTemplate>
                                                        <asp:LinkButton Font-Underline="True" ID="lkbDetalle" runat="server" Text="Detalle" CommandName="detail" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ContentTemplate>
                                   <Triggers>
                                       <asp:PostBackTrigger ControlID="gvVuelos" />
                                   </Triggers>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
