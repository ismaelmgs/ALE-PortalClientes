﻿const url = "/Views/frmDashboard.aspx/GetGastos"; // API URL

$(document).ready(function () {
    
    let obj = JSON.stringify({
        meses: $("#ContentPlaceHolder1_ddlPeriodo").val(),
        fechaInicial: $("#ContentPlaceHolder1_txtFechaInicioGrafica").val(),
        fechaFinal: $("#ContentPlaceHolder1_txtFechaFinGrafica").val(),
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

$('#btnGraficasBuscar').click(function (event) {

    event.preventDefault();
    ActualizarGrafica();

});

function ActualizarGrafica() {
    let obj = JSON.stringify({
        meses: $("#ContentPlaceHolder1_ddlPeriodo").val(),
        fechaInicial: $("#ContentPlaceHolder1_txtFechaInicioGrafica").val(),
        fechaFinal: $("#ContentPlaceHolder1_txtFechaFinGrafica").val(),
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
            alert("Error In Connecting");
        }
    });
}

function charts(data, ChartType) {
    var c = ChartType;
    var jsonData = data;
    google.charts.load("current", { packages: ["corechart"] });
    google.charts.setOnLoadCallback(drawVisualization)

    function drawVisualization() {
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
            data.addRows([[item.rubroESP, item.totalMXN, `${item.rubroESP} - ${numberFormat.format(item.totalMXN)} MXN`,]]);
            dataE.addRows([[item.rubroENG, item.totalUSD, `${item.rubroENG} - ${numberFormat2.format(item.totalUSD)} USD`,]]);
        });

        var options = {
            title: "Costos por Categoria'",
            is3D: true, //Pie Charts
            animation: {
                duration: 3000,
                easing: 'out',
                startup: true
            },
            legend: {
                position: 'rigth',
                alignment: 'start',
                textStyle: {
                    fontsize: 8
                }
            },
        };

        var optionsE = {
            title: "Costs by Category",
            is3D: true, //Pie Charts
            animation: {
                duration: 3000,
                easing: 'out',
                startup: true
            },
            legend: {
                position: 'rigth',
                alignment: 'start',
                textStyle: {
                    fontsize: 8
                }
            },
        };

        var chart = new google.visualization.PieChart(document.getElementById('piechart_3d_1'));
        chart.draw(data, options);

        var chartE = new google.visualization.PieChart(document.getElementById('piechart_3d_2'));
        chartE.draw(dataE, optionsE);

        google.visualization.events.addListener(chart, 'select', function () {
            var selection = chart.getSelection();
            if (selection.length) {
                var row = selection[0].row;
                //alert(data.getValue(row, 0));

                let array = jsonData[row];
                const gastos = array.Gastos

                $.ajax({
                    data: JSON.stringify(gastos),
                    contentType: "Application/json;",
                    method: 'POST',
                    url: "/Views/frmTransacciones.aspx",
                    dataType: "json",
                });

                //window.location.pathname = '/Views/frmTuAeronave.aspx';
            }
        });

        google.visualization.events.addListener(chartE, 'select', function () {
            var selection = chartE.getSelection();
            if (selection.length) {
                //var row = selection[0].row;
                //alert(dataE.getValue(row, 1));

                window.location.pathname = '/Views/frmTuAeronave.aspx';
            }
        });
    }
}

