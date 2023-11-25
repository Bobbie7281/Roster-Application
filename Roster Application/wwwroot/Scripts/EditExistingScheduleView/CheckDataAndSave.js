        $(document).ready(function () {
            $("#save").click (function () {
                var selectedName = $("#selectSchedule").val();
                var name = $("#scheduleName").val();
                var mon = $("#monday").val();
                var tue = $("#tuesday").val();
                var wed = $("#wednesday").val();
                var thur = $("#thursday").val();
                var fri = $("#friday").val();
                var sat = $("#saturday").val();
                var sun = $("#sunday").val();
                var totalHours = $("#totalHours").val();
                var message="The folowing errors where encountered:\n\n";

                $.ajax({
                url: "/Schedule/SCheckDataPriorSaving",
                type:"POST",
                    data: { editingCurrentSchedule: true, selectedSchedule: selectedName, newSchName: name, monHrs: mon, tueHrs: tue, wedHrs: wed, thurHrs: thur, friHrs: fri, satHrs: sat, sunHrs: sun },
                success: function(data) 
                {
                    //update all the input fields with the returned data from the method SCheckDataPriorSaving
                    if (data[0] == "Orange") { $("#scheduleName").css("background-color", "orange"); message += "-Schedule Name, either exists or blank or not in the correct format.\n"; }
                    else { $("#scheduleName").css("background-color", "white"); }
                    if (data[1] == "Orange") { $("#monday").css("background-color", "orange"); message += "-Monday Hours are either blank or not in the correct format.\n"; }
                        else { $("#monday").css("background-color", "white"); }
                    if (data[2] == "Orange") { $("#tuesday").css("background-color", "orange"); message += "-Tuesday Hours are either blank or not in the correct format.\n"; }
                        else { $("#tuesday").css("background-color", "white"); }
                    if (data[3] == "Orange") { $("#wednesday").css("background-color", "orange"); message += "-Wednesday Hours are either blank or not in the correct format.\n"; }
                        else { $("#wednesday").css("background-color", "white"); }
                    if (data[4] == "Orange") { $("#thursday").css("background-color", "orange"); message += "-Thursday Hours are either blank or not in the correct format.\n"; }
                        else { $("#thursday").css("background-color", "white"); }
                    if (data[5] == "Orange") { $("#friday").css("background-color", "orange"); message += "-Friday Hours are either blank or not in the correct format.\n"; }
                        else { $("#friday").css("background-color", "white"); }
                    if (data[6] == "Orange") { $("#saturday").css("background-color", "orange"); message += "-Saturday Hours are either blank or not in the correct format.\n"; }
                        else { $("#saturday").css("background-color", "white"); }
                    if (data[7] == "Orange") { $("#sunday").css("background-color", "orange"); message += "-Sunday Hours are not in the correct format.\n"; }
                        else { $("#sunday").css("background-color", "white"); }

                    if(data[8]==0)//data at location 8 stores the amount of errors encountered while checking the data. If the amount is 0, execute the following code. 
                    {
                        $.ajax({
                            url: "/Schedule/EditSchedule",
                            type: "POST",
                            data: { selectedSchedule: selectedName, newSchName: name, monHrs: mon, tueHrs: tue, wedHrs: wed, thurHrs: thur, friHrs: fri, satHrs: sat, sunHrs: sun, totHours: totalHours },
                            success: function (response) {
                                if (response.isValid) {

                                    location.reload();

                                }
                            }
                        });
                    }
                    else
                    {
                        alert(message+="\n Saving not possible. Correct all errors in order to save.");
                    }
                }
                });
            });
        });