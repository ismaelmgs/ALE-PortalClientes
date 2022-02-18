<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmSinMatriculas.aspx.cs" Inherits="PortalClientes.Views.frmSinMatriculas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-6">
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
                <div class="col-md-6" style="text-align:center;">
                    <img src="../build/images/sinmatriculas.jpg" style="width:100%;" /><br />
                    <asp:LinkButton ID="btnRegresar" runat="server" Text="<i class='fa fa-undo' style='color:#73879C;font-size:14px;'></i> Regresar " CssClass="btn"/>
                </div>
                <div class="col-md-3">&nbsp;</div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
