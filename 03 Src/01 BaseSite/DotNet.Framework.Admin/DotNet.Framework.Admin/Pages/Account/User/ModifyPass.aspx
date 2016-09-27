<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin.Master" AutoEventWireup="true" CodeBehind="ModifyPass.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Account.User.ModifyPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <div class="container">
        <div class="widget">
            <div class="widget-header">
                <i class="icon-user"></i>
                <h3>修改密码</h3>
            </div>
            <div class="widget-content">
                <div class="tab-content">
                    <div class="tab-pane active form-horizontal" id="info">
                        <div class="control-group">
                            <label class="control-label" for="Password">旧密码：</label>
                            <div class="controls">
                                <input type="password" class="input-medium" id="Password" name="Password" />
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane active form-horizontal" id="Div1">
                        <div class="control-group">
                            <label class="control-label" for="Password_new">新密码：</label>
                            <div class="controls">
                                <input type="password" class="input-medium" id="Password_new" name="Password_new" />
                            </div>
                        </div>
                    </div>
                    <div class="tab-pane active form-horizontal" id="Div2">
                        <div class="control-group">
                            <label class="control-label" for="Password_new2">重新输入：</label>
                            <div class="controls">
                                <input type="password" class="input-medium" id="Password_new2" name="Password_new2" />
                                <p class="help-block">再一次输入新密码，两次密码保持一致。</p>
                            </div>
                        </div>
                    </div>
                    <EDNFramework:Messagebox ID="Messagebox1" runat="server" />

                    <div class="form-actions taab-pane">
                        <input type="button" id="btn_Save" class="btn btn-primary btn-loading " value="保存" />
                        <input type="reset" class="btn" value="取消" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
</asp:Content>
