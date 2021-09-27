<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmTuAeronave.aspx.cs" Inherits="PortalClientes.Views.frmTuAeronave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-6">
            <div class="title_left">
                <h3>
                    <asp:Label ID="lblTitulo" runat="server"></asp:Label></h3>
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
            <div class="x_panel" style="min-height: 70vh;">
                <div class="x_title">
                    <h2>
                        <asp:Label ID="lblTuAeronave" runat="server" Text="Tu Aeronave" Font-Bold="true"></asp:Label></h2>
                    <ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                        <li><a class="close-link"><i class="fa fa-close"></i></a>
                        </li>
                    </ul>
                    <div class="clearfix"></div>
                </div>

                <!-- RLR -->

                <ul class="nav nav-tabs" id="myTab" role="tablist">
                    <li class="nav-item">
                        <a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">
                            <asp:Label ID="lblEspecificaciones" runat="server"></asp:Label></a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" id="profile-tab" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="false">
                            <asp:Label ID="lblDocumentos" runat="server"></asp:Label></a>
                    </li>
                </ul>
                <div class="tab-content" id="myTabContent">
                    <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-12" style="text-align: center;">
                                        <h3>
                                            <asp:Label ID="lblMatriculaTuAeronave" runat="server" Text="2015 Cessna Citation X+"></asp:Label></h3>
                                    </div>
                                </div>
                                <div class="row" style="background-color: #f2f2f2; padding: 5px; margin: 5px;">
                                    <div class="col-md-4">
                                        <asp:Label ID="lblFabricante" runat="server" Text="Fabricante:"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Label ID="lblFabricanteResp" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                                <div class="row" style="background-color: #f2f2f2; padding: 5px; margin: 5px;">
                                    <div class="col-md-4">
                                        <asp:Label ID="lblYear" runat="server" Text="Año:"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Label ID="lblYearResp" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                                <div class="row" style="background-color: #f2f2f2; padding: 5px; margin: 5px;">
                                    <div class="col-md-4">
                                        <asp:Label ID="lblModelo" runat="server" Text="Modelo:"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Label ID="lblModeloResp" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                                <div class="row" style="background-color: #f2f2f2; padding: 5px; margin: 5px;">
                                    <div class="col-md-4">
                                        <asp:Label ID="lblRegistro" runat="server" Text="Registro No.:"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Label ID="lblRegistroResp" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                                <div class="row" style="background-color: #f2f2f2; padding: 5px; margin: 5px;">
                                    <div class="col-md-4">
                                        <asp:Label ID="lblSerie" runat="server" Text="Serie No.:"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Label ID="lblSerieResp" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12" style="text-align: center;">
                                        <h3>
                                            <asp:Label ID="lblCapacidad" runat="server" Text="Capacidad"></asp:Label></h3>
                                    </div>
                                </div>
                                <div class="row" style="background-color: #f2f2f2; padding: 5px; margin: 5px;">
                                    <div class="col-md-4">
                                        <asp:Label ID="lblPasajeros" runat="server" Text="Pasajeros:"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Label ID="lblPasajerosResp" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                                <div class="row" style="background-color: #f2f2f2; padding: 5px; margin: 5px;">
                                    <div class="col-md-4">
                                        <asp:Label ID="lblTripulacion" runat="server" Text="Tripulación:"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Label ID="lblTripulacionRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                                <div class="row" style="background-color: #f2f2f2; padding: 5px; margin: 5px;">
                                    <div class="col-md-4">
                                        <asp:Label ID="lblDimencionesExt" runat="server" Text="Dimenciones Exteriores:"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Label ID="lblDimencionesExtRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                                <div class="row" style="background-color: #f2f2f2; padding: 5px; margin: 5px;">
                                    <div class="col-md-4">
                                        <asp:Label ID="lblDimencionesInt" runat="server" Text="Dimenciones Interiores:"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Label ID="lblDimencionesIntRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>

                            <div class="row">
                            <div class="col-md-6">
                                <div class="row" style="background-color: #f2f2f2; margin: 5px;">
                                    <div class="col-md-7">
                                        <asp:Label ID="lblMaxFuel" runat="server" Text="Máx. Combustible:"></asp:Label>
                                    </div>
                                    <div class="col-md-5">
                                        <asp:Label ID="lblMaxFuelResp" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="row" style="background-color: #f2f2f2; margin: 5px;">
                                    <div class="col-md-7">
                                        <asp:Label ID="lblMinFuel" runat="server" Text="Mín. Combustible:"></asp:Label>
                                    </div>
                                    <div class="col-md-5">
                                        <asp:Label ID="lblMinFuelResp" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            </div>
                            <div class="row">
                            <div class="col-md-6">
                                <div class="row" style="background-color: #f2f2f2; margin: 5px;">
                                    <div class="col-md-7">
                                        <asp:Label ID="lblTipoCombustible" runat="server" Text="Tipo Combustible:"></asp:Label>
                                    </div>
                                    <div class="col-md-5">
                                        <asp:Label ID="lblTipoCombustibleRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="row" style="background-color: #f2f2f2; margin: 5px;">
                                    <div class="col-md-7">
                                        <asp:Label ID="lblRendimiento" runat="server" Text="Rendimiento:"></asp:Label>
                                    </div>
                                    <div class="col-md-5">
                                        <asp:Label ID="lblRendimientoRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            </div>
                            <div class="row">
                            <div class="col-md-6">
                                <div class="row" style="background-color: #f2f2f2; margin: 5px;">
                                    <div class="col-md-7">
                                        <asp:Label ID="lblVelocidad" runat="server" Text="Velocidad Crucero:"></asp:Label>
                                    </div>
                                    <div class="col-md-5">
                                        <asp:Label ID="lblVelocidadRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="row" style="background-color: #f2f2f2; margin: 5px;">
                                    <div class="col-md-7">
                                        <asp:Label ID="lblMaxAltura" runat="server" Text="Altitud Máxima:"></asp:Label>
                                    </div>
                                    <div class="col-md-5">
                                        <asp:Label ID="lblMaxAlturaRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            </div>
                            
                            <div class="row">
                            <div class="col-md-6">
                                <div class="row" style="background-color: #f2f2f2; margin: 5px;">
                                    <div class="col-md-7">
                                        <asp:Label ID="lblDistancia" runat="server" Text="Distancia:"></asp:Label>
                                    </div>
                                    <div class="col-md-5">
                                        <asp:Label ID="lblDistanciaRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="row" style="background-color: #f2f2f2; margin: 5px;">
                                    <div class="col-md-7">
                                        <asp:Label ID="lblPeso" runat="server" Text="Peso:"></asp:Label>
                                    </div>
                                    <div class="col-md-5">
                                        <asp:Label ID="lblPesoRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            </div>
                        </div>
                            <div class="col-md-6">
                                <br />
                                <br />
                                <br />
                                <div runat="server" id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                                </div>
                            </div>
                        </div>
                        
                    </div>
                    <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                        <br />
                        <div class="table-responsive">
                            <table class="table table-striped table-bordered table-hover">
                                <tr>
                                    <th>Nombre de documento
                                    </th>
                                    <th>Tipo de Documento
                                    </th>
                                    <th>Fecha de carga
                                    </th>
                                    <th>Acciones
                                    </th>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblNombreDocRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTipoDocRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblFechaUpload" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                    </td>
                                    <td style="text-align: center;">
                                        <a><i class="fa fa-download"></i></a>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </div>


                <!-- RLR -->
            </div>
        </div>
    </div>
</asp:Content>
