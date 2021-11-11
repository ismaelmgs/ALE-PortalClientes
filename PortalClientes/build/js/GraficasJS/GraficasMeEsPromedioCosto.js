$(document).ready(function () {
    //const url = "http://192.168.1.250/PortalClientes/Views/frmMetricasEstadisticas.aspx/GetPromedioCostos"; // API URL
    const url = getUrlPC(); // API URL

    let objPC = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesPC").val(),
    });

    ajax_dataPC(objPC, url, function (dataPC) {
        chartsPC(dataPC , "PieChart"); // Pie Charts
    });

    window.onresize = function () {
        ajax_dataPC(objPC, url, function (dataPC) {
            chartsPC(dataPC, "PieChart"); // Pie Charts
        });
    };
});

function getUrlPC() {
    let value = window.location + "/GetPromedioCostos";
    return value;
}

$('#btnGraficasBuscarPC').click(function (event) {

    event.preventDefault();
    ActualizarGraficaPC();

});

function ActualizarGraficaPC() {
    const url = getUrlPC(); // API URL
    let objPC = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesPC").val(),
    });

    ajax_dataPC(objPC, url, function (dataPC) {
        chartsPC(dataPC, "PieChart"); // Pie Charts
    });
}

function ajax_dataPC(objPC, url, success) {
    $.ajax({
        data: objPC,
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

function chartsPC(dataPC, ChartType) {
    var c = ChartType;
    var jsonDataPC = dataPC;

    if (jsonDataPC.length > 0) {
        google.charts.load("current", { packages: ["corechart"] });
        google.charts.setOnLoadCallback(drawVisualizationPC)
    }
    
    function generarUrlPC(obtiene) {
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

    function drawVisualizationPC() {

        var screenWidth = screen.width;

        var dataPC_ = new google.visualization.DataTable();
        dataPC_.addColumn('string', 'Proveedor');
        dataPC_.addColumn('number', 'Gastos');
        dataPC_.addColumn({ type: 'string', role: 'tooltip' });

        const opt = { style: 'currency', currency: 'MXN' };
        var numberFormat = new Intl.NumberFormat('es-MX', opt);

        const opt2 = { style: 'currency', currency: 'USD' };
        const numberFormat2 = new Intl.NumberFormat('en-US', opt2);

        jsonDataPC.forEach((item, index) => {
            if (jsonDataPC[0].idioma == "es-MX") {
                dataPC_.addRows([[item.rubroESP, item.totalMXN, `${item.rubroESP} - ${numberFormat.format(item.totalMXN)} MXN`,]]);
            } else {
                dataPC_.addRows([[item.rubroENG, item.totalMXN, `${item.rubroENG} - ${numberFormat.format(item.totalMXN)} MXN`,]]);
            }
        });

        var optionsPC = {
            title: jsonDataPC[0].idioma == "es-MX" ? "Promedio Costo" : "Average Cost",
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

        var chartPC = new google.visualization.ColumnChart(document.getElementById('piechart_3d_16'));
        chartPCdraw(dataPC_, optionsPC);

        google.visualization.events.addListener(chartPC, 'select', function () {
            var selection = chartPC.getSelection();
            if (selection.length) {
                var row = selection[0].row;

                let array = jsonDataPC[row];
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
                    url: generarUrlPC(true),
                    dataType: "json",
                    success: function (response) {
                        window.location.pathname = generarUrlPC(false);
                    },
                    error: function (err) {
                        console.log("Error In Connecting", err);
                    }
                });
            }
        });
    }
}


