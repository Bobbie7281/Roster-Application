$(document).ready(function () {
    $("#selectSchedule").on("change", function () {//When a schedule is selected 
        var selectedschedule = $(this).find("option:selected").text(); //The Schedule name will be saved in the selectedSchedule variable

        $.ajax({
            url: "/Client/SGetTotalHours",//SGetTotalHours is a method located in the client controller.
            type: "POST",//The method will be of type POST ([HttpPost])
            data: { scheduleName: selectedschedule },//selectedSchedule variable will be passed to the parameter scheduleName of the SGetTotalHours method
            success: function (data) {
                $("#TotalHours").val(data);//The returned data will be displayed in the TotalHours element.
            },
        });
    });
});