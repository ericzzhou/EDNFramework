$(function () {
    PageModel.Init();
});

var PageModel = {
    data: {},
    LoadData: function () {
        _self = this;
        _self.data.Password = $("#Password").val();
        _self.data.Password_new = $("#Password_new").val();
        _self.data.Password_new2 = $("#Password_new2").val();
    },
    Init: function () {
        _self = this;

        $("#btn_Save").click(function () {
            _self.LoadData();
            $.AjaxPost('?ajax=modifypass', true, JSON.stringify(_self.data));

        });
    },
};