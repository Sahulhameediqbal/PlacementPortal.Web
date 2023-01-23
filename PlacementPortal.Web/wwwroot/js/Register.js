$("#btnSaveRegister").click(function () {
    
    $("#message").show();
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
            window.location.href = "/Authentication/LogIn";
        },
        error: function (req, status, error) {
            $("#message").html("Error while Register the User");
        }
    });
});

function validation() {
    var isValid = true;

    var mailId = $("#Email").val();
    var password = $("#Password").val();

    if (mailId == '') {
        $("#message").html("Please enter Email");
        isValid = false;
    }
    else if (IsEmail(mailId) == false) {
        $("#message").html("Invalid email");
        return false;
    }
    else if (password == '') {
        $("#message").html("Please enter Password");
        isValid = false;
    }
    else if (password <= 7) {
        $("#message").html("Password must be minimum 8 digits");
        isValid = false;
    }
    else if (PasswordValidator(password) == false) {
        $("#message").html("Invalid email");
        return false;
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
    $("#Email").val('');
    $("#Password").val('');
    $("#ConfirmPassword").val('');
    $("#Name").val('');
    $("#RollNumber").val('');
    $("#Code").val('');    
    $("#PhoneNumber").val('');    
    $("#Address").val('');
}

$('#Password, #ConfirmPassword').bind("cut copy paste", function (e) {
    e.preventDefault();
});

function IsEmail(email) {
    var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!regex.test(email)) {
        return false;
    } else {
        return true;
    }
}

function PasswordValidator(passwordstrength) {
    var regex = new Array();
    regex.push("[A-Z]"); //Uppercase Alphabet.
    regex.push("[a-z]"); //Lowercase Alphabet.
    regex.push("[0-9]"); //Digit.
    regex.push("[!@#$%^&*]"); //Special Character.

    var passed = 0;
    for (var i = 0; i < regex.length; i++) {
        if (new RegExp(regex[i]).test(passwordstrength)) {
            passed++;
        }
    }

    if (passed > 3) {
        // alert("Valid");
    }
    else {
        alert("Password must contain at least 1 capital letter,\n\n1 small letter, 1 number and 1 special character.\n\nFor special characters you can pick one of these -,(,!,@,#,$,),%,<,>");
        return false;
    }
}

function GetAllRegister() {

    $.ajax({
        type: "Get",
        url: "/Register/GetAllRegister",
        dataType: "json",
        contentType: "application/json; charset=utf-8",

        success: function (result) {

            $("#RegisterInfo tbody").empty();
            $.each(result.data, function (key, value) {

                var rows = "<tr>"
                    + "<td>" + value.id + "</td>"
                    + "<td>" + value.name + "</td>"
                    + "<td>" + value.email + "</td>"
                    + "</tr>"
                $("#RegisterInfo tbody").append(rows);
            })
        },
        error: function (req, status, error) {
            $("#message").html("Error while Loading Student Details!");
        }
    });
}