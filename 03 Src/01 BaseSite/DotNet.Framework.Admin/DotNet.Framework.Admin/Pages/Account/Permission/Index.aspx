<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Account.Permission.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Libs/zTreeV3.5.14/css/zTreeStyle/zTreeStyle.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <div class="main-inner">
        <div class="container">
            <div class="row">
                <div class="span4">
                    <div class="widget">
                        <div class="widget-header">
                            <i class="icon-file"></i>
                            <h3>权限树</h3>
                            <%--<input type="button" class="btn btn-add" value="添加" />
                            <input type="button" class="btn btn-clear" value="重置" />--%>
                        </div>
                        <div class="widget-content">

                            <EDNFramework:ToolsBar ID="ToolsBar" runat="server" Insert_Fun="PageModel.AddControl()" Clear_Fun="PageModel.ClearControl()" disable_Detail="true" disable_Delete="True" disable_Modify="True" />

                            <div>
                                <table border="0" height="470px" align="left">
                                    <tr>
                                        <td align="left" valign="top">
                                            <ul id="tree" class="ztree" style="overflow: auto;"></ul>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="span8">
                    <div class="widget">
                        <div class="widget-header">
                            <i class="icon-bookmark"></i>
                            <h3>权限维护</h3>
                        </div>
                        <div class="widget-content">
                            <div class="tab-pane active form-horizontal" id="info">
                                <div class="control-group">
                                    <label class="control-label" for="CategoryID">权限类别</label>
                                    <div class="controls">
                                        <input type="hidden" id="ID" name="ID" />
                                        <select id="CategoryID">
                                        </select>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="ParentName">上级权限</label>
                                    <div class="controls">
                                        <input type="hidden" class="input-medium" id="ParentID" name="ParentID" />
                                        <input type="text" class="input-medium" id="ParentName" name="ParentName" disabled="disabled" />
                                        <a href="javascript:;" id="parent_select">选择</a>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="PermissionCode">权限码</label>
                                    <div class="controls">
                                        <input type="text" class="input-medium" id="PermissionCode" name="PermissionCode" />
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="PermissionName">权限名</label>
                                    <div class="controls">
                                        <div class="textarea">
                                            <input type="text" class="input-medium" id="PermissionName" name="PermissionName" />
                                        </div>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="Sequence">权重</label>
                                    <div class="controls">
                                        <div class="textarea">
                                            <input type="text" class="input-medium" id="Sequence" name="Sequence" value="0" />
                                        </div>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label" for="RequestUrl">请求地址</label>
                                    <div class="controls">
                                        <div class="textarea">
                                            <input type="text" class="input-medium" id="RequestUrl" name="RequestUrl" />
                                        </div>
                                    </div>
                                </div>
                                <div class="control-group">
                                    <label class="control-label">描述</label>
                                    <div class="controls">
                                        <div class="textarea">
                                            <textarea class="" id="Description" name="Description"> </textarea>
                                            <p class="help-block">描述250字符以内</p>
                                        </div>
                                    </div>
                                </div>
                                <EDNFramework:Messagebox ID="Messagebox1" runat="server" />
                                <div class="form-actions taab-pane">

                                    <input type="button" class="btn btn-modal-reset" value="重置" />
                                    <input type="button" value="保存" class="btn btn-primary btn-modal-save" disabled="disabled" style="display: none;" />
                                    &nbsp;&nbsp;&nbsp;
                                    <input type="button" class="btn btn-modal-delete" value="删除" style="display: none;" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="menuContent" class="menuContent" style="display: none; position: absolute;">
        <ul id="treemenu" class="ztree" style="margin-top: 0; width: 160px;"></ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Libs/zTreeV3.5.14/js/jquery.ztree.core-3.5.min.js"></script>
</asp:Content>
