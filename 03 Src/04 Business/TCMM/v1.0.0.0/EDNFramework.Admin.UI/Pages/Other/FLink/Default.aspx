<%@ Page Title="" Language="C#" MasterPageFile="../../Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Other.FLink.Default" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="其他 > 友情链接" />
    <EDNFramework:ToolsBar ID="ToolsBar" runat="server" disable_Detail="true" Insert_Fun="PageModel.Insert()" Modify_Fun="PageModel.RowClick()" Delete_Fun="PageModel.RowDelete()" disable_Clear="true" />
    <EDNFramework:Messagebox ID="Messagebox2" runat="server" />
    <div id="grid_json" class="tab-content action-table "></div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script>
        $(document).ready(function () {
            PageModel.Bind();
            PageModel.AppendEvent();
        });
        var url = {
            ajaxUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.AjaxPath%>/Other/FLink.ashx?ajax='
            , editUrl: '<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Other/FLink/edit.aspx?id='
            , addUrl: '<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Other/FLink/add.aspx'
        };
        var PageModel = {
            GridID: '#grid_json',
            pqsAjaxSource: url.ajaxUrl + 'getPagerData',
            RowClick: function () {
                _self = this;
                if (GetRowIndex != -1) {
                    var id = GetPqGridCellValue(_self.GridID, "ID");
                    $.RemoteDialog("编辑友情链接", url.editUrl + id, {
                        height: 600,
                        width: 700,
                        close: function () {
                            //alert("关闭了")
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
                    //alert(GetRowIndexs);
                    //alert(GetRowIndexs.Length);
                    if ($.Confirm("删除后不可恢复，确定继续吗？")) {
                        var id = GetPqGridCellValue(_self.GridID, "ID");
                        $.AjaxPostCall(url.ajaxUrl + 'deletemodel', false, { ID: id }, function (data) {
                            _self.RefreshGrid();
                        });
                    }
                }
                else {
                    $.AlertAutoClose("很抱歉，您当前未选中任何一行！");
                }
            },

            AppendEvent: function () {
                _self = this;
                $("#btn_add").click(function () {
                    _self.Insert();
                });
            },
            Bind: function () {
                //url：请求地址
                var url = PageModel.pqsAjaxSource;
                //colM：表头名称
                var colM = [
                    {
                        title: "浏览", width: 60, dataIndx: "ID",
                        render: function (ui) {
                            var data = ui.rowData;
                            return '<a href="' + data["LinkUrl"] + '"  target="_blank">浏览</a>';
                        }
                    },
                    { title: "编号", width: 60, dataIndx: "ID" },
                    { title: "名称", width: 250, dataIndx: "Name" },
                    {
                        title: "状态", width: 60, dataIndx: "State",
                        render: function (ui) {
                            var rowdata = ui.rowData;
                            if (rowdata['State'] == true) {
                                return "正常";
                            }
                            else {
                                return "<span class=\"label label-warning\">失效</span>";
                            }
                        }
                    },
                    {
                        title: "显示", width: 60, dataIndx: "IsDisplay",
                        render: function (ui) {
                            var rowdata = ui.rowData;
                            if (rowdata['IsDisplay']) {
                                return "显示";
                            }
                            else {
                                return "<span class=\"label label-warning\">隐藏</span>";
                            }
                        }
                    },
                    { title: "排序", width: 60, dataIndx: "OrderID" },
                    { title: "联系人", width: 100, dataIndx: "ContactPerson" },
                    { title: "电子邮箱", width: 150, dataIndx: "Email" },
                    { title: "电话", width: 150, dataIndx: "TelPhone" },
                    { title: "描述", width: 300, dataIndx: "LinkDesc" }
                ];
                var Condition = {


                };
                PQLoadGrid("ID", this.GridID, url, colM, 20, false, Condition);
                $(this.GridID).pqGrid({
                    freezeCols: 2,
                    title: "<i class=\"icon-cog\"></i>&nbsp;友情连接"
                })

            },
            Insert: function () {
                _self = this;
                $.RemoteDialog("添加友情链接", url.addUrl, {
                    height: 600,
                    width: 700,
                    close: function () {
                        //alert("关闭了")
                        _self.RefreshGrid();
                    }
                });
            },
            RefreshGrid: function () {
                pqGridRefresh(_self.GridID);
            }

        };
    </script>
</asp:Content>
