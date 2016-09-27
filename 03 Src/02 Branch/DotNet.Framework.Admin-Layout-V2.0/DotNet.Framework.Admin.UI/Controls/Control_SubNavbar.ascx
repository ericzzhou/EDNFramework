<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Control_SubNavbar.ascx.cs" Inherits="DotNet.Framework.Admin.UI.Controls.Control_SubNavbar" %>
<%--<div class="subnavbar" style="z-index: 1000;">
    <div class="subnavbar-inner">
        <div class="container">
            <ul class="mainnav">
                <li id="INDEX">
                    <a href="<%:ResourcePath%>/Pages/Index.aspx">
                        <i class="icon-home"></i>
                        <span>首页</span>
                    </a>
                </li>
                <li id="ARTICLE" class="dropdown">
                    <a href="javascript:;" class="dropdown-toggle" data-toggle="dropdown">
                        <i class="icon-book"></i>
                        <span>文章管理</span>
                        <b class="caret"></b>
                    </a>
                    <ul class="dropdown-menu">
                        <li><a href="<%:ResourcePath%>/Pages/Articles/Category/default.aspx">类别管理</a></li>
                        <li><a href="<%:ResourcePath%>/Pages/Articles/Category/add.aspx">添加类别</a></li>
                        <li class="divider"></li>
                        <li><a href="<%:ResourcePath%>/Pages/Articles/Item/default.aspx">文章管理</a></li>
                        <li><a href="<%:ResourcePath%>/Pages/Articles/Item/Add.aspx">添加文章</a></li>
                    </ul>
                </li>
                <li id="PRODUCT" class="dropdown">
                    <a href="javascript:;" class="dropdown-toggle" data-toggle="dropdown">
                        <i class="icon-shopping-cart"></i>
                        <span>产品管理</span>
                        <b class="caret"></b>
                    </a>
                    <ul class="dropdown-menu">
                        <li><a href="<%:ResourcePath%>/Pages/Product/Category/Index.aspx">类别管理</a></li>
                        <li><a href="<%:ResourcePath%>/Pages/Product/Category/Add.aspx">添加类别</a></li>
                        <li class="divider"></li>
                        <li><a href="<%:ResourcePath%>/Pages/Product/Item/Index.aspx">产品管理</a></li>
                        <li><a href="<%:ResourcePath%>/Pages/Product/Item/Add.aspx">添加产品</a></li>
                    </ul>
                </li>

                <li id="LOG" class="dropdown">
                    <a href="javascript:;" class="dropdown-toggle" data-toggle="dropdown">
                        <i class="icon-facetime-video"></i>
                        <span>日志查询</span>
                        <b class="caret"></b>
                    </a>
                    <ul class="dropdown-menu">
                        <li><a href="<%:ResourcePath%>/Pages/Log/ErrorLog/default.aspx">系统日志</a></li>
                    </ul>
                </li>

                <li id="ACCOUNT" class="dropdown">
                    <a href="javascript:;" class="dropdown-toggle" data-toggle="dropdown">
                        <i class="icon-lock"></i>
                        <span>系统安全</span>
                        <b class="caret"></b>
                    </a>
                    <ul class="dropdown-menu">
                        <li><a href="<%:ResourcePath%>/Pages/Account/Permission/Index.aspx">权限管理</a></li>
                        <li><a href="<%:ResourcePath%>/Pages/Account/Role/default.aspx">角色管理</a></li>
                        <li><a href="<%:ResourcePath%>/Pages/Account/Role/RolePermission.aspx">角色权限</a></li>
                        <li class="divider"></li>
                        <li><a href="<%:ResourcePath%>/Pages/Account/User/default.aspx">用户管理</a></li>
                        <li><a href="<%:ResourcePath%>/Pages/Account/Department/default.aspx">部门管理</a></li>

                    </ul>
                </li>

                <li id="SYSTEM" class="dropdown">
                    <a href="javascript:;" class="dropdown-toggle" data-toggle="dropdown">
                        <i class="icon-cog"></i>
                        <span>控制面板</span>
                        <b class="caret"></b>
                    </a>
                    <ul class="dropdown-menu">

                        <li><a href="<%:ResourcePath%>/Pages/ControlPanel/SysConfig/default.aspx">系统设定</a></li>
                    </ul>
                </li>
                <li id="Li1" class="dropdown">
                    <a href="javascript:;" class="dropdown-toggle" data-toggle="dropdown">
                        <i class="icon-share-alt"></i>
                        <span>更多页面</span>
                        <b class="caret"></b>
                    </a>
                    <ul class="dropdown-menu">
                        <li><a href="<%:ResourcePath%>/Pages/ControlPanel/Guestbook/Index.aspx">留言管理</a></li>
                        <li><a href="#">友情链接</a></li>
                        <li><a href="#">Charts</a></li>
                        <li><a href="#">User Account</a></li>
                        <li class="divider"></li>
                        <li><a href="#">Login</a></li>
                        <li><a href="#">Signup</a></li>
                        <li><a href="#">Error</a></li>
                    </ul>
                </li>
            </ul>
        </div>
        <div style="clear: both;"></div>
    </div>

</div>--%>
<input type="hidden" id="hid_CurrentNav" value="<%=CurrentNav %>" />