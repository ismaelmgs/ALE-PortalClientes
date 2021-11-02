<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmMetricasEstadisticas.aspx.cs" Inherits="PortalClientes.Views.frmMetricasEstadisticas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-6">
            <div class="title_left">
                <h3>
                    <asp:Label ID="lbltitulometricasEstadisticas" runat="server" Text="Métricas y Estadísticas" Font-Bold="true"></asp:Label></h3>
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
                    <h2>
                        <asp:Label ID="lblResumenPeriodo" runat="server" Text="Resumen del período $USD" Font-Bold="true"></asp:Label></h2>
                    <div class="clearfix"></div>
                </div>
                <div class="row">
                    <div class="col-md-7">
                        &nbsp;
                    </div>
                    <div class="col-md-3" style="text-align: right;">
                        <asp:DropDownList ID="ddlFiltroResumenPeriodo" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="col-md-2" style="text-align: center;">
                        <asp:Button ID="btnFiltrarMetricasEstadisticas" runat="server" Text="Filtrar" CssClass="btn btn-primary" OnClick="btnFiltrar_Click" />
                    </div>
                </div>
                <div>
                    <br />
                    <%--<h2>Resumen del período</h2>--%>
                    <div class="row" style="margin: 5px;">
                        <div class="col-md-3 tile_count">
                            <div class="tile_stats_count" style="text-align: center;">
                                <span class="count_top">
                                    <asp:Label ID="lblGastoTotalFijo" runat="server" Text=" Gasto Total Fijo" Font-Bold="false"></asp:Label></span>
                                <div class="count">
                                    <%--<asp:Label ID="lblGastoTotalFijoS" runat="server" Text=" $" Font-Bold="true" CssClass="count" />--%>
                                    <asp:Label ID="lblGastoTotalRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3 tile_count">
                            <div class="tile_stats_count" style="text-align: center;">
                                <span class="count_top">
                                    <asp:Label ID="lblGastoTotalVariable" runat="server" Text=" Costo Total Variable" Font-Bold="false"></asp:Label></span>
                                <div class="count">
                                    <%--<asp:Label ID="lblGastoTotalVariableS" runat="server" Text=" $" Font-Bold="true" CssClass="count" />--%>
                                    <asp:Label ID="lblGastoTotalVariableRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3 tile_count">
                            <div class="tile_stats_count" style="text-align: center;">
                                <span class="count_top">
                                    <asp:Label ID="lblCostoHora" runat="server" Text=" Costo por Hora" Font-Bold="false"></asp:Label></span>
                                <div class="count">
                                    <%--<asp:Label ID="lblCostoHoraS" runat="server" Text=" $" Font-Bold="true" CssClass="count" />--%>
                                    <asp:Label ID="lblCostoHoraRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3 tile_count">
                            <div class="tile_stats_count" style="text-align: center;">
                                <span class="count_top">
                                    <asp:Label ID="lblCostoMilla" runat="server" Text=" Costo por Milla" Font-Bold="false"></asp:Label></span>
                                <div class="count">
                                    <%--<asp:Label ID="lblCostoMillaS" runat="server" Text=" $" Font-Bold="true" CssClass="count" />--%>
                                    <asp:Label ID="lblCostoMillaRes" runat="server" Text=" - " Font-Bold="true" CssClass="count"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="x_title">
                    <h2>
                        <asp:Label ID="lblResumenPeriodoMXN" runat="server" Text="Resumen del periodo $MXN" Font-Bold="true"></asp:Label></h2>
                    <div class="clearfix"></div>
                </div>
                <div>
                    <br />
                    <div class="row" style="margin: 5px;">
                        <div class="col-md-3 tile_count">
                            <div class="tile_stats_count" style="text-align: center;">
                                <span class="count_top">
                                    <asp:Label ID="lblGastoTotalFijoMXN" runat="server" Text=" Gasto Total Fijo" Font-Bold="false"></asp:Label></span>
                                <div class="count">
                                    <%--<asp:Label ID="lblGastoTotalFijoSMXN" runat="server" Text=" $" Font-Bold="true" CssClass="count" />--%>
                                    <asp:Label ID="lblGastoTotalResMXN" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3 tile_count">
                            <div class="tile_stats_count" style="text-align: center;">
                                <span class="count_top">
                                    <asp:Label ID="lblGastoTotalVariableMXN" runat="server" Text=" Costo Total Variable" Font-Bold="false"></asp:Label></span>
                                <div class="count">
                                    <%--<asp:Label ID="lblGastoTotalVariableSMXN" runat="server" Text=" $" Font-Bold="true" CssClass="count" />--%>
                                    <asp:Label ID="lblGastoTotalVariableMXNRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3 tile_count">
                            <div class="tile_stats_count" style="text-align: center;">
                                <span class="count_top">
                                    <asp:Label ID="lblCostoHoraMXN" runat="server" Text=" Costo por Hora" Font-Bold="false"></asp:Label></span>
                                <div class="count">
                                    <%--<asp:Label ID="lblCostoHoraSMXN" runat="server" Text=" $" Font-Bold="true" CssClass="count" />--%>
                                    <asp:Label ID="lblCostoHoraMXNRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3 tile_count">
                            <div class="tile_stats_count" style="text-align: center;">
                                <span class="count_top">
                                    <asp:Label ID="lblCostoMillaMXN" runat="server" Text=" Costo por Milla" Font-Bold="false"></asp:Label></span>
                                <div class="count">
                                    <%--<asp:Label ID="lblCostoMillaSMXN" runat="server" Text=" $" Font-Bold="true" CssClass="count" />--%>
                                    <asp:Label ID="lblCostoMillaMXNRes" runat="server" Text=" - " Font-Bold="true" CssClass="count"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="x_title">
                    <h2>
                        <asp:Label ID="lblInformacionGeneral" runat="server" Text="Informacion General" Font-Bold="true"></asp:Label></h2>
                    <div class="clearfix"></div>
                </div>
                <div class="row" style="margin: 5px;">
                    <div class="col-md">
                        &nbsp;
                    </div>
                    <div class="col-md-3 tile_count">
                        <div class="tile_stats_count" style="text-align: center;">
                            <span class="count_top">
                                <asp:Label ID="lblNumeroVuelos" runat="server" Text=" Número de Vuelos" Font-Bold="false"></asp:Label></span>
                            <div class="count">
                                <asp:Label ID="lblNumeroVuelosRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count">
                                </asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 tile_count">
                        <div class="tile_stats_count" style="text-align: center;">
                            <span class="count_top">
                                <asp:Label ID="lblHorasVoladas" runat="server" Text=" Horas Voladas" Font-Bold="false"></asp:Label></span>
                            <div class="count">
                                <asp:Label ID="lblHorasVoladasRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3 tile_count">
                        <div class="tile_stats_count" style="text-align: center;">
                            <span class="count_top">
                                <asp:Label ID="lblPromedioDePasajeros" runat="server" Text=" Numero de Pasajeros" Font-Bold="false"></asp:Label></span>
                            <div class="count">
                                <asp:Label ID="lblPromedioDePasajerosRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="col-md">
                        &nbsp;
                    </div>
                </div>
                <div class="x_title">
                    <h2>
                        <asp:Label ID="lblPeriodoVuelo" runat="server" Text="Promedio por Vuelo" Font-Bold="true"></asp:Label></h2>
                    <div class="clearfix"></div>
                </div>

                <div>
                    <br />
                    <div class="row" style="margin: 5px;">

                        <div class="col-md-2 tile_count">
                            <div class="tile_stats_count" style="text-align: center;">
                                <span class="count_top">
                                    <asp:Label ID="lblTiempoPromedio" runat="server" Text=" Tiempo Promedio" Font-Bold="false"></asp:Label></span>
                                <div class="count">
                                    <asp:Label ID="lblTiempoPromedioRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 tile_count">
                            <div class="tile_stats_count" style="text-align: center;">
                                <span class="count_top">
                                    <asp:Label ID="lblDistanciaPromedio" runat="server" Text=" Distancia Promedio (millas)" Font-Bold="false"></asp:Label></span>
                                <div class="count">
                                    <asp:Label ID="lblDistanciaPromedioRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2 tile_count">
                            <div class="tile_stats_count" style="text-align: center;">
                                <span class="count_top">
                                    <asp:Label ID="lblPromedioPasajeros" runat="server" Text=" Promedio de Pasajeros" Font-Bold="false"></asp:Label></span>
                                <div class="count">
                                    <asp:Label ID="lblPromedioPasajerosRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3 tile_count">
                            <div class="tile_stats_count" style="text-align: center;">
                                <span class="count_top">
                                    <asp:Label ID="lblCostoPromedioMXN" runat="server" Text=" Costo Promedio Pesos" Font-Bold="false"></asp:Label></span>
                                <div class="count">
                                    <%--<asp:Label ID="lblCostoPromedioRes" runat="server" Text=" $" Font-Bold="true" CssClass="count" />--%>
                                    <asp:Label ID="lblCostoPromedioRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-3 tile_count">
                            <div class="tile_stats_count" style="text-align: center;">
                                <span class="count_top">
                                    <asp:Label ID="lblCostoPromedioUSD" runat="server" Text=" Costo Promedio Dlls" Font-Bold="false"></asp:Label></span>
                                <div class="count">
                                    <%--<asp:Label ID="Label4" runat="server" Text=" $" Font-Bold="true" CssClass="count" />--%>
                                    <asp:Label ID="lblCostoPromedioUSDRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="x_title">
                    <h2>
                        <asp:Label ID="lblCostosCat" runat="server" Text="Costos Por Categoría" Font-Bold="true"></asp:Label></h2>
                    <div class="clearfix"></div>
                </div>
                <div class="row">
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddlPeriodo" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtFechaInicioGrafica" runat="server" CssClass="form-control" Type="date" Width="100%"></asp:TextBox>
                    </div>
                    <div class="col-md-3">
                        <asp:TextBox ID="txtFechaFinGrafica" runat="server" CssClass="form-control" Type="date" Width="100%"></asp:TextBox>
                    </div>
                    <div class="col-md-2">
                        <asp:DropDownList ID="ddlTipoRubro" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                    </div>
                    <div class="col-md-2">
                        <button id="btnGraficasBuscar" class="btn btn-primary"><i class='fa fa-undo' style='color: #ffffff; font-size: 14px;'></i></button>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div id="piechart_3d_1" style="min-height: 400px;"></div>
                    </div>
                    <div class="col-md-6">
                        <div id="piechart_3d_2" style="min-height: 400px;">
                        </div>
                    </div>
                </div>

                <div class="x_title">
                    <h2>
                        <asp:Label ID="lblReportes" runat="server" Text="Reportes" Font-Bold="true"></asp:Label>
                    </h2>
                    <div class="clearfix"></div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        &nbsp;
                    </div>
                    <div class="col-md-6" style="text-align: right;">
                    </div>
                </div>
                <div>
                    <br />
                    <div class="row" style="margin: 5px;">
                        <div class="col-md-12 table-responsive">
                            <table class="table table-striped table-bordered table-hover">
                                <tr>
                                    <th style="width: 70%;">
                                        <asp:Label ID="lblDescripcion" runat="server" Text="Tipo Reporte" Font-Bold="false"></asp:Label>
                                    </th>
                                    <th>
                                        <asp:Label ID="lblDescargar" runat="server" Text=" Descargar" Font-Bold="false"></asp:Label>
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblResumenGastos" runat="server" Text=" Resumen de Gastos" Font-Bold="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="LinkButton1" runat="server" Text="<i class='fa fa-file-excel-o' style='color:#73879c;font-size:25px;'></i>" CssClass="btn" OnClick="lkbExpExcelRes_Click" />
                                        <asp:LinkButton ID="LinkButton2" runat="server" Text="<i class='fa fa-file-pdf-o' style='color:#73879c;font-size:25px;' ></i>" CssClass="btn" OnClick="lkbExpPDFRes_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblRepDetGastos" runat="server" Text=" Detalle de Gastos" Font-Bold="false"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="btnExcel" runat="server" Text="<i class='fa fa-file-excel-o' style='color:#73879c;font-size:25px;'></i>" CssClass="btn" OnClick="lkbExpExcel_Click" />
                                        <asp:LinkButton ID="btnPDF" runat="server" Text="<i class='fa fa-file-pdf-o' style='color:#73879c;font-size:25px;' ></i>" CssClass="btn" OnClick="lkbExpPDF_Click" />
                                    </td>
                                </tr>
                            </table>

                        </div>
                    </div>
                </div>

                <div class="x_title">
                    <h2>
                        <asp:Label ID="Label1" runat="server" Text="Costos Por Proveedor y Aeropuerto" Font-Bold="true"></asp:Label>
                    </h2>
                    <div class="clearfix"></div>
                </div>
                <div class="row">
                    <div class="col-md-2 offset-8">
                        <asp:DropDownList ID="DDFiltroMesesPA" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                    </div>
                    <div class="col-md-2">
                        <button id="btnGraficasBuscarPA" class="btn btn-primary"><i class='fa fa-undo' style='color: #ffffff; font-size: 14px;'></i></button>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div id="piechart_3d_3" style="min-height: 400px;"></div>
                    </div>
                    <div class="col-md-6">
                        <div id="piechart_3d_4" style="min-height: 400px;">
                        </div>
                    </div>
                </div>

                <div class="x_title">
                    <h2>
                        <asp:Label ID="Label2" runat="server" Text="Horas de Vuelo por Tipo y Duracion de vuelos" Font-Bold="true"></asp:Label>
                    </h2>
                    <div class="clearfix"></div>
                </div>
                <div class="row">
                    <div class="col-md-2 offset-8">
                        <asp:DropDownList ID="DDFiltroMesesV" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                    </div>
                    <div class="col-md-2">
                        <button id="btnGraficasBuscarHvDv" class="btn btn-primary"><i class='fa fa-undo' style='color: #ffffff; font-size: 14px;'></i></button>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6">
                        <div id="piechart_3d_5" style="min-height: 400px;"></div>
                    </div>
                    <div class="col-md-6">
                        <div id="piechart_3d_6" style="min-height: 400px;">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src='<%=ResolveUrl("~/vendors/jquery/dist/jquery.min.js")%>'></script>
    <script src='<%=ResolveUrl("~/vendors/jquery/dist/jquery.js")%>'></script>
    <script src='<%=ResolveUrl("~/build/js/GraficasJS/GraficasMeEsPorDuracionVuelos.js")%>'></script>
    <script src='<%=ResolveUrl("~/build/js/GraficasJS/GraficasMeEsPorAeropuerto.js")%>'></script>
    <script src='<%=ResolveUrl("~/build/js/GraficasJS/GraficasMeEsPorProveedor.js")%>'></script>
    <script src='<%=ResolveUrl("~/build/js/GraficasJS/GraficasMeEs.js")%>'></script>


    <asp:UpdateProgress ID="prgLoadingStatus" runat="server" DynamicLayout="true">
        <ProgressTemplate>
            <div id="overlay">
                <div id="modalprogress">
                    <div id="theprogress">
                        <asp:Image ID="imgWaitIcon" runat="server" ImageAlign="AbsMiddle" ImageUrl="~/Images/loading.gif" Width="150" Height="130" />
                    </div>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
