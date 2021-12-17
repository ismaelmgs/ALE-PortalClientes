<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmEstadoCuenta.aspx.cs" UICulture="es" Culture="es-MX" Inherits="PortalClientes.Views.frmEstadoCuenta" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-3.3.1.min.js"></script>

    <script type="text/javascript">
        function OcultarModal() {
            "use strict";
            var modalId = '<%=mpeDocsEdoCuenta.ClientID%>';
            var modal = $find(modalId);
            modal.hide();
        }
        
        $(document).on('keydown', function (event){
            if (event.key == "Escape") {
                var modalcloId = '<%=mpeDocsEdoCuenta.ClientID%>';
                var modalclo = $find(modalcloId);
                modalclo.hide();
            }
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upaPrincipal" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-6">
                    <div class="title_left">
                        <h3>
                            <asp:Label ID="lblTitulo" runat="server" Text="Estados de Cuenta Mensual"></asp:Label>
                            (<asp:Label ID="lblPeriodo" runat="server"></asp:Label>)
                        </h3>
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
                            <h2>
                                <asp:Label ID="lblResumenDeCuenta" runat="server" Text="Resumen de la cuenta" Font-Bold="true"></asp:Label>
                                <asp:Label ID="lblDolares" runat="server" Text=" | USD" Font-Bold="true"></asp:Label></h2>
                            <div class="clearfix"></div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div>
                                    <br />
                                    <div class="row" style="margin: 5px;">
                                        <div class="col-md-3 tile_count">
                                            <div class="tile_stats_count" style="text-align: center; background-image: none !important; border: 0px;">
                                                <span class="count_top">
                                                    <asp:Label ID="lblSaldoActual" runat="server" Text=" Saldo Actual" Font-Bold="false"></asp:Label></span>
                                                <div class="count">
                                                    <asp:Label ID="lblSaldoActualaUSD" runat="server" Text=" $" Font-Bold="true" CssClass="count" />
                                                    <asp:Label ID="lblSaldoActualRes" runat="server" Text=" 155,522.11" Font-Bold="true" CssClass="count"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3 tile_count">
                                            <div class="tile_stats_count" style="text-align: center; background-image: none !important; border: 0px;">
                                                <span class="count_top">
                                                    <asp:Label ID="lblNuevosCargos" runat="server" Text=" Nuevos Cargos" Font-Bold="false"></asp:Label></span>
                                                <div class="count">
                                                    <asp:Label ID="lblNuevosCargosUSD" runat="server" Text=" $" Font-Bold="true" CssClass="count" />
                                                    <asp:Label ID="lblNuevosCargosRes" runat="server" Text=" 155.522.11" Font-Bold="true" CssClass="count"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3 tile_count">
                                            <div class="tile_stats_count" style="text-align: center; background-image: none !important; border: 0px;">
                                                <span class="count_top">
                                                    <asp:Label ID="lblPagosPeriodo" runat="server" Text=" Pagos del periodo" Font-Bold="false"></asp:Label></span>
                                                <div class="count">
                                                    <asp:Label ID="lblPagosPeriodoUSD" runat="server" Text=" $" Font-Bold="true" CssClass="count" />
                                                    <asp:Label ID="lblPagosPeriodoRes" runat="server" Text=" 0.00" Font-Bold="true" CssClass="count"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3 tile_count">
                                            <div class="tile_stats_count" style="text-align: center; background-image: none !important; border: 0px;">
                                                <span class="count_top">
                                                    <asp:Label ID="lblMontoReq" runat="server" Text=" Monto de Depósito Requerido" Font-Bold="false"></asp:Label></span>
                                                <div class="count">
                                                    <asp:Label ID="lblMontoReqUSD" runat="server" Text=" $" Font-Bold="true" CssClass="count" />
                                                    <asp:Label ID="lblMontoReqRes" runat="server" Text=" 0.00" Font-Bold="true" CssClass="count"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="x_title">
                            <h2>
                                <asp:Label ID="lblResumenPeriodo" runat="server" Text="Resumen de la cuenta" Font-Bold="true"></asp:Label>
                                <asp:Label ID="lblPesos" runat="server" Text=" | MXN" Font-Bold="true"></asp:Label>
                            </h2>
                            <div class="clearfix"></div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div>
                                    <br />
                                    <div class="row" style="margin: 5px;">
                                        <div class="col-md-3 tile_count">
                                            <div class="tile_stats_count" style="text-align: center; background-image: none !important; border: 0px;">
                                                <span class="count_top">
                                                    <asp:Label ID="lblSaldoActualMXN" runat="server" Text=" Saldo Actual" Font-Bold="false"></asp:Label></span>
                                                <div class="count">
                                                    <asp:Label ID="lblSaldoActualMonMXN" runat="server" Text=" $" Font-Bold="true" CssClass="count" />
                                                    <asp:Label ID="lblSaldoActualMXNRes" runat="server" Text=" 0.01" Font-Bold="true" CssClass="count"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3 tile_count">
                                            <div class="tile_stats_count" style="text-align: center; background-image: none !important; border: 0px;">
                                                <span class="count_top">
                                                    <asp:Label ID="lblNuevosCargosMXN" runat="server" Text=" Nuevos Cargos" Font-Bold="false"></asp:Label></span>
                                                <div class="count">
                                                    <asp:Label ID="Label7" runat="server" Text=" $" Font-Bold="true" CssClass="count" />
                                                    <asp:Label ID="lblNuevosCargosMXNRes" runat="server" Text=" 0.01" Font-Bold="true" CssClass="count"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3 tile_count">
                                            <div class="tile_stats_count" style="text-align: center; background-image: none !important; border: 0px;">
                                                <span class="count_top">
                                                    <asp:Label ID="lblPagosPeriodoMXN" runat="server" Text=" Pagos del periodo" Font-Bold="false"></asp:Label></span>
                                                <div class="count">
                                                    <asp:Label ID="Label10" runat="server" Text=" $" Font-Bold="true" CssClass="count" />
                                                    <asp:Label ID="lblPagosPeriodoMXNRes" runat="server" Text=" 0.00" Font-Bold="true" CssClass="count"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-3 tile_count">
                                            <div class="tile_stats_count" style="text-align: center; background-image: none !important; border: 0px;">
                                                <span class="count_top">
                                                    <asp:Label ID="lblMontoReqMXN" runat="server" Text=" Monto de Depósito Requerido" Font-Bold="false"></asp:Label></span>
                                                <div class="count">
                                                    <asp:Label ID="Label13" runat="server" Text=" $" Font-Bold="true" CssClass="count" />
                                                    <asp:Label ID="lblMontoReqMXNRes" runat="server" Text=" 0.00" Font-Bold="true" CssClass="count"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12 col-sm-12">
                    <div class="x_panel">
                        <div class="x_title">
                            <h2>
                                <asp:Label ID="lblAnio" runat="server" Text="2021" Font-Bold="true"></asp:Label>
                            </h2>
                            <div class="clearfix"></div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <div>
                                    <asp:GridView ID="gvEdoCuenta" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true"
                                        EmptyDataText="No Registros" OnRowDataBound="gvEdoCuenta_RowDataBound" OnRowCommand="gvEdoCuenta_RowCommand" DataKeyNames="Mes">
                                        <Columns>
                                            <asp:BoundField DataField="nombreMes" />
                                            <asp:BoundField DataField="saldoAnteriorMXN" DataFormatString="{0:c}" />
                                            <asp:BoundField DataField="pagosCreditoMXN" DataFormatString="{0:c}" />
                                            <asp:BoundField DataField="nuevosCargosMXN" DataFormatString="{0:c}" />
                                            <asp:BoundField DataField="saldoActualMXN" DataFormatString="{0:c}" />
                                            <asp:BoundField DataField="saldoAnteriorUSD" DataFormatString="{0:c}" />
                                            <asp:BoundField DataField="pagosCreditoUSD" DataFormatString="{0:c}" />
                                            <asp:BoundField DataField="nuevosCargosUSD" DataFormatString="{0:c}" />
                                            <asp:BoundField DataField="saldoActualUSD" DataFormatString="{0:c}" />
                                             <asp:TemplateField ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="lkbViewDocument" runat="server" ImageUrl="~/Images/icons/descargar.png" Width="30px" Height="32px"
                                                             CommandName="ViewDocument" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CssClass="btn" />&nbsp;&nbsp;&nbsp;
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="lkbDetalle" runat="server" CommandName="Detalle" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"></asp:LinkButton>
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
            <!-- Button trigger modal -->
            <%--<button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
                Launch demo modal
            </button>--%>

            <!-- Modal -->
           <%-- <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title" id="exampleModalLabel">
                                <asp:Label ID="lblTituloMensajes" runat="server" Text="Mensajes" Font-Bold="true"></asp:Label></h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <ul class="nav nav-tabs" id="myTab" role="tablist">
                                        <li class="nav-item">
                                            <a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">
                                                <asp:Label ID="lblMensajeNuevo" runat="server" Text=" Mensaje Nuevo" Font-Bold="true"></asp:Label></a>
                                        </li>
                                        <li class="nav-item">
                                            <a class="nav-link" id="profile-tab" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="false">
                                                <asp:Label ID="lblHistorialMensajes" runat="server" Text=" Historial de Mensajes" Font-Bold="true"></asp:Label></a>
                                        </li>
                                    </ul>
                                    <div class="tab-content" id="myTabContent">
                                        <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                                            <div class="row">
                                                <div class="col-md-2" style="padding-top: 10px;">
                                                    <asp:Label ID="lblMensajePara" runat="server" Text=" Para:" Font-Bold="true"></asp:Label>
                                                </div>
                                                <div class="col-md-10">
                                                    <asp:TextBox ID="txtMensajePara" type="text" runat="server" Text="Recipientes" Width="100%" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-2">
                                                    <asp:Button ID="btnAddCc" Text="+ Add Cc" runat="server" CssClass="btn btn-primary" />
                                                </div>
                                                <div class="col-md-2">
                                                    <asp:Button ID="btnAddBcc" Text="+ Add Bcc" runat="server" CssClass="btn btn-primary" />
                                                </div>
                                                <div class="col-md-8">
                                                    &nbsp;
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <asp:Label ID="lblMensajeOpcional" runat="server" Text=" Mensaje Opcional" Font-Bold="true"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <asp:TextBox ID="txtMensaje" type="text" runat="server" Text="" Width="100%" CssClass="form-control"></asp:TextBox>
                                                </div>
                                            </div>
                                            <br />
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <asp:CheckBox ID="cbIncluirPDFs" runat="server" type="checkbox" Text="&nbsp;&nbsp;&nbsp;Incluir PDFs de extractos mensuales como archivos adjuntos (< 7,5 Mb)" />
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-12">
                                                    --- Grid ---
                                                </div>
                                            </div>
                                        </div>
                                        <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                                            ...
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                        </div>
                    </div>
                </div>
            </div>--%>
        </ContentTemplate>
    </asp:UpdatePanel>

    <%-- MODAL --%>
    <asp:HiddenField ID="hdTargetDocs" runat="server" />
    <cc1:modalpopupextender id="mpeDocsEdoCuenta" runat="server" targetcontrolid="hdTargetDocs"
        popupcontrolid="pnlDocsEdoCuenta" backgroundcssclass="overlayy">
    </cc1:modalpopupextender>
    <asp:Panel ID="pnlDocsEdoCuenta" runat="server" BorderColor="" BackColor="White" HorizontalAlign="Center" Height="" Width=""
        CssClass="modalrlr">
        <asp:UpdatePanel ID="upaDocsEdoCuenta" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Button ID="btnCerrar" runat="server" CssClass="btn" Text="X" Font-Bold="true" OnClientClick="OcultarModal();" Style="z-index: 2000; right: 13px; margin-top: 10px; position: absolute; color: #ffffff;" />
                <h5 class="modal-title" style="color: #ffffff; background-color: #2a3f54; width: 100%; height: 70px; padding-top: 15px;">
                    <asp:Label ID="lblTituloDocsEdoCuenta" runat="server"></asp:Label>
                </h5>
                <br />
                <div style="height: 70vh; overflow-y: auto; overflow-x: hidden; border: 1px solid #efefef; background-color: #00000003;">
                    <asp:GridView ID="gvDocEdoCuenta" runat="server" AutoGenerateColumns="false"
                        OnRowDataBound="gvDocEdoCuenta_RowDataBound" OnRowCommand="gvDocEdoCuenta_RowCommand" Width="100%" CssClass="table table-bordered table-hover">
                        <Columns>
                            <asp:BoundField DataField="Clave" />
                            <asp:BoundField DataField="RazonSocial" />
                            <asp:BoundField DataField="TipoDocumento" />
                            <asp:BoundField DataField="Folio" />
                            <asp:BoundField DataField="fechaDocumento" DataFormatString = "{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="anio" />
                            <asp:BoundField DataField="mes" />
                            <asp:BoundField DataField="dia" />
                            <asp:TemplateField  ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate >
                                    <asp:ImageButton ID="lkbDownloadDoc" runat="server" ImageUrl="~/Images/icons/descargar.png" Width="30px" Height="32px"
                                                             CommandName="Download" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" CssClass="btn" />&nbsp;&nbsp;&nbsp;
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <br />
                <table style="width: 100%;">
                    <tr>
                        <td>
                            <div class="row">
                                <div class="col-md-12" style="text-align: right;">
                                    <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-warning" UseSubmitBehavior="true" OnClientClick="OcultarModal();" />
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="gvDocEdoCuenta" />
            </Triggers>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Content>
