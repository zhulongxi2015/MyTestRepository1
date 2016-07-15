(function () {
    $(function () {
        //$("span.menu").click(function () {
        //    $("ul.nav1").slideToggle(300, function () {
        //        // Animation complete.
        //    });
        //});
        // script-for sticky-nav
        var navoffeset = $(".banner-bottom").offset().top;
        $(window).scroll(function () {
            var scrollpos = $(window).scrollTop();
            if (scrollpos >= navoffeset) {
                $(".banner-bottom").addClass("fixed");
            } else {
                $(".banner-bottom").removeClass("fixed");
            }
        });
        var $navlis = $(".navbar-default .navbar-nav>li");
        $navlis.click(function () {
            $.each($navlis, function (i, e) {
                $(e).removeClass("active")
            })
            $(this).addClass("active");
        });
    });
})()