
var _BoxId = 'MessageBox';
var MessageBox = {
    _BoxId: _BoxId,
    ShowError: function (error) {
        if (error.responseText != "") {
            var data = eval('(' + error.responseText + ')')

            var type = "success";
            if (data.error.Type == "Business") {
                type = "warning";
            }
            if (data.error.Type = "Application") {
                type = "fail";
            }

            this.ShowBox(data.error.Message, type);
        }
    },
    ShowBox: function (Message, Type) {
        $("#" + this._BoxId + " span:eq(0)").html(Message);
        $("#" + this._BoxId).removeClass("success warning fail").addClass(Type);
        $("#" + this._BoxId).show();
        //$("#" + _BoxId).fadeIn("slow");
    }
    ,
    Close: function () {
        //$("#" + _BoxId).hide();
        $("#" + _BoxId).fadeOut("slow");
    },
    Init: function () {
        $("#" + _BoxId).hide();
        MessageBox.GlobalAjaxSend();
        MessageBox.GlobalAjaxError();
        $("#" + _BoxId + "_close").click(function () {
            MessageBox.Close();
        });
    },
    GlobalAjaxSend: function () {
        $("#" + this._BoxId).ajaxSend(function () {
            
        });

    },
    GlobalAjaxError: function () {
        $("#" + this._BoxId + " span:eq(0)").ajaxError(function (e, xhr, settings, exception) {
            MessageBox.ShowError(xhr);
        });
    }
};

$(function () {
    MessageBox.Init();
});

