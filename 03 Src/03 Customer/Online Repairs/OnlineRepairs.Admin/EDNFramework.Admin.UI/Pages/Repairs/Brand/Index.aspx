<%@ Page Title="" Language="C#" MasterPageFile="../../../Pages/Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Repairs.Brand.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="报修系统 > 品牌管理" />
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
            ajaxUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.AjaxPath%>/Repairs/Brand.ashx?ajax='
            , editUrl: '<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Repairs/Brand/edit.aspx?id='
            , addUrl: '<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Repairs/Brand/add.aspx'
        };

        var PageModel = {
            GridID: '#grid_json',
            pqsAjaxSource: url.ajaxUrl + 'getpagerdata',
            data: {},
            RowClick: function () {
                if (GetRowIndex != -1) {
                    var id = GetPqGridCellValue(this.GridID, "ID");
                    _self = this;
                    $.RemoteDialog("修改品牌", url.editUrl + id, {
                        height: 360,
                        width: 550,
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
                        var id = GetPqGridCellValue(_self.GridID, "ID");
                        $.AjaxPostCall(url.ajaxUrl + 'delete', false, { id: id }, function (data) {
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
                    { title: "编号", width: 60, dataIndx: "ID" },
                    { title: "品牌名称", width: 200, dataIndx: "Name" },
                    { title: "品牌描述", width: 500, dataIndx: "Descriptino" }
                ];
                PQLoadGrid("id", this.GridID, url, colM, 20, false);
                $(this.GridID).pqGrid({
                    freezeCols: 3,
                    title: "<i class=\"icon-cog\"></i>&nbsp;类别管理"
                })

            },
            Insert: function () {
                _self = this;
                $.RemoteDialog("添加品牌", url.addUrl, {
                    height: 360,
                    width: 550,
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
