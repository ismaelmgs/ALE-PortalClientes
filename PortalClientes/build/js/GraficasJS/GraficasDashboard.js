$(document).ready(function () {
    //const url = "http://192.168.1.250/PortalClientes/Views/frmDashboard.aspx/GetGastos"; // API URL
    const url = getUrl(); // API URL
    
    let obj = JSON.stringify({
        meses: $("#ContentPlaceHolder1_ddlPeriodo").val(),
        rubro: '',
        tipoRubro: $("#ContentPlaceHolder1_ddlTipoRubro").val() // 1.fijo 2. var 3. todos
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
    let value = window.location + "/GetGastos";
    return value;
}

$('#ContentPlaceHolder1_ddlPeriodo').change(function (event) {
    event.preventDefault();
    ActualizarGrafica();
});

$('#ContentPlaceHolder1_ddlTipoRubro').change(function (event) {
    event.preventDefault();
    ActualizarGrafica();
});

function ActualizarGrafica() {
    const url = getUrl(); // API URL
    let obj = JSON.stringify({
        meses: $("#ContentPlaceHolder1_ddlPeriodo").val(),
        rubro: '',
        tipoRubro: $("#ContentPlaceHolder1_ddlTipoRubro").val() // 1.fijo 2. var 3. todos
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

        var data = new google.visualization.DataTable();
        data.addColumn('string', 'Categoria');
        data.addColumn('number', 'Costos');
        data.addColumn({ type: 'string', role: 'tooltip' });

        var dataE = new google.visualization.DataTable();
        dataE.addColumn('string', 'Category');
        dataE.addColumn('number', 'Costs');
        dataE.addColumn({ type: 'string', role: 'tooltip' });

        const opt = { style: 'currency', currency: 'MXN' };
        var numberFormat = new Intl.NumberFormat('es-MX', opt);

        const opt2 = { style: 'currency', currency: 'USD' };
        const numberFormat2 = new Intl.NumberFormat('en-US', opt2);

        jsonData.forEach((item, index) => {

            if (jsonData[0].idioma == "es-MX") {
                data.addRows([[item.rubroESP, item.totalMXN, `${item.rubroESP} - ${numberFormat.format(item.totalMXN)} MXN`,]]);
                dataE.addRows([[item.rubroESP, item.totalUSD, `${item.rubroESP} - ${numberFormat2.format(item.totalUSD)} USD`,]]);
            } else {
                data.addRows([[item.rubroENG, item.totalMXN, `${item.rubroENG} - ${numberFormat.format(item.totalMXN)} MXN`,]]);
                dataE.addRows([[item.rubroENG, item.totalUSD, `${item.rubroENG} - ${numberFormat2.format(item.totalUSD)} USD`,]]);
            }
            
        });

        var options = {
            title: jsonData[0].idioma == "es-MX" ? "Costos por Categoria MXN" : "Costs by Category MXN",
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

        var optionsE = {
            title: jsonData[0].idioma == "es-MX" ? "Costos por Categoria USD" : "Costs by Category USD",
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

        var chart = new google.visualization.PieChart(document.getElementById('piechart_3d_1'));
        chart.draw(data, options);

        var chartE = new google.visualization.PieChart(document.getElementById('piechart_3d_2'));
        chartE.draw(dataE, optionsE);

        google.visualization.events.addListener(chart, 'select', function () {
            var selection = chart.getSelection();
            if (selection.length) {
                var row = selection[0].row;

                let array = jsonData[row];
                const gastos = array.Gastos

                let opt = {
                    campo1: null,
                    campo2: null,
                }//campos opcionales en graficas

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
                let detGasto = []

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
                    detGasto,
                    tipoTrans: 1,
                    tipoDet: "MXN",
                    descES: array.rubroESP,
                    descEN: array.rubroENG,
                    origen: 1,
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

        google.visualization.events.addListener(chartE, 'select', function () {
            var selection = chartE.getSelection();
            if (selection.length) {
                var row = selection[0].row;

                let array = jsonData[row];
                const gastos = array.Gastos

                let opt = {
                    campo1: null,
                    campo2: null,
                }//campos opcionales en graficas

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
                let detGasto = []

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
                    detGasto,
                    tipoTrans: 1,
                    tipoDet: "USD",
                    descES: array.rubroESP,
                    descEN: array.rubroENG,
                    origen: 1,
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


