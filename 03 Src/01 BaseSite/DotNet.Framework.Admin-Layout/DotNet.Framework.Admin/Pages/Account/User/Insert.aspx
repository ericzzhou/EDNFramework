<%@ Page Title="" Language="C#" MasterPageFile="../../Dialog.Master" AutoEventWireup="true" CodeBehind="Insert.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Account.User.Insert" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">

    <div class="tab-content">
        <div class="tab-pane active form-horizontal" id="info">
            <div class="control-group">
                <label class="control-label" for="UserType">账号类型</label>
                <div class="controls">
                    <select id="UserType">
                        <option value="">请选择</option>
                        <option value="AA">管理员</option>
                        <option value="UU">普通用户</option>
                    </select>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="DepartmentID">所属部门</label>
                <div class="controls">
                    <select id="DepartmentID">
                        <option value="">请选择</option>
                    </select>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="NickName">昵称</label>
                <div class="controls">
                    <input type="text" class="input-medium" id="NickName" name="NickName" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="UserName">用户名</label>
                <div class="controls">
                    <input type="text" class="input-medium" id="UserName" name="UserName" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="Password">密码</label>
                <div class="controls">
                    <input type="password" class="input-medium" id="Password" name="Password" disabled="disabled" value="*******" />
                    <p class="help-block">系统配置默认密码</p>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label">性别</label>
                <div class="controls">
                    <label class="radio inline">
                        <input value="男" type="radio" id="man" name="Sex" />男
                    </label>
                    <label class="radio inline">
                        <input value="女" type="radio" id="woman" name="Sex" />女
                    </label>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label">状态</label>
                <div class="controls">
                    <label class="checkbox inline">
                        <input type="checkbox" id="Activity" name="Activity" />激活
                    </label>
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="Phone">电话</label>
                <div class="controls">
                    <input type="text" class="input-medium" id="Phone" name="Phone" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="Email">Email</label>
                <div class="controls">
                    <input type="text" class="input-medium" id="Email" name="Email" />
                </div>
            </div>

        </div>

        <EDNFramework:Messagebox ID="Messagebox1" runat="server" />

        <div class="footer-actions taab-pane" id="footer" >
            <input type="button" id="btn_Insert" class="btn btn-primary btn-loading " value="保存" />
            <input type="reset" class="btn" value="重置" />
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script>
        $(function () {
            PageModel.Init();
        });

        var PageModel = {
            data: {},
            LoadData: function () {
                _self = this;

                _self.data.UserType = $("#UserType").val();
                _self.data.NickName = $("#NickName").val();
                _self.data.Activity = $("#Activity").is(':checked');
                _self.data.Sex = $('input[name="Sex"]:checked').val();
                _self.data.UserName = $("#UserName").val();
                _self.data.Phone = $("#Phone").val();
                _self.data.Email = $("#Email").val();
                _self.data.DepartmentID = $("#DepartmentID").val();
            },
            Init: function () {
                _self = this;

                $.AjaxGet("default.aspx?ajax=getdepartment", false, {}, function (data) {
                    for (var i = 0; i < data.length; i++) {
                        var item = eval(data[i]);

                        $("#DepartmentID").append("<option value=\"" + item.ID + "\">" + item.Name + "</option>")

                    }
                    $.RemoveButtonLoading();
                    $.RemoveBodyLoading();
                });


                $("#btn_Insert").click(function () {
                    _self.LoadData();
                    $.AjaxPost('?ajax=adddata', true, _self.data);

                });
            }
        };
    </script>
</asp:Content>
