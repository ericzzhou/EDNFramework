﻿<%@ Page Title="" Language="C#" MasterPageFile="../../Admin.Master" AutoEventWireup="true" CodeBehind="RolePermission.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Account.Role.RolePermission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="系统安全 > 角色权限" />
    <div class="row">
        <div class="span0.5" style="background-color: red; height: 50px;">
        </div>
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
        <div class="span12">
            <div class="widget">
                <div class="widget-header">
                    <i class="icon-bookmark"></i>
                    <h3 id="p_title">角色授权</h3>
                </div>
                <div class="widget-content">
                    <ul class="nav nav-tabs">
                        <li class="active"><a href="#user" data-toggle="tab">角色成员</a></li>
                        <li><a href="#Permission" data-toggle="tab">模块权限</a></li>
                        <%--<li><a href="#PermissionButton" data-toggle="tab">权限按钮</a></li>--%>
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

        $(document).ready(function () {
            PageModel.Init();
        });

        var selectedRole = -1;
        var PageModel = {
            GridID_User: '#grid_user',
            AjaxSource_User: '?ajax=getuser',
            AjaxSource_AddMembers: '?ajax=getnotmembers',
            AjaxSource_SaveMembers: '?ajax=savemembers',
            modal_AddMembers: "#modal_AddMembers",
            Init: function () {
                //绑定左侧 角色列表
                this.RoleListClick();

                _self = this;
                $(".btn-modal-close").click(function () {
                    _self.ClearData();
                    $(_self.modal_AddMembers).modal('hide');
                    pqGridRefresh(_self.GridID_User);
                    $.HideMessage();
                });
                //保存
                $(".btn-modal-save").click(function () {
                    _self.SaveMembers();
                });
            },
            ClearData: function () {
                //清除弹窗数据
            },
            RoleListClick: function () {
                _self = this;
                $(".nav-stacked li").click(function () {
                    //取消 class=active
                    $(".nav-stacked li").removeClass("active");
                    //给当前LI添加 class=active
                    $(this).addClass("active");

                    selectedRole = $(this).attr("data-roleid");
                    var roleName = $(this).text();

                    $("#p_title").text("角色授权 - " + roleName);
                    $("#modal_rolename").text(roleName);
                    if (selectedRole != -1) {
                        $("#frame_permission_user").attr("src", "role_permission_user.aspx?roleid=" + selectedRole);
                        $("#frame_permission_domain").attr("src", "role_permission_domain.aspx?roleid=" + selectedRole);
                        $("#frame_permission_button").attr("src", "role_permission_button.aspx?roleid=" + selectedRole);
                        ////绑定当前角色下用户列表
                        //_self.BindUserByRole();
                        ////绑定当前角色下模块权限列表
                        //_self.BindPermissionByRole();
                        ////绑定当前角色下权限按钮列表
                        //_self.BindPermissionActionButtonByRole();
                    } else {
                        $.Alert("很抱歉，请先选择要操作的角色！");
                    }
                });
            },
            BindUserByRole: function () {
                //url：请求地址
                var url = PageModel.AjaxSource_User + "&roleid=" + selectedRole;
                //colM：表头名称
                var colM = [
                    { title: "编号", width: 60, dataIndx: "UserID" },
                    { title: "登录名", width: 100, dataIndx: "UserName" },
                    { title: "昵称", width: 100, dataIndx: "NickName" },
                    { title: "性别", width: 60, dataIndx: "Sex" },
                    { title: "电话", width: 100, dataIndx: "Phone" },
                    { title: "邮件", width: 180, dataIndx: "Email" }

                ];
                PQLoadGridNoPage("UserID", PageModel.GridID_User, url, colM);
                $(PageModel.GridID_User).pqGrid({
                    freezeCols: 2,
                    title: "<i class=\"icon-cog\"></i>&nbsp;角色成员列表"
                })

            },
            BindPermissionByRole: function () {

            },
            BindPermissionActionButtonByRole: function () {

            },
            ToolsBar_Fun_Leave: function () {
                history.go(-1);
            },
            SetModalTitle: function (ModalID, title) {
                $(ModalID + " h3").html(title);
            },

            AddMembers: function () {
                if (this.CheckSelectedRole()) {
                    this.SetModalTitle(this.modal_AddMembers, "添加成员到角色");
                    /*
                    1、列出当前选中角色不包含的用户列表 JSON.stringify
                    */
                    $.AjaxPostCall(this.AjaxSource_AddMembers, true, { roleid: selectedRole }, function (data) {
                        var html = "";
                        if (data) {
                            for (var i = 0; i < data.length; i++) {
                                var u = data[i];
                                html += "<span class='span1'><label>";
                                html += "<input type=\"checkbox\" value=\"" + $.trim(u.UserID) + "\" class='checkbox inline' />" + $.trim(u.UserName) + "(" + $.trim(u.Sex) + ")";
                                html += "</label></span>";
                            }
                        }
                        $("#AddMembers_users").html(html);
                    });
                    $(this.modal_AddMembers).modal('show');
                }
            },
            SaveMembers: function () {
                if (this.CheckSelectedRole()) {
                    //($("#AddMembers_users input[type='checkbox']:checked")[0].value
                    var u_id = [];
                    $("#AddMembers_users input[type='checkbox']:checked").each(function (i) {
                        u_id[i] = $(this).val();
                    });
                    if (u_id.length > 0) {
                        var uids = '';
                        for (var i = 0; i < u_id.length; i++) {
                            if (i > 0) {
                                uids += ',';
                            }
                            uids += u_id[i];
                        }
                        $.AjaxPost(this.AjaxSource_SaveMembers, true, { roleid: selectedRole, uids: uids });
                        pqGridRefresh(this.GridID_User);
                    }
                    else {
                        $.Alert("没有选择要添加到当前角色的成员。");
                    }
                }
            },
            DeleteMembers: function () {

            },
            CheckSelectedRole: function () {
                if (selectedRole == -1) {
                    $.Alert("很抱歉，请先选择要操作的角色！");
                    return false;
                }
                else {
                    return true;
                }
            }

        };
    </script>
</asp:Content>
