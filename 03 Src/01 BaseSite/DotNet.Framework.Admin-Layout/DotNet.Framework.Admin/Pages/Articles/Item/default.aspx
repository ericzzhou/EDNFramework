<%@ Page Title="" Language="C#" MasterPageFile="../../Admin.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Articles.Item._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="文章 > 文章管理" />
    <%--<EDNFramework:ToolsBar ID="ToolsBar" runat="server"
        Insert_Fun="PageModel.Insert()"
        Modify_Fun="PageModel.RowClick()"
        Delete_Fun="PageModel.RowDelete()"
        disable_Clear="true" disable_Detail="true" />--%>

    <div class="tools_bar-inner form-inline">
        <a href="javascript:void(0);" class="btn" onclick="PageModel.Insert()">
            <i class="icon-plus-sign"></i>
            <span>新增</span>
        </a>
        <a href="javascript:void(0);" class="btn" onclick="PageModel.RowClick()">
            <i class="icon-pencil"></i>
            <span>编辑</span>
        </a>

        <a href="javascript:void(0);" class="btn" onclick="PageModel.RowDelete()">
            <i class="icon-minus-sign"></i>
            <span>删除</span>
        </a>
        <input type="text" placeholder="输入文章标题" id="search_articletitle"/>
        <select id="search_articleclass">
            <option value="0">选择文章分类</option>
        </select>
         <a href="javascript:void(0);" class="btn" id="btn_search">
            <i class="icon-search"></i>
            <span>查询</span>
        </a>
    </div>
    



    <EDNFramework:Messagebox ID="Messagebox2" runat="server" />
    <div id="grid_json" class="tab-content action-table ">
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script>
        $(document).ready(function () {
           
            PageModel.Init();
        });


        var PageModel = {
            GridID: '#grid_json',
            ModalID: 'EditModal',
            pqsAjaxSource: 'default.aspx?ajax=getPagerData',
            data: {},
            Init: function () {
                this.BindClass();
                this.Bind();
                $("#btn_search").click(function () {
                    PageModel.Bind();
                });
            },
            RowClick: function () {
                if (GetRowIndex != -1) {
                    var id = GetPqGridCellValue(this.GridID, "ContentID");
                    location.href = 'edit.aspx?id=' + id;
                }
                else {
                    $.AlertAutoClose("很抱歉，您当前未选中任何一行！");
                }
            },
            RowDelete: function () {
                _self = this;
                if (GetRowIndex != -1) {
                    if ($.Confirm("删除后不可恢复，确定继续吗？")) {
                        var id = GetPqGridCellValue(_self.GridID, "ContentID");
                        $.AjaxPostCall('?ajax=delete', true, { ID: id }, function (data) {
                            if (data.result && data.result.error) {
                                $.RemoveBodyLoading();
                                $.RemoveButtonLoading();
                                $.AlertAutoClose(data.result.error);
                            }
                            else {
                                _self.RefreshGrid();
                            }
                        });
                    }
                }
                else {
                    $.AlertAutoClose("很抱歉，您当前未选中任何一行！");
                }
            },

            Bind: function () {
                //url：请求地址
                var classid = $.trim($("#search_articleclass").val());
                var title = $.trim($("#search_articletitle").val());
                var url = PageModel.pqsAjaxSource + "&ClassID=" + classid + "&Title=" + title;
                //colM：表头名称
                var colM = [
                    { title: "编号", width: 60, dataIndx: "ContentID" },
                    { title: "标题", width: 250, dataIndx: "Title" },
                    { title: "类别", width: 100, dataIndx: "ClassName" },
                    {
                        title: "属性", width: 200, dataIndx: "IsTop",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            var html = "";
                            if (rowData["State"] == 'True') {
                                html += '<span class="label">发布</span> ';
                            }
                            if (rowData["IsHot"] == 'True') {
                                html += '<span class="label">热点</span> ';
                            }
                            if (rowData["IsRecomend"] == 'True') {
                                html += '<span class="label">推荐</span> ';
                            }
                            if (rowData["IsTop"] == 'True') {
                                html += '<span class="label">置顶</span> ';
                            }
                            return html;
                        }
                    },
                     {
                         title: "概要", width: 500,
                         render: function (ui) {
                             var row = ui.rowData;
                             return row["Summary"];
                         }
                     }
                ];
                PQLoadGrid("ContentID", this.GridID, url, colM, 20, false);
                $(this.GridID).pqGrid({
                    freezeCols: 2,
                    title: "<i class=\"icon-cog\"></i>&nbsp;文章管理"
                })
            },
            Insert: function () {
                location.href = 'Add.aspx';
            },
            RefreshGrid: function () {
                pqGridRefresh(this.GridID);
            },
            BindClass: function () {
                $.AjaxGet("../Category/Ajax.ashx?ajax=getclass", false, {}, function (data) {
                    $.RemoveButtonLoading();
                    $.RemoveBodyLoading();
                    var helper = new bind("#search_articleclass",data);
                    helper.bindselect("ClassName", "ClassID", "0", "选择文章分类", "0");
                });
            }

        };
    </script>
</asp:Content>
