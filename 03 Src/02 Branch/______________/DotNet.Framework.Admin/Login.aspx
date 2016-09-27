<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DotNet.Framework.Admin.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <meta charset="utf-8" />
    <title><%=Resources.AppBaseResource.sys_adminLoginTitle %></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no" />
    <meta name="apple-mobile-web-app-capable" content="yes" />

    <link href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Resource/Style/bootstrap.min.css" rel="stylesheet" type="text/css" />
<%--    <link href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Resource/Style/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />--%>

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
            if (isIE6)
            {
                footer.style.position = 'absolute';
            } else
            {
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
                <a class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse">
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </a>
                <a class="brand" > <img src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Resource/Images/logo2.png" style="height: 50px;" />				
                </a>
                <div class="nav-collapse">
                    <ul class="nav pull-right">
                        <%--<li class="">
                            <a href="./signup.html" class="">Create an Account
                            </a>
                        </li>--%>
                       <%-- <li class="">
                            <a href="./" class="">
                                <i class="icon-chevron-left"></i>
                                返回首页
                            </a>
                        </li>--%>
                    </ul>
                </div>
                <!--/.nav-collapse -->
            </div>
            <!-- /container -->
        </div>
        <!-- /navbar-inner -->
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
            <!-- .actions -->
            <div class="login-social">
                <div id="MessageBox" class="alert alert-error fade in MessageBox" style="display:<asp:Literal ID="litDisplay" runat="server"></asp:Literal>;">
                    <button type="button" class="close" onclick="$('.MessageBox').fadeOut();">&times;</button>
                    <strong><asp:Literal ID="litMessage" runat="server"></asp:Literal></strong>
                </div>
                <%--<p>Sign in using social network:</p>
                   <div class="twitter">
                        <a href="#" class="btn_1">Login with Twitter</a>
                    </div>
                    <div class="fb">
                        <a href="#" class="btn_2">Login with Facebook</a>
                    </div>--%>
            </div>
        </div>
        <!-- /content -->
    </div>
    <!-- /account-container -->
    <!-- Text Under Box -->
    <%-- <div class="login-extra">
        Don't have an account? <a href="./signup.html">Sign Up</a><br />
        Remind <a href="#">Password</a>
    </div>--%>
    <!-- /login-extra -->
            <div class="footer" id="footer" style="z-index: 1000;">
        <div class="footer-inner">
            <div class="container">
                <div class="row">
                    <div class="span5">
                       <%-- 技术支持：zhouzhaokun@gmail.com &nbsp;--%>
                    </div>
                    <div class="span4">
                        CopyRight &copy; 2013 - <%:DateTime.Now.Year %> 汉中市人民医院 版权所有
                    </div>
                    <div class="span3" style="text-align: right;">
                        
                    </div>
                    <!-- /span12 -->
                </div>
                <!-- /row -->
            </div>
            <!-- /container -->
        </div>
        <!-- /footer-inner -->
    </div>
    <script src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Resource/Scripts/jquery-1.7.2.min.js"></script>
    <script src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Resource/Scripts/bootstrap.js"></script>
    <script src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Resource/Scripts/Extend/jquery.extend.js"></script>
    <script src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Resource/Scripts/signin.js"></script>

    </form>

</body>
</html>
