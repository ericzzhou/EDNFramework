

$(document).ready(function () {
    PageModel.Bind();
});


var tbl;
var PageModel = {
    GridID: '#grid_Item',
    ModalID: 'EditModal',
    pqsAjaxSource: 'ajax.aspx?ajax=getpagerdata',
    data: {},
    EditNormItem: function () {
        _self = this;
        if (GetRowIndex != -1)
        {
            var id = GetPqGridCellValue(_self.GridID, "ID");
            $.RemoteDialog("编辑指标明细", "edit.aspx?id=" + id, {
                height: 450,
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
    RowDelete: function () {
        _self = this;
        if (GetRowIndex != -1)
        {
            if ($.Confirm("删除后不可恢复，确定继续吗？"))
            {
                var id = GetPqGridCellValue(_self.GridID, "ID");
                $.AjaxPostCall('ajax.aspx?ajax=deletemodel', false, { ID: id }, function (data) {
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
    StopNormItem: function () {
        _self = this;
        if (GetRowIndex != -1)
        {
            var id = GetPqGridCellValue(_self.GridID, "ID");
            $.AjaxPostCall('ajax.aspx?ajax=stopmodel', false, { ID: id }, function (data) {
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
        else
        {
            $.AlertAutoClose("很抱歉，您当前未选中任何一行！");
        }
    },
    StartNormItem: function () {
        _self = this;
        if (GetRowIndex != -1)
        {
            var id = GetPqGridCellValue(_self.GridID, "ID");
            $.AjaxPostCall('ajax.aspx?ajax=startmodel', false, { ID: id }, function (data) {
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
        else
        {
            $.AlertAutoClose("很抱歉，您当前未选中任何一行！");
        }
    },
    Bind: function () {
        //url：请求地址
        var url = PageModel.pqsAjaxSource + "&categoryid=" + $("#categoryid").val();
        //colM：表头名称
        var colM = [
            { title: "名称", width: 120, dataIndx: "ItremName" },
            { title: "简码", width: 60, dataIndx: "ItemCode" },
            {
                title: "指标类型", width: 150, dataIndx: 'ItemCategory',
                render: function (ui) {
                    var rowData = ui.rowData;
                    return rowData["ItemCategoryName"];
                }
            },
            { title: "建档时间", width: 130, dataIndx: "ItemCreateTime" },
            { title: "停用时间", width: 130, dataIndx: "ItemStopTime" },
            {
                title: "状态", width: 60, dataIndx: "ItemStatus",
                render: function (ui) {
                    var rowData = ui.rowData;
                    var stat = rowData["ItemStatus"];
                    if (stat == "Y")
                    {
                        return '<span class="label label-warning">停用</span>';
                    }
                    else
                    {
                        return '<span class="label">启用</span>';

                    }
                }
            }
        ];
        PQLoadGrid("ni.ID", this.GridID, url, colM, 20);
        $(this.GridID).pqGrid({
            freezeCols: 1,
            //title: "<i class=\"icon-cog\"></i>&nbsp;系统设定"
           
        })
        pqGridResize(this.GridID,-65,-10);
    },
    AddNormItem: function () {
        _self = this;
        $.RemoteDialog("添加指标明细", "add.aspx?cid=" + $("#categoryid").val(), {
            height: 450,
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
};