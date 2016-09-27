

$(document).ready(function () {
    PageModel.Init();
});


var tbl;
var PageModel = {
    sAjaxSource: 'Index.aspx?ajax=getlist',
    Init: function () {
        this.Bind();
    },
    Delete: function (id) {
        _self = this;
        if ($.Confirm("删除后不可恢复，确定要删除么？")) {
            if (id) {
                $.AjaxPost('?ajax=delete&id=' + id, true, JSON.stringify(_self.data));
                _self.Bind();
            }
        }
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
            "sDom": '<""l>t<"F"fp>',
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
                        {
                            "mData": null,
                            "sClass": "center",
                            'fnRender': function (obj) {
                                var ContentID = obj.aData.ContentID;
                                return "<input _id=\"" + ContentID + "\" type=\"checkbox\" />";
                            }
                        },
                        { "mData": "ContentID" },
						{ "mData": "ClassName" },
						{ "mData": "Title" },
                        {
                            "mData": null,
                            'fnRender': function (obj) {
                                var html = "";
                                if (obj.aData.State) {
                                    html += '<span class="label">' + obj.aData.State + '</span> ';
                                }
                                if (obj.aData.IsHot) {
                                    html += '<span class="label">' + obj.aData.IsHot + '</span> ';
                                }
                                if (obj.aData.IsRecomend) {
                                    html += '<span class="label">' + obj.aData.IsRecomend + '</span> ';
                                }
                                if (obj.aData.IsTop) {
                                    html += '<span class="label">' + obj.aData.IsTop + '</span> ';
                                }
                                return html;
                            }
                        },
                        {
                            "mData": null,
                            "fnRender": function (obj) {
                                var ContentID = obj.aData.ContentID;

                                var html = "";
                                html += "<a href=\"edit.aspx?id=" + ContentID + "\" class=\"btn btn-small btn-warning\">";
                                html += "<i class=\"btn-icon-only icon-edit\"></i>";
                                html += "</a> ";
                                html += "<a href=\"javascript:;\" onclick=\"PageModel.Delete('" + ContentID + "');\" class=\"btn btn-small\">";
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