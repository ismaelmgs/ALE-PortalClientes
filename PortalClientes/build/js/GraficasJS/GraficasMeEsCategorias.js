$(document).ready(function () {
    //const url = "http://192.168.1.250/PortalClientes/Views/frmMetricasEstadisticas.aspx/GetCategoriasPeriodo"; // API URL
    const urlCLT = getUrlCLT(); // API URL

    let objCLT = JSON.stringify({
        meses: $("#ContentPlaceHolder1_ddlCategoriasLT").val(),
    });

    ajax_dataCLT(objCLT, urlCLT, function (data) {
        chartsCLT(data); // Pie Charts
    });

    window.onresize = function () {
        ajax_dataCLT(objCLT, urlCLT, function (data) {
            charts(data); // Pie Charts
        });
    };
});

function getUrlCLT() {
    let value = window.location + "/GetCategoriasPeriodo";
    return value;
}

$('#ContentPlaceHolder1_ddlCategoriasLT').click(function (event) {
    event.preventDefault();
    ActualizarGraficaCLT();
});

function ActualizarGraficaCLT() {
    const urlCLT = getUrl(); // API URL
    let objCLT = JSON.stringify({
        meses: $("#ContentPlaceHolder1_ddlPeriodo").val(),
    });

    ajax_dataCLT(objCLT, urlCLT, function (data) {
        chartsCLT(data, "PieChart"); // Pie Charts
    });
}

function ajax_dataCLT(obj, url, success) {
    $.ajax({
        data: obj,
        contentType: "Application/json; charset=utf-8",
        responseType: "json",
        method: 'POST',
        url: url,
        dataType: "json",
        beforeSend: function (response) { },
        success: function (response) {
            success.call(this, response.d);
        },
        error: function (err) {
            console.log("Error In Connecting", err);
        }
    });
}

function chartsCLT(data) {
    var jsonDataCLT = data;
    
    if (jsonDataCLT.length > 0) {
        google.charts.load("current", { packages: ["corechart"] });
        google.charts.setOnLoadCallback(drawVisualizationCLT)
    }

    function generarUrlCLT(obtiene) {
        var url = "";

        if (obtiene) {
            if (window.location.host.includes("localhost")) {
                url = "/Views/frmTransacciones.aspx/ObtenerTransacciones";
            } else {
                url = "/PortalClientes/Views/frmTransacciones.aspx/ObtenerTransacciones";
            }
        }
        else {
            if (window.location.host.includes("localhost")) {
                url = "/Views/frmTransacciones.aspx";
            } else {
                url = "/PortalClientes/Views/frmTransacciones.aspx";
            }
        }

        return url;
    }


    function drawVisualizationCLT() {

        var screenWidth = screen.width;

        var data = google.visualization.arrayToDataTable([
            [ {label: 'Mes', id: 'mes'},
              {label: 'CAPITAL', id: 'CAPITAL', type: 'number'},
              {label: 'CUOTA', id: 'CUOTA', type: 'number'},
              {label: 'DIVERSOS', id: 'DIVERSOS', type: 'number'},
              {label: 'IMPUESTOS Y DERECHOS', id: 'IMPUESTOS Y DERECHOS', type: 'number'},
              {label: 'MANTENIMIENTO', id: 'MANTENIMIENTO', type: 'number'},
              {label: 'SEGUROS', id: 'SEGUROS', type: 'number'},
              {label: 'VIAJE', id: 'VIAJE', type: 'number'},
              {label: 'OTHER', id: 'OTHER', type: 'number'} ],
            ['ENERO', 21000, 40330,53234,32542,23564,54677,34554,33223],
            ['FEBRERO', 23430, 40330,53234,32542,23564,24677,34554,54333],
            ['MARZO', 25634, 40330,53234,32542,23564,25477,34554,44633],
            ['ABRIL', 34674, 40330,53234,32542,23564,25467,34554,43655],
            ['MAYO', 12345, 40330,53234,32542,23564,25677,34554,46433],
            ['JUNIO', 32432, 40330,53234,32542,23564,25677,34554,45744],
            ['JULIO', 34567, 40330,53234,32542,23564,25677,34554,42377],
            ['AGOSTO', 45678, 40330,53234,32542,23564,24677,34554,37456],
            ['SEPTIEMBRE', 67534, 40330,53234,32542,23564,25467,34554,23467],
            ['OCTUBRE', 34567, 44455,34673,64533,36789,12349,23789,34532],
            ['NOVIEMBRE', 21456, 34455,56334,65444,34599,47891,35783,43525],
            ['DICIEMBRE', 53454, 23453,32432,34571,23123,12322,23211,65432],
        ]);


        var options = {
            title: "Categorias a lo Largo del Tiempo",//jsonData[0].idioma == "es-MX" ? "Categorias a lo Largo del Tiempo" : "Expenses Categories Over Time",
            bar: {
                groupWidth: "60%",
            },
            isStacked: true,
            fontSize: 9,
            chartArea: {
                left: screenWidth > 500 ? 30 : 10,
                top: 30,
                width: '100%',
                height: '75%'
            },
            animation: {
                duration: 3000,
                easing: 'out',
                startup: true
            },
            legend: {
                position: 'bottom',
                alignment: 'center',
                maxLines: 20,
            },
            colors: ['#3276ae', '#6aabc0', '#cf575e', '#eb924f', '#f6c543', '#d578a9', '#9889d1', '#89d193']
        };

        var chart = new google.visualization.ColumnChart(document.getElementById('piechart_3d_17'));
        chart.draw(data, options);

        google.visualization.events.addListener(chart, 'select', function () {
            var selection = chart.getSelection();
            if (selection.length) {
                var row = selection[0].row;

                let array = jsonData[row];
                const gastos = array.Gastos

                let opt = {}//campos opcionales en graficas

                let vuelos = []
                let gastosAe = []
                let gastosProv = []
                let costos = []
                let horasV = []
                let novuelos = []
                let paxs = []
                let gastosT = []
                let costoH = []
                let costosFV = []
                let costosFVH = []

                let obj = JSON.stringify({
                    vuelos,
                    gastos,
                    gastosAe,
                    gastosProv,
                    costos,
                    paxs,
                    horasV,
                    novuelos,
                    costosFV,
                    gastosT,
                    costoH,
                    costosFVH,
                    tipoTrans: 1,
                    tipoDet: "MXN",
                    descES: array.rubroESP,
                    descEN: array.rubroENG,
                    origen: 2,
                    opt,
                });

                $.ajax({
                    data: obj,
                    contentType: "Application/json; charset=utf-8",
                    responseType: "json",
                    method: 'POST',
                    url: generarUrl(true),
                    dataType: "json",
                    success: function (response) {
                        window.location.pathname = generarUrl(false);
                    },
                    error: function (err) {
                        console.log("Error In Connecting", err);
                    }
                });
            }
        });
    }
}


function hometab_Click(){
    document.getElementById("ContentPlaceHolder1_lbTitleMapR").style.display = 'block';
    document.getElementById("ContentPlaceHolder1_lbTitleMapA").style.display = 'none';
}

function profiletab_Click(){
    document.getElementById("ContentPlaceHolder1_lbTitleMapA").style.display = 'block';
    document.getElementById("ContentPlaceHolder1_lbTitleMapR").style.display = 'none';
}


