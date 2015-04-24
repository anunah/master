/*$(function ($) {

    $.ajaxSetup({ cache: false });

    $(".DelPopup").on("click", function (e) {
        e.preventDefault();

        $("<div></div>")
            .addClass("dialog")
            .appendTo("body")
            .dialog({
                title: $(this).attr("data-dialog-title"),
                close: function () { $(this).remove() },
                modal: true
            })
            .load(this.href);
    });
    $(".close").on("click", function (e) {
        e.preventDefault();
        $(this).closest(".dialog").dialog("close");
    });
});*/
function DelAjax() {
    _thisdel = this;

    this.initDel = function () {
        $(".DelPopup").click(function (e) {
            e.preventDefault();
            _thisdel.showPopupDel(this.href, initDelPopup);
        });
    }

    this.showPopupDel = function (url, callback) {
        $.ajax({
            type: "GET",
            url: url,
            success: function (data) {
                showModalDataDel(data, callback);
            }
        });
    }

    function initDelPopup(modal) {
        $("#DelButton").click(function () {
            $.ajax({
                type: "POST",
                url: "/AddTest/Delete",
                data: $("#DelForm").serialize(),
                success: function (data) {
                    showModalDataDel(data);
                    initDelPopup(modal);
                }
            });
        });
    }

    function showModalDataDel(data, callback) {
        $(".modal-backdrop").remove();
        var popupWrapper = $("#dialogContentDel");
        popupWrapper.empty();
        popupWrapper.html(data);
        $('#modDialogDel').modal('show');
        var popup = $(".modal", popupWrapper);
        $(".modal", popupWrapper).modal();
        if (callback != undefined) {
            callback(popup);
        }
    }
}

var Delajax = null;
$().ready(function () {
    Delajax = new DelAjax();
    Delajax.initDel();
});