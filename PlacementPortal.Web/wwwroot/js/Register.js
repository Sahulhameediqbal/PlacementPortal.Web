$("#btnRegister").click(function () {
    debugger;

    if (!validation()) {
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
            ClearControls();
            $("#message").html(status.message);
        },
        error: function (req, status, error) {
            alert(error);
            $("#message").html("Error while Register the User");
        }
    });
});

function validation() {
    var isValid = true;
    if ($("#Email").val() == '') {
        $("#message").html("Please enter Email");
        isValid = false;
    }
    else if ($("#Password").val() == '') {
        $("#message").html("Please enter Password");
        isValid = false;
    }
    else if ($("#ConfirmPassword").val() == '') {
        $("#message").html("Please enter ConfirmPassword");
        isValid = false;
    }  
    else if ($("#Password").val() != $("#ConfirmPassword").val()) {
        $("#message").html('Password and ConfirmPassword not same.');
        return false;
    }  
    else if ($("#Name").val() == '') {
        $("#message").html("Please enter Name");
        isValid = false;
    }
    else if ($("#Code").val() == '') {
        $("#message").html("Please enter Code");
        isValid = false;
    }
    else if ($("#PhoneNumber").val() == '') {
        $("#message").html("Please enter PhoneNumber");
        isValid = false;
    }
    else if ($("#Address").val() == '') {
        $("#message").html("Please enter Address");
        isValid = false;
    }
    return isValid;
}

function ClearControls() {
    $("#Name").val('');
    $("#Email").val('');
    $("#PhoneNumber").val('');
    $("#Rollumber").val('');
    $("#DOB").val('');
    $("#Address").val('');
}

$('#Password, #ConfirmPassword').bind("cut copy paste", function (e) {
    e.preventDefault();
});
