﻿using PortalClientes.Objetos;
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

namespace PortalClientes.Views
{
    public partial class frmMetricasEstadisticas : System.Web.UI.Page
    {
        #region EVENTOS
        protected void Page_Load(object sender, EventArgs e)
        {
            //oPresenter = new Dashboard_Presenter(this, new DBDashboard());

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
                //LlenarDashboard();
            }
        }

        protected void lkbExpPDF_Click(object sender, EventArgs e)
        {
            DataSet dsGastos = new DataSet();
            DBMetricasEstatics oIGesCat = new DBMetricasEstatics();
            //DateTime dtFechaI = new DateTime();
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
            //column.DataType = System.Type.GetType("System.Int32");
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
            if(Utils.Idioma == "es-MX")
                row["Idioma"] = "MX";
            else
                row["Idioma"] = "US";

            DateTime dt = new DateTime();
            dt = DateTime.Now;
            string strFecha = string.Empty;
            if (Utils.Idioma == "es-MX")
                strFecha = dt.ToLongDateString().ToString(CultureInfo.CreateSpecificCulture("es-MX"));
            else
                strFecha = dt.ToLongDateString().ToString(CultureInfo.CreateSpecificCulture("en-US"));
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

            rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "DetalleGastos");

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
                        strTotalesMX = L.totalMXN.ToString();//.Replace(',', '.');
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
                        row["TotalGMXN"] = G.totalMXN;
                        dtGastosMXN.Rows.Add(row);
                    }
                    else
                    {
                        if ((G.totalMXN == 0) && (G.totalUSD > 0))  //USD
                        {
                            rowUSD = dtGastosUSD.NewRow();
                            strTotalesUS = L.totalUSD.ToString().Replace(',', '.');
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
                            rowUSD["TotalGUSD"] = G.totalUSD;
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

            #endregion

            #region METODOS

            public void LlenarMetricasEstadisticas()
        {
            if (eSearchObj != null)
                eSearchObj(null, EventArgs.Empty);
        }

        private void ArmarMetricasEstadisticas()
        {
            txtBusqueda.Attributes.Add("placeholder", Properties.Resources.Cm_Buscador);

            lbltitulometricasEstadisticas.Text = Properties.Resources.ME_Titulo;
            lblResumenPeriodo.Text = Properties.Resources.ME_ResumeenPeriodo; ;
            lblfiltrar.Text = Properties.Resources.ME_Filtrar;
            lblGastoTotalFijo.Text = Properties.Resources.Me_GastoTotalFijo;
            lblGastoTotalVariable.Text = Properties.Resources.ME_GastoTotalVariable;
            lblCostoHora.Text = Properties.Resources.ME_CostoHora;
            lblCostoMilla.Text = Properties.Resources.ME_CostoMilla;
            lblNumeroVuelos.Text = Properties.Resources.ME_NumeroVuelos;
            lblHorasVoladas.Text = Properties.Resources.ME_HorasVoladas;
            lblPromedioDePasajeros.Text = Properties.Resources.ME_PromedioPasajeros;
            lblPeriodoVuelo.Text = Properties.Resources.ME_PeriodoVuelo;
            lblTiempoPromedio.Text = Properties.Resources.ME_TiempoPromedio;
            lblDistanciaPromedio.Text = Properties.Resources.ME_DistanciaPromedio;
            lblPromedioPasajeros.Text = Properties.Resources.ME_PromedioPasajeros;
            lblCostoPromedio.Text = Properties.Resources.ME_CostoPromedio;
            lblCostosCat.Text = Properties.Resources.ME_CostoCat;
            lblReportes.Text = Properties.Resources.ME_Reportes;

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

            //lblCostosCat.Text = Properties.Resources.Das_CostoCategoria;
        }

        [WebMethod]
        public static List<responseGraficaGastos> GetGastos(string meses, DateTime? fechaInicial, DateTime? fechaFinal, string rubro, int tipoRubro)
        {
            DBDashboard oIGesCat = new DBDashboard();

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
        #endregion

        #region VARIABLES Y PROPIEDADES

        public event EventHandler eSearchObj;

        #endregion
    }
}