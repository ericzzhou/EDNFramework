
$(document).ready(function () {
    PageModel.Init();
});
var selectedRole = -1;
var PageModel = {
    pqsAjaxSource: 'default.aspx?ajax=getpagerdata',
    GridID: '#grid',
    Init: function () {
        this.BindGrid();

    },
    BindGrid: function () {
        var url = this.pqsAjaxSource;
        //colM：表头名称
        var colM = [
            { title: "编号", width: 60, dataIndx: "ID" },
            { title: "部门名称", width: 150, dataIndx: "Name" },
            { title: "部门短名", width: 100, dataIndx: "ShortName" },

            { title: "部门电话", width: 120, dataIndx: "Phone" },
           
            {
                title: "状态", width: 70,align:'center',
                dataIndx: "Status",
                render: function (ui) {
                    var rowData = ui.rowData;
                    var data = $.trim(rowData["Status"]);
                    var html = "";
                    if (data == 'True')
                    {
                        return "<img src='../../../Resource/Images/checkmark.gif'/>";
                    }
                    else
                    {
                        return "<img src='../../../Resource/Images/checknomark.gif'/>";
                    }
                    return html;
                }
            },
            { title: "描述", width: 350, dataIndx: "Description" }
        ];

        PQLoadGrid("ID", this.GridID, url, colM, 20, true);
        $(this.GridID).pqGrid({
            freezeCols: 4,
            title: "<i class=\"icon-cog\"></i>&nbsp;部门管理"
        })

    },
    AddDepartment: function () {
        _self = this;
        $.RemoteDialog("添加部门", "add.aspx", {
            height: 600,
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
    EditDepartment: function () {
        _self = this;
        if (GetRowIndex != -1)
        {
            var id = GetPqGridCellValue(_self.GridID, "ID");;
            $.RemoteDialog("修改部门", "edit.aspx?id=" + id, {
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
    DeleteDepartment: function () {
        _self = this;
        if (GetRowIndex != -1)
        {
            if ($.Confirm("删除后不可恢复，确定继续吗？"))
            {
                var id = GetPqGridCellValue(_self.GridID, "ID");
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