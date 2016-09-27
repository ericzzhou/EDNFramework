$(function () {

    //$("body").ajaxError(function (event, request, settings) {
    //    alert("error 了");
    //    //$(this).append("<li>出错页面:" + settings.url + "</li>");
    //    //if (request.responseText != "" && request.status != 200) {
    //    //    var data = eval('(' + request.responseText + ')')
    //    //    //$.jBox.tip(data.error.message, 'error');
    //    //    //$.jBox.tip(data.message, 'error');
    //    //    alert(data.error.Message);
    //    //}
    //});

    //// ajax 发生错误，就会执行
    //$('body').ajaxError(function (e, xhr, setting, text) {
    //    // e - event 事件
    //    // xhr - XMLHttpRequest 对象
    //    // setting - ajax 设置
    //    // text - 错误信息
    //    alert(text);
    //});

    //// ajax 完成后，就会执行
    //$('body').ajaxComplete(function () {
    //    alert('complete'); // ajax 请求完成就会执行
    //});
});


// ajax 发生错误，就会执行
$(document).ajaxError(function (event, request, settings, text) {
    // e - event 事件
    // xhr - XMLHttpRequest 对象
    // setting - ajax 设置
    // text - 错误信息

    //$(this).append("<li>出错页面:" + settings.url + "</li>");
    alert("error 了");
    //alert(request.error.Message);


});

// ajax 完成后，就会执行
$(document).ajaxComplete(function () {
    //alert('complete'); // ajax 请求完成就会执行
});

function alert(message) {
    bootbox.dialog({
        message: message, buttons:
        {
            "button":
            {
                "label": "确定",
                "className": "btn-sm btn-primary"
            }
        }
    });
}


function confirm(message, successful, unsuccessful) {
    bootbox.dialog({
        message: message,
        buttons:
               {
                   "click":
                   {
                       "label": "确定",
                       "className": "btn-sm btn-primary",
                       "callback": function () {
                           if (successful && successful != undefined) {
                               successful();
                           }
                       }
                   },
                   "button":
                   {
                       "label": "取消",
                       "className": "btn-sm"
                   }
               }
    });

    //bootbox.confirm(message, function (result) {
    //    if (result) {
    //        if (!successful && typeof successful == "function") {
    //            successful();
    //        }
    //        else {
    //            if (!unsuccessful && typeof unsuccessful == "function") {
    //                unsuccessful();
    //            }
    //        }
    //    }
    //});
}


function dialog(options, successCallback) {
    if (!options.width || options.width == undefined) {
        options.width = "100%";
    }
    if (!options.height || options.height == undefined) {
        options.height = "100%";
    }
    bootbox.dialog({
        message: '<iframe id="myfream" src="' + options.url + '" frameBorder="0" style="border: 0; " scrolling="auto" width="' + options.width + '" height="' + options.height + '"></iframe>',
        title: options.title,
        buttons: {
            main: {
                label: "保存",
                className: "btn-primary",
                callback: function () {
                    //if (!successCallback && typeof successCallback == 'function') {
                    successCallback();
                    //}
                }
            },
            cancel: {
                label: "取消",
                className: "btn"
            }
        },
        close: function () {
            alert("关掉了窗口");
        }
    });
}
