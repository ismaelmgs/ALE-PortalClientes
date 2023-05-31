<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmMantenimientos.aspx.cs" Inherits="PortalClientes.Views.frmMantenimientos"  EnableEventValidation="false"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upaPrincipal" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-6">
                    <div class="title_left">
                        <h3>
                            <asp:Label ID="lblMantenimientosHeader" runat="server" Text=" Mantenimientos" Font-Bold="false"></asp:Label></h3>
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
                            <div class="row">
                                <div class="col-md-6" style="text-align: left;">
                                    <h2>
                                        <asp:Label ID="lblMantenimientos" runat="server" Text="Mantenimientos" Font-Bold="true"></asp:Label>
                                    </h2>
                                </div>
                                <div class="col-md-6" style="text-align: right;">
                                    <div class="row">
                                        <div class="col-md-2">
                                            &nbsp;
                                        </div>
                                        <div class="col-md-7">
                                            <asp:DropDownList ID="DDFiltroMeses" runat="server" AutoPostBack="true" CssClass="form-control ddl" Width="100%" OnSelectedIndexChanged="DDFiltroMeses_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="row">
                                                <div class="col-md-5">
                                                    <asp:LinkButton ID="btnExc" runat="server" Text="<i class='fa fa-file-excel-o' style='color:#73879c;font-size:25px;'></i>" CssClass="btn"  OnClientClick="LoadingTime(3)" OnClick="btnExc_Click" Visible="false" />
                                                </div>
                                                <div class="col-md-5">
                                                    <asp:LinkButton ID="btnPdf" runat="server" Text="<i class='fa fa-file-pdf-o' style='color:#73879c;font-size:25px;' ></i>" CssClass="btn"  OnClientClick="LoadingTime(3)" OnClick="btnPdf_Click" Visible="false" />
                                                </div>
                                                <div class="col-md-2">
                                                    &nbsp;
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                        <div class="row">
                           <div class="col-md-12">
                                <div class="table-responsive">
                                    <div class="card-box table-responsive">
                                        <asp:GridView ID="gvMttos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" ChildrenAsTriggers="False"
                                            AllowPaging="true" OnRowDataBound="gvMttos_RowDataBound" EmptyDataText="No Registros" OnPageIndexChanging="gvMttos_PageIndexChanging">
                                            <Columns>
                                                <asp:BoundField DataField="Matricula" HeaderText="Matricula" />
                                                <asp:BoundField DataField="Origen" HeaderText="Origen" />
                                                <asp:BoundField DataField="Destino" HeaderText="Destino" />
                                                <asp:BoundField DataField="FechaSalida" HeaderText="FechaSalida" />
                                                <asp:BoundField DataField="FechaLlegada" HeaderText="FechaLlegada" />
                                                <asp:BoundField DataField="Pasajeros" HeaderText="Pasajeros" />
                                                <asp:BoundField DataField="Trip" HeaderText="Trip" />
                                                <asp:BoundField DataField="Comentarios" HeaderText="Comentarios" />
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
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExc" />
            <asp:PostBackTrigger ControlID="btnPdf" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
