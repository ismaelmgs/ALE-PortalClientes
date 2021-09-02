<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmTuAeronave.aspx.cs" Inherits="PortalClientes.Views.frmTuAeronave" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row">
        <div class="col-md-6">
            <div class="title_left">
                <h3>Tu Aeronave</h3>
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
                <h2><asp:Label ID="lblTuAeronave" runat="server" Text="Tu Aeronave" Font-Bold="true"></asp:Label></h2>
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
                        <a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">Especificaciones</a>
                      </li>
                      <li class="nav-item">
                        <a class="nav-link" id="profile-tab" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="false">Documentos</a>
                      </li>
                    </ul>
                    <div class="tab-content" id="myTabContent">
                      <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                          <div class="row">
                            <div class="col-md-6">
                                <div class="row">
                                    <div class="col-md-12" style="text-align:center;">
                                        <h3><asp:Label ID="lblMatriculaTuAeronave" runat="server" Text="2015 Cessna Citation X+"></asp:Label></h3>
                                    </div>
                                </div>
                                <br /><br />
                                <div class="row" style="background-color:#f2f2f2; padding:5px;margin:5px;">
                                    <div class="col-md-4">
                                        <asp:Label ID="lblOrigen" runat="server" Text="Origen:"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Label ID="lblOrigenText" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12" style="text-align:center;">
                                        <h3><asp:Label ID="lblCapacidad" runat="server" Text="Capacidad"></asp:Label></h3>
                                    </div>
                                </div>
                                <br /><br />
                                <div class="row" style="background-color:#f2f2f2; padding:5px;margin:5px;">
                                    <div class="col-md-4">
                                        <asp:Label ID="Label2" runat="server" Text="Origen:"></asp:Label>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Label ID="Label3" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div id="carouselExampleIndicators" class="carousel slide" data-ride="carousel">
                                    <ol class="carousel-indicators">
                                    <li data-target="#carouselExampleIndicators" data-slide-to="0" class="active"></li>
                                    <li data-target="#carouselExampleIndicators" data-slide-to="1"></li>
                                    <li data-target="#carouselExampleIndicators" data-slide-to="2"></li>
                                    <li data-target="#carouselExampleIndicators" data-slide-to="3"></li>
                                    <li data-target="#carouselExampleIndicators" data-slide-to="4"></li>
                                    </ol>
                                    <div class="carousel-inner">
                                    <div class="carousel-item active">
                                        <img class="d-block w-100" src="..." alt="slide 1">
                                    </div>
                                    <div class="carousel-item">
                                        <img class="d-block w-100" src="..." alt="slide 2">
                                    </div>
                                    <div class="carousel-item">
                                        <img class="d-block w-100" src="..." alt="slide 3">
                                    </div>
                                    <div class="carousel-item">
                                        <img class="d-block w-100" src="..." alt="slide 4">
                                    </div>
                                    <div class="carousel-item">
                                        <img class="d-block w-100" src="..." alt="slide 5">
                                    </div>
                                    </div>
                                    <a class="carousel-control-prev" href="#carouselExampleIndicators" role="button" data-slide="prev">
                                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                    <span class="sr-only">Previous</span>
                                    </a>
                                    <a class="carousel-control-next" href="#carouselExampleIndicators" role="button" data-slide="next">
                                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                    <span class="sr-only">Next</span>
                                    </a>
                                </div> 
                            </div>
                        </div>
                      </div>
                      <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                          <br />
                           
                      </div>
                    </div>


            <!-- RLR -->
        </div>
    </div>
    </div>
</asp:Content>
