$(document).ready(function () {
    //const url = "http://192.168.1.250/PortalClientes/Views/frmMetricasEstadisticas.aspx/GetCostosFijoVariableHora"; // API URL
    const urlFVH = getUrlFVH(); // API URL

    let objFVH = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesFVH").val(),
    });

    ajax_dataFVH(objFVH, urlFVH, function (dataFVH) {
        chartsFVH(dataFVH , "PieChart"); // Pie Charts
    });

    window.onresize = function () {
        ajax_dataFVH(objFVH, urlFVH, function (dataFVH) {
            chartsFVH(dataFVH, "PieChart"); // Pie Charts
        });
    };
});

function getUrlFVH() {
    let value = window.location + "/GetCostosFijoVariableHora";
    return value;
}

$('#ContentPlaceHolder1_DDFiltroMesesFVH').change(function (event) {

    event.preventDefault();
    ActualizarGraficaFVH();

});

function ActualizarGraficaFVH() {
    const urlFVH = getUrlFVH(); // API URL
    let objFVH = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesFVH").val(),
    });

    ajax_dataFVH(objFVH, urlFVH, function (dataFVH) {
        chartsFVH(dataFVH, "PieChart"); // Pie Charts
    });
}

function ajax_dataFVH(objFVH, urlFVH, success) {
    $.ajax({
        data: objFVH,
        contentType: "Application/json; charset=utf-8",
        responseType: "json",
        method: 'POST',
        url: urlFVH,
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

function chartsFVH(dataFVH, ChartType) {
    var c = ChartType;
    var jsonDataFVH = dataFVH;

    if (jsonDataFVH.length > 0) {
        google.charts.load("current", { packages: ["corechart"] });
        google.charts.setOnLoadCallback(drawVisualizationFVH)
    }
    
    function generarUrlFVH(obtiene) {
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

    function drawVisualizationFVH() {

        var screenWidth = screen.width;

        var dataFVH_ = new google.visualization.DataTable();
        dataFVH_.addColumn('string', 'Categoria');
        dataFVH_.addColumn('number', jsonDataFVH[0].idioma == "es-MX" ? "Costos" : "Costs");
        dataFVH_.addColumn({ type: 'string', role: 'tooltip' });

        jsonDataFVH.forEach((item, index) => {
            if (jsonDataFVH[0].idioma == "es-MX") {
                dataFVH_.addRows([[item.categoria, item.noGastos, `Total de Costos ${ item.noGastos } por ${ item.categoria }`,]]);
            } else {
                dataFVH_.addRows([[item.categoria, item.noGastos, `Total costs ${ item.noGastos } by ${ item.categoria }`,]]);
            }
        });

        var optionsFVH = {
            title: jsonDataFVH[0].idioma == "es-MX" ? "Costo Fijo y Variable por Hora" : "Fixed and Variable Cost Per Hour",
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

        var chartFVH = new google.visualization.PieChart(document.getElementById('piechart_3d_8'));
        chartFVH.draw(dataFVH_, optionsFVH);

        google.visualization.events.addListener(chartFVH, 'select', function () {
            var selection = chartFVH.getSelection();
            if (selection.length) {
                var row = selection[0].row;

                let array = jsonDataFVH[row];
                const costosFVH = array.costos

                let vuelos = []
                let gastos = []
                let gastosAe = []
                let gastosProv = []
                let costos = []
                let horasV = []
                let novuelos = []
                let paxs = []
                let gastosT = []
                let costoH = []
                let costosFV = []

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
                    tipoTrans: 9,
                    tipoDet: "MXN",
                    descES: array.categoria,
                    descEN: array.categoria,
                    origen: 2,
                });

                $.ajax({
                    data: obj,
                    contentType: "Application/json; charset=utf-8",
                    responseType: "json",
                    method: 'POST',
                    url: generarUrlFVH(true),
                    dataType: "json",
                    success: function (response) {
                        window.location.pathname = generarUrlFVH(false);
                    },
                    error: function (err) {
                        console.log("Error In Connecting", err);
                    }
                });
            }
        });
    }
}

