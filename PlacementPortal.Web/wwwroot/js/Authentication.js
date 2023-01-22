
$("#btnLogIn").click(function () {
    debugger;
    $("#message").html("Logging in...");

    if (!validation()) {
        return false;
    }

    var data = {
        Email: $("#Email").val(),
        Password: $("#Password").val()
    };
    
    $.ajax({
        url: "/Authentication/CheckUser",
        contentType: "application/json; charset=utf-8",
        type: "POST",
        data: JSON.stringify(data),
        dataType: "json",
        success: function (result) {
            debugger;
            alert("Success")
            $("#message").html(result.message);
            if (result.status) {
                window.location.href = "https://localhost:7014/Home/Index";//status.TargetURL;
            }
        },
        error: function (req, result, error) {
            console.log(error);
            $("#message").html("Error while authenticating user credentials!");
            }
    });
});

$('#Password').bind("cut copy paste", function (e) {
    e.preventDefault();
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

    return isValid;
}

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