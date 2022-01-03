using PortalClientes.DomainModel;
using PortalClientes.Interfaces;
using PortalClientes.Objetos;
using System;
using PortalClientes.Clases;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PortalClientes.Presenter
{
    public class DetalleReportes_Presenter : BasePresenter<IViewDetalleReportes>
    {
        private readonly DBMetricasEstatics oIGesCat;

        public DetalleReportes_Presenter(IViewDetalleReportes oView, DBMetricasEstatics oGC) : base(oView)
        {
            oIGesCat = oGC;
            oIView.eSearchObj += SearchObj_Presenter;
        }

        protected override void SearchObj_Presenter(object sender, EventArgs e)
        {
            switch (oIView.iReporte)
            {
                case 1:
                    FiltroGraficaFV f1 = new FiltroGraficaFV();
                    f1.idioma = Utils.Idioma;
                    f1.matricula = Utils.MatriculaActual;
                    f1.meses = "3";

                    oIView.CargarReporteGastosFV(oIGesCat.obtenerCostosFijoVariable(f1));
                    break;
                case 2:
                    FiltroGrafica f2 = new FiltroGrafica();
                    f2.matricula = Utils.MatriculaActual;
                    f2.meses = "3";

                    oIView.CargarReporteGastosAe(oIGesCat.ObtenerGastosAeropuerto(f2));
                    break;
                case 3:
                    FiltroGrafica f3 = new FiltroGrafica();
                    f3.matricula = Utils.MatriculaActual;
                    f3.meses = "3";

                    oIView.CargarReporteGastosProve(oIGesCat.ObtenerGastosProveedor(f3));
                    break;
                case 4:
                    FiltroGraficaCC f4 = new FiltroGraficaCC();
                    f4.matricula = Utils.MatriculaActual;
                    f4.meses = "12";
                    f4.claveCliente = "RASSI";

                    oIView.CargarReporteResumenGastosVuelos(oIGesCat.obtenerReporteResumenGastosVuelos(f4));
                    break;
                case 5:
                    FiltroGraficaCC f5 = new FiltroGraficaCC();
                    f5.matricula = Utils.MatriculaActual;
                    f5.meses = "12";
                    f5.claveCliente = "RASSI";

                    oIView.CargarReporteDetalleGastosVuelos(oIGesCat.obtenerReporteDetalleGastosVuelos(f5));
                    break;
            }
        }
    }
}