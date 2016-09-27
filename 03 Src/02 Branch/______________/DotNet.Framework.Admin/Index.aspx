<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DotNet.Framework.Admin.Index" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title><%=Resources.AppBaseResource.sys_adminTitle %></title>
    <!--<script type="text/javascript" src="js/complex.js"></script>-->
    <style type="text/css">
        body
        {
            font-family: "Helvetica Neue", Helvetica, Arial, sans-serif;
            font-size: 14px;
        }

        .ui-layout-pane
        { /* all 'panes' */
            background: #FFF;
            border: 0px solid #BBB;
            /*padding: 5px;*/
            overflow: auto;
        }

        .ui-layout-resizer
        { /* all 'resizer-bars' */
            background: #2E7AB5;
        }

        .ui-layout-toggler
        { /* all 'toggler-buttons' */
            background: #f90;
        }

        .ui-layout-south
        {
            background-color: rgb(30, 113, 177);
            color: white;
           
            font-size:12px;
        }
        .ui-layout-south span
        {
             padding-left:20px;
              padding-right:20px;
               
        }
        .ui-layout-north
        {
            background-color: #2E7AB5;
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr='#2E7AB5', endColorstr='#1E71B1', GradientType=0);
            background-image: -webkit-linear-gradient(top, #2E7AB5, #1E71B1);
        }
    </style>
    <script src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Resource/Scripts/jquery-1.7.2.min.js"></script>
    <script src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Scripts/jquery.layout.min.js"></script>
    <%--<script charset="GBK" src="<%:ResourcePath %>/Resource/Libs/iCheck/jquery.icheck.min.js"></script>--%>
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
        <img src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Resource/Images/logo2.png" style="height: 50px;" />
    </div>
    <div class="ui-layout-west" id="ui-layout-west">

        <%--<button onclick="myLayout.close('west')">Close Me</button>--%>
        <iframe width="100%" height="100%" frameborder="0" style="display: block;" id="iframe1" name="iframe_main" src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/pages/left.aspx"></iframe>

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
        <span>CopyRight © 2013 - 2013 汉中市人民医院 版权所有</span>
        <span id="user">

        </span>


        <!--<button onclick="myLayout.toggle('north')">顶部面板开关</button>
        <button onclick="myLayout.toggle('south')">底部面板开关</button>-->
    </div>
    <script>
        $(function () {
            $.ajax({
                async: true,
                dataType: "JSON",
                type: "GET",
                url: '<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/ajax.ashx?ajax=chacklogin',
                data: {},
                success: function (data) {
                    if (!data || data.status == 'false')
                    {
                        top.location.href = '<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/login.aspx'
                    }
                    else
                    {
                        $("#user").text("当前登录用户：" + data.admin_truename + "[" + data.admin_id + "]");
                    }
                }
            });
        });
    </script>
</body>
</html>
