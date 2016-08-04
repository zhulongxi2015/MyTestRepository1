(function () {
    var urls = {
        login:"/main/Account/Login"
    }
    var returnUrl = "";

    $(function () {
        FormValidate();
        var $hfReturnUrl = $("#hfReturnUrl");
        if ($hfReturnUrl.length > 0) {
            returnUrl = $hfReturnUrl.val();
        }

        $("#btn_login").click(function () {
            if ($(this).hasClass("disabled")) {
                return;
            }
            login();
        });
        ArchitectureFrame.utils.onEnterKeydown($("#chk_remember"), function () {
            if ($("#btn_login").hasClass("disabled")) {
                return;
            }
            login();
        })
    });
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

    function login() {
        var $form = $("#login_form");
        if (!$form.valid()) {
            return;
        }
        var $btn_login = $("#btn_login");       
        $btn_login.cssDisable().html("Login...");
        ArchitectureFrame.ajax.post(urls.login, $form.serialize(), function (result) {
            if (result.Success) {
                $btn_login.html("Login succeeded...");
                window.location = returnUrl === "" ? "/" : returnUrl;
            } else {
                ArchitectureFrame.notification.promptError(result.Message);
                $btn_login.cssEnable().html("Sign in");
            }
        });
    }
})();