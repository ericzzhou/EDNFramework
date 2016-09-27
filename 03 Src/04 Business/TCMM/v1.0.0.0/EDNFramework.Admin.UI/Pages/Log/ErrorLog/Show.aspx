<%@ Page Title="" Language="C#" MasterPageFile="../../Admin.Master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Log.ErrorLog.Show" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <%--<div class="container">
        <div class="widget">--%>
    <div class="widget-header">
        <i class="icon-error"></i>
        <h3>异常信息</h3>
    </div>

    <div class="widget-content">
        <ul class="nav nav-tabs">
            <li class="active"><a href="#info" data-toggle="tab">基础信息</a></li>
            <li><a href="#seo" data-toggle="tab">异常堆栈</a></li>
        </ul>
        <br />
        <div class="tab-content">
            <div class="tab-pane active form-horizontal" id="info">
                <fieldset>
                    <div class="control-group">
                        <label class="control-label" for="Domain">所属模块</label>
                        <div class="controls">
                            <input type="hidden" id="id" value="<%:Request["id"] %>" />
                            <input type="text" class="input-medium" id="Domain" name="Domain" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="ErrorType">错误类型</label>
                        <div class="controls">
                            <input type="text" class="input-medium" id="ErrorType" name="ErrorType" />
                        </div>
                    </div>

                    <div class="control-group">
                        <label class="control-label" for="OPTime">异常时间</label>
                        <div class="controls">
                            <input type="text" class="input-medium" id="OPTime" name="OPTime" value="" />
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label" for="Url">请求路径</label>
                        <div class="controls">
                            <input type="text" class="input-medium" id="Url" name="Url" />
                        </div>
                    </div>


                    <div class="control-group">
                        <label class="control-label">错误信息</label>
                        <div class="controls">
                            <div class="textarea">
                                <textarea id="Loginfo" style="height: 100px; width: 500px;" name="Loginfo"> </textarea>
                            </div>
                        </div>
                    </div>
                </fieldset>
            </div>
            <div class="tab-pane form-horizontal" id="seo">
                <fieldset>

                    <div class="control-group">
                        <label class="control-label">堆栈信息</label>
                        <div class="controls">
                            <div class="textarea">
                                <textarea rows="15" style="width: 100%;" id="StackTrace" name="StackTrace"> </textarea>
                            </div>
                        </div>
                    </div>
                </fieldset>
            </div>
            <EDNFramework:Messagebox ID="Messagebox1" runat="server" />

            <div class="footer-actions taab-pane">

                <input type="button" class="btn" id="btn_Back" value="返回" />
            </div>
        </div>
    </div>
    <%--  </div>
   </div>--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script>
        $(function () {
            PageModel.Init();
            PageModel.AppendEvent();
        });
        var url = {
            ajaxUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.AjaxPath%>/Log/ErrorLog.ashx?ajax='
        };
        var PageModel = {
            Init: function () {
                var id = $.trim($("#id").val());
                $.AjaxGet(url.ajaxUrl + 'show&id=' + id, false, {}, function (data) {
                    $.RemoveButtonLoading();
                    $.RemoveBodyLoading();
                    $("#Domain").val(data.Domain);
                    $("#ErrorType").val(data.ErrorType);

                    $("#OPTime").val(data.OPTime);
                    $("#Url").val(data.Url);
                    $("#Loginfo").val(data.Loginfo);
                    $("#StackTrace").val(data.StackTrace);

                });
            },
            AppendEvent: function () {
                $("#btn_Back").click(function () {
                    location.href = 'default.aspx';
                });
            }
        };

    </script>
</asp:Content>
