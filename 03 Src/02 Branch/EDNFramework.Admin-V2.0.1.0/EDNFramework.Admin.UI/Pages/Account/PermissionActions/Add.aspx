<%@ Page Title="" Language="C#" MasterPageFile="../../Dialog.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Account.PermissionActions.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="tab-content">
        <div class="tab-pane active form-horizontal bind-valid " id="tb_form">
            <div class="control-group">
                <label class="control-label" for="PermissionCode">模块</label>
                <div class="controls">
                    <input type="hidden" id="PermissionCode" name="PermissionCode" />
                    <input type="text" class="input-medium" readonly="true" id="PermissionName" name="PermissionName" />
                </div>
            </div>

           
            <div class="control-group">
                <label class="control-label" for="Description">按钮名称</label>
                <div class="controls">
                    <input type="text" class="input-medium require" id="Description" name="Description" />
                </div>
            </div>
             <div class="control-group">
                <label class="control-label" for="ActionCode">按钮权限</label>
                <div class="controls">
                    <input type="text" class="input-medium  require" id="ActionCode" name="ActionCode" />
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
            ajaxUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.AjaxPath%>/Account/PermissionActions.ashx?ajax='
        };
        $(function () {
            var form = new bind("#tb_form",<%=jsonStr%>);
            form.form();
            form.bindform();
            $("#btn_Insert").click(function () {
                var data = form.getformdata();
                if (form.valid()) {
                    $.AjaxPost(url.ajaxUrl + 'add', false, JSON.stringify(data));
                }
            });
        });
    </script>
</asp:Content>
