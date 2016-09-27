$(function () {
    PageModel.Init();
});

var PageModel = {
    data: {},
    LoadData: function () {
        _self = this;

        _self.data.ClassID = $("#ClassID").val();
        _self.data.State = $("#State").is(':checked');
        _self.data.IsHot = $("#IsHot").is(':checked');
        _self.data.IsRecomend = $("#IsRecomend").is(':checked');
        _self.data.IsTop = $("#IsTop").is(':checked');

        _self.data.Title = $("#Title").val();
        _self.data.Summary = $("#Summary").val();
        _self.data.Description =$("#Description").val();
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
    LoadContentClass: function () {
        $.AjaxGet("../Category/Ajax.ashx?ajax=getclass", false, {}, function (data) {
            $.RemoveButtonLoading();
            $.RemoveBodyLoading();
            for (var i = 0; i < data.length; i++) {
                var item = eval(data[i]);
                if (item.AllowAddContent && item.AllowAddContent == true) {
                    $("#ClassID").append("<option value=\"" + item.ClassID + "\">" + item.ClassName + "</option>")
                }
                else {
                    $("#ClassID").append("<optgroup label=\"" + item.ClassName + "\"></optgroup>")
                }
            }
        });
    },
    Init: function () {
        UE.getEditor('Description');
        this.LoadContentClass();
        this.ApplyEvent();
        
    }
};