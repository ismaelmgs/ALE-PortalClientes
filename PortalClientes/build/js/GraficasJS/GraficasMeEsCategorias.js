$(document).ready(function () {
    //const url = "http://192.168.1.250/PortalClientes/Views/frmMetricasEstadisticas.aspx/GetCategoriasPeriodo"; // API URL
    const urlCLT = getUrlCLT(); // API URL

    let objCLT = JSON.stringify({
        meses: $("#ContentPlaceHolder1_ddlCategoriasLT").val(),
    });

    ajax_data(objCLT, urlCLT, function (data) {
        charts(data); // Pie Charts
    });

    window.onresize = function () {
        ajax_data(objCLT, urlCLT, function (data) {
            charts(data); // Pie Charts
        });
    };
});

function getUrlCLT() {
    let value = window.location + "/GetCategoriasPeriodo";
    return value;
}

$('#btnGraficasBuscar').click(function (event) {

    event.preventDefault();
    ActualizarGrafica();

});

function ActualizarGrafica() {
    const url = getUrl(); // API URL
    let obj = JSON.stringify({
        meses: $("#ContentPlaceHolder1_ddlPeriodo").val(),
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

function charts(data) {
    var jsonData = data;
    
    if (jsonData.length > 0) {
        google.charts.load("current", { packages: ["corechart"] });
        google.charts.setOnLoadCallback(drawVisualization)
    }

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

        var data = google.visualization.arrayToDataTable([
            [ {label: 'Year', id: 'year'},
              {label: 'Sales', id: 'Sales', type: 'number'}, // Use object notation to explicitly specify the data type.
              {label: 'Expenses', id: 'Expenses', type: 'number'} ],
            ['2014', 1000, 400],
            ['2015', 1170, 460],
            ['2016', 660, 1120],
            ['2017', 1030, 540]]);

        // const opt = { style: 'currency', currency: 'MXN' };
        // var numberFormat = new Intl.NumberFormat('es-MX', opt);

        // jsonData.forEach((item, index) => {

        //     if (jsonData[0].idioma == "es-MX") {
        //         data.addRows([[item.rubroESP, item.totalMXN, `${item.rubroESP} - ${numberFormat.format(item.totalMXN)} MXN`,]]);
        //     } else {
        //         data.addRows([[item.rubroENG, item.totalMXN, `${item.rubroENG} - ${numberFormat.format(item.totalMXN)} MXN`,]]);
        //     }

        // });

        var options = {
            title: jsonData[0].idioma == "es-MX" ? "Categorias a lo Largo del Tiempo" : "Expenses Categories Over Time",
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
                maxLines: 20,
            },
            colors: ['#3276ae', '#6aabc0', '#cf575e', '#eb924f', '#f6c543', '#d578a9', '#9889d1', '#89d193']
        };

        var chart = new google.visualization.ColumnChart(document.getElementById('piechart_3d_1'));
        chart.draw(data, options);

        google.visualization.events.addListener(chart, 'select', function () {
            var selection = chart.getSelection();
            if (selection.length) {
                var row = selection[0].row;

                let array = jsonData[row];
                const gastos = array.Gastos

                let opt = {}//campos opcionales en graficas

                let vuelos = []
                let gastosAe = []
                let gastosProv = []
                let costos = []
                let horasV = []
                let novuelos = []
                let paxs = []
                let gastosT = []
                let costoH = []
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
                    tipoTrans: 1,
                    tipoDet: "MXN",
                    descES: array.rubroESP,
                    descEN: array.rubroENG,
                    origen: 2,
                    opt,
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


