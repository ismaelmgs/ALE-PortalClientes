$(document).ready(function () {
    //const url = "http://192.168.1.250/PortalClientes/Views/frmMetricasEstadisticas.aspx/GetNumeroVuelos"; // API URL
    const url = getUrlNV(); // API URL

    let objNV = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesNV").val(),
    });

    ajax_dataNV(objNV, url, function (dataNV) {
        chartsProv(dataNV , "PieChart"); // Pie Charts
    });

    window.onresize = function () {
        ajax_dataNV(objNV, url, function (dataNV) {
            chartsNV(dataNV, "PieChart"); // Pie Charts
        });
    };
});

function getUrlNV() {
    let value = window.location + "/GetNumeroVuelos";
    return value;
}

$('#btnGraficasBuscarNV').click(function (event) {

    event.preventDefault();
    ActualizarGraficaNV();

});

function ActualizarGraficaNV() {
    const url = getUrlP(); // API URL
    let objNV = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesNV").val(),
    });

    ajax_dataNV(objNV, url, function (dataNV) {
        chartsNV(dataNV, "PieChart"); // Pie Charts
    });
}

function ajax_dataNV(objNV, url, success) {
    $.ajax({
        data: objNV,
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

function chartsNV(dataNV, ChartType) {
    var c = ChartType;
    var jsonDataNV = dataNV;

    if (jsonDataNV.length > 0) {
        google.charts.load("current", { packages: ["corechart"] });
        google.charts.setOnLoadCallback(drawVisualizationNV)
    }
    
    function generarUrlNV(obtiene) {
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

    function drawVisualizationNV() {

        var screenWidth = screen.width;

        var dataNV_ = new google.visualization.DataTable();
        dataNV_.addColumn('string', 'NVedor');
        dataNV_.addColumn('number', 'Gastos');
        dataNV_.addColumn({ type: 'string', role: 'tooltip' });

        const opt = { style: 'currency', currency: 'MXN' };
        var numberFormat = new Intl.NumberFormat('es-MX', opt);

        const opt2 = { style: 'currency', currency: 'USD' };
        const numberFormat2 = new Intl.NumberFormat('en-US', opt2);

        jsonDataNV.forEach((item, index) => {
            if (jsonDataNV[0].idioma == "es-MX") {
                dataNV_.addRows([[item.rubroESP, item.totalMXN, `${item.rubroESP} - ${numberFormat.format(item.totalMXN)} MXN`,]]);
            } else {
                dataNV_.addRows([[item.rubroENG, item.totalMXN, `${item.rubroENG} - ${numberFormat.format(item.totalMXN)} MXN`,]]);
            }
        });

        var optionsNV = {
            title: jsonDataNV[0].idioma == "es-MX" ? "No. de Vuelos" : "No. of Flights",
            bar: {
                groupWidth: "95%",
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

        var chartNV = new google.visualization.ColumnChart(document.getElementById('piechart_3d_13'));
        chartNV.draw(dataNV_, optionsNV);

        google.visualization.events.addListener(optionsNV, 'select', function () {
            var selection = chartNV.getSelection();
            if (selection.length) {
                var row = selection[0].row;

                let array = jsonDataNV[row];
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
                    url: generarUrlNV(true),
                    dataType: "json",
                    success: function (response) {
                        window.location.pathname = generarUrlNV(false);
                    },
                    error: function (err) {
                        console.log("Error In Connecting", err);
                    }
                });
            }
        });
    }
}

