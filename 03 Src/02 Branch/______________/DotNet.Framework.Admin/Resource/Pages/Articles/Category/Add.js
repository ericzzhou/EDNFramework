$(function () {
    PageModel.Init();
    PageModel.ApplyEvent();
});

var PageModel = {
    data: {},
    LoadData: function () {
        _self = this;

        _self.data.ClassTypeID = $("#ClassTypeID").val();
        _self.data.Sequence = $("#Sequence").val();
        _self.data.State = $("#State").is(':checked');
        _self.data.AllowAddContent = $("#AllowAddContent").is(':checked');
        _self.data.ClassName = $("#ClassName").val();
        _self.data.Description = $("#Description").val();
        _self.data.Meta_Title = $("#Meta_Title").val();
        _self.data.SeoUrl = $("#SeoUrl").val();
        _self.data.Meta_Keywords = $("#Meta_Keywords").val();
        _self.data.Meta_Description = $("#Meta_Description").val();
    },
    ApplyEvent: function () {
        _self = this;
        $("#btn_Insert").click(function () {
            _self.LoadData();
            $.AjaxPost('?ajax=AddData', true, JSON.stringify(_self.data));

        });
    },
    Init: function () {
        //$.get("Ajax.ashx?ajax=getclasstype", function (data) {
        //    $.RemoveButtonLoading();
        //    for (var i = 0; i < data.length; i++) {
        //        var item = eval(data[i]);

        //        $("#ClassTypeID").append("<option value=\"" + item.ClassTypeID + "\">" + item.ClassTypeName + "</option>")
        //    }
        //});

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