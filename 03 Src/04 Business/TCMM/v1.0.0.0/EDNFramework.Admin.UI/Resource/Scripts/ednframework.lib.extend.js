﻿
$(function () {
    if (!ednframework || !ednframework.lib || !ednframework.lib.tools) {
        alert("请在之前引入ednframework.lib.js文件.");
        return;
    }

    Global.Init();

    /*检查浏览器是否支持*/
    var isIE = !!window.ActiveXObject;
    var isIE6 = isIE && !window.XMLHttpRequest;
    //window.onload = function () {
    //    var footer = document.getElementById('footer');
    //    if (isIE6)
    //    {
    //        footer.style.position = 'absolute';
    //    } else
    //    {
    //        footer.style.position = 'fixed';
    //    }
    //    footer.style.bottom = '0';
    //    footer.style.width = '100%';
    //}

});

///<summary>根据城市ID获取热线医生代表</summary>
///<param name="userId" type="int">用户ID</param>
///<param name="cityId" type="int">城市ID</param>
///<returns type="String" />


var _BoxID = 'MessageBox';
var _class_btn_loading = '.btn-loading';
var _AlertModalId = 'AlertModal';

(function ($) {
    $.alert = function (message) {
        $.Alert(message);
    }
    $.Alert = function (message) {
        ///<summary>扩展Alert()</summary>
        if (message) {
            //$("#" + _AlertModalId + " .modal-body").html(message);
            //$('#' + _AlertModalId).modal('show');
            $.scojs_message(message, $.scojs_message.TYPE_ERROR);
        }
    };

    $.confirm = function (message) {
        return $.Confirm(message);
    }
    $.Confirm = function (message) {
        //var confirm = $.scojs_confirm({
        //    content: message,
        //    action: function () {
        //        this.close();
        //    }
        //});
        //confirm.show();

        return confirm(message);
    }

    $.AlertAutoClose = function (message) {
        ///<summary>扩展Alert() 1.5s 后自动关闭</summary>
        if (message) {
            //$("#" + _AlertModalId + " .modal-body").html(message);
            //$('#' + _AlertModalId).modal('show');

            //setTimeout(function () {
            //    $('#' + _AlertModalId).modal('hide');
            //}, 1500)

            $.scojs_message(message, $.scojs_message.TYPE_ERROR);
        }
    };

    $.AjaxGet = function (url, local, data, callfunction) {
        if (url) {
            if (local && local == true)
                url = window.location.pathname + url;
            //alert(url);
            url += "&_v=" + ednframework.lib.tools.NewGuid();
            $.ajax({
                async: true,
                dataType: "JSON",
                type: "GET",
                url: url,
                data: data,
                success: function (msg) {
                    callfunction(msg);
                }
            });
        }
    };

    $.AjaxPostCall = function (url, local, data, callfunction) {
        ///<summary>框架封装的 jquery ajax post 请求</summary>
        ///<param name="url" type="String">ajax请求地址</param>
        ///<param name="local" type="Boolen">是否请求当前路径，如果是 ajax url = 当前页+url参数</param>
        ///<param name="data" type="json">json类型的请求参数</param>
        ///<param name="callfunction" type="Function">ajax 处理成功后的回调函数</param>

        if (url) {
            if (local && local == true)
                url = window.location.pathname + url;
            //alert(url);
            url += "&_v=" + ednframework.lib.tools.NewGuid();
            $.ajax({
                async: true,
                dataType: "JSON",
                type: "POST",
                url: url,
                data: data,
                success: function (msg) {
                    callfunction(msg);
                }
            });

        }
    };

    $.AjaxPost = function (url, local, data, successMessage) {
        ///<summary>框架封装的 jquery ajax post 请求</summary>
        ///<param name="url" type="String">ajax请求地址</param>
        ///<param name="local" type="Boolen">是否请求当前路径，如果是 ajax url = 当前页+url参数</param>
        ///<param name="data" type="json">json类型的请求参数</param>
        ///<param name="successMessage" type="String">(可选)请求成功后显示的消息内容</param>

        if (url) {
            if (local && local == true)
                url = window.location.pathname + url;
            //alert(url);
            url += "&_v=" + ednframework.lib.tools.NewGuid();
            $.ajax({
                async: true,
                dataType: "JSON",
                //contentType: 'application/json',
                type: "POST",
                url: url,
                data: data,
                success: function (msg) {
                    if (!successMessage)
                        successMessage = '操作成功';

                    //$.RemoveBodyLoading();
                    $.RemoveButtonLoading();
                    $.ShowMessage(successMessage);

                }
            });

        }
    };

    $.SetButtonLoading = function () {
        ///<summary>设置 class = btn-loading 的按钮 不可点击 并且 value=loading</summary>
        var title = $(_class_btn_loading).attr('title');
        if (title)
            $(_class_btn_loading).val('loading');
        $(_class_btn_loading).attr("disabled", 'disabled');
    };

    $.RemoveButtonLoading = function () {
        ///<summary>取消 class = btn-loading 的按钮 不可点击 并且 value=loading</summary>
        var title = $(_class_btn_loading).attr('title');
        if (title)
            $(_class_btn_loading).val(title);
        $(_class_btn_loading).removeAttr("disabled");
    };

    $.ShowMessage = function (Message, Class) {
        ///<summary>显示提醒信息</summary>
        ///<param name="Message" type="String">消息内容</param>
        ///<param name="Class" type="String">(可选)提醒框样式 alert-success alert-warning alert-error</param>
        if (!Class)
            Class = 'alert-success';
        $("." + _BoxID + " strong").html(Message);
        $("." + _BoxID).removeClass("alert-success alert-warning alert-error").addClass(Class);
        //$("#" + _BoxID).fadeIn();
        $("." + _BoxID).show();
    };
    $.HideMessage = function () {
        $("." + _BoxID).hide();
    };

    $.ShowError = function (error) {
        ///<summary>显示异常提醒信息（ajax post 用，不建议自行调用）</summary>
        ///<param name="error" type="json">服务器端Throw 的异常信息</param>
        if (error.responseText != "" && error.status != 200) {
            var data = eval('(' + error.responseText + ')')
            var type = "alert-success";
            if (data.error.IsBizException) {
                type = "alert-warning";
            }
            else {
                type = "alert-error";
            }
            $.ShowMessage(data.error.Message, type);
        }
    };

    $.ShowBodyLoading = function (container) {
        if (!container || container == '')
            container = 'body';

        $(container).showLoading();
    };

    $.RemoveBodyLoading = function (container) {
        //if (!container || container == '')
        //    container = 'body';

        //$(container).hideLoading();
    };

    $.RemoteDialog = function (title, url, options) {
        top.OpenDialog(title, url, options);
    };


})(jQuery);


var Global = {
    _BoxId: _BoxID,
    LoadingButton: function () {
        $(".btn_loading").click(function () {
            _self = this;
            var val = $(this).val();
            $(this).val("请稍候...");
            $(this).attr("disabled", "disabled");
            setTimeout(function () {
                $(_self).val(val);
                $(_self).removeAttr("disabled");
            }, 1000);

        });
    },
    Init: function () {
        var _self = this;
        //$("#" + _self._BoxId).hide();
        _self.GlobalAjaxSend();
        _self.GlobalAjaxError();
        _self.LoadingButton();
    },
    GlobalAjaxSend: function () {
        ///<summary> ajax 请求全局 AjaxSend 事件）</summary>
        var _self = this;
        $("body").ajaxSend(function (xhr, settings) {
            //$.ShowBodyLoading();
            $.SetButtonLoading();
            $.HideMessage();
        });

    },
    GlobalAjaxError: function () {
        ///<summary> ajax 请求全局 AjaxError 事件）</summary>
        var _self = this;
        $("." + _self._BoxId + " strong").ajaxError(function (e, xhr, settings, exception) {
            $.RemoveBodyLoading();
            $.RemoveButtonLoading();
            $.ShowError(xhr);
            //$.scojs_message(xhr, $.scojs_message.TYPE_ERROR);
        });
    }

};

function OpenDialog(title, url, options) {
    if (url.indexOf('?') < 0) {
        url += "?";
    }
    var html =
   '<div class="dialog" id="dialog-window" title=' + title + '>' +
   ' <iframe src="' + url + "&_v=" + ednframework.lib.tools.NewGuid() + '" frameBorder="0" style="border: 0; " scrolling="auto" width="100%" height="100%"></iframe>' +
   '</div>';
    return $(html).dialog($.extend({
        modal: true,
        closeOnEscape: true,
        draggable: false,
        resizable: false,
        close: function (event, ui) {
            $(this).dialog("destroy"); // 关闭时销毁   
        }
    }, options));
}



