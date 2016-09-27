<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DotNet.Framework.Core.Test.Core.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>EDNFramework.Core 使用说明</title>
    <link rel="stylesheet" type="text/css" href="../Resource/Style/bootstrap.min.css" />
    <script type="text/javascript" src="../Resource/Scripts/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="../Resource/Scripts/bootstrap.js"></script>
    <%--<script type="text/javascript" src="../Resource/Scripts/json2.js"></script>--%>
    <script type="text/javascript" src="../Resource/Scripts/ednframework.lib.js"></script>
    <script type="text/javascript" src="../Resource/Scripts/ednframework.lib.extend.js"></script>

</head>
<body>

    <div class="container">
        <div class="row">
            <div class="page-header">
                <h1>EDNFramework异常组件 <small>点击按钮查看不同异常展现效果</small></h1>
            </div>
        </div>
        <div class="row">
            <div class="span12">
                <div id="div_error">
                    <input class="btn" type="button" id="btn_Success" value="Success" />
                    <input class="btn" type="button" id="btn_Exception" value="Exception" />
                    <input class="btn" type="button" id="btn_BusinessException" value="BusinessException" />
                    <input class="btn" type="button" id="btn_AlertException" value="AlertException" />
                    <input class="btn" type="button" id="btn_Default" value="Default" />
                    <input class="btn" type="button" id="btn_OperationException" value="OperationException" />
                    <input class="btn" type="button" id="btn_AuthorizationException" value="AuthorizationException" />
                    <a class="btn" href="javascript:;" id="btn_undefined_default">自定义默认</a>
                    <a class="btn" href="javascript:;" id="btn_undefined_style">自定义带样式</a>

                </div>
                <hr />
                <div id="MessageBox" class="alert fade in MessageBox" style="display: none;">
                    <%--<button type="button" class="close" onclick="$('.MessageBox').fadeOut();">&times;</button>--%>
                    <a href="javascript:void(0);" class="close" onclick="$('.MessageBox').fadeOut();">×</a>
                    <strong>提示信息.</strong>
                </div>

                <hr />
                <div class="widget-content">
                    <ul class="nav nav-tabs">
                        <li class="active"><a href="#wid_first" data-toggle="tab">第一步</a></li>
                        <li><a href="#wid_second" data-toggle="tab">第二步</a></li>
                        <li><a href="#wid_third" data-toggle="tab">第三步</a></li>
                        <li><a href="#wid_fourth" data-toggle="tab">第四步</a></li>
                    </ul>
                    <br />
                    <div class="tab-content">
                        <div class="tab-pane active form-horizontal" id="wid_first">
                            <fieldset>
                                <div class="control-group">
                                    <h3>配置Web.Config <small>EDNFrameworkConnectionString不能更改，用来将以此消息写入DB</small></h3>
                                    <textarea style="width: 100%" rows="4">
//添加httpModules
<httpModules>
    <add name="DotNetGlobalModule" type="DotNet.Framework.Core.HttpModules.DotNetGlobalModule,DotNet.Framework.Core"/>
</httpModules>
//添加链接字符串
<appSettings>
  <add key="EDNFrameworkConnectionString" value=""/>
</appSettings>
                                    </textarea>
                                </div>
                                <div class="control-group">
                                    <h3>导入SQL脚本</h3>
                                    <textarea style="width: 100%" rows="4">
CREATE TABLE [EDNF_SYS_ErrorLog](
	[ID]		 [int] IDENTITY(1,1) NOT NULL,
	[OPTime]	 [datetime] NULL,
	[Url]		 [varchar](max) NULL,
	[Loginfo]	 [varchar](max) NULL,
	[StackTrace] [varchar](max) NULL,
	[ErrorType]	 [varchar](100) NULL,
	[Domain]	 [varchar](200) NULL,
 CONSTRAINT [PK_EDNF_SYS_ErrorLog] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
                                    </textarea>
                                </div>
                                <div class="control-group">
                                    <h3>效果：</h3>
                                    <textarea style="width: 100%" rows="10">
<configuration>
  <appSettings>
    <add key="EDNFrameworkConnectionString" value="Data Source=localhost;Initial Catalog=EDNFramework;User ID=xx;pwd=xx"/>
  </appSettings>
  <system.web>
    <compilation debug="true" targetFramework="4.0" />
    <httpModules>
      <add name="DotNetGlobalModule" type="DotNet.Framework.Core.HttpModules.DotNetGlobalModule,DotNet.Framework.Core"/>
    </httpModules>
  </system.web>

  <system.webServer >
    <validation validateIntegratedModeConfiguration="false"  />
    <modules runAllManagedModulesForAllRequests="true"  >
      <add name="DotNetGlobalModule" type="DotNet.Framework.Core.HttpModules.DotNetGlobalModule,DotNet.Framework.Core"/>
    </modules>

  </system.webServer>
</configuration>

                                    </textarea>

                                </div>
                            </fieldset>
                        </div>
                        <div class="tab-pane form-horizontal" id="wid_second">
                            <fieldset>
                                <div class="control-group">
                                    <h3>修改并添加资源文件到项目bin目录</h3>
                                    <h3><small>Resource\DotNet.Framework.Core\Config\ImageWatermarkingConfig.xml</small></h3>
                                    <h3><small>Resource\DotNet.Framework.Core\Templates\ErrorPage.html</small></h3>
                                </div>
                            </fieldset>
                        </div>
                        <div class="tab-pane form-horizontal" id="wid_third">
                            <fieldset>
                                <div class="control-group">
                                    <h3>引入依赖文件</h3>
                                    <h3><small>DotNet.Framework.DataAccess.dll</small></h3>
                                    <h3><small>DotNet.Framework.Utils.dll</small></h3>
                                    <h3>引用EDNFramework.Core库文件</h3>
                                    <h3><small>DotNet.Framework.Core.dll</small></h3>
                                    <h3><small>下载 ： <a href="/EDNFramework/EDNFramework.Core/v2.0.0.1.rar">v2.0.0.1</a></small></h3>
                                    <h3><small>下载 ： <a href="/EDNFramework/EDNFramework.Core/v2.0.0.0.rar">v2.0.0.0</a></small></h3>
                                    
                                </div>
                            </fieldset>
                        </div>
                        <div class="tab-pane form-horizontal" id="wid_fourth">
                            <fieldset>
                                <div class="control-group">
                                    <h3>在 Ajax 方法中使用</h3>
                                    <h3><small>v2.0.0.1</small></h3>
                                    <textarea style="width: 100%;" rows="4" enable="enable">
//v2.0.0.1 新增
throw new AuthorizationException("授权异常 AuthorizationException");
throw new OperationException("操作异常 OperationException");
                                    </textarea>

                                    <h3><small>v2.0.0.0</small></h3>
                                    <textarea style="width: 100%" rows="10">
throw new BusinessException("业务异常BusinessException");
throw new Exception("异常Exception");
                                    </textarea>

                                </div>
                            </fieldset>
                        </div>

                    </div>
                </div>

            </div>
        </div>

        <script type="text/javascript">
            var url = {
                ajaxUrl: "ajax.ashx?ajax="
                //ajaxUrl: "/ajax.ashx"
            };
            $(function () {
                $("input").click(function () {
                    var ajaxAction = $(this).val();
                    $.AjaxPost(url.ajaxUrl + ajaxAction, false, null);
                    //$.AjaxPost(url.ajaxUrl, false, { ajax: ajaxAction });
                });
                $("#btn_undefined_default").click(function () {
                    $.ShowMessage("自定义消息内容,默认消息样式： alert-success");
                });
                $("#btn_undefined_style").click(function () {
                    $.ShowMessage("自定义消息内容,<br/>可选消息样式： alert-success alert-warning alert-error,<br/>当前消息样式： alert-warning", "alert-warning");
                });

                $("textarea").attr("", "");
            });
        </script>
</body>
</html>
