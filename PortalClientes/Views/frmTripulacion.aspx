<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmTripulacion.aspx.cs" EnableEventValidation="false" Inherits="PortalClientes.Views.frmTripulacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upaPrincipal" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-6">
                    <div class="title_left">
                        <h3>
                            <asp:Label ID="lblTitleTripulacion" runat="server" Text="Tripulación" Font-Bold="true"></asp:Label></h3>
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
                    <div class="x_panel" style="min-height: 74vh;">
                        <div class="x_title">
                            <h2>
                                <asp:Label ID="lblTripulacion" runat="server" Text="Tripulación" Font-Bold="true"></asp:Label></h2>
                            <div class="clearfix"></div>
                        </div>
                        <div class="row">
                            <div class="col-md-12">
                                <ul class="nav nav-tabs" id="myTab" role="tablist">
                                    <li class="nav-item">
                                        <a class="nav-link active" runat="server" id="hometab" data-toggle="tab" href="#ContentPlaceHolder1_home" role="tab" aria-controls="ContentPlaceHolder1_home" aria-selected="true">
                                            <asp:Label ID="lblPanelEventos" runat="server" Text="Eventos" Font-Bold="true"></asp:Label></a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" runat="server" id="profiletab" data-toggle="tab" href="#ContentPlaceHolder1_profile" role="tab" aria-controls="ContentPlaceHolder1_profile" aria-selected="false">
                                            <asp:Label ID="lblPanelListado" runat="server" Text="Listado" Font-Bold="true"></asp:Label></a>
                                    </li>
                                </ul>
                                <div class="tab-content" id="myTabContent">
                                    <div class="tab-pane fade show active" runat="server" id="home" role="tabpanel" aria-labelledby="home-tab">
                                        <br />
                                        <div class="row">
                                            <div class="col-md-6">&nbsp;</div>
                                            <div class="col-md-3">
                                                <asp:DropDownList ID="ddlFiltro" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-md-1" style="text-align: right;">
                                                <asp:Button ID="btnFiltrarTripulacion" runat="server" Text="Filtrar" CssClass="btn btn-success" OnClick="btnFiltrar_Click" Style="margin-left: 10px;" />
                                            </div>
                                            <div class="col" style="text-align: center;">
                                                <asp:LinkButton ID="btnExcelEvent" runat="server" Text="<i class='fa fa-file-excel-o' style='color:#73879c;font-size:28px;'></i>" CssClass="btn" OnClick="btnExcelEvent_Click" />
                                                <asp:LinkButton ID="btnPDFEvent" runat="server" Text="<i class='fa fa-file-pdf-o' style='color:#73879c;font-size:28px;'></i>" CssClass="btn" OnClick="btnPDFEvent_Click" />
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="table-responsive">
                                                    <div class="card-box table-responsive">
                                                        <asp:GridView ID="gvEventos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true"
                                                            OnPageIndexChanging="gvEventos_PageIndexChanging" OnRowDataBound="gvEventos_RowDataBound" EmptyDataText="No Registros">
                                                            <Columns>
                                                                <asp:BoundField DataField="fechaInicio" />
                                                                <asp:BoundField DataField="fechaFin" />
                                                                <asp:BoundField DataField="codigoPiloto" />
                                                                <asp:BoundField DataField="piloto" />
                                                                <asp:BoundField DataField="temaESP" />
                                                                <asp:BoundField DataField="temaENG" />
                                                                <asp:BoundField DataField="descripcion" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="tab-pane fade" runat="server" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                                        <br />
                                        <div class="row">
                                            <div class="col-md-2 offset-10" style="text-align: center;">
                                                <asp:LinkButton ID="btnExcelPilotos" runat="server" Text="<i class='fa fa-file-excel-o' style='color:#73879c;font-size:28px;'></i>" CssClass="btn" OnClick="btnExcelPilotos_Click" />
                                                <asp:LinkButton ID="btnPDFPilotos" runat="server" Text="<i class='fa fa-file-pdf-o' style='color:#73879c;font-size:28px;'></i>" CssClass="btn" OnClick="btnPDFPilotos_Click" />
                                            </div>
                                        </div>
                                        <br />
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="table-responsive">
                                                    <div class="card-box table-responsive">
                                                        <asp:GridView ID="gvPilotos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true"
                                                            OnPageIndexChanging="gvPilotos_PageIndexChanging" OnRowDataBound="gvPilotos_RowDataBound" EmptyDataText="No Registros">
                                                            <Columns>
                                                                <asp:BoundField DataField="codigoPiloto" />
                                                                <asp:BoundField DataField="nombre" />
                                                                <asp:BoundField DataField="tipoDocumentoEsp" />
                                                                <asp:BoundField DataField="tipoDocumentoEng" />
                                                                <asp:BoundField DataField="tipo" />
                                                                <asp:BoundField DataField="numero" />
                                                                <asp:BoundField DataField="fechaExpiracion" />
                                                                <asp:BoundField DataField="lugarTrabajo" />
                                                                <asp:BoundField DataField="pais" />
                                                                <asp:BoundField DataField="estatusEsp" />
                                                                <asp:BoundField DataField="estatusEng" />
                                                            </Columns>
                                                        </asp:GridView>
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
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExcelEvent" />
            <asp:PostBackTrigger ControlID="btnPDFEvent" />
            <asp:PostBackTrigger ControlID="btnExcelPilotos" />
            <asp:PostBackTrigger ControlID="btnPDFPilotos" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
