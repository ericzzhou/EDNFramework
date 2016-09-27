<%@ Page Title="" Language="C#" MasterPageFile="Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Style/pages/dashboard.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <%
        //取得页面执行开始时间
        DateTime stime = DateTime.Now;

    %>
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="服务器信息" />
    <table class="table table-striped table-bordered table-hover">
        <tbody>
            <tr>
                <td style="width: 300px;">服务器名称</td>
                <td><%=Server.MachineName%></td>

            </tr>
            <tr>

                <td>服务器域名</td>
                <td><%=Request.ServerVariables["SERVER_NAME"]%></td>
            </tr>
            <tr>

                <td>服务器IP</td>
                <td><%=Request.ServerVariables["LOCAL_ADDR"]%></td>
            </tr>
            <tr>

                <td>HTTP端口</td>
                <td><%=Request.ServerVariables["SERVER_PORT"]%></td>
            </tr>
            <tr>

                <td>当前系统用户名</td>
                <td><%=Environment.UserName%></td>
            </tr>
            <tr>

                <td>服务器系统版本</td>
                <td><%=Environment.OSVersion.ToString()%></td>
            </tr>
            <tr>

                <td>服务器系统信息</td>
                <td><%=Request.ServerVariables["HTTP_USER_AGENT"]%> </td>
            </tr>
            <tr>

                <td>服务器处理器个数</td>
                <td><%=Environment.ProcessorCount.ToString()%> </td>
            </tr>
            <tr>

                <td>服务器物理内存</td>
                <td><%=Environment.WorkingSet.ToString() %></td>
            </tr>
            <tr>

                <td>启动到现在已运行</td>
                <td><%=((Environment.TickCount / 0x3e8) / 60).ToString()%> 分钟</td>
            </tr>
            <tr>

                <td>CPU 数量</td>
                <td><%=Environment.GetEnvironmentVariable("NUMBER_OF_PROCESSORS").ToString()%> </td>
            </tr>
            <tr>

                <td>CPU类型</td>
                <td><%=Environment.GetEnvironmentVariable("PROCESSOR_IDENTIFIER").ToString()%></td>
            </tr>
            <tr>

                <td>服务端语言</td>
                <td><%=Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"]%> </td>
            </tr>
            <tr>

                <td>Framework版本</td>
                <td><%=Environment.Version.ToString() %></td>
            </tr>
            <tr>

                <td>服务器时间</td>
                <td><%=DateTime.Now%></td>
            </tr>
            <tr>

                <td>ASP.NET所站内存</td>
                <td><%=((Double)System.Diagnostics.Process.GetCurrentProcess().WorkingSet64 / 1048576).ToString("N2")%> M</td>
            </tr>
            <tr>

                <td>ASP.NET所占CPU</td>
                <td><%=((TimeSpan)System.Diagnostics.Process.GetCurrentProcess().TotalProcessorTime).TotalSeconds.ToString("N0")%> %</td>
            </tr>
            <tr>

                <td>探针文件路径</td>
                <td><%=Server.MapPath(Request.ServerVariables["SCRIPT_NAME"])%></td>
            </tr>
            <tr>

                <td>服务器系统所在文件夹</td>
                <td><%=Environment.SystemDirectory.ToString()%></td>
            </tr>
            <tr>

                <td>允许文件</td>
                <td><%=Request.ServerVariables["HTTP_ACCEPT"]%></td>
            </tr>

            <tr>
                <td>MD目录</td>
                <td><%=Request.ServerVariables["APPL_MD_PATH"]%></td>
            </tr>
            <tr>
                <td>执行文件绝对路径</td>
                <td><%=Request.ServerVariables["PATH_TRANSLATED"]%></td>
            </tr>
            <tr>
                <td>虚拟目录绝对路径</td>
                <td><%=Request.ServerVariables["APPL_PHYSICAL_PATH"]%></td>
            </tr>
            <tr>
                <td>虚拟目录Session总数</td>
                <td><%=Session.Contents.Count%></td>
            </tr>
            <tr>
                <td>虚拟目录Application总数</td>
                <td><%=Application.Contents.Count%></td>
            </tr>
            <tr>
                <td>IIS版本</td>
                <td><%=Request.ServerVariables["SERVER_SOFTWARE"]%></td>
            </tr>
            <tr>
                <td>脚本超时时间</td>
                <td><%=(Server.ScriptTimeout / 1000).ToString()%>秒</td>
            </tr>
            <tr>
                <td>SLL连接</td>
                <td><%=Request.ServerVariables["HTTPS"]%></td>
            </tr>
            <tr>
                <td>CGI版本</td>
                <td><%=Request.ServerVariables["GATEWAY_INTERFACE"]%></td>
            </tr>
            <tr>
                <td>IE版本</td>
                <td>
                    <%
                        Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Version Vector");
                        Response.Write(key.GetValue("IE", "未检测到").ToString());
                    %>
                </td>
            </tr>
        </tbody>
    </table>
    <EDNFramework:BreadCrumb ID="BreadCrumb2" runat="server" BreadCrumbContent="客户端信息" />
    <table class="table table-striped table-bordered table-hover">
        <tbody>
            <tr>
                <td style="width: 300px;">客户端ip地址</td>
                <td><%= Request.ServerVariables["REMOTE_ADDR"] %></td>
            </tr>
            <tr>
                <td>客户端浏览器类型</td>
                <td><%= Request.Browser.Type%></td>
            </tr>
            <tr>
                <td>客户端浏览器类型</td>
                <td><%= Request.Browser%></td>
            </tr>
            <tr>
                <td>客户端浏览器版本</td>
                <td><%= Request.Browser.Version%></td>
            </tr>
            <tr>
                <td>客户端浏览器主版本</td>
                <td><%= Request.Browser.MajorVersion%></td>
            </tr>
            <tr>
                <td>客户端浏览器次版本</td>
                <td><%= Request.Browser.MinorVersion%></td>
            </tr>
            <tr>
                <td>客户端浏览器是否测试版本</td>
                <td><%= Request.Browser.Beta%></td>
            </tr>
            <tr>
                <td>客户端浏览器是否客户平台</td>
                <td><%= Request.Browser.Platform%></td>
            </tr>
            <tr>
                <td>客户端浏览器是否AOL 浏览器</td>
                <td><%= Request.Browser.AOL%></td>
            </tr>
            <tr>
                <td>客户端浏览器是否基于Win16</td>
                <td><%= Request.Browser.Win16%></td>
            </tr>
            <tr>
                <td>客户端浏览器是否基于Win32</td>
                <td><%= Request.Browser.Win32%></td>
            </tr>
            <tr>
                <td>客户端浏览器是否支持框架</td>
                <td><%= Request.Browser.Frames%></td>
            </tr>
            <tr>
                <td>客户端浏览器是否支持表格</td>
                <td><%= Request.Browser.Tables%></td>
            </tr>
            <tr>
                <td>客户端浏览器是否支持Cookies</td>
                <td><%= Request.Browser.Cookies%></td>
            </tr>
            <tr>
                <td>客户端浏览器是否支持VB Script</td>
                <td><%= Request.Browser.VBScript%></td>
            </tr>
            <tr>
                <td>客户端浏览器是否支持JavaScript</td>
                <td><%= Request.Browser.JavaScript%></td>
            </tr>
            <tr>
                <td>客户端浏览器支持JScript的版本</td>
                <td><%= Request.Browser.JScriptVersion%></td>
            </tr>
            <tr>
                <td>客户端浏览器是否支持JavaApplets</td>
                <td><%= Request.Browser.JavaApplets%></td>
            </tr>
            <tr>
                <td>客户端浏览器是否支持ActiveXControls</td>
                <td><%= Request.Browser.ActiveXControls%></td>
            </tr>
            <tr>
                <td>客户端浏览器是否支持CDF</td>
                <td><%= Request.Browser.CDF%></td>
            </tr>
            <tr>
                <td>户端浏览器是否支持背景音乐</td>
                <td><%= Request.Browser.BackgroundSounds%></td>
            </tr>
            <tr>
                <td>客户端浏览器ECMAScript版本</td>
                <td><%= Request.Browser.EcmaScriptVersion%></td>
            </tr>
            <tr>
                <td>客户端浏览器MSDom版本</td>
                <td><%= Request.Browser.MSDomVersion%></td>
            </tr>
            <tr>
                <td>客户端浏览器W3CDom版本</td>
                <td><%= Request.Browser.W3CDomVersion%></td>
            </tr>
            <tr>
                <td>客户端浏览器语言</td>
                <td><%= Request.ServerVariables["HTTP_ACCEPT_LANGUAGE"]%></td>
            </tr>
        </tbody>
    </table>


    <%
        //取得页面执行结束时间
        DateTime etime = DateTime.Now;
        //计算页面执行时间
        string tTime = "本次页面执行时间: " + ((etime - stime).TotalMilliseconds).ToString() + "毫秒";

    %>
    <div><%=tTime %></div>
</asp:Content>
