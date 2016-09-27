<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Account.User._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <div class="container">
        <div class="tools_bar">
            <div class="tools_bar-inner">
                <%--<div class="container">--%>
                <ul class="tools_bar-container">
                    <li>

                        <a href="javascript:void(0);" onclick="PageModel.AddUserDialog()">
                            <i class="icon-plus-sign"></i>
                            <span>新增</span>
                        </a>
                        <a href="javascript:void(0);" onclick="PageModel.EditMembers()">
                            <i class="icon-pencil"></i>
                            <span>编辑</span>
                        </a>
                        <a href="javascript:void(0);" onclick="PageModel.DeleteMembers()">
                            <i class="icon-minus-sign"></i>
                            <span>删除</span>
                        </a>
                        <a href="javascript:void(0);" onclick="PageModel.()">
                            <i class="icon-eye-open"></i>
                            <span>查看详细</span>
                        </a>
                        <a href="javascript:void(0);" onclick="PageModel.()">
                            <i class="icon-repeat"></i>
                            <span>重置密码</span>
                        </a><a href="javascript:void(0);" onclick="PageModel.()">
                            <i class="icon-magnet"></i>
                            <span>分配角色</span>
                        </a>

                        <a href="javascript:void(0);" onclick="PageModel.ToolsBar_Fun_Leave()">
                            <i class="icon-arrow-left"></i><%--icon-share-alt--%>
                            <span>返回</span>
                        </a>
                    </li>
                </ul>
                <%-- </div>--%>
            </div>
        </div>
         <EDNFramework:Messagebox ID="Messagebox2" runat="server" />
        <div id="grid_user" class="tab-content action-table ">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
</asp:Content>
