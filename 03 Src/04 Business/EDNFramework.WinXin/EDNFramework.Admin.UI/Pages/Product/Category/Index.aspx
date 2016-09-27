<%@ Page Title="" Language="C#" MasterPageFile="../../../Pages/Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Product.Category.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="产品 > 类别维护" />
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
            ajaxUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.AjaxPath%>/Product/Category.ashx?ajax='
            , editUrl: '<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Product/Category/edit.aspx?classid='
            , addUrl: '<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Product/Category/add.aspx'
        };

        var PageModel = {
            GridID: '#grid_json',
            pqsAjaxSource: url.ajaxUrl + 'getpagerdata',
            data: {},
            RowClick: function () {
                if (GetRowIndex != -1) {
                    var id = GetPqGridCellValue(this.GridID, "ClassID");
                    _self = this;
                    $.RemoteDialog("修改产品类别", url.editUrl + id, {
                        height: 650,
                        width: 900,
                        close: function () {
                            pqGridRefresh(_self.GridID);
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
                        $.AjaxPostCall(url.ajaxUrl + 'deleteclass', false, { ClassID: id }, function (data) {
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
                    {
                        title: "编号", width: 60, dataIndx: "cc.ClassID",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            return rowData["ClassID"];
                        }
                    },
                    {
                        title: "类别", width: 200, dataIndx: "cc.ClassName",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            return rowData["ClassName"];
                        }
                    },
                    {
                        title: "父类别", width: 200, dataIndx: "cp.ClassName",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            return rowData["ParentName"];
                        }
                    },
                    {
                        title: "序列", width: 60, dataIndx: "cc.Sequence",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            return rowData["Sequence"];
                        }
                    },
                    {
                        title: "激活", width: 60, align: "center", dataIndx: "cc.Activity",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            var value = rowData["Activity"];
                            if (value == 'True') {
                                return "是";
                            }
                            if (value == 'False') {
                                return "<span class=\"label label-warning\">否</span>";
                            }
                        }
                    },
                    {
                        title: "发布产品", width: 100, align: "center", dataIndx: "cc.AllowAddContent",
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
                    },
                    {
                        title: "描述", width: 200, dataIndx: "cc.Description",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            return rowData["Description"];
                        }
                    }
                ];
                PQLoadGrid("cc.ClassID", this.GridID, url, colM, 20, false);
                $(this.GridID).pqGrid({
                    freezeCols: 3,
                    title: "<i class=\"icon-cog\"></i>&nbsp;类别管理"
                })

            },
            Insert: function () {
                _self = this;
                $.RemoteDialog("添加产品类别", url.addUrl, {
                    height: 650,
                    width: 900,
                    close: function () {
                        //alert("关闭了")
                        pqGridRefresh(_self.GridID);
                    }
                });
            },
            RefreshGrid: function () {
                pqGridRefresh(_self.GridID);
            }

        };
    </script>
</asp:Content>
