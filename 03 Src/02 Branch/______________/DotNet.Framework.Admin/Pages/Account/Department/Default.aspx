<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Account.Department.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="系统安全 > 部门维护" />
    <div class="tools_bar">
        <div class="tools_bar-inner">
            <%--<div class="container">--%>
            <ul class="tools_bar-container">
                <li>

                    <a href="javascript:void(0);" onclick="PageModel.AddDepartment()">
                        <i class="icon-plus-sign"></i>
                        <span>新增</span>
                    </a>
                    <a href="javascript:void(0);" onclick="PageModel.EditDepartment()">
                        <i class="icon-pencil"></i>
                        <span>编辑</span>
                    </a>
                    <a href="javascript:void(0);" onclick="PageModel.DeleteDepartment()">
                        <i class="icon-minus-sign"></i>
                        <span>删除</span>
                    </a>
                </li>
            </ul>
            <%-- </div>--%>
        </div>
    </div>
    <EDNFramework:Messagebox ID="Messagebox2" runat="server" />
    <div id="grid" class="tab-content action-table ">
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
</asp:Content>
