<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin.Master" AutoEventWireup="true" CodeBehind="ModifyInfo.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Account.User.ModifyInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <div class="container">
        <div class="widget">
            <div class="widget-header">
                <i class="icon-user"></i>
                <h3>编辑资料</h3>
            </div>
            <div class="widget-content">
                <div class="tab-content">
                    <div class="tab-pane active form-horizontal" id="info">
                        <div class="control-group">
                            <label class="control-label" for="NickName">昵称</label>
                            <div class="controls">
                                <input type="text" class="input-medium" id="NickName" name="NickName" />
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
