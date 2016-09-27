<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.left" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="../Resource/Libs/jquery-ui/bundle/themes/ui-lightness/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            font-family: "Helvetica Neue", Helvetica, Arial, sans-serif;
            font-size: 12px;
        }

        .ui-accordion .ui-accordion-content
        {
            /*padding: 0.5em 0.5em;*/
            padding-top: 0.5em;
            padding-left: 0.5em;
            padding-right: 0.5em;
            padding-bottom: 1em;
        }

        #accordion > div > div
        {
            width: 90%;
            height: 35px;
            line-height: 35px;
            margin-left: 0;
            margin-right: 0;
            padding-left: 1em;
            margin: 0 auto;
            /*border:1px solid blue*/
        }


        .accordion_menu_selected
        {
            background-color: rgb(30, 113, 177);
            color: #fff;
            padding-left: 1em;
        }

        #accordion > div > div:hover
        {
            background-color: rgb(88, 149, 185);
            color: #fff;
            padding-left: 1em;
        }
    </style>
    <script src="<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Scripts/jquery-1.7.2.min.js"></script>
    <script src="<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Libs/jquery-ui/js/jquery-ui.min.js"></script>
    <script src="<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Scripts/json2.js"></script>
    <script type="text/javascript">
        $(function () {
            LoadMenu();
           
        });
        //$(window).resize(function () {
        //    LoadMenu();
        //})
        function LoadMenu() {
            $("#accordion").height($(window).height() - 16 + "px");

            $("#accordion").accordion({
                heightStyle: "fill",
            });


            $("#accordion div div").each(function () {
                $(this).click(function () {
                    $("#accordion div div").removeClass("accordion_menu_selected");
                    $(this).addClass("accordion_menu_selected");
                });
            });
            $("#accordion div div").click(function () {
                var href = $(this).attr("data-href");
                var frameid = parent.document.getElementById("iframe_main");
                frameid.src = href;
                return;
            });
        }
    </script>

</head>
<body>

    <div id="accordion">
        <%-- <h3>文章管理</h3>
        <div>
            <div style="cursor: pointer" data-href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Articles/Category/default.aspx">
                类别管理
            </div>
            <div style="cursor: pointer" data-href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Articles/Category/add.aspx">添加类别</div>
            <div style="cursor: pointer" data-href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Articles/Item/default.aspx">文章管理</div>
            <div style="cursor: pointer" data-href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Articles/Item/Add.aspx">添加文章</div>
        </div>--%>
        <h3>指标维护</h3>
        <div>
            <div style="cursor: pointer" data-href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Norm/default.aspx">指标维护</div>
            <div style="cursor: pointer" data-href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Norm/item/entering.aspx">指标录入</div>
            <div style="cursor: pointer" data-href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Norm/item/search.aspx">指标查询</div>
        </div>
        <h3>日志查询</h3>
        <div>
            <div style="cursor: pointer" data-href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Log/ErrorLog/default.aspx">系统日志</div>
        </div>
        <h3>系统安全</h3>
        <div>
            <div style="cursor: pointer" data-href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Account/Permission/Index.aspx">权限管理</div>
            <div style="cursor: pointer" data-href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Account/Role/default.aspx">角色管理</div>
            <div style="cursor: pointer" data-href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Account/Role/RolePermission.aspx">角色权限</div>
            <div style="cursor: pointer" data-href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Account/User/default.aspx">用户管理</div>
            <div style="cursor: pointer" data-href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Account/Department/default.aspx">部门管理</div>
        </div>
    </div>
</body>
</html>
