﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin.Master" AutoEventWireup="true" CodeBehind="Show.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Log.ErrorLog.Show" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <div class="container">
        <div class="widget">
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
                                        <textarea id="Loginfo" name="Loginfo"> </textarea>
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
                                        <textarea style="width: 90%; height: 210px;" id="StackTrace" name="StackTrace"> </textarea>
                                    </div>
                                </div>
                            </div>
                        </fieldset>
                    </div>
                    <EDNFramework:Messagebox ID="Messagebox1" runat="server" />

                    <div class="form-actions taab-pane">

                        <input type="button" class="btn" id="btn_Back" value="返回" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
