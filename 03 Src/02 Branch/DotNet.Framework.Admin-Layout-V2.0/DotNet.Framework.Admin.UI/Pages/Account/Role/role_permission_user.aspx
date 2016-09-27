<%@ Page Title="" Language="C#" MasterPageFile="../../Admin.Master" AutoEventWireup="true" CodeBehind="role_permission_user.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Account.Role.role_permission_user" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <div class="footer-actions taab-pane">
        <a href="javascript:void(0);" id="AddMember" class="btn">
            <i class="icon-plus-sign"></i>
            <span>添加成员</span>
        </a>
    </div>
    <EDNFramework:Messagebox ID="Messagebox2" runat="server" />
    <div id="grid_user" class="tab-content action-table ">
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script>
       
        var selectedRole = -1;
        var PageModel = {
            currentUser:<%=DotNet.Framework.Admin.Core.Entity.BusEntity_LoginUser.Sys_LoginUser.UserID%>,
            currentRoleId:<%=Request["roleid"]%>,
            pqsAjaxSource: 'role_permission_user.aspx?ajax=getlistbyroleid',
            GridID: '#grid_user',
            Init: function () {
                _self = this;
                $("#AddMember").click(function(){
                    $.RemoteDialog("添加成员", "<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Account/Role/AddMember.aspx?rid=<%=Request["roleid"]%>", {
                        height: 520,
                        width: 600,
                        //buttons: {
                        //    '关闭': function () {
                        //        $(this).dialog("close");
                        //    }
                        //},
                        close: function () {
                            pqGridRefresh(_self.GridID);
                        }
                    });
                });
                
                this.BindGrid();

            },
            Remove: function (id) {
                if ($.confirm("确定要移除吗？")) {
                    var paramData = {
                        roleid: this.currentRoleId,
                        uid: id
                    };
                    $.AjaxPostCall('?ajax=removeuser', true, paramData, function (data) {
                        pqGridRefresh(PageModel.GridID);
                    });
                   
                }
            },
            BindGrid: function () {
            var url = this.pqsAjaxSource;
            //colM：表头名称
            var colM = [
                //{ title: "编号", width: 60, dataIndx: "UserID" },
                {
                    title: "移除", width: 60,dataIndx:"UserName",
                    render: function (ui) {
                        var rowData = ui.rowData;
                        if (rowData["UserID"] == PageModel.currentUser) {
                            return "";
                        }
                        else
                            return "<a class='label label-warning icon-remove btn' href='javascript:void(0);' onclick='PageModel.Remove(" + rowData["UserID"] + ")'>移除</a>";
                    }
                },
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
                    title: "账号类型", width: 90,
                    dataIndx: "U.UserType",
                    render: function (ui) {
                        var rowData = ui.rowData;
                        var data = $.trim(rowData["UserTypeName"]);

                        return data;
                    }
                },
                { title: "性别", width: 60, dataIndx: "Sex" },
                { title: "电话", width: 100, dataIndx: "U.Phone",
                    render:function(ui)
                    {
                        var data = ui.rowData;
                        return data["Phone"];
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
                        return html;
                    }
                }
                ];

                PQLoadGrid("U.UserID", this.GridID, url, colM, 20, false,{RoleID:this.currentRoleId});
                $(this.GridID).pqGrid({
                    freezeCols: 4,
                    title: "<i class=\"icon-cog\"></i>&nbsp;用户管理"
                })

            }
        };
        $(document).ready(function () {
            PageModel.Init();
        });
    </script>
</asp:Content>
