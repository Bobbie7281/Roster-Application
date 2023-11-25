$(document).ready(function(){

            $("#selectSchedule").on("change", function () {
                var selectSchedule = $(this).find("option:selected").text();
                $.ajax({
                    url: "/Schedule/SGetData",
                    type: "POST",
                    data: { scheduleName: selectSchedule },
                    success: function (data) {
                        var totalMonHours = data.scheduleMonTotHours;
                        var totalTueHours = data.scheduleTueTotHours;
                        var totalWedHours = data.scheduleWedTotHours;
                        var totalThurHours = data.scheduleThurTotHours;
                        var totalFriHours = data.scheduleFriTotHours;
                        var totalSatHours = data.scheduleSatTotHours;
                        var totalSunHours = data.scheduleSunTotHours;

                        $("#monday").on("change", function () {
                            if ($("#monday").val() < 0) { $("#monday").val(0); }
                            else {
                                totalMonHours = parseInt($("#monday").val());
                                var totalHrs = totalMonHours + totalTueHours + totalWedHours + totalThurHours + totalFriHours + totalSatHours + totalSunHours;
                                $("#totalHours").val(totalHrs);
                                $("#copyTotal").val(totalHrs);
                            }
                        });
                        $("#tuesday").on("change", function () {
                            if ($("#tuesday").val() < 0) { $("#tuesday").val(0); }
                            else {
                                totalTueHours = parseInt($("#tuesday").val());
                                var totalHrs = totalMonHours + totalTueHours + totalWedHours + totalThurHours + totalFriHours + totalSatHours + totalSunHours;
                                $("#totalHours").val(totalHrs);
                                $("#copyTotal").val(totalHrs);
                            }
                        });
                        $("#wednesday").on("change", function () {
                            if ($("#wednesday").val() < 0) { $("#wednesday").val(0); }
                            else {
                                totalWedHours = parseInt($("#wednesday").val());
                                var totalHrs = totalMonHours + totalTueHours + totalWedHours + totalThurHours + totalFriHours + totalSatHours + totalSunHours;
                                $("#totalHours").val(totalHrs);
                                $("#copyTotal").val(totalHrs);
                            }
                        });
                        $("#thursday").on("change", function () {
                            if ($("#thursday").val() < 0) { $("#thursday").val(0); }
                            else {
                                totalThurHours = parseInt($("#thursday").val());
                                var totalHrs = totalMonHours + totalTueHours + totalWedHours + totalThurHours + totalFriHours + totalSatHours + totalSunHours;
                                $("#totalHours").val(totalHrs);
                                $("#copyTotal").val(totalHrs);
                            }
                        });
                        $("#friday").on("change", function () {
                            if ($("#friday").val() < 0) { $("#friday").val(0); }
                            else {
                                totalFriHours = parseInt($("#friday").val());
                                var totalHrs = totalMonHours + totalTueHours + totalWedHours + totalThurHours + totalFriHours + totalSatHours + totalSunHours;
                                $("#totalHours").val(totalHrs);
                                $("#copyTotal").val(totalHrs);
                            }
                        });
                        $("#saturday").on("change", function () {
                            if ($("#saturday").val() < 0) { $("#saturday").val(0); }
                            else {
                                totalSatHours = parseInt($("#saturday").val());
                                var totalHrs = totalMonHours + totalTueHours + totalWedHours + totalThurHours + totalFriHours + totalSatHours + totalSunHours;
                                $("#totalHours").val(totalHrs);
                                $("#copyTotal").val(totalHrs);
                            }
                        });
                        $("#sunday").on("change", function () {
                            if ($("#sunday").val() < 0) { $("#sunday").val(0); }
                            else {
                                totalSunHours = parseInt($("#sunday").val());
                                var totalHrs = totalMonHours + totalTueHours + totalWedHours + totalThurHours + totalFriHours + totalSatHours + totalSunHours;
                                $("#totalHours").val(totalHrs);
                                $("#copyTotal").val(totalHrs);
                            }
                        });
                    }
                });
            });
        });