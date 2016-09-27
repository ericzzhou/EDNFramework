

$(document).ready(function () {
    PageModel.Bind();
    PageModel.AppendEvent();

});


var tbl;
var PageModel = {
    ModalID: 'EditModal',
    sAjaxSource: 'Index.aspx?ajax=getlist',
    editAjaxSource: '',
    data: {},
    SetModalTitle: function (title) {
        _self = this;
        $('#' + _self.ModalID + " h3").html(title);
    },
    RowClick: function (id) {
        _self = this;
        $.AjaxGet('?ajax=getmodel&id=' + id, true, {}, function (data) {
            $("#ID").val(data.ID);
            $("#Keyname").val(data.Keyname);
            $("#Value").val(data.Value);
            $("#Description").val(data.Description);
            $.RemoveButtonLoading();
            $.RemoveBodyLoading();
        });

        $("#Keyname").attr("disabled", "disabled");
        _self.SetModalTitle("编辑");
        $('#' + _self.ModalID).modal('show');
    },
    RowDelete: function (id) {
        $.AjaxPostCall('?ajax=deletemodel', true, { ID: id }, function (data) {
            if (data.result && data.result.error) {
                $.RemoveBodyLoading();
                $.RemoveButtonLoading();
                $.AlertAutoClose(data.result.error);
            }
            else {
                PageModel.Bind();

            }
        });
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
            _self.Bind();
            $.HideMessage();
        });

        $("#btn_add").click(function () {
            _self.ClearData();
            _self.SetModalTitle("添加");
            $("#Keyname").removeAttr("disabled");
            $('#' + _self.ModalID).modal('show');
        });

        //保存
        $(".btn-modal-save").click(function () {
            _self.LoadData();
            if (_self.data.ID && _self.data.ID > 0) {
                //编辑
                _self.EditData();
            }
            else {
                //新增
                _self.AddData();
            }
        });
    },
    Bind: function () {
        _self = this;
        tbl = $('.dataTable').dataTable({
            "bDestroy": true,//屏蔽错误提示
            "bProcessing": false,
            'bPaginate': true,
            'bLengthChange': false,
            'sPaginationType': 'full_numbers',
            'bFilter': false,
            'sAjaxSource': _self.sAjaxSource,
            "oLanguage": {
                "sLengthMenu": "每页显示 _MENU_ 条记录",
                "sZeroRecords": "对不起，查询不到任何相关数据",
                "sInfo": "当前显示 _START_ 到 _END_ 条，共 _TOTAL_ 条记录",
                "sInfoEmtpy": "找不到相关数据",
                //"sInfoFiltered": "数据表中共为 _MAX_ 条记录",  
                "sProcessing": "正在加载中...",
                "sSearch": "搜索",
                "sInfoEmpty": "显示 0 至 0 共 0 项",
                "oPaginate": { "sFirst": "第一页", "sPrevious": "上一页 ", "sNext": "下一页 ", "sLast": "末页 " }
            },

            "aoColumns": [
						{ "mData": "ID" },
						{ "mData": "Keyname" },
						{ "mData": "Value" },
						{ "mData": "Description" },
                        {
                            "mData": null,
                            "fnRender": function (obj) {
                                var html = "";
                                html += "<a title=\"编辑\" href=\"javascript:;\" onclick=\"PageModel.RowClick('" + obj.aData.ID + "');\" class=\"btn btn-small btn-warning btn-row-edit\">";
                                html += "<i class=\"btn-icon-only icon-edit\"></i>";
                                html += "</a> ";
                                html += "<a href=\"javascript:;\" onclick=\"PageModel.RowDelete('" + obj.aData.ID + "');\" class=\"btn btn-small\">";
                                html += "<i class=\"btn-icon-only icon-remove\"></i>";
                                html += "</a>";

                                return html;
                            }
                        }

            ],
            'fnInitComplete': function () {
                $.RemoveButtonLoading();
                $.RemoveBodyLoading();
            }
        });
    }
};