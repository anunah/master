/*$(document).ready(function () {
    $(".alert").addClass("in").fadeOut(4500);

    /* swap open/close side menu icons 
    $('[data-toggle=collapse]').click(function () {
        // toggle icon
        $(this).find("i").toggleClass("glyphicon-chevron-right glyphicon-chevron-down");
    });
});

$('a[data-toggle="tab"]').on('shown',function(e){
    e.target // активная вкладка
    e.relatedTarget // предыдущая вкладка
})

$(function(){
    $('#myTab a:last').tab('show');
})*/

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
/*
$("#Timer").bind("load", function () {
        timeoutId = setInterval(go, 1000)
    });
    function go() {
        time = $("#Timer").val()
        if (time != 0) {
            res = time - 1
            $("#Timer").val(res)
            var h = res / 3600 ^ 0;
            var m = (res - h * 3600) / 60 ^ 0;
            var s = res - h * 3600 - m * 60;
            $("#TimerText").text((h < 10 ? "0" + h : h) + " : " + (m < 10 ? "0" + m : m) + " : " + (s < 10 ? "0" + s : s))
        }
        else {
            var idusertest = $("#idUserTest").val()
            window.location.href = "/Test/EndTest/" + idusertest;
        }

    }*/

/*$(document).ready(function () {

    $.ajaxSetup({ cache: false });

    $(".viewDialogModal").on("click", function (e) {
        e.preventDefault();

        $("<div id='dialogContent'></div>")
            .load(this.href)
            .dialog({
                title: $(this).attr("data-dialog-title"),
                close: function () { $(this).remove() },
                modal: true,
                buttons: {
                    "Сохранить": function () {
                        $.ajax({
                            url: "/Account/LoginAjax",
                            type: "POST",
                            data: $('#LoginForm').serialize(),
                            datatype: "json",
                            success: function (result) {
                                $("#dialogContent").html(result);
                            }
                        });
                    }
                }
            });

    });
    $(".close").on("click", function (e) {
        e.preventDefault();
        $(this).closest("#dialogContent").dialog("close");
    });
});*/
/*$(function () {
    $.ajaxSetup({ cache: false });
    $(".viewDialogModal").click(function (e) {

        e.preventDefault();
        $.get(this.href, function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
        });
    });
    
})
$(function () {
    $("#LoginButton").click(function () {
        $.ajax({
            type: "POST",
            url: "/Account/LoginAjax",
            data: $("#LoginForm").serialize(),
            success: function (data) {
                $("#dialogContent").html(data);
            }
        });
    });
});*/

