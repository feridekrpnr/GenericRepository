$(document).ready(function () {
    $("#example").DataTable({
        processing: false,
        serverSide: true,


        ajax: {
            url: "https://localhost:44363/api/company/getallcompanies",
            type: "POST",
            dataType: "json",

            contentType: "application/x-www-form-urlencoded", /*dönen result sonucunu hangi formatta gelip gelmediğini belirler*/

        },
        columnDefs: [{
            targets: [0],
            visible: false,
            searchable: false
        }],
        columns: [
            { "data": "companyId", "name": "companyId", "autowidth": true },
            { "data": "companyName", "name": "companyName", "autowidth": true },
            { "data": "adress", "name": "adress", "autowidth": true },
            { "data": "isActive", "name": "isActive", "autowidth": true },



            {

                "data": "companyId",
                "render": function (data) {
                    return `
                    <div class= "text-center">
                    <a href="/CompEdit?id=${data}" class="btn btn-info btn-sm text-white" style="cursor:pointer; width: 70px">
                        Edit
                    </a>
                   
                    &nbsp;
                    <a class="btn btn-danger btn-sm text-white" style="cursor: pointer; width: 70px;"
                        onclick= Delete('/api/company/delete?id='+${data})>
                        Delete
                    </a>
                    </div>`;
                }, "width": "40%"
            }
        ],
        "language": {
            "emptyTable": "no data available"
        },
        "width": "100%"
    });
    table = dt.$;


    // Re-init functions on every table re-draw -- more info: https://datatables.net/reference/event/draw
    dt.on('draw', function () {


        handleEditRowDatatable();

    });
});
