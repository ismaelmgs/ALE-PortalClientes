<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="PortalClientes.frmLogin" %>

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
</head>
 <body class="login" style="background-image:url(build/images/bkg.jpg); background-position: center center; background-repeat: no-repeat;background-attachment: fixed; background-size: cover; background-color: #ffffff;">
    <form id="form1" runat="server">
        <div>
            <a class="hiddenanchor" id="signup"></a>
      <a class="hiddenanchor" id="signin"></a>

      <div class="login_wrapper">
        <div class="animate form login_form">
          <section class="login_content">
            <form><br />
              <h1>Acceso</h1>
              <div>
                <input type="text" class="form-control" placeholder="Usuario" required />
              </div><br />
              <div>
                <input type="password" class="form-control" placeholder="Contraseña" required />
              </div>
              <div><br />
                  <div class="row">
                      <div class="col-md-12" style="text-align:center;">
                        <a class="btn btn-primary" href="Views/frmDashboard.aspx">Enviar</a><br /><br />
                        <a href="#">¿Olvidó su contraseña?</a>
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

                <div><br />
                  <h2><img src="build/images/logo-ale_azul2.png" width="150" alt="ALE"> <!-- Aerolíneas Ejecutivas --></h2>
                  <p>© 2021 All Rights Reserved. Aerolíneas Ejecutivas. Privacy and Terms</p>
                </div>
              </div>
            </form>
          </section>
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
