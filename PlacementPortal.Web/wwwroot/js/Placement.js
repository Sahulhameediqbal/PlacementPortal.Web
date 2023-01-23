function GetAllCollege() {

    $.ajax({
        type: "Get",
        url: "/College/GetAllCollege",
        dataType: "json",
        contentType: "application/json; charset=utf-8",

        success: function (result) {

            $.each(result.data, function (key, value) {
                $("#CollegeId").append($("<option></option>").val(value.id).html(value.name));
            })
        },
        error: function (req, status, error) {
            $("#message").html("Error while Loading College Details!");
        }
    });
}