$(document).ready(function () {
    var $sourceInput = $("#newScheduleName");
    var $copyNewScheduleName = $("#copyNewScheduleName");

    $sourceInput.on("input", function () {
        $copyNewScheduleName.val($sourceInput.val());
    })
})