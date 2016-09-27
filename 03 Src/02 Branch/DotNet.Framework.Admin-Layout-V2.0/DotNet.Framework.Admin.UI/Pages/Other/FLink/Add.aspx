<%@ Page Title="" Language="C#" MasterPageFile="../../../Pages/Dialog.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Other.FLink.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="tab-content">
        <div class="tab-pane active form-horizontal bind-valid " id="tb_form">
            <div class="control-group">
                <label class="control-label" for="Name">名称</label>
                <div class="controls">
                    <input type="hidden" id="TypeID" name="TypeID" value="0" />
                    <input type="hidden" id="ImgUrl" name="ImgUrl" />
                    <input type="hidden" id="ImgWidth" name="ImgWidth" />
                    <input type="hidden" id="ImgHeight" name="ImgHeight" />
                    <input type="text" class="input-medium require" id="Name" name="Name" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="LinkUrl">链接</label>
                <div class="controls">
                    <input type="text" class="input-medium" id="LinkUrl" name="LinkUrl" value="http://" />
                    <span>必须带“http://”</span>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="OrderID">顺序</label>
                <div class="controls">
                    <input type="text" class="input-medium" id="OrderID" name="OrderID" value="0" />
                    <span>输入0 - 99999，数值越小，排名越靠前</span>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="ContactPerson">联系人</label>
                <div class="controls">
                    <input type="text" class="input-medium" id="ContactPerson" name="ContactPerson" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="TelPhone">联系电话</label>
                <div class="controls">
                    <input type="text" class="input-medium" id="TelPhone" name="TelPhone" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="Email">电子邮件</label>
                <div class="controls">
                    <input type="text" class="input-medium" id="Email" name="Email" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label">状态</label>
                <div class="controls">
                    <label class="checkbox inline">
                        <input type="checkbox" id="State" name="State" checked="checked" />正常
                    </label>
                    <label class="checkbox inline">
                        <input type="checkbox" id="IsDisplay" name="IsDisplay" checked="checked" />显示
                    </label>
                </div>
            </div>

            <div class="control-group">
                <label class="control-label" for="LinkDesc">描述</label>
                <div class="controls">
                    <textarea id="LinkDesc" rows="3" name="LinkDesc"></textarea>
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
        $(function () {
            var form = new bind("#tb_form");
            form.form();
            $("#btn_Insert").click(function () {
                var data = form.getformdata();
                if (form.valid()) {
                    $.AjaxPost('?ajax=adddata', true, JSON.stringify(data));
                }
            });
        });
    </script>
</asp:Content>
