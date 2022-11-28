$(document).ready(function () {
    $('#datatableSimple').DataTable({
        ajax: {
            url: 'https://localhost:7240/api/Department',
            dataSrc: 'data',
            "headers": {
                //'Content-Type': 'application/x-www-form-urlencoded'
                'Authorization': "Bearer " + sessionStorage.getItem("token")
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
                    return `<button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#departmentModal" onclick="tableDepartment('${data.id}')">Details</button>
                               <button type="button" class="btn btn-danger" onclick="deleteDepartment('${data.id}')">Hapus</button>
                                 <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#departmentModal" onclick="editDepartment('${data.id}')">Edit</button>
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

function chartPie() {
    $.ajax({
        url: `https://localhost:7240/api/Department`,
        method: "GET",
        success: function () {
            //console.log(data);
            var label = [];
            var value = [];
            for (var i in data) {
                label.push(data[i].Nama);
                value.push(data[i].DivisionId);
            }
            var ctx = document.getElementById("pieChart");
            var myPieChart = new Chart(ctx, {
                type: 'pie',
                data: {
                    labels: ["Nama", "DivisionId"],
                    datasets: [{
                        label: 'Jumlah Department',
                        //data: [12.21, 15.58, 11.25, 8.32],
                        backgroundColor: ['#007bff', '#dc3545', '#ffc107', '#28a745'],
                        data: value
                    }],
                },
            });
        }
    });
}

function tableDepartment(id) {
    $.ajax({
        url: `https://localhost:7240/api/Department/${id}`,
        type: "GET"
    }).done((res) => {
        let temp = "";
        temp += `    
            <input type="hidden" class="form-control" id="hideId" readonly placeholder="" value="0">
            <h5>id: <h5><input type="text" class="form-control" id="departId" placeholder="${res.data.id}" value="${res.data.id}">
            <h5>nama: <h5><input type="text" class="form-control" id="departName" placeholder="${res.data.nama}" value="${res.data.nama}">            
            `; 
        $("#displayData").html(temp);
        console.log(res.data.id);
       }).fail((err) => {
        console.log(err);
    });
}

function deleteDepartment(id){
    $.ajax({
        url: `https://localhost:7240/api/department?id=${id}`,
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


function editDepartment(id) {
    $.ajax({
        url: `https://localhost:7240/api/Department/${id}`,
        type: "GET"
    }).done((res) => {
        let temp = "";
        temp += `    
            <input type="hidden" class="form-control" id="hideId" readonly placeholder="" value="0">
            <h5>id: <h5><input type="text" class="form-control" id="departId" placeholder="${res.data.id}" value="${res.data.id}">
            <h5>nama: <h5><input type="text" class="form-control" id="departName" placeholder="${res.data.nama}" value="${res.data.nama}">
            <h5>Division Id: <h5><input type="text" class="form-control" id="divId" placeholder="${res.data.divisionId}" value="${res.data.divisionId}" readonly>
            <button type="button" class="btn btn-primary" id="editName" onclick="saveDepartment('${res.data.id}')">Save changes</button>
            `;                                                                                          
        $("#displayData").html(temp);
        console.log(res.data.id);
    }).fail((err) => {
        console.log(err);
    });
}


function saveDepartment(id) {
    var Id = id;
    var Nama = $('#departName').val();
    var DivisionId = parseInt($('#divId').val());

    //let DivId = $('departId')

    var result = { Id, Nama, DivisionId };
    $.ajax({
        url: `https://localhost:7240/api/Department`,
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


function createDepartment() {
    $.ajax({
        url: `https://localhost:7240/api/Department`,
        type: "GET"
    }).done((res) => {
        let temp = "";
        temp += `    
            <input type="hidden" class="form-control" id="hideId" readonly placeholder="" value="0">
            <form class="row g-3 needs-validation" novalidate>
              <div class="col-md-4">
                <label for="validationCustom01" class="form-label">First name</label>
                <input type="text" class="form-control" id="departName" required>
                <div class="valid-feedback">
                  Looks good!
                </div>
              </div>
              <div class="col-md-4">
                <label for="validationCustom02" class="form-label">Last name</label>
                <input type="text" class="form-control" id="divId" required>
                <div class="valid-feedback">
                  Looks good!
                </div>
              </div>
              <div class="col-12">
            <button type="button" class="btn btn-primary" id="editName" onclick="saveCreateDepartment()">Save</button>
            </div>
            </form>
            `;
        $("#createData").html(temp);
        console.log(res.data.id);
    }).fail((err) => {
        console.log(err);
    });
}


function saveCreateDepartment() {
    var Nama = $('#departName').val();
    var DivisionId = parseInt($('#divId').val());

    //let DivId = $('departId')

    var result = { Nama, DivisionId };
    $.ajax({
        url: `https://localhost:7240/api/Department`,
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