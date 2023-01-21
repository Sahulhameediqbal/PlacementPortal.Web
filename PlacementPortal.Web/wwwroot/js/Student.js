$("#btnStudent").click(function () {
    $.ajax({
        url: "/Student/AddStudent",
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