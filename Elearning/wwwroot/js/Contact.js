$('#send').click(function () {
    $('#send').attr('disabled', true);

    var name = $('#name').val().trim();
    var email = $('#email').val().trim();
    var subject = $('#subject').val().trim();
    var message = $('#message').val().trim();
    if (name && email && subject && message) {
        $('#send-contact-form').hide();
        var model = {
            name: name,
            email: email,
            subject: subject,
            message: message
        };

        $.ajax({
            url: '/Home/SendMail',
            type: 'POST',
            dataType: 'json',
            data: model,
            success: function (response) {
                $('#success').show();
            },
            error: function () {
                $('#send-contact-form').hide();
            }
        });
    } else {
        $('#send').attr('disabled', false);
    };

});