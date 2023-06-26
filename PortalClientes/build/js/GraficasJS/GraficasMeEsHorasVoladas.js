$(document).ready(function () {
    //const url = "http://192.168.1.250/PortalClientes/Views/frmMetricasEstadisticas.aspx/GetHorasVoladas"; // API URL
    const url = getUrlHV(); // API URL

    let objHV = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesHV").val(),
    });

    ajax_dataHV(objHV, url, function (dataHV) {
        chartsHV(dataHV , "PieChart"); // Pie Charts
    });

    window.onresize = function () {
        ajax_dataHV(objHV, url, function (dataHV) {
            chartsHV(dataHV, "PieChart"); // Pie Charts
        });
    };
});

function getUrlHV() {
    let value = window.location + "/GetHorasVoladas";
    return value;
}

$('#ContentPlaceHolder1_DDFiltroMesesHV').change(function (event) {
    event.preventDefault();
    lPanel.Show();
    ActualizarGraficaHV();
});

function ActualizarGraficaHV() {
    const url = getUrlHV(); // API URL
    let objHV = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesHV").val(),
    });

    ajax_dataHV(objHV, url, function (dataHV) {
        chartsHV(dataHV, "PieChart"); // Pie Charts
    });
}

function ajax_dataHV(objHV, url, success) {
    $.ajax({
        data: objHV,
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

function chartsHV(dataHV, ChartType) {
    var c = ChartType;
    var jsonDataHV = dataHV;

    if (jsonDataHV.length > 0) {
        google.charts.load("current", { packages: ["corechart"] });
        google.charts.setOnLoadCallback(drawVisualizationHV)
    }else{
        let mensaje='';
        let leng = document.getElementById('txtLang').value
        if (leng == "es-MX") {
            mensaje="No Hay Datos Disponibles";
        }else{
            mensaje="No data available"
        }
        
        document.getElementById('piechart_3d_14').innerHTML = `<div class="alert alert-info mt-5 text-center" role="alert">${mensaje}</div>`;
        lPanel.Hide();
    }
    
    function generarUrlHV(obtiene) {
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

    function drawVisualizationHV() {

        var screenWidth = screen.width;

        var dataHV_ = new google.visualization.DataTable();
        dataHV_.addColumn('string', 'Meses');
        dataHV_.addColumn('number', jsonDataHV[0].idioma == "es-MX" ? "Horas" : "Hours");
        dataHV_.addColumn({ type: 'string', role: 'tooltip' });

        jsonDataHV.forEach((item, index) => {

            if (jsonDataHV[0].idioma == "es-MX") {
                dataHV_.addRows([[item.nombreESP, item.totalTiempo, `${item.nombreESP} - ${item.totalTiempo} Horas Voladas`,]]);
            } else {
                dataHV_.addRows([[item.nombreENG, item.totalTiempo, `${item.nombreENG} - ${item.totalTiempo} Flight Hours`,]]);
            }
        });

        const colorsList = ['#3276ae','#6aabc0','#cf575e','#eb924f','#f6c543','#d578a9','#9889d1','#89d193','#d1b089','#e48fea','#f4d583','#fea6c0','#94e6f2','#89c893','#ffe1a1']

        var optionsHV = {
            title: jsonDataHV[0].idioma == "es-MX" ? "Horas Voladas" : "Flight Hours",
            bar: {
                groupWidth: "60%",
            },
            fontSize: 12,
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

        var chartHV = new google.visualization.ColumnChart(document.getElementById('piechart_3d_14'));
        chartHV.draw(dataHV_, optionsHV);
        
        lPanel.Hide();

        google.visualization.events.addListener(chartHV, 'select', function () {
            lPanel.Show();
            var selection = chartHV.getSelection();
            if (selection.length) {
                var row = selection[0].row;

                let array = jsonDataHV[row];
                const horasV = array.horasVoladas

                let opt = {}//campos opcionales en graficas

                let gastos = []
                let vuelos = []
                let gastosAe = []
                let gastosProv = []
                let costos = []
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
                    tipoTrans: 7,
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
                    url: generarUrlHV(true),
                    dataType: "json",
                    success: function (response) {
                        window.location.pathname = generarUrlHV(false);
                    },
                    error: function (err) {
                        console.log("Error In Connecting", err);
                    }
                });
            }
        });
    }
}


