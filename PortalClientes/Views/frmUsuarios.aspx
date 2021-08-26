<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmUsuarios.aspx.cs" Inherits="PortalClientes.Views.frmUsuarios" %>

<%@ Register Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
                            <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered" 
                                AllowPaging="true" OnPageIndexChanging="gvUsuarios_PageIndexChanging">
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
                                    <tr>
                                        <td>Nombre 000</td>
                                        <td>Paterno 000</td>
                                        <td>Materno 000</td>
                                        <td>Correo 000</td>
                                        <td>Puesto 000</td>
                                    </tr>
                                    <tr>
                                        <td>Nombre 111</td>
                                        <td>Paterno 111</td>
                                        <td>Materno 111</td>
                                        <td>Correo 111</td>
                                        <td>Puesto 111</td>
                                    </tr>
                                    <tr>
                                        <td>Nombre 333</td>
                                        <td>Paterno 333</td>
                                        <td>Materno 333</td>
                                        <td>Correo 333</td>
                                        <td>Puesto 333</td>
                                    </tr>
                                    <tr>
                                        <td>Nombre 444</td>
                                        <td>Paterno 444</td>
                                        <td>Materno 444</td>
                                        <td>Correo 444</td>
                                        <td>Puesto 444</td>
                                    </tr>
                                    <tr>
                                        <td>Nombre 555</td>
                                        <td>Paterno 555</td>
                                        <td>Materno 555</td>
                                        <td>Correo 555</td>
                                        <td>Puesto 555</td>
                                    </tr>
                                    <tr>
                                        <td>Nombre 666</td>
                                        <td>Paterno 666</td>
                                        <td>Materno 666</td>
                                        <td>Correo 666</td>
                                        <td>Puesto 666</td>
                                    </tr>
                                    <tr>
                                        <td>Nombre 777</td>
                                        <td>Paterno 777</td>
                                        <td>Materno 777</td>
                                        <td>Correo 777</td>
                                        <td>Puesto 777</td>
                                    </tr>
                                    <tr>
                                        <td>Nombre 888</td>
                                        <td>Paterno 888</td>
                                        <td>Materno 888</td>
                                        <td>Correo 888</td>
                                        <td>Puesto 888</td>
                                    </tr>
                                    <tr>
                                        <td>Nombre 999</td>
                                        <td>Paterno 999</td>
                                        <td>Materno 999</td>
                                        <td>Correo 999</td>
                                        <td>Puesto 999</td>
                                    </tr>
                                    <tr>
                                        <td>Nombre 122</td>
                                        <td>Paterno 122</td>
                                        <td>Materno 122</td>
                                        <td>Correo 122</td>
                                        <td>Puesto 122</td>
                                    </tr>
                                    <tr>
                                        <td>Nombre 123</td>
                                        <td>Paterno 123</td>
                                        <td>Materno 123</td>
                                        <td>Correo 123</td>
                                        <td>Puesto 123</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
