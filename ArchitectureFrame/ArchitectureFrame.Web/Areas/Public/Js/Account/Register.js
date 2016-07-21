(function () {
    var urls = {
        register: "/main/account/register",
        CheckName:"/main/account/test"
    }
    $(function () {
        //FormValidate();
        $("#register_form #user_name").blur(function () {
            alert("tt")
            $.ajax({
                type: "post",
                url: "/main/category/test",
                data: { username: "eee" },
                success: function (result) {
                    if (!result.Success) {
                        result = false;
                    }
                }
            })
        })
    });
    function FormValidate() {
        $("#register_form").validate({
            rules:{
                user_name: {
                    required: true,
                    minlength: 2
                    //CheckSameName:true
                },
                password:
                    {
                        required: true,
                        IsPassword:true
                    }
            },
            messages: {
                user_name: {
                    required: "User name can't be empty!",
                    minlength: "User name length can't less than 2!",
                    date:"date"
                },
                password: {
                    required: "Password can't be empty!",
                }
            }
            
        });
        $.validator.addMethod("IsPassword", function (value, element) {
            var passwordPattern = /^[^\s]{6,18}$/
            if (value != '') {
                if (!passwordPattern.test(value)) {
                    return false;
                }
                return true;
            }
        }, "Password must contain characters and numbers and length must between 6 and 18!");

        $.validator.addMethod("IsPhone", function (value, element) {
            var pattern = /^(([0\+]\d{2,3}-)?(0\d{2,3})-)(\d{7,8})(-(\d{3,}))?$/;
            if (value != '') {
                if (!pattern.test(value)) {
                    return false;
                }
                return true;
            }
        }, "Please enter correct phone!");

        $.validator.addMethod("CheckSameName", function (value, element) {
            var result = true;
            $.ajax({
                type: "post",
                url: urls.CheckName,
                //async: false,
                //cache: false,
                data: { username: value },
                dataType: "html",
                scriptCharset: "Utf-8",
                success: function (result)
                {
                    if (!result.Success)
                    {
                        result = false;
                    }
                }
            })
            return result;
        }, "The user name already exists!");
    }

})();