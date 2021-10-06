<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmTransacciones.aspx.cs" Inherits="PortalClientes.Views.frmTransacciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="row">
        <div class="col-md-6">
            <div class="title_left">
                <h3><asp:Label ID="lblTitulo" runat="server" Text="Transacciones"></asp:Label></h3>
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
    <div class="row" style="margin:5px;">
        <div class="col-md-3 tile_count" style="border-left:2px solid #73879c;border-right:2px solid #73879c;">
        <div class="tile_stats_count" style="text-align:center;">
            <span class="count_top"><i class="fa fa-plane"></i><asp:Label ID="lblNumVuelos" runat="server" Text=" Número de Vuelos" Font-Bold="false"></asp:Label></span>
            <div class="count"><asp:Label ID="lblNumVuelosRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label></div>
        </div>
        </div>
        <div class="col-md-3 tile_count" style="border-right:2px solid #73879c;">
        <div class="tile_stats_count" style="text-align:center;">
            <span class="count_top"><i class="fa fa-plane"></i><asp:Label ID="lblPagos" runat="server" Text=" Pagos" Font-Bold="false"></asp:Label></span>
            <div class="count"><asp:Label ID="lblMXNUSDuno" runat="server" Text=" $" Font-Bold="true" CssClass="count" /> <asp:Label ID="lblPagosRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label></div>
        </div>
        </div>
        <div class="col-md-3 tile_count" style="border-right:2px solid #73879c;">
        <div class="tile_stats_count" style="text-align:center;">
            <span class="count_top"><i class="fa fa-plane"></i><asp:Label ID="lblGastos" runat="server" Text=" Gastos" Font-Bold="false"></asp:Label></span>
            <div class="count"><asp:Label ID="lblMXNUSDdos" runat="server" Text=" $" Font-Bold="true" CssClass="count" /> <asp:Label ID="lblGastosRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label></div>
        </div>
        </div>
        <div class="col-md-3 tile_count" style="border-right:2px solid #73879c;">
        <div class="tile_stats_count" style="text-align:center;">
            <span class="count_top"><i class="fa fa-plane"></i><asp:Label ID="lblGastosOperacion" runat="server" Text=" Gastos de Operación" Font-Bold="false"></asp:Label></span>
            <div class="count"><asp:Label ID="lblMXNUSDtres" runat="server" Text=" $" Font-Bold="true" CssClass="count" /> <asp:Label ID="lblGastosOperacionRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label></div>
        </div>
        </div>
    </div>
    <div class="row">
       <div class="col-md-12 col-sm-12">
        <div class="x_panel" style="min-height: 55vh;">
            <div class="x_title">
                <h2><asp:Label ID="lblTransacciones" runat="server" Text="Transacciones" Font-Bold="true"></asp:Label></h2>
                
                <ul class="nav navbar-right panel_toolbox">
                    <li>
                        <asp:dropdownlist runat="server" id="ddlMeses" CssClass="form-control"> 
                             <asp:listitem text="Intervalo de:" value=""></asp:listitem>
                             <asp:listitem text="Último mes" value="1mes"></asp:listitem>
                             <asp:listitem text="Últimos 3 meses" value="2mes"></asp:listitem>
                             <asp:listitem text="Últimos 6 meses" value="3mes"></asp:listitem>
                             <asp:listitem text="Último año" value="12meses"></asp:listitem>
                        </asp:dropdownlist>
                    </li>
                    <li>
                        <asp:dropdownlist runat="server" id="ddlColumnas" CssClass="form-control"> 
                             <asp:listitem text="Columnas" value=""></asp:listitem>
                             <asp:listitem text="Opción 1" value="op1"></asp:listitem>
                             <asp:listitem text="Opción 2" value="op2"></asp:listitem>
                             <asp:listitem text="Opción 3" value="op3"></asp:listitem>
                             <asp:listitem text="Opción 4" value="op4"></asp:listitem>
                        </asp:dropdownlist>
                    </li>
                    <li style="padding-left:5px;">
                        <asp:LinkButton ID="btnExcel" runat="server" Text="<i class='fa fa-file-excel-o' style='color:#ffffff;font-size:22px;'></i>" CssClass="btn btn-primary" />
                    </li>
                    <li>
                        <asp:LinkButton ID="btnPDF" runat="server" Text="<i class='fa fa-file-pdf-o' style='color:#ffffff;font-size:22px;'></i>" CssClass="btn btn-primary" />
                    </li>
                    <li>
                        <a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                    <li>
                        <a class="close-link"><i class="fa fa-close"></i></a>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="table-responsive">
                        <table class="table table-striped table-bordered table-hover">
                            <tr>
                                <th>
                                    <asp:Label ID="lblFecha" runat="server" Text="Fecha" Font-Bold="true"></asp:Label>
                                </th>
                                <th>
                                    <asp:Label ID="lblCategoria" runat="server" Text="Categoría" Font-Bold="true"></asp:Label>
                                </th>
                                <th>
                                    <asp:Label ID="lblSubCategoria" runat="server" Text="Sub Categoría" Font-Bold="true"></asp:Label>
                                </th>
                                <th>
                                    <asp:Label ID="lblTripulacion" runat="server" Text="No. Tripulación" Font-Bold="true"></asp:Label>
                                </th>
                                <th>
                                    <asp:Label ID="lblVendedorPagador" runat="server" Text="Vendedor/Pagador" Font-Bold="true"></asp:Label>
                                </th>
                                <th>
                                    <asp:Label ID="lblDescripcion" runat="server" Text="Descripción" Font-Bold="true"></asp:Label>
                                </th>
                                <th>
                                    <asp:Label ID="lblTotal" runat="server" Text="Total" Font-Bold="true"></asp:Label>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblfechaRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblCategoriaRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblSubCategoriaRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblTripulacionRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblVendedorPagadorRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDescripcionRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblTotalRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
