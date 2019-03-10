function updatePerson() {
    var personId = $("#personId").val();
    var firstName = $("#firstName").val();
    var lastName = $("#lastName").val();
    var gender = $("#gender").val();
    var email = $("#email").val();
    var phoneNumber = $("#phoneNumber").val();

    $.ajax({
        url: "UpdatePerson",
        dataType: "json",
        data: {
            PersonId: personId,
            FirstName: firstName,
            LastName: lastName,
            Gender: gender,
            Email: email,
            PhoneNumber: phoneNumber
        }
    }).done(function (data) {
        if (data) {
            //$("#errorMessage").removeClass("visible")
            //    .addClass("hidden");
            $("#successMessage").removeClass("hidden")
                .addClass("visible");
        } else {
            //$("#successMessage").removeClass("visible")
            //    .addClass("hidden");
            $("#errorMessage").removeClass("hidden")
                .addClass("visible");
        }
    });
}