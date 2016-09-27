<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin.Master" AutoEventWireup="true" CodeBehind="role_permission_user.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Account.Role.role_permission_user" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    role_permission_user[<%=Request["roleid"] %>]
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
</asp:Content>
