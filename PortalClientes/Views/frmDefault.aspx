<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmDefault.aspx.cs" Inherits="PortalClientes.frmDefault" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row">
        <div class="col-md-6">
            <div class="title_left">
                <h3>Bienvenido</h3>
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
                <h2><asp:Label ID="lblEstadoDeCuenta" runat="server" Text="Nuestra Flota" Font-Bold="true"></asp:Label></h2>
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
<!-- RLR Carrusel inicio-->

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
                          <img class="d-block w-100" src="../jets/fotos_portada_01.jpg" alt="Slide 01">
                        </div>
                        <div class="carousel-item">
                          <img class="d-block w-100" src="../jets/fotos_portada_02.jpg" alt="Slide 02">
                        </div>
                        <div class="carousel-item">
                          <img class="d-block w-100" src="../jets/fotos_portada_03.jpg" alt="Slide 03">
                        </div>
                          <div class="carousel-item">
                          <img class="d-block w-100" src="../jets/fotos_portada_04.jpg" alt="Slide 04">
                        </div>
                          <div class="carousel-item">
                          <img class="d-block w-100" src="../jets/fotos_portada_05.jpg" alt="Slide 05">
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

<!-- RLR Carrusel fin -->
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
