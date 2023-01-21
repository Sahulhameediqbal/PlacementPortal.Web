
$("#btnCollegeSave").click(function () {
    debugger;
    $("#message").html("Logging in...");
    var data = {
        "Code": $("#Code").val(),
        "Name": $("#Name").val(),
        "Email": $("#Email").val(),
        "PhoneNumber": $("#PhoneNumber").val(),
        "Address": $("#Address").val(),
        "IsActive": $("#IsActive").val()
    };
    var formData = {
        Code: $("#Code").val(),
        Name: $("#Name").val(),
        Email: $("#Email").val(),
        PhoneNumber: $("#PhoneNumber").val(),
        Address: $("#Address").val(),
        IsActive: $("#IsActive").val()
    };

    $.ajax({
        url: "/College/AddCollege",
        contentType: "application/json; charset=utf-8",
        type: "POST",
        data: formData,
        dataType: "json",
        success: function (status) {
            debugger;
            alert("Success")
            $("#message").html(status.message);
        },
        error: function (req, status, error) {
            alert(error);
            $("#message").html("Error while authenticating user credentials!");
        }
    });
});