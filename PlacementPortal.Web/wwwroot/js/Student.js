$(document).ready(function () {
    GetAllCollege();
    GetAllCourse();
    GetAllDepartment();
});

function GetAllCollege() {
    debugger;
    $.ajax({
        type: "Get",
        url: "/College/GetAllCollege",
        dataType: "json",
        contentType: "application/json; charset=utf-8",

        success: function (result) {
            debugger;
            $.each(result.data, function (key, value) {
                $("#CollegeId").append($("<option></option>").val(value.id).html(value.name));
            })
        },
        error: function (req, status, error) {
            alert(error);
            $("#message").html("Error while Loading College Details!");
        }
    });
}

function GetAllCourse() {
    debugger;
    $.ajax({
        type: "Get",
        url: "/Student/GetAllCourse",
        dataType: "json",
        contentType: "application/json; charset=utf-8",

        success: function (result) {
            debugger;
            $.each(result.data, function (key, value) {
                $("#CourseId").append($("<option></option>").val(value.id).html(value.name));
            })
        },
        error: function (req, status, error) {
            alert(error);
            $("#message").html("Error while Loading Course Details!");
        }
    });
}

function GetAllDepartment() {
    debugger;
    $.ajax({
        type: "Get",
        url: "/Student/GetAllDepartment",
        dataType: "json",
        contentType: "application/json; charset=utf-8",

        success: function (result) {
            debugger;
            $.each(result.data, function (key, value) {
                $("#DepartmentId").append($("<option></option>").val(value.id).html(value.name));
            })
        },
        error: function (req, status, error) {
            alert(error);
            $("#message").html("Error while Loading Department Details!");
        }
    });
}

$("#btnSaveStudent").click(function () {

    if (!validation()) {
        return false;
    }

    var studentData = {
        Name: $("#Name").val(),
        CollegeId: $("#CollegeId").val(),
        CourseId: $("#CourseId").val(),
        DepartmentId: $("#DepartmentId").val(),
        Email: $("#Email").val(),
        PhoneNumber: $("#PhoneNumber").val(),
        Rollumber: $("#Rollumber").val(),
        Gender: $("#Gender").val(),
        DOB: $("#DOB").val(),
        CourseStart: $("#CourseStart").val(),
        CourseEnd: $("#CourseEnd").val(),        
        CGPA: $("#CGPA").val(),        
        Address: $("#Address").val(),
        IsActive: $("#IsActive").is(':checked')
    };

    $.ajax({
        type: "POST",
        url: "/Student/AddStudent",
        dataType: "json",
        contentType: "application/json",        
        data: JSON.stringify(studentData),
        
        success: function (status) {
            debugger;
            ClearControls();
            $("#message").html(status.message);
        },
        error: function (req, status, error) {
            alert(error);
            $("#message").html("Error while authenticating user credentials!");
        }
    });
});

function validation() {
    var isValid = true;

    if ($("#Name").val() == '') {
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
    else if ($("#Rollumber").val() == '') {
        $("#message").html("Please enter Rollumber");
        isValid = false;
    }
    else if ($("#DOB").val() == '') {
        $("#message").html("Please enter DOB");
        isValid = false;
    }
    else if ($("#Address").val() == '') {
        $("#message").html("Please enter Address");
        isValid = false;
    }
    return isValid;
}

function ClearControls() {
    $("#Name").val('');
    $("#Email").val('');
    $("#PhoneNumber").val('');
    $("#Rollumber").val('');
    $("#DOB").val('');
    $("#Address").val('');
}

$('#DOB').bind("cut copy paste", function (e) {
    e.preventDefault();
});