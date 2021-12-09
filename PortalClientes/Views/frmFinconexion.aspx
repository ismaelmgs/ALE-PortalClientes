<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmFinconexion.aspx.cs" Inherits="PortalClientes.Views.frmFinconexion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upaPrincipal" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-6">
                    <div class="title_left">
                        <h3>
                            <asp:Label ID="lblSesionExp" runat="server" Text="Sesión Expirada"></asp:Label></h3>
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
                            <h2>&nbsp;</h2>
                            <div class="clearfix"></div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">&nbsp;</div>
                            <div class="col-md-6" style="text-align: center;">
                                <img src="../build/images/sesion.jpg" style="width: 100%;" /><%--<img src="../build/images/sesion_us.jpg" style="width:100%;" />--%><br />
                                <asp:LinkButton ID="btnRegresarLogin" runat="server" Text="<i class='fa fa-undo' style='color:#73879C;font-size:14px;'></i> Regresar a Acceso <span class='glyphicon glyphicon-off' style='color:#73879C;font-size:14px;'></span>" CssClass="btn" href="../frmLogin.aspx" />
                            </div>
                            <div class="col-md-3">&nbsp;</div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
