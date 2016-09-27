<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Dialog.Master" AutoEventWireup="true" CodeBehind="edit.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Norm.Category.edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Libs/zTreeV3.5.14/css/zTreeStyle/zTreeStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="tab-content">
        <div class="tab-pane active form-horizontal" id="info">
            <div class="control-group">
                <label class="control-label" for="lastname">上级分类</label>
                <div class="controls">
                    <input type="hidden" value="<%=Request["id"] %>" id="ID" name="ID" />
                    <input type="hidden" class="input-medium" id="ParentID" name="ParentID" />
                    <input type="text" class="input-medium" id="ParentName" name="ParentName" disabled="disabled" />
                    <a href="javascript:;" id="parent_select">选择</a>

                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="CategoryName">分类名称</label>
                <div class="controls">
                    <input type="text" class="input-medium" id="CategoryName" name="CategoryName" />
                </div>
            </div>
            <div class="control-group">
                <label class="control-label" for="CategoryCode">简码</label>
                <div class="controls">
                    <input type="text" class="input-medium" id="CategoryCode" name="CategoryCode" />
                </div>
            </div>


        </div>

        <EDNFramework:Messagebox ID="Messagebox1" runat="server" />

        <div class="form-actions taab-pane" style="text-align: right;">
            <input type="button" id="btn_Insert" class="btn btn-primary btn-loading " value="保存" />
            <input type="reset" class="btn" value="重置" />
        </div>
    </div>
    <div id="menuContent" class="menuContent" style="display: none; position: absolute;">
        <ul id="treemenu" class="ztree" style="margin-top: 0; width: 160px;"></ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Libs/zTreeV3.5.14/js/jquery.ztree.core-3.5.min.js"></script>
</asp:Content>
