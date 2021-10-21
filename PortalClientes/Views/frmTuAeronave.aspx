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
                    <%--<ul class="nav navbar-right panel_toolbox">
                        <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                        </li>
                        <li><a class="close-link"><i class="fa fa-close"></i></a>
                        </li>
                    </ul>--%>
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
                            <div class="col-md-7">
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
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="row" style="background-color: #f2f2f2; padding: 5px; margin: 5px;">
                                        <div class="col-md-9">
                                            <asp:Label ID="lblPesoMaxDespegue" runat="server" Text="Peso Máx. Despegue:"></asp:Label>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:Label ID="lblPesoMaxDespegueRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="row" style="background-color: #f2f2f2; padding: 5px; margin: 5px;">
                                        <div class="col-md-9">
                                            <asp:Label ID="lblPesoMaxAterrizaje" runat="server" Text="Peso Máx. Aterrizaje:"></asp:Label>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:Label ID="lblPesoMaxAterrizajeRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="row" style="background-color: #f2f2f2; padding: 5px; margin: 5px;">
                                        <div class="col-md-9">
                                            <asp:Label ID="lblMaxCeroCombustible" runat="server" Text="Peso Máx. 0 combustible:"></asp:Label>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:Label ID="lblMaxCeroCombustibleRes" runat="server" Text="----------" Font-Bold="true"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="row" style="background-color: #f2f2f2; padding: 5px; margin: 5px;">
                                        <div class="col-md-9">
                                            <asp:Label ID="lblPesoBasicoOperacion" runat="server" Text="Peso Básico Operación:"></asp:Label>
                                        </div>
                                        <div class="col-md-3">
                                            <asp:Label ID="lblPesoBasicoOperacionRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            <div class="col-md-6">
                                <div class="row" style="background-color: #f2f2f2; padding: 5px; margin: 5px;">
                                    <div class="col-md-9">
                                        <asp:Label ID="lblVelocidad" runat="server" Text="Velocidad Crucero:"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="lblVelocidadRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="row" style="background-color: #f2f2f2; padding: 5px; margin: 5px;">
                                    <div class="col-md-9">
                                        <asp:Label ID="lblMaxAltura" runat="server" Text="Altitud Máxima:"></asp:Label>
                                    </div>
                                    <div class="col-md-3">
                                        <asp:Label ID="lblMaxAlturaRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            </div>
                        </div>
                            <div class="col-md-5">
                                <br /><br /><br />
                                <div runat="server" id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                                </div>
                            </div>
                        </div>
                        
                    </div>
                    <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                        <br />
                        <div class="table-responsive">
                            <div class="card-box table-responsive">
                                <asp:GridView ID="gvDocumentos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover"
                                    DataKeyNames="NombreImagen" AllowPaging="true" OnRowDataBound="gvDocumentos_RowDataBound" EmptyDataText="No Registros">
                                    <HeaderStyle />
                                    <RowStyle />
                                    <AlternatingRowStyle />
                                    <Columns>
                                        <asp:BoundField DataField="NombreImagen" />
                                        <asp:BoundField DataField="Extension" HeaderText="ID" ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol"/>
                                        <asp:BoundField DataField="Imagen" HeaderText="ID" ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol"/>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%--<asp:ImageButton ID="imbViewDoc" runat="server" ImageUrl="~/Images/icons/visualizar.png" Width="24px" Height="28px"
                                                    OnClick="imbViewDoc_Click" CommandName="Mats" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />&nbsp;&nbsp;&nbsp;--%>
                                                <asp:ImageButton ID="imbDownloadDoc" runat="server" ImageUrl="~/Images/icons/descargar.png" Width="26px" Height="28px"
                                                    OnClick="imbDownloadDoc_Click" CommandName="Modulos" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />&nbsp;&nbsp;&nbsp;
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <asp:HiddenField runat="server" ID="HFPath"/>
                    </div>
                </div>


                <!-- RLR -->
            </div>
        </div>
    </div>

    <style type="text/css">
      .hiddencol
      {
        display: none;
      }
    </style>
</asp:Content>
