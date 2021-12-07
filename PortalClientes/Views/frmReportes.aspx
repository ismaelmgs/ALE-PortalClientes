<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmReportes.aspx.cs" Inherits="PortalClientes.Views.frmReportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row">
        <div class="col-md-6">
            <div class="title_left">
                <h3><asp:Label ID="lblReportesFijosVariables" runat="server" Text="Reportes" Font-Bold="true"></asp:Label></h3>
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
                <h2><asp:Label ID="lblReportesFijosVar" runat="server" Text="Gastos Fijos y variables" Font-Bold="true"></asp:Label></h2>
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
                    <div class="row" style="margin: 0px;">
                        <div class="col-md-12 table-responsive" style="padding-left: 1px !important; padding-right: 1px !important">
                            <table class="table" style="border: 0px;">
                                <tr style="background-color: #00000003;">
                                    <td style="border-bottom: 1px solid #dee2e6; padding: 6px;">
                                        <img src="../build/images/detalle_gatos.png" style="width: 32px;" />&nbsp;<span style="font-size: 17px; font-weight: bold;"><asp:Label ID="lblRepGastosFijos" runat="server" Text=" Gastos Fijos" Font-Bold="true"></asp:Label></span><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 3px;"></td>
                                </tr>
                                <tr style="background-color: #00000003;">
                                    <td style="border-bottom: 1px solid #dee2e6; padding: 6px;">
                                        <img src="../build/images/detalle_gatos.png" style="width: 32px;" />&nbsp;<span style="font-size: 17px; font-weight: bold;"><asp:Label ID="lblRepGastosVariables" runat="server" Text=" Gastos Variables" Font-Bold="true"></asp:Label></span><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 3px;"></td>
                                </tr>
                                <tr style="background-color: #00000003;">
                                    <td style="border-bottom: 1px solid #dee2e6; padding: 6px;">
                                        <img src="../build/images/detalle_gatos.png" style="width: 32px;" />&nbsp;<span style="font-size: 17px; font-weight: bold;"><asp:Label ID="lblRepGastosAeropuerto" runat="server" Text=" Gastos por Aeropuerto" Font-Bold="true"></asp:Label></span><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 3px;"></td>
                                </tr>
                                <tr style="background-color: #00000003;">
                                    <td style="border-bottom: 1px solid #dee2e6; padding: 6px;">
                                        <img src="../build/images/detalle_gatos.png" style="width: 32px;" />&nbsp;<span style="font-size: 17px; font-weight: bold;"><asp:Label ID="lblRepGastosProveedor" runat="server" Text=" Gastos por Proveedor" Font-Bold="true"></asp:Label></span><br />
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
</asp:Content>
