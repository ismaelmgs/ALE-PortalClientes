$(document).ready(function () {
    //const url = "http://192.168.1.250/PortalClientes/Views/frmMetricasEstadisticas.aspx/GetCategoriasPeriodo"; // API URL
    const urlCLT = getUrlCLT(); // API URL

    let objCLT = JSON.stringify({
        meses: $("#ContentPlaceHolder1_ddlCategoriasLT").val(),
    });

    ajax_dataCLT(objCLT, urlCLT, function (data) {
        chartsCLT(data); // Pie Charts
    });

    window.onresize = function () {
        ajax_dataCLT(objCLT, urlCLT, function (data) {
            chartsCLT(data); // Pie Charts
        });
    };
});

function getUrlCLT() {
    let value = window.location + "/GetCategoriasPeriodo";
    return value;
}

$('#ContentPlaceHolder1_ddlCategoriasLT').click(function (event) {
    event.preventDefault();
    ActualizarGraficaCLT();
});

function ActualizarGraficaCLT() {
    const urlCLT = getUrlCLT(); // API URL
    let objCLT = JSON.stringify({
        meses: $("#ContentPlaceHolder1_ddlCategoriasLT").val(),
    });

    ajax_dataCLT(objCLT, urlCLT, function (data) {
        chartsCLT(data, "PieChart"); // Pie Charts
    });
}

function ajax_dataCLT(obj, url, success) {
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

function chartsCLT(data) {
    var jsonDataCLT = data;
    
    if (jsonDataCLT.datosM.length > 0) {
        google.charts.load("current", { packages: ["corechart"] });
        google.charts.setOnLoadCallback(drawVisualizationCLT)
    }

    function generarUrlCLT(obtiene) {
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

    function drawVisualizationCLT() {

        var screenWidth = screen.width;

        var dataMXN = jsonDataCLT.datosM;
        var dataUSD = jsonDataCLT.datosU;
        const conceptos = jsonDataCLT.conceptos;
        const idioma = jsonDataCLT.idioma;
        let dataArrayMXN = []
        let dataArrayUSD = []

        let dataTitles = [ 
            {label: idioma == "es-MX" ? 'MES' : 'MOUNTH', id: 'mes'},
        ]

        let title = {
            label: '', 
            id: '', 
            type: 'number'
        }

        conceptos.forEach(item => {
            let addTitle = {...title}
            addTitle.label = item
            addTitle.id = item

            dataTitles.push(addTitle)
        })

        dataArrayMXN.push(dataTitles)
        dataArrayUSD.push(dataTitles)

        const opt = { style: 'currency', currency: 'MXN' };
        var numberFormat = new Intl.NumberFormat('es-MX', opt);

        let contador2 = 1
        let contadorAdd2 = 0
        let array2 = []
        dataMXN.forEach(item => {
            if(contador2 > conceptos.length + 1){
                array2.push(item)

                if(contadorAdd2 == conceptos.length){
                    dataArrayMXN.push(array2)
                    array2 = []
                    contadorAdd2 = 0
                }else{
                    contadorAdd2 ++
                }
            }
            contador2++
        })

        const opt2 = { style: 'currency', currency: 'USD' };
        const numberFormat2 = new Intl.NumberFormat('en-US', opt2);

        let contador = 1
        let contadorAdd = 0
        let array = []
        dataUSD.forEach(item => {
            if(contador > conceptos.length + 1){
                array.push(item)

                if(contadorAdd == conceptos.length){
                    dataArrayUSD.push(array)
                    array = []
                    contadorAdd = 0
                }else{
                    contadorAdd ++
                }
            }
            contador++
        })

        var data = google.visualization.arrayToDataTable(dataArrayMXN);
        var dataE = google.visualization.arrayToDataTable(dataArrayUSD);


        var options = {
            title: "Categorias a lo Largo del Tiempo MX",//jsonData[0].idioma == "es-MX" ? "Categorias a lo Largo del Tiempo" : "Expenses Categories Over Time",
            bar: {
                groupWidth: "60%",
            },
            isStacked: true,
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

        var optionsE = {
            title: "Categorias a lo Largo del Tiempo USD",//jsonData[0].idioma == "es-MX" ? "Categorias a lo Largo del Tiempo" : "Expenses Categories Over Time",
            bar: {
                groupWidth: "60%",
            },
            isStacked: true,
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

        var chart = new google.visualization.ColumnChart(document.getElementById('piechart_3d_17'));
        chart.draw(data, options);

        var chartE = new google.visualization.ColumnChart(document.getElementById('piechart_3d_18'));
        chartE.draw(dataE, optionsE);

        google.visualization.events.addListener(chart, 'select', function () {
             var selection = chart.getSelection();
             if (selection.length) {

                 let mes = selection[0].row + 1
                 let concepto = jsonDataCLT.conceptos[selection[0].column - 1]

                 let array = idoma == "es-MX" ? jsonDataCLT.response.find(item => item.mes == mes && item.rubroESP == concepto) : sonDataCLT.response.find(item => item.mes == mes && item.rubroENG == concepto);
                 let detGasto = idoma == "es-MX" ? array.detalleGastos.filter(elem => elem.mes == mes && elem.rubroESP == concepto && elem.totalMXN > 0) :  array.detalleGastos.filter(elem => elem.mes == mes && elem.rubroENG == concepto && elem.totalMXN > 0)

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
                    detGasto,
                    tipoTrans: 14,
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
                    url: generarUrlCLT(true),
                    dataType: "json",
                    success: function (response) {
                        window.location.pathname = generarUrlCLT(false);
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

                let mes = selection[0].row + 1
                let concepto = jsonDataCLT.conceptos[selection[0].column - 1]

                let array = idoma == "es-MX" ? jsonDataCLT.response.find(item => item.mes == mes && item.rubroESP == concepto) : sonDataCLT.response.find(item => item.mes == mes && item.rubroENG == concepto);
                 let detGasto = idoma == "es-MX" ? array.detalleGastos.filter(elem => elem.mes == mes && elem.rubroESP == concepto && elem.totalUSD> 0) :  array.detalleGastos.filter(elem => elem.mes == mes && elem.rubroENG == concepto && elem.totalUSD > 0)

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
                   detGasto,
                   tipoTrans: 14,
                   tipoDet: "USD",
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
                   url: generarUrlCLT(true),
                   dataType: "json",
                   success: function (response) {
                       window.location.pathname = generarUrlCLT(false);
                   },
                   error: function (err) {
                       console.log("Error In Connecting", err);
                   }
               });
            }
       });
    }
}


function hometab_Click(){
    document.getElementById("ContentPlaceHolder1_lbTitleMapR").style.display = 'block';
    document.getElementById("ContentPlaceHolder1_lbTitleMapA").style.display = 'none';
}

function profiletab_Click(){
    document.getElementById("ContentPlaceHolder1_lbTitleMapA").style.display = 'block';
    document.getElementById("ContentPlaceHolder1_lbTitleMapR").style.display = 'none';
}


