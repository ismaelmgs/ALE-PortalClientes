<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmEditusuario.aspx.cs" Inherits="PortalClientes.Views.frmEditusuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-6">
                    <div class="title_left">
                        <h3>
                            <asp:Label ID="lblEdisionUsuarioHeader" runat="server" Text=" Edición Usuario" Font-Bold="false"></asp:Label></h3>
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
                            <div class="row">
                                <div class="col-md-6" style="text-align: left;">
                                    <h2>
                                        <asp:Label ID="lblEditarUsuario" runat="server" Text="Edición Usuario" Font-Bold="true"></asp:Label>
                                    </h2>
                                </div>
                                <div class="col-md-6" style="text-align: right;">
                                    &nbsp;
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="row">
                           <div class="col-md-12">
                                <table style="width: 97%; margin: 0 auto !important;">
                                    <tr>
                                        <td>&nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-1"></div>
                                                <div class="col-md-5" style="text-align: left;">
                                                    <asp:Label ID="lblNombre" runat="server" Text="Nombre(s)"></asp:Label><asp:Label runat="server" ForeColor="Red" Text=" *"></asp:Label><br />
                                                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-md-5" style="text-align: left;">
                                                    <asp:Label ID="lblApellidoPat" runat="server" Text="Apellido Paterno"></asp:Label><br />
                                                    <asp:TextBox ID="txtApellidoPat" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-md-1"></div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="row">
                                                <div class="col-md-1"></div>
                                                <div class="col-md-5" style="text-align: left;">
                                                    <asp:Label ID="lblApellidoMat" runat="server" Text="Apellido Materno"></asp:Label><br />
                                                    <asp:TextBox ID="txtApellidoMat" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-md-5" style="text-align: left;">
                                                    <asp:Label ID="lblPuesto" runat="server" Text="Puesto"></asp:Label>
                                                    <asp:TextBox ID="txtPuesto" runat="server" CssClass="form-control"></asp:TextBox>

                                                </div>
                                                <div class="col-md-1"></div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="row">
                                                <div class="col-md-1"></div>
                                                <div class="col-md-5" style="text-align: left;">
                                                    <asp:Label ID="lblCorreo" runat="server" Text="Correo Electrónico"></asp:Label><asp:Label runat="server" ForeColor="Red" Text=" *"></asp:Label><br />
                                                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-md-5" style="text-align: left;">
                                                    <asp:Label ID="lblTelefonoMovil" runat="server" Text="Celular"></asp:Label><br />
                                                    <asp:TextBox ID="txtTelMovil" runat="server" CssClass="form-control" MaxLength="13"></asp:TextBox>                                        
                                                </div>
                                                <div class="col-md-1"></div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="row">
                                                <div class="col-md-1"></div>
                                                <div class="col-md-5" style="text-align: left;">
                                                    <asp:Label ID="lblCorreoSecundario" runat="server" Text="Correo Secundario"></asp:Label><br />
                                                    <asp:TextBox ID="txtCorreoSecundario" runat="server" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-md-5" style="text-align: left;">
                                                    <asp:Label ID="lblTelefonoOficina" runat="server" Text="Teléfono Oficina"></asp:Label><br />
                                                    <asp:TextBox ID="txtTelefonoOficina" runat="server" CssClass="form-control" MaxLength="13"></asp:TextBox>
                                                </div>
                                                <div class="col-md-1"></div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="row">
                                                <div class="col-md-1"></div>
                                                <div class="col-md-5" style="text-align: left;">
                                                    <asp:Label ID="lblPass" runat="server" Text="Contraseña"></asp:Label><asp:Label runat="server" ForeColor="Red" Text=" *"></asp:Label><br />
                                                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-md-5" style="text-align: left;">
                                                    <asp:Label ID="lblConfirPass" runat="server" Text="Confirmar Contraseña"></asp:Label><asp:Label runat="server" ForeColor="Red" Text=" *"></asp:Label><br />
                                                    <asp:TextBox ID="txtConfirPass" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                                </div>
                                                <div class="col-md-1"></div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="row">
                                                <div class="col-md-4"></div>
                                                <div class="col-md-4" style="text-align: center;"><br /><br />
                                                    <asp:Button ID="btnEditarUsuario" runat="server" CssClass="btn btn-primary" Text=" Actualizar " />
                                                </div>
                                                <div class="col-md-4"></div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                               <br /><br />
                           </div>
                        </div>
                    </div>

                </div>
            </div>
        </ContentTemplate>
</asp:Content>
