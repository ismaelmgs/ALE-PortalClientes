<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmMetricasEstadisticas.aspx.cs" Inherits="PortalClientes.Views.frmMetricasEstadisticas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row">
        <div class="col-md-6">
            <div class="title_left">
                <h3>Métricas y Estadísticas</h3>
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
                <h2><asp:Label ID="lblMetricasEstadisticas" runat="server" Text="Métricas y Estadísticas" Font-Bold="true"></asp:Label></h2>
                <ul class="nav navbar-right panel_toolbox">
                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                    <li><a class="close-link"><i class="fa fa-close"></i></a>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
            <div class="row">
                <div class="col-md-7">
                    &nbsp;
                </div>
                <div class="col-md-3" style="text-align:right;">
                    <asp:DropDownList id="ddlFiltroResumenPeriodo" runat="server" CssClass="form-control">
                        <asp:ListItem Selected="True" Value="Últimos tres meses"> Últimos 3 meses </asp:ListItem>
                        <asp:ListItem Value="Últimos dos meses"> Últimos 2 meses </asp:ListItem>
                        <asp:ListItem Value="Último mes"> Último mes </asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-2" style="text-align:center;">
                    <button id="btnFiltrarMetricasEstadisticas" class="btn btn-primary" type="button">
                        <i class="fa fa-filter" aria-hidden="true"></i> Filtrar
                    </button>
                </div>
            </div>
            <div>
                <br />
                <h2>Resumen del período</h2>
                <div class="row" style="margin:5px;">
                    <div class="col-md-3 tile_count" style="border-left:2px solid #73879c;border-right:2px solid #73879c;">
                    <div class="tile_stats_count" style="text-align:center;">
                        <span class="count_top"><asp:Label ID="lblGastoTotal" runat="server" Text=" Gasto Total" Font-Bold="false"></asp:Label></span>
                        <div class="count"><asp:Label ID="lblGastoTotalS" runat="server" Text=" $" Font-Bold="true" CssClass="count" /> <asp:Label ID="lblGastoTotalRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label></div>
                    </div>
                    </div>
                    <div class="col-md-3 tile_count" style="border-right:2px solid #73879c;">
                    <div class="tile_stats_count" style="text-align:center;">
                        <span class="count_top"><asp:Label ID="lblCostoHora" runat="server" Text=" Costo por Hora" Font-Bold="false"></asp:Label></span>
                        <div class="count"><asp:Label ID="lblCostoHoraS" runat="server" Text=" $" Font-Bold="true" CssClass="count" /><asp:Label ID="lblCostoHoraRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label></div>
                    </div>
                    </div>
                    <div class="col-md-3 tile_count" style="border-right:2px solid #73879c;">
                    <div class="tile_stats_count" style="text-align:center;">
                        <span class="count_top"><asp:Label ID="lblCostoMilla" runat="server" Text=" Costo por Milla" Font-Bold="false"></asp:Label></span>
                        <div class="count"><asp:Label ID="lblCostoMillaS" runat="server" Text=" $" Font-Bold="true" CssClass="count" /><asp:Label ID="lblCostoMillaRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label></div>
                    </div>
                    </div>
                    <div class="col-md-3 tile_count" style="border-right:2px solid #73879c;">
                    <div class="tile_stats_count" style="text-align:center;">
                        <span class="count_top"><asp:Label ID="lblCostoMillaPAX" runat="server" Text=" Costo por Milla PAX" Font-Bold="false"></asp:Label></span>
                        <div class="count"><asp:Label ID="lblCostoMillaPAXS" runat="server" Text=" $" Font-Bold="true" CssClass="count" /><asp:Label ID="lblCostoMillaPAXRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label></div>
                    </div>
                    </div>
                </div>
                <div class="row" style="margin:5px;">
                    <div class="col-md-3 tile_count" style="border-left:2px solid #73879c;border-right:2px solid #73879c;">
                    <div class="tile_stats_count" style="text-align:center;">
                        <span class="count_top"><asp:Label ID="lblNumeroVuelos" runat="server" Text=" Número de Vuelos" Font-Bold="false"></asp:Label></span>
                        <div class="count"><asp:Label ID="lblNumeroVuelosRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label></div>
                    </div>
                    </div>
                    <div class="col-md-3 tile_count" style="border-right:2px solid #73879c;">
                    <div class="tile_stats_count" style="text-align:center;">
                        <span class="count_top"><asp:Label ID="lblHorasVuelos" runat="server" Text=" Horas de Vuelo" Font-Bold="false"></asp:Label></span>
                        <div class="count"><asp:Label ID="lblHorasVuelosRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label></div>
                    </div>
                    </div>
                    <div class="col-md-3 tile_count" style="border-right:2px solid #73879c;">
                    <div class="tile_stats_count" style="text-align:center;">
                        <span class="count_top"><asp:Label ID="lblDistanciaVolada" runat="server" Text=" Distancia Volada (millas)" Font-Bold="false"></asp:Label></span>
                        <div class="count"><asp:Label ID="lblDistanciaVoladaRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label></div>
                    </div>
                    </div>
                    <div class="col-md-3 tile_count" style="border-right:2px solid #73879c;">
                    <div class="tile_stats_count" style="text-align:center;">
                        <span class="count_top"><asp:Label ID="lblPasajeros" runat="server" Text=" Pasajeros" Font-Bold="false"></asp:Label></span>
                        <div class="count"><asp:Label ID="lblPasajerosRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label></div>
                    </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
    <div class="row">
       <div class="col-md-12 col-sm-12">
        <div class="x_panel">
            <div class="x_title">
                <ul class="nav navbar-right panel_toolbox">
                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                    <li><a class="close-link"><i class="fa fa-close"></i></a>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
            <div class="row">
                <div class="col-md-7">
                    &nbsp;
                </div>
                <div class="col-md-2" style="text-align:center;">
                        &nbsp;
                </div>
                <div class="col-md-3" style="text-align:right;">
                    <asp:DropDownList id="ddlPromedioVuelo" runat="server" CssClass="form-control">
                        <asp:ListItem Selected="True" Value="Últimos tres meses"> Últimos 3 meses </asp:ListItem>
                        <asp:ListItem Value="Últimos dos meses"> Últimos 2 meses </asp:ListItem>
                        <asp:ListItem Value="Último mes"> Último mes </asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div>
                <br />
                <h2>Promedio de Vuelo</h2>
                <div class="row" style="margin:5px;">
                    <div class="col-md-3 tile_count" style="border-left:2px solid #73879c;border-right:2px solid #73879c;">
                    <div class="tile_stats_count" style="text-align:center;">
                        <span class="count_top"><asp:Label ID="lblTiempoPromedio" runat="server" Text=" Tiempo Promedio" Font-Bold="false"></asp:Label></span>
                        <div class="count"><asp:Label ID="lblTiempoPromedioRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label></div>
                    </div>
                    </div>
                    <div class="col-md-3 tile_count" style="border-right:2px solid #73879c;">
                    <div class="tile_stats_count" style="text-align:center;">
                        <span class="count_top"><asp:Label ID="lblDistanciaPromedio" runat="server" Text=" Distancia Promedio (millas)" Font-Bold="false"></asp:Label></span>
                        <div class="count"><asp:Label ID="lblDistanciaPromedioRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label></div>
                    </div>
                    </div>
                    <div class="col-md-3 tile_count" style="border-right:2px solid #73879c;">
                    <div class="tile_stats_count" style="text-align:center;">
                        <span class="count_top"><asp:Label ID="lblPromedioPasajeros" runat="server" Text=" Promedio de Pasajeros" Font-Bold="false"></asp:Label></span>
                        <div class="count"><asp:Label ID="lblPromedioPasajerosRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label></div>
                    </div>
                    </div>
                    <div class="col-md-3 tile_count" style="border-right:2px solid #73879c;">
                    <div class="tile_stats_count" style="text-align:center;">
                        <span class="count_top"><asp:Label ID="lblCostoPromedio" runat="server" Text=" Costo Promedio" Font-Bold="false"></asp:Label></span>
                        <div class="count"><asp:Label ID="lblCostoPromedioRes" runat="server" Text=" $" Font-Bold="true" CssClass="count" /> <asp:Label ID="Label9" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label></div>
                    </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
    <div class="row">
        <div class="col-md-6">
        <div class="x_panel">
            <div class="x_title">
                <ul class="nav navbar-right panel_toolbox">
                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                    <li><a class="close-link"><i class="fa fa-close"></i></a>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    &nbsp;
                </div>
                <div class="col-md-6" style="text-align:right;">
                    <asp:DropDownList id="ddlGastosCategoria" runat="server" CssClass="form-control">
                        <asp:ListItem Selected="True" Value="Últimos tres meses"> Últimos 3 meses </asp:ListItem>
                        <asp:ListItem Value="Últimos dos meses"> Últimos 2 meses </asp:ListItem>
                        <asp:ListItem Value="Último mes"> Último mes </asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div>
                <br />
                <h2>Gastos por Categoría</h2>
                <div class="row" style="margin:5px;">
                    <div class="col-md-12">
                        Contenido Gráfica<br /><br /><br /><br /><br /><br /><br />
                    </div>
                </div>
            </div>
        </div>
        </div>
        <div class="col-md-6">
            <div class="x_panel">
            <div class="x_title">
                <ul class="nav navbar-right panel_toolbox">
                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                    <li><a class="close-link"><i class="fa fa-close"></i></a>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    &nbsp;
                </div>
                <div class="col-md-6" style="text-align:right;">
                    <asp:DropDownList id="ddlReportes" runat="server" CssClass="form-control">
                        <asp:ListItem Selected="True" Value="Valor 1"> Valor 1 </asp:ListItem>
                        <asp:ListItem Value="Valor 2"> Valor 2 </asp:ListItem>
                        <asp:ListItem Value="Valor 3"> Valor 3 </asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div>
                <br />
                <h2>Reportes</h2>
                <div class="row" style="margin:5px;">
                    <div class="col-md-12 table-responsive">
                        <table class="table table-striped table-bordered table-hover">
                            <tr>
                                <th style="width:70%;">
                                    <asp:Label ID="lblDescripcion" runat="server" Text=" Descripción" Font-Bold="false"></asp:Label>
                                </th>
                                <th>
                                    <asp:Label ID="lblDescargar" runat="server" Text=" Descargar" Font-Bold="false"></asp:Label>
                                </th>
                            </tr>
                            <tr>
                                <td>
                                    Contenido
                                </td>
                                <td>
                                    <asp:LinkButton ID="btnExcel" runat="server" Text="<i class='fa fa-file-excel-o' style='color:#ffffff;font-size:22px;'></i>" CssClass="btn btn-primary" />
                                    <asp:LinkButton ID="btnPDF" runat="server" Text="<i class='fa fa-file-pdf-o' style='color:#ffffff;font-size:22px;'></i>" CssClass="btn btn-primary" />
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
