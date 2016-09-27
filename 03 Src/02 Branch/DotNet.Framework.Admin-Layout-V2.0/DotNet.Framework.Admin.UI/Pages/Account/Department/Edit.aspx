<%@ Page Title="" Language="C#" MasterPageFile="../../Dialog.Master" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Account.Department.Edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="tab-content">
        <div class="tab-pane active form-horizontal bind-valid" id="tb_Form">
            <div class="control-group">
                <label class="control-label" for="Name">部门名称</label>
                <div class="controls">
                    <input type="hidden" id="ID" name="ID" />
                    <input type="text" class="input-medium require" id="Name" name="Name" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="ShortName">部门短名</label>
                <div class="controls">
                    <input type="text" class="input-medium require" id="ShortName" name="ShortName" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="Phone">部门电话</label>
                <div class="controls">
                    <input type="text" class="input-medium" id="Phone" name="Phone" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="ExtNumber">分机号码</label>
                <div class="controls">
                    <input type="text" class="input-medium" id="ExtNumber" name="ExtNumber" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="Fax">传真</label>
                <div class="controls">
                    <input type="text" class="input-medium" id="Fax" name="Fax" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label">状态</label>
                <div class="controls">
                    <label class="checkbox inline">
                        <input type="checkbox" id="Status" name="Status" checked="checked" />激活
                    </label>
                </div>
            </div>

            <div class="control-group">
                <label class="control-label" for="Description">描述</label>
                <div class="controls">
                    <textarea id="Description" rows="5" name="Description"></textarea>
                </div>
            </div>

        </div>

        <EDNFramework:Messagebox ID="Messagebox1" runat="server" />

        <div class="footer-actions taab-pane" id="footer" style="text-align: center;">
            <input type="button" id="btn_edit" class="btn btn-primary btn-loading " value="保存" />
           <%-- <input type="reset" class="btn" value="重置" />--%>
            <%--<input type="button" id="Button1" class="btn " onclick="test()" value="关闭" />--%>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script>
        $(function () {
            var pm = new pageModel("#tb_Form", <%=Json_Model%>);
            pm.bind();
            
            pm.submit();
        });

        function test()
        {
            //ui-dialog
            var par = $(window.parent.document.body).find("body").find(".ui-dialog");
            alert(par).html();

        }
        
        function pageModel(formId, formData) {
            this.formId = formId;
            this.formData = formData;
            var form = new bind(this.formId, formData);
            this.bind = function () {
                form.form();
                form.bindform();
            };


            this.submit = function () {
                $("#btn_edit").click(function () {
                    if (form.valid()) {
                        var data = JSON.stringify(form.getformdata());
                        $.AjaxPost('?ajax=edit', true, data);
                    }
                    else
                        $.alert("验证失败，请检查必填项。");
                });
            };
        };
    </script>
</asp:Content>
