<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmUsuarios.aspx.cs" Inherits="PortalClientes.Views.frmUsuarios" %>
<%@ Register Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <br />
    <div class="title_left">
        <h3>Listado de usuarios</h3>
    </div>
    <div class="title_right">
        <div class="col-md-5 col-sm-5   form-group pull-right top_search">
            <div class="input-group">
                <asp:TextBox ID="txtBusqueda" runat="server" placeholder="Busqueda aqui..." CssClass="form-control"></asp:TextBox>
                <span class="input-group-btn">
                    <asp:Button ID="btnBuscar" runat="server" Text="Go!" CssClass="btn btn-default" />
                </span>
            </div>
        </div>
    </div>
    <br />
    <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
            <asp:BoundField DataField="ApePat" HeaderText="Nombres" />
            <asp:BoundField DataField="ApeMat" HeaderText="Nombres" />
            <asp:BoundField DataField="Correo" HeaderText="Nombres" />
            <asp:BoundField DataField="Puesto" HeaderText="Nombres" />
        </Columns>
    </asp:GridView>
    
</asp:Content>
