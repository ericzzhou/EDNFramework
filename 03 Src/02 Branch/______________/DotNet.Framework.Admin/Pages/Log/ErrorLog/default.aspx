<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Log.ErrorLog._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
   <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="日志 > 系统日志" />
        <EDNFramework:ToolsBar ID="ToolsBar" runat="server" disable_Insert="True" Detail_Fun="PageModel.ShowDetail()" disable_Delete="True" disable_Modify="True" />
        <div id="grid_json" class="tab-content action-table ">
        </div>
   
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
</asp:Content>
