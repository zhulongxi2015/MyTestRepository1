var ArchitectureFrame = {
    ajax: {

    },
    notification: {

    },
    shell: {

    },
    documentReady: {

    },
    utils: {

    },
    pages: {

    },
    ckey: null
};

//busy plugin
(function ($) {
    $.fn.busy = function (userOptions) {
        var timer = null;
        var defaultOptions = function (isbusy) {
            this.isBusy = isbusy;
            this.busyContent = "Loading......";
            this.request = null;
            this.showCancel = true;
            this.modal = true;
            this.delay = 0;
            this.css = "";
            this.hide = null
        };

        //var options = null;
        //if (userOptions.constructor == Boolean) {
        //    options = new defaultOptions(userOptions);
        //}
        //else {
        //    options = $.extend({}, $.fn.busy.defaultOptions, userOptions);
        //}

        defaultOptions.Fix = function (obj) {
            if (obj.constructor == Boolean) {
                return new defaultOptions(obj);
            }
            var result = new defaultOptions(true);
            for (property in obj) {
                result[property] = obj[property];
            }
            return result;
        };

        function createIndicator(opts) {
            var $container = $("<div class='busy-indicator'></div>");
            if (opts.css != null && opts.css != "") {
                $container.addClass(opts.css);
            }
            var $contentWrapper = $("<div class='busy-content'></div>")
            $contentWrapper.appendTo($container);
            if (opts.showCancel) {
                var $cancelLink = $("<a href='javascript:void(0)' title='cancel' class='busy-cancel'></a>");
                $cancelLink.appendTo($contentWrapper);
                $cancelLink.click(function () {
                    if (opts.request != undefined && opts.request != "") {
                        opts.request.abort();
                    }
                    $container.remove();
                });
            }
            $("<div class='busy-text'></div>").appendTo($contentWrapper);
            return $container;
        }
        return $(this).each(function (i, elem) {
            var $item = $(elem);
            var options = defaultOptions.Fix(userOptions);
            if (options.isBusy) {
                var $indicator = $item.find(".busy-indicator");
                if ($indicator.length == 0) {
                    $indicator = new createIndicator(options);
                    $item.prepend($indicator);
                    var $content = $item.find(".busy-content");
                    var contentHeight = $content.height();
                    var contentWidth = $content.width();
                    var windowHeight = $(window).height();
                    var windowWidth = $(window).width();
                    if (options.modal) {
                        $indicator.addClass("busy-modal");
                        var itemHeight = $item.height();
                        var itemWidth = $item.width();
                        if ($item.is("body")) {
                            $indicator.css("position", "absolute");
                            var itemContentsHeight = 0;
                            var itemContentsWidth = 0;
                            if ($item.find("#wrapper").length > 0) {
                                itemContentsHeight = $item.find("#wrapper").height();
                                itemContentsWidth = $item.find("#wrapper").width();
                            }
                            $indicator.height(Math.max(itemHeight, windowHeight, itemContentsHeight) + "px");
                            $indicator.width(Math.max(itemWidth, windowWidth, itemContentsWidth) + "px");
                            $content.css("position", "fixed");
                            contentWidth = $content.width();
                            $content.css("top", (windowHeight - contentHeight) / 2 + "px");
                            $content.css("left", (windowWidth - contentWidth) / 2 + "px");
                        }
                        else {
                            $indicator.height(itemHeight + "px");
                            $indicator.width(itemWidth + "px");
                            $content.css("top", ($indicator.height() - contentHeight) / 2 + "px");
                        }
                    }
                    else {
                        var wrapperHeight = 0;
                        var wrapperWidth = 0;
                        if ($item.is("body")) {
                            $indicator.css("position", "fixed");
                            wrapperHeight = windowHeight;
                            wrapperWidth = windowWidth;
                        } else {
                            wrapperHeight = $item.height();
                            wrapperWidth = $item.width();
                        }

                        var top = (wrapperHeight - contentHeight) / 2;
                        var left = (wrapperWidth - contentWidth) / 2;
                        $indicator.css("left", left + "px");
                        $indicator.css("top", top + "px");
                    }
                }
                $indicator.find(".busy-text").html(options.busyContent);
                $indicator.hide();

                timer = setTimeout(function () {
                    if (options.modal == false) {
                        $indicator.css("display", "table");
                    }
                    else {
                        $indicator.show();
                    }
                }, options.delay);
            }
            else {
                $item.find(".busy-indicator").remove();
                clearTimeout(timer);
            }
        });
    }
})(jQuery);
$.busy = function (options) {
    $("body").busy(options);
}
//~~busy plugin

//alert plugin
$.prompt = function (options) {
    var defaultOptions = function (message) {
        this.message = message;
        this.showDuration = 1000;
        this.displayDuration = 3000;
        this.hideDuration = 1000;
        this.css = "alert-success";
        this.showClose = true;
    };

    defaultOptions.Fix = function (obj) {
        if (obj.constructor == String) {
            return new defaultOptions(obj);
        }
        var result = new defaultOptions("");
        for (property in obj) {
            result[property] = obj[property];
        }
        return result;
    }

    options = defaultOptions.Fix(options);
    var $prompt = $("<div class='alert prompt' role='alert' style='position:fixed;min-width:200px;min-height:60px;'>" + options.message + "</div>");
    $prompt.addClass(options.css);
    if (options.showClose) {
        $prompt.addClass("alert-dismissible");
        var $close = $('<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>');
        $prompt.prepend($close);
    }
    $prompt.appendTo("body");

    var centerX = $(window).width() / 2;
    var centerY = $(window).height() / 2;
    var left = centerX - $prompt.width() / 2;
    var top = centerY - $prompt.height() / 2 + 50;
    $prompt.css("left", left + "px");
    $prompt.css("top", top + "px");
    $prompt.animate({
        top: "-=50",
        opacity: 1
    }, {
        duration: options.showDuration,
        complete: function () {
            setTimeout(function () {
                $prompt.animate({
                    top: "-=35",
                    opacity: 0
                }, {
                    duration: options.hideDuration,
                    complete: function () {
                        $prompt.remove();
                    }
                });
            }, options.displayDuration);
        }
    });

};

ArchitectureFrame.notification.promptSuccess = function (message) {
    $.prompt({
        message: message,
        css: "alert-success"
    });
}
ArchitectureFrame.notification.promptError = function (message) {
    if (message == undefined || message == '') {
        message = "Error";
    }
    $.prompt({
        message: message,
        css: "alert-danger",
        displayDuration: 3000
    });
}
ArchitectureFrame.notification.promptInfo = function (message) {
    $.prompt({
        message: message,
        css: "alert-info"
    });
}
ArchitectureFrame.notification.promptWarning = function (message) {
    $.prompt({
        message: message,
        css: "alert-warning"
    });
}
//~~alert plugin

//modalDialog plugin
$.modalDialog = function (options) {
    var defaultOptions = function (content) {
        this.id = "",
        this.content = "",
        this.title = "",
        this.isLargeModal = false,
        this.isSmallModal = false,
        this.css = "",
        this.backdrop = false,
        this.buttons = [],
        this.show = null,//show 方法调用之后立即触发该事件。如果是通过点击某个作为触发器的元素，则此元素可以通过事件的 relatedTarget 属性进行访问。
        this.shown = null,//此事件在模态框已经显示出来（并且同时在 CSS 过渡效果完成）之后被触发。如果是通过点击某个作为触发器的元素，则此元素可以通过事件的 relatedTarget 属性进行访问
        this.loaded = null,//从远端的数据源加载完数据之后触发该事件。
        this.hide = null,//hide 方法调用之后立即触发该事件。
        this.hidden = null//此事件在模态框被隐藏（并且同时在 CSS 过渡效果完成）之后被触发。
    };
    defaultOptions.Fix = function (obj) {
        if (obj.constructor == String) {
            return new defaultOptions(obj);
        }
        var result = new defaultOptions("");
        for (property in obj) {
            result[property] = obj[property];
        }
        return result;
    };

    options = defaultOptions.Fix(options);
    var id = options.id
    $dialog = $('<div class="modal fade" id="' + id + '" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">' +
        '<div class="modal-dialog" role="document">' +
            '<div class="modal-content">' +
                '<div class="modal-header">' +
                    '<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>' +
                    '<h4 class="modal-title" id="myModalLabel">' +
                    options.title
                    + '</h4>' +
               ' </div>' +
                '<div class="modal-body">' +
                   options.content
                + '</div>' +
                '<div class="modal-footer">' +
                     
                    //'<button type="button" class="btn btn-primary">Save changes</button>' +
                '</div>' +
            '</div>' +
        '</div>' +
    '</div>');
    if (options.css != '') {
        $dialog.addClass(options.css);
    }
    if (options.isLargeModal) {
        if ($dialog.hasClass("bs-example-modal-sm")) {
            $dialog.removeClass("bs-example-modal-sm");
        }
        if ($dialog.children(".modal-dialog").hasClass("modal-sm")) {
            $dialog.children(".modal-dialog").removeClass("modal-sm");
        }
        $dialog.addClass("bs-example-modal-lg");
        $dialog.children(".modal-dialog").addClass("modal-lg");
    }
    else if (options.isSmallModal) {
        if ($dialog.hasClass("bs-example-modal-lg")) {
            $dialog.removeClass("bs-example-modal-lg");
        }
        if ($dialog.children(".modal-dialog").hasClass("modal-lg")) {
            $dialog.children(".modal-dialog").removeClass("modal-lg");
        }
        $dialog.addClass("bs-example-modal-sm");
        $dialog.children(".modal-dialog").addClass("modal-sm");
    }
    if (options.buttons != null && options.buttons.length>0) {
        //buttons: [
        //    {
        //        id:"btn-save",
        //        type:"button",
        //        text: "Save",
        //        css: "btn-btn-info",
        //        clickFunc: function (obj) {

        //        }
        //    },
        //{
        //    id:"btn-save",
        //    type:"button",
        //    text: "Save",
        //    css: "btn-info",
        //    clickFunc: function (obj) {
        //}
        //]
        for (var i = 0; i < options.buttons.length; i++) {
            var curObj = options.buttons[i];
            var $button = $('<button id="' + curObj.id + '" type="'+curObj.type+'" class="btn">' + curObj.text + '</button>');
            $button.addClass(curObj.css);
            if (curObj.clickFunc != undefined && curObj.clickFunc != null) {
                $button.on("click",function(){
                    curObj.clickFunc(this);
                });
            }
            $dialog.find(".modal-dialog .modal-content .modal-footer").append($button);
        }
    }

    $dialog.appendTo("body");
    $("#" + id).modal({
        backdrop:options.backdrop
    });

    $("#" + id).on('loaded.bs.modal', function () {
        if (options.loaded != null && options.loaded != undefined) {
            options.loaded();
        }

    });
    $("#" + id).on('show.bs.modal', function () {
        if (options.show != null && options.show != undefined) {
            options.show();
        }
    });
    $("#" + id).on('shown.bs.modal', function () {
        if (options.shown != null && options.shown != undefined) {
            options.shown();
        }
    });
    $("#" + id).on('hide.bs.modal', function (e) {
        if (options.hide != null && options.hide != undefined) {
            options.hide(e);
        }
    });
    $("#" + id).on('hidden.bs.modal', function (e) {
        if (options.hidden != null && options.hidden != undefined) {
            options.hidden(e);
        }
    });
}

ArchitectureFrame.notification.dialog = function (options) {
    $.modalDialog(options);
}
ArchitectureFrame.notification.alertInfo = function (id,title, content, css,onClose) {
    $.modalDialog({
        id: id,
        title: title,
        content: content,
        hidden: onClose,
        buttons: [{
            text: "OK",
            type: "button",
            css: "btn-primary",
            clickFunc: function (obj) {
                $("#" + id).modal('hide');
            }
        }]
    });
};

ArchitectureFrame.notification.alertError = function (id, title, content) {
    if (title == undefined) {
        title = "Error";
    }
    if (content == undefined || content == "") {
        content = "The server returned an unknown error!";
    }
    //content = "<p class='error'>" + content + "</p>";
    ArchitectureFrame.notification.alertInfo(id,title,content)
};
//~~modalDialog plugin

//html display: disable or enable
(function ($) {
    $.prototype.cssDisable = function () {
        return this.each(function () {
            $(this).addClass("disabled");
        });
    }
    $.prototype.cssEnable = function () {
        return this.each(function () {
            $(this).removeClass("disabled");
        });
    };
})(jQuery);
//~~html display: disable or enable