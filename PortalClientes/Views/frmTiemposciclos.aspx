<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmTiemposciclos.aspx.cs" Inherits="PortalClientes.Views.frmTiemposciclos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:UpdatePanel ID="upaPrincipal" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="title_left">
                                <h3><asp:Label ID="lblHorasCiclos" runat="server" Text="Horas y Ciclos" Font-Bold="true"></asp:Label></h3>
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
                            <div class="col-md-12">
                                <div class="row" style="margin: 5px;">
                                    <div class="col-md-3 tile_count">
                                        <div class="" style="text-align: center;">
                                                <asp:Label ID="lblTotalHorasCiclos" runat="server" Text=" Total de Horas y Ciclos" Font-Bold="false"></asp:Label></span>
                                            <div class="count">
                                                <asp:Label ID="lblTotalHorasCiclosRes" runat="server" Font-Bold="true" Text="0000h 00m / 0000" CssClass="count4"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3 tile_count">
                                        <div class="" style="text-align: center;">
                                                <asp:Label ID="lblTotalMaquinauno" runat="server" Text=" Máquina 1 Horas y Ciclos" Font-Bold="false"></asp:Label></span>
                                            <div class="count">
                                                <asp:Label ID="lblTotalMaquinaunoRes" runat="server" Font-Bold="true" Text="0000h 00m / 0000" CssClass="count4" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3 tile_count">
                                        <div class="" style="text-align: center;">
                                                <asp:Label ID="lblTotalMaquinados" runat="server" Text=" Máquina 2 Horas y Ciclos" Font-Bold="false"></asp:Label></span>
                                            <div class="count">
                                                <asp:Label ID="lblTotalMaquinaunodosRes" runat="server" Font-Bold="true" Text="0000h 00m / 0000" CssClass="count4" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3 tile_count">
                                        <div class="" style="text-align: center;">
                                                <asp:Label ID="lblTotalAPU" runat="server" Text=" APU Horas y Ciclos" Font-Bold="false"></asp:Label></span>
                                            <div class="count">
                                                <asp:Label ID="lblTotalAPURes" runat="server" Font-Bold="true" Text="0000h 00m / 0000" CssClass="count4" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                
                            </div>
                        </div>
                    </div>
                </div>
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="x_panel" style="min-height: 55vh;">
                        <div class="x_title">
                            <h2>
                                <asp:Label ID="lblHorasyCiclos" runat="server" Text="Horas y Ciclos" Font-Bold="true"></asp:Label></h2>
                            <div class="clearfix"></div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="table-responsive">
                                    <div class="card-box table-responsive">
                                        Grid
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
