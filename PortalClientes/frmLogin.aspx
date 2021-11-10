<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="PortalClientes.frmLogin" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v18.1, Version=18.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
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
            <a class="hiddenanchor" id="signup"></a>
      <a class="hiddenanchor" id="signin"></a>

      <div class="login_wrapper">
        <div class="animate form login_form">
          <section class="login_content">
            <form>
                <h2><img src="build/images/logo-ale_azul2.png" width="100%" alt="ALE" /> <!-- Aerolíneas Ejecutivas --></h2>
              <%--<h1></h1>--%><h2><asp:Label ID="lblAcceso" runat="server"></asp:Label></h2>
              <div class="row">
                  <div class="col-md-1" style="text-align:center;">
                    <%--<asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Usuario"></asp:TextBox>--%>
                    <i class="fa fa-envelope" style="font-size:20px;margin-top:5px;"></i>
                  </div>
                  <div class="col-md-11">
                    <dx:BootstrapTextBox ID="txtUsuarios" runat="server"></dx:BootstrapTextBox>
                  </div>
              </div><br />
              <div class="row">
                  <div class="col-md-1" style="text-align:center;">
                    <%--<asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="contraseña"></asp:TextBox>--%>
                    <i class="fa fa-lock" style="font-size:25px;margin-top:5px;margin-left: 4px;"></i>
                  </div>
                  <div class="col-md-11">
                    <dx:BootstrapTextBox ID="txtPassword" runat="server" Password="true"></dx:BootstrapTextBox>
                  </div>
              </div>
            <div>
                <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
            </div>
              <div><br />
                  <div class="row">
                      <div class="col-md-12" style="text-align:center;">
                        <%--<button id="btnEntrar" class="btn btn-primary" type="button" runat="server">
                            Enviar
                        </button>--%>
                          <dx:BootstrapButton ID="btnEntrar" runat="server" OnClick="btnEntrar_Click" style="width:100%;background-color: #2e416b;">
                              <SettingsBootstrap RenderOption="Primary" />
                          </dx:BootstrapButton>
                          <br />
                          <br />
                        <asp:Label ID="lblOlvidoPAssword" runat="server"></asp:Label>
                      </div>
                  </div>
              </div>

              <div class="clearfix"></div>

              <div class="separator">
                <%--<p class="change_link">New to site?
                  <a href="#signup" class="to_register"> Create Account </a>
                </p>--%>

                <div class="clearfix"></div>
                <br />
                  <div class="row" style="width:100%;">
                      <div class="col-md-5" style="text-align:right;">
                          <asp:LinkButton ID="lblIdiomaEspanol" runat="server" Text="Español" Font-Bold="true" OnClick="lblIdiomaEspanol_Click"></asp:LinkButton>
                      </div>
                      <div class="col-md-2">
                          <i class="fa fa-globe" style="font-size:25px;"></i>
                      </div>
                      <div class="col-md-5" style="text-align:left;">
                          <asp:LinkButton ID="lblIdiomaEnglish" runat="server" Text="English" Font-Bold="true" OnClick="lblIdiomaEnglish_Click"></asp:LinkButton>
                      </div>
                  </div><br />
              </div>
            </form>
          </section>
            <div style="text-align:center;"><br />
                  
                  <p><script>
                         document.write(new Date().getFullYear())
                  </script>
                        © All Rights Reserved. Aerolíneas Ejecutivas.</p>
                </div>
        </div>

        <div id="register" class="animate form registration_form">
          <section class="login_content">
            <form>
              <h1>Create Account</h1>
              <div>
                <input type="text" class="form-control" placeholder="Username" required />
              </div>
              <div>
                <input type="email" class="form-control" placeholder="Email" required />
              </div>
              <div>
                <input type="password" class="form-control" placeholder="Password" required />
              </div>
              <div>
                <a class="btn btn-default submit" href="index.html">Submit</a>
              </div>

              <div class="clearfix"></div>

              <div class="separator">
                <p class="change_link">Already a member ?
                  <a href="#signin" class="to_register"> Log in </a>
                </p>

                <div class="clearfix"></div>
                <br />

                <div>
                  <h1><img src="build/images/logo-ale_blanco.png" width="156" height="92" alt="ALE"> Aerolíneas Ejecutivas</h1>
                  <p>© 2021 All Rights Reserved. Aerolíneas Ejecutivas. Privacy and Terms</p>
                </div>
              </div>
            </form>
          </section>
        </div>
      </div>
        </div>
    </form>
</body>
</html>
