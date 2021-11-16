$(document).ready(function () {
    //const url = "http://192.168.1.250/PortalClientes/Views/frmMetricasEstadisticas.aspx/GetPromedioPasajeros"; // API URL
    const urlPP = getUrlPP(); // API URL

    let objPP = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesPP").val(),
    });

    ajax_dataPP(objPP, urlPP, function (dataPP) {
        chartsPP(dataPP , "PieChart"); // Pie Charts
    });

    window.onresize = function () {
        ajax_dataPP(objPP, urlPP, function (dataPP) {
            chartsPP(dataPP, "PieChart"); // Pie Charts
        });
    };
});

function getUrlPP() {
    let value = window.location + "/GetPromedioPasajeros";
    return value;
}

$('#btnGraficasBuscarPP').click(function (event) {

    event.preventDefault();
    ActualizarGraficaPP();

});

function ActualizarGraficaPP() {
    const urlPP = getUrlPP(); // API URL
    let objPP = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesPP").val(),
    });

    ajax_dataPP(objPP, urlPP, function (dataPP) {
        chartsPP(dataPP, "PieChart"); // Pie Charts
    });
}

function ajax_dataPP(objPP, urlPP, success) {
    $.ajax({
        data: objPP,
        contentType: "Application/json; charset=utf-8",
        responseType: "json",
        method: 'POST',
        url: urlPP,
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

function chartsPP(dataPP, ChartType) {
    var c = ChartType;
    var jsonDataPP = dataPP;

    if (jsonDataPP.length > 0) {
        google.charts.load("current", { packages: ["corechart"] });
        google.charts.setOnLoadCallback(drawVisualizationPP)
    }
    
    function generarUrlPP(obtiene) {
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

    function drawVisualizationPP() {

        var screenWidth = screen.width;

        var dataPP_ = new google.visualization.DataTable();
        dataPP_.addColumn('string', 'Meses');
        dataPP_.addColumn('number', 'Promedio');
        dataPP_.addColumn({ type: 'string', role: 'tooltip' });

        jsonDataPP.forEach((item, index) => {
            if (jsonDataPP[0].idioma == "es-MX") {
                dataPP_.addRows([[item.nombreESP, item.promPax, `Promedio en ${item.nombreESP} - ${item.promPax} pasajeros`,]]);
            } else {
                dataPP_.addRows([[item.nombreENG, item.promPax, `Average in ${item.nombreENG} - ${item.promPax} passengers`,]]);
            }
        });

        var optionsPP = {
            title: jsonDataPP[0].idioma == "es-MX" ? "Promedio Pasajeros" : "Average Passengers",
            bar: {
                groupWidth: "60%",
            },
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
            },
            colors: ['#3276ae', '#6aabc0', '#cf575e', '#eb924f', '#f6c543', '#d578a9', '#9889d1', '#89d193']
        };

        var chartPP = new google.visualization.ColumnChart(document.getElementById('piechart_3d_15'));
        chartPP.draw(dataPP_, optionsPP);

        google.visualization.events.addListener(chartPP, 'select', function () {
            var selection = chartPP.getSelection();
            if (selection.length) {
                var row = selection[0].row;

                let array = jsonDataPP[row];
                const costos = array.costos

                let vuelos = []

                let gastos = []

                let gastosAe = []

                let gastosProv = []

                let obj = JSON.stringify({
                    vuelos,
                    gastos,
                    gastosAe,
                    gastosProv,
                    costos,
                    tipoTrans: 3,
                    tipoDet: "MXN",
                    descES: array.nombreESP,
                    descEN: array.nombreENG,
                    origen: 2,
                });

                $.ajax({
                    data: obj,
                    contentType: "Application/json; charset=utf-8",
                    responseType: "json",
                    method: 'POST',
                    url: generarUrlPP(true),
                    dataType: "json",
                    success: function (response) {
                        window.location.pathname = generarUrlPP(false);
                    },
                    error: function (err) {
                        console.log("Error In Connecting", err);
                    }
                });
            }
        });
    }
}


