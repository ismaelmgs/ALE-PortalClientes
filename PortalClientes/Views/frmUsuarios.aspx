<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmUsuarios.aspx.cs" Inherits="PortalClientes.Views.frmUsuarios" %>

<%@ Register Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function OcultarEdicionUsuarios() {
            "use strict";
            var modalId = '<%=mpeUsuario.ClientID%>';
            var modal = $find(modalId);
            modal.hide();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upaPrincipal" runat="server">
        <ContentTemplate>


            <div class="">
                <div class="page-title">
                    <div class="title_left">
                        <h3>Administración de Usuarios</h3>
                    </div>

                    <div class="title_right">
                        <div class="col-md-5 col-sm-5   form-group pull-right top_search">
                            <div class="input-group">
                                <asp:TextBox ID="txtBusqueda" runat="server" CssClass="form-control" placeholder="Buscar..."></asp:TextBox>
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
                        <h2>Listado de usuarios</h2>
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
                                    <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered"
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

            <br />
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


    <%-- MODAL PARA SELECCION DE EMPLEADO --%>
    <asp:HiddenField ID="hdTargetUsuario" runat="server" />
    <cc1:ModalPopupExtender ID="mpeUsuario" runat="server" TargetControlID="hdTargetUsuario"
        PopupControlID="pnlUsuario" BackgroundCssClass="overlayy">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlUsuario" runat="server" BorderColor="" BackColor="White" Height="300px" HorizontalAlign="Center"
        Width="600px" CssClass="modalrlr">
        <asp:UpdatePanel ID="upaUsuario" runat="server">
            <ContentTemplate>
                <table style="width: 100%">
                    <tr>
                        <td style="width: 5%"></td>
                        <td colspan="2" style="width: 90%; text-align: center">
                            <h5 class="modal-title">
                                <%--Edición de empleados--%>
                                <asp:Label ID="lblTituloModalUsuario" runat="server"></asp:Label>
                            </h5>
                        </td>
                        <td style="width: 5%"></td>
                    </tr>
                    <%--<tr>
                        <td style="width:5%">
                        </td>
                        <td style="width:90%; text-align:center">
                    
                        </td>
                        <td style="width:5%">
                            <asp:LinkButton ID="btnClose" runat="server" CssClass="close" Style="margin-top: -25px; margin-right: 10px; color: #cccccc; font-weight: bold;" ToolTip="Clic aqui para cerrar" OnClientClick="OcultarModalBusqueda();" >x</asp:LinkButton>
                        </td>
                    </tr>--%>
                    <tr>
                        <td colspan="4" style="height: 15px"></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td style="width: 30%">
                            <asp:Label ID="lblNombre" runat="server"></asp:Label>
                        </td>
                        <td style="width: 60%">
                            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Label ID="lblApellidoPat" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtApellidoPat" runat="server"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Label ID="lblApellidoMat" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtApellidoMat" runat="server"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Label ID="lblCorreo" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCorreo" runat="server"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            <asp:Label ID="lblPuesto" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPuesto" runat="server"></asp:TextBox>
                        </td>
                        <td></td>
                    </tr>
                </table>
                <br />
                <table style="width: 100%">
                    <tr>
                        <td style="text-align: right; width: 50%">
                            <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-primary" OnClientClick="OcultarEdicionUsuarios();"/>
                        </td>
                        <td style="text-align: left; width: 50%">
                            <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-warning" OnClientClick="OcultarEdicionUsuarios();" />
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
