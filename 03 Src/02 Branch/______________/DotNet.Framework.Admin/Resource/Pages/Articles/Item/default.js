$(document).ready(function () {
    PageModel.Bind();
});


var PageModel = {
    GridID: '#grid_json',
    ModalID: 'EditModal',
    pqsAjaxSource: 'default.aspx?ajax=getPagerData',
    data: {},
    RowClick: function () {
        if (GetRowIndex != -1)
        {
            var id = GetPqGridCellValue(this.GridID, "ContentID");
            location.href = 'edit.aspx?id=' + id;
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
                var id = GetPqGridCellValue(_self.GridID, "ContentID");
                $.AjaxPostCall('?ajax=delete', true, { ID: id }, function (data) {
                    if (data.result && data.result.error)
                    {
                        $.RemoveBodyLoading();
                        $.RemoveButtonLoading();
                        $.AlertAutoClose(data.result.error);
                    }
                    else
                    {
                        _self.RefreshGrid();
                    }
                });
            }
        }
        else
        {
            $.AlertAutoClose("很抱歉，您当前未选中任何一行！");
        }
    },

    Bind: function () {
        //url：请求地址
        var url = PageModel.pqsAjaxSource;
        //colM：表头名称
        var colM = [
            { title: "编号", width: 60, dataIndx: "ContentID" },
             { title: "标题", width: 250, dataIndx: "Title" },
            { title: "类别", width: 100, dataIndx: "ClassName" },
            {
                title: "属性", width: 200,
                render: function (ui) {
                    var rowData = ui.rowData;
                    var html = "";
                    if (rowData["State"] == 'True')
                    {
                        html += '<span class="label">发布</span> ';
                    }
                    if (rowData["IsHot"] == 'True')
                    {
                        html += '<span class="label">热点</span> ';
                    }
                    if (rowData["IsRecomend"] == 'True')
                    {
                        html += '<span class="label">推荐</span> ';
                    }
                    if (rowData["IsTop"] == 'True')
                    {
                        html += '<span class="label">置顶</span> ';
                    }
                    return html;
                }
            },
             { title: "概要", width:500, dataIndx: "Summary" }
        ];
        PQLoadGrid("ContentID", this.GridID, url, colM, 20, true);
        $(this.GridID).pqGrid({
            freezeCols: 2,
            title: "<i class=\"icon-cog\"></i>&nbsp;文章管理"
        })
    },
    Insert: function () {
        location.href = 'Add.aspx';
    },
    RefreshGrid: function () {
        pqGridRefresh(this.GridID);
    }

};
