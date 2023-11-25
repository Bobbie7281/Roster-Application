$(document).ready(function () {

    $("#selectEmployee").on("change", function () { //When a Employee name is selected

        var ids = [$("#NewEmployeeName"), $("#NewEmployeeSurname"), $("#NewAddress"), $("#NewContact"), $("#NewEmployeeEmail"), $("#SelectNewCategory")];

        var selectEmployee = $(this).find("option:selected").text(); //The Employee name will be saved in selectEmployee
        $.ajax({
            url: "/Employee/SGetData",//SGetData is a method located in the Employee controller
            type: "POST",//The method will be of type post ([HttpPost])
            data: { EmployeeName: selectEmployee },//selectEmployee variable will be passed to the parameter EmployeeName of the SGetData method
            success: function (data) {//upon return the disabled attribute will be removed for the following elements

                document.getElementById("NewEmployeeName").removeAttribute("disabled");
                document.getElementById("NewEmployeeSurname").removeAttribute("disabled");
                document.getElementById("NewAddress").removeAttribute("disabled");
                document.getElementById("NewContact").removeAttribute("disabled");
                document.getElementById("NewEmployeeEmail").removeAttribute("disabled");
                document.getElementById("SelectNewCategory").removeAttribute("disabled");
                document.getElementById("Save").removeAttribute("disabled");
                console.log(data);
                //data returned from the method will be displayed in the following input fields
                $.each(data, function (index, element) {
                    ids[index].val(data[index]);
                    console.log(ids[index], data[index]);
                });
            },
            error: function (xhr, status, error) {
                console.log("Ajax Error: " + status + " - " + error);
                console.log(xhr.responseText);
            }
        });
    });
});