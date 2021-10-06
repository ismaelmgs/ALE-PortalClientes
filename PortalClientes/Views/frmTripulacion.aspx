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
                <ul class="nav navbar-right panel_toolbox">
                    <li><a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                    <li><a class="close-link"><i class="fa fa-close"></i></a>
                    </li>
                </ul>
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
                               <table class="table table-striped table-bordered table-hover">
                                       <tr>
                                           <th>
                                               <asp:Label ID="lblFechaHoraInicio" runat="server" Text="Fecha y hora de inicio" Font-Bold="true"></asp:Label>
                                           </th>
                                           <th>
                                               <asp:Label ID="lblFechaHoraFin" runat="server" Text="Fecha y hora de término" Font-Bold="true"></asp:Label>
                                           </th>
                                           <th>
                                               <asp:Label ID="lblMiembroTripulacion" runat="server" Text="Miembro de la tripulación" Font-Bold="true"></asp:Label>
                                           </th>
                                           <th>
                                               <asp:Label ID="lblTripulacionTipo" runat="server" Text="Tipo" Font-Bold="true"></asp:Label>
                                           </th>
                                           <th>
                                               <asp:Label ID="lblTripulacionDescripcion" runat="server" Text="Descripción" Font-Bold="true"></asp:Label>
                                           </th>
                                       </tr>
                                       <tr>
                                           <td>
                                               <asp:Label ID="lblFechaHoraInicioRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                           </td>
                                           <td>
                                               <asp:Label ID="lblFechaHoraFinRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                           </td>
                                           <td>
                                               <asp:Label ID="lblMiembroTripulacionRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                           </td>
                                           <td>
                                               <asp:Label ID="lblTripulacionTipoRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                           </td>
                                           <td>
                                               <asp:Label ID="lblTripulacionDescripcionRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                           </td>
                                       </tr>
                               </table>
                           </div>
                      </div>
                      <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                            <div class="table-responsive">
                               <table class="table table-striped table-bordered table-hover">
                                       <tr>
                                           <th>
                                               <asp:Label ID="lblCodigo" runat="server" Text="Código Piloto" Font-Bold="true"></asp:Label>
                                           </th>
                                           <th>
                                               <asp:Label ID="lblNombre" runat="server" Text="Nombre" Font-Bold="true"></asp:Label>
                                           </th>
                                           <th>
                                               <asp:Label ID="lblLicencia" runat="server" Text="Licencia" Font-Bold="true"></asp:Label>
                                           </th>
                                           <th>
                                               <asp:Label ID="lblTipo" runat="server" Text="Tipo" Font-Bold="true"></asp:Label>
                                           </th>
                                           <th>
                                               <asp:Label ID="lblLugarTrabajo" runat="server" Text="Lugar de Trabajo" Font-Bold="true"></asp:Label>
                                           </th>
                                           <th>
                                               <asp:Label ID="lblNumeroVisa" runat="server" Text="No. de Visa" Font-Bold="true"></asp:Label>
                                           </th>
                                           <th>
                                               <asp:Label ID="lblExpiracionVisa" runat="server" Text="Expiración Visa" Font-Bold="true"></asp:Label>
                                           </th>
                                           <th>
                                               <asp:Label ID="lblPaisVisa" runat="server" Text="País Visa" Font-Bold="true"></asp:Label>
                                           </th>
                                           <th>
                                               <asp:Label ID="lblPasaporte" runat="server" Text="No. Pasaporte" Font-Bold="true"></asp:Label>
                                           </th>
                                           <th>
                                               <asp:Label ID="lblExpiracionPasaporte" runat="server" Text="Expiración Pasaporte" Font-Bold="true"></asp:Label>
                                           </th>
                                       </tr>
                                       <tr>
                                           <td>
                                               <asp:Label ID="lblCodigoRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                           </td>
                                           <td>
                                               <asp:Label ID="lblNombreRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                           </td>
                                           <td>
                                               <asp:Label ID="lblLicenciaRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                           </td>
                                           <td>
                                               <asp:Label ID="lblTipoRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                           </td>
                                           <td>
                                               <asp:Label ID="lblLugarTrabajoRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                           </td>
                                           <td>
                                               <asp:Label ID="lblNumeroVisaRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                           </td>
                                           <td>
                                               <asp:Label ID="lblExpiracionVisaRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                           </td>
                                           <td>
                                               <asp:Label ID="lblPaisVisaRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                           </td>
                                           <td>
                                               <asp:Label ID="lblPasaporteRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                           </td>
                                           <td>
                                               <asp:Label ID="lblExpiracionPasaporteRes" runat="server" Text="---" Font-Bold="true"></asp:Label>
                                           </td>
                                       </tr>
                               </table>
                           </div>
                      </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>
