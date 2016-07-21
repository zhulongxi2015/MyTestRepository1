(function () {
    var urls = {
        login:"/main/account/login"
    }
    function FormValidate() {
        $("#login_form").validate({
            rules: {
                user_name: {
                    required: true,
                    minlength: 2
                },
                password: {
                    required: true
                }
            },
            messages: {
                user_name: {
                    required: "User name can't be empty!",
                    minlength: "User name can't less than two characters!"
                },
                password: {
                    required: "Password can't be empty!"
                }
            }
            //errorPlacement: function (error, element) {
            //   // error.appendTo(element.next("span"));
            //}
        })
    }

    $(function () {
        FormValidate();
    });
})();