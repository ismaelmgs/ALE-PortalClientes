using PortalClientes.Objetos;
using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using PortalClientes.Presenter;
using PortalClientes.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Web.Script.Services;
using System.Globalization;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using NucleoBase.Core;

namespace PortalClientes.Views
{
    public partial class frmMetricasEstadisticas : System.Web.UI.Page, IViewMetricasEstadisticas
    {
        #region EVENTOS
        protected void Page_Load(object sender, EventArgs e)
        {

            if (System.Web.HttpContext.Current.Session["UserIdentity"] == null)
            {
                Response.Redirect("~/Views/frmFinconexion2.aspx");
            }

            oPresenter = new MetricasEstadisticas_Presenter(this, new DBMetricasEstatics());

            TextBox milabel = (TextBox)this.Master.FindControl("txtLang");
            if (milabel.Text != Utils.Idioma && milabel.Text != string.Empty)
            {
                Utils.Idioma = milabel.Text;
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmarMetricasEstadisticas();
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmarMetricasEstadisticas();
            }

            if (!IsPostBack)
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "openLoading();", true);
                LlenarMetricasEstadisticas();
            }
        }

        protected void lkbExpExcel_Click(object sender, EventArgs e)
        {
            GeneraReportes(2);
        }
        protected void lkbExpPDF_Click(object sender, EventArgs e)
        {
            GeneraReportes(1);
        }

        protected void lkbExpPDFRes_Click(object sender, EventArgs e)
        {
            GeneraRepResumen(1);
        }

        protected void lkbExpExcelRes_Click(object sender, EventArgs e)
        {
            GeneraRepResumen(2);
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (eSearchObj != null)
                    eSearchObj(null, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region METODOS

        public void LlenarMetricasEstadisticas()
        {
            if (eSearchObj != null)
                eSearchObj(null, EventArgs.Empty);
        }

        private void ArmarMetricasEstadisticas()
        {
            //txtBusqueda.Attributes.Add("placeholder", Properties.Resources.Cm_Buscador);

            lbltitulometricasEstadisticas.Text = Properties.Resources.ME_Titulo;
            lblResumenPeriodo.Text = Properties.Resources.ME_ResumeenPeriodo;
            lblResumenPeriodoMXN.Text = Properties.Resources.ME_ResumeenPeriodoMXN;
            btnFiltrarMetricasEstadisticas.Text = Properties.Resources.ME_Filtrar;
            lblGastoTotalFijo.Text = Properties.Resources.Me_GastoTotalFijo;
            lblGastoTotalFijoMXN.Text = Properties.Resources.Me_GastoTotalFijo;
            lblGastoTotalVariable.Text = Properties.Resources.ME_GastoTotalVariable;
            lblGastoTotalVariableMXN.Text = Properties.Resources.ME_GastoTotalVariable;
            lblCostoHora.Text = Properties.Resources.ME_CostoHora;
            lblCostoHoraMXN.Text = Properties.Resources.ME_CostoHora;
            lblCostoMilla.Text = Properties.Resources.ME_CostoMilla;
            lblCostoMillaMXN.Text = Properties.Resources.ME_CostoMilla;
            lblNumeroVuelos.Text = Properties.Resources.ME_NumeroVuelos;
            lblHorasVoladas.Text = Properties.Resources.ME_HorasVoladas;
            lblPromedioDePasajeros.Text = Properties.Resources.ME_NumeroPasajeros;
            lblPeriodoVuelo.Text = Properties.Resources.ME_PeriodoVuelo;
            lblTiempoPromedio.Text = Properties.Resources.ME_TiempoPromedio;
            lblDistanciaPromedio.Text = Properties.Resources.ME_DistanciaPromedio;
            lblPromedioPasajeros.Text = Properties.Resources.ME_PromedioPasajeros;
            lblCostoPromedioMXN.Text = Properties.Resources.ME_CostoPromedioMXN;
            lblCostoPromedioUSD.Text = Properties.Resources.ME_CostoPromedioUSD;
            lblCostosCat.Text = Properties.Resources.ME_CostoCat;
            lblReportes.Text = Properties.Resources.ME_Reportes;
            lblprovaero.Text = Properties.Resources.ME_ProveedorAeropuerto;
            lblDuracionVuelos.Text = Properties.Resources.ME_DuracionVuelos;

            lblInformacionGeneral.Text = Properties.Resources.ME_InfoGeneral;
            //lblDescripcion.Text = Properties.Resources.ME_TabDocDescripcion;
            //lblDescargar.Text = Properties.Resources.ME_TabDocDescarga;
            lblResumenGastos.Text = Properties.Resources.ME_TabDocResumenGastos;
            lblRepDetGastos.Text = Properties.Resources.Me_TabDocDetGastos;

            lblPRomedioCosto.Text = Properties.Resources.ME_PromedioCosto;
            lblPromedioPasajerosDos.Text = Properties.Resources.ME_PromedioPax;
            lblHorasVuelo.Text = Properties.Resources.ME_HorasVuelo;
            lblNumVuelos.Text = Properties.Resources.ME_NoVuelos;
            //lblCostoPaxMilla.Text = Properties.Resources.ME_CostoPaxMilla;
            //lblCoatoMilla.Text = Properties.Resources.ME_CostoMilla;
            lblGastoHora.Text = Properties.Resources.ME_CostoHora;
            lblGastoTotal.Text = Properties.Resources.ME_GastoTotal;
            lblCostoFijoVariableHora.Text = Properties.Resources.ME_CostoFijoVariableHora;
            lblCostoFijoVariable.Text = Properties.Resources.ME_CostoFIjoVariable;

            lblTopRutas.Text = Properties.Resources.ME_PnlRutas;
            lblTopAeropuertos.Text = Properties.Resources.ME_PnlAeropuertos;

            lbTitleMapA.InnerText = Properties.Resources.ME_PnlAeropuertos;
            lbTitleMapR.InnerText = Properties.Resources.ME_PnlRutas;

            lblMapRutaAeroPrinc.Text = Properties.Resources.ME_TituloRutaAero;
            lblCategoriasLargoTiempo.Text = Properties.Resources.ME_TituloCatLT;

            var vPeriodo = ddlPeriodo.SelectedValue;
            // llenar dropdown Periodo
            ddlPeriodo.Items.Clear();
            ddlPeriodo.Items.Add(new ListItem(Properties.Resources.Das_Manual, "0"));
            ddlPeriodo.Items.Add(new ListItem(Properties.Resources.Das_Mensual, "1"));
            ddlPeriodo.Items.Add(new ListItem(Properties.Resources.Das_Trimestral, "3"));
            ddlPeriodo.Items.Add(new ListItem(Properties.Resources.Das_Semestral, "6"));
            ddlPeriodo.Items.Add(new ListItem(Properties.Resources.Das_Anual, "12"));

            if (vPeriodo == "")
            {
                ddlPeriodo.SelectedIndex = 3;
            }
            else
            {
                ddlPeriodo.SelectedValue = vPeriodo;
            }

            var vTR = ddlTipoRubro.SelectedValue;
            // llenar dropdown Tipo Rubro
            ddlTipoRubro.Items.Clear();
            ddlTipoRubro.Items.Add(new ListItem(Properties.Resources.Das_Fijo, "1"));
            ddlTipoRubro.Items.Add(new ListItem(Properties.Resources.Das_Variable, "2"));
            ddlTipoRubro.Items.Add(new ListItem(Properties.Resources.Das_Todos, "3"));

            if (vPeriodo == "")
            {
                ddlTipoRubro.SelectedIndex = 2;
            }
            else
            {
                ddlTipoRubro.SelectedValue = vTR;
            }

            var v = ddlFiltroResumenPeriodo.SelectedValue;
            // llenar dropdown filtro
            ddlFiltroResumenPeriodo.Items.Clear();
            ddlFiltroResumenPeriodo.Items.Add(new ListItem(Properties.Resources.FiltroME_MA, "0"));
            ddlFiltroResumenPeriodo.Items.Add(new ListItem(Properties.Resources.FiltroME_1M, "1"));
            ddlFiltroResumenPeriodo.Items.Add(new ListItem(Properties.Resources.FiltroME_2M, "2"));
            ddlFiltroResumenPeriodo.Items.Add(new ListItem(Properties.Resources.FiltroME_3M, "3"));

            if (v == "")
            {
                ddlFiltroResumenPeriodo.SelectedIndex = 0;
            }
            else
            {
                ddlFiltroResumenPeriodo.SelectedValue = v;
            }

            var v2 = DDFiltroMesesPA.SelectedValue;
            // llenar dropdown filtro
            DDFiltroMesesPA.Items.Clear();
            DDFiltroMesesPA.Items.Add(new ListItem(Properties.Resources.FiltroME_MA, "0"));
            DDFiltroMesesPA.Items.Add(new ListItem(Properties.Resources.FiltroME_1M, "1"));
            DDFiltroMesesPA.Items.Add(new ListItem(Properties.Resources.FiltroME_2M, "2"));
            DDFiltroMesesPA.Items.Add(new ListItem(Properties.Resources.FiltroME_3M, "3"));

            if (v2 == "")
            {
                DDFiltroMesesPA.SelectedIndex = 0;
            }
            else
            {
                DDFiltroMesesPA.SelectedValue = v2;
            }

            var v3 = DDFiltroMesesV.SelectedValue;
            // llenar dropdown filtro
            DDFiltroMesesV.Items.Clear();
            DDFiltroMesesV.Items.Add(new ListItem(Properties.Resources.FiltroME_MA, "0"));
            DDFiltroMesesV.Items.Add(new ListItem(Properties.Resources.FiltroME_1M, "1"));
            DDFiltroMesesV.Items.Add(new ListItem(Properties.Resources.FiltroME_2M, "2"));
            DDFiltroMesesV.Items.Add(new ListItem(Properties.Resources.FiltroME_3M, "3"));

            if (v3 == "")
            {
                DDFiltroMesesV.SelectedIndex = 0;
            }
            else
            {
                DDFiltroMesesV.SelectedValue = v3;
            }

            var v4 = DDFiltroMesesHV.SelectedValue;
            // llenar dropdown filtro
            DDFiltroMesesHV.Items.Clear();
            DDFiltroMesesHV.Items.Add(new ListItem(Properties.Resources.FiltroME_3M, "3"));
            DDFiltroMesesHV.Items.Add(new ListItem(Properties.Resources.FiltroME_6M, "6"));
            DDFiltroMesesHV.Items.Add(new ListItem(Properties.Resources.FiltroME_12M, "12"));

            if (v4 == "")
            {
                DDFiltroMesesHV.SelectedIndex = 0;
            }
            else
            {
                DDFiltroMesesHV.SelectedValue = v4;
            }

            var v5 = DDFiltroMesesNV.SelectedValue;
            // llenar dropdown filtro
            DDFiltroMesesNV.Items.Clear();
            DDFiltroMesesNV.Items.Add(new ListItem(Properties.Resources.FiltroME_3M, "3"));
            DDFiltroMesesNV.Items.Add(new ListItem(Properties.Resources.FiltroME_6M, "6"));
            DDFiltroMesesNV.Items.Add(new ListItem(Properties.Resources.FiltroME_12M, "12"));

            if (v5 == "")
            {
                DDFiltroMesesNV.SelectedIndex = 0;
            }
            else
            {
                DDFiltroMesesNV.SelectedValue = v5;
            }

            var v6= DDFiltroMesesPC.SelectedValue;
            // llenar dropdown filtro
            DDFiltroMesesPC.Items.Clear();
            DDFiltroMesesPC.Items.Add(new ListItem(Properties.Resources.FiltroME_3M, "3"));
            DDFiltroMesesPC.Items.Add(new ListItem(Properties.Resources.FiltroME_6M, "6"));
            DDFiltroMesesPC.Items.Add(new ListItem(Properties.Resources.FiltroME_12M, "12"));

            if (v6 == "")
            {
                DDFiltroMesesPC.SelectedIndex = 0;
            }
            else
            {
                DDFiltroMesesPC.SelectedValue = v6;
            }

            var v7 = DDFiltroMesesPP.SelectedValue;
            // llenar dropdown filtro
            DDFiltroMesesPP.Items.Clear();
            DDFiltroMesesPP.Items.Add(new ListItem(Properties.Resources.FiltroME_3M, "3"));
            DDFiltroMesesPP.Items.Add(new ListItem(Properties.Resources.FiltroME_6M, "6"));
            DDFiltroMesesPP.Items.Add(new ListItem(Properties.Resources.FiltroME_12M, "12"));

            if (v7 == "")
            {
                DDFiltroMesesPP.SelectedIndex = 0;
            }
            else
            {
                DDFiltroMesesPP.SelectedValue = v6;
            }

            var v8 = DDFiltroMesesFV.SelectedValue;
            // llenar dropdown filtro
            DDFiltroMesesFV.Items.Clear();
            DDFiltroMesesFV.Items.Add(new ListItem(Properties.Resources.FiltroME_MA, "0"));
            DDFiltroMesesFV.Items.Add(new ListItem(Properties.Resources.FiltroME_1M, "1"));
            DDFiltroMesesFV.Items.Add(new ListItem(Properties.Resources.FiltroME_2M, "2"));
            DDFiltroMesesFV.Items.Add(new ListItem(Properties.Resources.FiltroME_3M, "3"));

            if (v8 == "")
            {
                DDFiltroMesesFV.SelectedIndex = 0;
            }
            else
            {
                DDFiltroMesesFV.SelectedValue = v8;
            }

            var v9 = DDFiltroMesesGT.SelectedValue;
            // llenar dropdown filtro
            DDFiltroMesesGT.Items.Clear();
            DDFiltroMesesGT.Items.Add(new ListItem(Properties.Resources.FiltroME_3M, "3"));
            DDFiltroMesesGT.Items.Add(new ListItem(Properties.Resources.FiltroME_6M, "6"));
            DDFiltroMesesGT.Items.Add(new ListItem(Properties.Resources.FiltroME_12M, "12"));

            if (v9 == "")
            {
                DDFiltroMesesGT.SelectedIndex = 0;
            }
            else
            {
                DDFiltroMesesGT.SelectedValue = v9;
            }

            var v10 = DDFiltroMesesCH.SelectedValue;
            // llenar dropdown filtro
            DDFiltroMesesCH.Items.Clear();
            DDFiltroMesesCH.Items.Add(new ListItem(Properties.Resources.FiltroME_3M, "3"));
            DDFiltroMesesCH.Items.Add(new ListItem(Properties.Resources.FiltroME_6M, "6"));
            DDFiltroMesesCH.Items.Add(new ListItem(Properties.Resources.FiltroME_12M, "12"));

            if (v10 == "")
            {
                DDFiltroMesesCH.SelectedIndex = 0;
            }
            else
            {
                DDFiltroMesesCH.SelectedValue = v10;
            }

            var v11 = DDFiltroMesesFV.SelectedValue;
            // llenar dropdown filtro
            DDFiltroMesesFVH.Items.Clear();
            DDFiltroMesesFVH.Items.Add(new ListItem(Properties.Resources.FiltroME_MA, "0"));
            DDFiltroMesesFVH.Items.Add(new ListItem(Properties.Resources.FiltroME_1M, "1"));
            DDFiltroMesesFVH.Items.Add(new ListItem(Properties.Resources.FiltroME_2M, "2"));
            DDFiltroMesesFVH.Items.Add(new ListItem(Properties.Resources.FiltroME_3M, "3"));

            if (v11 == "")
            {
                DDFiltroMesesFVH.SelectedIndex = 0;
            }
            else
            {
                DDFiltroMesesFVH.SelectedValue = v11;
            }

            var v12 = ddlCategoriasLT.SelectedValue;
            // llenar dropdown filtro
            ddlCategoriasLT.Items.Clear();
            ddlCategoriasLT.Items.Add(new ListItem(Properties.Resources.FiltroME_12M, "12"));
            ddlCategoriasLT.Items.Add(new ListItem(Properties.Resources.FiltroME_6M, "6"));
            ddlCategoriasLT.Items.Add(new ListItem(Properties.Resources.FiltroME_3M, "3"));

            if (v12 == "")
            {
                ddlCategoriasLT.SelectedIndex = 0;
            }
            else
            {
                ddlCategoriasLT.SelectedValue = v12;
            }

            var v13 = ddlFiltroMesesRA.SelectedValue;
            // llenar dropdown filtro
            ddlFiltroMesesRA.Items.Clear();
            ddlFiltroMesesRA.Items.Add(new ListItem(Properties.Resources.FiltroME_3M, "3"));
            ddlFiltroMesesRA.Items.Add(new ListItem(Properties.Resources.FiltroME_6M, "6"));
            ddlFiltroMesesRA.Items.Add(new ListItem(Properties.Resources.FiltroME_12M, "12"));

            if (v13 == "")
            {
                ddlFiltroMesesRA.SelectedIndex = 0;
            }
            else
            {
                ddlFiltroMesesRA.SelectedValue = v13;
            }

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "closeLoading();", true);
        }

        public void GeneraRepResumen(int iTipoReporte)
        {
            DataSet dsGastos = new DataSet();
            DBMetricasEstatics oIGesCat = new DBMetricasEstatics();

            FiltroGraficaGastos fg = new FiltroGraficaGastos();
            fg.meses = ddlPeriodo.SelectedValue;

            if (txtFechaInicioGrafica.Text != "")
                fg.fechaInicial = DateTime.Parse(txtFechaInicioGrafica.Text);
            else
                fg.fechaInicial = null;
            if (txtFechaFinGrafica.Text != "")
                fg.fechaFinal = DateTime.Parse(txtFechaFinGrafica.Text);
            else
                fg.fechaFinal = null;
            fg.rubro = 5; // modificar despues
            fg.tipoRubro = int.Parse(ddlTipoRubro.SelectedValue);

            List<responseGraficaGastos> lrg = new List<responseGraficaGastos>();
            lrg = oIGesCat.ObtenerGastos(fg);

            dsGastos = ObtieneResumenGastosT(lrg);

            #region
            DataTable dtFiltros = new DataTable();
            DataColumn column;
            DataRow row;
            column = new DataColumn();
            column.ColumnName = "Periodo";
            dtFiltros.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "Tipo";
            dtFiltros.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "Idioma";
            dtFiltros.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "Fecha";
            dtFiltros.Columns.Add(column);

            row = dtFiltros.NewRow();
            row["Periodo"] = ddlPeriodo.SelectedItem.Text;
            row["Tipo"] = ddlTipoRubro.SelectedItem.Text;
            if (Utils.Idioma == "es-MX")
                row["Idioma"] = "MX";
            else
                row["Idioma"] = "US";

            DateTime dt = new DateTime();
            dt = DateTime.Now;
            string strFecha = string.Empty;
            if (Utils.Idioma == "es-MX")
                strFecha = dt.ToLongDateString().ToString(CultureInfo.CreateSpecificCulture("es-MX"));
            else
                strFecha = DevuelveFechaIngles(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            row["Fecha"] = strFecha;
            dtFiltros.Rows.Add(row);
            dtFiltros.TableName = "Filtros";
            #endregion

            dsGastos.Tables.Add(dtFiltros);

            string strPath = string.Empty;
            ReportDocument rd = new ReportDocument();
            strPath = Server.MapPath("RPT\\rptResumenGastos.rpt");
            strPath = strPath.Replace("\\Views", "");
            rd.Load(strPath, OpenReportMethod.OpenReportByDefault);
            rd.SetDataSource(dsGastos);

            if (iTipoReporte == 1)
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "ResumenGastos");
            else
                rd.ExportToHttpResponse(ExportFormatType.Excel, Response, true, "ResumenGastos");

        }

        public void GeneraReportes(int iTipoReporte)
        {
            DataSet dsGastos = new DataSet();
            DBMetricasEstatics oIGesCat = new DBMetricasEstatics();

            FiltroGraficaGastos fg = new FiltroGraficaGastos();
            fg.meses = ddlPeriodo.SelectedValue;

            if (txtFechaInicioGrafica.Text != "")
                fg.fechaInicial = DateTime.Parse(txtFechaInicioGrafica.Text);
            else
                fg.fechaInicial = null;
            if (txtFechaFinGrafica.Text != "")
                fg.fechaFinal = DateTime.Parse(txtFechaFinGrafica.Text);
            else
                fg.fechaFinal = null;
            fg.rubro = 5; // modificar despues
            fg.tipoRubro = int.Parse(ddlTipoRubro.SelectedValue);

            List<responseGraficaGastos> lrg = new List<responseGraficaGastos>();
            lrg = oIGesCat.ObtenerGastos(fg);

            dsGastos = ObtieneGastosTabla(lrg);

            #region
            DataTable dtFiltros = new DataTable();
            DataColumn column;
            DataRow row;
            column = new DataColumn();

            column.ColumnName = "Periodo";
            dtFiltros.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "Tipo";
            dtFiltros.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "Idioma";
            dtFiltros.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "Fecha";
            dtFiltros.Columns.Add(column);

            row = dtFiltros.NewRow();
            row["Periodo"] = ddlPeriodo.SelectedItem.Text;
            row["Tipo"] = ddlTipoRubro.SelectedItem.Text;
            if (Utils.Idioma == "es-MX")
                row["Idioma"] = "MX";
            else
                row["Idioma"] = "US";

            DateTime dt = new DateTime();
            dt = DateTime.Now;
            string strFecha = string.Empty;
            if (Utils.Idioma == "es-MX")
                strFecha = dt.ToLongDateString().ToString(CultureInfo.CreateSpecificCulture("es-MX"));
            else
                strFecha = DevuelveFechaIngles(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            row["Fecha"] = strFecha;
            dtFiltros.Rows.Add(row);
            dtFiltros.TableName = "Filtros";
            #endregion


            string strPath = string.Empty;
            ReportDocument rd = new ReportDocument();
            strPath = Server.MapPath("RPT\\rptDetalleGastos.rpt");
            strPath = strPath.Replace("\\Views", "");
            rd.Load(strPath, OpenReportMethod.OpenReportByDefault);
            rd.SetDataSource(dtFiltros);
            rd.Subreports["rptSUBGastosMXN.rpt"].SetDataSource(dsGastos.Tables[0]);
            rd.Subreports["rptSUBGastosUSD.rpt"].SetDataSource(dsGastos.Tables[1]);

            if (iTipoReporte == 1)
                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "DetalleGastos");
            else
                rd.ExportToHttpResponse(ExportFormatType.Excel, Response, true, "DetalleGastos");
        }

        protected void gvRutas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "openLoading();", true);
            gvRuta.PageIndex = e.NewPageIndex;
            LlenaGridRutas();
            settabHome();
        }

        private void LlenaGridRutas()
        {
            gvRuta.DataSource = oLstRutas;
            gvRuta.DataBind();
        }

        protected void gvRutas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = Properties.Resources.ME_TabRutasRuta;
            }
        }

        protected void gvAeropuertos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "openLoading();", true);
            gvAeropuerto.PageIndex = e.NewPageIndex;
            LlenaGridAeropuertos();
            settabProfile();
        }

        private void LlenaGridAeropuertos()
        {
            gvAeropuerto.DataSource = oLstAeropuertos;
            gvAeropuerto.DataBind();
        }

        protected void gvAeropuertos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = Properties.Resources.ME_TabAeropuertosClave;
                e.Row.Cells[1].Text = Properties.Resources.ME_TabAeropuertosAero;
            }
        }

        public void settabHome()
        {
            profiletab.Attributes["class"] = "nav-link";
            hometab.Attributes.Add("class", "nav-link active");

            profile.Attributes.Add("class", "tab-pane fade");
            home.Attributes.Add("class", "tab-pane fade show active");

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "closeLoading();", true);
        }

        public void settabProfile()
        {
            hometab.Attributes["class"] = "nav-link";
            profiletab.Attributes.Add("class", "nav-link active");

            home.Attributes.Add("class", "tab-pane fade");
            profile.Attributes.Add("class", "tab-pane fade show active");

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "closeLoading();", true);
        }

        public DataSet ObtieneGastosTabla(List<responseGraficaGastos> lrg)
        {
            DataSet dsGastos = new DataSet();
            double dbTotales = 0;
            string strTotalesMX = string.Empty;
            string strTotalesUS = string.Empty;
            #region
            DataTable dtGastosMXN = new DataTable();
            DataColumn column;
            DataRow row;
            column = new DataColumn();
            column.ColumnName = "Rubro";
            dtGastosMXN.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "TotalMXM";
            dtGastosMXN.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "TotalUSD";
            dtGastosMXN.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "Categoria";
            dtGastosMXN.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "Comentarios";
            dtGastosMXN.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "Fecha";
            dtGastosMXN.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "Mes";
            dtGastosMXN.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "RubroG";
            dtGastosMXN.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "TotalGMXN";
            dtGastosMXN.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "TotalGUSD";
            dtGastosMXN.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "Idioma";
            dtGastosMXN.Columns.Add(column);


            DataTable dtGastosUSD = new DataTable();
            DataColumn columnUSD;
            DataRow rowUSD;
            columnUSD = new DataColumn();
            columnUSD.ColumnName = "Rubro";
            dtGastosUSD.Columns.Add(columnUSD);

            columnUSD = new DataColumn();
            columnUSD.ColumnName = "TotalMXM";
            dtGastosUSD.Columns.Add(columnUSD);

            columnUSD = new DataColumn();
            columnUSD.ColumnName = "TotalUSD";
            dtGastosUSD.Columns.Add(columnUSD);

            columnUSD = new DataColumn();
            columnUSD.ColumnName = "Categoria";
            dtGastosUSD.Columns.Add(columnUSD);

            columnUSD = new DataColumn();
            columnUSD.ColumnName = "Comentarios";
            dtGastosUSD.Columns.Add(columnUSD);

            columnUSD = new DataColumn();
            columnUSD.ColumnName = "Fecha";
            dtGastosUSD.Columns.Add(columnUSD);

            columnUSD = new DataColumn();
            columnUSD.ColumnName = "Mes";
            dtGastosUSD.Columns.Add(columnUSD);

            columnUSD = new DataColumn();
            columnUSD.ColumnName = "RubroG";
            dtGastosUSD.Columns.Add(columnUSD);

            columnUSD = new DataColumn();
            columnUSD.ColumnName = "TotalGMXN";
            dtGastosUSD.Columns.Add(columnUSD);

            columnUSD = new DataColumn();
            columnUSD.ColumnName = "TotalGUSD";
            dtGastosUSD.Columns.Add(columnUSD);

            columnUSD = new DataColumn();
            columnUSD.ColumnName = "Idioma";
            dtGastosUSD.Columns.Add(columnUSD);

            #endregion

            foreach (responseGraficaGastos L in lrg)
            {
                foreach (gasto G in L.Gastos)
                {
                    if ((G.totalMXN > 0) && (G.totalUSD == 0))  //MXN
                    {
                        row = dtGastosMXN.NewRow();
                        strTotalesMX = L.totalMXN.ToString();
                        dbTotales = double.Parse(strTotalesMX);
                        strTotalesMX = dbTotales.ToString("c", CultureInfo.CreateSpecificCulture("es-MX"));
                        row["TotalMXM"] = strTotalesMX;
                        if (Utils.Idioma == "es-MX")
                        {
                            row["Rubro"] = L.rubroESP;
                            row["RubroG"] = G.rubroESP;
                            row["Idioma"] = "MX";
                        }
                        else
                        {
                            row["Rubro"] = L.rubroENG;
                            row["RubroG"] = G.rubroENG;
                            row["Idioma"] = "US";
                        }
                        row["Categoria"] = G.categoria;
                        row["Comentarios"] = G.comentarios;
                        row["Fecha"] = G.fecha;
                        row["Mes"] = G.mes;
                        strTotalesMX = G.totalMXN.ToString();
                        dbTotales = double.Parse(strTotalesMX);
                        strTotalesMX = dbTotales.ToString("c", CultureInfo.CreateSpecificCulture("es-MX"));
                        row["TotalGMXN"] = strTotalesMX;
                        dtGastosMXN.Rows.Add(row);
                    }
                    else
                    {
                        if ((G.totalMXN == 0) && (G.totalUSD > 0))  //USD
                        {
                            rowUSD = dtGastosUSD.NewRow();
                            strTotalesUS = L.totalUSD.ToString();
                            dbTotales = double.Parse(strTotalesUS);
                            strTotalesUS = dbTotales.ToString("c", CultureInfo.CreateSpecificCulture("es-MX"));
                            rowUSD["TotalUSD"] = strTotalesUS;
                            if (Utils.Idioma == "es-MX")
                            {
                                rowUSD["Rubro"] = L.rubroESP;
                                rowUSD["RubroG"] = G.rubroESP;
                                rowUSD["Idioma"] = "MX";
                            }
                            else
                            {
                                rowUSD["Rubro"] = L.rubroENG;
                                rowUSD["RubroG"] = G.rubroENG;
                                rowUSD["Idioma"] = "US";
                            }
                            rowUSD["Categoria"] = G.categoria;
                            rowUSD["Comentarios"] = G.comentarios;
                            rowUSD["Fecha"] = G.fecha;
                            rowUSD["Mes"] = G.mes;

                            strTotalesUS = G.totalUSD.ToString();
                            dbTotales = double.Parse(strTotalesUS);
                            strTotalesUS = dbTotales.ToString("c", CultureInfo.CreateSpecificCulture("es-MX"));

                            rowUSD["TotalGUSD"] = strTotalesUS;
                            dtGastosUSD.Rows.Add(rowUSD);
                        }
                    }
                }
            }
            dtGastosMXN.TableName = "MXN";
            dtGastosUSD.TableName = "USD";
            dsGastos.Tables.Add(dtGastosMXN);
            dsGastos.Tables.Add(dtGastosUSD);
            return dsGastos;
        }

        public DataSet ObtieneResumenGastosT(List<responseGraficaGastos> lrg)
        {
            double dbTotales = 0;
            double dbTMXN = 0;
            double dbTUSD = 0;
            string strTotales = string.Empty;
            string strT = string.Empty;
            DataSet dsRgastos = new DataSet();
            DataTable dtGastos = new DataTable();
            DataColumn column;
            DataRow row;
            column = new DataColumn();
            column.ColumnName = "Rubro";
            dtGastos.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "TotalMXM";
            dtGastos.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "TotalUSD";
            dtGastos.Columns.Add(column);

            column = new DataColumn();
            column.ColumnName = "Idioma";
            dtGastos.Columns.Add(column);


            DataTable dtTotales = new DataTable();
            DataColumn columnT;
            DataRow rowT;
            columnT = new DataColumn();
            columnT.ColumnName = "TMXN";
            dtTotales.Columns.Add(columnT);

            columnT = new DataColumn();
            columnT.ColumnName = "TUSD";
            dtTotales.Columns.Add(columnT);



            foreach (responseGraficaGastos L in lrg)
            {
                row = dtGastos.NewRow();


                strTotales = L.totalMXN.ToString();
                dbTotales = double.Parse(strTotales);
                dbTMXN += dbTotales;
                strTotales = dbTotales.ToString("c", CultureInfo.CreateSpecificCulture("es-MX"));
                row["TotalMXM"] = strTotales;

                strTotales = L.totalUSD.ToString();
                dbTotales = double.Parse(strTotales);
                dbTUSD += dbTotales;
                strTotales = dbTotales.ToString("c", CultureInfo.CreateSpecificCulture("es-MX"));
                row["TotalUSD"] = strTotales;

                if (Utils.Idioma == "es-MX")
                {
                    row["Rubro"] = L.rubroESP;
                    row["Idioma"] = "MX";
                }
                else
                {
                    row["Rubro"] = L.rubroENG;
                    row["Idioma"] = "US";
                }
                dtGastos.Rows.Add(row);
            }
            rowT = dtTotales.NewRow();
            strT = dbTMXN.ToString("c", CultureInfo.CreateSpecificCulture("es-MX"));
            rowT["TMXN"] = strT;
            strT = dbTUSD.ToString("c", CultureInfo.CreateSpecificCulture("es-MX"));
            rowT["TUSD"] = strT;
            dtTotales.Rows.Add(rowT);
            dtTotales.TableName = "TOTALES";

            dtGastos.TableName = "RESUMEN";
            dsRgastos.Tables.Add(dtGastos);
            dsRgastos.Tables.Add(dtTotales);
            return dsRgastos;
        }

        public string DevuelveFechaIngles(int iDia, int iMes, int iAnio)
        {
            string sFecha = string.Empty;
            string sDia = string.Empty;
            string sMes = string.Empty;

            switch (iDia)
            {
                case 1:
                    sDia = "1st";
                    break;
                case 2:
                    sDia = "2nd";
                    break;
                case 3:
                    sDia = "3rd";
                    break;
                case 4:
                    sDia = "4th";
                    break;
                default:
                    sDia = iDia.ToString() + "th";
                    break;
            }

            switch (iMes)
            {
                case 1:
                    sMes = "January";
                    break;
                case 2:
                    sMes = "February";
                    break;
                case 3:
                    sMes = "March";
                    break;
                case 4:
                    sMes = "April";
                    break;
                case 5:
                    sMes = "May";
                    break;
                case 6:
                    sMes = "June";
                    break;
                case 7:
                    sMes = "July";
                    break;
                case 8:
                    sMes = "August";
                    break;
                case 9:
                    sMes = "September";
                    break;
                case 10:
                    sMes = "October";
                    break;
                case 11:
                    sMes = "November";
                    break;
                case 12:
                    sMes = "December";
                    break;
            }

            sFecha = sMes + " " + sDia + ", " + iAnio.ToString();

            return sFecha;
        }

        [WebMethod]
        public static List<responseGraficaGastos> GetGastos(string meses, DateTime? fechaInicial, DateTime? fechaFinal, string rubro, int tipoRubro)
        {
            DBMetricasEstatics oIGesCat = new DBMetricasEstatics();

            FiltroGraficaGastos fg = new FiltroGraficaGastos();
            fg.meses = meses;
            fg.fechaInicial = fechaInicial;
            fg.fechaFinal = fechaFinal;
            fg.rubro = 5; // modificar despues
            fg.tipoRubro = tipoRubro;

            List<responseGraficaGastos> lrg = new List<responseGraficaGastos>();
            lrg = oIGesCat.ObtenerGastos(fg);

            if (lrg.Count() > 0)
            {
                lrg[0].idioma = Utils.Idioma;
            }

            return lrg;
        }

        [WebMethod]
        public static List<responseGraficaProveedores> GetGastosProveedor(string meses)
        {
            DBMetricasEstatics oIGesCat = new DBMetricasEstatics();

            FiltroGrafica fg = new FiltroGrafica();
            fg.meses = meses;

            List<responseGraficaProveedores> lrg = new List<responseGraficaProveedores>();
            lrg = oIGesCat.ObtenerGastosProveedor(fg);

            if (lrg.Count() > 0)
            {
                lrg[0].idioma = Utils.Idioma;
            }

            return lrg;
        }

        [WebMethod]
        public static List<responseGraficaAeropuerto> GetGastosAeropuerto(string meses)
        {
            DBMetricasEstatics oIGesCat = new DBMetricasEstatics();

            FiltroGrafica fg = new FiltroGrafica();
            fg.meses = meses;

            List<responseGraficaAeropuerto> lrg = new List<responseGraficaAeropuerto>();
            lrg = oIGesCat.ObtenerGastosAeropuerto(fg);

            if (lrg.Count() > 0)
            {
                lrg[0].idioma = Utils.Idioma;
            }

            return lrg;
        }

        [WebMethod]
        public static List<responseGraficaDuracionVuelos> GetDuracionVuelos(string meses)
        {
            DBMetricasEstatics oIGesCat = new DBMetricasEstatics();

            FiltroGrafica fg = new FiltroGrafica();
            fg.meses = meses;

            List<responseGraficaDuracionVuelos> lrg = new List<responseGraficaDuracionVuelos>();
            lrg = oIGesCat.ObtenerDuracionVuelos(fg);

            if (lrg.Count() > 0)
            {
                lrg[0].idioma = Utils.Idioma;
            }

            return lrg;
        }

        [WebMethod]
        public static List<responseGraficaHorasVoladas> GetHorasVoladas(string meses)
        {
            DBMetricasEstatics oIGesCat = new DBMetricasEstatics();

            FiltroGrafica fg = new FiltroGrafica();
            fg.meses = meses;

            List<responseGraficaHorasVoladas> lrg = new List<responseGraficaHorasVoladas>();
            lrg = oIGesCat.ObtenerHorasVoladas(fg);

            if (lrg.Count() > 0)
            {
                lrg[0].idioma = Utils.Idioma;
            }

            return lrg;
        }

        [WebMethod]
        public static List<responseGraficaNoVuelos> GetNoVuelos(string meses)
        {
            DBMetricasEstatics oIGesCat = new DBMetricasEstatics();

            FiltroGrafica fg = new FiltroGrafica();
            fg.meses = meses;

            List<responseGraficaNoVuelos> lrg = new List<responseGraficaNoVuelos>();
            lrg = oIGesCat.ObtenerNoVuelos(fg);

            if (lrg.Count() > 0)
            {
                lrg[0].idioma = Utils.Idioma;
            }

            return lrg;
        }

        [WebMethod]
        public static List<responseGraficaPromedioCostos> GetPromedioCostos(string meses)
        {
            DBMetricasEstatics oIGesCat = new DBMetricasEstatics();

            FiltroGrafica fg = new FiltroGrafica();
            fg.meses = meses;

            List<responseGraficaPromedioCostos> lrg = new List<responseGraficaPromedioCostos>();
            lrg = oIGesCat.ObtenerPromedioCostos(fg);

            if (lrg.Count() > 0)
            {
                lrg[0].idioma = Utils.Idioma;
            }

            return lrg;
        }

        [WebMethod]
        public static List<responseGraficaPromedioPasajero> GetPromedioPasajeros(string meses)
        {
            DBMetricasEstatics oIGesCat = new DBMetricasEstatics();

            FiltroGrafica fg = new FiltroGrafica();
            fg.meses = meses;

            List<responseGraficaPromedioPasajero> lrg = new List<responseGraficaPromedioPasajero>();
            lrg = oIGesCat.obtenerPromedioPasajero(fg);

            if (lrg.Count() > 0)
            {
                lrg[0].idioma = Utils.Idioma;
            }

            return lrg;
        }

        [WebMethod]
        public static List<responseGraficaCostoFijoVariable> GetCostosFijoVariable(string meses)
        {
            DBMetricasEstatics oIGesCat = new DBMetricasEstatics();

            FiltroGraficaFV fg = new FiltroGraficaFV();
            fg.meses = meses;

            List<responseGraficaCostoFijoVariable> lrg = new List<responseGraficaCostoFijoVariable>();
            lrg = oIGesCat.obtenerCostosFijoVariable(fg);

            if (lrg.Count() > 0)
            {
                lrg[0].idioma = Utils.Idioma;
            }

            return lrg;
        }

        [WebMethod]
        public static List<responseGraficaGastoTotal> GetGastoTotales(string meses)
        {
            DBMetricasEstatics oIGesCat = new DBMetricasEstatics();

            FiltroGrafica fg = new FiltroGrafica();
            fg.meses = meses;

            List<responseGraficaGastoTotal> lrg = new List<responseGraficaGastoTotal>();
            lrg = oIGesCat.obtenerGastoTotal(fg);

            if (lrg.Count() > 0)
            {
                lrg[0].idioma = Utils.Idioma;
            }

            return lrg;
        }

        [WebMethod]
        public static List<responseGraficaCostoHoraVuelo> GetCostoHoraVuelo(string meses)
        {
            DBMetricasEstatics oIGesCat = new DBMetricasEstatics();

            FiltroGrafica fg = new FiltroGrafica();
            fg.meses = meses;

            List<responseGraficaCostoHoraVuelo> lrg = new List<responseGraficaCostoHoraVuelo>();
            lrg = oIGesCat.obtenerCostoHoraVuelo(fg);

            if (lrg.Count() > 0)
            {
                lrg[0].idioma = Utils.Idioma;
            }

            return lrg;
        }

        [WebMethod]
        public static List<responseGraficaCostoFijoVariableHora> GetCostoFijoVariableHora(string meses)
        {
            DBMetricasEstatics oIGesCat = new DBMetricasEstatics();

            FiltroGraficaFV fg = new FiltroGraficaFV();
            fg.meses = meses;

            List<responseGraficaCostoFijoVariableHora> lrg = new List<responseGraficaCostoFijoVariableHora>();
            lrg = oIGesCat.obtenerCostoFijoVariableHora(fg);

            if (lrg.Count() > 0)
            {
                lrg[0].idioma = Utils.Idioma;
            }

            return lrg;
        }

        [WebMethod]
        public static dataGrafica GetCategoriasPeriodo(string meses)
        {
            DBMetricasEstatics oIGesCat = new DBMetricasEstatics();

            FiltroGraficaFV fg = new FiltroGraficaFV();
            fg.meses = meses;

            List<responseGraficaCategorias> lrg = new List<responseGraficaCategorias>();
            dataGrafica data = new dataGrafica();

            lrg = oIGesCat.obtenerCategoriasPeriodos(fg);

            var mesesL = lrg.Select(item => mesLetra(item.mes)).Distinct().ToArray();
            var mesesArray = lrg.Select(item => item.mes).Distinct().ToArray();
            var conceptos = lrg.Select(item => Utils.Idioma == "es-MX" ? item.rubroESP : item.rubroENG).Distinct().ToArray();

            data.datosM = new string[mesesArray.Count() + 1,conceptos.Count() + 1];
            data.datosU = new string[mesesArray.Count() + 1,conceptos.Count() + 1];

            data.datosM[0, 0] = Utils.Idioma == "es-MX" ? "MESES" : "MONTHS";
            data.datosU[0, 0] = Utils.Idioma == "es-MX" ? "MESES" : "MONTHS";

            var x = 1;
            foreach (var item in conceptos)
            {
                data.datosM[0, x] = item;
                data.datosU[0, x] = item;
                x++;
            }

            for (int i = 1; i < mesesL.Count(); i++)
            {
                data.datosM[i, 0] = mesesL[i-1];
                data.datosU[i, 0] = mesesL[i-1];

                var cont = 0;
                var elements = lrg.Where(z => z.mes == mesesArray[i-1]).ToList();
                foreach (var item in elements)
                {
                    if (item.rubroESP == conceptos[cont] || item.rubroENG == conceptos[cont])
                    {
                        data.datosM[i, cont + 1] = item.totalMXN.ToString();
                        data.datosU[i, cont + 1] = item.totalUSD.ToString();
                        cont++;
                    }
                }
            }

            if (lrg.Count() > 0)
            {
                data.idioma = Utils.Idioma;
            }

            data.response = lrg;
            data.conceptos = conceptos;

            return data;
        }

        private static string mesLetra(int mes)
        {
            var m = "";

            switch (mes)
            {
                case 1:
                    m = Utils.Idioma == "es-MX" ? "ENERO" : "JUNUARY";
                    break;
                case 2:
                    m = Utils.Idioma == "es-MX" ? "FEBRERO" : "FEBRUARY";
                    break;
                case 3:
                    m = Utils.Idioma == "es-MX" ? "MARZO" : "MARCH";
                    break;
                case 4:
                    m = Utils.Idioma == "es-MX" ? "ABRIL" : "APRIL";
                    break;
                case 5:
                    m = Utils.Idioma == "es-MX" ? "MAYO" : "MAY";
                    break;
                case 6:
                    m = Utils.Idioma == "es-MX" ? "JUNIO" : "JUNE";
                    break;
                case 7:
                    m = Utils.Idioma == "es-MX" ? "JULIO" : "JULY";
                    break;
                case 8:
                    m = Utils.Idioma == "es-MX" ? "AGOSTO" : "AUGUSTS";
                    break;
                case 9:
                    m = Utils.Idioma == "es-MX" ? "SEPTIEMBRE" : "EPTEMBRE";
                    break;
                case 10:
                    m = Utils.Idioma == "es-MX" ? "OCTUBRE" : "OCTOBER";
                    break;
                case 11:
                    m = Utils.Idioma == "es-MX" ? "NOVIEMBRE" : "NOVEMBER";
                    break;
                case 12:
                    m = Utils.Idioma == "es-MX" ? "DICIEMBRE" : "DECEMBER";
                    break;
            }

            return m;
        }

        [WebMethod]
        public static RutaAeropuerto GetRutasAeropuertos(int meses)
        {
            DBMetricasEstatics oIGesCat = new DBMetricasEstatics();

            FiltroEvent fg = new FiltroEvent();
            fg.meses = meses;

            RutaAeropuerto lrg = new RutaAeropuerto();
            lrg = oIGesCat.obtenerRutasAeropuertos(fg);

            return lrg;
        }

        public void CargarMetricasEstadisticas(DatosMetricas oME)
        {
            oMetEsta = oME;

            lblGastoTotalRes.Text = oMetEsta.GastoTotalFijoUSD.ToString("C", CultureInfo.CreateSpecificCulture("es-MX"));
            lblGastoTotalVariableRes.Text = oMetEsta.GastoTotalVarUSD.ToString("C", CultureInfo.CreateSpecificCulture("es-MX"));
            lblCostoHoraRes.Text = oMetEsta.CostoPorHoraUSD.ToString("C", CultureInfo.CreateSpecificCulture("es-MX"));
            lblCostoMillaRes.Text = oMetEsta.CostoPorMillaUSD.ToString("C", CultureInfo.CreateSpecificCulture("es-MX"));

            lblGastoTotalResMXN.Text = oMetEsta.GastoTotalFijoMXN.ToString("C", CultureInfo.CreateSpecificCulture("es-MX"));
            lblGastoTotalVariableMXNRes.Text = oMetEsta.GastoTotalVarMXN.ToString("C", CultureInfo.CreateSpecificCulture("es-MX"));
            lblCostoHoraMXNRes.Text = oMetEsta.CostoPorHoraMXN.ToString("C", CultureInfo.CreateSpecificCulture("es-MX"));
            lblCostoMillaMXNRes.Text = oMetEsta.CostoPorMillaMXN.ToString("C", CultureInfo.CreateSpecificCulture("es-MX"));

            lblNumeroVuelosRes.Text = oMetEsta.NumeroVuelos.ToString();
            lblHorasVoladasRes.Text = oMetEsta.HorasVoladas.ToString();
            lblPromedioDePasajerosRes.Text = oMetEsta.TotalPasajeros.ToString();


            lblTiempoPromedioRes.Text = oMetEsta.TiempoPromedio != null ? oMetEsta.TiempoPromedio.ToString() : "00:00";
            lblDistanciaPromedioRes.Text = oMetEsta.DistanciaPromedio.ToString();
            lblPromedioPasajerosRes.Text = oMetEsta.PaxPromedio.ToString();
            lblCostoPromedioRes.Text = oMetEsta.PromedioMXN.ToString("C", CultureInfo.CreateSpecificCulture("es-MX"));
            lblCostoPromedioUSDRes.Text = oMetEsta.PromedioUSD.ToString("C", CultureInfo.CreateSpecificCulture("es-MX"));

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "closeLoading();", true);

        }

        public void CargarRutasyAeropuertos(RutaAeropuerto ra)
        {
            var rutas = ra.rutaAeropuertoPeriodoA;
            var aeropuertos = ra.rutaAeropuertoPeriodoB;

            List<gvRutas> gvRutas = new List<gvRutas>();

            foreach(var item in rutas)
            {
                if (item.aorigenLatitud != null && item.aorigenLongitud != null && item.adestinoLatitud != null && item.adestinoLatitud != null)
                {
                    gvRutas gv = new gvRutas();
                    gv.rutas = item.origen + " - " + item.destino;

                    gvRutas.Add(gv);
                }
            }

            oLstRutas = gvRutas;
            gvRuta.DataSource = oLstRutas;
            gvRuta.DataBind();

            List<gvAeropuertos> gvAeropuertos = new List<gvAeropuertos>();

            foreach (var item in aeropuertos)
            {
                if(item.latitud != null && item.longitud != null)
                {
                    gvAeropuertos gv = new gvAeropuertos();
                    gv.clave = item.aeropuerto;
                    gv.aeropuerto = item.descripcion;

                    gvAeropuertos.Add(gv);
                }
            }

            oLstAeropuertos = gvAeropuertos;
            gvAeropuerto.DataSource = oLstAeropuertos;
            gvAeropuerto.DataBind();

            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), Guid.NewGuid().ToString(), "closeLoading();", true);
        }
        #endregion

        #region VARIABLES Y PROPIEDADES

        MetricasEstadisticas_Presenter oPresenter;
        public event EventHandler eSearchObj;
        public event EventHandler eNewObj;
        public event EventHandler eObjSelected;
        public event EventHandler eSaveObj;
        public event EventHandler eDeleteObj;

        public List<gvRutas> oLstRutas
        {
            get { return (List<gvRutas>)ViewState["VSRutas"]; }
            set { ViewState["VSRutas"] = value; }
        }

        public List<gvAeropuertos> oLstAeropuertos
        {
            get { return (List<gvAeropuertos>)ViewState["VSAeropuertos"]; }
            set { ViewState["VSAeropuertos"] = value; }
        }

        public int iMeses
        {
            get
            {
                return ddlFiltroResumenPeriodo.SelectedValue.S().I();
            }
        }

        public int iMesesMap
        {
            get
            {
                return ddlFiltroMesesRA.SelectedValue.S().I();
            }
        }

        public string sMatricula
        {
            get
            {
                return Utils.MatriculaActual;
            }
        }

        public DatosMetricas oMetEsta
        {
            get { return (DatosMetricas)ViewState["VSMetricasEstadisticas"]; }
            set { ViewState["VSMetricasEstadisticas"] = value; }
        }

        #endregion
    }
}