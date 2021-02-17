$(document).ready(function () {
    var defaultDate = $('input[name=WrittenDate]').val();
    $('#addB').click(function () {
        $('#ok').html("");
        $('#error').html("");
        var bookName = $('input[name=BookName]').val().trim();
        var writtenDate = $('input[name=WrittenDate]').val();
        if (bookName == "" || defaultDate == writtenDate) {
            $('#error').html("Please Fill All Fields!");
        } else {
            $.ajax({
                url: "/Home/Index",
                method: "post",
                data: {
                    "BookName": bookName, "WrittenDate": writtenDate
                },
                success: function (response) {
                    if (response == "True") {
                        $('#ok').html("Successfully Added!");
                        $('[name=BookName]').val("");
                        $('input[name=WrittenDate]').val("");
                    }
                    else if (response == "Arsebobs") {
                        $('#error').html("Already Exists This Book!");
                    } else {
                        $('#error').html("Your DateTime is Incorrect");
                    }

                },
                error: function () {
                    alert("Contact Your System Administrator!");
                }

            });
        }
        var input = this;
        input.disabled = true;
        setTimeout(function () {
            input.disabled = false;
        }, 3000);
        
    });

});