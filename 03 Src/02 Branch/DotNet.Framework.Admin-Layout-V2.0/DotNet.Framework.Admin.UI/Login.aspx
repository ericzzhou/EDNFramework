<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <meta charset="utf-8" />
    <title>登录 - <%:DotNet.Framework.Admin.Business.EDNFramework_SYS.Business_ConfigContent.GetValueByKey(DotNet.Framework.Admin.Core.Config.SysConfig.SYS_WebSiteName)%></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <link href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Resource/Style/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Resource/Style/font-awesome.css" rel="stylesheet" />
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400italic,600italic,400,600" rel="stylesheet" />

    <link href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Resource/Style/base-admin.css" rel="stylesheet" type="text/css" />
    <link href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Resource/Style/pages/signin.css" rel="stylesheet" type="text/css" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <script>
        var isIE = !!window.ActiveXObject;
        var isIE6 = isIE && !window.XMLHttpRequest;
        window.onload = function () {
            var footer = document.getElementById('footer');
            if (isIE6) {
                footer.style.position = 'absolute';
            } else {
                footer.style.position = 'fixed';
            }
            footer.style.bottom = '0';
            footer.style.width = '100%';
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="navbar navbar-fixed-top">
        <div class="navbar-inner">
            <div class="container">
                
                <a class="brand" > 
                    <img src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%><%:DotNet.Framework.Admin.Business.EDNFramework_SYS.Business_ConfigContent.GetValueByKey(DotNet.Framework.Admin.Core.Config.SysConfig.SYS_AdminLogoPath)%>" style="height: 50px;" />			
                </a>
                
            </div>
        </div>
    </div>
    <!-- /navbar -->
    <div class="account-container">
        <div class="content clearfix">
            <h1>登录</h1>
            <div class="login-fields">
                <%--<p>使用您的注册账号登录:</p>--%>
                <div class="field">
                    <label for="username">账号:</label>
                    <input type="text" runat="server" id="username" name="username" value="" placeholder="账号" class="login username-field" />
                </div>
                <!-- /field -->
                <div class="field">
                    <label for="password">密码:</label>
                    <input type="password"  runat="server" id="password" name="password" value="" placeholder="密码" class="login password-field" />
                </div>
                <!-- /password -->
            </div>
            <!-- /login-fields -->
            <div class="login-actions">
                <span class="login-checkbox">
                    <input id="autoLogin"  runat="server" name="Field" type="checkbox" class="field login-checkbox" value="First Choice" tabindex="4" />
                    <label class="choice" for="Field">自动登录</label>
                </span>
                
                <asp:Button ID="btnSingIn" runat="server" Text="登录"  class="button btn btn-primary btn-large btn_singin" OnClick="btnSingIn_Click"/>
            </div>
           <div class="login-actions">
            <div id="MessageBox" class="alert alert-error fade in MessageBox" style="display:<asp:Literal ID="litDisplay" runat="server"></asp:Literal>;">
                <a href="javascript:(0);" class="close" onclick="$('.MessageBox').fadeOut();">&times;</a>
                <strong><asp:Literal ID="litMessage" runat="server"></asp:Literal></strong>
            </div>
               </div>
        </div>
    </div>
            <div class="footer" id="footer" style="z-index: 1000;">
        <div class="footer-inner">
            <div class="container">
                <div class="row">
                    <div class="span12">
                        <%-- 技术支持：zhouzhaokun@gmail.com &nbsp;--%> CopyRight &copy; 2013 - <%:DateTime.Now.Year %> <%:DotNet.Framework.Admin.Business.EDNFramework_SYS.Business_ConfigContent.GetValueByKey(DotNet.Framework.Admin.Core.Config.SysConfig.SYS_WebCopyRight)%>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Resource/Scripts/jquery-1.7.2.min.js"></script>
    <script src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Resource/Scripts/bootstrap.js"></script>
    <script src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Resource/Scripts/Extend/jquery.extend.js"></script>
    <script src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Resource/Scripts/signin.js"></script>

    </form>

</body>
</html>
