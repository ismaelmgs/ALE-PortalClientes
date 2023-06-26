$(document).ready(function () {
    //const url = "http://192.168.1.250/PortalClientes/Views/frmMetricasEstadisticas.aspx/GetCostosFijoVariable"; // API URL
    const urlFV = getUrlFV(); // API URL

    let objFV = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesFV").val(),
    });

    ajax_dataFV(objFV, urlFV, function (dataFV) {
        chartsFV(dataFV , "PieChart"); // Pie Charts
    });

    window.onresize = function () {
        ajax_dataFV(objFV, urlFV, function (dataFV) {
            chartsFV(dataFV, "PieChart"); // Pie Charts
        });
    };
});

function getUrlFV() {
    let value = window.location + "/GetCostosFijoVariable";
    return value;
}

$('#ContentPlaceHolder1_DDFiltroMesesFV').change(function (event) {
    event.preventDefault();
    lPanel.Show();
    ActualizarGraficaFV();
});

function ActualizarGraficaFV() {
    const urlFV = getUrlFV(); // API URL
    let objFV = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesFV").val(),
    });

    ajax_dataFV(objFV, urlFV, function (dataFV) {
        chartsFV(dataFV, "PieChart"); // Pie Charts
    });
}

function ajax_dataFV(objFV, urlFV, success) {
    $.ajax({
        data: objFV,
        contentType: "Application/json; charset=utf-8",
        responseType: "json",
        method: 'POST',
        url: urlFV,
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

function chartsFV(dataFV, ChartType) {
    var c = ChartType;
    var jsonDataFV = dataFV;

    if (jsonDataFV.length > 0) {
        google.charts.load("current", { packages: ["corechart"] });
        google.charts.setOnLoadCallback(drawVisualizationFV)
    }else{
        let mensaje='';
        let leng = document.getElementById('txtLang').value
        if (leng == "es-MX") {
            mensaje="No Hay Datos Disponibles";
        }else{
            mensaje="No data available"
        }
        
        document.getElementById('piechart_3d_7').innerHTML = `<div class="alert alert-info mt-5 text-center" role="alert">${mensaje}</div>`;
        lPanel.Hide();
    }
    
    function generarUrlFV(obtiene) {
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

    function drawVisualizationFV() {

        var screenWidth = screen.width;

        var dataFV_ = new google.visualization.DataTable();
        dataFV_.addColumn('string', 'Categoria');
        dataFV_.addColumn('number', jsonDataFV[0].idioma == "es-MX" ? "Costos" : "Costs");
        dataFV_.addColumn({ type: 'string', role: 'tooltip' });

        jsonDataFV.forEach((item, index) => {
            if (jsonDataFV[0].idioma == "es-MX") {
                dataFV_.addRows([[item.categoria, item.noGastos, `Total de Movimientos ${ item.noGastos } por ${ item.categoria }`,]]);
            } else {
                dataFV_.addRows([[item.categoria, item.noGastos, `Total Movements ${ item.noGastos } by ${ item.categoria }`,]]);
            }
        });

        const colorsList = ['#3276ae','#6aabc0','#cf575e','#eb924f','#f6c543','#d578a9','#9889d1','#89d193','#d1b089','#e48fea','#f4d583','#fea6c0','#94e6f2','#89c893','#ffe1a1']

        var optionsFV = {
            title: jsonDataFV[0].idioma == "es-MX" ? "Costo Fijo y Variable" : "Fixed and Variable Cost",
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

        var chartFV = new google.visualization.PieChart(document.getElementById('piechart_3d_7'));
        chartFV.draw(dataFV_, optionsFV);

        lPanel.Hide();

        google.visualization.events.addListener(chartFV, 'select', function () {
            lPanel.Show();
            var selection = chartFV.getSelection();
            if (selection.length) {
                var row = selection[0].row;

                let array = jsonDataFV[row];
                const costosFV = array.costos

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
                let gastosT = []
                let costoH = []
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
                    tipoTrans: 9,
                    tipoDet: "MXN",
                    descES: array.categoria,
                    descEN: array.categoria,
                    origen: 2,
                    opt,
                });

                $.ajax({
                    data: obj,
                    contentType: "Application/json; charset=utf-8",
                    responseType: "json",
                    method: 'POST',
                    url: generarUrlFV(true),
                    dataType: "json",
                    success: function (response) {
                        window.location.pathname = generarUrlFV(false);
                    },
                    error: function (err) {
                        console.log("Error In Connecting", err);
                    }
                });
            }
        });
    }
}


