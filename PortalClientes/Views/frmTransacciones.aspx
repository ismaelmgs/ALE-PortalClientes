<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" UICulture="es" Culture="es-MX" AutoEventWireup="true" CodeBehind="frmTransacciones.aspx.cs" Inherits="PortalClientes.Views.frmTransacciones" %>

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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="upaPrincipal" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-6">
                    <div class="title_left">
                        <h3>
                            <asp:Label ID="lblTitulo" runat="server" Text="Transacciones"></asp:Label></h3>
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
                        <span class="count_top"><i runat="server" id="iconTime" class="fa fa-clock-o"></i> <i runat="server" id="iconMoney" class="fa fa-money"></i>
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
                            <asp:Label ID="lblPromedioRes" runat="server" Font-Bold="true" CssClass="coun4" style="font-size:25px;" />
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
                                    <asp:LinkButton ID="btnExcel" runat="server" Text="<i class='fa fa-file-excel-o' style='color:#73879c;font-size:25px;'></i>" OnClientClick="LoadingTime(3)" CssClass="btn" OnClick="btnExcel_Click" />
                                </li>
                                <li>
                                    <asp:LinkButton ID="btnPDF" runat="server" Text="<i class='fa fa-file-pdf-o' style='color:#73879c;font-size:25px;'></i>" OnClientClick="LoadingTime(3)" CssClass="btn" OnClick="btnPDF_Click" Visible="false" />
                                </li>
                            </ul>
                            <div class="clearfix"></div>
                        </div>

                        <asp:Panel ID="pnlGastos" runat="server" Visible="false">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <div class="card-box table-responsive">
                                            <asp:GridView ID="gvGastos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true"
                                                OnPageIndexChanging="gvGastos_PageIndexChanging" OnRowDataBound="gvGastos_RowDataBound" EmptyDataText="No Registros">
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        
                        <asp:Panel ID="pnlGastosViewRef" runat="server" Visible="false">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="table-responsive">
                                        <div class="card-box table-responsive">

                                            <asp:GridView ID="gvGastosRef" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true"
                                                OnPageIndexChanging="gvGastosRef_PageIndexChanging" EmptyDataText="No Registros" OnRowCommand="gvGastosRef_RowCommand">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Mes" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblMesAnio" Text='<%# Bind("nombreMes") %>' runat="server" Style="display: block; text-align: center;"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Tipo Moneda" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTipoMoneda" Text='<%# Bind("tipoMoneda") %>' runat="server" Style="display: block; text-align: center;"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Fecha" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFecha" Text='<%# Bind("fecha") %>' runat="server" Style="display: block; text-align: center;"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="No Referencia" SortExpression="Referencia" ControlStyle-Width="150" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:UpdatePanel ID="upaLinkRef" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <asp:Label ID="lblReferenciaPesos" runat="server" Text='<%# Bind("noReferencia") %>' Font-Size="X-Small"></asp:Label>
                                                                    <asp:ImageButton ID="imbReferenciaPesos" runat="server" Width="16" Height="16" ImageUrl="~/Images/icons/searchdate.png" CommandName="ViewReference" Style="margin: 0 auto; margin-left: 25%;"
                                                                        CommandArgument="<%# ((GridViewRow) Container).RowIndex %>" ToolTip="De clic para visualizar el documento." Visible="true"></asp:ImageButton>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Tipo de Gasto" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblTipoGasto" Text='<%# Bind("tipoGasto") %>' runat="server" Style="display: block; text-align: center;"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Concepto" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblConcepto" Text='<%# Bind("concepto") %>' runat="server" Style="display: block; text-align: center;"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Detalle" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDetalle" Text='<%# Bind("detalle") %>' runat="server" Style="display: block; text-align: center;"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Proveedor" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblProveedor" Text='<%# Bind("proveedor") %>' runat="server" Style="display: block; text-align: center;"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Importe" ItemStyle-HorizontalAlign="center" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblImporte" Text='<%# Bind("importe", "{0:c}") %>' runat="server" Style="display: block; text-align: center;"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>



                        <hr style="border: 1px solid #efefef;" />
                        <div style="width: 100%; text-align: center;">
                            <asp:LinkButton ID="btnRegresarMeEsEng" runat="server" Text="<i class='fa fa-undo' style='color:#73879C;font-size:14px;'></i> Metrics and Statistics <i class='fa fa-line-chart' style='color:#73879C;font-size:14px;'></i>" CssClass="btn" href="frmMetricasEstadisticas.aspx" />
                            <asp:LinkButton ID="btnRegresarMeEs" runat="server" Text="<i class='fa fa-undo' style='color:#73879C;font-size:14px;'></i> Metricas y Estadisticas <i class='fa fa-line-chart' style='color:#73879C;font-size:14px;'></i>" CssClass="btn" href="frmMetricasEstadisticas.aspx" />
                            <asp:LinkButton ID="btnRegresarDash" runat="server" Text="<i class='fa fa-undo' style='color:#73879C;font-size:14px;'></i> Dashboard <i class='fa fa-th-large' style='color:#73879C;font-size:14px;'></i>" CssClass="btn" href="frmDashboard.aspx" />
                            <asp:LinkButton ID="btnRegresaEdoCtaEng" runat="server" Text="<i class='fa fa-undo' style='color:#73879C;font-size:14px;'></i> Account Status <i class='fa fa-th-large' style='color:#73879C;font-size:14px;'></i>" CssClass="btn" href="frmEstadoCuenta.aspx" />
                            <asp:LinkButton ID="btnRegresaEdoCta" runat="server" Text="<i class='fa fa-undo' style='color:#73879C;font-size:14px;'></i> Estado de cuenta <i class='fa fa-th-large' style='color:#73879C;font-size:14px;'></i>" CssClass="btn" href="frmEstadoCuenta.aspx" />
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
</asp:Content>
