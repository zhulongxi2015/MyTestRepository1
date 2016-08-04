(function () {
    var urls = {
        register: "/main/Account/Register",
        CheckName: "/main/Account/CheckUserName",
        registerCompleted:"/"
    }
    $(function () {
        //$.ajaxSetup({ cache: false });
        FormValidate();
        $("#btn_register").click(function () {
            register();
            return;
        })
    });
    function FormValidate() {
        $("#register_form").validate({
            rules: {
                user_name: {
                    required: true,
                    minlength: 2,
                    CheckSameName: true
                    //remote: {
                    //    url: urls.CheckName,
                    //    type: "GET",
                    //    dataType: "Json",
                    //    data:{
                    //        userName: function () {
                    //            return $("#register_form #user_name").val();
                    //        }
                    //    },
                    //    dataFilter: function (data) {
                    //        //var notice = eval("(" + data + ")");
                    //        //if (notice) {
                    //        //    return false;
                    //        //}
                    //        //else {
                    //        //    return true;
                    //        //}
                    //        if (eval("(" + data + ")").Success) {
                    //            return true;
                    //        }
                    //        else {
                    //            return false;
                    //        }
                    //    }
                    //}
                },
                password:
                    {
                        required: true,
                        IsPassword: true
                    },
                confirm_password: {
                    required: true,
                    IsSameAsPassword: true
                },
                email:
                    {
                        email: true
                    }
                //phone: {
                //    IsPhone:true
                //}
            },
            messages: {
                user_name: {
                    required: "User name can't be empty!",
                    minlength: "User name length can't less than 2!"
                    //remote:"Thre user name already exists!"
                },
                password: {
                    required: "Password can't be empty!",
                },
                confirm_password: {
                    required: "Confirm password can't be empty!"
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

        $.validator.addMethod("IsSameAsPassword", function (value, element) {
            if (value != $("#register_form #password").val()) {
                return false;
            }
            return true;
        }, "The two password must be the same");

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
            var flag = true;
            $.ajax({
                type: "get",
                url: urls.CheckName,
                async: false,
                cache: false,
                data: { username: value },
                //dataType: "html",
                scriptCharset: "UTF-8",
                success: function (result) {
                    if (!result.Success) {
                        flag = false;
                    }
                }
            });
            return flag;
        }, "The user name already exists!");
    }

    function register() {
        var $form = $("#register_form");
        if (!$form.valid()) {
            return;
        }
        var $btn_register = $("#btn_register");
        if (!$("#chk_agree").is(":checked")) {
            ArchitectureFrame.notification.promptWarning("You have to agree to the agreement!");
            return;
        }
        $btn_register.cssDisable().html("Processing...");
        ArchitectureFrame.ajax.post(urls.register, $form.serialize(), function (result) {
            if (result.Success) {
                ArchitectureFrame.notification.promptSuccess("Register successfully!");
                window.location.replace(urls.registerCompleted);
            }
            else {
                ArchitectureFrame.notification.promptError(result.Message);
                $btn_register.cssEnable().html("Register");
            }
        });
    }
})();