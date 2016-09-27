$(function () {
    PageModel.Init();
});

var PageModel = {
    data: {},
    LoadData: function () {
        _self = this;
        _self.data.NickName = $("#NickName").val();
        _self.data.Sex = $('input[name="Sex"]:checked').val();
        _self.data.Phone = $("#Phone").val();
        _self.data.Email = $("#Email").val();
    },
    Init: function () {
        _self = this;
        _self.GetDate();

        $("#btn_Save").click(function () {
            _self.LoadData();
            $.AjaxPost('?ajax=update', true, JSON.stringify(_self.data));

        });
    },
    GetDate: function () {
        _self = this;
        var id = $.trim($("#UserID").val());
        $.AjaxGet('?ajax=getmodel', true, {}, function (data) {
            $("#NickName").val(data.NickName);
            $('input[name="Sex"][value=' + data.Sex + ']').attr('checked', 'checked');
            $("#Phone").val(data.Phone);
            $("#Email").val(data.Email);

            $.RemoveButtonLoading();
            $.RemoveBodyLoading();
        });
    }
};