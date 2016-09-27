<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin.Master" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Norm.Item.search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Libs/zTreeV3.5.14/css/zTreeStyle/zTreeStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="指标维护 > 指标查询" />
    <div class="span3">
        <div class="widget">
            <div class="widget-header">
                <i class="icon-file"></i>
                <h3>指标分类</h3>
            </div>
            <div class="widget-content">

                <table border="0" height="513px" align="left">
                    <tr>
                        <td align="left" valign="top">
                            <ul id="tree" class="ztree" style="overflow: auto;"></ul>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div id="div_input" >
        <div class="widget">
            <div class="widget-header">
                <i class="icon-bookmark"></i>
                <h3 id="p_title">指标查询</h3>
            </div>
            <EDNFramework:Messagebox ID="Messagebox1" runat="server" />
            <div class="widget-content" id="NormContent" style="height: 512px">
                <iframe width="100%" height="500" frameborder="0" style="display: block;" id="frame_page" name="frame_page" src=""></iframe>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Libs/zTreeV3.5.14/js/jquery.ztree.core-3.5.min.js"></script>
    <script>
        $(function () {
            $("#div_input").css({ width: document.body.clientWidth - 240 + "px", float: "right" });
            $(window).resize(function () {
                $("#div_input").css({ width: document.body.clientWidth - 240 + "px", float: "right" });
            })
        });

    </script>
</asp:Content>
