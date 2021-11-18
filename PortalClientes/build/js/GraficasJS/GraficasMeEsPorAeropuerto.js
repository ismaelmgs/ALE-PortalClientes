$(document).ready(function () {
    //const url = "http://192.168.1.250/PortalClientes/Views/frmMetricasEstadisticas.aspx/GetGastos"; // API URL
    const url = getUrlA(); // API URL

    let objAe = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesPA").val(),
    });

    ajax_data(objAe, url, function (dataAe) {
        chartsAe(dataAe, "PieChart"); // Pie Charts
    });

    window.onresize = function () {
        ajax_data(objAe, url, function (dataAe) {
            chartsAe(dataAe, "PieChart"); // Pie Charts
        });
    };
});

function getUrlA() {
    let value = window.location + "/GetGastosAeropuerto";
    return value;
}

$('#btnGraficasBuscarPA').click(function (event) {

    event.preventDefault();
    ActualizarGraficaAe();

});

function ActualizarGraficaAe() {
    const url = getUrlA(); // API URL
    let objAe = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesPA").val(),
    });

    ajax_data(objAe, url, function (dataAe) {
        chartsAe(dataAe, "PieChart"); // Pie Charts
    });
}

function ajax_data(objAe, url, success) {
    $.ajax({
        data: objAe,
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

function chartsAe(dataAe, ChartType) {
    var c = ChartType;
    var jsonDataAe = dataAe;
    google.charts.load("current", { packages: ["corechart"] });
    google.charts.setOnLoadCallback(drawVisualizationAe)

    function generarUrlAe(obtiene) {
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

    function drawVisualizationAe() {

        var screenWidth = screen.width;

        var dataAe_ = new google.visualization.DataTable();
        dataAe_.addColumn('string', 'Aeropuertos');
        dataAe_.addColumn('number', 'Costos');
        dataAe_.addColumn({ type: 'string', role: 'tooltip' });

        const opt = { style: 'currency', currency: 'MXN' };
        var numberFormat = new Intl.NumberFormat('es-MX', opt);

        const opt2 = { style: 'currency', currency: 'USD' };
        const numberFormat2 = new Intl.NumberFormat('en-US', opt2);

        jsonDataAe.forEach((item, index) => {
            dataAe_.addRows([[item.aeropuerto, item.totalMXN, `${item.aeropuerto} - ${numberFormat.format(item.totalMXN)} MXN`,]]);
        });

        var optionsAe = {
            title: jsonDataAe[0].idioma == "es-MX" ? "Gastos por Aeropuerto" : "Expenses by Airport",
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

        var chartAero = new google.visualization.PieChart(document.getElementById('piechart_3d_4'));
        chartAero.draw(dataAe_, optionsAe);

        google.visualization.events.addListener(chartAero, 'select', function () {
            var selection = chartAero.getSelection();
            if (selection.length) {
                var row = selection[0].row;

                let array = jsonDataAe[row];
                const gastosAe = array.gastos

                let vuelos = []
                let gastos = []
                let gastosProv = []
                let costos = []
                let horasV = []
                let novuelos = []
                let paxs = []
                let costosFV = []
                let gastosT = []
                let costoH = []

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
                    tipoTrans: 2,
                    tipoDet: "MXN",
                    descES: array.aeropuerto,
                    descEN: array.aeropuerto,
                    origen: 2,
                });

                $.ajax({
                    data: obj,
                    contentType: "Application/json; charset=utf-8",
                    responseType: "json",
                    method: 'POST',
                    url: generarUrlAe(true),
                    dataType: "json",
                    success: function (response) {
                        window.location.pathname = generarUrlAe(false);
                    },
                    error: function (err) {
                        console.log("Error In Connecting", err);
                    }
                });
            }
        });
    }
}


