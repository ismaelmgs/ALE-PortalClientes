<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmMapaflota.aspx.cs" Inherits="PortalClientes.Views.frmMapaflota" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:UpdatePanel ID="upaPrincipal" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-6">
                    <div class="title_left">
                        <h3><asp:Label ID="lblMapaFlotaHeader" runat="server" Text=" Mapa de Flota" Font-Bold="false"></asp:Label></h3>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="title_right">
                        <div class="col-md-5 col-sm-5   form-group pull-right top_search">
                            <div class="input-group">
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
                                <asp:Label ID="lblMapaFlota" runat="server" Text="Mapa de Flota" Font-Bold="true"></asp:Label></h2>
                            <div class="clearfix"></div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-3">
                                        <ul class="nav nav-tabs" id="myTab" role="tablist">
                                            <li class="nav-item" onclick="hometab_Click">
                                                <asp:LinkButton runat="server" ID="hometab" OnClientClick="hometab_Click()" CssClass="nav-link active" data-toggle="tab" href="#ContentPlaceHolder1_home" role="tab" aria-controls="ContentPlaceHolder1_home" aria-selected="true">
                                                    <asp:Label ID="lblLocacion" runat="server" Text="Locación"></asp:Label>
                                                </asp:LinkButton>
                                            </li>
                                            <li class="nav-item" onclick="profiletab_Click">
                                                <asp:LinkButton runat="server" ID="profiletab" OnClientClick="profiletab_Click()" CssClass="nav-link" data-toggle="tab" href="#ContentPlaceHolder1_profile" role="tab" aria-controls="ContentPlaceHolder1_profile" aria-selected="false">
                                                    <asp:Label ID="lblRutas" runat="server" Text="Rutas"></asp:Label>
                                                </asp:LinkButton>
                                            </li>
                                        </ul>
                                        <div class="tab-content" id="myTabContent">
                                            <div class="tab-pane fade show active" runat="server" id="home" role="tabpanel" aria-labelledby="home-tab">
                                                <i class="fa fa-exclamation-circle"></i> <asp:Label ID="lblFuenteDatos" runat="server" Text="Fuentes de Datos" Font-Bold="true"></asp:Label>
                                                <br /><br />
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <asp:Label ID="lblPeriodo" runat="server" Text="Periodo"></asp:Label>
                                                        <asp:DropDownList id="ddlMeses" AutoPostBack="True" runat="server" CssClass="form-control">
                                                          <asp:ListItem Selected="True" Value="3 meses">Últimos 3 meses </asp:ListItem>
                                                          <asp:ListItem Value="6 meses"> Últimos 6 meses </asp:ListItem>
                                                          <asp:ListItem Value="12 meses"> Últimos 12 meses </asp:ListItem>
                                                       </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <asp:Label ID="lblAeronave" runat="server" Text="Aeronave"></asp:Label>
                                                        <asp:DropDownList id="ddlAeronave" AutoPostBack="True" runat="server" CssClass="form-control">
                                                          <asp:ListItem Selected="True" Value="Todas">Todas </asp:ListItem>
                                                          <asp:ListItem Value="Op 2"> Opción 2 </asp:ListItem>
                                                          <asp:ListItem Value="Op 3"> Opción 3 </asp:ListItem>
                                                       </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <asp:Label ID="lblTiposVuelo" runat="server" Text="Tipos de Vuelo"></asp:Label>
                                                        <asp:DropDownList id="DropDownList1" AutoPostBack="True" runat="server" CssClass="form-control">
                                                          <asp:ListItem Selected="True" Value="Todas">Todos </asp:ListItem>
                                                          <asp:ListItem Value="Op 2"> Opción 2 </asp:ListItem>
                                                          <asp:ListItem Value="Op 3"> Opción 3 </asp:ListItem>
                                                       </asp:DropDownList>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12">
                                                        <div class="x_title">
                                                            <h2>
                                                                <asp:Label ID="lblEstadosVuelos" runat="server" Text="Estado de Vuelos" Font-Bold="true"></asp:Label></h2>
                                                            <div class="clearfix"></div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <div>
                                                                    <div class="row" style="margin: 5px;">
                                                                        <div class="col-md-6 tile_count">
                                                                            <div class="" style="text-align: center;">
                                                                                    <asp:Label ID="lblVuelos" runat="server" Text=" Vuelos" Font-Bold="false"></asp:Label></span>
                                                                                <div class="count">
                                                                                    <asp:Label ID="lblVuelosRes" runat="server" Text="000" Font-Bold="true" CssClass="count4" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-6 tile_count">
                                                                            <div class="" style="text-align: center;">
                                                                                    <asp:Label ID="lblHorasVuelo" runat="server" Text=" Horas de vuelo" Font-Bold="false"></asp:Label></span>
                                                                                <div class="count">
                                                                                    <asp:Label ID="lblHorasVueloRes" runat="server" Text="000" Font-Bold="true" CssClass="count4" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row" style="margin: 5px;">
                                                                        <div class="col-md-6 tile_count">
                                                                            <div class="" style="text-align: center;">
                                                                                    <asp:Label ID="lblAeropuertos" runat="server" Text=" Aeropuertos" Font-Bold="false"></asp:Label></span>
                                                                                <div class="count">
                                                                                    <asp:Label ID="lblAeropuertosRes" runat="server" Text="000" Font-Bold="true" CssClass="count4" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-md-6 tile_count">
                                                                            <div class="" style="text-align: center;">
                                                                                    <asp:Label ID="lblMiVuelo" runat="server" Text=" Mi vuelo" Font-Bold="false"></asp:Label></span>
                                                                                <div class="count">
                                                                                    <asp:Label ID="lblMiVueloRes" runat="server" Text="00,000" Font-Bold="true" CssClass="count4" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <br />
                                                <div class="row">
                                                    <div class="col-md-12 col-sm-12">
                                                        <div class="x_title">
                                                            <h2>
                                                                <asp:Label ID="lblRutass" runat="server" Text="Rutas" Font-Bold="true"></asp:Label></h2>
                                                            <div class="clearfix"></div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <div>
                                                                    <div class="row" style="margin: 5px;">
                                                                        <div class="col-md-12">
                                                                            <div class="" style="text-align: left;">
                                                                                <i class="fa fa-minus" style="color:#ff0000"></i>&nbsp;<asp:Label ID="lblMultiple" runat="server" Text=" Multiple" Font-Bold="false"></asp:Label></span>
                                                                            </div>
                                                                        </div>
                                                                        </div>
                                                                        <div class="row" style="margin: 5px;">
                                                                        <div class="col-md-12">
                                                                            <div class="" style="text-align: left;">
                                                                                <i class="fa fa-minus" style="color:#28a745"></i>&nbsp;<asp:Label ID="lblPropietarioTerceros" runat="server" Text=" Propietarios - Terceros" Font-Bold="false"></asp:Label></span>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row" style="margin: 5px;">
                                                                        <div class="col-md-12">
                                                                            <div class="" style="text-align: left;">
                                                                                <i class="fa fa-minus" style="color:#ffc107"></i>&nbsp;<asp:Label ID="lblPropietarioPrincipal" runat="server" Text=" Propietario - Principal" Font-Bold="false"></asp:Label></span>
                                                                            </div>
                                                                        </div>
                                                                        </div>
                                                                        <div class="row" style="margin: 5px;">
                                                                        <div class="col-md-12">
                                                                            <div class="" style="text-align: left;">
                                                                                <i class="fa fa-minus" style="color:#007bff"></i>&nbsp;<asp:Label ID="lblTiposRutas" runat="server" Text=" Tipos de rutas" Font-Bold="false"></asp:Label></span>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="tab-pane fade" runat="server" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                                                <br />
                                                <div class="col-md-12">
                                                    <div class="">
                                                        Contenido
                                                    </div>
                                                </div>
                                            </div>
                                        </div>



                                    </div>
                                    <div class="col-md-9">
                                        <br />
                                        <div id="googleMap"></div>
                                        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d15008005.624851545!2d-111.65547970087938!3d23.313441203547026!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x84043a3b88685353%3A0xed64b4be6b099811!2zTcOpeGljbw!5e0!3m2!1ses!2smx!4v1629999888503!5m2!1ses!2smx" width="100%" height="450" style="border:0;" allowfullscreen="" loading="lazy"></iframe>
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
