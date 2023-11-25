$(document).ready(function () {
    $("#Save").click(function () {
        var selectedName = $("#selectClient").val();
        var name = $("#copyNewClientName").val();
        var clientAddress = $("#Address").val();
        var contact = $("#Contact").val();
        var scheduleName = $("#scheduleOptions").val();
        var categoryName = $("#categoryOptions").val();
        var totHours = $("#TotalHours").val();
        var message = "The folowing errors where encountered:\n\n";

        $.ajax({
            url: "/Client/SCheckDataPriorSaving",
            type: "POST",
            data: { editingCurrentClient: false, selectedSchedule: selectedName, clientName: name, address: clientAddress, contactNum: contact, schedule: scheduleName, category: categoryName, totalHours: totHours },
            success: function (data) {
                //update all the input fields with the returned data from the method SCheckDataPriorSaving
                if (data[0] == "Orange") { $("#newClientName").css("background-color", "orange"); message += "-Client Name, either exists or blank or not in the correct format.\n"; }
                else { $("#newClientName").css("background-color", "white"); }

                if (data[1] == "Orange") { $("#Address").css("background-color", "orange"); message += "-Client Address is blank.\n"; }
                else { $("#Address").css("background-color", "white"); }

                if (data[2] == "Orange") { $("#Contact").css("background-color", "orange"); message += "-Client Contact is Blank.\n"; }
                else { $("#Contact").css("background-color", "white"); }

                if (data[3] == "Orange") { $("#scheduleOptions").css("background-color", "orange"); message += "-Schedule not selected\n"; }
                else { $("#scheduleOptions").css("background-color", "white"); }

                if (data[4] == "Orange") { $("#categoryOptions").css("background-color", "orange"); message += "-Category not selected.\n"; }
                else { $("#categoryOptions").css("background-color", "white"); }

                if (data[5] == 0)//data at location 8 stores the amount of errors encountered while checking the data. If the amount is 0, execute the following code.
                {
                    $.ajax({
                        url: "/Client/SCreateNewClient",
                        type: "POST",
                        data: { clientName: name, address: clientAddress, contactNum: contact, schedule: scheduleName, category: categoryName, totalHours: totHours },
                        success: function (response) {
                            if (response.isValid) {
                                //alert("Save Successfully");
                                //if (confirm) //after pressing the ok button of the message, the page will refresh
                                //{
                                location.reload();
                                //}
                            }
                        }
                    });
                }
                else {
                    alert(message += "\n Saving not possible. Correct all errors in order to save.");
                }
            }
        });
    });
});