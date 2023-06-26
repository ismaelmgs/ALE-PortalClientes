$(document).ready(function () {
    //const url = "http://192.168.1.250/PortalClientes/Views/frmMetricasEstadisticas.aspx/GetGastos"; // API URL
    const url = getUrlA(); // API URL

    let objAe = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesPA").val(),
    });

    ajax_data(objAe, url, function (dataAe) {
        chartsAe(dataAe, "PieChart"); // Pie Charts
    });

    window.onresize = function () {
        ajax_data(objAe, url, function (dataAe) {
            chartsAe(dataAe, "PieChart"); // Pie Charts
        });
    };
});

function getUrlA() {
    let value = window.location + "/GetGastosAeropuerto";
    return value;
}

$('#ContentPlaceHolder1_DDFiltroMesesPA').change(function (event) {
    event.preventDefault();
    lPanel.Show();
    ActualizarGraficaAe();
});

function ActualizarGraficaAe() {
    const url = getUrlA(); // API URL
    let objAe = JSON.stringify({
        meses: $("#ContentPlaceHolder1_DDFiltroMesesPA").val(),
    });

    ajax_data(objAe, url, function (dataAe) {
        chartsAe(dataAe, "PieChart"); // Pie Charts
    });
}

function ajax_data(objAe, url, success) {
    $.ajax({
        data: objAe,
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

function chartsAe(dataAe, ChartType) {
    var c = ChartType;
    var jsonDataAe = dataAe;

    if (jsonDataAe.length > 0) {
        google.charts.load("current", { packages: ["corechart"] });
        google.charts.setOnLoadCallback(drawVisualizationAe)
    }else{
        let mensaje='';
        let leng = document.getElementById('txtLang').value
        if (leng == "es-MX") {
            mensaje="No Hay Datos Disponibles";
        }else{
            mensaje="No data available"
        }
        
        document.getElementById('piechart_3d_4').innerHTML = `<div class="alert alert-info mt-5 text-center" role="alert">${mensaje}</div>`;
        lPanel.Hide();
    }

    function generarUrlAe(obtiene) {
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

    function drawVisualizationAe() {

        var screenWidth = screen.width;

        var dataAe_ = new google.visualization.DataTable();
        dataAe_.addColumn('string', 'Aeropuertos');
        dataAe_.addColumn('number', 'Costos');
        dataAe_.addColumn({ type: 'string', role: 'tooltip' });

        const opt = { style: 'currency', currency: 'MXN' };
        var numberFormat = new Intl.NumberFormat('es-MX', opt);

        const opt2 = { style: 'currency', currency: 'USD' };
        const numberFormat2 = new Intl.NumberFormat('en-US', opt2);

        jsonDataAe.forEach((item, index) => {
            dataAe_.addRows([[item.aeropuerto, item.totalMXN, `${item.aeropuerto} - ${numberFormat.format(item.totalMXN)} MXN`,]]);
        });

        const colorsList = ['#3276ae','#6aabc0','#cf575e','#eb924f','#f6c543','#d578a9','#9889d1','#89d193','#d1b089','#e48fea','#f4d583','#fea6c0','#94e6f2','#89c893','#ffe1a1']

        var optionsAe = {
            title: jsonDataAe[0].idioma == "es-MX" ? "Gastos por Aeropuerto" : "Expenses by Airport",
            //is3D: true, //Pie Charts
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
                position: 'rigth',
                alignment: 'center',
            },
            colors: colorsList.sort(function () { return 0.5 - Math.random() }),
        };

        var chartAero = new google.visualization.PieChart(document.getElementById('piechart_3d_4'));
        chartAero.draw(dataAe_, optionsAe);

        lPanel.Hide();

        google.visualization.events.addListener(chartAero, 'select', function () {
            lPanel.Show();
            var selection = chartAero.getSelection();
            if (selection.length) {
                var row = selection[0].row;

                let array = jsonDataAe[row];
                const gastosAe = array.gastos

                let opt = {
                    campo1: null,
                    campo2: null,
                }//campos opcionales en graficas

                let gastos = []
                let vuelos = []
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
                    tipoTrans: 2,
                    tipoDet: "MXN",
                    descES: array.aeropuerto,
                    descEN: array.aeropuerto,
                    origen: 2,
                    opt,
                });

                $.ajax({
                    data: obj,
                    contentType: "Application/json; charset=utf-8",
                    responseType: "json",
                    method: 'POST',
                    url: generarUrlAe(true),
                    dataType: "json",
                    success: function (response) {
                        window.location.pathname = generarUrlAe(false);
                    },
                    error: function (err) {
                        console.log("Error In Connecting", err);
                    }
                });
            }
        });
    }
}


