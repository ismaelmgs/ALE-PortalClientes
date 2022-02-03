<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmMetricasEstadisticas.aspx.cs" Inherits="PortalClientes.Views.frmMetricasEstadisticas" UICulture="es" Culture="es-MX" %>

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
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <div class="row">
                                 <div class="col-md-6" style="text-align: right">
                            <h2><asp:Label ID="lblResumenPeriodo" runat="server" Text="Resumen del período $USD" Font-Bold="true"></asp:Label></h2>
                                </div>
                            <div class="col-md-6" style="text-align: right">
									<div class="popover__wrapper">
									  <a href="#">
										<h2 class="popover__title"><i class="fa fa-question-circle" style="font-size:35px;margin-top: 5px;cursor:pointer;"></i>&nbsp;&nbsp;</h2>
									  </a>
									  <div class="popover__content" style="text-align:center; margin-top:90px;line-height:18px;">
										<p class="popover__message">
											<h5 style="background-color: #efefef; padding: 5px;">
                                            <asp:Label ID="lblHeaderDudasAclaraciones" runat="server" Text="Dudas o Aclaraciones" Font-Bold="true" Style="color:#5a738e;"></asp:Label></h5>
											<asp:Label ID="lblFavorComunicarse" runat="server" Text="Favor de comunicarse con:" Font-Bold="false" Style="color:#5a738e;"></asp:Label><br /> 
											<asp:Label ID="lblNombreAyuda" runat="server" Text="" Font-Bold="true" Style="color:#5a738e;"></asp:Label><br />
											<asp:Label ID="lblALTel" runat="server" Text="al teléfono:"></asp:Label><br /> <a runat="server" id="hrefTel" href="tel:+525555555555"><asp:Label ID="lblTel" runat="server" Text="" Font-Bold="true"></asp:Label></a>
										</p>
									  </div>
									</div>
								</div>
                            </div>
                            
                            <div class="clearfix"></div>                          
                        </div>                      
                        <div class="row">
                            <div class="col-md-7">
                                &nbsp;
                            </div>
                            <div class="col-md-3" style="text-align: right;">
                                <asp:DropDownList AutoPostBack="true" ID="ddlFiltroResumenPeriodo" runat="server" CssClass="form-control ddl" OnSelectedIndexChanged="btnFiltrar_Click">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div>
                            <br />
                            <div class="row" style="margin: 5px;">
                                <div class="col-md-3 tile_count">
                                    <div class="" style="text-align: center;">
                                        <span class="count_top">
                                            <asp:Label ID="lblGastoTotalFijo" runat="server" Text=" Gasto Total Fijo" Font-Bold="false"></asp:Label></span>
                                        <div class="count">
                                            <asp:Label ID="lblGastoTotalSimbolo" runat="server" Text=" $" Font-Bold="true" CssClass="count3" />
                                            <asp:Label ID="lblGastoTotalRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count4"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3 tile_count">
                                    <div class="" style="text-align: center;">
                                        <span class="count_top">
                                            <asp:Label ID="lblGastoTotalVariable" runat="server" Text=" Costo Total Variable" Font-Bold="false"></asp:Label></span>
                                        <div class="count">
                                            <asp:Label ID="lblGastoTotalVariableSimbolo" runat="server" Text=" $" Font-Bold="true" CssClass="count3" />
                                            <asp:Label ID="lblGastoTotalVariableRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count4"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3 tile_count">
                                    <div class="" style="text-align: center;">
                                        <span class="count_top">
                                            <asp:Label ID="lblCostoHora" runat="server" Text=" Costo por Hora" Font-Bold="false"></asp:Label></span>
                                        <div class="count">
                                            <asp:Label ID="lblCostoHoraSimbolo" runat="server" Text=" $" Font-Bold="true" CssClass="count3" />
                                            <asp:Label ID="lblCostoHoraRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count4"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3 tile_count">
                                    <div class="" style="text-align: center;">
                                        <span class="count_top">
                                            <asp:Label ID="lblCostoMilla" runat="server" Text=" Costo por Milla" Font-Bold="false"></asp:Label></span>
                                        <div class="count">
                                            <asp:Label ID="lblCostoMillaSimbolo" runat="server" Text=" $" Font-Bold="true" CssClass="count3" />
                                            <asp:Label ID="lblCostoMillaRes" runat="server" Text=" - " Font-Bold="true" CssClass="count4"></asp:Label>
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
                                    <div class="" style="text-align: center;">
                                        <span class="count_top">
                                            <asp:Label ID="lblGastoTotalFijoMXN" runat="server" Text=" Gasto Total Fijo" Font-Bold="false"></asp:Label></span>
                                        <div class="count">
                                            <asp:Label ID="lblGastoTotalsimboloMXN" runat="server" Text=" $" Font-Bold="true" CssClass="count3" />
                                            <asp:Label ID="lblGastoTotalResMXN" runat="server" Text=" 2500" Font-Bold="true" CssClass="count4"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3 tile_count">
                                    <div class="" style="text-align: center;">
                                        <span class="count_top">
                                            <asp:Label ID="lblGastoTotalVariableMXN" runat="server" Text=" Costo Total Variable" Font-Bold="false"></asp:Label></span>
                                        <div class="count">
                                            <asp:Label ID="lblGastoTotalVariableMXNSimbolo" runat="server" Text=" $" Font-Bold="true" CssClass="count3" />
                                            <asp:Label ID="lblGastoTotalVariableMXNRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count4"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3 tile_count">
                                    <div class="" style="text-align: center;">
                                        <span class="count_top">
                                            <asp:Label ID="lblCostoHoraMXN" runat="server" Text=" Costo por Hora" Font-Bold="false"></asp:Label></span>
                                        <div class="count">
                                            <asp:Label ID="lblCostoHoraMXNSimbolo" runat="server" Text=" $" Font-Bold="true" CssClass="count3" />
                                            <asp:Label ID="lblCostoHoraMXNRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count4"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3 tile_count">
                                    <div class="" style="text-align: center;">
                                        <span class="count_top">
                                            <asp:Label ID="lblCostoMillaMXN" runat="server" Text=" Costo por Milla" Font-Bold="false"></asp:Label></span>
                                        <div class="count">
                                            <asp:Label ID="lblCostoMillaMXNSimbolo" runat="server" Text=" $" Font-Bold="true" CssClass="count3" />
                                            <asp:Label ID="lblCostoMillaMXNRes" runat="server" Text=" - " Font-Bold="true" CssClass="count4"></asp:Label>
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
                                <div class="" style="text-align: center;">
                                    <span class="count_top">
                                        <asp:Label ID="lblNumeroVuelos" runat="server" Text=" Número de Vuelos" Font-Bold="false"></asp:Label></span>
                                    <div class="count">
                                        <asp:Label ID="lblNumeroVuelosRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count4">
                                        </asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3 tile_count">
                                <div class="" style="text-align: center;">
                                    <span class="count_top">
                                        <asp:Label ID="lblHorasVoladas" runat="server" Text=" Horas Voladas" Font-Bold="false"></asp:Label></span>
                                    <div class="count">
                                        <asp:Label ID="lblHorasVoladasRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count4"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3 tile_count">
                                <div class="" style="text-align: center;">
                                    <span class="count_top">
                                        <asp:Label ID="lblPromedioDePasajeros" runat="server" Text=" Numero de Pasajeros" Font-Bold="false"></asp:Label></span>
                                    <div class="count">
                                        <asp:Label ID="lblPromedioDePasajerosRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count4"></asp:Label>
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
                                    <div class="" style="text-align: center;">
                                        <span class="count_top">
                                            <asp:Label ID="lblTiempoPromedio" runat="server" Text=" Tiempo Promedio" Font-Bold="false"></asp:Label></span>
                                        <div class="count">
                                            <asp:Label ID="lblTiempoPromedioRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count4"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-2 tile_count">
                                    <div class="" style="text-align: center;">
                                        <span class="count_top">
                                            <asp:Label ID="lblDistanciaPromedio" runat="server" Text=" Distancia Promedio (millas)" Font-Bold="false"></asp:Label></span>
                                        <div class="count">
                                            <asp:Label ID="lblDistanciaPromedioRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count4"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-2 tile_count">
                                    <div class="" style="text-align: center;">
                                        <span class="count_top">
                                            <asp:Label ID="lblPromedioPasajeros" runat="server" Text=" Promedio de Pasajeros" Font-Bold="false"></asp:Label></span>
                                        <div class="count">
                                            <asp:Label ID="lblPromedioPasajerosRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count4"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3 tile_count">
                                    <div class="" style="text-align: center;">
                                        <span class="count_top">
                                            <asp:Label ID="lblCostoPromedioMXN" runat="server" Text=" Costo Promedio Pesos" Font-Bold="false"></asp:Label></span>
                                        <div class="count">
                                            <asp:Label ID="lblCostoPromedioSimbolo" runat="server" Text=" $" Font-Bold="true" CssClass="count3" />
                                            <asp:Label ID="lblCostoPromedioRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count4"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3 tile_count">
                                    <div class="" style="text-align: center;">
                                        <span class="count_top">
                                            <asp:Label ID="lblCostoPromedioUSD" runat="server" Text=" Costo Promedio Dlls" Font-Bold="false"></asp:Label></span>
                                        <div class="count">
                                            <asp:Label ID="lblCostoPromedioUSDSimbolo" runat="server" Text=" $" Font-Bold="true" CssClass="count3" />
                                            <asp:Label ID="lblCostoPromedioUSDRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count4"></asp:Label>
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
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlPeriodo" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                            </div>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlTipoRubro" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
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
                            <div class="row" style="margin: 0px;">
                                <div class="col-md-12 table-responsive" style="padding-left: 1px !important; padding-right: 1px !important">
                                    <table class="table" style="border: 0px;">
                                        <tr style="background-color: #00000003;">
                                            <td style="border: 0px; padding: 6px;">
                                                <img src="../build/images/resumen_gatos.png" style="width: 32px;" />&nbsp;<span style="font-size: 17px; font-weight: bold;"><asp:Label ID="lblResumenGastos" runat="server" Text=" Resumen de Gastos" Font-Bold="true"></asp:Label></span><br />
                                                <asp:Label ID="lblResumanGastosRes" runat="server" Text=" Resumen de gastos " Font-Bold="false"></asp:Label>
                                            </td>
                                            <td align="center" style="border: 0px; padding: 0.1rem;">
                                                <asp:LinkButton ID="LinkButton1" runat="server" Text="<i class='fa fa-file-excel-o' style='color:#73879c;font-size:25px;'></i>" CssClass="btn" OnClick="lkbExpExcelRes_Click" />
                                                <asp:LinkButton ID="LinkButton2" runat="server" Text="<i class='fa fa-file-pdf-o' style='color:#73879c;font-size:25px;' ></i>" CssClass="btn" OnClick="lkbExpPDFRes_Click" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="height: 3px;"></td>
                                        </tr>
                                        <tr style="background-color: #00000003;">
                                            <td style="border: 0px; padding: 6px;">
                                                <img src="../build/images/detalle_gatos.png" style="width: 32px;" />&nbsp;<span style="font-size: 17px; font-weight: bold;"><asp:Label ID="lblRepDetGastos" runat="server" Text=" Detalle de Gastos" Font-Bold="true"></asp:Label></span><br />
                                                <asp:Label ID="lblRepDeGastosRes" runat="server" Text=" Detalle de gastos " Font-Bold="false"></asp:Label>
                                            </td>
                                            <td align="center" style="border: 0px;">
                                                <asp:LinkButton ID="btnExcel" runat="server" Text="<i class='fa fa-file-excel-o' style='color:#73879c;font-size:25px;'></i>" CssClass="btn" OnClick="lkbExpExcel_Click" />
                                                <asp:LinkButton ID="btnPDF" runat="server" Text="<i class='fa fa-file-pdf-o' style='color:#73879c;font-size:25px;' ></i>" CssClass="btn" OnClick="lkbExpPDF_Click" />
                                            </td>
                                        </tr>
                                    </table>

                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="x_title">
                            <h2>
                                <asp:Label ID="lblprovaero" runat="server" Text="Gastos Por Proveedor y Aeropuerto" Font-Bold="true"></asp:Label>
                            </h2>
                            <div class="clearfix"></div>
                        </div>
                        <div class="row">
                            <div class="col-md-3 offset-9">
                                <asp:DropDownList ID="DDFiltroMesesPA" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
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
                                <asp:Label ID="lblDuracionVuelos" runat="server" Text="Duracion de vuelos" Font-Bold="true"></asp:Label>
                            </h2>
                            <div class="clearfix"></div>
                        </div>
                        <div class="row">
                            <div class="col-md-4 offset-8">
                                <asp:DropDownList ID="DDFiltroMesesV" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
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
                        <br />
                        <div class="row">
                            <div class="col-md-6">
                                <div class="x_title">
                                    <h2>
                                        <asp:Label ID="lblCostoFijoVariable" runat="server" Text="Costo Fijo y Variable" Font-Bold="true"></asp:Label>
                                    </h2>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4 offset-8">
                                        <asp:DropDownList ID="DDFiltroMesesFV" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div id="piechart_3d_7" style="min-height: 400px;">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="x_title">
                                    <h2>
                                        <asp:Label ID="lblCostoFijoVariableHora" runat="server" Text="Costo Fijo y Variable por Hora" Font-Bold="true"></asp:Label>
                                    </h2>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4 offset-8">
                                        <asp:DropDownList ID="DDFiltroMesesFVH" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div id="piechart_3d_8" style="min-height: 400px;">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-6">
                                <div class="x_title">
                                    <h2>
                                        <asp:Label ID="lblGastoTotal" runat="server" Text="Gastos Total" Font-Bold="true"></asp:Label>
                                    </h2>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4 offset-8">
                                        <asp:DropDownList ID="DDFiltroMesesGT" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div id="piechart_3d_9" style="min-height: 400px;">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="x_title">
                                    <h2>
                                        <asp:Label ID="lblGastoHora" runat="server" Text="Costo por Hora" Font-Bold="true"></asp:Label>
                                    </h2>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4 offset-8">
                                        <asp:DropDownList ID="DDFiltroMesesCH" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div id="piechart_3d_10" style="min-height: 400px;">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-6">
                                <div class="x_title">
                                    <h2>
                                        <asp:Label ID="lblNumVuelos" runat="server" Text="Número de Vuelos" Font-Bold="true"></asp:Label>
                                    </h2>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4 offset-8">
                                        <asp:DropDownList ID="DDFiltroMesesNV" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div id="piechart_3d_13" style="min-height: 400px;">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="x_title">
                                    <h2>
                                        <asp:Label ID="lblHorasVuelo" runat="server" Text="Horas de Vuelo" Font-Bold="true"></asp:Label>
                                    </h2>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4 offset-8">
                                        <asp:DropDownList ID="DDFiltroMesesHV" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div id="piechart_3d_14" style="min-height: 400px;">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-6">
                                <div class="x_title">
                                    <h2>
                                        <asp:Label ID="lblPromedioPasajerosDos" runat="server" Text="Promedio de Pasajeros" Font-Bold="true"></asp:Label>
                                    </h2>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4 offset-8">
                                        <asp:DropDownList ID="DDFiltroMesesPP" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div id="piechart_3d_15" style="min-height: 400px;">
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="x_title">
                                    <h2>
                                        <asp:Label ID="lblPRomedioCosto" runat="server" Text="Promedio de Costo" Font-Bold="true"></asp:Label>
                                    </h2>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4 offset-8">
                                        <asp:DropDownList ID="DDFiltroMesesPC" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div id="piechart_3d_16" style="min-height: 400px;">
                                        </div>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="x_title">
                                    <h2>
                                        <asp:Label ID="lblCategoriasLargoTiempo" runat="server" Text="Categorías a lo Largo del Tiempo" Font-Bold="true"></asp:Label>
                                    </h2>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4 offset-8">
                                        <asp:DropDownList ID="ddlCategoriasLT" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <div id="piechart_3d_17" style="min-height: 400px;">
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <div id="piechart_3d_18" style="min-height: 400px;">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-------->
                        <br />
                        <div class="row">
                            <div class="col-md-12">
                                <div class="x_title">
                                    <h2>
                                        <asp:Label ID="lblMapRutaAeroPrinc" runat="server" Text="Rutas y Aeropuertos Principales" Font-Bold="true"></asp:Label>
                                    </h2>
                                    <div class="clearfix"></div>
                                </div>
                                <div class="row">
                                    <div class="col-md-8">
                                        <span style="color: #bdbdbd; font-size: 16px;">&nbsp;&nbsp;<asp:Label ID="lblTusVuelos" runat="server" Text="" Font-Bold="true"></asp:Label></span>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:DropDownList ID="ddlFiltroMesesRA" runat="server" CssClass="form-control" Width="100%"></asp:DropDownList>
                                    </div>
                                </div>
                                <br />
                                <div class="row">

                                    <div class="col-md-7">
                                        <h5>
                                            <label runat="server" id="lbTitleMapR">Top Rutas</label>
                                            <label runat="server" style="display: none;" id="lbTitleMapA">Top Aeropuertos</label>
                                        </h5>
                                        <br />
                                        <div id="googleMap"></div>
                                        <%--<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d15008005.624851545!2d-111.65547970087938!3d23.313441203547026!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x84043a3b88685353%3A0xed64b4be6b099811!2zTcOpeGljbw!5e0!3m2!1ses!2smx!4v1629999888503!5m2!1ses!2smx" width="100%" height="450" style="border:0;" allowfullscreen="" loading="lazy"></iframe>--%>
                                    </div>
                                    <div class="col-md-5">
                                        <ul class="nav nav-tabs" id="myTab" role="tablist">
                                            <li class="nav-item" onclick="hometab_Click">
                                                <asp:LinkButton runat="server" ID="hometab" OnClientClick="hometab_Click()" CssClass="nav-link active" data-toggle="tab" href="#ContentPlaceHolder1_home" role="tab" aria-controls="ContentPlaceHolder1_home" aria-selected="true">
                                                    <asp:Label ID="lblTopRutas" runat="server" Text="Top Rutas"></asp:Label>
                                                </asp:LinkButton>
                                            </li>
                                            <li class="nav-item" onclick="profiletab_Click">
                                                <asp:LinkButton runat="server" ID="profiletab" OnClientClick="profiletab_Click()" CssClass="nav-link" data-toggle="tab" href="#ContentPlaceHolder1_profile" role="tab" aria-controls="ContentPlaceHolder1_profile" aria-selected="false">
                                                    <asp:Label ID="lblTopAeropuertos" runat="server" Text="Top Aeropuertos"></asp:Label>
                                                </asp:LinkButton>
                                            </li>
                                        </ul>
                                        <div class="tab-content" id="myTabContent">
                                            <div class="tab-pane fade show active" runat="server" id="home" role="tabpanel" aria-labelledby="home-tab">
                                                <br />
                                                <div class="col-md-12">
                                                    <div class="table-responsive">
                                                        <div class="card-box table-responsive">
                                                            <asp:UpdatePanel ID="upaPrincipal" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:GridView ID="gvRuta" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true"
                                                                        OnPageIndexChanging="gvRutas_PageIndexChanging" OnRowDataBound="gvRutas_RowDataBound" EmptyDataText="No Registros">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="rutas" />
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="tab-pane fade" runat="server" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                                                <br />
                                                <div class="col-md-12">
                                                    <div class="table-responsive">
                                                        <div class="card-box table-responsive">
                                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                                <ContentTemplate>
                                                                    <asp:GridView ID="gvAeropuerto" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true"
                                                                        OnPageIndexChanging="gvAeropuertos_PageIndexChanging" OnRowDataBound="gvAeropuertos_RowDataBound" EmptyDataText="No Registros">
                                                                        <Columns>
                                                                            <asp:BoundField DataField="clave" />
                                                                            <asp:BoundField DataField="aeropuerto" />
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
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
                </div>

                <!-------->
            </div>


            <style>
                html, body {
                    height: 100%;
                    margin: 0px;
                }

                #googleMap {
                    width: 100%;
                    height: 450px;
                }
            </style>

            <script src='<%=ResolveUrl("~/vendors/jquery/dist/jquery.min.js")%>'></script>
            <script src='<%=ResolveUrl("~/vendors/jquery/dist/jquery.js")%>'></script>

            <script
            src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC98wN4fcIzsEP7zyEey3V0LkvZ7KHUYdw&callback=initialize"
            async
            ></script>
            <!-- <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?sensor=false"></script> -->
            <script src='<%=ResolveUrl("~/build/js/RutasyAeropuertos.js")%>'></script>

            <script src='<%=ResolveUrl("~/build/js/GraficasJS/GraficasMeEsCategorias.js")%>'></script>
            <script src='<%=ResolveUrl("~/build/js/GraficasJS/GraficasMeEsCostoHoraVuelo.js")%>'></script>
            <script src='<%=ResolveUrl("~/build/js/GraficasJS/GraficasMeEsGastoTotal.js")%>'></script>
            <script src='<%=ResolveUrl("~/build/js/GraficasJS/GraficasMeEsCostoFijoVariableHora.js")%>'></script>
            <script src='<%=ResolveUrl("~/build/js/GraficasJS/GraficasMeEsCostoFijoVariable.js")%>'></script>
            <script src='<%=ResolveUrl("~/build/js/GraficasJS/GraficasMeEsPromedioPax.js")%>'></script>
            <script src='<%=ResolveUrl("~/build/js/GraficasJS/GraficasMeEsPromedioCosto.js")%>'></script>
            <script src='<%=ResolveUrl("~/build/js/GraficasJS/GraficasMeEsNumeroVuelos.js")%>'></script>
            <script src='<%=ResolveUrl("~/build/js/GraficasJS/GraficasMeEsHorasVoladas.js")%>'></script>
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
