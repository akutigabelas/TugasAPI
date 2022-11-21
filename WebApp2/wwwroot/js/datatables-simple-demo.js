//window.addEventListener('DOMContentLoaded', event => {
//    // Simple-DataTables
//    // https://github.com/fiduswriter/Simple-DataTables/wiki

//    const datatablesSimple = document.getElementById('datatablesSimple');
//    if (datatablesSimple) {
//        new simpleDatatables.DataTable(datatablesSimple);
//    }
//});

//$(document).ready(function () {
//    $('#tableDivision').DataTable();
//});


//$(document).ready(function () {

//    $('#tableDivision').DataTable({

//        ajax: {
//            url: 'https://localhost:44332/api/Department',
//            dataSrc: 'data',
//            "headers": {
//                'Content-Type': 'application/x-www-form-urlencoded'
//            },
//            "type": "GET",
//        },
//        columns: [
//            { data: 'Id' },
//            { data: 'Name' },
//            {
//                data: null,
//                "render": function (data, type, row, meta) {
//                    return <button type="button" class="btn btn-primary">Edit</button>
//                        <button type="button" class="btn btn-danger">Hapus</button>;
//                }
//            }

//        ]

//    });
//});
