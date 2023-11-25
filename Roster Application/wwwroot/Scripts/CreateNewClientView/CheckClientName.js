$(document).ready(function () {
    $("#btn").click(function () { //When the button with id "btn" is clicked, the following with execute.
        var inputValue = $("#newClientName").val();//takes the value of the input field with the id "newClientName and saves it into the variable inputValue"

        $.ajax({
            type: "POST",
            url: "/Client/SCheckClientName", //Schedule is the controller name and CheckScheduleName is the method inside the controller
            data: { inputValue: inputValue },//The data passed to the CheckScheduleName method.
            success: function (response) {
                if (response.isValid) //checks if the Json returned value from the method is true or false.
                {
                    //if response is true execute the following.
                    alert("Client Name Successfull");

                    $("#btn").hide();
                    document.getElementById("newClientName").setAttribute("disabled", "disabled");//disable the input field
                    document.getElementById("btn").setAttribute("disabled", "disabled"); //disable the create button
                    document.getElementById("Address").removeAttribute("disabled");
                    document.getElementById("Contact").removeAttribute("disabled");
                    document.getElementById("scheduleOptions").removeAttribute("disabled");
                    document.getElementById("categoryOptions").removeAttribute("disabled");
                    document.getElementById("Save").removeAttribute("disabled");

                    $.ajax({
                        type: "GET",
                        url: "/Client/SGetAllSchedules",
                        data: {},
                        success: function (data) {
                            $.each(data, function (index, item) {
                                var optionElement = $('<option>');
                                optionElement.text(item);
                                $("#scheduleOptions").append(optionElement);
                            });
                        }
                    });
                    $.ajax({
                        type: "GET",
                        url: "/Client/SGetAllCategories",
                        data: {},
                        success: function (data) {
                            $.each(data, function (index, item) {
                                var optionElement = $('<option>');
                                optionElement.text(item);
                                $("#categoryOptions").append(optionElement);
                            });
                        }
                    });
                }
                else {
                    //if response is false execute the following.
                    alert("Client Name \"" + inputValue + "\" is not valid due to one of the following:\n\n1.) Name already exists in the database.\n2.) " +
                        "The name contains whitespaces.\n3.) The name field is blank.\n\nPlease type the name correctly without the above errors.");
                }
            }
        });
    });

});