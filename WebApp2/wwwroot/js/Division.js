$(document).ready(function () {
    $('#datatableSimpleDiv').DataTable({
        ajax: {
            url: 'https://localhost:7240/api/Division',
            dataSrc: 'data',
            "headers": {
                'Content-Type': 'application/x-www-form-urlencoded'
            },
            "type": "GET",
        },
        columns: [
            {
                data: 'id',
            },
            {
                data: 'nama',
            },
            {
                data: null,
                "render": function (data, type, row, meta) {
                    return `<button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#divisionModal" onclick="tableDivision('${data.id}')">Details</button>
                               <button type="button" class="btn btn-danger" onclick="deleteDivision('${data.id}')">Hapus</button>
                                 <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#divisionModal" onclick="editDivision('${data.id}')">Edit</button>
                                  `;
                    //<button class="btn btn-primary" onclick="pokenama('${val.url}')" data-bs-toggle="modal" data-bs-target="#pokedetail">Detail</button>
                }
            }

        ],
        dom: 'Bfrtip',
        buttons: [
            'colvis',
            'pdfHtml5',
            'excelHtml5',
        ],
    });
});


function tableDivision(id) {
    $.ajax({
        url: `https://localhost:7240/api/Division/${id}`,
        type: "GET"
    }).done((res) => {
        let temp = "";
        temp += `    
            <input type="hidden" class="form-control" id="hideId" readonly placeholder="" value="0">
            <h5>id: <h5><input type="text" class="form-control" id="divId" placeholder="${res.data.id}" value="${res.data.id}">
            <h5>nama: <h5><input type="text" class="form-control" id="divName" placeholder="${res.data.nama}" value="${res.data.nama}">            
            `;
        $("#displayDataDivision").html(temp);
        console.log(res.data.id);
    }).fail((err) => {
        console.log(err);
    });
}

function deleteDivision(id) {
    $.ajax({
        url: `https://localhost:7240/api/division?id=${id}`,
        type: "DELETE",
        success: function (data) {
            Swal.fire(
                'Good job!',
                'You clicked the button!',
                'success'
            );
            setTimeout(function () {
                location.reload();
            }, 5000);
        }
    });
}


function editDivision(id) {
    $.ajax({
        url: `https://localhost:7240/api/Division/${id}`,
        type: "GET"
    }).done((res) => {
        let temp = "";
        temp += `    
            <input type="hidden" class="form-control" id="hideId" readonly placeholder="" value="0">
            <h5>id: <h5><input type="text" class="form-control" id="divId" placeholder="${res.data.id}" value="${res.data.id}">
            <h5>nama: <h5><input type="text" class="form-control" id="divName" placeholder="${res.data.nama}" value="${res.data.nama}">
           <button type="button" class="btn btn-primary" id="editName" onclick="saveDivision('${res.data.id}')">Save changes</button>
            `;
        $("#displayDataDivision").html(temp);
        console.log(res.data.id);
    }).fail((err) => {
        console.log(err);
    });
}


function saveDivision(id) {
    var Id = id;
    var Nama = $('#divName').val();

    //let DivId = $('departId')

    var result = { Id, Nama };
    $.ajax({
        url: `https://localhost:7240/api/Division`,
        type: "PUT",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(result),
        success: function () {
            Swal.fire(
                'Good job!',
                'You clicked the button!',
                'success'
            );
            setTimeout(function () {
                location.reload();
            }, 5000);
        },
        error: function () {

        }
    });
}


function createDivision() {
    $.ajax({
        url: `https://localhost:7240/api/Division`,
        type: "GET"
    }).done((res) => {
        let temp = "";
        temp += `    
            <input type="hidden" class="form-control" id="hideId" readonly placeholder="" value="0">
            <h5>nama: <h5><input type="text" class="form-control" id="divName">
            <button type="button" class="btn btn-primary" id="editName" onclick="saveCreateDivision()">Save</button>
            `;
        $("#createDataDiv").html(temp);
        console.log(res.data.id);
    }).fail((err) => {
        console.log(err);
    });
}

function saveCreateDivision() {
    var Nama = $('#divName').val();

    //let DivId = $('departId')

    var result = { Nama };
    $.ajax({
        url: `https://localhost:7240/api/Division`,
        type: "POST",
        contentType: "application/json",
        dataType: "json",
        data: JSON.stringify(result),
        success: function () {
            Swal.fire(
                'Good job!',
                'You clicked the button!',
                'success'
            );
            setTimeout(function () {
                location.reload();
            }, 5000);
        },
        error: function () {

        }
    });
}
