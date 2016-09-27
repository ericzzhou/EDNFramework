<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Dialog.Master" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Account.Department.Add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="tab-content">
        <div class="tab-pane active form-horizontal" id="info">
            <div class="control-group">
                <label class="control-label" for="Name">部门名称</label>
                <div class="controls">
                    <input type="text" class="input-medium" id="Name" name="Name" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="ShortName">部门短名</label>
                <div class="controls">
                    <input type="text" class="input-medium" id="ShortName" name="ShortName" />
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

        <div class="form-actions taab-pane" style="text-align: right;">
            <input type="button" id="btn_Insert" class="btn btn-primary btn-loading " value="保存" />
            <input type="reset" class="btn" value="重置" />
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
</asp:Content>
