﻿$(function () {
    PageModel.Init();
});

var PageModel = {
    data: {},
    LoadData: function () {
        _self = this;
        _self.data.UserID = $("#UserID").val();
        _self.data.UserType = $("#UserType").val();
        _self.data.Password = $("#Password").val();
        _self.data.NickName = $("#NickName").val();
        _self.data.Activity = $("#Activity").is(':checked');
        _self.data.Sex = $('input[name="Sex"]:checked').val();
        _self.data.UserName = $("#UserName").val();
        _self.data.Phone = $("#Phone").val();
        _self.data.Email = $("#Email").val();
        _self.data.DepartmentID = $("#DepartmentID").val()
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
        _self.GetDate();

       

        $("#btn_Save").click(function () {
            _self.LoadData();
            $.AjaxPost('?ajax=updatemodel', true, _self.data);

        });
    },
    GetDate: function () {
        _self = this;
        var id = $.trim($("#UserID").val());
        $.AjaxGet('?ajax=getmodel&id=' + id, true, {}, function (data) {

            $("#UserID").val(data.UserID);
            $("#UserType").val(data.UserType);
            $("#NickName").val(data.NickName);
            $("#Activity").attr('checked', data.Activity);
            $('input[name="Sex"][value=' + data.Sex + ']').attr('checked', 'checked');
            $("#UserName").val(data.UserName);
            $("#Phone").val(data.Phone);
            $("#Email").val(data.Email);
            $("#DepartmentID").val(data.DepartmentID);

            $.RemoveButtonLoading();
            $.RemoveBodyLoading();
        });
    }
};