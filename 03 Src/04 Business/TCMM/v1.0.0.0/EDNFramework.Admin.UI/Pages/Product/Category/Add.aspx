﻿<%@ Page Title="" Language="C#" MasterPageFile="../../../Pages/Dialog.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Product.Category.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="tab-content">
        <div class="tab-pane active form-horizontal bind-valid " id="tb_form">
            <div class="control-group">
                <label class="control-label" for="ParentId">父类别</label>
                <div class="controls">
                    <select id="ParentId" name="ParentId" class="require">
                        <option value="0">请选择</option>
                    </select>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="ClassName">类别名称</label>
                <div class="controls">
                    <input type="text" class="input-medium require" id="ClassName" name="ClassName" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="Sequence">类别权重</label>
                <div class="controls">
                    <input type="text" class="input-medium" id="Sequence" name="Sequence" value="0" />
                    <span>1~99</span>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label">状态</label>
                <div class="controls">
                    <label class="checkbox inline">
                        <input type="checkbox" id="Activity" name="Activity" checked="checked" />激活
                    </label>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label">发布产品</label>
                <div class="controls">
                    <label class="checkbox inline">
                        <input type="checkbox" id="AllowAddContent" name="AllowAddContent" checked="checked" />允许
                    </label>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="Description">描述</label>
                <div class="controls">
                    <textarea id="Description" rows="3" name="Description"></textarea>
                </div>
            </div>
        </div>

        <EDNFramework:Messagebox ID="Messagebox1" runat="server" />

        <div class="footer-actions taab-pane">
            <input type="button" id="btn_Insert" class="btn btn-primary btn-loading " value="保存" />
            <%-- <input type="reset" class="btn" value="重置" />--%>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script>
        var url = {
            ajaxUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.AjaxPath%>/Product/Category.ashx?ajax='
        };
        $(function () {
            //ParentId
            $.AjaxGet(url.ajaxUrl + "getclass", false, {}, function (data) {
                $.RemoveButtonLoading();
                $.RemoveBodyLoading();
                var helper = new bind("#ParentId", data);
                helper.bindselect("ClassName", "ClassID", "0", "请选择父类别", "0");
            });

            var form = new bind("#tb_form");
            form.form();
            $("#btn_Insert").click(function () {
                var data = form.getformdata();
                if (form.valid()) {
                    $.AjaxPost(url.ajaxUrl + 'adddata', false, JSON.stringify(data));
                }
            });
        });
    </script>
</asp:Content>
