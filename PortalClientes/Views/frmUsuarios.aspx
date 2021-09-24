<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmUsuarios.aspx.cs" EnableEventValidation="false" Inherits="PortalClientes.Views.frmUsuarios" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v18.1, Version=18.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<%@ Register Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="xVal.WebForms" Namespace="xVal.WebForms" TagPrefix="val" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>

    <script type="text/javascript">
        function OcultarEdicionUsuarios()
        {
            "use strict";
            var modalId = '<%=mpeUsuario.ClientID%>';
            var modal = $find(modalId);
            modal.hide();
        }
        
        function OcultarModalMatriculas() {
            "use strict";
            var modalId = '<%=mpeMats.ClientID%>';
            var modal = $find(modalId);
            modal.hide();
        }

        function OcultarModalModulos() {
            "use strict";
            var modalId = '<%=mpeModulos.ClientID%>';
            var modal = $find(modalId);
            modal.hide();
        }

        function OcultarModalClonar() {
            "use strict";
            var modalId = '<%=mpeClonar.ClientID%>';
            var modal = $find(modalId);
            modal.hide();
        }
        
        $(document).on('keydown', function (event){
            if (event.key == "Escape") {
                var modalId = '<%=mpeUsuario.ClientID%>';
                var modal = $find(modalId);
                modal.hide();

                var modalmatId = '<%=mpeMats.ClientID%>';
                var modalmat = $find(modalmatId);
                modalmat.hide();

                var modalmodId = '<%=mpeModulos.ClientID%>';
                var modalmod = $find(modalmodId);
                modalmod.hide();

                var modalcloId = '<%=mpeClonar.ClientID%>';
                var modalclo = $find(modalcloId);
                modalclo.hide();
            }
        });

        
        $(document).ready(function() {
            $("#basic-form").validate();
        });

        //$(document).ready(function ()
        //{
        //    $("#basic-form").validate({
        //        rules: {
        //            name : {
        //                required: true,
        //                minlength: 3
        //            },
        //            age: {
        //                required: true,
        //                number: true,
        //                min: 18
        //            },
        //            email: {
        //                required: true,
        //                email: true
        //            },
        //            weight: {
        //                required: {
        //                    depends: function(elem) {
        //                    return $("#age").val() > 50
        //                    }
        //            },
        //            number: true,
        //            min: 0
        //            }
        //        }
        //  });
        //});

    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upaPrincipal" runat="server">
        <ContentTemplate>

            <div class="row">
                <div class="col-md-6">
                    <div class="title_left">
                        <h3><asp:Label ID="lblTituloPagina" runat="server"></asp:Label></h3>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="title_right">
                        <div class="col-md-5 col-sm-5   form-group pull-right top_search">
                            <div class="input-group">
                                <asp:TextBox ID="txtBusqueda" runat="server" CssClass="form-control"></asp:TextBox>
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


            <%--<div class="row">
                <div class="col-sm-4"></div>
                <div class="col-sm-8">
                    <div class="x_content bs-example-popovers">
                        <div class="alert alert-info alert-dismissible" role="alert">
                            <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                                <span aria-hidden="true">x</span>
                            </button>
                            <strong>Holy guacamole!</strong>
                            " Best check yo self, you're not looking too good. "
                        </div>
                    </div>
                </div>
            </div>--%>

            <div class="col-md-12 col-sm-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2><asp:Label ID="lblSubTituloPagina" runat="server"></asp:Label></h2>
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
                                    <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover"
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
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imbAddMats" runat="server" ImageUrl="~/Images/icons/add_mats.png" Width="24px" Height="28px"
                                                        OnClick="imbAddMats_Click" CommandName="Mats" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" />&nbsp;&nbsp;&nbsp;
                                                    <asp:ImageButton ID="imbEditarModulos" runat="server" ImageUrl="~/Images/icons/add_permissions.png" Width="26px" Height="28px" 
                                                        OnClick="imbEditarModulos_Click" CommandName="Modulos" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/>&nbsp;&nbsp;&nbsp;
                                                    <asp:ImageButton ID="imbClonUsuarios" runat="server" ImageUrl="~/Images/icons/clone_permissions.png" Width="28px" Height="28px" 
                                                        OnClick="imbClonUsuarios_Click" CommandName="Usuarios" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


    <%-- MODAL PARA EDICIÓN DEL EMPLEADO --%>
    <asp:HiddenField ID="hdTargetUsuario" runat="server" />
    <cc1:ModalPopupExtender ID="mpeUsuario" runat="server" TargetControlID="hdTargetUsuario"
        PopupControlID="pnlUsuario" BackgroundCssClass="overlayy">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlUsuario" runat="server" BorderColor="" BackColor="White" Height="" HorizontalAlign="Center"
        Width="" CssClass="modal-derecha anim_RLR">
        <asp:UpdatePanel ID="upaUsuario" runat="server">
            <ContentTemplate>
                <asp:Button ID="Button1" runat="server" CssClass="btn" Text="X" Font-Bold="true" OnClientClick="OcultarEdicionUsuarios();" Style="z-index: 2000;right: 13px;margin-top:10px;position: absolute; color:#ffffff;" />
                <h5 class="modal-title" style="color:#ffffff;background-color:#2a3f54;width:100%;height:70px;padding-top:15px;">
                    <%--Edición de empleados--%>
                    <asp:Label ID="lblTituloModalUsuario" runat="server"></asp:Label>
                </h5><br />
                <div><%--style="margin:4px;">--%>
                    <table style="width: 97%; margin:0 auto !important;">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>  <br />        
                            <div class="row">
                                <div class="col-md-1"></div>
                                <div class="col-md-5" style="text-align:left;">
                                    <%--<asp:Label ID="lblNombre" runat="server" style="width:550px;"></asp:Label><br />
                                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>--%>
                                    <dx:bootstraptextbox ID="txtNombre" runat="server">
                                    </dx:bootstraptextbox>
                                    <asp:Label ID="lblReqNombre" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                </div>
                                <div class="col-md-5" style="text-align:left;">
                                    <asp:Label ID="lblApellidoPat" runat="server"></asp:Label><br />
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
                                <div class="col-md-5" style="text-align:left;">
                                    <asp:Label ID="lblApellidoMat" runat="server"></asp:Label><br />
                                    <asp:TextBox ID="txtApellidoMat" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-md-5" style="text-align:left;">
                                    <asp:Label ID="lblPuesto" runat="server"></asp:Label>
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
                                <div class="col-md-5" style="text-align:left;">
                                    <asp:Label ID="lblCorreo" runat="server"></asp:Label><br />
                                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblReqCorreo" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                </div>
                                <div class="col-md-5" style="text-align:left;">
                                    <asp:Label ID="lblTelefonoMovil" runat="server"></asp:Label><br />
                                    <asp:TextBox ID="txtTelMovil" runat="server" CssClass="form-control" MaxLength="13"></asp:TextBox>
                                    <cc1:FilteredTextBoxExtender ID="fteTelMovil" runat="server" TargetControlID="txtTelMovil" FilterMode="ValidChars"
                                        ValidChars="0123456789+"/>
                                </div>
                                <div class="col-md-1"></div>
                            </div>  
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="row">
                                <div class="col-md-1"></div>
                                <div class="col-md-5" style="text-align:left;">
                                    <asp:Label ID="lblPass" runat="server"></asp:Label><br />
                                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblReqPass" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                </div>
                                <div class="col-md-5" style="text-align:left;">
                                    <asp:Label ID="lblConfirPass" runat="server"></asp:Label><br />
                                    <asp:TextBox ID="txtConfirPass" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    <asp:Label ID="lblReqConfirPass" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                </div>
                                <div class="col-md-1"></div>
                            </div>
                        </td>
                    </tr>
                </table>
                </div>
                <br /><br /><br />
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <div class="row">
                                <div class="col-md-1">
                                    &nbsp;
                                </div>
                                <div class="col-md-10" style="text-align:right;">
                                    <asp:Button ID="btnAceptar" runat="server" CssClass="btn btn-primary" UseSubmitBehavior="true" OnClick="btnAceptar_Click"/>
                                </div>
                                <%--<div class="col-md-3" style="text-align:center;">
                                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-danger" OnClientClick="OcultarEdicionUsuarios();" />
                                </div>--%>
                                <div class="col-md-1">
                                    &nbsp;
                                </div>
                            </div>
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


    <%-- MODAL PARA SELECCION DE MATRICULAS --%>
    <asp:HiddenField ID="hdTargetMats" runat="server" />
    <cc1:ModalPopupExtender ID="mpeMats" runat="server" TargetControlID="hdTargetMats"
        PopupControlID="pnlMats" BackgroundCssClass="overlayy">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlMats" runat="server" BorderColor="" BackColor="White" HorizontalAlign="Center" Height="" Width=""
         CssClass="modalrlr">
        <asp:UpdatePanel ID="upaMats" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnCerrarMats" runat="server" CssClass="btn" Text="X" Font-Bold="true" OnClientClick="OcultarModalMatriculas();" Style="z-index: 2000;right: 13px;margin-top:10px;position: absolute; color:#ffffff;" />
                <h5 class="modal-title" style="color:#ffffff;background-color:#2a3f54;width:100%;height:70px;padding-top:15px;">
                    <%--Edición de empleados--%>
                    <asp:Label ID="lblTituloMatriculas" runat="server"></asp:Label>
                </h5><br />
                <div><%--style="margin:4px;">--%>
                    <asp:Panel ID="pnlMatsScroll" runat="server">
                        <div style="height:70vh; overflow-y:auto; overflow-x:hidden; border:1px solid #efefef; background-color:#00000003;">      
                            <div class="table-responsive" style="text-align:left;padding:5px;">
                                <asp:GridView ID="gvMatriculas" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvMatriculas_RowDataBound" Width="100%" CssClass="table table-bordered table-hover">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSeleccione" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Matricula" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
                <br />
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <div class="row">
                                <div class="col-md-12" style="text-align:right;">
                                    <asp:Button ID="btnAceptarMats" runat="server" CssClass="btn btn-primary" UseSubmitBehavior="true" OnClick="btnAceptarMats_Click"/>
                                    <asp:Button ID="btnCancelarMats" runat="server" CssClass="btn btn-warning" UseSubmitBehavior="true" OnClientClick="OcultarModalMatriculas();"/>
                                </div>
                            </div>
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


    <%-- MODAL PARA SELECCION DE MODULOS --%>
    <asp:HiddenField ID="hdTargetModulos" runat="server" />
    <cc1:ModalPopupExtender ID="mpeModulos" runat="server" TargetControlID="hdTargetModulos"
        PopupControlID="pnlModulos" BackgroundCssClass="overlayy">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlModulos" runat="server" BorderColor="" BackColor="White" HorizontalAlign="Center" Height="" Width=""
         CssClass="modalrlr">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnCerrarModulos" runat="server" CssClass="btn" Text="X" Font-Bold="true" OnClientClick="OcultarModalModulos();" Style="z-index: 2000;right: 13px;margin-top:10px;position: absolute; color:#ffffff;" />
                <h5 class="modal-title" style="color:#ffffff;background-color:#2a3f54;width:100%;height:70px;padding-top:15px;">
                    <asp:Label ID="lblTituloModulos" runat="server"></asp:Label>
                </h5><br />
                <div>
                    <asp:Panel ID="Panel2" runat="server">
                        <div style="height:70vh; overflow-y:auto; overflow-x:hidden; border:1px solid #efefef; background-color:#00000003;">      
                            <div class="table-responsive" style="text-align:left;padding:5px;">
                                <asp:GridView ID="gvModulos" runat="server" AutoGenerateColumns="false" OnRowDataBound="gvModulos_RowDataBound" Width="100%" CssClass="table table-bordered table-hover">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkSeleccione" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Clave" />
                                        <asp:BoundField DataField="Modulo" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
                <br />
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <div class="row">
                                <div class="col-md-12" style="text-align:right;">
                                    <asp:Button ID="btnAceptarModulos" runat="server" CssClass="btn btn-primary" UseSubmitBehavior="true" OnClick="btnAceptarModulos_Click"/>
                                    <asp:Button ID="btnCancelarModulos" runat="server" CssClass="btn btn-warning" UseSubmitBehavior="true" OnClientClick="OcultarModalModulos();"/>
                                </div>
                            </div>
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


    <%-- MODAL PARA CLONAR LOS PERMISOS DE UN USUARIO A OTRO --%>
    <asp:HiddenField ID="hdTargetClonar" runat="server" />
    <cc1:ModalPopupExtender ID="mpeClonar" runat="server" TargetControlID="hdTargetClonar"
        PopupControlID="pnlClonar" BackgroundCssClass="overlayy">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlClonar" runat="server" BorderColor="" BackColor="White" HorizontalAlign="Center" Height="" Width=""
         CssClass="modalrlr">
        <asp:UpdatePanel ID="upaClonar" runat="server">
            <ContentTemplate>
                <asp:Button ID="btnCerrarClonar" runat="server" CssClass="btn" Text="X" Font-Bold="true" OnClientClick="OcultarModalClonar();" Style="z-index: 2000;right: 13px;margin-top:10px;position: absolute; color:#ffffff;" />
                <h5 class="modal-title" style="color:#ffffff;background-color:#2a3f54;width:100%;height:70px;padding-top:15px;">
                    <asp:Label ID="lblTituloClonar" runat="server"></asp:Label>
                </h5><br />
                <div style="height:70vh; overflow-y:auto; overflow-x:hidden; border:1px solid #efefef; background-color:#00000003;">
                    <dx:BootstrapComboBox ID="ddlUsuarios" runat="server" ValueField="IdUsuario" TextFormatString="{0} {1}" DropDownRows="4">
                        <Fields>
                            <dx:BootstrapListBoxField FieldName="Nombres" />
                            <dx:BootstrapListBoxField FieldName="ApePat" />
                        </Fields>
                        <ButtonTemplate>
                            <br />
                            <span class="btn btn-secondary dropdown-toggle" data-toggle="dropdown-show" style="border-radius:2px;">Clic</span>
                        </ButtonTemplate>
                        <ItemTemplate>
                            <div class="media mb-3">
                                <%--<dx:BootstrapBinaryImage runat="server" AlternateText="" Value='<%# Eval("Photo") %>' Width="64" Height="68">
                                    <CssClasses Control="mr-3" />
                                </dx:BootstrapBinaryImage>--%>
                                <div class="media-body media-middle" style="padding:5px;">
                                    <h5 class="mt-0"><%# Eval("Nombres") %> <%# Eval("ApePat") %></h5>
                                    <%# Eval("Puesto") %>
                                </div>
                            </div>
                        </ItemTemplate>
                    </dx:BootstrapComboBox>
                </div>
                <br />
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <div class="row">
                                <div class="col-md-12" style="text-align:right;">
                                    <asp:Button ID="btnAceptarClonar" runat="server" CssClass="btn btn-primary" UseSubmitBehavior="true" OnClick="btnAceptarModulos_Click"/>
                                    <asp:Button ID="btnCancelarClonar" runat="server" CssClass="btn btn-warning" UseSubmitBehavior="true" OnClientClick="OcultarModalClonar();"/>
                                </div>
                            </div>
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
