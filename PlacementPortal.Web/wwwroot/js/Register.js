$("#btnRegister").click(function () {
    debugger;

    if ($("#Password").val() != $("#ConfirmPassword").val()) {
        $("#message").html('Password and ConfirmPassword not same.');
        return false;
    }

    var registerData = {
        Email: $("#Email").val(),
        Password: $("#Password").val(),
        ConfirmPassword: $("#ConfirmPassword").val(),
        Name: $("#Name").val(),
        UserTypeId: $("#UserTypeId").val(),
        Code: $("#Code").val(),
        PhoneNumber: $("#PhoneNumber").val(),
        Address: $("#Address").val()
    };

    $.ajax({
        url: "/Register/AddRegister",
        contentType: "application/json; charset=utf-8",
        type: "POST",
        data: JSON.stringify(registerData),
        dataType: "json",
        success: function (status) {
            debugger;
            alert("Success")
            $("#message").html(status.message);
        },
        error: function (req, status, error) {
            alert(error);
            $("#message").html("Error while Register the User");
        }
    });
});