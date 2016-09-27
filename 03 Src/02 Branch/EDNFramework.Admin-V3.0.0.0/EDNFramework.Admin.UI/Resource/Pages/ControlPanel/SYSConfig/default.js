



$(document).ready(function () {
    PageModel.Bind();
    PageModel.AppendEvent();

});


var tbl;
var PageModel = {
    GridID: '#grid_json',
    ModalID: 'EditModal',
    pqsAjaxSource: 'default.aspx?ajax=getPagerData',
    data: {},
    SetModalTitle: function (title) {
        _self = this;
        $('#' + _self.ModalID + " h3").html(title);
    },
    RowClick: function () {
        _self = this;
        if (GetRowIndex != -1)
        {
            var rowJson = GetPgGridRowData(_self.GridID);
            $("#ID").val(rowJson.ID);
            $("#Keyname").val(rowJson.Keyname);
            $("#Value").val(rowJson.Value);
            $("#Description").val(rowJson.Description);

            $("#Keyname").attr("disabled", "disabled");
            _self.SetModalTitle("编辑");
            $('#' + _self.ModalID).modal('show');
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
                $.AjaxPostCall('?ajax=deletemodel', true, { ID: id }, function (data) {
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

    LoadData: function () {
        this.data.ID = $("#ID").val();
        this.data.Keyname = $("#Keyname").val();
        this.data.Value = $("#Value").val();
        this.data.Description = $("#Description").val();
    },
    ClearData: function () {
        this.data = {};
        $("#ID").val('');
        $("#Keyname").val('');
        $("#Value").val('');
        $("#Description").val('');
    },
    EditData: function () {
        $.AjaxPost('?ajax=editdata', true, this.data);

    },
    AddData: function () {
        $.AjaxPost('?ajax=adddata', true, this.data);

    },
    AppendEvent: function () {
        _self = this;
        $(".btn-modal-close").click(function () {
            _self.ClearData();
            $('#' + _self.ModalID).modal('hide');
            _self.RefreshGrid();
            $.HideMessage();
        });

        $("#btn_add").click(function () {
            _self.Insert();
        });

        //保存
        $(".btn-modal-save").click(function () {
            _self.LoadData();
            if (_self.data.ID && _self.data.ID > 0)
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
            { title: "编号", width: 60, dataIndx: "ID" },
            { title: "项目", width: 250, dataIndx: "Keyname" },
            { title: "值", width: 350, dataIndx: "Value" },
            { title: "描述", width: 205, dataIndx: "Description" }
        ];
        PQLoadGrid("ID", this.GridID, url, colM, 20, true);
        $(this.GridID).pqGrid({
            freezeCols: 2,
            title: "<i class=\"icon-cog\"></i>&nbsp;系统设定"
        })
        
    },
    Insert: function () {
        this.ClearData();
        this.SetModalTitle("添加");
        $("#Keyname").removeAttr("disabled");
        $('#' + this.ModalID).modal('show');
    },
    RefreshGrid: function () {
        pqGridRefresh(_self.GridID);
    }

};