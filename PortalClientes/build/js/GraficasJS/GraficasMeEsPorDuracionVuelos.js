$(document).ready(function () {
    //const url = "http://192.168.1.250/PortalClientes/Views/frmMetricasEstadisticas.aspx/GetGastos"; // API URL
    const urlDV = getUrlDV(); // API URL

    let objDV = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesV").val(),
    });

    ajax_data(objDV, urlDV, function (dataDV) {
        chartsDV(dataDV, "PieChart"); // Pie Charts
    });

    window.onresize = function () {
        ajax_data(objDV, urlDV, function (dataDV) {
            chartsDV(dataDV, "PieChart"); // Pie Charts
        });
    };
});

function getUrlDV() {
    let value = window.location + "/GetDuracionVuelos";
    return value;
}

$('#btnGraficasBuscar').click(function (event) {

    event.preventDefault();
    ActualizarGraficaDV();

});

function ActualizarGraficaDV() {
    const urlDV = getUrlDV(); // API URL
    let objDV = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesV").val(),
    });

    ajax_data(objDV, urlDV, function (dataDV) {
        chartsDV(dataDV, "PieChart"); // Pie Charts
    });
}

function ajax_data(objDV, urlDV, success) {
    $.ajax({
        data: objDV,
        contentType: "Application/json; charset=utf-8",
        responseType: "json",
        method: 'POST',
        url: urlDV,
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

function chartsDV(dataDV, ChartType) {
    var c = ChartType;
    var jsonDataDV = dataDV;
    google.charts.load("current", { packages: ["corechart"] });
    google.charts.setOnLoadCallback(drawVisualizationDV)

    function generarUrlV(obtiene) {
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

    function drawVisualizationDV() {

        var screenWidth = screen.width;

        var dataDV_ = new google.visualization.DataTable();
        dataDV_.addColumn('string', 'tipo');
        dataDV_.addColumn('number', 'vuelos');
        dataDV_.addColumn({ type: 'string', role: 'tooltip' });

        jsonDataDV.forEach((item, index) => {

            if (jsonDataDV[0].idioma == "es-MX") {
                dataDV_.addRows([[item.descripcionESP, item.noVuelos, `Vuelo ${item.descripcionESP}: Total ${item.noVuelos}`,]]);
            } else {
                dataDV_.addRows([[item.descripcionENG, item.noVuelos, `Flight ${item.descripcionENG}: Total ${item.noVuelos}`,]]);
            }

        });

        var optionsDV = {
            title: jsonDataDV[0].idioma == "es-MX" ? "Vuelos por Duracion" : "Flight Duration",
            //is3D: true, //Pie Charts
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
                position: 'rigth',
                alignment: 'center',
            },
            colors: ['#3276ae', '#6aabc0', '#cf575e', '#eb924f', '#f6c543', '#d578a9', '#9889d1', '#89d193']
        };

        var chartDV = new google.visualization.PieChart(document.getElementById('piechart_3d_5'));
        chartDV.draw(dataDV_, optionsDV);

        google.visualization.events.addListener(chartDV, 'select', function () {
            var selection = chartDV.getSelection();
            if (selection.length) {
                var row = selection[0].row;

                let array = jsonDataDV[row];
                const vuelos = array.vuelos

                let gastosProv = []

                let gastos = []

                let gastosAe = []

                let obj = JSON.stringify({
                    vuelos,
                    gastos,
                    gastosAe,
                    gastosProv,
                    tipoTrans: 4,
                    tipoDet: "MXN",
                    descES: array.descripcionESP,
                    descEN: array.descripcionENG,
                    origen: 2,
                });

                $.ajax({
                    data: obj,
                    contentType: "Application/json; charset=utf-8",
                    responseType: "json",
                    method: 'POST',
                    url: generarUrlV(true),
                    dataType: "json",
                    success: function (response) {
                        window.location.pathname = generarUrlV(false);
                    },
                    error: function (err) {
                        console.log("Error In Connecting", err);
                    }
                });
            }
        });
    }
}


