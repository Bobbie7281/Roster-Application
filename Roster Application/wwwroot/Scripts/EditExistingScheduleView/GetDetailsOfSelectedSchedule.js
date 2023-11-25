$(document).ready(function () {

            $("#selectSchedule").on("change", function () {
                var selectSchedule = $(this).find("option:selected").text();
                $.ajax({
                    url: "/Schedule/SGetData",
                    type: "POST",
                    data: { scheduleName: selectSchedule },
                    success: function (data) {
                        console.log("Test");

                        document.getElementById("selectSchedule").setAttribute("disabled", "disabled");
                        document.getElementById("scheduleName").removeAttribute("disabled");
                        document.getElementById("monday").removeAttribute("disabled");
                        document.getElementById("tuesday").removeAttribute("disabled");
                        document.getElementById("wednesday").removeAttribute("disabled");
                        document.getElementById("thursday").removeAttribute("disabled");
                        document.getElementById("friday").removeAttribute("disabled");
                        document.getElementById("saturday").removeAttribute("disabled");
                        document.getElementById("sunday").removeAttribute("disabled");
                        document.getElementById("save").removeAttribute("disabled");

                        $("#scheduleName").val(data.scheduleName);
                        $("#monday").val(data.scheduleMonTotHours);
                        $("#tuesday").val(data.scheduleTueTotHours);
                        $("#wednesday").val(data.scheduleWedTotHours);
                        $("#thursday").val(data.scheduleThurTotHours);
                        $("#friday").val(data.scheduleFriTotHours);
                        $("#saturday").val(data.scheduleSatTotHours);
                        $("#sunday").val(data.scheduleSunTotHours);
                        $("#totalHours").val(data.scheduleTotalHours);
                    },
                });
            });
        });