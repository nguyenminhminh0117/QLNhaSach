$(document).ready(function () {
    $("#login").click(function () {
        var khachHang = {
            email: $("#InputEmail").val(),
            matkhaukh: $("#InputPassword").val(),
        };
        $.ajax({
            url: '/Home/Login/',
            type: 'POST',
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(khachHang),
            crossDomain: true,
            success: function (khachHang) {
                location.href = '/Home/Index';
            },
            error: function (request, message, error) {
                handlerExeption(request, message, error);
            }
        });
    });
});