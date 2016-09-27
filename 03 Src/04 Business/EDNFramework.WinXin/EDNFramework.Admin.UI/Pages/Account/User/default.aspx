<%@ Page Title="" Language="C#" MasterPageFile="../../Admin.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Account.User._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="系统安全 > 用户管理" />
    <%--<div class="container-fluid">--%>
    <div class="tools_bar-inner">



        <a href="javascript:void(0);" class="btn" onclick="PageModel.AddUserDialog()">
            <i class="icon-plus-sign"></i>
            <span>新增</span>
        </a>
        <a href="javascript:void(0);" class="btn" onclick="PageModel.EditMembers()">
            <i class="icon-pencil"></i>
            <span>编辑</span>
        </a>
        <a href="javascript:void(0);" class="btn" onclick="PageModel.DeleteMembers()">
            <i class="icon-minus-sign"></i>
            <span>删除</span>
        </a>
        <%-- <a href="javascript:void(0);" class="btn" onclick="PageModel.()">
            <i class="icon-eye-open"></i>
            <span>查看详细</span>
        </a>
        <a href="javascript:void(0);" class="btn" onclick="PageModel.()">
            <i class="icon-repeat"></i>
            <span>重置密码</span>
        </a>
        <a href="javascript:void(0);" class="btn" onclick="PageModel.()">
            <i class="icon-magnet"></i>
            <span>分配角色</span>
        </a>--%>

        <a href="javascript:void(0);" class="btn" onclick="PageModel.ToolsBar_Fun_Leave()">
            <i class="icon-arrow-left"></i><%--icon-share-alt--%>
            <span>返回</span>
        </a>

    </div>

    <EDNFramework:Messagebox ID="Messagebox2" runat="server" />
    <div id="grid_user" class="tab-content action-table ">
    </div>
    <%-- </div>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script>
        var url = {
            ajaxUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.AjaxPath%>/Account/User.ashx?ajax='
            , addUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Account/User/insert.aspx'
            , editUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Account/User//edit.aspx?id='
        };

        $(document).ready(function () {
            PageModel.Init();
        });
        var selectedRole = -1;
        var PageModel = {
            pqsAjaxSource: url.ajaxUrl + 'getlist',
            GridID: '#grid_user',
            Init: function () {
                this.BindGrid();

            },
            BindGrid: function () {
                var url = this.pqsAjaxSource;
                //colM：表头名称
                var colM = [
                    { title: "编号", width: 60, dataIndx: "UserID" },
                    { title: "登录名", width: 100, dataIndx: "UserName" },
                    { title: "昵称", width: 100, dataIndx: "NickName" },
                    {
                        title: "部门", width: 100,
                        dataIndx: "U.DepartmentID",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            var data = $.trim(rowData["DepartmentName"]);

                            return data;
                        }
                    },
                    {
                        title: "账号类型", width: 100,
                        dataIndx: "U.UserType",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            var data = $.trim(rowData["UserTypeName"]);

                            return data;
                        }
                    },
                    { title: "性别", width: 60, dataIndx: "Sex" },
                    {
                        title: "电话", width: 100, dataIndx: "U.Phone",
                        render: function (ui) {
                            var row = ui.rowData;
                            return row["Phone"]
                        }
                    },
                    { title: "邮件", width: 180, dataIndx: "Email" },
                    {
                        title: "激活", width: 70,
                        dataIndx: "Activity",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            var data = $.trim(rowData["Activity"]);
                            var html = "";
                            if (data == 'false') {
                                return "<img src='../../../Resource/Images/checknomark.gif'/>";
                            }
                            else {
                                return "<img src='../../../Resource/Images/checkmark.gif'/>";
                            }
                            //return rowData["Activity"];
                            //return '<span class="' + cla + '">' + val + '</span>';
                            return html;
                        }
                    }
                ];

                PQLoadGrid("UserID", this.GridID, url, colM, 20, false);
                $(this.GridID).pqGrid({
                    freezeCols: 0,
                    title: "<i class=\"icon-cog\"></i>&nbsp;用户管理"
                })

            },
            AddUserDialog: function () {
                _self = this;
                $.RemoteDialog("添加用户", url.addUrl, {
                    height: 620,
                    width: 600,

                    close: function () {
                        //alert("关闭了")
                        pqGridRefresh(_self.GridID);
                    }
                });
            },
            EditMembers: function () {
                _self = this;
                if (GetRowIndex != -1) {
                    var uid = GetPqGridCellValue(_self.GridID, "UserID");;
                    $.RemoteDialog("修改用户", url.editUrl + uid, {
                        height: 620,
                        width: 600,

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
            DeleteMembers: function () {
                _self = this;
                if (GetRowIndex != -1) {
                    if ($.Confirm("删除后不可恢复，确定继续吗？")) {
                        var id = GetPqGridCellValue(_self.GridID, "UserID");
                        $.AjaxPostCall(url.ajaxUrl + 'deletemodel', false, { ID: id }, function (data) {
                            pqGridRefresh(_self.GridID);
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
