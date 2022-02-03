let rutas = true

function getUrlRA() {
	let value = window.location + "/GetRutasAeropuertos"
	return value
}

function initialize() {
	lPanel.Show();
	// Coordenada de la ruta
	var flightPlanCoordinates = [
		// {lat: 19.3910038, lng: -99.2836972},
		// {lat: 28.6710638, lng: -106.1346581}
	]

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
	var map = new google.maps.Map(document.getElementById("googleMap"), mapProp)

	let objRA = JSON.stringify({
		meses: $("#ContentPlaceHolder1_ddlFiltroMesesRA").val(),
	})

	ajax_dataRA(objRA, function (response) {
		const dataRutas = response.rutaAeropuertoPeriodoA
		const dataAeropuertos = response.rutaAeropuertoPeriodoB

		if (rutas) {
			dataRutas.forEach((item, index, array) => {
				if (
					item.adestinoLatitud != null &&
					item.adestinoLongitud != null &&
					item.aorigenLatitud != null &&
					item.adestinoLongitud != null
				) {
					let ca = { ...coordenada }
					ca.lat = item.aorigenLatitud
					ca.lng = item.aorigenLongitud
					flightPlanCoordinates.push(ca)

					let cb = { ...coordenada }
					cb.lat = item.adestinoLatitud
					cb.lng = item.adestinoLongitud
					flightPlanCoordinates.push(cb)

					// Información de la ruta (coordenadas, color de línea, etc...)
					var flightPath = new google.maps.Polyline({
						path: flightPlanCoordinates,
						geodesic: true,
						strokeColor: "#FF0000",
						strokeOpacity: 1.0,
						strokeWeight: 2,
					})

					for (i = 0; i < flightPlanCoordinates.length; i++) {
						var marker = new google.maps.Marker({
							position: flightPlanCoordinates[i],
							// label: i > 0 ? item.origen : item.destino,
							map: map,
						})
					}

					// Creando la ruta en el mapa
					flightPath.setMap(map)
				}
			})
		} else {
			let arrayClaves = []
			dataAeropuertos.forEach((item, index, array) => {
				if (item.latitud != null && item.longitud != null) {
					let ca = { ...coordenada }
					ca.lat = item.latitud
					ca.lng = item.longitud
					flightPlanCoordinates.push(ca)
					arrayClaves.push(item.aeropuerto)
				}
			})

			for (i = 0; i < flightPlanCoordinates.length; i++) {
				var marker = new google.maps.Marker({
					position: flightPlanCoordinates[i],
					// label: arrayClaves[i],
					map: map,
				})
			}
		}

		lPanel.Hide();
	})
}

function ajax_dataRA(objRA, success) {
	$.ajax({
		data: objRA,
		contentType: "Application/json; charset=utf-8",
		responseType: "json",
		method: "POST",
		url: getUrlRA(),
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

// Inicializando el mapa cuando se carga la página
// google.maps.event.addDomListener(window, 'load', initialize(true));

function hometab_Click() {
	document.getElementById("ContentPlaceHolder1_lbTitleMapR").style.display =
		"block"
	document.getElementById("ContentPlaceHolder1_lbTitleMapA").style.display =
		"none"

	rutas = true
	initialize()
}

function profiletab_Click() {
	document.getElementById("ContentPlaceHolder1_lbTitleMapA").style.display =
		"block"
	document.getElementById("ContentPlaceHolder1_lbTitleMapR").style.display =
		"none"

	rutas = false
	initialize()
}
