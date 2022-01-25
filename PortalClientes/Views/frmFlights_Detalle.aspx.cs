using PortalClientes.Objetos;
using PortalClientes.Clases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Web.Services;
using DevExpress.Web;
using NucleoBase.Core;
using System.Globalization;
using System.Drawing;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System.Threading;

namespace PortalClientes.Views
{
    public partial class frmFlights_Detalle : System.Web.UI.Page
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
                ArmarDetalleVuelo();
            }
            else
            {
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Utils.Idioma);
                ArmarDetalleVuelo();
            }

            if (!IsPostBack)
            {
                if (Session["detVuelo"] != null)
                {
                    detVuelos data = (detVuelos)Session["detVuelo"];
                    LlenarDetalleVuelo(data);
                }
            }
        }

        private void LlenarDetalleVuelo(detVuelos data)
        {
            lblClaveCiudadSalida.Text = data.origen;
            lblClaveCiudadSalidaRes.Text = data.fboNombreOrigen;
            lblTiempoVuelo.Text = (data.FechaFin - data.FechaInicio).ToString(@"hh\h\ mm\m\ ");
            lblClaveCiudadLlegada.Text = data.destino;
            lblClaveCiudadLlegadaRes.Text = data.fboNombreDest;
            lblDMASalida.Text = data.FechaInicio.ToLongDateString();
            lblDMAHoraSalida.Text = data.FechaInicio.ToShortTimeString();
            lblDMALLegada.Text = data.FechaFin.ToLongDateString();
            lblDMAHoraLLegada.Text = data.FechaFin.ToShortTimeString();
            lblTipoEventoRes.Text = data.recType == "M" ? "Mantenimiento" : "Vuelo"; 
            lblViajeNumeroRes.Text = data.tripNum.S();    
            lblTipoVueloRes.Text = data.requestor;
            lblNombreContactoRes.Text = data.requestorName;
            lalSolicitanteRes.Text = data.cliente;
            lblAeronaveRes.Text = Utils.MatriculaActual;
            lblRegulacionRes.Text = data.farNum;
            lblEstatusRes.Text = data.tripStat == "X" ? "Cancelado" : "Pendiente";
            lblDistanciaRes.Text = data.distancia.S();
            lblDatosTiempoVueloRes.Text = (data.FechaFin - data.FechaInicio).ToString(@"hh\h\ mm\m\ ");
            lblDescripcionRes.Text = data.typeDesc;
            lblAeropuertoSalida.Text = data.origen;
            lblAeropuertoSalidaRes.Text = data.fboNombreOrigen;
            lblFechaDeSalidaRes.Text = data.FechaInicio.ToLongDateString();
            lblHoraSalidaRes.Text = data.FechaInicio.ToString(@"hh\h\ mm\m\ ");
            lblAeropuertoLLegada.Text = data.destino;
            lblAeropuertoLLegadaRes.Text = data.fboNombreDest;
            lblFechaArrivoRes.Text = data.FechaFin.ToLongDateString();
            lblHoraArrivoRes.Text = data.FechaFin.ToString(@"hh\h\ mm\m\ ");
            lblNumeroPasajerosRes.Text = data.pax.S();
            lblTrpulacionRes.Text = data.primerNomPil + " " + data.segNomPil + " " + data.apellidosPil + ", " + data.primerNomCop + " " + data.segNomCop + " " + data.apellidosCop;
            lblSalidaFBORes.Text = data.fboNombreOrigen;
            lblTelRes.Text = data.fboPhoneOrigen;
            lblDireccionRes.Text = data.fboDirOrigen;
            lblLLEgadaRes.Text = data.fboNombreDest;
            lblTelLLegadaRes.Text = data.fboPhoneDest;           
            lblDireccioLLegadaRes.Text = data.fboDirDest;
            lblCateringTelNotasRes.Text = data.notes;
            lblPasajerosRes.Text = string.Join(", ", data.pasajeros.Split('|').ToList());
        }

        private void ArmarDetalleVuelo()
        {
            lblFligthsDetalle.Text = Properties.Resources.Ca_DetalleVuelo;
            lblInformacionGeneral.Text = Properties.Resources.Ca_InformacionGeneral;
            lblTipoEvento.Text = Properties.Resources.Ca_TipoEvento;
            lblViajeNumero.Text = Properties.Resources.Ca_ViajeNumero;
            lblTipoVuelo.Text = Properties.Resources.Ca_TipoVuelo;
            lblNombreContacto.Text = Properties.Resources.Ca_NombreContacto;
            lalSolicitante.Text = Properties.Resources.Ca_Solicitante;
            lblRegulacion.Text = Properties.Resources.Ca_Regulacion;
            lblEstatus.Text = Properties.Resources.Ca_Estatus;
            lblDescripcion.Text = Properties.Resources.Ca_Descripcion;
            lbldesdeA.Text = Properties.Resources.Ca_SalidaLlegada;
            lblAeropuertoSalida.Text = Properties.Resources.Ca_AeropuertoSalida;
            lblFechaDeSalida.Text = Properties.Resources.Ca_FechaSalida;
            lblHoraSalida.Text = Properties.Resources.Ca_HoraSalida;
            lblZonaHoraria.Text = Properties.Resources.Ca_ZonaHoraria;
            lblAeropuertoLLegada.Text = Properties.Resources.Ca_AeropuertoLlegada;
            lblFhechaArrivo.Text = Properties.Resources.Ca_FechaArrivo;
            lblHoraArrivo.Text = Properties.Resources.Ca_HoraArrivo;
            lblZonaHorariaLlegada.Text = Properties.Resources.Ca_ZonaHorariaLlegada;
            lblPasajerosGeneral.Text = Properties.Resources.Ca_Pasajeros;
            lblPasajeros.Text = Properties.Resources.Ca_SubPasajeros;
            lblNumeroPasajeros.Text = Properties.Resources.Ca_NumeroPasajeros;
            lblTripulacion.Text = Properties.Resources.Ca_Tripulacion;
            lblTripulacionMiembros.Text = Properties.Resources.Ca_MiembrosTripulacion;
            lblDistancia.Text = Properties.Resources.Ca_Distancia;
            lblDatosTiempoVuelo.Text = Properties.Resources.Ca_TiempoVuelo;
            lblFBO.Text = Properties.Resources.Ca_FBO;
            lblSalidaFBO.Text = Properties.Resources.Ca_SalidaFBO;
            lblTel.Text = Properties.Resources.Ca_Telefono;
            lblDireccion.Text = Properties.Resources.Ca_Direccion;
            lblLLEgada.Text = Properties.Resources.Ca_LlegadaFBO;
            lblTelLLegada.Text = Properties.Resources.Ca_SegundoTelefono;
            lblDireccioLLegada.Text = Properties.Resources.Ca_SegundaDireccion;
            lblCatering.Text = Properties.Resources.Ca_Catering;
            lblInformacionGeneral.Text = Properties.Resources.Ca_InformacionGeneral;
            lblAeronave.Text = Properties.Resources.Ca_Aeronave;
            lblTipoEvento.Text = Properties.Resources.Ca_TipoEvento;
            lblViajeNumero.Text = Properties.Resources.Ca_ViajeNumero;
            lblTipoVuelo.Text = Properties.Resources.Ca_TipoVuelo;
            lblNombreContacto.Text = Properties.Resources.Ca_NombreContacto;
            lblllegadaa.Text = Properties.Resources.Ca_LlegadaA;
            lblFBO.Text = Properties.Resources.Ca_FBO;
            lblSalidaFBO.Text = Properties.Resources.Ca_SalidaFBO;
            lblTel.Text = Properties.Resources.Ca_Telefono;
            lblDireccion.Text = Properties.Resources.Ca_Direccion;
            lblLLEgada.Text = Properties.Resources.Ca_LlegadaFBO;
            lblTelLLegada.Text = Properties.Resources.Ca_SegundoTelefono;
            lblDireccioLLegada.Text = Properties.Resources.Ca_SegundaDireccion;
            lblCatering.Text = Properties.Resources.Ca_Catering;
        }
    }
}