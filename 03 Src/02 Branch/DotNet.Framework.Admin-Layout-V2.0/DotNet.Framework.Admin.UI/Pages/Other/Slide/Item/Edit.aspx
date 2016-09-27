<%@ Page Title="" Language="C#" MasterPageFile="../../../../Pages/Dialog.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Other.Slide.Item.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="tab-content">
        <div class="tab-pane active form-horizontal bind-valid " id="tb_form">
            <div class="control-group">
                <label class="control-label" for="SlideID">组</label>
                <div class="controls">
                    <select class="input-medium" id="SlideID" name="SlideID">
                    </select>
                </div>
            </div>

            <div class="control-group">
                <label class="control-label" for="Name">名称</label>
                <div class="controls">
                    <input type="hidden" name="ID" />
                    <input type="text" class="input-medium require" id="Name" name="Name" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="Href">链接</label>
                <div class="controls">
                    <input type="text" class="input-medium require" id="Href" name="Href" value="http://" />
                    <span>必须带“http://”</span>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="FilePath">文件</label>
                <div class="controls">
                    <input type="text" class="input-medium require" id="FilePath" name="FilePath" />
                    <EDNFramework:Upload ID="upload_file" runat="server" ResultTo="FilePath" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="Enable">状态</label>
                <div class="controls">
                    <label class="checkbox inline">
                        <input type="checkbox" name="Enable" checked="checked" />启用
                    </label>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="sequence">排序</label>
                <div class="controls">
                    <input type="text" class="input-medium" id="sequence" name="sequence" value="0" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="Description">描述</label>
                <div class="controls">
                    <textarea name="Description" rows="5" cols="3"></textarea>
                </div>
            </div>
        </div>

        <EDNFramework:Messagebox ID="Messagebox1" runat="server" />

        <div class="footer-actions taab-pane">
            <input type="button" id="btn_save" class="btn btn-primary btn-loading " value="保存" />
            <%-- <input type="reset" class="btn" value="重置" /> --%>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script>
        $(function () {

            var helper = new bind("#SlideID",<%=json_group%>);
            helper.bindselect("Name","ID","0","请选择","0");


            var form = new bind("#tb_form",<%=json_Entity%>);
            form.bindform();
            form.form();
            $("#btn_save").click(function () {
                var data = form.getformdata();
                if (form.valid()) {
                    $.AjaxPost('?ajax=update', true, JSON.stringify(data));
                }
            });
        });
    </script>
</asp:Content>
