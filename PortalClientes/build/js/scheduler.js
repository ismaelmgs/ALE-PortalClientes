function ClickAppointment(scheduler, a) {

    if (a != null) {
        $.ajax({
            data: JSON.stringify({ Id: a.appointmentId }),
            contentType: "Application/json; charset=utf-8",
            responseType: "json",
            method: 'POST',
            url: window.location + "/getDataAppointment",
            dataType: "json",
            beforeSend: function (response) {
                lPanel.Show();
            },
            success: function (response) {
                if (response.d) {
                    InsertData(response.d)
                }
            },
            error: function (err) {
                console.log("Fallo al llenar modal", err);
            }
        });
        //$("#ContentPlaceHolder1_AppointmentID").val(a.appointmentId);
        //$("#ContentPlaceHolder1_GetModal").val("Modal");
        //scheduler.GetAppointmentProperties(a.appointmentId, 'Subject;Location;Start;End;Description', openModal);
    }
}

function InsertData(item) {
    var modalId = 'ContentPlaceHolder1_modalDescription';
    var modal = $find(modalId);

    $("#ContentPlaceHolder1_lblClaveCiudadSalida").html(item.origen);
    $("#ContentPlaceHolder1_lblClaveCiudadSalidaRes").html(item.fboNombreOrigen);
    $("#ContentPlaceHolder1_lblClaveCiudadLlegada").html(item.destino);
    $("#ContentPlaceHolder1_lblClaveCiudadLlegadaRes").html(item.fboNombreDest);
    $("#ContentPlaceHolder1_lblDMASalida").html(item.FechaInicio);
    $("#ContentPlaceHolder1_lblDMAHoraSalida").html(item.HoraInicio);
    $("#ContentPlaceHolder1_lblDMALLegada").html(item.FechaFin);
    $("#ContentPlaceHolder1_lblDMAHoraLLegada").html(item.HoraFin);
    $("#ContentPlaceHolder1_lblAeronaveRes").html(item.matricula);
    $("#ContentPlaceHolder1_lblTipoEventoRes").html(item.recType);
    $("#ContentPlaceHolder1_lblViajeNumeroRes").html(item.tripNum);
    $("#ContentPlaceHolder1_lblTipoVueloRes").html(item.requestor);
    $("#ContentPlaceHolder1_lblNombreContactoRes").html(item.requestorName);
    $("#ContentPlaceHolder1_lalSolicitanteRes").html(item.cliente);
    $("#ContentPlaceHolder1_lblRegulacionRes").html(item.farNum);
    $("#ContentPlaceHolder1_lblEstatusRes").html(item.tripStat);
    $("#ContentPlaceHolder1_lblEstatusRes").html(item.statusVuelo);
    $("#ContentPlaceHolder1_lblAeropuertoSalida").html(item.origen);
    $("#ContentPlaceHolder1_lblAeropuertoSalidaRes").html(item.fboNombreOrigen);
    $("#ContentPlaceHolder1_lblFueraFechaBloqueRes").html(item.FechaInicio);
    $("#ContentPlaceHolder1_lblFueraTiempoBloqueRes").html(item.HoraInicio);
    $("#ContentPlaceHolder1_lblFechaDeSalidaRes").html(item.FechaInicio);
    $("#ContentPlaceHolder1_lblHoraSalidaRes").html(item.HoraInicio);
    $("#ContentPlaceHolder1_lblTiempoVuelo").html(item.TiempoVuelo);
    //$("#ContentPlaceHolder1_lblObjetivoRes").html(item.);
    $("#ContentPlaceHolder1_lblDescripcionRes").html(item.typeDesc);
    $("#ContentPlaceHolder1_lblAeropuertoLLegadaRes").html(item.fboNombreDest);
    $("#ContentPlaceHolder1_lblAeropuertoLLegada").html(item.destino);
    $("#ContentPlaceHolder1_lblFechaArrivoRes").html(item.FechaFin);
    $("#ContentPlaceHolder1_lblHoraArrivoRes").html(item.HoraFin);
    $("#ContentPlaceHolder1_lblFechaBloqueRes").html(item.FechaFin);
    $("#ContentPlaceHolder1_lblTiempoBloqueRes").html(item.HoraFin);
    $("#ContentPlaceHolder1_lblPasajerosRes").html(item.pasajeros);
    $("#ContentPlaceHolder1_lblNumeroPasajerosRes").html(item.pax);
    $("#ContentPlaceHolder1_lblTrpulacionRes").html(item.tripulacion);
    $("#ContentPlaceHolder1_lblDistanciaRes").html(item.distancia);
    $("#ContentPlaceHolder1_lblDatosTiempoVueloRes").html(item.TiempoVuelo);
    $("#ContentPlaceHolder1_lblDatosBloqueTiempoRes").html(item.FechaFin);
    $("#ContentPlaceHolder1_lblSalidaFBORes").html(item.fboNombreOrigen);
    $("#ContentPlaceHolder1_lblTelRes").html(item.fboPhoneOrigen);
    $("#ContentPlaceHolder1_lblDireccionRes").html(item.fboDirOrigen);
    $("#ContentPlaceHolder1_lblLLEgadaRes").html(item.fboNombreDest);
    $("#ContentPlaceHolder1_lblTelLLegadaRes").html(item.fboPhoneDest);
    $("#ContentPlaceHolder1_lblDireccioLLegadaRes").html(item.fboDirDest);
    $("#ContentPlaceHolder1_lblCateringTelNotasRes").html(item.notes);

    lPanel.Hide();
    modal.show();
}

function CloseModal() {
    var modalId = 'ContentPlaceHolder1_modalDescription';
    var modal = $find(modalId);
    modal.hide();
}

function Click(s, e) {
    lPanel.Show();
    var y = s.GetSelectedInterval();
    $("#ContentPlaceHolder1_hfdate").val(y.start);
    lPanel.Hide();
}

document.addEventListener("DOMContentLoaded", function(event) {
    document.getElementById("ctl00_ContentPlaceHolder1_Scheduler_viewNavigatorBlock_ctl00_toolbar_DXI0_").style.display = "none";
    document.getElementById("ctl00_ContentPlaceHolder1_Scheduler_viewNavigatorBlock_ctl00_toolbar_DXI1_").style.display = "none";
    document.getElementById("ctl00_ContentPlaceHolder1_Scheduler_viewNavigatorBlock_ctl00_toolbar_DXI3_").style.display = "none";
});