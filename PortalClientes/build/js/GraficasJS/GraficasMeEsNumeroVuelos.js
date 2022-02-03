$(document).ready(function () {
    //const url = "http://192.168.1.250/PortalClientes/Views/frmMetricasEstadisticas.aspx/GetNumeroVuelos"; // API URL
    const urlNV = getUrlNV(); // API URL

    let objNV = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesNV").val(),
    });

    ajax_dataNV(objNV, urlNV, function (dataNV) {
        chartsNV(dataNV , "PieChart"); // Pie Charts
    });

    window.onresize = function () {
        ajax_dataNV(objNV, urlNV, function (dataNV) {
            chartsNV(dataNV, "PieChart"); // Pie Charts
        });
    };
});

function getUrlNV() {
    let value = window.location + "/GetNoVuelos";
    return value;
}

$('#ContentPlaceHolder1_DDFiltroMesesNV').change(function (event) {
    event.preventDefault();
    lPanel.Show();
    ActualizarGraficaNV();
});

function ActualizarGraficaNV() {
    const urlNV = getUrlNV(); // API URL
    let objNV = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesNV").val(),
    });

    ajax_dataNV(objNV, urlNV, function (dataNV) {
        chartsNV(dataNV, "PieChart"); // Pie Charts
    });
}

function ajax_dataNV(objNV, urlNV, success) {
    $.ajax({
        data: objNV,
        contentType: "Application/json; charset=utf-8",
        responseType: "json",
        method: 'POST',
        url: urlNV,
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
    }else{
        let mensaje='';
        let leng = document.getElementById('txtLang').value
        if (leng == "es-MX") {
            mensaje="No Hay Datos Disponibles";
        }else{
            mensaje="No data available"
        }
        
        document.getElementById('piechart_3d_13').innerHTML = `<div class="alert alert-info mt-5 text-center" role="alert">${mensaje}</div>`;
        lPanel.Hide();
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
        dataNV_.addColumn('string', 'Mes');
        dataNV_.addColumn('number', jsonDataNV[0].idioma == "es-MX" ? "Vuelos" : "Flights");
        dataNV_.addColumn({ type: 'string', role: 'tooltip' });

        jsonDataNV.forEach((item, index) => {
            if (jsonDataNV[0].idioma == "es-MX") {
                dataNV_.addRows([[item.nombreESP, item.noVuelos, `${item.nombreESP} - No. de Vuelos ${item.noVuelos}`,]]);
            } else {
                dataNV_.addRows([[item.nombreENG, item.noVuelos, `${item.nombreENG} - No. of Flights ${item.noVuelos}`,]]);
            }
        });

        const colorsList = ['#3276ae','#6aabc0','#cf575e','#eb924f','#f6c543','#d578a9','#9889d1','#89d193','#d1b089','#e48fea','#f4d583','#fea6c0','#94e6f2','#89c893','#ffe1a1']

        var optionsNV = {
            title: jsonDataNV[0].idioma == "es-MX" ? "No. de Vuelos" : "No. of Flights",
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

        var chartNV = new google.visualization.ColumnChart(document.getElementById('piechart_3d_13'));
        chartNV.draw(dataNV_, optionsNV);

        lPanel.Hide();

        google.visualization.events.addListener(chartNV, 'select', function () {
            lPanel.Show();
            var selection = chartNV.getSelection();
            if (selection.length) {
                var row = selection[0].row;

                let array = jsonDataNV[row];
                const novuelos = array.vuelos

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
                    tipoTrans: 8,
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


