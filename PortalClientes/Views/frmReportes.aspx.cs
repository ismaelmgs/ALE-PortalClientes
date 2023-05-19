using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalClientes.Clases;
using NucleoBase.Core;
using System.Data;
using PortalClientes.Presenter;
using DevExpress.XtraRichEdit.Forms;
using NReco.PdfGenerator;

namespace PortalClientes.Views
{
    public partial class frmReportes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["RefUrl"] = Request.Url.ToString();
            if (System.Web.HttpContext.Current.Session["UserIdentity"] == null)
            {
                Response.Redirect("~/Views/frmFinconexion2.aspx");
            }
            TextBox milabel = (TextBox)this.Master.FindControl("txtLang");
            if (milabel.Text != Utils.Idioma && milabel.Text != string.Empty)
            {
                Utils.Idioma = milabel.Text;
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmaReportes();
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmaReportes();
            }

        }

        protected void btnDetReporte_Click(object sender, EventArgs e)
        {
            LinkButton button = (LinkButton)sender;
            string report = button.Attributes["data-report"];
            string rpt = button.Attributes["data-rpt"];

            Session["reporteDetalle"] = report.I();
            Session["isRpt"] = rpt.I();

            Response.Redirect("frmDetalleReportes.aspx");
        }

        private void ArmaReportes()
        {
            lblReportesFijosVariables.Text = Properties.Resources.Re_TituloRep;
            lblReportesFijosVar.Text = Properties.Resources.Re_SeccionGatoFijoVariable;
            lblRepGastosFijosVariables.Text = Properties.Resources.Re_GastosFijoVariable;
            lblRepGastosAeropuerto.Text = Properties.Resources.Re_GastosAeropuerto;
            lblRepGastosProveedor.Text = Properties.Resources.Re_GastosProveedor;
            lblResumenGastosVuelos.Text = Properties.Resources.Re_ResumenGastosVuelos;
            lblDetalleGastosVuelos.Text = Properties.Resources.Re_DetalleGastosVuelos;
            lblIngresosGastos.Text = Properties.Resources.Re_GastosIngresos;
            lblReporteAdminAnual.Text = Properties.Resources.Re_AdminAnual;
            lblGastoCombustibleVuelo.Text = Properties.Resources.Re_GastoCombustibleVuelo;
        }

        protected void btnExportarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                string sUsuario = Utils.NombreUsuario;
                string sMatricula = Utils.MatriculaActual;
                int iAnio = DateTime.Now.Year;

                Reportes_Presenter oPre = new Reportes_Presenter();
                DataSet ds = oPre.GetCostoxHora(iAnio, sMatricula);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    string sReport = GetBodyReport(ds);
                    string sHeader = GetHeader(ds);
                    string sFooter = "<div class='row'>";
                    sFooter += "    <div class='col-md-12' style='text-align:center;'>";
                    sFooter += "        <hr style='color:#002D56;' />";
                    sFooter += "        <span style='vertical-align:top; font-size:10pt; color:#002D56; font-family: Arial, sans-serif;'>Copyright © 2023 ALE Aerolíneas Ejecutivas S.A. de C.V. Todos los Derechos Reservados.</span>";
                    sFooter += "    </div>";
                    sFooter += "</div>";

                    var htmlToPdf = new HtmlToPdfConverter();
                    htmlToPdf.Orientation = PageOrientation.Landscape;
                    htmlToPdf.Margins.Left = 1;
                    htmlToPdf.Margins.Right = 1;
                    htmlToPdf.Size = PageSize.A4;
                    htmlToPdf.PageHeaderHtml = sHeader;
                    htmlToPdf.PageFooterHtml = sFooter;

                    byte[] pdfBytes = htmlToPdf.GeneratePdf(sReport);

                    Response.Clear();
                    Response.ClearHeaders();
                    Response.Buffer = true;
                    Response.Charset = "UTF-8";
                    string filename = "Reporte_CostoPorHora_" + sMatricula + ".pdf";
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");
                    Response.BinaryWrite(pdfBytes);
                    Response.Flush();
                    //Response.End();
                    Response.SuppressContent = true;
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
                else
                {
                    //Algun mensaje
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetHeader(DataSet dsData)
        {
            try
            {
                string sUsuario = Utils.NombreUsuario;
                string sMatricula = Utils.MatriculaActual;
                string sContrato = Utils.ClaveContrato;
                string sCliente = Utils.NombreCliente;
                DateTime dtActual = DateTime.Now;
                string sFechaImpresion = dtActual.Day.ToString() + " de " + GetMes(dtActual.Month) + " de " + dtActual.Year.ToString() + " a las " + dtActual.Hour.ToString() + ":" + dtActual.Minute.ToString() + " hrs.";
                string css = System.IO.File.ReadAllText(Server.MapPath(@"~/vendors/bootstrap4/bootstrap4.min.css"));
                byte[] imageArray = System.IO.File.ReadAllBytes(Server.MapPath(@"~/build/images/logo-ale_azul2_2.jpg"));
                string base64ImageRepresentation = Convert.ToBase64String(imageArray);
                string sHTML = string.Empty;

                sHTML += "<!doctype html>";
                sHTML += "<html>";
                sHTML += "<head>";
                sHTML += "  <title></title>";
                sHTML += "  <meta charset='utf-8' />";
                sHTML += "  <meta name='viewport' content='width=device-width, initial-scale=1, shrink-to-fit=no'>";
                sHTML += "  <style>";
                sHTML += css;
                sHTML += ".tbldata tr:nth-child(even) { background-color: #ffffff; }";
                sHTML += ".tbldata tr:nth-child(odd) { background-color: #f2f2f2; }";
                sHTML += "  </style>";
                sHTML += "</head>";
                sHTML += "<body>";
                sHTML += "  <div>";
                sHTML += "      <div class='row'>";
                sHTML += "          <div class='col-md-4' align='left'>";
                sHTML += "              <div style='text-align:center;'>";
                sHTML += "                  <img src='data:image/png;base64," + base64ImageRepresentation + "' alt='Fancy Image' width='380px' />";
                sHTML += "              </div>";
                sHTML += "          </div>";
                sHTML += "          <div class='col'></div>";
                sHTML += "          <div class='col'></div>";
                sHTML += "      </div>";

                sHTML += "      <div class='row'>";

                sHTML += "          <div class='col-md-4' align='left' style='padding-left:80px;'>";
                sHTML += "                <table border='0' width='60%' style='border: 0px solid transparent !important; font-size:10pt;'>";
                sHTML += "                  <tr>";
                sHTML += "                      <td>Matrícula:</td>";
                sHTML += "                      <td style='width:60%;font-weight:600;'>" + sMatricula + " </td>";
                sHTML += "                  </tr>";
                sHTML += "                  <tr>";
                sHTML += "                      <td style='width:40%;'>Clave Contrato:</td>";
                sHTML += "                      <td style='width:60%;font-weight:600;'>" + sContrato + "</td>";
                sHTML += "                  </tr>";

                sHTML += "              </table>";
                sHTML += "          </div>";

                sHTML += "          <div class='col-md-4'>";
                sHTML += "              <table border='0' width='100%' style='vertical-align:top !important;'>";
                sHTML += "                <tr>";
                sHTML += "                    <td>";
                sHTML += "                      <div style='text-align:center;'>";
                sHTML += "                          <span style='color:#2D416E;font-size:18pt;'>Reporte de costo por hora de vuelo</span>";
                sHTML += "                      </div>";
                sHTML += "                    </td>";
                sHTML += "                </tr>";
                sHTML += "                <tr>";
                sHTML += "                    <td>";
                sHTML += "                      <div style='text-align:center;'>";
                sHTML += "                          <span style='color:#2D416E;font-size:14pt;'>" + sCliente + "</span>";
                sHTML += "                      </div>";
                sHTML += "                    </td>";
                sHTML += "                </tr>";
                sHTML += "              </table>";
                sHTML += "          </div>";

                sHTML += "          <div class='col-md-4' align='left'>";
                sHTML += "                <table border='0' width='95%' style='border: 0px solid transparent !important; font-size:10pt;'>";
                sHTML += "                  <tr>";
                sHTML += "                      <td style='width:40%;'>Usuario:</td>";
                sHTML += "                      <td style='width:60%; font-weight:600;'>" + sUsuario + "</td>";
                sHTML += "                  </tr>";
                sHTML += "                  <tr>";
                sHTML += "                      <td>Fecha de Impresión:</td>";
                sHTML += "                      <td style='width:60%; font-weight:600;'>" + sFechaImpresion + " </td>";
                sHTML += "                  </tr>";
                sHTML += "              </table>";
                sHTML += "          </div>";
                sHTML += "      </div>";

                sHTML += "  </div>";
                sHTML += "</body>";
                sHTML += "</html>";
                return sHTML;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string GetBodyReport(DataSet dsData)
        {
            try
            {
                string sUsuario = Utils.NombreUsuario;
                string sMatricula = Utils.MatriculaActual;
                string sContrato = Utils.ClaveContrato;
                string sCliente = Utils.NombreCliente;

                DataTable dtFV = new DataTable();
                DataTable dtF = new DataTable();
                DataTable dtV = new DataTable();
                DataTable dtHV = new DataTable();
                DateTime dtActual = DateTime.Now;

                string sFechaImpresion = dtActual.Day.ToString() + " de " + GetMes(dtActual.Month) + " de " + dtActual.Year.ToString() + " a las " + dtActual.Hour.ToString() + ":" + dtActual.Minute.ToString() + " hrs.";

                dtFV = dsData.Tables[0];
                dtF = dsData.Tables[1];
                dtV = dsData.Tables[2];
                dtHV = dsData.Tables[3];

                string css = System.IO.File.ReadAllText(Server.MapPath(@"~/vendors/bootstrap4/bootstrap4.min.css"));
                byte[] imageArray = System.IO.File.ReadAllBytes(Server.MapPath(@"~/build/images/logo-ale_azul2_2.jpg"));
                string base64ImageRepresentation = Convert.ToBase64String(imageArray);

                string sHTML = string.Empty;
                sHTML += "<!doctype html>";
                sHTML += "<html>";
                sHTML += "<head>";
                sHTML += "  <title></title>";
                sHTML += "  <meta charset='utf-8' />";
                sHTML += "  <meta name='viewport' content='width=device-width, initial-scale=1, shrink-to-fit=no'>";
                sHTML += "  <style>";
                sHTML += css;
                sHTML += ".tbldata tr:nth-child(even) { background-color: #ffffff; }";
                sHTML += ".tbldata tr:nth-child(odd) { background-color: #f2f2f2; }";
                sHTML += "  </style>";
                sHTML += "</head>";
                sHTML += "<body>";
                sHTML += "  <div>";

                #region PRIMERA TABLA


                //sHTML += "      <div class='row'>";
                //sHTML += "          <div class='col-md-4' align='left'>";
                //sHTML += "              <div style='text-align:center;'>";
                //sHTML += "                  <img src='data:image/png;base64," + base64ImageRepresentation + "' alt='Fancy Image' width='380px' />";
                //sHTML += "              </div>";
                //sHTML += "          </div>";
                //sHTML += "          <div class='col'></div>";
                //sHTML += "          <div class='col'></div>";
                //sHTML += "      </div>";

                //sHTML += "      <div class='row'>";

                //sHTML += "          <div class='col-md-4' align='left' style='padding-left:80px;'>";
                //sHTML += "                <table border='0' width='60%' style='border: 0px solid transparent !important; font-size:10pt;'>";
                //sHTML += "                  <tr>";
                //sHTML += "                      <td>Matrícula:</td>";
                //sHTML += "                      <td style='width:60%;font-weight:600;'>" + sMatricula + " </td>";
                //sHTML += "                  </tr>";
                //sHTML += "                  <tr>";
                //sHTML += "                      <td style='width:40%;'>Clave Contrato:</td>";
                //sHTML += "                      <td style='width:60%;font-weight:600;'>" + sContrato + "</td>";
                //sHTML += "                  </tr>";

                //sHTML += "              </table>";
                //sHTML += "          </div>";

                //sHTML += "          <div class='col-md-4'>";
                //sHTML += "              <table border='0' width='100%' style='vertical-align:top !important;'>";
                //sHTML += "                <tr>";
                //sHTML += "                    <td>";
                //sHTML += "                      <div style='text-align:center;'>";
                //sHTML += "                          <span style='color:#2D416E;font-size:18pt;'>Reporte de costo por hora de vuelo</span>";
                //sHTML += "                      </div>";
                //sHTML += "                    </td>";
                //sHTML += "                </tr>";
                //sHTML += "                <tr>";
                //sHTML += "                    <td>";
                //sHTML += "                      <div style='text-align:center;'>";
                //sHTML += "                          <span style='color:#2D416E;font-size:14pt;'>" + sCliente + "</span>";
                //sHTML += "                      </div>";
                //sHTML += "                    </td>";
                //sHTML += "                </tr>";
                //sHTML += "              </table>";
                //sHTML += "          </div>";

                //sHTML += "          <div class='col-md-4' align='left'>";
                //sHTML += "                <table border='0' width='95%' style='border: 0px solid transparent !important; font-size:10pt;'>";
                //sHTML += "                  <tr>";
                //sHTML += "                      <td style='width:40%;'>Usuario:</td>";
                //sHTML += "                      <td style='width:60%; font-weight:600;'>" + sUsuario + "</td>";
                //sHTML += "                  </tr>";
                //sHTML += "                  <tr>";
                //sHTML += "                      <td>Fecha de Impresión:</td>";
                //sHTML += "                      <td style='width:60%; font-weight:600;'>" + sFechaImpresion + " </td>";
                //sHTML += "                  </tr>";
                //sHTML += "              </table>";
                //sHTML += "          </div>";
                //sHTML += "      </div>";


                //sHTML += "<br />";

                sHTML += "      <div class='row'>";
                sHTML += "          <div class='col-md-12' align='center'>";
                sHTML += "  	        <div style='width: 100%; margin:0 auto 0 auto;'>";
                sHTML += "  		        <table id='tblReporteFijoVariable' name='tblReporteFijoVariable' class='tbldata' style='border: 0px solid #85B4DE !important; font-size:9pt;'>";
                sHTML += "  			        <tr style='background-color:#2D416E; color: #FFFFFF;'>";
                sHTML += "  			        	<td style='padding:5px;'><span>Mes</span></td>";
                sHTML += "  			        	<td style='padding:5px; text-align:center;'><span>Capital</span></td>";
                sHTML += "  			        	<td style='padding:5px; text-align:center;'><span>Seguros</span></td>";
                sHTML += "  			        	<td style='padding:5px; text-align:center;'><span>Adiestramiento</span></td>";
                sHTML += "  			        	<td style='padding:5px; text-align:center;'><span>Tripulación</span></td>";
                sHTML += "  			        	<td style='padding:5px; text-align:center;'><span>Cuota Admon</span></td>";
                sHTML += "  			        	<td style='padding:5px; text-align:center;'><span>Hangar</span></td>";
                sHTML += "  			        	<td style='padding:5px; text-align:center; font-weight:600;'><span>Total Fijo</span></td>";
                sHTML += "  			        	<td style='padding:5px; text-align:center;'><span>Combustible</span></td>";
                sHTML += "  			        	<td style='padding:5px; text-align:center;'><span>Viaje</span></td>";
                sHTML += "  			        	<td style='padding:5px; text-align:center;'><span>Mantenimiento</span></td>";
                sHTML += "  			        	<td style='padding:5px; text-align:center;'><span>Impuesto y Derechos</span></td>";
                sHTML += "  			        	<td style='padding:5px; text-align:center;'><span>Diversos</span></td>";
                sHTML += "  			        	<td style='padding:5px; text-align:center; font-weight:600;'><span>Total Variable</span></td>";
                sHTML += "  			        	<td style='padding:5px; text-align:center; font-weight:600;'><span>Total General</span></td>";
                sHTML += "  			        </tr>";

                for (int i = 0; i < dtFV.Rows.Count; i++)
                {
                    if (i != dtFV.Rows.Count - 1)
                    {
                        sHTML += "  			        <tr style='border-left: 0px solid transparent !important; border-right: 0px solid transparent !important;'>";
                        sHTML += "  			        	<td style='padding:5px; text-align:left;'><span>" + dtFV.Rows[i]["Mes"].S() + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right;'><span>" + dtFV.Rows[i]["Capital"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right;'><span>" + dtFV.Rows[i]["Seguros"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right;'><span>" + dtFV.Rows[i]["Adiestramiento"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right;'><span>" + dtFV.Rows[i]["Tripulacion"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right;'><span>" + dtFV.Rows[i]["Cuota"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right;'><span>" + dtFV.Rows[i]["Hangar"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right; font-weight:600;'><span>" + dtFV.Rows[i]["TotalFijo"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right;'><span>" + dtFV.Rows[i]["Combustible"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right;'><span>" + dtFV.Rows[i]["Viaje"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right;'><span>" + dtFV.Rows[i]["Mantenimiento"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right;'><span>" + dtFV.Rows[i]["Impuesto_Derecho"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right;'><span>" + dtFV.Rows[i]["Diversos"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right; font-weight:600;'><span>" + dtFV.Rows[i]["TotalVariable"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right; font-weight:600;'><span>" + dtFV.Rows[i]["TotalGeneral"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        </tr>";
                    }
                    else
                    {
                        sHTML += "  			        <tr style='border-left: 0px solid transparent !important; border-right: 0px solid transparent !important; border-bottom: 0px solid transparent !important;'>";
                        sHTML += "  			        	<td style='padding:5px; text-align:left; font-weight:600;'><span>" + dtFV.Rows[i]["Mes"].S() + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right; font-weight:600;'><span>" + dtFV.Rows[i]["Capital"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right; font-weight:600;'><span>" + dtFV.Rows[i]["Seguros"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right; font-weight:600;'><span>" + dtFV.Rows[i]["Adiestramiento"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right; font-weight:600;'><span>" + dtFV.Rows[i]["Tripulacion"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right; font-weight:600;'><span>" + dtFV.Rows[i]["Cuota"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right; font-weight:600;'><span>" + dtFV.Rows[i]["Hangar"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right; font-weight:600;'><span>" + dtFV.Rows[i]["TotalFijo"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right; font-weight:600;'><span>" + dtFV.Rows[i]["Combustible"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right; font-weight:600;'><span>" + dtFV.Rows[i]["Viaje"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right; font-weight:600;'><span>" + dtFV.Rows[i]["Mantenimiento"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right; font-weight:600;'><span>" + dtFV.Rows[i]["Impuesto_Derecho"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right; font-weight:600;'><span>" + dtFV.Rows[i]["Diversos"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right; font-weight:600;'><span>" + dtFV.Rows[i]["TotalVariable"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right; font-weight:600;'><span>" + dtFV.Rows[i]["TotalGeneral"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        </tr>";
                    }
                }

                sHTML += "                  </table>";
                sHTML += "              </div>";
                sHTML += "          </div>";
                sHTML += "      </div>";
                #endregion

                sHTML += "      <br />";
                //sHTML += "      <br />";

                #region TABLAS DE FIJO Y VARIABLES COSTO POR HORA USD
                sHTML += "      <div class='row'>";
                sHTML += "          <div class='col-md-6' align='center'>";
                sHTML += "  	        <div style='width: 98%; margin:0 auto 0 auto;'>";
                sHTML += "  		        <table id='tblFijo' name='tblFijo'  class='tbldata' style='border: 0px solid #85B4DE !important; font-size:9pt;'>";
                sHTML += "  			        <tr style='background-color:#2D416E; color: #FFFFFF;'>";
                sHTML += "  			        	<td style='padding:5px; text-align:center;'><span>Rubro</span></td>";
                sHTML += "  			        	<td style='padding:5px; text-align:center;'><span>Importe USD</span></td>";
                sHTML += "  			        	<td style='padding:5px; text-align:center;'><span>Costo por Hora USD</span></td>";
                sHTML += "  			        </tr>";
                for (int i = 0; i < dtF.Rows.Count; i++)
                {
                    if (i != dtF.Rows.Count - 1)
                    {
                        sHTML += "  			        <tr style='border-left: 0px solid transparent !important; border-right: 0px solid transparent !important;'>";
                        sHTML += "  			        	<td style='padding:5px; text-align:left;'><span>" + dtF.Rows[i]["Rubro"].S() + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right;'><span>" + dtF.Rows[i]["ImporteUSD"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right;'><span>" + dtF.Rows[i]["CostoXHoraUSD"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        </tr>";
                    }
                    else
                    {
                        sHTML += "  			        <tr style='border-left: 0px solid transparent !important; border-right: 0px solid transparent !important; border-bottom: 0px solid transparent !important;'>";
                        sHTML += "  			        	<td style='padding:5px; text-align:left; font-weight:600;'><span>" + dtF.Rows[i]["Rubro"].S() + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right; font-weight:600;'><span>" + dtF.Rows[i]["ImporteUSD"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right; font-weight:600;'><span>" + dtF.Rows[i]["CostoXHoraUSD"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        </tr>";
                    }  
                }
                sHTML += "                  </table>";
                sHTML += "              </div>";
                sHTML += "          </div>";

                sHTML += "          <div class='col-md-6' align='center'>";
                sHTML += "  	        <div style='width: 98%; margin:0 auto 0 auto;'>";
                sHTML += "  		        <table id='tblVariable' name='tblVariable'  class='tbldata' style='border: 0px solid #85B4DE !important; font-size:9pt;'>";
                sHTML += "  			        <tr style='background-color:#2D416E; color: #FFFFFF;'>";
                sHTML += "  			        	<td style='padding:5px; text-align: left;'><span>Rubro</span></td>";
                sHTML += "  			        	<td style='padding:5px; text-align: center;'><span>Importe USD</span></td>";
                sHTML += "  			        	<td style='padding:5px; text-align: center;'><span>Costo por Hora USD</span></td>";
                sHTML += "  			        </tr>";
                for (int i = 0; i < dtV.Rows.Count; i++)
                {
                    if (i != dtV.Rows.Count - 1)
                    {
                        sHTML += "  			        <tr style='border-left: 0px solid transparent !important; border-right: 0px solid transparent !important;'>";
                        sHTML += "  			        	<td style='padding:5px; text-align:left;'><span>" + dtV.Rows[i]["Rubro"].S() + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right;'><span>" + dtV.Rows[i]["ImporteUSD"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right;'><span>" + dtV.Rows[i]["CostoXHoraUSD"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        </tr>";
                    }
                    else
                    {
                        sHTML += "  			        <tr style='border-left: 0px solid transparent !important; border-right: 0px solid transparent !important; border-bottom: 0px solid transparent !important;'>";
                        sHTML += "  			        	<td style='padding:5px; text-align:left; font-weight:600;'><span>" + dtV.Rows[i]["Rubro"].S() + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right; font-weight:600;'><span>" + dtV.Rows[i]["ImporteUSD"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        	<td style='padding:5px; text-align:right; font-weight:600;'><span>" + dtV.Rows[i]["CostoXHoraUSD"].S().D().ToString("c") + "</span></td>";
                        sHTML += "  			        </tr>";
                    }
                    
                }
                sHTML += "                  </table>";
                sHTML += "              </div>";
                sHTML += "          </div>";

                sHTML += "      </div>";
                #endregion
                sHTML += "<br /><br /><br /><br /><br /><br />";
                sHTML += "<div class='row'>";
                sHTML += "  <div class='col-md-6' align='center'>";
                sHTML += "      <div style='width: 98%; margin:0 auto 0 auto;'>";
                sHTML += "          <table id='tblHoraVuelo' name='tblHoraVuelo'  class='tbldata' style='border: 0px solid #85B4DE !important; font-size:9pt; width:50%;'>";
                sHTML += "  	        <tr style='background-color:#2D416E; color: #FFFFFF;'>";
                sHTML += "  	        	<td style='padding:5px; text-align: left; width:50%;'><span>Mes</span></td>";
                sHTML += "  	        	<td style='padding:5px; text-align: center; width:50%;'><span>Total</span></td>";
                sHTML += "  	        </tr>";
                for (int i = 0; i < dtHV.Rows.Count; i++)
                {
                    if (i != dtHV.Rows.Count - 1)
                    {
                        sHTML += "  		<tr style='border-left: 0px solid transparent !important; border-right: 0px solid transparent !important;'>";
                        sHTML += "  			<td style='padding:5px; text-align:left; width:50%;'><span>" + dtHV.Rows[i]["Mes"].S() + "</span></td>";
                        sHTML += "  			<td style='padding:5px; text-align:center; width:50%;'><span>" + dtHV.Rows[i]["Total"].S() + "</span></td>";
                        sHTML += "  		</tr>";
                    }
                    else
                    {
                        sHTML += "  		<tr style='border-left: 0px solid transparent !important; border-right: 0px solid transparent !important; border-bottom: 0px solid transparent !important;'>";
                        sHTML += "  			<td style='padding:5px; text-align:left; font-weight:600; width:50%;'><span>" + dtHV.Rows[i]["Mes"].S() + "</span></td>";
                        sHTML += "  			<td style='padding:5px; text-align:center; font-weight:600; width:50%;'><span>" + dtHV.Rows[i]["Total"].S() + "</span></td>";
                        sHTML += "  		</tr>";
                    }
                }
                sHTML += "          </table>";
                sHTML += "      </div>";
                sHTML += "  </div>";

                sHTML += "  <div class='col-md-6' align='center'>";
                sHTML += "      <div style='width: 98%; margin:0 auto 0 auto;'>";
                sHTML += "      </div>";
                sHTML += "  </div>";

                sHTML += "</div>";

                sHTML += "  </div>";
                sHTML += "</body>";
                sHTML += "</html>";


                return sHTML;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string GetMes(int iMes)
        {
            try
            {
                string sMes = string.Empty;
                switch (iMes)
                {
                    case 1:
                        sMes = "Enero";
                        break;
                    case 2:
                        sMes = "Febrero";
                        break;
                    case 3:
                        sMes = "Marzo";
                        break;
                    case 4:
                        sMes = "Abril";
                        break;
                    case 5:
                        sMes = "Mayo";
                        break;
                    case 6:
                        sMes = "Junio";
                        break;
                    case 7:
                        sMes = "Julio";
                        break;
                    case 8:
                        sMes = "Agosto";
                        break;
                    case 9:
                        sMes = "Septiembre";
                        break;
                    case 10:
                        sMes = "Octubre";
                        break;
                    case 11:
                        sMes = "Noviembre";
                        break;
                    case 12:
                        sMes = "Diciembre";
                        break;
                    default:
                        break;
                }
                return sMes;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}