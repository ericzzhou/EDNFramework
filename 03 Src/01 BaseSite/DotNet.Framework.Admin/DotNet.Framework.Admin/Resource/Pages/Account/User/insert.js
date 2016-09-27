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
        _self.data.DepartmentID = $("#DepartmentID").val();
    },
    Init: function () {
        _self = this;

        $.AjaxGet("default.aspx?ajax=getdepartment", false, {}, function (data) {
            for (var i = 0; i < data.length; i++)
            {
                var item = eval(data[i]);

                $("#DepartmentID").append("<option value=\"" + item.ID + "\">" + item.Name + "</option>")

            }
        });


        $("#btn_Insert").click(function () {
            _self.LoadData();
            $.AjaxPost('?ajax=adddata', true, _self.data);

        });
    }
};