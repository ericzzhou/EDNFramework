<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DotNet.Framework.Admin.Index" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link rel="shortcut icon" href="favicon.ico" />
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%:DotNet.Framework.Admin.Business.EDNFramework_SYS.Business_ConfigContent.GetValueByKey(DotNet.Framework.Admin.Core.Config.SysConfig.SYS_WebSiteName)%></title>
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <!--<script type="text/javascript" src="js/complex.js"></script>-->
    <style type="text/css">
        body {
            font-family: "Helvetica Neue", Helvetica, Arial, sans-serif;
            font-size: 14px;
        }

        .ui-layout-pane { /* all 'panes' */
            background: #FFF;
            border: 0px solid #BBB;
            /*padding: 5px;*/
            overflow: auto;
        }

        .ui-layout-resizer { /* all 'resizer-bars' */
            background: #2E7AB5;
        }

        .ui-layout-toggler { /* all 'toggler-buttons' */
            background: #f90;
        }

        .ui-layout-south {
            background-color: rgb(30, 113, 177);
            color: white;
            font-size: 12px;
        }

            .ui-layout-south span {
                padding-left: 20px;
                padding-right: 20px;
            }

        .ui-layout-north {
            background-color: #2E7AB5;
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#2E7AB5', endColorstr='#1E71B1', GradientType=0);
            background-image: -webkit-linear-gradient(top, #2E7AB5, #1E71B1);
        }
    </style>
    <!-- Le HTML5 shim, for IE6-8 support of HTML5 elements -->
    <!--[if lt IE 9]>
      <script src="http://html5shim.googlecode.com/svn/trunk/html5.js"></script>
    <![endif]-->

    <link href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Libs/jquery-ui/bundle/themes/base/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <link href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Style/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <script src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Scripts/jquery-1.7.2.min.js"></script>
    <script src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Scripts/bootstrap.js"></script>
    <script src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Libs/jquery-ui/js/jquery-ui.min.js"></script>
    <script src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Scripts/jquery.layout.min.js"></script>
    <script src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Scripts/Extend/jquery.extend.js"></script>
    <script src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Scripts/ednframework.lib.js"></script>

    <script type="text/javascript">

        var myLayout;

        $(function () {
            myLayout = $('body').layout({
                west__showOverflowOnOut: false
            });
            //$('#ui-layout-west').load('Pages/left.aspx');
        });



    </script>

</head>
<body id="body">
    <div class="ui-layout-north">
        <div style="float: right; height: 50px; line-height: 50px;">
            <%--            <button id="loginout" style="margin-top: 10px; border: 1px solid #fff; background-color: #2E7AB5; color: #fff; font-weight: bold;">退出系统</button>--%>
            <div style="width: 150px;"></div>
        </div>
        <%--<img src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Resource/Images/logo2.png" style="height: 50px;" />--%>
        <img src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %><%:DotNet.Framework.Admin.Business.EDNFramework_SYS.Business_ConfigContent.GetValueByKey(DotNet.Framework.Admin.Core.Config.SysConfig.SYS_AdminLogoPath)%>" style="height: 50px;" />

    </div>
    <div class="ui-layout-west" id="ui-layout-west">
        <%--<button onclick="myLayout.close('west')">Close Me</button>--%>
        <iframe width="100%" height="100%" frameborder="0" style="display: block;" id="iframe1" name="iframe1" src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/pages/left.aspx"></iframe>
    </div>
    <!--<div class="ui-layout-east">
        This is the east pane, closable, slidable and resizable        
            <button onclick="myLayout.close('east')">Close Me</button>
    </div>-->

    <div class="ui-layout-center">
        <iframe width="100%" height="100%" frameborder="0" style="display: block;" id="iframe_main" name="iframe_main" src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/pages/index.aspx"></iframe>
    </div>
    <div class="ui-layout-south">
        <span id="support">技术支持：zhouzhaokun@gmail.com </span>
        <span>CopyRight&nbsp;©&nbsp;2013&nbsp;-&nbsp;<%=DateTime.Now.Year %>&nbsp;<%:DotNet.Framework.Admin.Business.EDNFramework_SYS.Business_ConfigContent.GetValueByKey(DotNet.Framework.Admin.Core.Config.SysConfig.SYS_WebCopyRight)%></span>
        <span id="user"></span>


        <!--<button onclick="myLayout.toggle('north')">顶部面板开关</button>
        <button onclick="myLayout.toggle('south')">底部面板开关</button>-->
    </div>
    <script>
        $(function () {
            $("#loginout").click(function () {
                if ($.confirm("确定要退出系统吗？")) {
                    top.location.href = '<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/LogOut.aspx'
                }
            });
            $.ajax({
                async: true,
                dataType: "JSON",
                type: "GET",
                url: '<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/ajax.ashx?ajax=chacklogin',
                data: {},
                success: function (data) {
                    if (!data || data.status == 'false') {
                        top.location.href = '<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/login.aspx'
                    }
                    else {
                        $("#user").text("当前登录用户：" + data.admin_truename + "[" + data.admin_id + "]");
                    }
                }
            });
        });
    </script>
</body>
</html>
