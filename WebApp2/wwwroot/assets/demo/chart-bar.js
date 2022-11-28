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
            series: [divisionId1, divisionId3],
            chart: {
                width: 280,
                type: 'bar',
            },
            labels: ['Division Id: 1', 'Division Id: 3'],
            responsive: [{
                breakpoint: 480,
                options: {
                    chart: {
                        width: 200
                    },
                    legend: {
                        show: true,
                        position: 'right',
                    }
                }
            }]
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
        var chart = new ApexCharts(document.querySelector("#area-chart"), options);
        //var line = new ApexCharts(document.querySelector("#next-chart"), lineChart);
        //console.log(chart);
        chart.render();
        //line.render();
    });
});