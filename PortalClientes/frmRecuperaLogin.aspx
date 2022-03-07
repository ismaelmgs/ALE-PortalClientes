<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmRecuperaLogin.aspx.cs" Inherits="PortalClientes.frmRecuperaLogin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="icon" href="~/build/images/favicon.ico" type="image/ico" />
    <title>Aerolíneas Ejecutivas</title>
    <!-- Bootstrap -->
    <link href="vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- NProgress -->
    <link href="vendors/nprogress/nprogress.css" rel="stylesheet">
    <!-- Animate.css -->
    <link href="vendors/animate.css/animate.min.css" rel="stylesheet">

    <!-- Custom Theme Style -->
    <link href="build/css/custom.min.css" rel="stylesheet">
    <style>
        .dxbs-textbox > div > input.form-control, .dxbs-memo > div > input.form-control, .dxbs-button-edit > div:not(.input-group) > input.form-control, .dxbs-spin-edit > div:not(.input-group) > input.form-control, .dxbs-dropdown-edit > div:not(.input-group-append):not(.input-group-prepend):not(.dxbs-dropdown-area):not(.dxbs-out-of-range-warn):not(.dxbs-ld):not(.dxbs-lp):not(.input-group) > input.form-control, .dxbs-button-edit > .input-group > div:not(.input-group-append):not(.input-group-prepend) > input.form-control, .dxbs-spin-edit > .input-group > div:not(.input-group-append):not(.input-group-prepend) > input.form-control, .dxbs-dropdown-edit > .input-group > div:not(.input-group-append):not(.input-group-prepend):not(.dxbs-dropdown-area):not(.dxbs-out-of-range-warn):not(.dxbs-ld):not(.dxbs-lp) > input.form-control {
            width: 100%;
            border: 0px;
            border-radius: 0px;
            border-bottom: 1px solid #0000002e;
        }
    </style>
</head>
<body class="login" style="background: repeating-linear-gradient(45deg,transparent,transparent 2px,hsla(0,0%,76.1%,.05) 3px,hsla(0,0%,76.1%,.05) 4px,transparent 5px); background-color: #3a495c;">
    <form id="form1" runat="server">
        <div>

            <div class="login_wrapper">
                <div class="animate form login_form">
                    <section class="login_content">
                        <h2>
                            <img src="build/images/logo-ale_azul2.png" width="100%" alt="ALE" /></h2>
                        <h2>
                            <asp:Label ID="lblLoginLossHeader" runat="server" Text="Ingresar Contraseña Nueva"></asp:Label></h2>
                        <br />
                        <div class="row">
                            <div class="col-md-1" style="text-align: center;">
                                <i class="fa fa-lock" style="font-size: 20px; margin-top: 5px;"></i>
                            </div>
                            <div class="col-md-11">
                                <asp:Label ID="lblPass" runat="server"></asp:Label><br />
                                <asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="Regex1" runat="server" ControlToValidate="txtPass"
                                    ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$" ErrorMessage="Password must contain: Minimum 8 characters atleast 1 Alphabet and 1 Number" ForeColor="Red" />
                                <asp:Label ID="lblReqPass" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-1" style="text-align: center;">
                                <i class="fa fa-lock" style="font-size: 20px; margin-top: 5px;"></i>
                            </div>
                            <div class="col-md-11">
                                <asp:Label ID="lblConfirPass" runat="server"></asp:Label><br />
                                <asp:TextBox ID="txtConfirPass" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="Regex2" runat="server" ControlToValidate="txtConfirPass"
                                    ValidationExpression="^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$" ErrorMessage="Password must contain: Minimum 8 characters atleast 1 Alphabet and 1 Number" ForeColor="Red" />
                                <asp:Label ID="lblReqConfirPass" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                            </div>
                        </div>
                        <br />
                        <div>
                        </div>
                        <div>
                            <br />
                            <div class="row">
                                <div class="col-md-12" style="text-align: center;">
                                    <asp:Button ID="btnRecuperarContrasena" OnClick="btnRecuperarContrasena_Click" runat="server" CssClass="btn btn-primary" Text=" Recuperar " Style="width: 100%;" />
                                </div>
                            </div>
                            <br />
                            <a href="frmLogin.aspx">
                                <asp:Label ID="lblRegresarLogin" runat="server" Text=" Regresar a Acceso"></asp:Label></a>
                            <br />
                        </div>

                        <div class="clearfix"></div>

                        <div class="separator">

                            <div class="clearfix"></div>
                            <br />
                            <table style="width: 100%;">
                                <tr>
                                    <td style="text-align: right;">
                                        <asp:LinkButton ID="lblIdiomaEspanol" OnClick="lblIdiomaEspanol_Click" runat="server" Text="Español" Font-Bold="true"></asp:LinkButton>
                                    </td>
                                    <td style="text-align: center;">
                                        <i class="fa fa-globe" style="font-size: 25px;"></i>
                                    </td>
                                    <td style="text-align: left;">
                                        <asp:LinkButton ID="lblIdiomaEnglish" OnClick="lblIdiomaEnglish_Click" runat="server" Text="English" Font-Bold="true"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </div>
                    </section>
                    <div style="text-align: center;">
                        <br />

                        <p>
                            <script>
                         document.write(new Date().getFullYear())
                            </script>
                            © All Rights Reserved. Aerolíneas Ejecutivas.
                        </p>
                    </div>
                </div>
            </div>
        </div>

        <asp:ScriptManager ID="ScriptManager1" runat="server" />
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
                                <h3>
                                    <asp:Label ID="lblCaption" runat="server"></asp:Label></h3>
                            </center>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="vertical-align: middle; text-align: center">
                                <div class="row">
                                    <div class="col-md-12" style="text-align:center;">
                                        <asp:Image ID="imgInfo" runat="server" ImageUrl="~/Images/icons/bien_02.png" Height="24" Width="24" /><br />            
                                        <asp:Label ID="lblMessageConfirm" runat="server"></asp:Label>            
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <br />
                                 <asp:Button ID="btnAceptConfirm" runat="server" Text="Entendido" OnClick="btnAceptConfirm_Click" CssClass="btn btn-primary" />
                                <br /><br />
                            </td>
                            <%--<td style="text-align: left">
                            <asp:Button ID="btnCancelConfirm" runat="server" Text="No" OnClick="btnCancelConfirm_Click" CssClass="btn btn-default" />
                        </td>--%>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
    </form>
</body>
</html>


