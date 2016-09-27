$(function () {
    PageModel.Init();
    PageModel.ApplyEvent();
});

var PageModel = {
    data: {},
    LoadData: function () {
        _self = this;
        _self.data.ClassID = $("#ClassID").val();
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
        _self.LoadData();
 
        $.AjaxGet('?ajax=getclassinfo&ClassID=' + _self.data.ClassID, true, {}, function (data) {
            $.RemoveButtonLoading();
            $.RemoveBodyLoading();
            $("#ClassTypeID").val(data.ClassTypeID);
            $("#Sequence").val(data.Sequence);

            $("#State").attr('checked', data.State);
            $("#AllowAddContent").attr('checked', data.AllowAddContent);
            //_self.data.State = $("#State").is(':checked');
            //_self.data.AllowAddContent = $("#AllowAddContent").is(':checked');
            $("#ClassName").val(data.ClassName);
            $("#Description").val(data.Description);
            $("#Meta_Title").val(data.Meta_Title);
            $("#SeoUrl").val(data.SeoUrl);
            $("#Meta_Keywords").val(data.Meta_Keywords);
            $("#Meta_Description").val(data.Meta_Description);

        });
    },
    ApplyEvent: function () {
        _self = this;
        $("#btn_Update").click(function () {
           
            _self.LoadData();
            $.AjaxPost('?ajax=UpdateData', true, _self.data);

        });
    }
};
