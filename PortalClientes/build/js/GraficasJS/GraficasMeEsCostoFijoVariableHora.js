$(document).ready(function () {
    //const url = "http://192.168.1.250/PortalClientes/Views/frmMetricasEstadisticas.aspx/GetCostoFijoVariableHora"; // API URL
    const urlFVH = getUrlFVH(); // API URL

    let objFVH = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesFVH").val(),
    });

    ajax_dataFVH(objFVH, urlFVH, function (dataFVH) {
        chartsFVH(dataFVH , "PieChart"); // Pie Charts
    });

    window.onresize = function () {
        ajax_dataFVH(objFVH, urlFVH, function (dataFVH) {
            chartsFVH(dataFVH, "PieChart"); // Pie Charts
        });
    };
});

function getUrlFVH() {
    let value = window.location + "/GetCostoFijoVariableHora";
    return value;
}

$('#ContentPlaceHolder1_DDFiltroMesesFVH').change(function (event) {
    event.preventDefault();
    lPanel.Show();
    ActualizarGraficaFVH();
});

function ActualizarGraficaFVH() {
    const urlFVH = getUrlFVH(); // API URL
    let objFVH = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesFVH").val(),
    });

    ajax_dataFVH(objFVH, urlFVH, function (dataFVH) {
        chartsFVH(dataFVH, "PieChart"); // Pie Charts
    });
}

function ajax_dataFVH(objFVH, urlFVH, success) {
    $.ajax({
        data: objFVH,
        contentType: "Application/json; charset=utf-8",
        responseType: "json",
        method: 'POST',
        url: urlFVH,
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

function chartsFVH(dataFVH, ChartType) {
    var c = ChartType;
    var jsonDataFVH = dataFVH;

    if (jsonDataFVH.length > 0) {
        google.charts.load("current", { packages: ["corechart"] });
        google.charts.setOnLoadCallback(drawVisualizationFVH)
    }else{
        let mensaje='';
        let leng = document.getElementById('txtLang').value
        if (leng == "es-MX") {
            mensaje="No Hay Datos Disponibles";
        }else{
            mensaje="No data available"
        }
        
        document.getElementById('piechart_3d_8').innerHTML = `<div class="alert alert-info mt-5 text-center" role="alert">${mensaje}</div>`;
        lPanel.Hide();
    }
    
    function generarUrlFVH(obtiene) {
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

    function drawVisualizationFVH() {

        var screenWidth = screen.width;

        var dataFVH_ = new google.visualization.DataTable();
        dataFVH_.addColumn('string', 'Categoria');
        dataFVH_.addColumn('number', jsonDataFVH[0].idioma == "es-MX" ? "Costos" : "Costs");
        dataFVH_.addColumn({ type: 'string', role: 'tooltip' });

        jsonDataFVH.forEach((item, index) => {
            if (jsonDataFVH[0].idioma == "es-MX") {
                dataFVH_.addRows([[item.categoria, item.noGastos, `Total de Movimientos ${ item.noGastos } por ${ item.categoria }`,]]);
            } else {
                dataFVH_.addRows([[item.categoria, item.noGastos, `Total Movements ${ item.noGastos } by ${ item.categoria }`,]]);
            }
        });

        const colorsList = ['#3276ae','#6aabc0','#cf575e','#eb924f','#f6c543','#d578a9','#9889d1','#89d193','#d1b089','#e48fea','#f4d583','#fea6c0','#94e6f2','#89c893','#ffe1a1']

        var optionsFVH = {
            title: jsonDataFVH[0].idioma == "es-MX" ? "Costo Fijo y Variable por Hora" : "Fixed and Variable Cost Per Hour",
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

        var chartFVH = new google.visualization.PieChart(document.getElementById('piechart_3d_8'));
        chartFVH.draw(dataFVH_, optionsFVH);
        
        lPanel.Hide();

        google.visualization.events.addListener(chartFVH, 'select', function () {
            lPanel.Show();
            var selection = chartFVH.getSelection();
            if (selection.length) {
                var row = selection[0].row;

                let array = jsonDataFVH[row];
                const costosFVH = array.gastos

                let opt = {
                    campo1: array.costoHoraVuelo,
                    campo2: array.totalTiempo,
                }//campos opcionales en graficas

                let gastos = []
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
                    tipoTrans: 12,
                    tipoDet: "MXN",
                    descES: array.categoria,
                    descEN: array.categoria,
                    origen: 2,
                    opt
                });

                $.ajax({
                    data: obj,
                    contentType: "Application/json; charset=utf-8",
                    responseType: "json",
                    method: 'POST',
                    url: generarUrlFVH(true),
                    dataType: "json",
                    success: function (response) {
                        window.location.pathname = generarUrlFVH(false);
                    },
                    error: function (err) {
                        console.log("Error In Connecting", err);
                    }
                });
            }
        });
    }
}


