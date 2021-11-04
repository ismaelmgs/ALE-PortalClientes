$(document).ready(function () {
    //const url = "http://192.168.1.250/PortalClientes/Views/frmMetricasEstadisticas.aspx/GetGastos"; // API URL
    const url = getUrlP(); // API URL

    let objProve = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesPA").val(),
    });

    ajax_data(objProve, url, function (dataProve) {
        chartsProv(dataProve , "PieChart"); // Pie Charts
    });

    window.onresize = function () {
        ajax_data(objProve, url, function (dataProve) {
            chartsProv(dataProve, "PieChart"); // Pie Charts
        });
    };
});

function getUrlP() {
    let value = window.location + "/GetGastosProveedor";
    return value;
}

$('#btnGraficasBuscarPA').click(function (event) {

    event.preventDefault();
    ActualizarGraficaProve();

});

function ActualizarGraficaProve() {
    const url = getUrlP(); // API URL
    let objProve = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesPA").val(),
    });

    ajax_data(objProve, url, function (dataProve) {
        chartsProv(dataProve, "PieChart"); // Pie Charts
    });
}

function ajax_data(objProve, url, success) {
    $.ajax({
        data: objProve,
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

function chartsProv(dataProve, ChartType) {
    var c = ChartType;
    var jsonData = dataProve;

    if (jsonData.length > 0) {
        google.charts.load("current", { packages: ["corechart"] });
        google.charts.setOnLoadCallback(drawVisualizationProv)
    }
    
    function generarUrlProve(obtiene) {
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

    function drawVisualizationProv() {

        var screenWidth = screen.width;

        var dataProve_ = new google.visualization.DataTable();
        dataProve_.addColumn('string', 'Proveedor');
        dataProve_.addColumn('number', 'Gastos');
        dataProve_.addColumn({ type: 'string', role: 'tooltip' });

        const opt = { style: 'currency', currency: 'MXN' };
        var numberFormat = new Intl.NumberFormat('es-MX', opt);

        const opt2 = { style: 'currency', currency: 'USD' };
        const numberFormat2 = new Intl.NumberFormat('en-US', opt2);

        jsonData.forEach((item, index) => {
            dataProve_.addRows([[item.proveedor, item.totalMXN, `${item.proveedor} - ${numberFormat.format(item.totalMXN)} MXN`,]]);
        });

        var optionsProv = {
            title: jsonData[0].idioma == "es-MX" ? "Gastos por Proveedor" : "Expenses by Vendor",
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
            colors: ['#3276ae', '#6aabc0', '#cf575e', '#eb924f', '#f6c543', '#d578a9', '#9889d1', '#89d193']
        };

        var chartProveedor = new google.visualization.PieChart(document.getElementById('piechart_3d_3'));
        chartProveedor.draw(dataProve_, optionsProv);

        google.visualization.events.addListener(chartProveedor, 'select', function () {
            var selection = chartProveedor.getSelection();
            if (selection.length) {
                var row = selection[0].row;

                let array = jsonData[row];
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
                        window.location.pathname = generarUrlProve(false);
                    },
                    error: function (err) {
                        console.log("Error In Connecting", err);
                    }
                });
            }
        });
    }
}


