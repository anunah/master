function CustomerEdit() {
    _this = this;

    this.ajaxAddOwnership = "/AddQuest/AddAnswerMethod";

    this.init = function () {
        $("#AddAnswer").click(function () {
            $.ajax({
                type: "GET",
                url: "/AddQuest/AddAnswerMethod",
                success: function (data) {
                    $("#AnswerModel").append(data);
                }
            })
        });

        $(document).on("click", ".remove-line", function () {
            $(this).closest(".answerwrapper").remove();
        });
    }
}

var customerEdit = null;
$().ready(function () {
    customerEdit = new CustomerEdit();
    customerEdit.init();
});