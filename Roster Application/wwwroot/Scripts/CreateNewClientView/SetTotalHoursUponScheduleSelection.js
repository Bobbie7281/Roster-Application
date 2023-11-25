$(document).ready(function () {
    $("#scheduleOptions").on("change", function () {
        var selectSchedule = $(this).find("option:selected").text();

        $.ajax({
            url: "/Client/SGetTotalHours",
            type: "POST",
            data: { scheduleName: selectSchedule },
            success: function (data) {
                $("#TotalHours").val(data);
                $("#copyTotalHours").val(data);
            }
        });
    });
});