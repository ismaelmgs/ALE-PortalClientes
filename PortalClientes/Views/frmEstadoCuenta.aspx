<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmEstadoCuenta.aspx.cs" Inherits="PortalClientes.Views.frmEstadoCuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row">
        <div class="col-md-6">
            <div class="title_left">
                <h3>Estados de Cuenta Mensual</h3>
            </div>
        </div>
        <div class="col-md-6">
        <div class="title_right">
                <div class="col-md-5 col-sm-5   form-group pull-right top_search">
                    <div class="input-group">
                        <%--<asp:TextBox ID="txtBusqueda" runat="server" CssClass="form-control" placeholder="Buscar..."></asp:TextBox>
                        <span class="input-group-btn">
                            <button id="btnBuscar" class="btn btn-default" type="button">
                                <i class="fa fa-search" aria-hidden="true"></i>
                            </button>
                        </span>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
       <div class="col-md-12 col-sm-12">
        <div class="x_panel">
            <div class="x_title">
                <h2><asp:Label ID="lblResumenDeCuenta" runat="server" Text="Resumen de la Cuenta" Font-Bold="true"></asp:Label> | <asp:Label ID="lblMatricula" runat="server" Text="N849WC" Font-Bold="true"></asp:Label></h2>
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
                    <div>
                    <br />
                    <%--<h2>Resumen del período</h2>--%>
                    <div class="row" style="margin: 5px;">
                        <div class="col-md-4 tile_count">
                            <div class="tile_stats_count" style="text-align: center;background-image:none !important;">
                                <span class="count_top">
                                    <asp:Label ID="lblSaldoActual" runat="server" Text=" Saldo Actual" Font-Bold="false"></asp:Label></span>
                                <div class="count">
                                    <asp:Label ID="lblSaldoActualS" runat="server" Text=" $" Font-Bold="true" CssClass="count" />
                                    <asp:Label ID="lblSaldoActualRes" runat="server" Text=" 155,522.11" Font-Bold="true" CssClass="count"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4 tile_count">
                            <div class="tile_stats_count" style="text-align: center;background-image:none !important;">
                                <span class="count_top">
                                    <asp:Label ID="lblTotalAtrasado" runat="server" Text=" Total Atrasado" Font-Bold="false"></asp:Label></span>
                                <div class="count">
                                    <asp:Label ID="lblTotalAtrasadoS" runat="server" Text=" $" Font-Bold="true" CssClass="count" style="color:#ff0000" />
                                    <asp:Label ID="lblTotalAtrasadoRes" runat="server" Text=" 155.522.11" Font-Bold="true" CssClass="count" style="color:#ff0000"></asp:Label>
                                </div>
                                <div class="row">
                                <div class="col-md-6">
                                    <asp:Label ID="lblTotalAtrasadoUno" runat="server" Text=" Total Atrasado (+30 días):" Font-Bold="true"></asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="lblTotalAtrasadoUnoRes" runat="server" Text=" 66,603.91 USD" Font-Bold="true" style="color:#ff0000;"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Label ID="lblTotalAtrasadoDos" runat="server" Text=" Total Atrasado (+60 días):" Font-Bold="true"></asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="lblTotalAtrasadoDosRes" runat="server" Text=" 49,759.53 USD" Font-Bold="true" style="color:#ff0000;"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <asp:Label ID="lblTotalAtrasadoTres" runat="server" Text=" Total Atrasado (+90 días):" Font-Bold="true"></asp:Label>
                                </div>
                                <div class="col-md-6">
                                    <asp:Label ID="lblTotalAtrasadoTresRes" runat="server" Text=" 39,158.67 USD" Font-Bold="true" style="color:#ff0000;"></asp:Label>
                                </div>
                            </div>
                            </div>
                            
                        </div>
                        <div class="col-md-4 tile_count">
                            <div class="tile_stats_count" style="text-align: center;background-image:none !important;">
                                <span class="count_top">
                                    <asp:Label ID="lblMontoRequerido" runat="server" Text=" Monto de Depósito Requerido" Font-Bold="false"></asp:Label></span>
                                <div class="count">
                                    <asp:Label ID="lblMontoRequeridoUSD" runat="server" Text=" USD" Font-Bold="true" CssClass="count" style="font-size:14px;" />
                                    <asp:Label ID="lblMontoRequeridoRes" runat="server" Text=" 100,000.00" Font-Bold="true" CssClass="count" style="color:#ff0000"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
