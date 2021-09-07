<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmCalendario.aspx.cs" Inherits="PortalClientes.Views.frmCalendario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link href="../toastr/toastr.min.css" rel="stylesheet" />--%>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row">
        <div class="col-md-6">
            <div class="title_left">
                <h3>Calendario</h3>
            </div>
        </div>
        <div class="col-md-6">
        <div class="title_right">
                <div class="col-md-5 col-sm-5   form-group pull-right top_search">
                    <div class="input-group">
                        <asp:TextBox ID="txtBusqueda" runat="server" CssClass="form-control" placeholder="Buscar..."></asp:TextBox>
                        <span class="input-group-btn">
                            <button id="btnBuscar" class="btn btn-default" type="button">
                                <i class="fa fa-search" aria-hidden="true"></i>
                            </button>
                        </span>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
       <div class="col-md-12 col-sm-12">
        <div class="x_panel">
            <div class="x_title">
                <h2><asp:Label ID="lblCalendario" runat="server" Text="Calendario" Font-Bold="true"></asp:Label></h2>
                <ul class="nav navbar-right panel_toolbox">
                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                    <li><a class="close-link"><i class="fa fa-close"></i></a>
                    </li>
                </ul>
                <div class="clearfix"></div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    Contenido
                    <br />
                    <div class="container mt-5">
                        <input type="button" id="btnAlerta" value="Alerta" class="btn btn-info" />
                        <asp:Button ID="btnAlerta2" runat="server" Text="¡Alerta!" CssClass="btn btn-warning"  />
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>

    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>
    <%--<script src='<%=ResolveUrl("../toastr/toastr.min.js")%>'></script>--%>

    <script type="text/javascript">

        function alertexito(mensaje)
        {
            toastr.success("Mensaje de exito");
        }

        $(document).ready(function () {
            $('#btnAlerta').click(function () {
                //toastr['warning']('Mensaje de prueba', 'Titulo del mensaje');
                toastr.success("Mensaje de exito");
            });
        });

        //toastr.options = {
        //  "closeButton": true,
        //  "debug": false,
        //  "newestOnTop": false,
        //  "progressBar": true,
        //  "positionClass": "toast-top-right",
        //  "preventDuplicates": false,
        //  "onclick": null,
        //  "showDuration": "3000",
        //  "hideDuration": "3000",
        //  "timeOut": "5000",
        //  "extendedTimeOut": "1000",
        //  "showEasing": "swing",
        //  "hideEasing": "linear",
        //  "showMethod": "fadeIn",
        //  "hideMethod": "fadeOut"
        //}
        
    </script>
</asp:Content>
