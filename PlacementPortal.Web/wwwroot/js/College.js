﻿
$("#btnCollegeSave").click(function () {
    debugger;
    $("#message").html("Logging in...");

    var collegeData = {
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
        data: collegeData,
        dataType: "json",
        success: function (status) {
            debugger;
            alert("Success")
            $("#message").html(status.message);
        },
        error: function (req, status, error) {
            alert(error);
            $("#message").html("Error while inserting College data!");
        }
    });
});