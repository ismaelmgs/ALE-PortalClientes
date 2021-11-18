$(document).ready(function () {
    //const url = "http://192.168.1.250/PortalClientes/Views/frmMetricasEstadisticas.aspx/GetCostosFijoVariable"; // API URL
    const urlFV = getUrlFV(); // API URL

    let objFV = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesFV").val(),
    });

    ajax_dataFV(objFV, urlFV, function (dataFV) {
        chartsFV(dataFV , "PieChart"); // Pie Charts
    });

    window.onresize = function () {
        ajax_dataFV(objFV, urlFV, function (dataFV) {
            chartsFV(dataFV, "PieChart"); // Pie Charts
        });
    };
});

function getUrlFV() {
    let value = window.location + "/GetCostosFijoVariable";
    return value;
}

$('#ContentPlaceHolder1_DDFiltroMesesFV').change(function (event) {

    event.preventDefault();
    ActualizarGraficaFV();

});

function ActualizarGraficaFV() {
    const urlFV = getUrlFV(); // API URL
    let objFV = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesFV").val(),
    });

    ajax_dataFV(objFV, urlFV, function (dataFV) {
        chartsFV(dataFV, "PieChart"); // Pie Charts
    });
}

function ajax_dataFV(objFV, urlFV, success) {
    $.ajax({
        data: objFV,
        contentType: "Application/json; charset=utf-8",
        responseType: "json",
        method: 'POST',
        url: urlFV,
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

function chartsFV(dataFV, ChartType) {
    var c = ChartType;
    var jsonDataFV = dataFV;

    if (jsonDataFV.length > 0) {
        google.charts.load("current", { packages: ["corechart"] });
        google.charts.setOnLoadCallback(drawVisualizationFV)
    }
    
    function generarUrlFV(obtiene) {
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

    function drawVisualizationFV() {

        var screenWidth = screen.width;

        var dataFV_ = new google.visualization.DataTable();
        dataFV_.addColumn('string', 'Categoria');
        dataFV_.addColumn('number', jsonDataFV[0].idioma == "es-MX" ? "Costos" : "Costs");
        dataFV_.addColumn({ type: 'string', role: 'tooltip' });

        jsonDataFV.forEach((item, index) => {
            if (jsonDataFV[0].idioma == "es-MX") {
                dataFV_.addRows([[item.categoria, item.noGastos, `Total de Costos ${ item.noGastos } por ${ item.categoria }`,]]);
            } else {
                dataFV_.addRows([[item.categoria, item.noGastos, `Total costs ${ item.noGastos } by ${ item.categoria }`,]]);
            }
        });

        var optionsFV = {
            title: jsonDataFV[0].idioma == "es-MX" ? "Costo Fijo y Variable" : "Fixed and Variable Cost",
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

        var chartFV = new google.visualization.ColumnChart(document.getElementById('piechart_3d_7'));
        chartFV.draw(dataFV_, optionsFV);

        google.visualization.events.addListener(chartFV, 'select', function () {
            var selection = chartFV.getSelection();
            if (selection.length) {
                var row = selection[0].row;

                let array = jsonDataFV[row];
                const costosFV = array.costos

                let vuelos = []
                let gastos = []
                let gastosAe = []
                let gastosProv = []
                let costos = []
                let horasV = []
                let novuelos = []
                let paxs = []
                let gastosT = []

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
                    url: generarUrlFV(true),
                    dataType: "json",
                    success: function (response) {
                        window.location.pathname = generarUrlFV(false);
                    },
                    error: function (err) {
                        console.log("Error In Connecting", err);
                    }
                });
            }
        });
    }
}


