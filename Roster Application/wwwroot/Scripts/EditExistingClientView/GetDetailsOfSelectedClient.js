//The following script will execute upon selecting the client name.
$(document).ready(function () {

    $("#selectClient").on("change", function () { //When a client name is selected 
        var selectClient = $(this).find("option:selected").text(); //The client name will be saved in selectClient

        var idsRemoveDisabledAttr = [$("#NewClientName"), $("#Address"), $("#Contact"), $("#selectSchedule"), $("#selectCatgory"), $("#save")];
        var idsUploadData = [$("#NewClientName"), $("#Address"), $("#Contact"), $("#selectSchedule"), $("#selectCatgory"), $("#TotalHours")];

        $.ajax({
            url: "/Client/SGetData",//SGetData is a method located in the client controller 
            type: "POST",//The method will be of type post ([HttpPost])
            data: { clientName: selectClient },//selectClient variable will be passed to the parameter clientName of the SGetData method
            success: function (data) {//upon return the disabled attribute will be removed for the following elements

                $.each(idsRemoveDisabledAttr, function (index, element) {

                    $(element).removeAttr("disabled");

                });
                $.each(data, function (index, element) {
                    idsUploadData[index].val(data[index]);

                });
            },
            error: function (xhr, status, error) {
                console.log("Ajax Error: " + status + " - " + error);
                console.log(xhr.responseText);
            }
        });
    });
});