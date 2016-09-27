<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Index" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Style/pages/dashboard.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="系统面板" />

    <div class="row">
        <div class="span6" style="background-color: red; height: 50px;">
        </div>
          <div class="span3" style="background-color: yellow; height: 50px;">
        </div>
        <!-- /span6 -->
        <div class="span*" style="background-color: black; height: 50px;">
           测试容器
        </div>
        <!-- /span6 -->
    </div>
    <!-- /row -->

</asp:Content>
