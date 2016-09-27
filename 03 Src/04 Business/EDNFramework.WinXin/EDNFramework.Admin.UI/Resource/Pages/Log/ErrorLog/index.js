

$(document).ready(function () {
    PageModel.Bind();
});


var tbl;
var PageModel = {
    AddData: {},
    EditData: {},
    AjaxUrl: "",
    Bind: function () {
        tbl = $('.dataTable').dataTable({
            "bDestroy": true,//屏蔽错误提示
            "bProcessing": false,
            'bPaginate': true,
            'bLengthChange': false,
            'sPaginationType': 'full_numbers',
            'bFilter': false,
            'sAjaxSource': 'Index.aspx?ajax=getlist',
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
						{ "mData": "ErrorType" },
						{ "mData": "OPTime" },
						{ "mData": "Url" },
						{ "mData": "Loginfo" },
                        {
                            "mData": null,
                            "fnRender": function (obj) {
                                var html = "";
                                html += "<a href=\"show.aspx?id=" + obj.aData.ID + "\" class=\"btn btn-small btn-warning\">";
                                html += "<i class=\"btn-icon-only icon-edit\"></i>";
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