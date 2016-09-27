$(function () {
    PageModel.Init();
});

var PageModel = {
    data: {},
    LoadData: function () {
        _self = this;

        _self.data.Name = $("#Name").val();
        _self.data.ShortName = $("#ShortName").val();
        _self.data.Status = $("#Status").is(':checked');
        _self.data.Phone = $("#Phone").val();
        _self.data.ExtNumber = $("#ExtNumber").val();
        _self.data.Fax = $("#Fax").val();
        _self.data.Description = $("#Description").val();
    },
    Init: function () {
        _self = this;
        $("#btn_Insert").click(function () {
            _self.LoadData();
            $.AjaxPost('?ajax=adddata', true, JSON.stringify(_self.data));

        });
    }
};