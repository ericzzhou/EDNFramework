$(document).ready(function () {
    PageModel.Bind();
    PageModel.AppendEvent();

});

var PageModel = {
    ModalID: 'EditModal',
    GridID: '#grid_json',
    pqsAjaxSource: 'default.aspx?ajax=getlist',
    data: {},
    SetModalTitle: function (title) {
        $('#' + this.ModalID + " h3").html(title);
    },
    RowClick: function (id) {
        if (GetRowIndex != -1)
        {
            var rowJson = GetPgGridRowData(this.GridID);
            $("#RoleID").val(rowJson.RoleID);
            $("#RoleName").val(rowJson.RoleName);
            $("#Description").val(rowJson.Description);

            this.SetModalTitle("编辑");
            $('#' + this.ModalID).modal('show');
        }
        else
        {
            $.AlertAutoClose("很抱歉，您当前未选中任何一行！");
        }
    },
    RowDelete: function () {
        if (GetRowIndex != -1)
        {
            if ($.Confirm("删除后不可恢复，确定继续吗？"))
            {
                var id = GetPqGridCellValue(this.GridID, "RoleID");
                $.AjaxPostCall('?ajax=deletemodel', true, { RoleID: id }, function (data) {
                    if (data.result && data.result.error)
                    {
                        $.RemoveBodyLoading();
                        $.RemoveButtonLoading();
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
    ShowDetail: function () {
        if (GetRowIndex != -1)
        {
            var id = GetPqGridCellValue(this.GridID, "RoleID");
            location.href = "";
        }
        else
        {
            $.AlertAutoClose("很抱歉，您当前未选中任何一行！");
        }
    },
    LoadData: function () {
        this.data.RoleID = $("#RoleID").val();
        this.data.RoleName = $("#RoleName").val();
        this.data.Description = $("#Description").val();
    },
    ClearData: function () {
        this.data = {};
        $("#RoleID").val('');
        $("#RoleName").val('');
        $("#Description").val('');
    },
    EditData: function () {
        $.AjaxPost('?ajax=editdata', true, this.data);
    },
    Insert: function () {
        this.ClearData();
        this.SetModalTitle("添加");
        //$("#Keyname").removeAttr("disabled");
        $('#' + this.ModalID).modal('show');
    },
    AddData: function () {
        $.AjaxPost('?ajax=adddata', true, this.data);
    },
    AppendEvent: function () {
        _self = this;
        $(".btn-modal-close").click(function () {
            _self.ClearData();
            $('#' + _self.ModalID).modal('hide');
            pqGridRefresh(_self.GridID);
            $.HideMessage();
        });
        //保存
        $(".btn-modal-save").click(function () {
            _self.LoadData();
            if (_self.data.RoleID && _self.data.RoleID > 0)
            {
                //编辑
                _self.EditData();
            }
            else
            {
                //新增
                _self.AddData();
            }
        });
    },
    Bind: function () {
        //url：请求地址
        var url = PageModel.pqsAjaxSource;
        //colM：表头名称
        var colM = [
            { title: "编号", width: 60, dataIndx: "RoleID" },
            { title: "角色", width: 250, dataIndx: "RoleName" },
            { title: "用户个数", width: 80, dataIndx: "UserCount" },
            { title: "描述", width: 495, dataIndx: "Description" }
        ];
        PQLoadGrid("RoleID", this.GridID, url, colM, 20, true);
        $(this.GridID).pqGrid({
            freezeCols: 2,
            title: "<i class=\"icon-cog\"></i>&nbsp;角色管理"
        })
        
    }
};