$(function () {
    UE.getEditor('Description');
    PageModel.Init();
});

var PageModel = {
    data: {},
    Bind: function () {
        var id = $("#ContentID").val();
        if (Number(id) > 0)
        {
            $.AjaxGet('?ajax=getdata', true, {id:id}, function (d) {
                if (id == d.ContentID)
                {
                    $("#ContentID").val(d.ContentID);
                    $("#ClassID").val(d.ClassID);

                    $("#State").attr('checked', d.State);
                    $("#IsHot").attr('checked', d.IsHot);
                    $("#IsRecomend").attr('checked', d.IsRecomend);
                    $("#IsTop").attr('checked', d.IsTop);

                    $("#Title").val(d.Title);
                    $("#Summary").val(d.Summary);
                    //editor.setContent(d.Description)
                    $("#Description").val(d.Description);
                    $("#Meta_Title").val(d.Meta_Title);
                    $("#SeoUrl").val(d.SeoUrl);
                    $("#Meta_Keywords").val(d.Meta_Keywords);
                    $("#Meta_Description").val(d.Meta_Description);
                }
                else
                {
                    $.Alert("数据读取异常");
                }
            });
        }
        else
        {
            $.Alert("数据读取异常");
        }
    },
    LoadData: function () {
        _self = this;
        _self.data.ContentID = $("#ContentID").val();
        _self.data.ClassID = $("#ClassID").val();
        _self.data.State = $("#State").is(':checked');
        _self.data.IsHot = $("#IsHot").is(':checked');
        _self.data.IsRecomend = $("#IsRecomend").is(':checked');
        _self.data.IsTop = $("#IsTop").is(':checked');

        _self.data.Title = $("#Title").val();
        _self.data.Summary = $("#Summary").val();
        _self.data.Description = $("#Description").val();
        _self.data.Meta_Title = $("#Meta_Title").val();
        _self.data.SeoUrl = $("#SeoUrl").val();
        _self.data.Meta_Keywords = $("#Meta_Keywords").val();
        _self.data.Meta_Description = $("#Meta_Description").val();
    },
    ApplyEvent: function () {
        _self = this;
        $("#btn_save").click(function () {
            _self.LoadData();
            $.AjaxPost('?ajax=update', true, JSON.stringify(_self.data));

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
       
        this.LoadContentClass();
        this.Bind();
        this.ApplyEvent();
        

    }
};