$(document).ready(function () {
    $('#username').blur(function () {
        $.ajax({
            type: "POST",
            url: "/ACCOUNT/CheckUsernameExists",
            data: {
                values: [document.querySelector('#form #username').value]
            },
            dataType: "json",
            contentType: 'application/x-www-form-urlencoded',
            success: function (data) {
                if (data) {
                    $('#username').parent().addClass('invalid');
                    $('#username').parent().find('span').append("Username already exists");
                }

                $('#username').focus(function () {
                    $('#username').parent().removeClass('invalid');
                    $('#username').parent().find('span').html(" ");
                })
            },
            error: function () {
                alert("Error occured!!")
            }
        });
    });

    $('#email').blur(function () {
        $.ajax({
            type: "POST",
            url: "/ACCOUNT/CheckGmailExists",
            data: {
                values: [document.querySelector('#form #email').value]
            },
            dataType: "json",
            contentType: 'application/x-www-form-urlencoded',
            success: function (data) {
                if (data) {
                    $('#email').parent().addClass('invalid');
                    $('#email').parent().find('span').append("Email already exists");
                }

                $('#email').focus(function () {
                    $('#email').parent().removeClass('invalid');
                    $('#email').parent().find('span').html(" ");
                })
            },
            error: function () {
                alert("Error occured!!")
            }
        });
    });
})