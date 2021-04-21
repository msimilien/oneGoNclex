function clearCardItems() {
    $(".card-item").each(function (index, card) {
        $(card).removeClass("selected-red");
        $(card).removeClass("selected-blue");
        $("#txtIsPremium").val("");
    });
}
$(function () {
    $(".card-item").each(function (index, card) {
        $(card).on("click", function () {
            clearCardItems();

            if ($(this).hasClass("border-danger")) {
                $(this).addClass("selected-red");
                $("#txtIsPremium").val("true");
            } else {
                $(this).addClass("selected-blue");
                $("#txtIsPremium").val("false");
            }

            $("#txtCost").val($(this).find(".card-footer h5").text().replace("Cost: ", "").replace("USD", ""));
            $("#txtDays").val($(this).find(".card-body h5").text());
        });
    });

    $("#btnConfirmPayment").on("click", function (e) {
        if ($("#txtCost").val() === "") {
            e.preventDefault();
            $("#lblValidation").fadeIn();
            return;
        } else
            $("#lblValidation").fadeOut();
    });
});