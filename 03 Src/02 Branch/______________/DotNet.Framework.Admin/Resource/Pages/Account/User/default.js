
$(document).ready(function () {
    PageModel.Init();
});
var selectedRole = -1;
var PageModel = {
    pqsAjaxSource: 'default.aspx?ajax=getlist',
    GridID: '#grid_user',
    Init: function () {
        this.BindGrid();

    },
    BindGrid: function () {
        var url = this.pqsAjaxSource;
        //colM：表头名称
        var colM = [
            { title: "编号", width: 60, dataIndx: "UserID" },
            { title: "登录名", width: 100, dataIndx: "UserName" },
            { title: "昵称", width: 100, dataIndx: "NickName" },
            {
                title: "部门", width: 100,
                dataIndx: "U.DepartmentID",
                render: function (ui) {
                    var rowData = ui.rowData;
                    var data = $.trim(rowData["DepartmentName"]);

                    return data;
                }
            },
            {
                title: "账号类型", width: 100,
                dataIndx: "U.UserType",
                render: function (ui) {
                    var rowData = ui.rowData;
                    var data = $.trim(rowData["UserTypeName"]);
                   
                    return data;
                }
            },
            { title: "性别", width: 60, dataIndx: "Sex" },
            {
                title: "电话", width: 100, dataIndx: "U.Phone",
                render: function (ui)
                {
                    var rowData = ui.rowData;
                    var data = $.trim(rowData["Phone"]);

                    return data;
                }
            },
            { title: "邮件", width: 180, dataIndx: "Email" },
            {
                title: "激活", width: 70,
                dataIndx: "Activity",
                render: function (ui) {
                    var rowData = ui.rowData;
                    var data = $.trim(rowData["Activity"]);
                    var html = "";
                    if (data == 'false')
                    {
                        return "<img src='../../../Resource/Images/checknomark.gif'/>";
                    }
                    else
                    {
                        return "<img src='../../../Resource/Images/checkmark.gif'/>";
                    }
                    //return rowData["Activity"];
                    //return '<span class="' + cla + '">' + val + '</span>';
                    return html;
                }
            }
        ];

        PQLoadGrid("UserID", this.GridID, url, colM, 20, true);
        $(this.GridID).pqGrid({
            freezeCols: 4,
            title: "<i class=\"icon-cog\"></i>&nbsp;用户管理"
        })

    },
    AddUserDialog: function () {
        _self = this;
        $.RemoteDialog("添加用户", "insert.aspx", {
            height: 620,
            width: 600,
            buttons: {
                '关闭': function () {
                    $(this).dialog("close");
                }
            },
            close: function () {
                //alert("关闭了")
                pqGridRefresh(_self.GridID);
            }
        });
    },
    EditMembers: function () {
        _self = this;
        if (GetRowIndex != -1)
        {
            var uid = GetPqGridCellValue(_self.GridID, "UserID");;
            $.RemoteDialog("修改用户", "edit.aspx?id=" + uid, {
                height: 620,
                width: 600,
                buttons: {
                    '关闭': function () {
                        $(this).dialog("close");
                    }
                },
                close: function () {
                    //alert("关闭了")
                    pqGridRefresh(_self.GridID);
                }
            });
        }
        else
        {
            $.AlertAutoClose("很抱歉，您当前未选中任何一行！");
        }
    },
    DeleteMembers: function () {
        _self = this;
        if (GetRowIndex != -1)
        {
            if ($.Confirm("删除后不可恢复，确定继续吗？"))
            {
                var id = GetPqGridCellValue(_self.GridID, "UserID");
                $.AjaxPostCall('?ajax=deletemodel', true, { ID: id }, function (data) {
                    if (data.result && data.result.error)
                    {
                        $.AlertAutoClose(data.result.error);
                    }
                    else
                    {
                        pqGridRefresh(_self.GridID);
                    }
                });
            }
        }
        else
        {
            $.AlertAutoClose("很抱歉，您当前未选中任何一行！");
        }
    },
};