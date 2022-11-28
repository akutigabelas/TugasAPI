// Set new default font family and font color to mimic Bootstrap's default styling
//Chart.defaults.global.defaultFontFamily = '-apple-system,system-ui,BlinkMacSystemFont,"Segoe UI",Roboto,"Helvetica Neue",Arial,sans-serif';
//Chart.defaults.global.defaultFontColor = '#292b2c';


getData();

async function getData() {
    const response = await fetch(
        'https://localhost:7240/api/Department');
    console.log(response);
    const data = await response.json();
    console.log(data);
    length = data.data.length;
    console.log(length);

    labels = [];
    values = [];
    for (i = 0; i < length; i++) {
        labels.push(data.data[i].id);
        values.push(data.data[i].nama);
    }


    new Chart(document.getElementById("myPieChart"), {
        type: 'pie',
        data: {
            labels: labels,
            datasets: [
                {
                    label: "nama",
                    backgroundColor: ["#3e95cd",
                        "#8e5ea2",
                        "#3cba9f",
                        "#e8c3b9",
                        "#c45850",
                        "#CD5C5C",
                        "#40E0D0"],
                    data: values
                }
            ]
        },
        options: {
            legend: { display: false },
            title: {
                display: true,
                text: 'U.S population'
            }
        }
    });

}

console.log("hahahaha");
// Pie Chart Example
//var ctx = document.getElementById("myPieChart");
//var myPieChart = new Chart(ctx, {
//  type: 'pie',
//  data: {
//    labels: ["Blue", "Red", "Yellow", "Green"],
//    datasets: [{
//      data: [12.21, 15.58, 11.25, 8.32],
//      backgroundColor: ['#007bff', '#dc3545', '#ffc107', '#28a745'],
//    }],
//  },
//});

