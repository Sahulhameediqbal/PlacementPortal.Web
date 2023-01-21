$("#btnStudent").click(function () {

    var studentData = {
        Name: $("#Name").val(),
        CollegeId: $("#CollegeId").val(),
        DepartmentId: $("#DepartmentId").val(),
        Email: $("#Email").val(),
        PhoneNumber: $("#PhoneNumber").val(),
        Rollumber: $("#Rollumber").val(),
        GenderId: $("#GenderId").val(),
        DOB: $("#DOB").val(),
        CourseStart: $("#CourseStart").val(),
        CourseEnd: $("#CourseEnd").val(),        
        CGPA: $("#CGPA").val(),        
        Address: $("#Address").val(),
        IsActive: $("#IsActive").val(),
    };

    $.ajax({
        url: "/Student/AddStudent",
        contentType: "application/json; charset=utf-8",
        type: "POST",
        data: JSON.stringify(studentData),
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