$(function () {
    PageModel.Init();
    PageModel.ApplyEvent();
});

var PageModel = {
    data: {},
    Init: function () {
        $.AjaxGet("Ajax.ashx?ajax=getclasstype", false, {}, function (data) {
            $.RemoveButtonLoading();
            $.RemoveBodyLoading();
            for (var i = 0; i < data.length; i++) {
                var item = eval(data[i]);

                $("#ClassTypeID").append("<option value=\"" + item.ClassTypeID + "\">" + item.ClassTypeName + "</option>")
            }
        });
       
        _self = this;
 
        $.AjaxGet('?ajax=getclassinfo&ClassID=' + $.trim($("#ClassID").val()), true, {}, function (data) {
            $.RemoveButtonLoading();
            $.RemoveBodyLoading();
            var form = new bind("#tb_form", data);
            form.bindform();

        });
    },
    ApplyEvent: function () {
        _self = this;
        $("#btn_Update").click(function () {
            var form = new bind("#tb_form");
            $.AjaxPost('?ajax=UpdateData', true, form.getformdata());

        });
    }
};
