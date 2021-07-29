$(document).ready(function () {

    var nameRegex = new RegExp("^[a-zA-ZÀÁÂÃÈÉÊÌÍÒÓÔÕÙÚĂĐĨŨƠàáâãèéêìíòóôõùúăđĩũơƯĂẠẢẤẦẨẪẬẮẰẲẴẶẸẺẼỀỀỂẾưăạảấầẩẫậắằẳẵặẹẻẽềềểếỄỆỈỊỌỎỐỒỔỖỘỚỜỞỠỢỤỦỨỪễệỉịọỏốồổỗộớờởỡợụủứừỬỮỰỲỴÝỶỸửữựỳỵỷỹ\\s]+$");//special char
    var emailRegex = new RegExp("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$");
    var phoneRegex = new RegExp("^[0-9]+$");
    var phoneMinMax = new RegExp("^[0-9]{10,20}$");
    var formContact = $('.form-contact form');
    var fullName = $('form input[name="fullName"]');
    var email = $('form input[name="email"]');
    var phone = $('form input[name="phone"]');
    var message = $('form textarea[name="message"]');

    fullName.change(function () {
        checkInputName()
    })

    email.change(function () {
        checkInputEmail()
    })

    phone.change(function () {
        checkInputPhone()
    })

    message.change(function () {
        checkInputMessage()
    })


    function checkInputName() {
        var name = formContact.find('input[name="fullName"]');
        var mess;
        var isValid = true;
        if (!nameRegex.test(name.val()) || name.val().length === 0 || name.val().length > 100) {
            mess = name.val().length === 0 ? name.data('form-missing') : name.val().length > 100 ? name.data('form-max') : name.data('form-error');
            isValid = false
        } else {
            isValid = true;
            mess = ''
        }
        $('p[data-error-for="fullName"]').html(mess);
        return isValid
    }

    function checkInputEmail() {
        var email = formContact.find('input[name="email"]');
        var mess;
        var isValid = true;
        if (!emailRegex.test(email.val()) || email.val().length === 0 || email.val().length > 100) {
            mess = email.val().length === 0 ? email.data('form-missing') : email.val().length > 100 ? email.data('form-max') : email.data('form-error');
            isValid = false
        } else {
            isValid = true;
            mess = ''
        }
        $('p[data-error-for="email"]').html(mess);
        return isValid
    }

    function checkInputPhone() {
        var phone = formContact.find('input[name="phone"]');
        var mess;
        var isValid = true
        if (!phoneRegex.test(phone.val()) || phone.val().length === 0 || !phoneMinMax.test(phone.val())) {
            mess = phone.val().length === 0 ? phone.data('form-missing') : !$.isNumeric(phone.val()) ? phone.data('form-error') : phone.data('form-min-max');
            isValid = false
        } else {
            isValid = true;
            mess = '';
        }
        $('p.error-msg[data-error-for="phone"]').html(mess);
        return isValid
    }

    function checkInputMessage() {
        var message = formContact.find('textarea[name="message"]');
        var mess;
        var isValid = true;
        if (message.val().length === 0 || message.val().length > 1000) {
            mess = message.val().length === 0 ? message.data('form-missing') : message.data('form-max');
            isValid = false
        } else {
            isValid = true;
            mess = ''
        }
        $('p[data-error-for="message"]').html(mess);
        return isValid
    }

    formContact.on('submit', function (e) {
        e.preventDefault()
    })

    $('form .input').keyup(function () {
        if (fullName.val() !== '' && nameRegex.test(fullName.val()) && fullName.val().length < 100 &&
            emailRegex.test(email.val()) && email.val() !== '' && email.val().length < 100 &&
            phoneRegex.test(phone.val()) && phone.val() !== '' && phoneMinMax.test(phone.val()) &&
            message.val() !== '' && message.val().length < 1000) {
            formContact.find('.animated').prop('disabled', false);
        } else {
            formContact.find('.animated').prop('disabled', true);
        }
    });

    formContact.find('.submit-button button').on('click', function (e) {
        e.preventDefault();
        var button = formContact.find('.animated');
        var url = formContact.attr('action');

        $('.cssload-container').show();
        $.ajax({
            url: url,
            type: 'post',
            dataType: 'jsonp',
            data: formContact.serialize(),
            complete: function (data) {
                formContact.trigger('reset').find('input').trigger('input');
                $('.cssload-container').hide();
                button.attr('disabled', true);
                $('.send-message-success').show();
                setTimeout(function () {
                    $('.send-message-success').fadeOut();
                }, 5000)
            },
            error: function (err) {
                button.removeAttr('disabled');
            }
        })

    })
});