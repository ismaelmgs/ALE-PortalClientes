<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmTripulacion.aspx.cs" Inherits="PortalClientes.Views.frmTripulacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row">
        <div class="col-md-6">
            <div class="title_left">
                <h3>Tripulación</h3>
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
        <div class="x_panel" style="min-height:74vh;">
            <div class="x_title">
                <h2><asp:Label ID="lblTripulacion" runat="server" Text="Tripulación" Font-Bold="true"></asp:Label></h2>
                <%--<ul class="nav navbar-right panel_toolbox">
                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                    <li><a class="close-link"><i class="fa fa-close"></i></a>
                    </li>
                </ul>--%>
                <div class="clearfix"></div>
            </div>
            <div class="row">
                        <div class="col-md-7">
                            &nbsp;
                        </div>
                        <div class="col-md-3" style="text-align:right;">
                            <asp:DropDownList id="ddlFiltro" runat="server" CssClass="form-control">
                                <asp:ListItem Selected="True" Value="Próximos tres meses"> Próximos 3 meses </asp:ListItem>
                                <asp:ListItem Value="Próximos dos meses"> Próximos 2 meses </asp:ListItem>
                                <asp:ListItem Value="Próximo mes"> Próximo mes </asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2" style="text-align:center;">
                            <button id="btnFiltrarTripulacion" class="btn btn-primary" type="button">
                                <i class="fa fa-filter" aria-hidden="true"></i> Filtrar
                            </button>
                        </div>
                    </div>
            <div class="row">
                <div class="col-md-12">
                    <ul class="nav nav-tabs" id="myTab" role="tablist">
                      <li class="nav-item">
                        <a class="nav-link active" id="home-tab" data-toggle="tab" href="#home" role="tab" aria-controls="home" aria-selected="true">Eventos</a>
                      </li>
                      <li class="nav-item">
                        <a class="nav-link" id="profile-tab" data-toggle="tab" href="#profile" role="tab" aria-controls="profile" aria-selected="false">Listado</a>
                      </li>
                    </ul>
                    <div class="tab-content" id="myTabContent">
                        <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
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
                      <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                          <div class="table-responsive">
                                <div class="card-box table-responsive">
                                    <asp:GridView ID="gvPilotos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true"
                                        OnPageIndexChanging="gvPilotos_PageIndexChanging" OnRowDataBound="gvPilotos_RowDataBound" EmptyDataText="No Registros">
                                        <Columns>
                                            <asp:BoundField DataField="codigoPiloto" />
                                            <asp:BoundField DataField="piloto" />
                                            <asp:BoundField DataField="licenciaVuelo" />
                                            <asp:BoundField DataField="tipoLicencia" />
                                            <asp:BoundField DataField="lugarTrabajo" />
                                            <asp:BoundField DataField="noVisa" />
                                            <asp:BoundField DataField="fechaExpiraVisa" />
                                            <asp:BoundField DataField="paisVisa" />
                                            <asp:BoundField DataField="noPassport" />
                                            <asp:BoundField DataField="fechaExpiraPass" />
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
</asp:Content>
