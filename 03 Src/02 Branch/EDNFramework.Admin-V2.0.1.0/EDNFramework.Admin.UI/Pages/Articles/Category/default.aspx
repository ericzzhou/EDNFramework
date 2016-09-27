<%@ Page Title="" Language="C#" MasterPageFile="../../Admin.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Articles.Category._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <EDNFramework:BreadCrumb runat="server" BreadCrumbContent="文章 > 类别管理" />
    <EDNFramework:ToolsBar ID="ToolsBar" runat="server"
        Insert_Fun="PageModel.Insert()"
        Modify_Fun="PageModel.RowClick()"
        Delete_Fun="PageModel.RowDelete()"
        disable_Clear="true" disable_Detail="true" />
    <EDNFramework:Messagebox ID="Messagebox2" runat="server" />
    <div>
        <div id="grid_json" class="tab-content action-table ">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script>
        $(document).ready(function () {
            PageModel.Bind();
        });

        var url = {
            ajaxUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.AjaxPath%>/Articles/Category.ashx?ajax='
            , addUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Articles/Category/Add.aspx'
            , editUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Articles/Category/edit.aspx?ClassID='
        };

        var PageModel = {
            GridID: '#grid_json',
            ModalID: 'EditModal',
            pqsAjaxSource: url.ajaxUrl + 'getPagerData',
            data: {},
            RowClick: function () {
                var _self = this;
                if (GetRowIndex != -1) {
                    var id = GetPqGridCellValue(_self.GridID, "ClassID");
                    //location.href = url.editUrl + id;
                    $.RemoteDialog("修改产品类别", url.editUrl + id, {
                        height: 600,
                        width: 700,
                        close: function () {
                            _self.RefreshGrid();
                        }
                    });
                }
                else {
                    $.AlertAutoClose("很抱歉，您当前未选中任何一行！");
                }
            },
            RowDelete: function () {
                _self = this;
                if (GetRowIndex != -1) {
                    if ($.Confirm("删除后不可恢复，确定继续吗？")) {
                        var id = GetPqGridCellValue(_self.GridID, "ClassID");
                        $.AjaxPostCall(url.ajaxUrl+ 'deleteCategory', false, { ID: id }, function (data) {
                            _self.RefreshGrid();
                        });
                    }
                }
                else {
                    $.AlertAutoClose("很抱歉，您当前未选中任何一行！");
                }
            },

            Bind: function () {
                //url：请求地址
                var url = PageModel.pqsAjaxSource;
                //colM：表头名称
                var colM = [
                    { title: "编号", width: 60, dataIndx: "ClassID" },
                    { title: "类型", width: 100, dataIndx: "ClassTypeName" },
                    { title: "名称", width: 200, dataIndx: "ClassName" },
                    { title: "序列", width: 60, dataIndx: "Sequence" },
                    {
                        title: "状态", width: 60, align: "center", dataIndx: "State",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            var value = rowData["State"];
                            if (value == 'True') {
                                return "显示";
                            }
                            if (value == 'False') {
                                return "<span class=\"label label-warning\">隐藏</span>";
                            }
                        }
                    },
                    {
                        title: "发布文章", width: 100, align: "center", dataIndx: "AllowAddContent",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            var value = rowData["AllowAddContent"];
                            if (value == 'True') {
                                return "允许";
                            }
                            if (value == 'False') {
                                return "<span class=\"label label-important\">禁止</span>";
                            }
                        }
                    }
                ];
                PQLoadGrid("ClassID", this.GridID, url, colM, 20, false);
                $(this.GridID).pqGrid({
                    freezeCols: 3,
                    title: "<i class=\"icon-cog\"></i>&nbsp;类别管理"
                })

            },
            Insert: function () {
                _self = this;
                $.RemoteDialog("添加文章类别", url.addUrl, {
                    height: 600,
                    width: 700,
                    close: function () {
                        _self.RefreshGrid();
                    }
                });
                //location.href = url.addUrl;
            },
            RefreshGrid: function () {
                _self = this;
                pqGridRefresh(_self.GridID);
            }

        };
    </script>
</asp:Content>
