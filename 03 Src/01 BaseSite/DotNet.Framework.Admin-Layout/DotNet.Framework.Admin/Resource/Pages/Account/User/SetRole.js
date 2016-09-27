

$(document).ready(function () {
    PageModel.Init();
});


var tbl;
var PageModel = {
    sAjaxSource: '../Role/Index.aspx?ajax=getlist',
    Init: function () {
        this.Bind();
        $("#btn_Save").click(function () {
            $.Alert("功能暂未实现");
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
                                var RoleID = obj.aData.RoleID;
                                return "<input _id=\"" + RoleID + "\" type=\"checkbox\" />";
                            }
                        },
						{ "mData": "RoleID" },
						{ "mData": "RoleName" },
						{ "mData": "Description" }
                        

            ],
            'fnInitComplete': function () {
                $.RemoveButtonLoading();
                $.RemoveBodyLoading();
            }
        });
    }
};