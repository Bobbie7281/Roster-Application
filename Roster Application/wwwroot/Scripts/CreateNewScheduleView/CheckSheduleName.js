$(document).ready(function () {
    $("#btn").click(function () { //When the button with id "btn" is clicked, the following with execute.
        var inputValue = $("#newScheduleName").val();//takes the value of the input field with the id "newScheduleName" and saves it into the variable inputValue"

        $.ajax({
            type: "POST",
            url: "/Schedule/SCheckScheduleName", //Schedule is the controller name and CheckScheduleName is the method inside the controller
            data: { inputValue: inputValue },//The data passed to the CheckScheduleName method.
            success: function (response) {
                if (response.isValid) //checks if the Json returned value from the method is true or false.
                {
                    //if response is true execute the following.
                    alert("Category Name Successfull");

                    $("#btn").hide();

                    document.getElementById("newScheduleName").setAttribute("disabled", "disabled");//disable the input field
                    document.getElementById("btn").setAttribute("disabled", "disabled"); //disable the create button
                    document.getElementById("Mon").removeAttribute("disabled"); //Enable all the inputs from Mon - Sun
                    document.getElementById("Tue").removeAttribute("disabled");
                    document.getElementById("Wed").removeAttribute("disabled");
                    document.getElementById("Thur").removeAttribute("disabled");
                    document.getElementById("Fri").removeAttribute("disabled");
                    document.getElementById("Sat").removeAttribute("disabled");
                    document.getElementById("Sun").removeAttribute("disabled");
                    document.getElementById("save").removeAttribute("disabled");
                }
                else {
                    //if response is false execute the following.
                    alert("Schedule Name \"" + inputValue + "\" is not valid due to one of the following:\n\n1.) Name already exists in the database.\n2.) " +
                        "The name contains whitespaces.\n3.) The name field is blank.\n\nPlease type the name correctly without the above errors.");
                }
            }
        });
    });

});