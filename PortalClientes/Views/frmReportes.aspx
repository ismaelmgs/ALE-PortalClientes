<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmReportes.aspx.cs" Inherits="PortalClientes.Views.frmReportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upaPrincipal" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-6">
                    <div class="title_left">
                        <h3>
                            <asp:Label ID="lblReportesFijosVariables" runat="server" Text="Reportes" Font-Bold="true"></asp:Label></h3>
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
                                <asp:Label ID="lblReportesFijosVar" runat="server" Text="Gastos Fijos y variables" Font-Bold="true"></asp:Label></h2>
                            <div class="clearfix"></div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="row" style="margin: 0px;">
                                    <div class="col-md-12 table-responsive" style="padding-left: 1px !important; padding-right: 1px !important">
                                        <table class="table" style="border: 0px;">
                                            <tr style="background-color: #00000003;">
                                                <td style="border-bottom: 1px solid #dee2e6; padding: 6px;">
                                                    <asp:LinkButton runat="server" ID="btnDetReporte1" OnClick="btnDetReporte_Click" data-report="1">
                                                        <img src="../build/images/detalle_gatos.png" style="width: 32px;" />&nbsp;
                                                        <span style="font-size: 17px; font-weight: bold;">
                                                            <asp:Label ID="lblRepGastosFijosVariables" runat="server" Text=" Gastos Fijos y Variables" Font-Bold="true"></asp:Label>
                                                        </span>
                                                        <br />
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>
                                            <td style="height: 3px;"></td>
                                            </tr>
                                            <tr style="background-color: #00000003;">
                                                <td style="border-bottom: 1px solid #dee2e6; padding: 6px;">
                                                    <asp:LinkButton runat="server" ID="btnDetReporte2" OnClick="btnDetReporte_Click" data-report="2">
                                                        <img src="../build/images/detalle_gatos.png" style="width: 32px;" />&nbsp;
                                                        <span style="font-size: 17px; font-weight: bold;">
                                                            <asp:Label ID="lblRepGastosAeropuerto" runat="server" Text=" Gastos por Aeropuerto" Font-Bold="true"></asp:Label>
                                                        </span>
                                                        <br />
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 3px;"></td>
                                            </tr>
                                            <tr style="background-color: #00000003;">
                                                <td style="border-bottom: 1px solid #dee2e6; padding: 6px;">
                                                    <asp:LinkButton runat="server" ID="btnDetReporte3" OnClick="btnDetReporte_Click" data-report="3">
                                                        <img src="../build/images/detalle_gatos.png" style="width: 32px;" />&nbsp;<span style="font-size: 17px; font-weight: bold;"><asp:Label ID="lblRepGastosProveedor" runat="server" Text=" Gastos por Proveedor" Font-Bold="true"></asp:Label></span><br />
                                                    </asp:LinkButton>
                                                </td>
                                            </tr>
                                        </table>

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
