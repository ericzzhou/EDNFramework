<%@ Page Title="" Language="C#" MasterPageFile="../../../../Pages/Dialog.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Other.Slide.Group.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="tab-content">
        <div class="tab-pane active form-horizontal bind-valid " id="tb_form">
            <div class="control-group">
                <label class="control-label" for="Name">组名称</label>
                <div class="controls">
                    <input type="hidden" id="ID" name="ID" />
                    <input type="text" class="input-medium require" id="Name" name="Name" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="delay">轮播间隔时间</label>
                <div class="controls">

                    <input type="text" class="input-medium" id="delay" name="delay" value="0" />
                    <span>若输入0，则3000ms</span>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="ItemType">类型</label>
                <div class="controls">
                    <select class="input-medium" id="ItemType" name="ItemType">
                        <option value="image">图片</option>
                    </select>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="Width">宽度</label>
                <div class="controls">
                    <input type="text" class="input-medium" id="Width" name="Width" value="0" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="Height">高度</label>
                <div class="controls">
                    <input type="text" class="input-medium" id="Height" name="Height" value="0" />
                </div>
            </div>

        </div>

        <EDNFramework:Messagebox ID="Messagebox1" runat="server" />

        <div class="footer-actions taab-pane">
            <input type="button" id="btn_save" class="btn btn-primary btn-loading " value="保存" />
            <%-- <input type="reset" class="btn" value="重置" />--%>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script>
        var url = {
            ajaxUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.AjaxPath%>/Other/Slide.ashx?ajax='
        };

        $(function () {
            var form = new bind("#tb_form",<%=jsonData%>);
            form.bindform();
            form.form();
            $("#btn_save").click(function () {
                var data = form.getformdata();
                if (form.valid()) {
                    $.AjaxPost(url.ajaxUrl+ 'updategroup', false, JSON.stringify(data));
                }
            });
        });
    </script>
</asp:Content>
