<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmMantenimientos.aspx.cs" Inherits="PortalClientes.Views.frmMantenimientos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upaPrincipal" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-6">
                    <div class="title_left">
                        <h3><asp:Label ID="lblMantenimientosHeader" runat="server" Text=" Mantenimientos" Font-Bold="false"></asp:Label></h3>
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
                            <h2>
                                <asp:Label ID="lblMantenimientos" runat="server" Text="Mantenimientos" Font-Bold="true"></asp:Label></h2>
                            <div class="clearfix"></div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">

                                <!-- RLR -->

                                <ul class="nav nav-tabs" id="myTab" role="tablist">
                                    <li class="nav-item">
                                        <a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">
                                            <asp:Label ID="lblProgramado" runat="server" Text="Programado"></asp:Label></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" id="profile-tab" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="false">
                                            <asp:Label ID="lblProyectado" runat="server" Text="Proyectado"></asp:Label></a>
                                    </li>
                                </ul>
                                <div class="tab-content" id="myTabContent">
                                    <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                                        Grid
                                    </div>
                                    <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                                        <div class="x_title">
                                            <h2>
                                                <asp:Label ID="MesEnCurso" runat="server" Text="Mes en curso" Font-Bold="true"></asp:Label></h2>
                                            <div class="clearfix"></div>
                                        </div>
                                            Grid
                                        <br /><br />
                                        <hr />
                                        <br />
                                        <div class="x_title">
                                            <h2>
                                                <asp:Label ID="lblSiguineteMes" runat="server" Text="Siguiente Mes" Font-Bold="true"></asp:Label></h2>
                                            <div class="clearfix"></div>
                                        </div>
                                            Grid
                                    </div>
                                </div>

                                <!-- RLR -->

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
