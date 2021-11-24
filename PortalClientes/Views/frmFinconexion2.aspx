<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmFinconexion2.aspx.cs" Inherits="PortalClientes.Views.frmFinconexion2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Aerolíneas Ejecutivas - Management</title>
        <!-- Bootstrap -->
    <link href="../vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <!-- Font Awesome -->
    <link href="../vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <!-- NProgress -->
    <link href="../vendors/nprogress/nprogress.css" rel="stylesheet">
    <!-- Animate.css -->
    <link href="../vendors/animate.css/animate.min.css" rel="stylesheet">

    <!-- Custom Theme Style -->
    <link href="../build/css/custom.min.css" rel="stylesheet">
    <style>
        .dxbs-textbox > div > input.form-control, .dxbs-memo > div > input.form-control, .dxbs-button-edit > div:not(.input-group) > input.form-control, .dxbs-spin-edit > div:not(.input-group) > input.form-control, .dxbs-dropdown-edit > div:not(.input-group-append):not(.input-group-prepend):not(.dxbs-dropdown-area):not(.dxbs-out-of-range-warn):not(.dxbs-ld):not(.dxbs-lp):not(.input-group) > input.form-control, .dxbs-button-edit > .input-group > div:not(.input-group-append):not(.input-group-prepend) > input.form-control, .dxbs-spin-edit > .input-group > div:not(.input-group-append):not(.input-group-prepend) > input.form-control, .dxbs-dropdown-edit > .input-group > div:not(.input-group-append):not(.input-group-prepend):not(.dxbs-dropdown-area):not(.dxbs-out-of-range-warn):not(.dxbs-ld):not(.dxbs-lp) > input.form-control {
        width: 100%;
        border: 0px;
        border-radius: 0px;
        border-bottom: 1px solid #0000002e;
        }
    </style>
</head>
<body class="login" style="background: repeating-linear-gradient(45deg,transparent,transparent 2px,hsla(0,0%,76.1%,.05) 3px,hsla(0,0%,76.1%,.05) 4px,transparent 5px); background-color: #3a495c; overflow:hidden;">
    <form id="form1" runat="server">
        <div>
            <div class="row">
                <div class="col-md-1">&nbsp;</div>
       <div class="col-md-10 col-sm-10" style="padding:20px;"><br /><br />
        <div class="x_panel">
            <div class="x_title">
                <h2>&nbsp;</h2>
                <%--<ul class="nav navbar-right panel_toolbox">
                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                    <li><a class="close-link"><i class="fa fa-close"></i></a>
                    </li>
                </ul>--%>
                <div class="clearfix"></div>
            </div>
            <div class="row">
                <div class="col-md-3">&nbsp;</div>
                <div class="col-md-6" style="text-align:center;">
                    <img src="../build/images/sesion.jpg" style="width:100%;" /><%--<img src="../build/images/sesion_us.jpg" style="width:100%;" />--%><br />
                    <asp:LinkButton ID="btnRegresarLogin" runat="server" Text="<i class='fa fa-undo' style='color:#73879C;font-size:14px;'></i> Regresar a Acceso <span class='glyphicon glyphicon-off' style='color:#73879C;font-size:14px;'></span>" CssClass="btn" href="../frmLogin.aspx" />
                </div>
                <div class="col-md-3">&nbsp;</div>
            </div>
        </div>
    </div>
    <div class="col-md-1">&nbsp;</div>
    </div>
        </div>
        <div style="text-align:center; width:100%;">
            <p>© 2021 All Rights Reserved. Aerolíneas Ejecutivas.</p>
        </div>
    </form>
</body>
</html>
