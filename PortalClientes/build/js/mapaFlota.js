function getUrlMF() {
	let value = window.location + "/getDataMap"
	return value
}

function initializeMF() {
	// Coordenada de la ruta
	var flightPlanCoordinatesRutas = []
	var flightPlanCoordinatesAero = []

	let coordenada = {
		lat: "",
		lng: "",
	}

	// Configuración del mapa
	var mapProp = {
		zoom: 5,
		center: { lat: 23.0, lng: -102.0 },
	}

	let fecha = new Date()
	let hora = fecha.getHours()

	if (hora >= 19 || hora < 6) {
		let styles = [
			{ elementType: "geometry", stylers: [{ color: "#242f3e" }] },
			{
				elementType: "labels.text.stroke",
				stylers: [{ color: "#242f3e" }],
			},
			{
				elementType: "labels.text.fill",
				stylers: [{ color: "#746855" }],
			},
			{
				featureType: "administrative.locality",
				elementType: "labels.text.fill",
				stylers: [{ color: "#d59563" }],
			},
			{
				featureType: "poi",
				elementType: "labels.text.fill",
				stylers: [{ color: "#d59563" }],
			},
			{
				featureType: "poi.park",
				elementType: "geometry",
				stylers: [{ color: "#263c3f" }],
			},
			{
				featureType: "poi.park",
				elementType: "labels.text.fill",
				stylers: [{ color: "#6b9a76" }],
			},
			{
				featureType: "road",
				elementType: "geometry",
				stylers: [{ color: "#38414e" }],
			},
			{
				featureType: "road",
				elementType: "geometry.stroke",
				stylers: [{ color: "#212a37" }],
			},
			{
				featureType: "road",
				elementType: "labels.text.fill",
				stylers: [{ color: "#9ca5b3" }],
			},
			{
				featureType: "road.highway",
				elementType: "geometry",
				stylers: [{ color: "#746855" }],
			},
			{
				featureType: "road.highway",
				elementType: "geometry.stroke",
				stylers: [{ color: "#1f2835" }],
			},
			{
				featureType: "road.highway",
				elementType: "labels.text.fill",
				stylers: [{ color: "#f3d19c" }],
			},
			{
				featureType: "transit",
				elementType: "geometry",
				stylers: [{ color: "#2f3948" }],
			},
			{
				featureType: "transit.station",
				elementType: "labels.text.fill",
				stylers: [{ color: "#d59563" }],
			},
			{
				featureType: "water",
				elementType: "geometry",
				stylers: [{ color: "#17263c" }],
			},
			{
				featureType: "water",
				elementType: "labels.text.fill",
				stylers: [{ color: "#515c6d" }],
			},
			{
				featureType: "water",
				elementType: "labels.text.stroke",
				stylers: [{ color: "#17263c" }],
			},
		]

		mapProp.styles = styles
	}

	// Agregando el mapa al tag de id googleMap
	var mapRutas = new google.maps.Map(
		document.getElementById("googleMapRutas"),
		mapProp
	)
	var mapAero = new google.maps.Map(
		document.getElementById("googleMapLocation"),
		mapProp
	)

	let objMF = JSON.stringify({
		meses: $("#ContentPlaceHolder1_ddlMeses").val(),
		matricula: $("#ContentPlaceHolder1_ddlAeronave").val(),
	})

	ajax_dataMF(objMF, function (response) {
		const dataRutas = response.detalleRutas
		const dataAeropuertos = response.detalleAeropuertos

		const { numeroVuelos, tiempoVolado, numeroAeropuertos, distanciaVolada } = response.detalleTotalVuelos

		document.getElementById("ContentPlaceHolder1_lblVuelosRes").innerHTML = numeroVuelos;
		document.getElementById("ContentPlaceHolder1_lblHorasVueloRes").innerHTML = tiempoVolado;
		document.getElementById("ContentPlaceHolder1_lblAeropuertosRes").innerHTML = numeroAeropuertos;
		document.getElementById("ContentPlaceHolder1_lblMiVueloRes").innerHTML = distanciaVolada;

		dataRutas.forEach((item, index, array) => {
			if (
				item.adestinoLatitud != null &&
				item.adestinoLongitud != null &&
				item.aorigenLatitud != null &&
				item.aorigenLongitud != null
			) {
				let ca = { ...coordenada }
				ca.lat = parseFloat(item.aorigenLatitud)
				ca.lng = parseFloat(item.aorigenLongitud)
				flightPlanCoordinatesRutas.push(ca)

				let cb = { ...coordenada }
				cb.lat = parseFloat(item.adestinoLatitud)
				cb.lng = parseFloat(item.adestinoLongitud)
				flightPlanCoordinatesRutas.push(cb)

				// Información de la ruta (coordenadas, color de línea, etc...)
				var flightPathRutas = new google.maps.Polyline({
					path: flightPlanCoordinatesRutas,
					geodesic: true,
					strokeColor: "#FF0000",
					strokeOpacity: 1.0,
					strokeWeight: 2,
				})

				for (i = 0; i < flightPlanCoordinatesRutas.length; i++) {
					var markerRutas = new google.maps.Marker({
						position: flightPlanCoordinatesRutas[i],
						// label: i > 0 ? item.origen : item.destino,
						map: mapRutas,
					})
				}

				// Creando la ruta en el mapa
				flightPathRutas.setMap(mapRutas)
			}
		})

		let arrayClaves = []
		dataAeropuertos.forEach((item, index, array) => {
			if (item.latitud != null && item.longitud != null) {
				let ca = { ...coordenada }
				ca.lat = parseFloat(item.latitud)
				ca.lng = parseFloat(item.longitud)
				flightPlanCoordinatesAero.push(ca)
				arrayClaves.push(item.aeropuerto)
			}
		})

		for (i = 0; i < flightPlanCoordinatesAero.length; i++) {
			var markerAero = new google.maps.Marker({
				position: flightPlanCoordinatesAero[i],
				// label: arrayClaves[i],
				map: mapAero,
			})
		}
	})
}

function ajax_dataMF(objMF, success) {
	$.ajax({
		data: objMF,
		contentType: "Application/json; charset=utf-8",
		responseType: "json",
		method: "POST",
		url: getUrlMF(),
		dataType: "json",
		beforeSend: function (response) {},
		success: function (response) {
			success.call(this, response.d)
		},
		error: function (err) {
			console.log("Error al generar mapas", err)
		},
	})
}

// var dropDownMeses = ;
// var dropDownMatricula = ;


// document.getElementById("<%=ddlMeses.ClientID %>").addEventListener('change', () => {
// 	initializeMF();
// });

// document.getElementById("<%=ddlAeronave.ClientID %>").addEventListener('change', () => {
// 	initializeMF();
// });

// Inicializando el mapa cuando se carga la página
// google.maps.event.addDomListener(window, 'load', initialize(true));

function hometab_Click() {
	initialize()
}

function profiletab_Click() {
	initialize()
}
