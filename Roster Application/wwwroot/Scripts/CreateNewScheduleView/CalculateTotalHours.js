$(document).ready(function () {
    var totalMonHours = 0;
    var totalTueHours = 0;
    var totalWedHours = 0;
    var totalThurHours = 0;
    var totalFriHours = 0;
    var totalSatHours = 0;
    var totalSunHours = 0;

    $("#Mon").on("change", function () {
        if ($("#Mon").val() < 0) {
            $("#Mon").val(0);
        }
        else {
            totalMonHours = parseInt($("#Mon").val());
            var totalHours = totalMonHours + totalTueHours + totalWedHours + totalThurHours + totalFriHours + totalSatHours + totalSunHours;
            $("#Total").val(totalHours);
            $("#copyTotal").val(totalHours);
        }
    });
    $("#Tue").on("change", function () {
        if ($("#Tue").val() < 0) { $("#Tue").val(0); }
        else {
            totalTueHours = parseInt($("#Tue").val());
            var totalHours = totalMonHours + totalTueHours + totalWedHours + totalThurHours + totalFriHours + totalSatHours + totalSunHours;
            $("#Total").val(totalHours);
            $("#copyTotal").val(totalHours);
        }
    });
    $("#Wed").on("change", function () {
        if ($("#Wed").val() < 0) { $("#Wed").val(0); }
        else {
            totalWedHours = parseInt($("#Wed").val());
            var totalHours = totalMonHours + totalTueHours + totalWedHours + totalThurHours + totalFriHours + totalSatHours + totalSunHours;
            $("#Total").val(totalHours);
            $("#copyTotal").val(totalHours);
        }
    });
    $("#Thur").on("change", function () {
        if ($("#Thur").val() < 0) { $("#Thur").val(0); }
        else {
            totalThurHours = parseInt($("#Thur").val());
            var totalHours = totalMonHours + totalTueHours + totalWedHours + totalThurHours + totalFriHours + totalSatHours + totalSunHours;
            $("#Total").val(totalHours);
            $("#copyTotal").val(totalHours);
        }
    });
    $("#Fri").on("change", function () {
        if ($("#Fri").val() < 0) { $("#Fri").val(0); }
        else {
            totalFriHours = parseInt($("#Fri").val());
            var totalHours = totalMonHours + totalTueHours + totalWedHours + totalThurHours + totalFriHours + totalSatHours + totalSunHours;
            $("#Total").val(totalHours);
            $("#copyTotal").val(totalHours);
        }
    });
    $("#Sat").on("change", function () {
        if ($("#Sat").val() < 0) { $("#Sat").val(0); }
        else {
            totalSatHours = parseInt($("#Sat").val());
            var totalHours = totalMonHours + totalTueHours + totalWedHours + totalThurHours + totalFriHours + totalSatHours + totalSunHours;
            $("#Total").val(totalHours);
            $("#copyTotal").val(totalHours);
        }
    });
    $("#Sun").on("change", function () {
        if ($("#Sun").val() < 0) { $("#Sun").val(0); }
        else {
            totalSunHours = parseInt($("#Sun").val());
            var totalHours = totalMonHours + totalTueHours + totalWedHours + totalThurHours + totalFriHours + totalSatHours + totalSunHours;
            $("#Total").val(totalHours);
            $("#copyTotal").val(totalHours);
        }
    });
});