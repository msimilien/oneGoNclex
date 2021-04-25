paypal.Buttons({
    createOrder: function (data, actions) {
        return actions.order.create({
            purchase_units: [{
                amount: {
                    value: $.trim($("#lblCost").text()),
                    currency: 'USD'
                }
            }]
        });
    },
    onApprove: function (data, actions) {
        return actions.order.capture().then(function (details) {
            $("#modalPayment").modal("show");
            $("#lblTicketID").text($(details).attr("id")).fadeIn();
            $("#lblPaymentDate").text($(details).attr("create_time")).fadeIn();
            $(".paypal-data").fadeIn();
            $("#txtID").val($(details).attr("id"));
            $("#txtDate").val($(details).attr("create_time"));
            $('#paypal-button-container').fadeOut();
        });
    },
    onError: function (err) {
        $("#modalPaymentError").modal("show");
    },
    onCancel: function (data) {
        $("#modalPaymentCancel").modal("show");
    }
}).render('#paypal-button-container');

function ConfirmTransaction() {
    $("#btnConfirm").trigger("click");
}