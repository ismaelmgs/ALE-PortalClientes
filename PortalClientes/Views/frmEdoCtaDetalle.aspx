<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmEdoCtaDetalle.aspx.cs" Inherits="PortalClientes.Views.frmEdoCtaDetalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-6">
            <div class="title_left">
                <h3><asp:Label ID="lblTituloEdoCtaDet" runat="server" Text="Estado de Cuenta Detallado"></asp:Label></h3>
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
        <div class="x_panel" style="min-height: 55vh;">
            <div class="x_title">
                <h2><asp:Label ID="lblEdoCtaDetalle" runat="server" Text="Estado de Cuenta Detallado" Font-Bold="true"></asp:Label></h2>
                <div class="clearfix"></div>
            </div>
            --- Contenido ---
            <br />
            <hr style="border:1px solid #efefef;" />
            <div style="width:100%; text-align:center;">
                <asp:LinkButton ID="btnRegresarMeEscEng" runat="server" Text="<i class='fa fa-undo' style='color:#73879C;font-size:14px;'></i> Account Statements <i class='fa fa-list' style='color:#73879C;font-size:14px;'></i>" CssClass="btn" href="frmMetricasEstadisticas.aspx" />
                <asp:LinkButton ID="btnRegresarMeEsc" runat="server" Text="<i class='fa fa-undo' style='color:#73879C;font-size:14px;'></i> Estados de Cuenta <i class='fa fa-list' style='color:#73879C;font-size:14px;'></i>" CssClass="btn" href="frmMetricasEstadisticas.aspx" />
            </div>
        </div>
    </div>
    </div>
</asp:Content>
