$(function () {
    $("#txt_startTime").datepicker({ dateFormat: "yy-mm-dd", showAnim: "drop" });
    $("#txt_endTime").datepicker({ dateFormat: "yy-mm-dd", showAnim: "drop" });

    PageModel.Init();
    PageModel.LoadGrid();
});

var PageModel = {
    data: {},
    GridID: "#grid_Item",
    LoadData: function () {
        this.data.categoryId = $.trim($("#categoryId").val());
        this.data.normOptions = document.getElementById("sel_normItem").options.length;
        this.data.depOptons = document.getElementById("sel_Department").options.length;
        this.data.startTime = $("#txt_startTime").val();
        this.data.endTime = $("#txt_endTime").val();
        this.data.departmentID = $("#sel_Department").val();
        this.data.normID = $("#sel_normItem").val()
    },
    Init: function () {
        _self = this;
        _self.LoadData();
        //读取科室（部门）
        $.AjaxGet("../../Account/User/default.aspx?ajax=getdepartment", false, {}, function (data) {
            $.RemoveButtonLoading();
            $.RemoveBodyLoading();
            for (var i = 0; i < data.length; i++)
            {
                var item = eval(data[i]);
                $("#sel_Department").append("<option value=\"" + item.ID + "\">" + item.Name + "</option>")

            }
        });

        //读取分类下医疗指标

        if (_self.data.categoryId && _self.data.categoryId != "" && Number(_self.data.categoryId) > 0)
        {

            $.AjaxGet("ajax.ashx?ajax=getnorms", false, { categoryId: _self.data.categoryId }, function (data) {
                $.RemoveButtonLoading();
                $.RemoveBodyLoading();
                for (var i = 0; i < data.length; i++)
                {
                    var item = eval(data[i]);
                    $("#sel_normItem").append("<option value=\"" + item.ID + "\">" + item.ItremName + "</option>")

                }
            });
        }
        else
        {
            alert("分类下医疗指标读取错误");
        }

        $("#btn_Search").click(function () {
            //$(_self.GridID)
            //var normOptions = document.getElementById("sel_normItem").options.length;
            //var depOptons = document.getElementById("sel_Department").options.length;
            _self.LoadData();
            if (_self.data.normOptions == 1 || _self.data.depOptons == 1)
            {
                $.ShowMessage("此分类下暂未分配医疗指标", "alert-error");
                return;
            }
            _self.LoadGrid();

        });
    },
    LoadGrid: function () {
        //var startTime = $("#txt_startTime").val();
        //var endTime = $("#txt_endTime").val();
        //var departmentID = $("#sel_Department").val();
        //var normID = $("#sel_normItem").val()
        _self = this;
        var startTime = this.data.startTime;
        var endTime = this.data.endTime;
        var departmentID = this.data.departmentID;
        var normID = this.data.normID;
        if (startTime == "" && endTime != "")
        {
            $.ShowMessage("不能单独设置结束时间", "alert-error");
            return;
        }
        if (startTime && startTime != "")
        {
            startTime += " 00:00:00";
        }
        if (endTime && endTime != "")
        {
            endTime += " 23:59:59";
        }
        if (startTime != "" && endTime != "" && startTime > endTime)
        {
            $.ShowMessage("结束时间不能小于起始时间", "alert-error");
            return;
        }
        var url = "ajax.ashx?ajax=getpagerdata"
            + "&startTime=" + escape(startTime)
            + "&endTime=" + escape(endTime)
            + "&categoryId=" + escape(this.data.categoryId)
            + "&normId=" + escape(normID)
            + "&departmentId=" + escape(departmentID);

        var colM = [
            //{
            //    title: "编号", width: 60,
            //    dataIndx: "NV.ID",
            //    render: function (ui) {
            //        var rowData = ui.rowData;
            //        var data = $.trim(rowData["ID"]);

            //        return data;
            //    }
            //},
            {
                title: "科室", width: 150, dataIndx: "DEP.Name",
                render: function (ui) {
                    var rowData = ui.rowData;
                    var data = $.trim(rowData["DepartmentName"]);

                    return data;
                }
            },
            {
                title: "指标", width: 150, dataIndx: "NI.ItremName",
                render: function (ui) {
                    var rowData = ui.rowData;
                    var data = $.trim(rowData["NormName"]);

                    return data;
                }
            },
            {
                title: "值", width: 100, dataIndx: "NV.Value",
                render: function (ui) {
                    var rowData = ui.rowData;
                    var data = $.trim(rowData["NormValue"]);

                    return data;
                }
            },
            //发生时间
            {
                title: "录入时间", width: 200, dataIndx: "NV.InDate",
                render: function (ui) {
                    var rowData = ui.rowData;
                    var data = $.trim(rowData["InDate"]);

                    return data;
                }
            },
            {
                title: "录入人", width: 100, dataIndx: "NV.InUser",
                render: function (ui) {
                    var rowData = ui.rowData;
                    var data = $.trim(rowData["InUserName"]);

                    return data;
                }
            }

        ];

        PQLoadGrid("NV.ID", _self.GridID, url, colM, 20);

        $(_self.GridID).pqGrid({
            freezeCols: 3,
        })

        pqGridResize(_self.GridID, -100, -20);
        $.RemoveButtonLoading();
        $.RemoveBodyLoading();
    }
};