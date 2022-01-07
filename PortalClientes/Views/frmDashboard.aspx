<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmDashboard.aspx.cs" UICulture="es" Culture="es-MX" Inherits="PortalClientes.Views.frmDashboard" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v18.1, Version=18.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upaPrincipal" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-6">
                    <div class="title_left">
                        <h3>Dashboard</h3>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="title_right">
                        <div class="col-md-5 col-sm-5 form-group pull-right top_search">
                            <div class="input-group">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:HiddenField runat="server" ID="HFoLat" />
            <asp:HiddenField runat="server" ID="HFoLon" />
            <asp:HiddenField runat="server" ID="HFdLat" />
            <asp:HiddenField runat="server" ID="HFdLon" />
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2>
                                <asp:Label ID="lblEstadoDeVuelo" runat="server" Text="" Font-Bold="true"></asp:Label></h2>
                            <div class="clearfix"></div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <br />
                                <div class="row">
                                    <div class="col-md-12" style="text-align: center;">
                                        <span style="font-size: 20px; color: #ffffff; background-color: #1a8ebb; padding: 8px; border-radius: 60%; margin: 4px;"><i class="fa fa-plane" style="padding: 5px;"></i></span>&nbsp;&nbsp;<asp:Label ID="lblCompleto" runat="server" Text="" Font-Bold="true" Style="font-size: 20px;"></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Label ID="lblOrigenText" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                        <asp:Label ID="lblOrigen" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Label ID="lblDestinoText" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                        <asp:Label ID="lblDestino" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:Label ID="lblSalida" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-md-10">
                                        <asp:Label ID="lblSalidaText" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-2">
                                        <asp:Label ID="lblLlego" runat="server" Text=""></asp:Label>
                                    </div>
                                    <div class="col-md-10">
                                        <asp:Label ID="lblLlegoText" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <ul class="nav nav-tabs" id="myTab" role="tablist">
                                    <li class="nav-item">
                                        <a class="nav-link active" id="hometab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">
                                            <asp:Label ID="lblVuelos" runat="server"></asp:Label></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" id="profiletab" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="false">
                                            <asp:Label ID="lblHorasVuelo" runat="server"></asp:Label></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" hidden id="contacttab" data-toggle="tab" href="#contact" role="tab" aria-controls="contact" aria-selected="false">
                                            <asp:Label ID="lblNMVuelo" runat="server"></asp:Label></a>
                                    </li>
                                </ul>
                                <div class="tab-content" id="myTabContent">
                                    <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                                        <br />
                                        <div class="widget_summary">
                                            <div class="w_left w_25">
                                                <asp:Label ID="lblMes01Vuelo" runat="server" Text="Mes 1"></asp:Label>
                                            </div>
                                            <div class="w_right w_20">
                                                <asp:Label ID="lblMes01VueloNum" runat="server" Text="8" Style="font-size: 14px;"></asp:Label>&nbsp;
                                            </div>
                                            <div class="w_center w_55">
                                                <dx:BootstrapProgressBar ID="barV1" ShowPosition="false" runat="server" Minimum="0" Maximum="100"></dx:BootstrapProgressBar>
                                            </div>
                                        </div>
                                        <div class="widget_summary">
                                            <div class="w_left w_25">
                                                <asp:Label ID="lblMes02Vuelo" runat="server" Text="Mes 2"></asp:Label>
                                            </div>
                                            <div class="w_right w_20">
                                                <asp:Label ID="lblMes02VueloNum" runat="server" Text="9" Style="font-size: 14px;"></asp:Label>&nbsp;
                                            </div>
                                            <div class="w_center w_55">
                                                <dx:BootstrapProgressBar ID="BarV2" ShowPosition="false" runat="server" Minimum="0" Maximum="100"></dx:BootstrapProgressBar>
                                            </div>
                                        </div>
                                        <div class="widget_summary">
                                            <div class="w_left w_25">
                                                <asp:Label ID="lblMes03Vuelo" runat="server" Text="Mes 3"></asp:Label>
                                            </div>
                                            <div class="w_right w_20">
                                                <asp:Label ID="lblMes03VueloNum" runat="server" Text="7" Style="font-size: 14px;"></asp:Label>&nbsp;
                                            </div>
                                            <div class="w_center w_55">
                                                <dx:BootstrapProgressBar ID="BarV3" ShowPosition="false" runat="server" Minimum="0" Maximum="100"></dx:BootstrapProgressBar>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                                        <br />
                                        <div class="widget_summary">
                                            <div class="w_left w_25">
                                                <asp:Label ID="lblMes01bVuelo" runat="server" Text="Mes 1b"></asp:Label>
                                            </div>
                                            <div class="w_right w_20">
                                                <asp:Label ID="lblMes01bVueloNum" runat="server" Text="8" Style="font-size: 14px;"></asp:Label>&nbsp;
                                            </div>
                                            <div class="w_center w_55">
                                                <dx:BootstrapProgressBar ID="BarH1" ShowPosition="false" runat="server" Minimum="0" Maximum="100"></dx:BootstrapProgressBar>
                                            </div>
                                        </div>
                                        <div class="widget_summary">
                                            <div class="w_left w_25">
                                                <asp:Label ID="lblMes02bVuelo" runat="server" Text="Mes 2b"></asp:Label>
                                            </div>
                                            <div class="w_right w_20">
                                                <asp:Label ID="lblMes02bVueloNum" runat="server" Text="9" Style="font-size: 14px;"></asp:Label>&nbsp;
                                            </div>
                                            <div class="w_center w_55">
                                                <dx:BootstrapProgressBar ID="BarH2" ShowPosition="false" runat="server" Minimum="0" Maximum="100"></dx:BootstrapProgressBar>
                                            </div>
                                        </div>
                                        <div class="widget_summary">
                                            <div class="w_left w_25">
                                                <asp:Label ID="lblMes03bVuelo" runat="server" Text="Mes 3b"></asp:Label>
                                            </div>
                                            <div class="w_right w_20">
                                                <asp:Label ID="lblMes03bVueloNum" runat="server" Text="7" Style="font-size: 14px;"></asp:Label>&nbsp;
                                            </div>
                                            <div class="w_center w_55">
                                                <dx:BootstrapProgressBar ID="BarH3" ShowPosition="false" runat="server" Minimum="0" Maximum="100"></dx:BootstrapProgressBar>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="tab-pane fade" id="contact" hidden role="tabpanel" aria-labelledby="contact-tab">
                                        <br />
                                        <div class="widget_summary">
                                            <div class="w_left w_25">
                                                <asp:Label ID="lblMes01cVuelo" runat="server" Text="Mes 1c"></asp:Label>
                                            </div>
                                            <div class="w_right w_20">
                                                <asp:Label ID="lblMes01cVueloNum" runat="server" Text="8" Style="font-size: 14px;"></asp:Label>&nbsp;
                                            </div>
                                            <div class="w_center w_55">
                                                <dx:BootstrapProgressBar ID="BarNM1" ShowPosition="false" runat="server" Minimum="0" Maximum="100"></dx:BootstrapProgressBar>
                                            </div>
                                        </div>
                                        <div class="widget_summary">
                                            <div class="w_left w_25">
                                                <asp:Label ID="lblMes02cVuelo" runat="server" Text="Mes 2c"></asp:Label>
                                            </div>
                                            <div class="w_right w_20">
                                                <asp:Label ID="lblMes02cVueloNum" runat="server" Text="9" Style="font-size: 14px;"></asp:Label>&nbsp;
                                            </div>
                                            <div class="w_center w_55">
                                                <dx:BootstrapProgressBar ID="BarNM2" ShowPosition="false" runat="server" Minimum="0" Maximum="100"></dx:BootstrapProgressBar>
                                            </div>
                                        </div>
                                        <div class="widget_summary">
                                            <div class="w_left w_25">
                                                <asp:Label ID="lblMes03cVuelo" runat="server" Text="Mes 3c"></asp:Label>
                                            </div>
                                            <div class="w_right w_20">
                                                <asp:Label ID="lblMes03cVueloNum" runat="server" Text="7" Style="font-size: 14px;"></asp:Label>&nbsp;
                                            </div>
                                            <div class="w_center w_55">
                                                <dx:BootstrapProgressBar ID="BarNM3" ShowPosition="false" runat="server" Minimum="0" Maximum="100"></dx:BootstrapProgressBar>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <div id="googleMap"></div>
                                <%--<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d15008005.624851545!2d-111.65547970087938!3d23.313441203547026!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x84043a3b88685353%3A0xed64b4be6b099811!2zTcOpeGljbw!5e0!3m2!1ses!2smx!4v1629999888503!5m2!1ses!2smx" width="100%" height="450" style="border:0;" allowfullscreen="" loading="lazy"></iframe>--%>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2>
                                <asp:Label ID="lblResumenDeCuenta" runat="server" Text="" Font-Bold="true"></asp:Label>
                                |
                        <asp:Label ID="lblMatriculaAeronave" runat="server" Text="" Font-Bold="true"></asp:Label></h2>
                            <div class="clearfix"></div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Label ID="lblSaldo" runat="server" Text="Saldo Actual" Font-Bold="true"></asp:Label><br />
                                <span style="font-size: 30px;">
                                    <asp:Label ID="lblSaldoActualSimbolo" runat="server" Text=" $" Font-Bold="true" CssClass="count2" />
                                    <asp:Label ID="lblSaldoNumber" runat="server" Text="181,011.65" Font-Bold="true"></asp:Label></span>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:Label ID="lblIncVenc90Dias" runat="server" Text="incluido el vencimiento (+ de 90 días)" Font-Bold="true"></asp:Label>
                                        &nbsp;&nbsp; <span style="font-weight: bold;">
                                            <%--<asp:Label ID="lblIncVenc90DiasNumber" runat="server" Text="181,011.65" Font-Bold="true"></asp:Label>
                                            USD</span>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <asp:Label ID="lblUltimaDeclaracion" runat="server" Text="Ultima declaración" Font-Bold="true"></asp:Label><br />
                                <span style="font-size: 30px;">
                                    <asp:Label ID="lblUtimaDeclaracionSimbolo" runat="server" Text=" $" Font-Bold="true" CssClass="count2" />
                                    <asp:Label ID="lblultimaDeclaracionText" runat="server" Text="58,182.87" Font-Bold="true"></asp:Label></span>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <table>
                                            <tr>
                                                <td valign="top">
                                                    <asp:Label ID="lblDeclaracionPara" runat="server" Text="Declaración para:" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td>&nbsp;&nbsp;&nbsp;
                                                </td>
                                                <%--<td>
                                                    <span style="font-weight: bold;">
                                                        <asp:Label ID="lblDeclaracionMesAno1" runat="server" Text="Marzo 2021" Font-Bold="true"></asp:Label>
                                                    </span>
                                                </td>--%>
                                            </tr>
                                            <%--<tr>
                                                <td valign="top">
                                                    <asp:Label ID="lblVence" runat="server" Text="Vence:" Font-Bold="true"></asp:Label>
                                                </td>
                                                <td>&nbsp;&nbsp;&nbsp;
                                                </td>
                                                <td>
                                                    <span style="font-weight: bold;">
                                                        <asp:Label ID="lblDeclaracionMesAno2" runat="server" Text="Abril 15 2020" Font-Bold="true"></asp:Label>
                                                    </span>
                                                </td>
                                            </tr>--%>
                                        </table>
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
                    <div class="x_panel">
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
                    </div>
                </div>
            </div>
            <script src='<%=ResolveUrl("~/vendors/jquery/dist/jquery.min.js")%>'></script>
            <script src='<%=ResolveUrl("~/vendors/jquery/dist/jquery.js")%>'></script>
            <script src='<%=ResolveUrl("~/build/js/GraficasJS/GraficasDashboard.js")%>'></script>

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
            <script
            src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC98wN4fcIzsEP7zyEey3V0LkvZ7KHUYdw&callback=initialize"
            async
            ></script>
            <!-- <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?sensor=false"></script> -->
            <script type="text/javascript">
      function initialize() {
    // Configuración del mapa
    var mapProp = {
      zoom: 5,
      center: {lat: 24.4848937, lng: -103.3544444},
    };
    // Agregando el mapa al tag de id googleMap
    var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);
      
    // Coordenada de la ruta
    var flightPlanCoordinates = [
      {lat: Number.parseFloat($('#ContentPlaceHolder1_HFoLat').val()), lng: Number.parseFloat($('#ContentPlaceHolder1_HFoLon').val())},
      {lat: Number.parseFloat($('#ContentPlaceHolder1_HFdLat').val()), lng: Number.parseFloat($('#ContentPlaceHolder1_HFdLon').val())}
    ];
     
    // Información de la ruta (coordenadas, color de línea, etc...)
    var flightPath = new google.maps.Polyline({
      path: flightPlanCoordinates,
      geodesic: true,
      strokeColor: '#FF0000',
      strokeOpacity: 1.0,
      strokeWeight: 2
    });

    for (i = 0; i < flightPlanCoordinates.length; i++) {
        if (i == 0 || i == flightPlanCoordinates.length-1) {
            var marker = new google.maps.Marker({
                position: flightPlanCoordinates[i],
                label: 'MX',
                map: map
            });
        }
    }
     
    // Creando la ruta en el mapa
    flightPath.setMap(map);
    }
      
    // Inicializando el mapa cuando se carga la página
  //   google.maps.event.addDomListener(window, 'load', initialize);
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


