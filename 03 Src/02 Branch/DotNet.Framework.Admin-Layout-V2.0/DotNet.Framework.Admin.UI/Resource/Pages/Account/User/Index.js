

$(document).ready(function () {
    PageModel.Bind();
    PageModel.AppendEvent();

});


var tbl;
var PageModel = {
    sAjaxSource: 'Index.aspx?ajax=getlist',
    editAjaxSource: '',
    data: {},
    RowDelete: function (id) {
        _self = this;
        if ($.Confirm('删除后不可恢复，确定要删除么？')) {
            $.AjaxPostCall('?ajax=deletemodel', true, { id: id }, function (data) {
                if (data.result && data.result.error) {
                    $.RemoveBodyLoading();
                    $.RemoveButtonLoading();
                    $.AlertAutoClose(data.result.error);
                }
                else {
                    _self.Bind();
                    $.AlertAutoClose('删除成功');
                }
            });
        }
    },
    AppendEvent: function () {
        _self = this;

        $("#btn_add").click(function () {
            window.location.href = 'add.aspx';
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
						{ "mData": "UserID" },
						{ "mData": "UserName" },
                        { "mData": "NickName" },
						{ "mData": "Sex" },
                        { "mData": "Phone" },
                        { "mData": "Email" },//"Activity"
                        {
                            "mData": null,
                            'fnRender': function (obj) {
                                var cla = "label";
                                var val = '激活';
                                if (!obj || !obj.aData || !obj.aData.Activity) {
                                    var cla = "label label-warning";
                                    var val = '冻结';
                                }
                                return '<span class="' + cla + '">' + val + '</span>';
                            }
                        },
                        {
                            "mData": null,
                            "fnRender": function (obj) {
                                var UserID = obj.aData.UserID;

                                var html = "";
                                html += "<a title=\"编辑\" href=\"edit.aspx?id=" + UserID + "\" class=\"btn btn-small btn-warning btn-row-edit\">";
                                html += "<i class=\"btn-icon-only icon-edit\"></i>";
                                html += "</a> ";
                                html += "<a href=\"javascript:;\" onclick=\"PageModel.RowDelete('" + UserID + "');\" class=\"btn btn-small\">";
                                html += "<i class=\"btn-icon-only icon-remove\"></i>";
                                html += "</a> ";

                                html += "<a title=\"角色\" href=\"SetRole.aspx?id=" + UserID + "\" class=\"btn btn-small\">";
                                html += "角色";
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