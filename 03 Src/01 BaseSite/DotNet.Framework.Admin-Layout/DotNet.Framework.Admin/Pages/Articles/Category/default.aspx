<%@ Page Title="" Language="C#" MasterPageFile="../../Admin.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Articles.Category._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
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


        var PageModel = {
            GridID: '#grid_json',
            ModalID: 'EditModal',
            pqsAjaxSource: 'default.aspx?ajax=getPagerData',
            data: {},
            RowClick: function () {
                if (GetRowIndex != -1) {
                    var id = GetPqGridCellValue(this.GridID, "ClassID");
                    location.href = 'edit.aspx?ClassID=' + id;
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
                        $.AjaxPostCall('?ajax=deleteCategory', true, { ID: id }, function (data) {
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
                location.href = 'Add.aspx';
            },
            RefreshGrid: function () {
                pqGridRefresh(_self.GridID);
            }

        };
    </script>
</asp:Content>
