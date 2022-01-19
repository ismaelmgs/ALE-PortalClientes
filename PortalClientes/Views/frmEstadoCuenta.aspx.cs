using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using PortalClientes.Presenter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalClientes.Clases;
using PortalClientes.Objetos;
using NucleoBase.Core;
using System.Drawing;
using System.Data;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Newtonsoft.Json;

namespace PortalClientes.Views
{
    public partial class frmEstadoCuenta : System.Web.UI.Page, IViewEstadoCuenta
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["RefUrl"] = Request.Url.ToString();
            if (System.Web.HttpContext.Current.Session["UserIdentity"] == null)
            {
                Response.Redirect("~/Views/frmFinconexion2.aspx");
            }

            oPresenter = new EstadoCuenta_Presenter(this, new DBEstadoCuenta());

            TextBox milabel = (TextBox)this.Master.FindControl("txtLang");
            if (milabel.Text != Utils.Idioma && milabel.Text != string.Empty)
            {
                Utils.Idioma = milabel.Text;
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmarEstadoCuenta();
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmarEstadoCuenta();
            }

            if (!IsPostBack)
            {
                if (eSearchObj != null)
                    eSearchObj(sender, e);
            }

            EdoCuenta = new DataSet();

            
        }

        protected void gvEdoCuenta_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                responseRepEdoCuenta doc = (responseRepEdoCuenta)e.Row.DataItem;
                var existeDoc = doc != null ? doc.docF : 0;

                if (e.Row.RowType == DataControlRowType.Header)
                {
                    e.Row.Cells[0].Text = Properties.Resources.Ec_NombreMes;

                    e.Row.Cells[1].Text = Properties.Resources.Ec_SaldoAnteriorMXN;
                    e.Row.Cells[2].Text = Properties.Resources.Ec_PagosCreditosMXN;
                    e.Row.Cells[3].Text = Properties.Resources.Ec_NuevosCargosMXN;
                    e.Row.Cells[4].Text = Properties.Resources.Ec_SaldoActualMXN;

                    e.Row.Cells[5].Text = Properties.Resources.Ec_SaldoAnteriosUSD;
                    e.Row.Cells[6].Text = Properties.Resources.Ec_PagosCreditosUSD;
                    e.Row.Cells[7].Text = Properties.Resources.Ec_NuevosCargosUSD;
                    e.Row.Cells[8].Text = Properties.Resources.Ec_SaldoActualUSD;
                    e.Row.Cells[9].Text = Properties.Resources.Ec_VerFacturaTitle;
                    e.Row.Cells[10].Text = Properties.Resources.Ec_VerDetalleTitle;
                }

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lkb = (LinkButton)e.Row.FindControl("lkbDetalle");
                    lkb.Text = Properties.Resources.Ec_VerDetalle;

                    ImageButton lkbvd = (ImageButton)e.Row.FindControl("lkbViewDocument");

                    if (existeDoc == 0) //cambiar a ==0
                    {
                        lkbvd.Visible = false;
                    }
                    else
                    {
                        lkbvd.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gvEdoCuenta_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            sMes = gvEdoCuenta.DataKeys[e.CommandArgument.S().I()]["nombreMes"].S();
            ObtienePeriodoEdoCuentaI(sMes);

            if (e.CommandName == "Detalle")
            {
                Session["tipoTransaccion"] = 13;
                Session["origenData"] = 3;
                
                responseRepEdoCuenta oEC = (responseRepEdoCuenta) oEstados.Where(x => x.mes == iMes).FirstOrDefault();
                if (oEC != null)
                {
                    Session["descripcion"] = ObtienePeriodoEdoCuenta(oEC.mes, oEC.anio);
                    Session["data"] = oEC.olsDetalle;
                    Response.Redirect("frmTransacciones.aspx");
                }
            }

            if(e.CommandName == "ViewDocument")
            {
                responseRepEdoCuenta oEC = (responseRepEdoCuenta)oEstados.Where(x => x.mes == iMes).FirstOrDefault();
                iAnio = oEC.anio;

                if (eSearchObjDocs != null)
                    eSearchObjDocs(sender, e);

                upaDocsEdoCuenta.Update();
                mpeDocsEdoCuenta.Show();
            }

            if (e.CommandName == "Reporte")
            {
                if (eSearchEdoObj != null)
                    eSearchEdoObj(sender, e);

                string strPath = string.Empty;
                ReportDocument rd = new ReportDocument();
                strPath = Server.MapPath("RPT\\rptEstadoCuenta.rpt");
                strPath = strPath.Replace("\\Views", "");
                rd.Load(strPath, OpenReportMethod.OpenReportByDefault);
                rd.SetDataSource(EdoCuenta.Tables[0]);

                rd.Subreports["rptSubEdoCuentaUSD.rpt"].SetDataSource(EdoCuenta.Tables[1]);
                rd.Subreports["rptSubEdocuentaMXN.rpt"].SetDataSource(EdoCuenta.Tables[2]);

                rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, "EstadoCuenta");
                Response.End();
            }
        }

        protected void gvDocEdoCuenta_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            var index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gvDocEdoCuenta.Rows[index];

            var path = "\\\\192.168.1.223/Archivos SAP/XML/INV/"; // \\192.168.1.223\Archivos SAP\XML\INV\2021\12\1

            // concatenar anio/mes/dia
            path += row.Cells[5].Text.S() + "/";
            path += row.Cells[6].Text.S() + "/";
            path += row.Cells[7].Text.S() + "/";

            if (e.CommandName == "DownloadPDF")
            {
                // concatenamos el nombre del archivo
                path += "FC" + row.Cells[3].Text.S() + ".pdf";

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "application/pdf";
                var nombre = Path.GetFileName(path).ToString();
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + nombre);
                HttpContext.Current.Response.TransmitFile(path);
                HttpContext.Current.Response.End();
            }

            if(e.CommandName == "DownloadXML")
            {
                // concatenamos el nombre del archivo
                path += "FC" + row.Cells[3].Text.S() + ".xml";

                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ContentType = "application/vnd.apple.installer+xml";
                var nombre = Path.GetFileName(path).ToString();
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=" + nombre);
                HttpContext.Current.Response.TransmitFile(path);
                HttpContext.Current.Response.End();
            }
        }

        protected void gvDocEdoCuenta_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Text = Properties.Resources.Ec_Clave;
                e.Row.Cells[1].Text = Properties.Resources.Ec_RazonSocial;
                e.Row.Cells[2].Text = Properties.Resources.Ec_TipoDocumento;
                e.Row.Cells[3].Text = Properties.Resources.Ec_Folio;
                e.Row.Cells[4].Text = Properties.Resources.Ec_FechaDoc;
                e.Row.Cells[5].Text = Properties.Resources.Ec_Anio;
                e.Row.Cells[6].Text = Properties.Resources.Ec_Mes;
                e.Row.Cells[7].Text = Properties.Resources.Ec_Dia;
                e.Row.Cells[8].Text = Properties.Resources.Ec_Download;
                e.Row.Cells[9].Text = Properties.Resources.Ec_DownloadXML;

                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[7].Visible = false;
            }

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ImageButton lkb = (ImageButton)e.Row.FindControl("lkbDownloadDoc");
                //lkb.Text = Properties.Resources.Ec_DownloadDoc;

                e.Row.Cells[5].Visible = false;
                e.Row.Cells[6].Visible = false;
                e.Row.Cells[7].Visible = false;
            }
        }

        #region METODOS
        private void ArmarEstadoCuenta()
        {
            lblTitulo.Text = Properties.Resources.Ec_Titulo;
            lblResumenDeCuenta.Text = Properties.Resources.Ec_ResumenCuenta;
            lblResumenPeriodo.Text = Properties.Resources.Ec_ResumenCuenta;
            lblSaldoActual.Text = Properties.Resources.Ec_SaldoActual;
            lblSaldoActualMXN.Text = Properties.Resources.Ec_SaldoActual;
            lblNuevosCargos.Text = Properties.Resources.Ec_NuevosCargos;
            lblNuevosCargosMXN.Text = Properties.Resources.Ec_NuevosCargos;
            lblPagosPeriodo.Text = Properties.Resources.Ec_PagosPeriodo;
            lblPagosPeriodoMXN.Text = Properties.Resources.Ec_PagosPeriodo;
            lblMontoReq.Text = Properties.Resources.Ec_PagoRequerido;
            lblMontoReqMXN.Text = Properties.Resources.Ec_PagoRequerido;

            btnCancelar.Text = Properties.Resources.Ec_btnCancelar;
            lblTituloDocsEdoCuenta.Text = Properties.Resources.Ec_FacturaEdoCuenta;
        }

        public void LlenaEstadoCuenta(EstadoCuenta oEstado)
        {
            lblSaldoActualRes.Text = string.Format("{0:###,###,###,0.##}", oEstado.saldoAnteriorUSD);
            lblNuevosCargosRes.Text = string.Format("{0:###,###,###,0.##}", oEstado.nuevosCargosUSD);
            lblPagosPeriodoRes.Text = string.Format("{0:###,###,###,0.##}", oEstado.pagosCreditosUSD);

            if (oEstado.saldoActalUSD < 0)
                lblMontoReqRes.ForeColor = Color.Green;
            if (oEstado.saldoActalUSD > 0)
                lblMontoReqRes.ForeColor = Color.Red;
            //if (oEstado.saldoActualUSD == 0)
            //    lblMontoReqRes.ForeColor = Color.Black;

            lblMontoReqRes.Text = string.Format("{0:###,###,###,0.##}", oEstado.saldoActalUSD);


            lblSaldoActualMXNRes.Text = string.Format("{0:###,###,###,0.##}", oEstado.saldoAnteriorMXN);
            lblNuevosCargosMXNRes.Text = string.Format("{0:###,###,###,0.##}", oEstado.nuevosCargosMXN);
            lblPagosPeriodoMXNRes.Text = string.Format("{0:###,###,###,0.##}", oEstado.pagosCreditosMXN);

            if (oEstado.saldoActalMXN < 0)
                lblMontoReqMXNRes.ForeColor = Color.Green;
            if(oEstado.saldoActalMXN > 0)
                lblMontoReqMXNRes.ForeColor = Color.Red;
            //if (oEstado.saldoActualMXN == 0)
            //    lblMontoReqMXNRes.ForeColor = Color.Black;

            lblMontoReqMXNRes.Text = string.Format("{0:###,###,###,0.##}", oEstado.saldoActalMXN);
            lblPeriodo.Text = ObtienePeriodoEdoCuenta(oEstado.mes, oEstado.anio);
        }

        private string ObtienePeriodoEdoCuenta(int iMes, int iAnio)
        {
            string Periodo = string.Empty;
            switch (iMes)
            {
                case 1:
                    Periodo = Properties.Resources.Cm_Enero;
                    break;
                case 2:
                    Periodo = Properties.Resources.Cm_Febrero;
                    break;
                case 3:
                    Periodo = Properties.Resources.Cm_Marzo;
                    break;
                case 4:
                    Periodo = Properties.Resources.Cm_Abril;
                    break;
                case 5:
                    Periodo = Properties.Resources.Cm_Mayo;
                    break;
                case 6:
                    Periodo = Properties.Resources.Cm_Junio;
                    break;
                case 7:
                    Periodo = Properties.Resources.Cm_Julio;
                    break;
                case 8:
                    Periodo = Properties.Resources.Cm_Agosto;
                    break;
                case 9:
                    Periodo = Properties.Resources.Cm_Septiembre;
                    break;
                case 10:
                    Periodo = Properties.Resources.Cm_Octubre;
                    break;
                case 11:
                    Periodo = Properties.Resources.Cm_Noviembre;
                    break;
                case 12:
                    Periodo = Properties.Resources.Cm_Diciembre;
                    break;
            }

            return Periodo + " " + iAnio.S();
        }

        private void ObtienePeriodoEdoCuentaI(string sMes)
        {
            string[] ma = sMes.Split(' ');
            iAnio = Convert.ToInt32(ma[1]);
            switch (ma[0])
            {
                case "Enero":
                    iMes = 1;
                    break;
                case "Jaunary":
                    iMes = 1;
                    break;
                case "Febrero":
                    iMes = 2;
                    break;
                case "February":
                    iMes = 2;
                    break;
                case "Marzo":
                    iMes = 3;
                    break;
                case "March":
                    iMes = 3;
                    break;
                case "Abril":
                    iMes = 4;
                    break;
                case "April":
                    iMes = 4;
                    break;
                case "Mayo":
                    iMes = 5;
                    break;
                case "May":
                    iMes = 5;
                    break;
                case "Junio":
                    iMes = 6;
                    break;
                case "June":
                    iMes = 6;
                    break;
                case "Julio":
                    iMes = 7;
                    break;
                case "July":
                    iMes = 7;
                    break;
                case "Agosto":
                    iMes = 8;
                    break;
                case "August":
                    iMes = 8;
                    break;
                case "Septiembre":
                    iMes = 9;
                    break;
                case "September":
                    iMes = 9;
                    break;
                case "Octubre":
                    iMes = 10;
                    break;
                case "October":
                    iMes = 10;
                    break;
                case "Noviembre":
                    iMes = 11;
                    break;
                case "November":
                    iMes = 11;
                    break;
                case "Diciembre":
                    iMes = 12;
                    break;
                case "December":
                    iMes = 12;
                    break;
            }
        }

        public void LlenaTableEdoCuenta(List<responseRepEdoCuenta> olstRep)
        {        
            oEstados = olstRep;

            foreach (responseRepEdoCuenta item in olstRep)
            {
                item.nombreMes = ObtienePeriodoEdoCuenta(item.mes, item.anio);

                foreach (detalleEdoCta itemD in item.olsDetalle)
                {
                    itemD.nombreMes = ObtienePeriodoEdoCuenta(itemD.mes, itemD.anio);
                }

            }

            gvEdoCuenta.DataSource = olstRep;
            gvEdoCuenta.DataBind();
        }

        public void LlenaDocsEdoCuenta(List<responseDocumentoF> olstRep)
        {
            if(olstRep.Count > 0)
            {
                gvDocEdoCuenta.DataSource = olstRep;
                gvDocEdoCuenta.DataBind();
            }
        }

        public void LlenarEdoCuenta(List<responseEdoCuenta> olstRep)
        {
            DataTable dt = new DataTable();
            dt.TableName = "Extras";
            dt.Columns.Add("Cliente", typeof(System.String));
            dt.Columns.Add("Periodo", typeof(System.String));
            dt.Columns.Add("Elaboro", typeof(System.String));
            dt.Columns.Add("Matricula", typeof(System.String));
            dt.Columns.Add("ClaveContrato", typeof(System.String));
            dt.Columns.Add("IVA", typeof(System.String));
            dt.Columns.Add("IVAText", typeof(System.String));
            dt.Columns.Add("Fecha", typeof(System.String));
            dt.Columns.Add("SaldoAnterior", typeof(System.String));
            dt.Columns.Add("PagosyCred", typeof(System.String));
            dt.Columns.Add("NuevosCargos", typeof(System.String));
            dt.Columns.Add("SaldoActual", typeof(System.String));
            dt.Columns.Add("SaldoAnteriorUSD", typeof(System.String));
            dt.Columns.Add("PagosyCredUSD", typeof(System.String));
            dt.Columns.Add("NuevosCargosUSD", typeof(System.String));
            dt.Columns.Add("SaldoActualUSD", typeof(System.String));

            var contador = 0;
            DataRow row = dt.NewRow();
            foreach (var item in olstRep)
            {
                if (contador == 0)
                {
                    row["SaldoAnterior"] = item.saldoAnterior.S().D().ToString("c");
                    row["PagosyCred"] = item.pagosCreditos.S().D().ToString("c");
                    row["NuevosCargos"] = item.nuevosCargos.S().D().ToString("c");
                    row["SaldoActual"] = item.saldoActual.S().D().ToString("c");
                    row["Matricula"] = Utils.MatriculaActual;                   
                    row["Cliente"] = Utils.NombreCliente;
                    row["IVA"] = "";
                    row["IVAText"] = "";
                    row["Fecha"] = "";
                    row["ClaveContrato"] = item.claveContrato;
                    row["Periodo"] = ObtienePeriodoEdoCuenta(item.mes,item.anio);
                    row["Elaboro"] = Utils.NombreUsuario;
                }
                else
                {
                    row["SaldoAnteriorUSD"] = item.saldoAnterior.S().D().ToString("c");
                    row["PagosyCredUSD"] = item.pagosCreditos.S().D().ToString("c");
                    row["NuevosCargosUSD"] = item.nuevosCargos.S().D().ToString("c");
                    row["SaldoActualUSD"] = item.saldoActual.S().D().ToString("c");
                    dt.Rows.Add(row);
                }
                contador++;
            }

            EdoCuenta.Tables.Add(dt);
        }

        public void LlenarSubEdoCuenta(SubEdoCuenta olstRep)
        {
            //Tabla MXP
            DataTable dtMXP = new DataTable();
            dtMXP.TableName = "MXP";
            dtMXP.Columns.Add("Fecha", typeof(System.String));
            dtMXP.Columns.Add("NoReferencia", typeof(System.String));
            dtMXP.Columns.Add("TipodeGastos", typeof(System.String));
            dtMXP.Columns.Add("Concepto", typeof(System.String));
            dtMXP.Columns.Add("Rubro", typeof(System.String));
            dtMXP.Columns.Add("Detalle", typeof(System.String));
            dtMXP.Columns.Add("Proveedor", typeof(System.String));
            dtMXP.Columns.Add("Importe", typeof(System.Decimal));
            dtMXP.Columns.Add("AmpliadoGasto", typeof(System.String));

            foreach (var item in olstRep.estadoCuentaUSD)
            {
                DataRow rowMXP = dtMXP.NewRow();
                rowMXP["Fecha"] = item.fecha;
                rowMXP["NoReferencia"] = item.numReferencia;
                rowMXP["TipodeGastos"] = item.tipoGasto;
                rowMXP["Concepto"] = item.concepto;
                rowMXP["Rubro"] = item.rubro;
                rowMXP["Detalle"] = item.detalle;
                rowMXP["Proveedor"] = item.proveedor;
                rowMXP["Importe"] = item.importe;
                rowMXP["AmpliadoGasto"] = "";

                dtMXP.Rows.Add(rowMXP);
            }

            EdoCuenta.Tables.Add(dtMXP);

            //Tabla USD
            DataTable dtUSD = new DataTable();
            dtUSD.TableName = "USD";
            dtUSD.Columns.Add("Fecha", typeof(System.String));
            dtUSD.Columns.Add("NoReferencia", typeof(System.String));
            dtUSD.Columns.Add("TipodeGasto", typeof(System.String));
            dtUSD.Columns.Add("Concepto", typeof(System.String));
            dtUSD.Columns.Add("Rubro", typeof(System.String));
            dtUSD.Columns.Add("Detalle", typeof(System.String));
            dtUSD.Columns.Add("Proveedor", typeof(System.String));
            dtUSD.Columns.Add("Importe", typeof(System.Decimal));
            dtUSD.Columns.Add("AmpliadoGasto", typeof(System.String));

            foreach (var item in olstRep.estadoCuentaMXN)
            {
                DataRow rowUSD = dtUSD.NewRow();
                rowUSD["Fecha"] = item.fecha;
                rowUSD["NoReferencia"] = item.numReferencia;
                rowUSD["TipodeGasto"] = item.tipoGasto;
                rowUSD["Concepto"] = item.concepto;
                rowUSD["Rubro"] = item.rubro;
                rowUSD["Detalle"] = item.detalle;
                rowUSD["Proveedor"] = item.proveedor;
                rowUSD["Importe"] = item.importe;
                rowUSD["AmpliadoGasto"] = "";

                dtUSD.Rows.Add(rowUSD);
            }

            EdoCuenta.Tables.Add(dtUSD);
        }
        #endregion

        #region VARIABLES Y PROPIEDADES

        EstadoCuenta_Presenter oPresenter;
        public event EventHandler eNewObj;
        public event EventHandler eObjSelected;
        public event EventHandler eSaveObj;
        public event EventHandler eDeleteObj;
        public event EventHandler eSearchObj;
        public event EventHandler eSearchObjDocs;
        public event EventHandler eSearchEdoObj;

        public List<responseRepEdoCuenta> oEstados
        {
            get { return (List<responseRepEdoCuenta>)ViewState["VSEstados"]; }
            set { ViewState["VSEstados"] = value; }
        }

        public int iMes
        {
            get { return ViewState["VSMes"].S().I(); }
            set { ViewState["VSMes"] = value; }
        }

        public string sMes
        {
            get { return ViewState["sVSMes"].S(); }
            set { ViewState["sVSMes"] = value; }
        }

        public int iAnio
        {
            get { return ViewState["VSAnio"].S().I(); }
            set { ViewState["VSAnio"] = value; }
        }

        public int iExisteDoc
        {
            get { return ViewState["VSExisteDoc"].S().I(); }
            set { ViewState["VSExisteDoc"] = value; }
        }

        public DataSet EdoCuenta
        {
            get { return (DataSet)ViewState["EdoCuenta"]; }
            set { ViewState["EdoCuenta"] = value; }
        }


        #endregion


    }
}