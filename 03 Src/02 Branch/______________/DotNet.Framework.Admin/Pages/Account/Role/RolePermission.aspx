<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin.Master" AutoEventWireup="true" CodeBehind="RolePermission.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Account.Role.RolePermission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="系统安全 > 角色权限" />
   
        <div class="span3">
            <div class="widget">
                <div class="widget-header">
                    <i class="icon-file"></i>
                    <h3>角色</h3>
                </div>
                <div class="widget-content">
                    <div class="bs-docs-sidebar" style="height: 510px; overflow-Y: scroll">

                        <ul class="nav nav-pills nav-stacked">
                            <%-- <ul class=" nav nav-list bs-docs-sidenav affix">
                                    <li class="active">
                                            <a href="javascript:void(0);">超级管理员</a>
                                        </li>
                            --%>
                            <asp:Repeater ID="rep_roles" runat="server">
                                <ItemTemplate>
                                    <li data-roleid="<%#Eval("RoleID") %>">
                                        <a href="javascript:void(0);"><%#Eval("RoleName") %>[<%#Eval("RoleID") %>]</a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>


                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div id="div_input">
            <div class="widget">
                <div class="widget-header">
                    <i class="icon-bookmark"></i>
                    <h3 id="p_title">角色授权</h3>
                </div>
                <div class="widget-content">
                    <ul class="nav nav-tabs">
                        <li class="active"><a href="#user" data-toggle="tab">角色成员</a></li>
                        <li><a href="#Permission" data-toggle="tab">模块权限</a></li>
                        <li><a href="#PermissionButton" data-toggle="tab">权限按钮</a></li>
                    </ul>

                    <div class="tab-content" style="height: 465px;">

                        <div class="tab-pane active form-horizontal" id="user">
                            <fieldset>
                                <iframe width="100%" height="465" frameborder="0" style="display: block;" id="frame_permission_user" name="frame_permission_user" src=""></iframe>
                            </fieldset>
                        </div>
                        <div class="tab-pane form-horizontal" id="Permission">
                            <fieldset>
                                <iframe width="100%" height="465" frameborder="0" style="display: block;" id="frame_permission_domain" name="frame_permission_domain" src=""></iframe>
                            </fieldset>
                        </div>
                        <div class="tab-pane form-horizontal" id="PermissionButton">
                            <fieldset>
                                <iframe width="100%" height="465" frameborder="0" style="display: block;" id="frame_permission_button" name="frame_permission_button" src=""></iframe>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    
    <div class="modal hide fade" id="modal_AddMembers">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h3>对话框标题</h3>
        </div>
        <div class="modal-body">
            <div class="tab-content">
                <div class="tab-pane active form-horizontal" id="info">
                    <div class="alert alert-info">
                        <b><span id="modal_rolename">系统管理员（1）</span>；想拥有成员（请点击勾选）</b>
                    </div>
                    <div id="AddMembers_users">
                    </div>
                </div>
                <EDNFramework:Messagebox ID="Messagebox2" runat="server" />

            </div>
        </div>
        <div class="modal-footer">

            <input type="button" class="btn btn-modal-close" value="关闭" />
            <input type="button" value="保存" class="btn btn-primary btn-modal-save" />

        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
            <script>
                $(function () {
                    $("#div_input").css({ width: document.body.clientWidth - 240 + "px", float: "right" });
                    $(window).resize(function () {
                        $("#div_input").css({ width: document.body.clientWidth - 240 + "px", float: "right" });
                    })
                });

    </script>

</asp:Content>
