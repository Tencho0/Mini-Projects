var dataTable;

$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("approved")) {
        loadDataTable("approved");
    } else {
        if (url.includes("readyforpickup")) {
            loadDataTable("readyforpickup");
        } else {
            if (url.includes("cancelled")) {
                loadDataTable("cancelled");
            } else {
                loadDataTable("all");
            }
        }
    }
});

function loadDataTable(status) {
    dataTable = $('#tblData').DataTable({
        order: [[0, 'desc']],
        "ajax": { url: "/order/getall?status=" + status, type: "GET", dataSrc: "data" },
        "columns": [
            { data: 'orderHeaderId', "width": "5%" },
            { data: 'email', "width": "25%" },
            { data: 'name', "width": "20%" },
            { data: 'phone', "width": "10%" },
            { data: 'status', "width": "10%" },
            {
                data: 'orderTotal',
                "width": "10%",
                "render": function (data, type, row) {
                    if (!data || isNaN(data)) return "0.00"; // Handles null, undefined, or non-numeric data
                    return Number(data).toFixed(2); // Ensures rounding works properly
                }
            },
            {
                data: 'orderHeaderId',
                "render": function (data) {
                    return `<div class="w-75 btn-group" role="group">
                    <a href="/order/orderDetail?orderId=${data}" class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i></a>
                    </div>`
                },
                "width": "10%"
            }
        ]
    })
}