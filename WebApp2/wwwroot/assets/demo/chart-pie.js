//$(document).ready(function () {
//    $.ajax({
//        url: `https://localhost:7240/api/Department`,
//        dataSrc: 'data',
//        type: "GET",
//        success: function (data) {
//            //var panjang = data.divisionId = 10;
//            console.log(data.divisionId);
//            console.log(data.data.length);
//            var banget = data.divisionId == 1;
//            var label = [1, 3];
//            var value = [];
//            for (i = 0; i < 15; i++) {
//                //if (data.data[i].divisionId) {
//                //    console.log("hahah");
//                label.push(data.data[i].nama);
//                value.push(data.data[i].divisionId);
//                //}
//            }
//            var ctx = document.getElementById('pieChart').getContext('2d');
//            var chart = new Chart(ctx, {
//                type: 'pie',
//                data: {
//                    labels: [1, 3],
//                    datasets: [{
//                        label: 'Jumlah ID',
//                        backgroundColor: ['rgb(252, 116, 101)', 'rgb(40, 104, 199)'],
//                        borderColor: 'rgb(255, 255, 255)',
//                        data: value
//                    }]
//                },
//                options: {
//                    legend: {
//                        display: true
//                    },
//                    generateLabels: function (chart) {
//                        var data = chart.data;
//                        if (data.labels.length && data.datasets.length) {
//                            return data.labels.map(function (label, i) {
//                                var meta = chart.getDatasetMeta(0);
//                                var ds = data.datasets[0];
//                                var arc = meta.data[i];
//                                var custom = arc && arc.custom || {};
//                                var getValueAtIndexOrDefault = theHelp.getValueAtIndexOrDefault;
//                                var arcOpts = chart.options.elements.arc;
//                                var fill = custom.backgroundColor ? custom.backgroundColor : getValueAtIndexOrDefault(ds.backgroundColor, i, arcOpts.backgroundColor);
//                                var stroke = custom.borderColor ? custom.borderColor : getValueAtIndexOrDefault(ds.borderColor, i, arcOpts.borderColor);
//                                var bw = custom.borderWidth ? custom.borderWidth : getValueAtIndexOrDefault(ds.borderWidth, i, arcOpts.borderWidth);
//                                return {
//                                    // And finally :
//                                    text: ds.data[i] + "% of the time " + label,
//                                    fillStyle: fill,
//                                    strokeStyle: stroke,
//                                    lineWidth: bw,
//                                    hidden: isNaN(ds.data[i]) || meta.data[i].hidden,
//                                    index: i
//                                };
//                            });
//                        }
//                        return [];
//                    }
//                }
//            });
//        }
//    });
//});

//const dats = data;
//let only3 = [];

//dats.forEach(x => {
//    if (x.divisionId == 3) {
//        console.log(x);
//    }
//})

//Chart.plugins.register({
//  afterDatasetsDraw: function(chartInstance, easing) {
//    // To only draw at the end of animation, check for easing === 1
//    var ctx = chartInstance.chart.ctx;
//    chartInstance.data.datasets.forEach(function(dataset, i) {
//      var meta = chartInstance.getDatasetMeta(i);
//      if (!meta.hidden) {
//        meta.data.forEach(function(element, index) {
//          // Draw the text in black, with the specified font
//          ctx.fillStyle = 'grey';
//          var fontSize = 16;
//          var fontStyle = 'normal';
//          var fontFamily = 'Helvetica Neue';
//          ctx.font = Chart.helpers.fontString(fontSize, fontStyle, fontFamily);
//          // Just naively convert to string for now
//          var dataString = dataset.data[index].toString();
//          // Make sure alignment settings are correct
//          ctx.textAlign = 'center';
//          ctx.textBaseline = 'middle';
//          var padding = 5;
//          var position = element.tooltipPosition();
//          ctx.fillText(dataString + '%', position.x, position.y - (fontSize / 2) - padding);
//        });
//      }
//    });
//  }
//});
$(document).ready(function () {
    $.ajax({
        url: 'https://localhost:7240/api/Department'
    }).done((data) => {
        console.log("test");
        console.log(data);
        var DivisionId = data.data
            .map(x => ({ divisionId: x.divisionId }));
        //var divisionId2 = DivisionId[0].divisionId;
        var { divisionId1, divisionId2, divisionId3 } = DivisionId.reduce((previous, current) => {
            if (current.divisionId === 1) {
                //... adalah spread operator
                // spread untuk memecah array-nya 
                return { ...previous, divisionId1: previous.divisionId1 + 1 }
            }
            //console.log(previous, "ytt+otak");
            if (current.divisionId === 2) {
                return { ...previous, divisionId2: previous.divisionId2 + 1 }
            }
            if (current.divisionId === 3) {
                return { ...previous, divisionId3: previous.divisionId3 + 1 }
            }
        }, { divisionId1: 0, divisionId2: 0, divisionId3: 0 })

        //console.log(divisonFiltered);
        //console.log(DivisionId);
        //console.log(DivisionId[0].divisionId);
        //var res = JSON.stringify(DivisionId);
        //console.log(res);
        //var ex = "5";
        var options = {
            series: [divisionId1, divisionId2, divisionId3],
            chart: {
                width: 500,
                height: 350,
                type: 'pie',
            },
            labels: ['Division Id: 1', 'Division Id: 2', 'Division Id: 3'],
            fill: {
                colors: ['#F44336', '#E91E63', '#9C27B0']
            },
            responsive: [{
                breakpoint: 1000,
                options: {
                    chart: {
                        width: 500,
                       
                    },
                   
                    legend: {
                        show: true,
                        position: 'right',
                          colors: ['#F44336', '#E91E63', '#9C27B0']
                    
                    }
                }
            }]
        };

        var options2 = {
            series: [{
                data: [divisionId1, divisionId2, divisionId3],
            }],
            chart: {
                height: 350,
                type: 'bar',
                events: {
                    click: function (chart, w, e) {
                        // console.log(chart, w, e)
                    }
                }
            },
            plotOptions: {
                bar: {
                    columnWidth: '45%',
                    distributed: true,
                }
            },
            dataLabels: {
                enabled: false
            },
            legend: {
                show: false
            },
            xaxis: {
                categories: [
                    ['Division Id: 1'],
                    ['Division Id: 2'],
                ],
                labels: {
                    style: {
                        fontSize: '12px'
                    }
                }
            }
        };
        //var lineChart = {
        //    series: [divisionId1, divisionId2, divisionId3],
        //    chart: {
        //        width: 280,
        //        height: '100%',
        //        type: 'line',
        //    },
        //    labels: ['Division Id: 1', 'Division Id: 2', 'Division Id: 3'],
        //    responsive: [{
        //        breakpoint: 480,
        //        options: {
        //            chart: {
        //                width: 200
        //            },
        //            legend: {
        //                show: true,
        //                position: 'left',
        //            }
        //        }
        //    }]
        //};
        //console.log(JSON.stringify(options));
        var chart2 = new ApexCharts(document.querySelector("#area-chart"), options2);
        var chart = new ApexCharts(document.querySelector("#stat-chart"), options);

        //var line = new ApexCharts(document.querySelector("#next-chart"), lineChart);
        //console.log(chart);
        chart.render();
        chart2.render();

        //line.render();
    });
});