<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frm_RepInicio.aspx.cs" Inherits="Infoteca.UserInterface.frm_RepInicio" MasterPageFile="~/MasterPage.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">   
    <div class="container">
        <h2>
            Inicio
        </h2>
        <hr />  
        <div class="form-row">
            <div class="form-group col-md-5">  
                <canvas id="lineChartBusquedas"></canvas>
            </div>
            <div class="form-group col-md-5">
                <canvas id="barChartNoticias"></canvas>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col-md-5">  
                <canvas id="barChartTiposDelito" height="200"></canvas>
            </div>
            <div class="form-group col-md-5"> 
                <canvas id="barChartFuentes" width="800" height="450"></canvas>
            </div>
        </div>
        
    </div> 
    <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.2/Chart.js"></script>
    <script src="/js/chartjs-plugin-labels.min.js"></script>

    <script type="text/javascript">

        $(function () {

            var ctx2 = document.getElementById("lineChartBusquedas").getContext("2d");

            var fetch_url;
            fetch_url = '../frm_RepInicio.aspx/CargarGraficoBusquedas';
            return $.ajax({
                url: fetch_url,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (res, textStatus) {

                    var parsedJson = JSON.parse(res.d);
                    var barData = parsedJson;
                    var barOptions = {
                        responsive: true,
                        maintainAspectRatio: true,
                        scales: {
                            yAxes: [{

                                gridLines: {
                                    display: true
                                },ticks: {
                                    beginAtZero: true,
                                    userCallback: function(label, index, labels) {
                                        if (Math.floor(label) === label) {
                                            return label;
                                        }
                                    }
                                }
                            }],
                            xAxes: [{
                                gridLines: {
                                    display: true
                                }
                            }]
                        },
                        title: {
                            display: true,
                            text: 'Cantidad de busquedas Realizadas'
                        },
                        legend: {
                            display: false
                        }
                    };

                    var myChart = new Chart(ctx2, { type: 'line', data: barData, options: barOptions }); 
                },
                error: function (res, textStatus) {
                }
            });

        });

    </script>

    <script type="text/javascript">

        $(function () {

            var ctx2 = document.getElementById("barChartFuentes").getContext("2d");

            var fetch_url;
            fetch_url = '../frm_RepInicio.aspx/CargarGraficoFuentes';
            return $.ajax({
                url: fetch_url,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (res, textStatus) {

                    var parsedJson = JSON.parse(res.d);
                    var barData = parsedJson;
                    var barOptions = {
                        responsive: true,
                        maintainAspectRatio: true,
                        scales: {
                            yAxes: [{

                                gridLines: {
                                    display: false
                                }
                            }],
                            xAxes: [{
                                gridLines: {
                                    display: false
                                },ticks: {
                                    beginAtZero: true,
                                    userCallback: function(label, index, labels) {
                                        if (Math.floor(label) === label) {
                                            return label;
                                        }
                                    }
                                }
                            }]
                        },
                        title: {
                            display: true,
                            text: 'Fuentes'
                        },
                        legend: {
                            display: false
                        }
                    };

                    var myChart = new Chart(ctx2, { type: 'horizontalBar', data: barData, options: barOptions }); 
                },
                error: function (res, textStatus) {

                }
            });

        });

    </script>
    
    <script type="text/javascript">

        $(function () {

            var ctx2 = document.getElementById("barChartNoticias").getContext("2d");

            var fetch_url;
            fetch_url = '../frm_RepInicio.aspx/CargarGraficoNoticias';
            return $.ajax({
                url: fetch_url,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (res, textStatus) {

                    var parsedJson = JSON.parse(res.d);
                    var barData = parsedJson;
                    var barOptions = {
                        responsive: true,
                        maintainAspectRatio: true,
                        scales: {
                            yAxes: [{

                                gridLines: {
                                    display: true
                                },ticks: {
                                    beginAtZero: true,
                                    userCallback: function(label, index, labels) {
                                        if (Math.floor(label) === label) {
                                            return label;
                                        }
                                    }
                                }
                            }],
                            xAxes: [{
                                gridLines: {
                                    display: true
                                }
                            }]
                        },
                        title: {
                            display: true,
                            text: 'Cantidad de Noticias Registradas'
                        },
                        legend: {
                            display: false
                        }
                    };

                    var myChart = new Chart(ctx2, { type: 'line', data: barData, options: barOptions }); 
                },
                error: function (res, textStatus) {
                }
            });

        });

    </script>
    
    <script type="text/javascript">
        $(function () {

            var ctx2 = document.getElementById("barChartTiposDelito").getContext("2d");

            var fetch_url;
            fetch_url = '../frm_RepInicio.aspx/CargarGraficoTiposDelito';
            return $.ajax({
                url: fetch_url,
                type: "POST",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (res, textStatus) {

                    var parsedJson = JSON.parse(res.d);
                    var barData = parsedJson;
                    var barOptions = {
                        responsive: true,
                        maintainAspectRatio: true,
                        scales: {
                            yAxes: [{

                                gridLines: {
                                    display: true
                                },ticks: {
                                    beginAtZero: true,
                                    userCallback: function(label, index, labels) {
                                        if (Math.floor(label) === label) {
                                            return label;
                                        }
                                    }
                                }
                            }],
                            xAxes: [{
                                gridLines: {
                                    display: true
                                }
                            }]
                        },
                        title: {
                            display: true,
                            text: 'Tipos de Delito'
                        },
                        plugins: {
                            labels: {
                                render: 'value'
                            }
                        }
                    };

                    var myChart = new Chart(ctx2, { type: 'pie', data: barData, options: barOptions }); 
                },
                error: function (res, textStatus) {

                }
            });

        });
    </script>

</asp:Content>