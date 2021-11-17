using DevExpress.Web.Bootstrap;
using PortalClientes.Clases;
using PortalClientes.Objetos;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalClientes
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserIdentity"] != null)
            {
                UserIdentity oUI = (UserIdentity)Session["UserIdentity"];
                txtLang.Text = oUI.sIdioma;
                lblNombreUsuario.Text = oUI.sNombre;
            }

            if (txtLang.Text != Utils.Idioma)
            {
                txtLang.Text = Utils.Idioma;
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmaFormulario();
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmaFormulario();
            }

            if(Utils.Idioma == "es-MX")
            {
                imgIconoEspanol.Visible = true;
                imgIconoEnglish.Visible = false;
            }
            else
            {
                imgIconoEspanol.Visible = false;
                imgIconoEnglish.Visible = true;
            }

            ArmaMenu();

            if (!IsPostBack)
            {
                CargaMatriculas();  
            }
        }

        protected void lblIdiomaEspanol_Click(object sender, EventArgs e)
        {
            Utils.Idioma = "es-MX";
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        protected void lblIdiomaEnglish_Click(object sender, EventArgs e)
        {
            Utils.Idioma = "en-US";
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        private void ArmaFormulario()
        {
            MenuMatriculas.Items[0].Text = Properties.Resources.CerrarSesion;
            MenuMatriculas.Items[1].Text = Utils.NombreUsuario;
            MenuMatriculas.Items[2].Text = Properties.Resources.AdministrarCuenta;
            
        }

        private void ArmaMenu()
        {
            List<MenuDinamico> olst = ObtieneMenu();
            string sHtml = "<ul class='nav side-menu'> ";

            foreach (MenuDinamico oMenu in olst)
            {
                string sNombre = Utils.Idioma == "es-MX" || Utils.Idioma == string.Empty ? oMenu.nombreESP : oMenu.nombreUSD;
                sHtml += "<li><a href = '" + oMenu.urlPage + "'><i class='" + oMenu.style + "'></i>"+ sNombre + "</a></li>";
            }
                                //<li><a href = "frmDashboard.aspx">< i class="fa fa-th-large"></i>Dashboard</a></li>
                                //<li><a href = "frmTuAeronave.aspx">< i class="fa fa-plane"></i>Tu Aeronave</a></li>
                                //<li><a href = "frmCalendario.aspx">< i class="fa fa-calendar"></i>Calendario</a></li>
                                //<li><a href = "frmEstadoCuenta.aspx">< i class="fa fa-list"></i>Estados de Cuenta</a></li>
                                //<li><a href = "frmTripulacion.aspx">< i class="fa fa-male"></i>Tripulación</a></li>
                                //<li><a href = "frmMetricasEstadisticas.aspx">< i class="fa fa-line-chart"></i>Métricas y Estadísticas</a></li>
                                //<li><a href = "frmReportes.aspx">< i class="fa fa-list-alt"></i>Reportes</a></li>
                                //<li><a href = "frmMantenimientos.aspx">< i class="fa fa-wrench"></i>Mantenimientos</a></li>
                                //<li><a href = "frmUsuarios.aspx">< i class="fa fa-group"></i>Usuarios</a></li>

            sHtml += " </ul>";

            divMenu.InnerHtml = sHtml;
        }

        private List<MenuDinamico> ObtieneMenu()
        {
            try
            {
                List<MenuDinamico> olstFinal = new List<MenuDinamico>();
                List<ModulosUsuario> olst = new List<ModulosUsuario>();
                JavaScriptSerializer ser = new JavaScriptSerializer();
                TokenWS oToken = Utils.ObtieneToken;
                requestIdUsuario oRe = new requestIdUsuario();
                oRe.idUsuario = Utils.GetIdEmpUsuario;

                var client = new RestClient(Helper.US_UrlConsultaModulosPorUsuario);
                var request = new RestRequest(Method.POST);
                request.AddHeader("Authorization", oToken.token);
                request.AddJsonBody(oRe);

                IRestResponse response = client.Execute(request);
                var resp = response.Content;
                olst = ser.Deserialize<List<ModulosUsuario>>(resp);

                MenuDinamico oMenu0 = new MenuDinamico();
                oMenu0.urlPage = "frmDefault.aspx";
                oMenu0.style = "fa fa-home";
                oMenu0.nombreESP = "Inicio";
                oMenu0.nombreUSD = "Home";

                olstFinal.Add(oMenu0);

                foreach (ModulosUsuario oMenu in olst)
                {
                    if (oMenu.sts == 1)
                    {
                        MenuDinamico oM = new MenuDinamico();
                        oM.urlPage = oMenu.urlPage;
                        oM.style = oMenu.icono;
                        oM.nombreESP = oMenu.nombreESP;
                        oM.nombreUSD = oMenu.nombreENG;

                        olstFinal.Add(oM);
                    }
                }

                return olstFinal;
                
                /*
                MenuDinamico oMenu1 = new MenuDinamico();
                oMenu1.UrlPage = "frmDashboard.aspx";
                oMenu1.Style = "fa fa-th-large";
                oMenu1.NombreESP = "Dashboard";
                oMenu1.NombreUSD = "Dashboard";

                MenuDinamico oMenu2 = new MenuDinamico();
                oMenu2.UrlPage = "frmTuAeronave.aspx";
                oMenu2.Style = "fa fa-plane";
                oMenu2.NombreESP = "Tu Aeronave";
                oMenu2.NombreUSD = "Your Aircraft";

                MenuDinamico oMenu3 = new MenuDinamico();
                oMenu3.UrlPage = "frmCalendario.aspx";
                oMenu3.Style = "fa fa-calendar";
                oMenu3.NombreESP = "Calendario";
                oMenu3.NombreUSD = "Calendar";

                MenuDinamico oMenu4 = new MenuDinamico();
                oMenu4.UrlPage = "frmEstadoCuenta.aspx";
                oMenu4.Style = "fa fa-list";
                oMenu4.NombreESP = "Estados de Cuenta";
                oMenu4.NombreUSD = "Account statements";

                MenuDinamico oMenu5 = new MenuDinamico();
                oMenu5.UrlPage = "frmTripulacion.aspx";
                oMenu5.Style = "fa fa-male";
                oMenu5.NombreESP = "Tripulación";
                oMenu5.NombreUSD = "Crew";

                MenuDinamico oMenu6 = new MenuDinamico();
                oMenu6.UrlPage = "frmMetricasEstadisticas.aspx";
                oMenu6.Style = "fa fa-line-chart";
                oMenu6.NombreESP = "Métricas y Estadísticas";
                oMenu6.NombreUSD = "Metrics and Statistics";

                MenuDinamico oMenu7 = new MenuDinamico();
                oMenu7.UrlPage = "frmReportes.aspx";
                oMenu7.Style = "fa fa-list-alt";
                oMenu7.NombreESP = "Reportes";
                oMenu7.NombreUSD = "Reports";

                MenuDinamico oMenu8 = new MenuDinamico();
                oMenu8.UrlPage = "frmMantenimientos.aspx";
                oMenu8.Style = "fa fa-wrench";
                oMenu8.NombreESP = "Mantenimientos";
                oMenu8.NombreUSD = "Maintenance";

                MenuDinamico oMenu9 = new MenuDinamico();
                oMenu9.UrlPage = "frmUsuarios.aspx";
                oMenu9.Style = "fa fa-group";
                oMenu9.NombreESP = "Usuarios";
                oMenu9.NombreUSD = "Users";


                olst.Add(oMenu0);
                olst.Add(oMenu1);
                olst.Add(oMenu2);
                olst.Add(oMenu3);
                olst.Add(oMenu4);
                olst.Add(oMenu5);
                olst.Add(oMenu6);
                olst.Add(oMenu7);
                olst.Add(oMenu8);
                olst.Add(oMenu9);

                return olst;
                */
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CargaMatriculas()
        {
            if (Session["UserIdentity"] != null)
            {
                UserIdentity oU = (UserIdentity)Session["UserIdentity"];
                if (oU != null)
                {
                    BootstrapMenuItem oMenuMats = new BootstrapMenuItem();
                    oMenuMats = MenuMatriculas.Items[3];

                    if (oU.lsMatriculas != null)
                    {
                        foreach (string sMat in oU.lsMatriculas)
                        {
                            BootstrapMenuItem oItem = new BootstrapMenuItem();
                            oItem.Text = sMat;
                            oItem.GroupName = "Group4";
                            oItem.IconCssClass = "fa fa-caret-right";
                            oItem.CssClass = "icon_left";
                            oMenuMats.Items.Add(oItem);

                            if(Utils.MatriculaActual == null || Utils.MatriculaActual == "")
                            {
                                lblAeronave.Text = sMat;
                                lblAeronaveLat.Text = sMat;
                                Utils.MatriculaActual = sMat;
                            }
                            else
                            {
                                lblAeronave.Text = Utils.MatriculaActual;
                                lblAeronaveLat.Text = Utils.MatriculaActual;
                            }
                        }
                    }
                }
            }
        }

        protected void MenuMatriculas_ItemClick(object source, DevExpress.Web.Bootstrap.BootstrapMenuItemEventArgs e)
        {
            if (e.Item.GroupName == "Group1")
            {
                Session["UserIdentity"] = null;
                Response.Redirect("~/frmLogin.aspx");
            }

            string[] pathList = HttpContext.Current.Request.Url.Segments;
            string path = pathList[2];

            if (e.Item.GroupName == "Group4")
            {
                if(Utils.MatriculaActual != e.Item.Text && e.Item.Text != "Matrículas ⏷")
                {
                    Utils.MatriculaActual = e.Item.Text;
                    lblAeronave.Text = e.Item.Text;
                    lblAeronaveLat.Text = e.Item.Text;
                }
                else
                {
                    lblAeronave.Text = Utils.MatriculaActual;
                    lblAeronaveLat.Text = Utils.MatriculaActual;
                }
            }

            if (path == Enums.Dashboard)
            {
                Response.Redirect("~/Views/frmDashboard.aspx");
            }
            else if (path == Enums.Aeronaves)
            {
                Response.Redirect("~/Views/frmTuAeronave.aspx");
            }
            else if (path == Enums.Tripulacion)
            {
                Response.Redirect("~/Views/frmTripulacion.aspx");
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session["UserIdentity"] = null;
            Response.Redirect("~/frmLogin.aspx");
        }
    }
}