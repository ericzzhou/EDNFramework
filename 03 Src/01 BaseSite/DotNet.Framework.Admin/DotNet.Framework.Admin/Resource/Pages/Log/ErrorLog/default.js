$(function () {
    PageModel.BindGrid();
});

var PageModel = {
    pqsAjaxSource: 'default.aspx?ajax=getlist',
    GridID: '#grid_json',
    BindGrid: function () {
        _self = this;

        //url：请求地址
        var url = PageModel.pqsAjaxSource;
        //colM：表头名称
        var colM = [
            { title: "编号", width: 60, dataIndx: "ID" },
            { title: "异常类型", width: 120, dataIndx: "ErrorType" },
            { title: "时间", width: 140, dataIndx: "OPTime" },
            { title: "异常信息", width: 250, dataIndx: "Loginfo" },
            { title: "请求路径", width: 310, dataIndx: "Url" }
        ];
        PQLoadGrid("ID", this.GridID, url, colM, 20, true);
        $(this.GridID).pqGrid({
            freezeCols: 3,
            title: "<i class=\"icon-file\"></i>&nbsp;系统日志"
        })
        
    },
    ShowDetail: function () {
        if (GetRowIndex != -1)
        {
            var id = GetPqGridCellValue(this.GridID, "ID");
            location.href = 'show.aspx?id=' + id;
        }
        else
        {
            $.Alert("很抱歉，您当前未选中任何一行！");
        }

    }
};