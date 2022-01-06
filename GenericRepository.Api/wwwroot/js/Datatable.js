$(document).ready(function () {
    $("#example").datatable({
        "processing": true,
        "serverside": true,
        "filter": true,
        "ajax": {
            "url": "https://localhost:44363/api/company/getallcompanies",
            "type": "POST",
            "datatype": "json",
            "contenttype": "application/x-www-form-urlencoded",
        },
        "columndefs": [{
            "targets": [0],
            "visible": false,
            "searchable": false
        }],
        "columns": [
            { "data": "companyId", "name": "companyId", "autowidth": true },
            { "data": "companyName", "name": "companyName", "autowidth": true },
            { "data": "adress", "name": "adress", "autowidth": true },
            { "data": "isActive", "name": "isActive", "autowidth": true },

            {
                "render": function (data, row) { return "<a href='#' class='btn btn-danger' onclick=deletecustomer('" + row.id + "'); >delete</a>"; }
            },
        ]
    });
});
//<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.5.2/css/bootstrap.css">
//    <link rel="stylesheet" href="https://cdn.datatables.net/1.11.3/css/dataTables.bootstrap4.min.css">
//        <link rel="stylesheet" href="https://cdn.datatables.net/1.11.3/css/jquery.dataTables.min.css">
//<script>
//        src="https://code.jquery.com/jquery-3.6.0.min.js"
//        integrity="sha256-/xUj+3OJU5yExlq6GSYGSHk7tPXikynS7ogEvDej/m4="
//        crossorigin="anonymous"></script>
//<script>
//    $(document).ready(function() {
//        $('#example').DataTable();
//    });
//            </script>

//<script src="https://cdn.datatables.net/1.11.3/js/jquery.dataTables.min.js"></script>