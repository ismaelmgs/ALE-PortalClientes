﻿using PortalClientes.Clases;
using PortalClientes.Objetos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalClientes
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (txtLang.Text != Utils.Idioma)
            {
                Utils.Idioma = txtLang.Text;
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmaFormulario();
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmaFormulario();
            }

            ArmaMenu();
        }

        protected void lblIdiomaEspanol_Click(object sender, EventArgs e)
        {
            Utils.Idioma = "es-MX";
        }

        protected void lblIdiomaEnglish_Click(object sender, EventArgs e)
        {
            Utils.Idioma = "en-US";
        }

        private void ArmaFormulario()
        {
            lblUserSetings.Text = Properties.Resources.AdministrarCuenta;
            lblSalir.Text = Properties.Resources.CerrarSesion;
        }

        private void ArmaMenu()
        {
            List<MenuDinamico> olst = ObtieneMenu();
            string sHtml = "<ul class='nav side-menu'> ";

            foreach (MenuDinamico oMenu in olst)
            {
                string sNombre = Utils.Idioma == "es-MX" || Utils.Idioma == string.Empty ? oMenu.Nombre : oMenu.NombreUSD;
                sHtml += "<li><a href = '" + oMenu.UrlPage + "'><i class='" + oMenu.Style + "'></i>"+ sNombre + "</a></li>";
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
                List<MenuDinamico> olst = new List<MenuDinamico>();
                MenuDinamico oMenu1 = new MenuDinamico();
                oMenu1.UrlPage = "frmDashboard.aspx";
                oMenu1.Style = "fa fa-th-large";
                oMenu1.Nombre = "Dashboard";
                oMenu1.NombreUSD = "Dashboard";

                MenuDinamico oMenu2 = new MenuDinamico();
                oMenu2.UrlPage = "frmTuAeronave.aspx";
                oMenu2.Style = "fa fa-plane";
                oMenu2.Nombre = "Tu Aeronave";
                oMenu2.NombreUSD = "Your Aircraft";

                MenuDinamico oMenu3 = new MenuDinamico();
                oMenu3.UrlPage = "frmCalendario.aspx";
                oMenu3.Style = "fa fa-calendar";
                oMenu3.Nombre = "Calendario";
                oMenu3.NombreUSD = "Calendar";

                MenuDinamico oMenu4 = new MenuDinamico();
                oMenu4.UrlPage = "frmEstadoCuenta.aspx";
                oMenu4.Style = "fa fa-list";
                oMenu4.Nombre = "Estados de Cuenta";
                oMenu4.NombreUSD = "Account statements";

                MenuDinamico oMenu5 = new MenuDinamico();
                oMenu5.UrlPage = "frmTripulacion.aspx";
                oMenu5.Style = "fa fa-male";
                oMenu5.Nombre = "Tripulación";
                oMenu5.NombreUSD = "Crew";

                MenuDinamico oMenu6 = new MenuDinamico();
                oMenu6.UrlPage = "frmMetricasEstadisticas.aspx";
                oMenu6.Style = "fa fa-line-chart";
                oMenu6.Nombre = "Métricas y Estadísticas";
                oMenu6.NombreUSD = "Metrics and Statistics";

                MenuDinamico oMenu7 = new MenuDinamico();
                oMenu7.UrlPage = "frmReportes.aspx";
                oMenu7.Style = "fa fa-list-alt";
                oMenu7.Nombre = "Reportes";
                oMenu7.NombreUSD = "Reports";

                MenuDinamico oMenu8 = new MenuDinamico();
                oMenu8.UrlPage = "frmMantenimientos.aspx";
                oMenu8.Style = "fa fa-wrench";
                oMenu8.Nombre = "Mantenimientos";
                oMenu8.NombreUSD = "Maintenance";

                MenuDinamico oMenu9 = new MenuDinamico();
                oMenu9.UrlPage = "frmUsuarios.aspx";
                oMenu9.Style = "fa fa-group";
                oMenu9.Nombre = "Usuarios";
                oMenu9.NombreUSD = "Users";


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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}