<%@ Page Title="" Language="C#" MasterPageFile="../../Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Account.Department.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="系统安全 > 部门维护" />
    <div class="tools_bar-inner">
        <a href="javascript:void(0);" class="btn" onclick="PageModel.AddDepartment()">
            <i class="icon-plus-sign"></i>
            <span>新增</span>
        </a>
        <a href="javascript:void(0);" class="btn" onclick="PageModel.EditDepartment()">
            <i class="icon-pencil"></i>
            编辑
        </a>
        <a href="javascript:void(0);" class="btn" onclick="PageModel.DeleteDepartment()">
            <i class="icon-minus-sign"></i>
            <span>删除</span>
        </a>
    </div>
    <EDNFramework:Messagebox ID="Messagebox2" runat="server" />
    <div id="grid" class="tab-content action-table ">
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script>

        $(document).ready(function () {
            PageModel.Init();
        });
        var selectedRole = -1;
        var url = {
            ajaxUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.AjaxPath%>/Account/Department.ashx?ajax='
            , addUrl: '<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Account/Department/add.aspx'
            , editUrl: '<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Account/Department/edit.aspx?id='
        }
        var PageModel = {

            pqsAjaxSource: url.ajaxUrl + 'getpagerdata',
            GridID: '#grid',
            Init: function () {
                this.BindGrid();

            },
            BindGrid: function () {
                var url = this.pqsAjaxSource;
                //colM：表头名称
                var colM = [
                    { title: "编号", width: 60, dataIndx: "ID" },
                    { title: "部门名称", width: 150, dataIndx: "Name" },
                    { title: "部门短名", width: 100, dataIndx: "ShortName" },

                    { title: "部门电话", width: 120, dataIndx: "Phone" },

                    {
                        title: "状态", width: 70, align: 'center',
                        dataIndx: "Status",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            var data = $.trim(rowData["Status"]);
                            var html = "";
                            if (data == 'True') {
                                return "<img src='../../../Resource/Images/checkmark.gif'/>";
                            }
                            else {
                                return "<img src='../../../Resource/Images/checknomark.gif'/>";
                            }
                            return html;
                        }
                    },
                    { title: "描述", width: 350, dataIndx: "Description" }
                ];

                PQLoadGrid("ID", this.GridID, url, colM, 20, false);
                $(this.GridID).pqGrid({
                    freezeCols: 4,
                    title: "<i class=\"icon-cog\"></i>&nbsp;部门管理"
                })

            },
            AddDepartment: function () {
                _self = this;
                $.RemoteDialog("添加部门", url.addUrl, {
                    height: 560,
                    width: 500,
                    //buttons: {
                    //    '关闭': function () {
                    //        $(this).dialog("close");
                    //    }
                    //},
                    close: function () {
                        //alert("关闭了")
                        pqGridRefresh(_self.GridID);
                    }
                });
            },
            EditDepartment: function () {
                _self = this;
                if (GetRowIndex != -1) {
                    var id = GetPqGridCellValue(_self.GridID, "ID");;
                    $.RemoteDialog("修改部门", url.editUrl + id, {
                        height: 560,
                        width: 500,
                        //buttons: {
                        //    '关闭': function () {
                        //        $(this).dialog("close");
                        //    }
                        //},
                        close: function () {
                            //alert("关闭了")
                            pqGridRefresh(_self.GridID);
                        }
                    });
                }
                else {
                    $.AlertAutoClose("很抱歉，您当前未选中任何一行！");
                }
            },
            DeleteDepartment: function () {
                _self = this;
                if (GetRowIndex != -1) {
                    if ($.Confirm("删除后不可恢复，确定继续吗22？")) {
                        var id = GetPqGridCellValue(_self.GridID, "ID");
                        $.AjaxPostCall(url.ajaxUrl + 'delete', false, { ID: id }, function (data) {
                            if (data.result && data.result.error) {
                                $.AlertAutoClose(data.result.error);
                            }
                            else {
                                pqGridRefresh(_self.GridID);
                            }
                        });
                    }
                }
                else {
                    $.AlertAutoClose("很抱歉，您当前未选中任何一行！");
                }
            }
        };
    </script>
</asp:Content>
