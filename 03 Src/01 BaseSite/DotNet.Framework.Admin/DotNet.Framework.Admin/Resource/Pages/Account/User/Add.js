$(function () {
    PageModel.Init();
});

var PageModel = {
    data: {},
    LoadData: function () {
        _self = this;

        _self.data.UserType = $("#UserType").val();
        _self.data.NickName = $("#NickName").val();
        _self.data.Activity = $("#Activity").is(':checked');
        _self.data.Sex = $('input[name="Sex"]:checked').val();
        _self.data.UserName = $("#UserName").val();
        _self.data.Phone = $("#Phone").val();
        _self.data.Email = $("#Email").val();
    },
    Init: function () {
        _self = this;
        $("#btn_Insert").click(function () {
            _self.LoadData();
            $.AjaxPost('?ajax=adddata', true, _self.data);

        });
    }
};