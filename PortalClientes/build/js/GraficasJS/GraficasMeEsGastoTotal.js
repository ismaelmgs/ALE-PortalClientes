$(document).ready(function () {
    //const url = "http://192.168.1.250/PortalClientes/Views/frmMetricasEstadisticas.aspx/GetGastoTotales"; // API URL
    const urlGT = getUrlGT(); // API URL

    let objGT = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesGT").val(),
    });

    ajax_dataGT(objGT, urlGT, function (dataGT) {
        chartsGT(dataGT , "PieChart"); // Pie Charts
    });

    window.onresize = function () {
        ajax_dataGT(objGT, urlGT, function (dataGT) {
            chartsGT(dataGT, "PieChart"); // Pie Charts
        });
    };
});

function getUrlGT() {
    let value = window.location + "/GetGastoTotales";
    return value;
}

$('#ContentPlaceHolder1_DDFiltroMesesGT').change(function (event) {

    event.preventDefault();
    ActualizarGraficaGT();

});

function ActualizarGraficaGT() {
    const urlGT = getUrlGT(); // API URL
    let objGT = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesGT").val(),
    });

    ajax_dataGT(objGT, urlGT, function (dataGT) {
        chartsGT(dataGT, "PieChart"); // Pie Charts
    });
}

function ajax_dataGT(objGT, urlGT, success) {
    $.ajax({
        data: objGT,
        contentType: "Application/json; charset=utf-8",
        responseType: "json",
        method: 'POST',
        url: urlGT,
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

function chartsGT(dataGT, ChartType) {
    var c = ChartType;
    var jsonDataGT = dataGT;

    if (jsonDataGT.length > 0) {
        google.charts.load("current", { packages: ["corechart"] });
        google.charts.setOnLoadCallback(drawVisualizationGT)
    }else{
        let mensaje='';
        let leng = document.getElementById('txtLang').value
        if (leng == "es-MX") {
            mensaje="No Hay Datos Disponibles";
        }else{
            mensaje="No data available"
        }
        
        document.getElementById('piechart_3d_9').innerHTML = `<div class="alert alert-info mt-5 text-center" role="alert">${mensaje}</div>`;
    }
    
    function generarUrlGT(obtiene) {
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

    function drawVisualizationGT() {

        var screenWidth = screen.width;

        var dataGT_ = new google.visualization.DataTable();
        dataGT_.addColumn('string', 'Categoria');
        dataGT_.addColumn('number', jsonDataGT[0].idioma == "es-MX" ? "Gastos" : "Expense Total");
        dataGT_.addColumn({ type: 'string', role: 'tooltip' });

        const opt = { style: 'currency', currency: 'MXN' };
        var numberFormat = new Intl.NumberFormat('es-MX', opt);

        jsonDataGT.forEach((item, index) => {
            if (jsonDataGT[0].idioma == "es-MX") {
                dataGT_.addRows([[item.nombreESP, item.total, `Total de Gastos ${ numberFormat.format(item.total)} en ${item.nombreESP }`,]]);
            } else {
                dataGT_.addRows([[item.nombreENG, item.total, `Total Expenses ${ numberFormat.format(item.total)} in ${item.nombreENG }`,]]);
            }
        });

        const colorsList = ['#3276ae','#6aabc0','#cf575e','#eb924f','#f6c543','#d578a9','#9889d1','#89d193','#d1b089','#e48fea','#f4d583','#fea6c0','#94e6f2','#89c893','#ffe1a1']

        var optionsGT = {
            title: jsonDataGT[0].idioma == "es-MX" ? "Gastos Totales" : "Total Expenses",
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
            colors: colorsList.sort(function () { return 0.5 - Math.random() }),
        };

        var chartGT = new google.visualization.ColumnChart(document.getElementById('piechart_3d_9'));
        chartGT.draw(dataGT_, optionsGT);

        google.visualization.events.addListener(chartGT, 'select', function () {
            var selection = chartGT.getSelection();
            if (selection.length) {
                var row = selection[0].row;

                let array = jsonDataGT[row];
                const gastosT = array.gastos

                let opt = {
                    campo1: null,
                    campo2: null,
                }//campos opcionales en graficas

                let gastos = []
                let vuelos = []
                let gastosAe = []
                let gastosProv = []
                let costos = []
                let horasV = []
                let novuelos = []
                let paxs = []
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
                    tipoTrans: 10,
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
                    url: generarUrlGT(true),
                    dataType: "json",
                    success: function (response) {
                        window.location.pathname = generarUrlGT(false);
                    },
                    error: function (err) {
                        console.log("Error In Connecting", err);
                    }
                });
            }
        });
    }
}


