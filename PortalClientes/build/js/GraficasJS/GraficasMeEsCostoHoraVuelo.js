$(document).ready(function () {
    //const url = "http://192.168.1.250/PortalClientes/Views/frmMetricasEstadisticas.aspx/GetCostoHoraVuelo"; // API URL
    const urlCH = getUrlCH(); // API URL

    let objCH = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesCH").val(),
    });

    ajax_dataCH(objCH, urlCH, function (dataCH) {
        chartsCH(dataCH , "PieChart"); // Pie Charts
    });

    window.onresize = function () {
        ajax_dataCH(objCH, urlCH, function (dataCH) {
            chartsCH(dataCH, "PieChart"); // Pie Charts
        });
    };
});

function getUrlCH() {
    let value = window.location + "/GetCostoHoraVuelo";
    return value;
}

$('#ContentPlaceHolder1_DDFiltroMesesCH').change(function (event) {

    event.preventDefault();
    ActualizarGraficaCH();

});

function ActualizarGraficaCH() {
    const urlCH = getUrlCH(); // API URL
    let objCH = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesCH").val(),
    });

    ajax_dataCH(objCH, urlCH, function (dataCH) {
        chartsCH(dataCH, "PieChart"); // Pie Charts
    });
}

function ajax_dataCH(objCH, urlCH, success) {
    $.ajax({
        data: objCH,
        contentType: "Application/json; charset=utf-8",
        responseType: "json",
        method: 'POST',
        url: urlCH,
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

function chartsCH(dataCH, ChartType) {
    var c = ChartType;
    var jsonDataCH = dataCH;

    if (jsonDataCH.length > 0) {
        google.charts.load("current", { packages: ["corechart"] });
        google.charts.setOnLoadCallback(drawVisualizationCH)
    }
    
    function generarUrlCH(obtiene) {
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

    function drawVisualizationCH() {

        var screenWidth = screen.width;

        var dataCH_ = new google.visualization.DataTable();
        dataCH_.addColumn('string', 'Categoria');
        dataCH_.addColumn('number', jsonDataCH[0].idioma == "es-MX" ? "Costo Hora" : "Cost Hour");
        dataCH_.addColumn({ type: 'string', role: 'tooltip' });

        const opt = { style: 'currency', currency: 'MXN' };
        var numberFormat = new Intl.NumberFormat('es-MX', opt);

        jsonDataCH.forEach((item, index) => {
            if (jsonDataCH[0].idioma == "es-MX") {
                dataCH_.addRows([[item.nombreESP, item.totalGasto, `Costo de ${item.nombreESP} ${numberFormat.format(item.totalGasto)}`,]]);
            } else {
                dataCH_.addRows([[item.nombreENG, item.totalGasto, `Cost of ${item.nombreENG} ${numberFormat.format(item.totalGasto)}`,]]);
            }
        });

        var optionsCH = {
            title: jsonDataCH[0].idioma == "es-MX" ? "Costo por Hora de Vuelo" : "Cost per Flight Hour",
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

        var chartCH = new google.visualization.ColumnChart(document.getElementById('piechart_3d_10'));
        chartCH.draw(dataCH_, optionsCH);

        google.visualization.events.addListener(chartCH, 'select', function () {
            var selection = chartCH.getSelection();
            if (selection.length) {
                var row = selection[0].row;

                let array = jsonDataCH[row];
                const costoH = array.costos

                let opt = {
                    campo1: null,
                    campo2: null,
                }//campos opcionales en graficas

                let vuelos = []
                let gastos = []
                let gastosAe = []
                let gastosProv = []
                let costos = []
                let horasV = []
                let novuelos = []
                let paxs = []
                let gastosT = []
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
                    tipoTrans: 11,
                    tipoDet: "MXN",
                    descES: array.nombreESP,
                    descEN: array.nombreENG,
                    origen: 2,
                    opt,
                });

                $.ajax({
                    data: obj,
                    contentType: "Application/json; charset=utf-8",
                    responseType: "json",
                    method: 'POST',
                    url: generarUrlCH(true),
                    dataType: "json",
                    success: function (response) {
                        window.location.pathname = generarUrlCH(false);
                    },
                    error: function (err) {
                        console.log("Error In Connecting", err);
                    }
                });
            }
        });
    }
}


