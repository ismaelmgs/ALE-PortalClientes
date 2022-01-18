<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" UICulture="es" Culture="es-MX" AutoEventWireup="true" CodeBehind="frmDetalleReportes.aspx.cs" Inherits="PortalClientes.Views.frmDetalleReportes" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../vendors/jquery/dist/jquery.js"></script>

    <script language="javascript" type="text/javascript">  
        function divexpandcollapse(divname) {
            var div = document.getElementById(divname);
            var img = document.getElementById('img' + divname);
            if (div.style.display == "none") {
                div.style.display = "inline";
                img.src = "../Images/icons/flecha_cierra.png";
            } else {
                div.style.display = "none";
                img.src = "../Images/icons/flecha_abre1.png";
            }
        }

        function Ocultar()
        {
            "use strict";
            var modalId = '<%=mpeVuelosMes.ClientID%>';
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
                            <asp:Label ID="lblTitulo" runat="server" Text="Detalle Reporte"></asp:Label></h3>
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
            <div class="row" style="margin: 5px;">
                <div class="col-md-4 tile_count">
                    <div class="" style="text-align: center;">
                        <span class="count_top"><i class="fa fa-list-ol"></i>
                            <asp:Label ID="lblTotalTrasn" runat="server" Text=" Número de Vuelos" Font-Bold="false"></asp:Label></span>
                        <div class="count">
                            <asp:Label ID="lblTotalTrasnRes" runat="server" Font-Bold="true" CssClass="count4"></asp:Label>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 tile_count">
                    <div class="" style="text-align: center;">
                        <span class="count_top"><i class="fa fa-money"></i>
                            <asp:Label ID="lblTotal" runat="server" Text=" Pagos" Font-Bold="false"></asp:Label></span>
                        <div class="count">
                            <asp:Label ID="lblTotalSimbolo" runat="server" Text=" $" Font-Bold="true" CssClass="count3" />
                            <asp:Label ID="lblTotalRes" runat="server" Font-Bold="true" CssClass="count4" />
                        </div>
                    </div>
                </div>
                <div class="col-md-4 tile_count">
                    <div class="" style="text-align: center;">
                        <span class="count_top"><i class="fa fa-bar-chart"></i>
                            <asp:Label ID="lblPromedio" runat="server" Text=" Gastos" Font-Bold="false"></asp:Label></span>
                        <div class="count">
                            <asp:Label ID="lblPromedioSimbolo" runat="server" Text=" $" Font-Bold="true" CssClass="count3" style="font-size:17px;" />
                            <asp:Label ID="lblPromedioRes" runat="server" Font-Bold="true" CssClass="count4" style="font-size:25px;" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="x_panel" style="min-height: 55vh;">
                        <div class="x_title">
                            <h2>
                                <asp:Label ID="lblTransacciones" runat="server" Text="Transacciones" Font-Bold="true"></asp:Label></h2>

                            <ul class="nav navbar-right panel_toolbox">
                                <li style="padding-left: 5px;">
                                    <asp:LinkButton ID="btnExcel" runat="server" Text="<i class='fa fa-file-excel-o' style='color:#73879c;font-size:25px;'></i>" CssClass="btn" OnClick="btnExcel_Click" />
                                </li>
                                <li>
                                    <asp:LinkButton ID="btnPDF" runat="server" Text="<i class='fa fa-file-pdf-o' style='color:#73879c;font-size:25px;'></i>" CssClass="btn" OnClick="btnPDF_Click" />
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                            <div class="row">
                                <div class="col-md-3 offset-9">
                                    <asp:TextBox ID="txtFecha" AutoPostBack="true" runat="server" CssClass="form-control" Type="date" Width="100%" OnTextChanged="txtFecha_TextChanged"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="table-responsive">
                                    <div class="card-box table-responsive">
                                        <asp:GridView ID="gvdetReportes" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true"
                                            OnPageIndexChanging="gvdetReportes_PageIndexChanging" OnRowCreated="gvdetReportes_RowCreated" OnRowDataBound="gvdetReportes_RowDataBound" EmptyDataText="No Registros">
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="table-responsive">
                                    <div class="card-box table-responsive">
                                        <asp:GridView ID="gvdetRepConceptos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true"
                                            OnPageIndexChanging="gvdetRepConceptos_PageIndexChanging" OnRowDataBound="gvdetRepConceptos_RowDataBound" EmptyDataText="No Registros">
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <hr style="border: 1px solid #efefef;" />
                        <div style="width: 100%; text-align: center;">
                            <asp:LinkButton ID="btnRegresarEng" runat="server" Text="<i class='fa fa-undo' style='color:#73879C;font-size:14px;'></i> Reports <i class='fa fa-line-chart' style='color:#73879C;font-size:14px;'></i>" CssClass="btn" href="frmReportes.aspx" />
                            <asp:LinkButton ID="btnRegresar" runat="server" Text="<i class='fa fa-undo' style='color:#73879C;font-size:14px;'></i> Reportes <i class='fa fa-line-chart' style='color:#73879C;font-size:14px;'></i>" CssClass="btn" href="frmReportes.aspx" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
         <Triggers>
            <asp:PostBackTrigger ControlID="btnExcel" />
            <asp:PostBackTrigger ControlID="btnPDF" />
        </Triggers>
    </asp:UpdatePanel>


    <%-- MODAL PARA EDICIÓN DEL EMPLEADO --%>
    <asp:HiddenField ID="hdTargetVuelosMes" runat="server" />
    <cc1:ModalPopupExtender ID="mpeVuelosMes" runat="server" TargetControlID="hdTargetVuelosMes"
        PopupControlID="pnlVuelosMes" BackgroundCssClass="overlayy">
    </cc1:ModalPopupExtender>
    <asp:Panel ID="pnlVuelosMes" runat="server" BorderColor="" BackColor="White" Height="" HorizontalAlign="Center"
        Width="" CssClass="width_RLR" >
        <asp:UpdatePanel ID="upaVuelosMes" runat="server">
            <ContentTemplate>
                <asp:Button ID="Button1" runat="server" CssClass="btn" Text="X" Font-Bold="true" OnClientClick="Ocultar();" Style="z-index: 2000; right: 13px; margin-top: 10px; position: absolute; color: #ffffff;" />
                <h5 class="modal-title" style="color: #ffffff; background-color: #2a3f54; width: 100%; height: 70px; padding-top: 15px;">
                    <%--Edición de empleados--%>
                    <asp:Label ID="lblVueloMes" Text="Vuelos del Mes" runat="server"></asp:Label>
                </h5>
                <br />
                <div class="row">
                    <div class="col-md-12">
                        <div class="table-responsive">
                            <div class="card-box table-responsive">
                                <asp:GridView ID="gvVuelos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true"
                                    OnPageIndexChanging="gvVuelos_PageIndexChanging" OnRowDataBound="gvVuelos_RowDataBound" EmptyDataText="No Registros">
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-10" style="text-align: right;">
                        <asp:Button ID="btnsalir" runat="server" CssClass="btn btn-primary" UseSubmitBehavior="true" OnClick="btnsalir_Click" />
                    </div>
                </div><br />
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
