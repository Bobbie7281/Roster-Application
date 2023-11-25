$(document).ready(function () {
    $("#Save").on("click", function () {//when save button is clicked update the following variables with the data of all the fields
        var name = $("#EmployeeName").val();
        var surname = $("#EmployeeSurname").val();
        var address = $("#EmployeeAddress").val();
        var contactNumber = $("#EmployeeContactNumber").val();
        var emailAddress = $("#EmployeeEmail").val();
        var category = $("#SelectCategory").val();

        var message = "The folowing errors where encountered:\n\n";

        //This array contains the values of the elements used in this script.
        var employeeData = [name, surname, address, contactNumber, emailAddress, category];

        //The following array contains the id's of the elements used in this script
        var ids = [$("#EmployeeName"), $("#EmployeeSurname"), $("#EmployeeAddress"), $("#EmployeeContactNumber"), $("#EmployeeEmail"), $("#SelectCategory")];

        //The following array contains the text that represents each element in the ids array. 
        var elementsNames = ["Name", "Surname", "Address", "Contact Number", "Email Address", "Category"];

        $.ajax({
            url: "/Employee/SCheckDataPriorSaving",
            type: "POST",
            data: { empData: employeeData },
            success: function (data) {

                //If the last element of the array is bigger then 0 execute the following
                if (data[data.length - 1] != "0") {
                    //Remove the last element from data, as it only contains the total number of errors and
                    //shouldn't be included in the for each loop below.

                    data.pop();
                    //index represents the index number of the data array and the element is the data 
                    $.each(data, function (index, element) {

                        //If the element in the data array is not Orange, execute the following.
                        if (element != "Green") {

                            //the same index is used for the data array, to make reference to the id in the array ids and change it's background.
                            ids[index].css("background-color", "Orange");

                            //the same index is used for the elementsNames array to make reference to the name in the array and used in the message.
                            message += elementsNames[index] + " is blank.\n";
                        }
                        else {
                            ids[index].css("background-color", "White");
                        }

                        //If the index reached the end of the array, show the error message.
                        if (index + 1 == data.length) {
                            alert(message += "\n Saving not possible. Correct all errors in order to save.");
                        }

                    });
                }
                else {//If the last element of the array is 0 execute the following
                    $.ajax({
                        //call the method SSaveEmployeeDetails
                        url: "/Employee/SSaveEmployeeDetails",
                        type: "POST",

                        //The array employeeData will be passed to the parameter empData in the SSaveEmployeeDetails.
                        data: { empData: employeeData },
                        success: function (response) {

                            //if the response returned by the method is true, location.reload() will call CreateNewEmployee() method.
                            if (response.isValid) {
                                location.reload();
                            }
                        }
                    });
                }
            }
        });
    });
});