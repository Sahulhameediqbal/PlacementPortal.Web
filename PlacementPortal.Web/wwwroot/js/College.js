
$("#btnCollegeSave").click(function () {
    debugger;
    $("#message").html("Logging in...");
        
    if (!validation()) {
        return false;
    }

    var collegeData = {
        Code: $("#Code").val(),
        Name: $("#Name").val(),
        Email: $("#Email").val(),
        PhoneNumber: $("#PhoneNumber").val(),
        Address: $("#Address").val(),
        IsActive: $("#IsActive").is(':checked')
    };

    $.ajax({
        url: "/College/AddCollege",
        contentType: "application/json; charset=utf-8",
        type: "POST",
        data: JSON.stringify(collegeData),
        dataType: "json",
        success: function (status) {
            debugger;
            ClearControls();
            $("#message").html(status.message);
        },
        error: function (req, status, error) {
            alert(error);
            $("#message").html("Error while inserting College data!");
        }
    });
});

function validation() {
    var isValid = true;
    if ($("#Code").val() == '') {        
        $("#message").html("Please enter Code");
        isValid = false;
    }
    else if ($("#Name").val() == '') {
        $("#message").html("Please enter Name");
        isValid = false;
    }
    else if ($("#Email").val() == '') {
        $("#message").html("Please enter Email");
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
    $("#Code").val('');
    $("#Name").val('');
    $("#Email").val('');
    $("#PhoneNumber").val('');
    $("#Address").val('');
}

