$(document).ready(function () {

    $("#selectCategory").on("change", function () {
        var selectOptionText = $(this).find("option:selected").text();
        $("#input").val(selectOptionText);

        //Once the category name is choosen for editing, the disabled attribute will change to enable.
        document.getElementById("input").removeAttribute("disabled");

    });
});