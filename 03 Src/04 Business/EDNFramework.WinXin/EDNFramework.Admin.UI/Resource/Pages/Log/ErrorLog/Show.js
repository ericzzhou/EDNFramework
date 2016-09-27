$(function () {
    PageModel.Init();
    PageModel.AppendEvent();
});

var PageModel = {
    Init: function () {
        var id = $.trim($("#id").val());
        $.AjaxGet('?ajax=show&id=' + id, true, {}, function (data) {
            $.RemoveButtonLoading();
            $.RemoveBodyLoading();
            $("#Domain").val(data.Domain);
            $("#ErrorType").val(data.ErrorType);

            $("#OPTime").val(data.OPTime);
            $("#Url").val(data.Url);
            $("#Loginfo").val(data.Loginfo);
            $("#StackTrace").val(data.StackTrace);

        });
    },
    AppendEvent: function () {
        $("#btn_Back").click(function () {
            history.go(-1);
        });
    }
};
