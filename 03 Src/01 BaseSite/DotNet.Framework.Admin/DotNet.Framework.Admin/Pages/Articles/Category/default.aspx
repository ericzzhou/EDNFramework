<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Articles.Category._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <div class="container">
        <EDNFramework:ToolsBar ID="ToolsBar" runat="server"
            Insert_Fun="PageModel.Insert()"
            Modify_Fun="PageModel.RowClick()"
            Delete_Fun="PageModel.RowDelete()"
            disable_Clear="true" disable_Detail="true" />
        <EDNFramework:Messagebox ID="Messagebox2" runat="server" />
        <div id="grid_json" class="tab-content action-table ">
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
</asp:Content>
