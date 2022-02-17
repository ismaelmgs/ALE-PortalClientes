<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLoginLoss.aspx.cs" Inherits="PortalClientes.frmLoginLoss" %>

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

      <div class="login_wrapper">
        <div class="animate form login_form">
          <section class="login_content">
                <h2><img src="build/images/logo-ale_azul2.png" width="100%" alt="ALE" /></h2>
              <h2><asp:Label ID="lblLoginLossHeader" runat="server" Text="Cambiar Contraseña"></asp:Label></h2><br />
              <div class="row">
                  <div class="col-md-1" style="text-align:center;">
                    <i class="fa fa-envelope" style="font-size:20px;margin-top:5px;"></i>
                  </div>
                  <div class="col-md-11">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Text="Correo electrónico" Style="border-top:none;border-right:none;border-left:none;"></asp:TextBox>
                  </div>
              </div>
              <br /><br />
            <div>
                
            </div>
              <div><br />
                  <div class="row">
                      <div class="col-md-12" style="text-align:center;">
                          <asp:Button ID="btnEviarContrasena" runat="server" OnClick="btnEviarContrasena_Click" CssClass="btn btn-primary" Text=" Enviar " Style="width:100%;" />  
                      </div>
                  </div>
                  <br />
                          <a href="frmLogin.aspx"><asp:Label ID="lblRegresarLogin" runat="server" Text=" Regresar a Acceso"></asp:Label></a>
                          <br />
              </div>

              <div class="clearfix"></div>

              <div class="separator">

                <div class="clearfix"></div>
                <br />
                  <div class="row" style="width:100%;">
                      <div class="col-md-5" style="text-align:right;">
                          <asp:LinkButton ID="lblIdiomaEspanol" runat="server" Text="Español" Font-Bold="true"></asp:LinkButton>
                      </div>
                      <div class="col-md-2">
                          <i class="fa fa-globe" style="font-size:25px;"></i>
                      </div>
                      <div class="col-md-5" style="text-align:left;">
                          <asp:LinkButton ID="lblIdiomaEnglish" runat="server" Text="English" Font-Bold="true"></asp:LinkButton>
                      </div>
                  </div><br />
              </div>
          </section>
            <div style="text-align:center;"><br />
                  
                  <p><script>
                         document.write(new Date().getFullYear())
                  </script>
                        © All Rights Reserved. Aerolíneas Ejecutivas.</p>
                </div>
        </div>
      </div>
        </div>
    </form>
</body>
</html>
