$(document).ready(function () {
    //const url = "http://192.168.1.250/PortalClientes/Views/frmMetricasEstadisticas.aspx/GetHorasVoladas"; // API URL
    const url = getUrlHV(); // API URL

    let objHV = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesHV").val(),
    });

    ajax_dataHV(objHV, url, function (dataHV) {
        chartsHV(dataHV , "PieChart"); // Pie Charts
    });

    window.onresize = function () {
        ajax_dataHV(objHV, url, function (dataHV) {
            chartsHV(dataHV, "PieChart"); // Pie Charts
        });
    };
});

function getUrlHV() {
    let value = window.location + "/GetHorasVoladas";
    return value;
}

$('#btnGraficasBuscarHV').click(function (event) {

    event.preventDefault();
    ActualizarGraficaHV();

});

function ActualizarGraficaHV() {
    const url = getUrlHV(); // API URL
    let objHV = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesHV").val(),
    });

    ajax_dataHV(objHV, url, function (dataHV) {
        chartsHV(dataHV, "PieChart"); // Pie Charts
    });
}

function ajax_dataHV(objHV, url, success) {
    $.ajax({
        data: objHV,
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

function chartsHV(dataHV, ChartType) {
    var c = ChartType;
    var jsonDataHV = dataHV;

    if (jsonDataHV.length > 0) {
        google.charts.load("current", { packages: ["corechart"] });
        google.charts.setOnLoadCallback(drawVisualizationHV)
    }
    
    function generarUrlHV(obtiene) {
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

    function drawVisualizationHV() {

        var screenWidth = screen.width;

        var dataHV_ = new google.visualization.DataTable();
        dataHV_.addColumn('string', 'Meses');
        dataHV_.addColumn('number', 'Horas');
        dataHV_.addColumn({ type: 'string', role: 'tooltip' });

        jsonDataHV.forEach((item, index) => {

            if (jsonDataHV[0].idioma == "es-MX") {
                dataHV_.addRows([[item.nombreESP, item.totalTiempo, `${item.nombreESP} - ${item.totalTiempo} Horas Voladas`,]]);
            } else {
                dataHV_.addRows([[item.nombreENG, item.totalTiempo, `${item.nombreENG} - ${item.totalTiempo} Flight Hours`,]]);
            }
        });

        var optionsHV = {
            title: jsonDataHV[0].idioma == "es-MX" ? "Horas Voladas" : "Flight Hours",
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

        var chartHV = new google.visualization.ColumnChart(document.getElementById('piechart_3d_14'));
        chartHV.draw(dataHV_, optionsHV);

        google.visualization.events.addListener(chartHV, 'select', function () {
            var selection = chartHV.getSelection();
            if (selection.length) {
                var row = selection[0].row;

                let array = jsonDataHV[row];
                const gastosProv = array.gastos

                let vuelos = []

                let gastos = []

                let gastosAe = []

                let obj = JSON.stringify({
                    vuelos,
                    gastos,
                    gastosAe,
                    gastosProv,
                    tipoTrans: 3,
                    tipoDet: "MXN",
                    descES: array.proveedor,
                    descEN: array.proveedor,
                    origen: 2,
                });

                $.ajax({
                    data: obj,
                    contentType: "Application/json; charset=utf-8",
                    responseType: "json",
                    method: 'POST',
                    url: generarUrlProve(true),
                    dataType: "json",
                    success: function (response) {
                        window.location.pathname = generarUrlHV(false);
                    },
                    error: function (err) {
                        console.log("Error In Connecting", err);
                    }
                });
            }
        });
    }
}


