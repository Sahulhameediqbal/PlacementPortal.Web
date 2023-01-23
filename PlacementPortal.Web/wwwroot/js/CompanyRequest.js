$(document).ready(function () {
    GetAllCompanyRequest();
});

function GetAllCompanyRequest() {
    
    $.ajax({
        type: "Get",
        url: "/CompanyRequest/GetAllCompanyRequest",
        dataType: "json",
        contentType: "application/json; charset=utf-8",

        success: function (result) {
            
            $("#CompanyRequestList tbody").empty();
            $.each(result.data, function (key, value) {

                var rows = "<tr>"
                    + "<td>" + value.id + "</td>"
                    + "<td>" + value.CompanyId + "</td>"
                    + "<td>" + value.CollegeId + "</td>"
                    + "<td>" + value.RecuritmentDate + "</td>"
                    + "<td>" + value.MinimumPercenage + "</td>"
                    + "<td>" + value.NoofInterviewRound + "</td>"
                    + "<td>" + (value.isActive == true ? "Active" : "InActive") + "</td>"
                    + "</tr>"
                $("#CompanyRequestList tbody").append(rows);
            })
        },
        error: function (req, status, error) {
            $("#message").html("Error while Loading College Details!");
        }
    });
}

$("#btnSaveComapnyRequest").click(function () {
    $("#message").html("Logging in...");

    if (!validation()) {
        return false;
    }

    var companyRequestData = {
        //Code: $("#Code").val(),
        CompanyId: $("#CompanyId").val(),
        CollegeId: $("#CollegeId").val(),
        RecuritmentDate: $("#RecuritmentDate").val(),
        DepartmentId: $("#DepartmentId").val(),
        MinimumPercenage: $("#MinimumPercenage").val(),
        NoofInterviewRound: $("#NoofInterviewRound").val(),
        NoOfRequirement: $("#NoofRequirement").val(),
        Comments: $("#Comments").val(),
        IsActive: $("#IsActive").is(':checked'),
        CollegeResponse: $("#CollegeResponse").is(':checked')
    };

    $.ajax({
        url: "/CompanyRequest/AddCompanyRequest",
        contentType: "application/json; charset=utf-8",
        type: "POST",
        data: JSON.stringify(companyRequestData),
        dataType: "json",
        success: function (status) {            
            ClearControls();
            $("#message").html(status.message);
        },
        error: function (req, status, error) {
            $("#message").html("Error while inserting Company Request data!");
        }
    });
});

function validation() {
    var isValid = true;
    //if ($("#Code").val() == '') {
    //    $("#message").html("Please enter Code");
    //    isValid = false;
    //}
    if ($("#RecuritmentDate").val() == '') {
        $("#message").html("Please enter RecuritmentDate");
        isValid = false;
    }
    else if ($("#MinimumPercenage").val() == '') {
        $("#message").html("Please enter Minimum Percenage");
        isValid = false;
    }
    else if ($("#NoofInterviewRound").val() == '') {
        $("#message").html("Please enter No of Interview Round");
        isValid = false;
    }
    else if ($("#NoofRequirement").val() == '') {
        $("#message").html("Please enter No of Requirement");
        isValid = false;
    }
    else if ($("#Comments").val() == '') {
        $("#message").html("Please enter Comments");
        isValid = false;
    }
    return isValid;
}

function ClearControls() {
    //$("#Code").val('');
    $("#RecuritmentDate").val('');
    $("#MinimumPercenage").val('');
    $("#NoofInterviewRound").val('');
    $("#NoofRequirement").val('');
    $("#Comments").val('');
}

