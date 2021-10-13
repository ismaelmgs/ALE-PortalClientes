<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="frmTransacciones.aspx.cs" Inherits="PortalClientes.Views.frmTransacciones" %>

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
            <div class="row">
        <div class="col-md-6">
            <div class="title_left">
                <h3><asp:Label ID="lblTitulo" runat="server" Text="Transacciones"></asp:Label></h3>
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
    <div class="row" style="margin:5px;">
        <div class="col-md-4 tile_count" style="border-left:2px solid #73879c;border-right:2px solid #73879c;">
        <div class="tile_stats_count" style="text-align:center;">
            <span class="count_top"><i class="fa fa-list-ol"></i> <asp:Label ID="lblTotalTrasn" runat="server" Text=" Número de Vuelos" Font-Bold="false"></asp:Label></span>
            <div class="count"><asp:Label ID="lblTotalTrasnRes" runat="server" Font-Bold="true" CssClass="count"></asp:Label></div>
        </div>
        </div>
        <div class="col-md-4 tile_count" style="border-right:2px solid #73879c;">
        <div class="tile_stats_count" style="text-align:center;">
            <span class="count_top"><i class="fa fa-money"></i> <asp:Label ID="lblTotal" runat="server" Text=" Pagos" Font-Bold="false"></asp:Label></span>
            <div class="count"><asp:Label ID="lblTotalRes" runat="server" Font-Bold="true" CssClass="count" /></div>
        </div>
        </div>
        <div class="col-md-4 tile_count" style="border-right:2px solid #73879c;">
        <div class="tile_stats_count" style="text-align:center;">
            <span class="count_top"><i class="fa fa-bar-chart"></i> <asp:Label ID="lblPromedio" runat="server" Text=" Gastos" Font-Bold="false"></asp:Label></span>
            <div class="count"><asp:Label ID="lblPromedioRes" runat="server" Font-Bold="true" CssClass="count" /></div>
        </div>
        </div>
        <%--<div class="col-md-3 tile_count" style="border-right:2px solid #73879c;">
        <div class="tile_stats_count" style="text-align:center;">
            <span class="count_top"><i class="fa fa-plane"></i><asp:Label ID="lblGastosOperacion" runat="server" Text=" Gastos de Operación" Font-Bold="false"></asp:Label></span>
            <div class="count"><asp:Label ID="lblMXNUSDtres" runat="server" Text=" $" Font-Bold="true" CssClass="count" /> <asp:Label ID="lblGastosOperacionRes" runat="server" Text=" 2500" Font-Bold="true" CssClass="count"></asp:Label></div>
        </div>
        </div>--%>
    </div>
    <div class="row">
       <div class="col-md-12 col-sm-12">
        <div class="x_panel" style="min-height: 55vh;">
            <div class="x_title">
                <h2><asp:Label ID="lblTransacciones" runat="server" Text="Transacciones" Font-Bold="true"></asp:Label></h2>
                
                <ul class="nav navbar-right panel_toolbox">
                    <%--<li>
                        <asp:dropdownlist runat="server" id="ddlMeses" CssClass="form-control"> 
                             <asp:listitem text="Intervalo de:" value=""></asp:listitem>
                             <asp:listitem text="Último mes" value="1mes"></asp:listitem>
                             <asp:listitem text="Últimos 3 meses" value="2mes"></asp:listitem>
                             <asp:listitem text="Últimos 6 meses" value="3mes"></asp:listitem>
                             <asp:listitem text="Último año" value="12meses"></asp:listitem>
                        </asp:dropdownlist>
                    </li>
                    <li>
                        <asp:dropdownlist runat="server" id="ddlColumnas" CssClass="form-control"> 
                             <asp:listitem text="Columnas" value=""></asp:listitem>
                             <asp:listitem text="Opción 1" value="op1"></asp:listitem>
                             <asp:listitem text="Opción 2" value="op2"></asp:listitem>
                             <asp:listitem text="Opción 3" value="op3"></asp:listitem>
                             <asp:listitem text="Opción 4" value="op4"></asp:listitem>
                        </asp:dropdownlist>
                    </li>--%>
                    <li style="padding-left:5px;">
                        <asp:LinkButton ID="btnExcel" runat="server" Text="<i class='fa fa-file-excel-o' style='color:#ffffff;font-size:22px;'></i>" CssClass="btn btn-primary" OnClick="btnExcel_Click"/>
                    </li>
                    <li>
                        <asp:LinkButton ID="btnPDF" runat="server" Text="<i class='fa fa-file-pdf-o' style='color:#ffffff;font-size:22px;'></i>" CssClass="btn btn-primary" OnClick="btnPDF_Click"/>
                    </li>
                    <%--<li>
                        <a class="collapse-link"><i class="fa fa-chevron-up"></i></a>
                    </li>
                    <li>
                        <a class="close-link"><i class="fa fa-close"></i></a>
                    </li>--%>
                </ul>
                <div class="clearfix"></div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <%--<div class="table-responsive">
                            <div class="card-box table-responsive">
                                <asp:GridView ID="gvGastos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover"
                                    OnPageIndexChanging="gvGastos_PageIndexChanging" OnRowDataBound="gvGastos_RowDataBound" EmptyDataText="No Registros">
                                    <Columns>
                                        <asp:TemplateField ItemStyle-Width="20px">
                                            <ItemTemplate>
                                                <a href="JavaScript:divexpandcollapse('div<%# Eval("mes") %>');">
                                                    <img id="imgdiv<%# Eval("mes") %>" width="14px;" border="0" src="../Images/icons/flecha_abre1.png" />
                                                </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="mes" />
                                        <asp:BoundField DataField="mes" HeaderText="Año" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <tr id="div<%# Eval("mes") %>">
                                                    <td>
                                                        <asp:GridView ID="gvGastosDetalle" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover"
                                                            OnRowDataBound="gvGastos_RowDataBound" EmptyDataText="No Registros">
                                                            <Columns>
                                                                
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>--%>
                    <div class="table-responsive">
                        <div class="card-box table-responsive">
                            <asp:GridView ID="gvGastos" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover" AllowPaging="true"
                                OnPageIndexChanging="gvGastos_PageIndexChanging" OnRowDataBound="gvGastos_RowDataBound" EmptyDataText="No Registros">
                                <Columns>
                                    <asp:BoundField DataField="mes" />
                                    <asp:BoundField DataField="idRubro" />
                                    <asp:BoundField DataField="Rubro" />
                                    <asp:TemplateField HeaderText="Total" ItemStyle-HorizontalAlign="Right">
                                        <ItemTemplate>
                                            <asp:Label runat="server" ID="lblTotal" Text='<%# String.Format("{0:C}",DataBinder.Eval(Container.DataItem,"Total"))%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:BoundField DataField="Total" DataFormatString="{0:c}" />--%>
                                    <asp:BoundField DataField="Fecha" />
                                    <asp:BoundField DataField="Categoria" />
                                    <asp:BoundField DataField="tipodeGasto" />
                                    <asp:BoundField DataField="comentarios" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                
            </div>
            <hr style="border:1px solid #efefef;" />
            <div style="width:100%; text-align:center;">
                <asp:LinkButton ID="btnRegresar" runat="server" Text="<i class='fa fa-undo' style='color:#ffffff;font-size:14px;'></i> Dashboard <i class='fa fa-th-large' style='color:#ffffff;font-size:14px;'></i>" CssClass="btn btn-primary" href="frmDashboard.aspx" />
            </div>
        </div>
    </div>
    </div>
</asp:Content>
