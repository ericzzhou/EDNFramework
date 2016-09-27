

$(document).ready(function () {
    PageModel.Bind();
    PageModel.AppendEvent();

});


var tbl;
var PageModel = {
    GetRowIndex: -1,
    ModalID: 'EditModal',
    sAjaxSource: 'Index.aspx?ajax=getlist',
    pqsAjaxSource: 'default.aspx?ajax=getPagerData',
    editAjaxSource: '',
    data: {},
    SetModalTitle: function (title) {
        _self = this;
        $('#' + _self.ModalID + " h3").html(title);
    },
    RowClick: function () {
        _self = this;
        if (this.GetRowIndex != -1)
        {
            var DM = $("#grid_json").pqGrid("option", "dataModel");
            var data = DM.data;
            var rowJson = DM.data[this.GetRowIndex];
            var id = rowJson.ID;
            //$.AjaxGet('?ajax=getmodel&id=' + id, true, {}, function (data) {
            //    $("#ID").val(data.ID);
            //    $("#Keyname").val(data.Keyname);
            //    $("#Value").val(data.Value);
            //    $("#Description").val(data.Description);
            //    $.RemoveButtonLoading();
            //    $.RemoveBodyLoading();
            //});

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
        if (this.GetRowIndex != -1)
        {
            var DM = $("#grid_json").pqGrid("option", "dataModel");
            var data = DM.data;
            var rowJson = DM.data[this.GetRowIndex];
            var id = rowJson.ID;

            $.AjaxPostCall('?ajax=deletemodel', true, { ID: id }, function (data) {
                if (data.result && data.result.error)
                {
                    $.RemoveBodyLoading();
                    $.RemoveButtonLoading();
                    $.AlertAutoClose(data.result.error);
                }
                else
                {
                    /*PageModel.Bind();*/
                    _self.RefreshGrid();
                }
            });
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
        $.AjaxPost('?ajax=editdata', true, _self.data);

    },
    AddData: function () {
        $.AjaxPost('?ajax=adddata', true, _self.data);

    },
    AppendEvent: function () {
        _self = this;
        $(".btn-modal-close").click(function () {
            _self.ClearData();
            $('#' + _self.ModalID).modal('hide');
            //_self.Bind();
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
        _self = this;
        var colM = [
            { title: "编号", width: 60, dataIndx: "ID" },
            { title: "项目", width: 250, dataIndx: "Keyname" },
            { title: "值", width: 350, dataIndx: "Value" },
            { title: "描述", width: 400, dataIndx: "Description" }
        ];

        var dataModel = {
            location: "remote",
            sorting: "remote",
            paging: "remote",
            dataType: "JSON",
            method: "GET",
            curPage: 1,
            rPP: 20,
            sortIndx: 0,
            sortDir: "down",
            rPPOptions: [10, 20, 30, 40, 50, 100, 500, 1000],
            getUrl: function () {
                var sortDir = (this.sortDir == "up") ? "asc" : "desc";
                var sort = ['ID', 'Keyname', 'Value', 'Description'];
                return {

                    url: _self.pqsAjaxSource, data: "pageindex=" + this.curPage + "&pagesize=" +
                        this.rPP + "&sortBy=" + sort[this.sortIndx] + "&dir=" + sortDir
                };
            },
            getData: function (dataJSON) {
                return { curPage: dataJSON.curPage, totalRecords: dataJSON.totalRecords, data: dataJSON.data };
            }
        }


        var grid1 = $("#grid_json").pqGrid({
            width: 1130,
            height: 470,
            dataModel: dataModel,
            colModel: colM,
            title: "<i class=\"icon-user\"></i>&nbsp;系统设定",
            //resizable: true,
            columnBorders: true,
            freezeCols: 4,
            //selectionModel: { type: 'cell' },
            selectionModel: { mode: 'single' },
            selectionModel: { type: 'row' },
            editModel: { clicksToEdit: 2 },
            editable: false,
            //scrollModel: { horizontal: false },
            topVisible: true,
            bottomVisible: true,
            rowSelect: function (evt, ui) {
                _self.GetRowIndex = ui.rowIndxPage;
            }
        });
    },
    Insert: function () {
        _self.ClearData();
        _self.SetModalTitle("添加");
        $("#Keyname").removeAttr("disabled");
        $('#' + _self.ModalID).modal('show');
    },
    RefreshGrid: function () {
        $("#grid_json").pqGrid("refreshDataAndView");
    }

};