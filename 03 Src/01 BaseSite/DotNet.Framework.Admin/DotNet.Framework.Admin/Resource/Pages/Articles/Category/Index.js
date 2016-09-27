

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
            "bDestroy":true,//屏蔽错误提示
            "bProcessing": false,
            'bPaginate': true,
            'bLengthChange': false,
            'sPaginationType': 'full_numbers',
            'bFilter': false,
            'sAjaxSource': 'Ajax.ashx?ajax=getclasslist',
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
						{ "mData": "ClassID" },
						{ "mData": "ClassTypeName" },
						{ "mData": "ClassName" },
						{ "mData": "Sequence" },
						{ "mData": "State" },
                        { "mData": "AllowAddContent" },
                        {
                            "mData": null,
                            "fnRender": function (obj) {
                                var html = "";
                                html += "<a href=\"javascript:;\" onclick=\"PageModel.Edit('" + obj.aData.ClassID + "');\" class=\"btn btn-small btn-warning\">";
                                html += "<i class=\"btn-icon-only icon-edit\"></i>";
                                html += "</a> ";
                                html += "<a href=\"javascript:;\" onclick=\"PageModel.Delete('" + obj.aData.ClassID + "');\" class=\"btn btn-small\">";
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
    },
    Reload:function(){
        $('.dataTable').dataTable().fnDestroy();
    },
    ApplyEvent: function () {

    },
    Edit: function (id) {
        location.href = 'edit.aspx?ClassID=' + id;
    },
    Delete: function (id) {
        _self = this;
        if (confirm("确定要删除么？")) {
            $.AjaxPost('?ajax=deleteCategory&ClassID=' + id, true);
            _self.Bind();
        }
    }
};



//    //Ajax重新load控件数据。（server端）
//    $("#btnTest").click(function () {
//        var oSettings = tbl.fnSettings();
//        oSettings.sAjaxSource = "Home/AjaxHandler2";
//        alert(oSettings.sAjaxSource);
//        tbl.fnClearTable(0);
//        tbl.fnDraw();

//    });
//});