
$("#btnLogIn").click(function () {
    debugger;
    $("#message").html("Logging in...");

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
        success: function (status) {
            debugger;
            alert("Success")
            $("#message").html(status.message);
            if (status.success) {
                window.location.href = "https://localhost:7014/Home/Index";//status.TargetURL;
            }
        },
        error: function (req, status, error) {
            console.log(error);
            $("#message").html("Error while authenticating user credentials!");
            }
    });
});

$('#Password').bind("cut copy paste", function (e) {
    e.preventDefault();
});