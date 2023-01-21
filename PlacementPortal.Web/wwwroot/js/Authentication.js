
$("#btnLogIn").click(function () {
    debugger;
    $("#message").html("Logging in...");
    var data = {
        "userid": $("#Username").val(),
        "password": $("#Password").val()
    };
    val1 = "5";
    val2 = "2";
    $.ajax({
        url: "/Authentication/CheckUser",
        contentType: "application/json; charset=utf-8",
        type: "POST",
        //data: JSON.stringify(data),
        data: { number1: val1, number2: val2 },
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