
$(function () {
    $.ajaxSetup({ cache: false });
    $(".viewDialog").click(function (e) {

        e.preventDefault();
        $.get(this.href, function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
        });
    });
})

$(function () {
    $.ajaxSetup({ cache: false });
    $("#DelPopup1").click(function (e) {

        e.preventDefault();
        $.get(this.href, function (data) {
            $('#dialogContentDel').html(data);
            $('#modDialogDel').modal('show');
        });
    });
})
