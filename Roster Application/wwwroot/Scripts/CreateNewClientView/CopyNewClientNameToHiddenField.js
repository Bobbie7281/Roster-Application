$(document).ready(function () {
    var $sourceInput = $("#newClientName");
    var $destinationInput = $("#copyNewClientName");

    $sourceInput.on("input", function () {
        $destinationInput.val($sourceInput.val());
    })
})