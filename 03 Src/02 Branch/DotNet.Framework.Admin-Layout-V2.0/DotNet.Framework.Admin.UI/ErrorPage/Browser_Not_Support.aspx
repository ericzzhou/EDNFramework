<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Browser_Not_Support.aspx.cs" Inherits="DotNet.Framework.Admin.UI.ErrorPage.Browser_Not_Support" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>建议升级浏览器软件
    </title>
    <style type="text/css">
        body { background-color: #F7F7F7; }
        .not-support-browser { background-color: #FFFFFF; border: 1px solid #CED0D3; border-radius: 5px; -moz-border-radius: 5px; -webkit-border-radius: 5px; width: 650px; height: 350px; margin: 100px auto; padding: 0px; }
        .Learun-logo { background-color: #333; }
        .not-support-browser-contant { color: #666666; font-size: 18px; margin: 35px 25px; text-align: center; }
        .not-support-browser-contant ul { display: inline-block; list-style: none outside none; margin: 35px 80px; padding: 0px; }
        .not-support-browser-contant ul li { float: left; margin-left: 10px; }
        .not-support-browser-contant ul li a { text-decoration: none; }
        .not-support-browser-contant ul li img { width: 64px; height: 64px; }
    </style>
</head>
<body>
    <div class="not-support-browser">

        <div class="not-support-browser-contant">
            <h1 style="font-size: 54px">您的浏览器<del>不支持</del></h1>
            <p>
                您的浏览器版本太低，所以您无法使用本系统。<br />
                我们推荐您使用以下几种浏览器，以便能更好的体验我们带给您的服务。
            </p>
            <ul>
                <li>
                    <a href="https://www.google.com/chrome?hl=en&brand=CHMI">
                        <img border="0" src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Resource/browselogo/chromelogo.png" alt="Chrome" /></a>
                </li>
                <li>
                    <a href="http://www.mozilla.org/en-US/firefox/fx/">
                        <img border="0" src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Resource/browselogo/firefoxlogo.png" alt="Firefox" /></a>
                </li>
                <li>
                    <a href="http://www.apple.com/safari/download/">
                        <img border="0" src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Resource/browselogo/safari_logo.png" alt="Safari" /></a>
                </li>
                <li>
                    <a href="http://www.opera.com/products/">
                        <img border="0" src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Resource/browselogo/operalogo.png" alt="Opera" /></a>
                </li>
                <li>
                    <a href="http://windows.microsoft.com/en-us/internet-explorer/products/ie/home">
                        <img border="0" src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Resource/browselogo/ielogo.png" alt="IE" /></a>
                </li>
            </ul>
        </div>
    </div>
</body>
</html>
