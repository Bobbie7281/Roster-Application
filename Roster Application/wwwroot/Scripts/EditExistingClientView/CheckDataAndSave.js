$(document).ready(function () {
    $("#save").click(function () {//When the save button is clicked, the following variables will take the values of their respective elements.
        var selectedName = $("#selectClient").val();
        var newName = $("#NewClientName").val();
        var address = $("#Address").val();
        var contact = $("#Contact").val();
        var schedule = $("#selectSchedule").val();
        var category = $("#selectCatgory").val();
        var totalHours = $("#TotalHours").val();
        var message = "The folowing errors where encountered:\n\n";


        $.ajax({
            url: "/Client/SCheckDataPriorSaving",//SCheckDataPriorSaving is a method located in the client controller.
            type: "POST",//The method will be of type post. 
            //All the varibles will be passed to the parameters of the SCheckDataPriorSaving method
            data: { editingCurrentClient: true, selectedName: selectedName, clientName: newName, address: address, contactNum: contact, schedule: schedule, category: category, totalHours: totalHours },
            success: function (data) {

                if (data[5] == 0)//data at location 6 stores the amount of errors encountered while checking the data. If the amount is 0, execute the following code and save.
                {
                    $.ajax({
                        url: "/Client/SEditClient",
                        type: "POST",
                        data: { selectedName: selectedName, newClientName: newName, address: address, contact: contact, schedule: schedule, category: category, totalHours: totalHours },
                        success: function (response) {
                            if (response.isValid) {
                                console.log(response);
                                location.reload();//This will refresh the page 

                            }
                        }
                    });
                }
                else {
                    //The elements that encountered an error will have their background colour changed to Orange and an alert message will be displayed.

                    if (data[0] == "Orange") { $("#NewClientName").css("background-color", "orange"); message += "-Client Name, either exists or blank or not in the correct format.\n"; }
                    else { $("#NewClientName").css("background-color", "white"); }
                    if (data[1] == "Orange") { $("#Address").css("background-color", "orange"); message += "-Address is either blank or not in the correct format.\n"; }
                    else { $("#Address").css("background-color", "white"); }
                    if (data[2] == "Orange") { $("#Contact").css("background-color", "orange"); message += "-Contact Details are either blank or not in the correct format.\n"; }
                    else { $("#Contact").css("background-color", "white"); }
                    if (data[3] == "Orange") { $("#selectSchedule").css("background-color", "orange"); message += "-Selected Schedule is either blank or not in the correct format.\n"; }
                    else { $("#selectSchedule").css("background-color", "white"); }
                    if (data[4] == "Orange") { $("#selectCatgory").css("background-color", "orange"); message += "-Selected Category is either blank or not in the correct format.\n"; }
                    else { $("#selectCatgory").css("background-color", "white"); }
                    if (data[5] == "Orange") { $("#TotalHours").css("background-color", "orange"); message += "-Total Hours are either blank or not in the correct format.\n"; }
                    else { $("#TotalHours").css("background-color", "white"); }

                    alert(message += "\n Saving not possible. Correct all errors in order to save.");
                }
            }
        });
    });
});