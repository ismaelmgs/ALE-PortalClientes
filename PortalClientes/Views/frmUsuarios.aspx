<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmUsuarios.aspx.cs" Inherits="PortalClientes.Views.frmUsuarios" %>

<%@ Register Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>

    <script type="text/javascript">
        function OcultarEdicionUsuarios() {
            "use strict";
            var modalId = '<%=mpeUsuario.ClientID%>';
            var modal = $find(modalId);
            modal.hide();
        }

        $(document).on('keydown', function (event){
            if (event.key == "Escape") {
                var modalId = '<%=mpeUsuario.ClientID%>';
                var modal = $find(modalId);
                modal.hide();
            }
        });
    </script>
    
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upaPrincipal" runat="server">
        <ContentTemplate>

            <div class="row">
                <div class="col-md-6">
                    <div class="title_left">
                        <h3><asp:Label ID="lblTituloPagina" runat="server"></asp:Label></h3>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="title_right">
                        <div class="col-md-5 col-sm-5   form-group pull-right top_search">
                            <div class="input-group">
                                <asp:TextBox ID="txtBusqueda" runat="server" CssClass="form-control"></asp:TextBox>
                                <span class="input-group-btn">
                                    <button id="btnBuscar" class="btn btn-default" type="button" runat="server" onserverclick="btnBuscar_ServerClick">
                                        <i class="fa fa-search" aria-hidden="true"></i>
                                    </button>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-12 col-sm-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2><asp:Label ID="lblSubTituloPagina" runat="server"></asp:Label></h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                            <li><a class="close-link"><i class="fa fa-close"></i></a>
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="card-box table-responsive">
                                    <div class="col-lg-12" style="text-align: right">
                                        <asp:Button ID="btnAgregar" runat="server" Text="" CssClass="btn btn-success" OnClick="btnAgregar_Click" />
                                    </div>
                                    <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover"
                                        AllowPaging="true" OnPageIndexChanging="gvUsuarios_PageIndexChanging" OnRowDataBound="gvUsuarios_RowDataBound">
                                        <HeaderStyle />
                                        <RowStyle />
                                        <AlternatingRowStyle />
                                        <Columns>
                                            <asp:BoundField DataField="Nombres"/>
                                            <asp:BoundField DataField="ApePat" />
                                            <asp:BoundField DataField="ApeMat" />
                                            <asp:BoundField DataField="Correo" />
                                            <asp:BoundField DataField="Puesto" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <%--<br />
            <div class="col-md-12 col-sm-12 ">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>Tabla de <small>Usuarios (demo)</small></h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                            </li>
                            <li><a class="close-link"><i class="fa fa-close"></i></a>
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="card-box table-responsive">
                                    <table id="datatable-buttons" class="table table-striped table-bordered" style="width: 100%">
                                        <thead>
                                            <tr>
                                                <th>Nombre</th>
                                                <th>Apellido Paterno</th>
                                                <th>Apellido Materno</th>
                                                <th>E-mail</th>
                                                <th>Puesto</th>
                                            </tr>
                                        </thead>

                                        <tbody>
                                            <asp:GridView ID="gvusuarios2" runat="server" AutoGenerateColumns="false" ShowHeader="false" Width="100%">
                                                <HeaderStyle />
                                                <RowStyle />
                                                <AlternatingRowStyle />
                                                <Columns>
                                                    <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
                                                    <asp:BoundField DataField="ApePat" HeaderText="Apellido Paterno" />
                                                    <asp:BoundField DataField="ApeMat" HeaderText="Apellido Materno" />
                                                    <asp:BoundField DataField="Correo" HeaderText="Correo" />
                                                    <asp:BoundField DataField="Puesto" HeaderText="Puesto" />
                                                </Columns>
                                            </asp:GridView>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>--%>
        </ContentTemplate>
    </asp:UpdatePanel>


    <%-- MODAL PARA SELECCION DE EMPLEADO --%>
    <asp:HiddenField ID="hdTargetUsuario" runat="server" />
    <cc1:ModalPopupExtender ID="mpeUsuario" runat="server" TargetControlID="hdTargetUsuario"
        PopupControlID="pnlUsuario" BackgroundCssClass="overlayy">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlUsuario" runat="server" BorderColor="" BackColor="White" Height="" HorizontalAlign="Center"
        Width="" CssClass="modal-derecha">
        <asp:UpdatePanel ID="upaUsuario" runat="server">
            <ContentTemplate>
                <asp:Button ID="Button1" runat="server" CssClass="btn" Text="X" Font-Bold="true" OnClientClick="OcultarEdicionUsuarios();" Style="z-index: 2000;right: 13px;margin-top:10px;position: absolute; color:#838383;" />
                <table style="width: 100%">
                    <tr>
                        <%--border-radius:15px;--%>
                        <td  style="background-color:#efefef; text-align:center; padding-top:10px; ">
                            <h5 class="modal-title">
                                <%--Edición de empleados--%>
                                <asp:Label ID="lblTituloModalUsuario" runat="server"></asp:Label>
                            </h5><br />
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr>
                        <td>  <br />              
                            <div class="row">
                                <div class="col-md-3" style="width:300px;">
                                    <asp:Label ID="lblNombre" runat="server" style="width:550px;"></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-1"></div>
                            </div>    
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="row">
                                <div class="col-md-3">
                                    <asp:Label ID="lblApellidoPat" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtApellidoPat" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-1"></div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="row">
                                <div class="col-md-3">
                                    <asp:Label ID="lblApellidoMat" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtApellidoMat" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-1"></div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="row">
                                <div class="col-md-3">
                                    <asp:Label ID="lblCorreo" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-1"></div>
                            </div>  
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="row">
                                <div class="col-md-3">
                                    <asp:Label ID="lblPuesto" runat="server"></asp:Label>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtPuesto" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-1"></div>
                            </div>  
                        </td>
                    </tr>
                </table>
                <div class="row">
                    <div class="col-md-3">
                        <asp:Label ID="lblTelefonoMovil" runat="server"></asp:Label>
                    </div>
                    <div class="col-md-8">
                        <asp:TextBox ID="txtTelMovil" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col-md-1"></div>
                </div>
                <br /><br /><br />
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <div class="row">
                                <div class="col-md-1">
                                    &nbsp;
                                </div>
                                <div class="col-md-10" style="text-align:right;">
                                    <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-primary" OnClientClick="OcultarEdicionUsuarios();"/>
                                </div>
                                <%--<div class="col-md-3" style="text-align:center;">
                                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" OnClientClick="OcultarEdicionUsuarios();" />
                                </div>--%>
                                <div class="col-md-1">
                                    &nbsp;
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>

        <%--<asp:UpdateProgress ID="upaProgEmpleados" runat="server" DynamicLayout="true" AssociatedUpdatePanelID="upaSelectEmpleado">
            <ProgressTemplate>
                <div style="text-align: left">
                    <asp:Label ID="lblProgresSeleEmpleado" runat="server" Text="Por favor espere..." Font-Italic="true"></asp:Label>
                    <asp:Image ID="LoadModal" runat="server" ImageUrl="~/images/gifs/loadingModal2.gif" Height="24" Width="24"/>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>--%>
    </asp:Panel>
</asp:Content>
