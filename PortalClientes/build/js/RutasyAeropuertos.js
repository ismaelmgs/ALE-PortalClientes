
function getUrlRA() {
  let value = window.location + "/GetRutasAeropuertos";
  return value;
}

function initialize() {

  let objRA = JSON.stringify({
      meses: $("#ContentPlaceHolder1_ddlFiltroMesesRA").val(),
  });

  $.ajax({
    data: objRA,
    contentType: "Application/json; charset=utf-8",
    responseType: "json",
    method: 'POST',
    url: getUrlRA(),
    dataType: "json",
    beforeSend: function (response) { },
    success: function (response) {
        const rutas = response.d.rutaAeropuertoPeriodoA
        const aeropuertos = response.d.rutaAeropuertoPeriodoB

        // Coordenada de la ruta
        var flightPlanCoordinates = [
          // {lat: 19.3910038, lng: -99.2836972},
          // {lat: 28.6710638, lng: -106.1346581}
        ];

        let coordenada = {
          lat: '',
          lng: ''
        }

        // Configuración del mapa
        var mapProp = {
          zoom: 2,
          center: {lat: 23.0000000, lng: -102.0000000},
        };
        
        // Agregando el mapa al tag de id googleMap
        var map = new google.maps.Map(document.getElementById("googleMap"), mapProp);

        rutas.forEach((item, index, array) => {

          if(item.adestinoLatitud != null && 
            item.adestinoLongitud != null && 
            item.aorigenLatitud != null && 
            item.adestinoLongitud != null)
          {

            let ca = {...coordenada}
            ca.lat = item.aorigenLatitud
            ca.lng = item.aorigenLongitud
            flightPlanCoordinates.push(ca)

            let cb = {...coordenada}
            cb.lat = item.adestinoLatitud
            cb.lng = item.adestinoLongitud
            flightPlanCoordinates.push(cb)

            // Información de la ruta (coordenadas, color de línea, etc...)
            var flightPath = new google.maps.Polyline({
              path: flightPlanCoordinates,
              geodesic: true,
              strokeColor: '#FF0000',
              strokeOpacity: 1.0,
              strokeWeight: 2
            });

            for (i = 0; i < flightPlanCoordinates.length; i++) {
              var marker = new google.maps.Marker({
                position: flightPlanCoordinates[i],
                // label: i > 0 ? item.origen : item.destino,
                map: map
              });
            }
          
            // Creando la ruta en el mapa
            flightPath.setMap(map);
          }
        })
      },
      error: function (err) {
          console.log("Error al generar mapas", err);
      }
  });
}
    
  // Inicializando el mapa cuando se carga la página
  google.maps.event.addDomListener(window, 'load', initialize);