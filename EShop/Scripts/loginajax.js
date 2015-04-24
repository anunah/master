function LoginAjax() {
    _this = this;
    
    this.init = function () {
        $("#LoginPopup").click(function () {
            _this.showPopup("/Account/LoginAjax", initLoginPopup);
        });
    }

    this.showPopup = function (url, callback) {
        $.ajax({
            type: "GET",
            url: url,
            success: function (data) {
                showModalData(data, callback);
            }
        });
    }

    function initLoginPopup(modal) {
        $("#LoginButton").click(function () {
            $.ajax({
                type: "POST",
                url: "/Account/LoginAjax",
                data: $("#LoginForm").serialize(),
                success: function (data) {
                    showModalData(data);
                    initLoginPopup(modal);
                }
            });
        });
    }

    function showModalData(data, callback) {
        $(".modal-backdrop").remove();
        var popupWrapper = $("#dialogContent");
        popupWrapper.empty();
        popupWrapper.html(data);
        $('#modDialog').modal('show');
        var popup = $(".modal", popupWrapper);
        $(".modal", popupWrapper).modal();
        if (callback != undefined) {
            callback(popup);
        }
    }
}

var loginajax = null;
$().ready(function () {
    loginajax = new LoginAjax();
    loginajax.init();
});