$(function () {
    PageModel.Init();
    PageModel.ApplyEvent();
});

var PageModel = {
    ApplyEvent: function () {
        _self = this;
        $("#btn_Insert").click(function () {
            var form = new bind("#tb_form");
            $.AjaxPost('?ajax=AddData', true,JSON.stringify(form.getformdata()));

        });
    },
    Init: function () {
        $.AjaxGet("Ajax.ashx?ajax=getclasstype", false, {}, function (data) {
            $.RemoveButtonLoading();
            $.RemoveBodyLoading();
            for (var i = 0; i < data.length; i++) {
                var item = eval(data[i]);

                $("#ClassTypeID").append("<option value=\"" + item.ClassTypeID + "\">" + item.ClassTypeName + "</option>")
            }
        });
    }
};