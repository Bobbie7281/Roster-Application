$(document).ready(function () {
    $("#save").click(function () {
        var selectedName = $("#selectSchedule").val();
        var name = $("#copyNewScheduleName").val();
        var mon = $("#Mon").val();
        var tue = $("#Tue").val();
        var wed = $("#Wed").val();
        var thur = $("#Thur").val();
        var fri = $("#Fri").val();
        var sat = $("#Sat").val();
        var sun = $("#Sun").val();
        var totalHours = $("#copyTotal").val();
        var message = "The folowing errors where encountered:\n\n";

        $.ajax({
            url: "/Schedule/SCheckDataPriorSaving",
            type: "POST",
            data: { editingCurrentSchedule: false, selectedSchedule: selectedName, newSchName: name, monHrs: mon, tueHrs: tue, wedHrs: wed, thurHrs: thur, friHrs: fri, satHrs: sat, sunHrs: sun },
            success: function (data) {
                //update all the input fields with the returned data from the method SCheckDataPriorSaving
                if (data[0] == "Orange") { $("#newScheduleName").css("background-color", "orange"); message += "-Schedule Name, either exists or blank or not in the correct format.\n"; }
                else { $("#newScheduleName").css("background-color", "white"); }

                if (data[1] == "Orange") { $("#Mon").css("background-color", "orange"); message += "-Monday Hours are either blank or not in the correct format.\n"; }
                else { $("#Mon").css("background-color", "white"); }

                if (data[2] == "Orange") { $("#Tue").css("background-color", "orange"); message += "-Tuesday Hours are either blank or not in the correct format.\n"; }
                else { $("#Tue").css("background-color", "white"); }

                if (data[3] == "Orange") { $("#Wed").css("background-color", "orange"); message += "-Wednesday Hours are either blank or not in the correct format.\n"; }
                else { $("#Wed").css("background-color", "white"); }

                if (data[4] == "Orange") { $("#Thur").css("background-color", "orange"); message += "-Thursday Hours are either blank or not in the correct format.\n"; }
                else { $("#Thur").css("background-color", "white"); }

                if (data[5] == "Orange") { $("#Fri").css("background-color", "orange"); message += "-Friday Hours are either blank or not in the correct format.\n"; }
                else { $("#Fri").css("background-color", "white"); }

                if (data[6] == "Orange") { $("#Sat").css("background-color", "orange"); message += "-Saturday Hours are either blank or not in the correct format.\n"; }
                else { $("#Sat").css("background-color", "white"); }

                if (data[7] == "Orange") { $("#Sun").css("background-color", "orange"); message += "-Sunday Hours are not in the correct format.\n"; }
                else { $("#Sun").css("background-color", "white"); }

                if (data[8] == 0)//data at location 8 stores the amount of errors encountered while checking the data. If the amount is 0, execute the following code.
                {
                    $.ajax({
                        url: "/Schedule/SCreateNewSchedule",
                        type: "POST",
                        data: { newSchName: name, monHrs: mon, tueHrs: tue, wedHrs: wed, thurHrs: thur, friHrs: fri, satHrs: sat, sunHrs: sun, totHours: totalHours },
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