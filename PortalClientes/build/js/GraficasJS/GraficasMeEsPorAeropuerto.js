$(document).ready(function () {
    //const url = "http://192.168.1.250/PortalClientes/Views/frmMetricasEstadisticas.aspx/GetGastos"; // API URL
    const url = getUrl(); // API URL

    let obj = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesPA").val(),
    });

    ajax_data(obj, url, function (data) {
        charts(data, "PieChart"); // Pie Charts
    });

    window.onresize = function () {
        ajax_data(obj, url, function (data) {
            charts(data, "PieChart"); // Pie Charts
        });
    };
});

function getUrl() {
    let value = window.location + "/GetGastosAeropuerto";
    console.log(value);
    return value;
}

$('#btnGraficasBuscarPA').click(function (event) {

    event.preventDefault();
    ActualizarGrafica();

});

function ActualizarGrafica() {
    const url = getUrl(); // API URL
    let obj = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesPA").val(),
    });

    ajax_data(obj, url, function (data) {
        charts(data, "PieChart"); // Pie Charts
    });
}

function ajax_data(obj, url, success) {
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

function charts(data, ChartType) {
    var c = ChartType;
    var jsonData = data;
    google.charts.load("current", { packages: ["corechart"] });
    google.charts.setOnLoadCallback(drawVisualization)

    function generarUrl(obtiene) {
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

    function drawVisualization() {

        var screenWidth = screen.width;

        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Categoria');
        data.addColumn('number', 'Costos');
        data.addColumn({ type: 'string', role: 'tooltip' });

        const opt = { style: 'currency', currency: 'MXN' };
        var numberFormat = new Intl.NumberFormat('es-MX', opt);

        const opt2 = { style: 'currency', currency: 'USD' };
        const numberFormat2 = new Intl.NumberFormat('en-US', opt2);

        jsonData.forEach((item, index) => {

            if (jsonData[0].idioma == "es-MX") {
                data.addRows([[item.rubroESP, item.totalMXN, `${item.rubroESP} - ${numberFormat.format(item.totalMXN)} MXN`,]]);
            } else {
                data.addRows([[item.rubroENG, item.totalMXN, `${item.rubroENG} - ${numberFormat.format(item.totalMXN)} MXN`,]]);
            }

        });

        var options = {
            title: jsonData[0].idioma == "es-MX" ? "Gastos por Aeropuerto" : "Exoenses by Airport",
            is3D: true, //Pie Charts
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
        };

        var chart = new google.visualization.PieChart(document.getElementById('piechart_3d_4'));
        chart.draw(data, options);

        google.visualization.events.addListener(chart, 'select', function () {
            var selection = chart.getSelection();
            if (selection.length) {
                var row = selection[0].row;

                let array = jsonData[row];
                const gastos = array.Gastos

                let obj = JSON.stringify({
                    gastos: gastos,
                    tipoDet: "MXN",
                    rubroEsp: array.rubroESP,
                    rubroEng: array.rubroENG
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


