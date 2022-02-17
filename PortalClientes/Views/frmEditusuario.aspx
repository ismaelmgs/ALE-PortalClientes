<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmEditusuario.aspx.cs" Inherits="PortalClientes.Views.frmEditusuario" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function OcultarModal()
        {
            "use strict";
            var modalId = '<%=mpeConfirm.ClientID%>';
            var modal = $find(modalId);
            modal.hide();
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upaPrincipal" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-6">
                    <div class="title_left">
                        <h3>
                            <asp:Label ID="lblEdisionUsuarioHeader" runat="server" Text=" Administrar Cuenta" Font-Bold="false"></asp:Label></h3>
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
                                        <asp:Label ID="lblEditarUsuario" runat="server" Text="Administrar Cuenta" Font-Bold="true"></asp:Label>
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
                                                    <asp:Label ID="lblCorreo" runat="server" Text="Correo Electrónico"></asp:Label><br />
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
                                    <%-- <tr>
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
                                    </tr>--%>
                                    <tr>
                                        <td>
                                            <div class="row">
                                                <div class="col-md-4"></div>
                                                <div class="col-md-4" style="text-align: center;">
                                                    <br />
                                                    <br />
                                                    <asp:Button ID="btnEditarUsuario" runat="server" CssClass="btn btn-primary" Text=" Actualizar " OnClick="btnEditarUsuario_Click" />
                                                </div>
                                                <div class="col-md-4"></div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <br />
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
                                        <asp:Label ID="lblEditarPass" runat="server" Text="Actualizar Contrasena" Font-Bold="true"></asp:Label>
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
                                            <div class="row">
                                                <div class="col-md-1"></div>
                                                <div class="col-md-5" style="text-align: left;">
                                                    <asp:Label ID="lblPass" runat="server"></asp:Label><asp:Label runat="server" ForeColor="Red" Text=" *"></asp:Label><br />
                                                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="Regex1" runat="server" ControlToValidate="txtPass"
                                                        ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$" ErrorMessage="Password must contain: Minimum 8 characters atleast 1 Alphabet and 1 Number" ForeColor="Red" />
                                                    <asp:Label ID="lblReqPass" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                                </div>
                                                <div class="col-md-5" style="text-align: left;">
                                                    <asp:Label ID="lblConfirPass" runat="server"></asp:Label><asp:Label runat="server" ForeColor="Red" Text=" *"></asp:Label><br />
                                                    <asp:TextBox ID="txtConfirPass" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                                    <asp:RegularExpressionValidator ID="Regex2" runat="server" ControlToValidate="txtConfirPass"
                                                        ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$" ErrorMessage="Password must contain: Minimum 8 characters atleast 1 Alphabet and 1 Number" ForeColor="Red" />
                                                    <asp:Label ID="lblReqConfirPass" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                                </div>
                                                <div class="col-md-1"></div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="row">
                                                <div class="col-md-4"></div>
                                                <div class="col-md-4" style="text-align: center;">
                                                    <br />
                                                    <br />
                                                    <asp:Button ID="btnEditarPass" runat="server" CssClass="btn btn-primary" Text=" Actualizar " OnClick="btnEditarPass_Click" />
                                                </div>
                                                <div class="col-md-4"></div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <br />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <%-- Modal Confirm --%>
    <asp:HiddenField ID="hdTargetConfirm" runat="server" />
    <cc1:ModalPopupExtender ID="mpeConfirm" runat="server" TargetControlID="hdTargetConfirm"
        PopupControlID="pnlConfirm" BackgroundCssClass="overlayy">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlConfirm" runat="server" BackColor="White" Style="display: none;" CssClass="modalrlr">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <table style="width: 100%">
                    <tr>
                        <td colspan="2" runat="server" id="tdCaption">&nbsp;
                           
                            <center>
                                <h4>
                                    <asp:Label ID="lblCaption" runat="server"></asp:Label></h4>
                            </center>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 60px; vertical-align: middle; text-align: center">
                            <asp:Image ID="imgInfo" runat="server" ImageUrl="~/Images/icons/bien_02.png" Height="24" Width="24" />
                        </td>
                        <td style="text-align: left; vertical-align: middle">
                            <asp:Label ID="lblMessageConfirm" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Button ID="btnAceptConfirm" runat="server" Text="Entendido" OnClientClick="OcultarModal();" CssClass="btn btn-primary" />
                        </td>
                        <%--<td style="text-align: left">
                            <asp:Button ID="btnCancelConfirm" runat="server" Text="No" OnClick="btnCancelConfirm_Click" CssClass="btn btn-default" />
                        </td>--%>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
