<%@ Page Title="" Language="C#" MasterPageFile="../../Admin.Master" AutoEventWireup="true" CodeBehind="RolePermission.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Account.Role.RolePermission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="系统安全 > 角色权限" />
    <div>
        <div class="row">


            <div class="widget">
                <div class="widget-header">
                    <i class="icon-file"></i>
                    <h3>角色</h3>
                </div>
                <div class="widget-content">
                    <div class="bs-docs-sidebar">

                        <ul class="nav nav-pills  repeater">
                            <asp:Repeater ID="rep_roles" runat="server">
                                <ItemTemplate>
                                    <li id="li_<%#Eval("RoleID") %>" data-roleid="<%#Eval("RoleID") %>">
                                        <a href="?roleid=<%#Eval("RoleID") %>"><%#Eval("RoleName") %>[<%#Eval("RoleID") %>]</a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>


                        </ul>
                    </div>
                </div>
            </div>


            <div class="widget">
                <div class="widget-header">
                    <i class="icon-bookmark"></i>
                    <h3 id="p_title">角色授权</h3>
                </div>
                <div class="widget-content">
                    <EDNFramework:Messagebox ID="Messagebox3" runat="server" />
                    <ul class="nav nav-tabs">
                        <li class="active"><a href="#user" data-toggle="tab">角色成员</a></li>
                        <li><a href="#Permission" data-toggle="tab">模块权限</a></li>
                        <%--<li><a href="#PermissionButton" data-toggle="tab">权限按钮</a></li>--%>
                    </ul>

                    <div class="tab-content">

                        <div class="tab-pane active form-horizontal" id="user">
                            <fieldset>
                                <div id="grid_user" class="tab-content action-table ">
                                </div>
                                <EDNFramework:Messagebox ID="Messagebox4" runat="server" />
                                <div class="footer-actions taab-pane">
                                    <a href="javascript:void(0);" id="AddMember" class="btn">
                                        <i class="icon-plus-sign"></i>
                                        <span>添加成员</span>
                                    </a>
                                </div>
                            </fieldset>
                        </div>
                        <div class="tab-pane form-horizontal" id="Permission">
                            <fieldset>
                                <table class="table table-striped table-bordered table-hover">
                                    <thead>
                                        <tr>
                                            <th style="width: 200px;">权限名</th>
                                            <th style="width: 250px;">权限码</th>
                                            <th style="width: 90px;">权限类别</th>
                                            <th style="width: 250px;">请求地址</th>
                                            <th>描述</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td data-id="1">
                                                <label class="checkbox inline">
                                                    <input type="checkbox" value="" id="chekcAll" />选择全部</label></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <%=html_permission%>
                                    </tbody>
                                </table>
                                <EDNFramework:Messagebox ID="Messagebox1" runat="server" />
                                <div style="height: 20px;">
                                </div>
                                <div class="footer-actions taab-pane">
                                    <a href="javascript:void(0);" id="btn_save" class="btn">
                                        <i class="icon-plus-sign"></i>
                                        <span>授权</span>
                                    </a>
                                </div>
                            </fieldset>
                        </div>
                        <div class="tab-pane form-horizontal" id="PermissionButton">
                            <fieldset>
                                <iframe width="100%" height="465" frameborder="0" style="display: block;" scrolling="auto" id="frame_permission_button" name="frame_permission_button" src=""></iframe>
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
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script>

        $(document).ready(function () {
            PageModel.Init();
        });

        var selectedRole = -1;
        var roleId = '<%=Request["roleid"]%>';
        var currentUser = <%=DotNet.Framework.Admin.Core.Entity.BusEntity_LoginUser.Sys_LoginUser.UserID%>;
        var PageModel = {
            GridID_User: '#grid_user',
            AjaxSource_User: '?ajax=getlistbyroleid',
            Init: function () {
                //绑定左侧 角色列表
                this.RoleListClick();

               var _self = this;
                
                //授权按钮
                $("#btn_save").click(function () {
                    PageModel.Impower();
                });

                $("#chekcAll").click(function () {
                    var allchecked = $(this).is(':checked');
                    $('input[name="ckPermission"]').each(function () {
                        $(this).attr("checked", allchecked);
                    });


                });

                $('input[name="ckPermission"]').each(function () {
                    $(this).click(function () {
                        var data_this = $.trim($(this).attr("data-this"));
                        var data_parent = $.trim($(this).attr("data-parent"));
                        var data_checked = $(this).is(':checked');
                        $('input[name="ckPermission"]').each(function () {
                            var p = $.trim($(this).attr("data-parent"));
                            var t = $.trim($(this).attr("data-this"));
                            if (p == data_this) {
                                $(this).attr("checked", data_checked);
                            }
                            if (t == data_parent) {
                                if (data_checked == true) {
                                    $(this).attr("checked", true);
                                }
                            }

                        });


                    });
                });

                $("#AddMember").click(function(){
                    $.RemoteDialog("添加成员", "<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Account/Role/AddMember.aspx?rid="+roleId, {
                         height: 520,
                         width: 600,
                         //buttons: {
                         //    '关闭': function () {
                         //        $(this).dialog("close");
                         //    }
                         //},
                         close: function () {
                             pqGridRefresh(_self.GridID_User);
                         }
                     });
                 });
            },
           
            Impower: function () {
                var data = {};
                $('input[name="ckPermission"]:checked').each(function (i) {
                    data[i] = $.trim($(this).val());
                });

                $.AjaxPost('?ajax=impower', true, { pcodes: JSON.stringify(data), roleid: roleId });

            },
            RoleListClick: function () {
                _self = this;


                if (roleId && roleId != "" && Number(roleId) > 0) {
                    $("#li_" + roleId).addClass("active");
                    var roleName = $("#li_" + roleId).text();
                    $("#p_title").text("角色授权 - " + roleName);
                    $("#modal_rolename").text(roleName);

                    PageModel.BindUserByRole(roleId);
                }
                else {
                    $.Alert("请从选择需要操作的角色。");
                }
                //$(".nav-stacked li").click(function () {

                //    if (selectedRole != -1) {
                //        $("#frame_permission_user").attr("src", "role_permission_user.aspx?roleid=" + selectedRole);
                //        $("#frame_permission_domain").attr("src", "role_permission_domain.aspx?roleid=" + selectedRole);
                //        $("#frame_permission_button").attr("src", "role_permission_button.aspx?roleid=" + selectedRole);
                //        ////绑定当前角色下用户列表
                //        //_self.BindUserByRole();
                //        ////绑定当前角色下模块权限列表
                //        //_self.BindPermissionByRole();
                //        ////绑定当前角色下权限按钮列表
                //        //_self.BindPermissionActionButtonByRole();
                //    }
                //});
            },
            RemoveUserFromRole:function(id){
                if ($.confirm("确定要移除吗？")) {
                    var paramData = {
                        roleid:roleId,
                        uid: id
                    };
                    $.AjaxPostCall('?ajax=RemoveUserFromRole', true, paramData, function (data) {
                        pqGridRefresh(PageModel.GridID_User);
                    });
                   
                }
            },
            BindUserByRole: function () {
                var _self = this;
                //url：请求地址
                var url = PageModel.AjaxSource_User + "&roleid=" + selectedRole;
                //colM：表头名称
                var colM = [
                    //{ title: "编号", width: 60, dataIndx: "UserID" },
                    {
                        title: "移除", width: 60,dataIndx:"UserName",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            if (rowData["UserID"] == PageModel.currentUser) {
                                return "";
                            }
                            else
                                return "<a class='label label-warning icon-remove btn' href='javascript:void(0);' onclick='PageModel.RemoveUserFromRole(" + rowData["UserID"] + ")'>移除</a>";
                        }
                    },
                    { title: "登录名", width: 100, dataIndx: "UserName" },
                    { title: "昵称", width: 100, dataIndx: "NickName" },
                    {
                        title: "部门", width: 100,
                        dataIndx: "U.DepartmentID",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            var data = $.trim(rowData["DepartmentName"]);

                            return data;
                        }
                    },
                    {
                        title: "账号类型", width: 90,
                        dataIndx: "U.UserType",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            var data = $.trim(rowData["UserTypeName"]);

                            return data;
                        }
                    },
                    { title: "性别", width: 60, dataIndx: "Sex" },
                    { title: "电话", width: 100, dataIndx: "U.Phone",
                        render:function(ui)
                        {
                            var data = ui.rowData;
                            return data["Phone"];
                        }
                    },
                    { title: "邮件", width: 180, dataIndx: "Email" },
                    {
                        title: "激活", width: 70,
                        dataIndx: "Activity",
                        render: function (ui) {
                            var rowData = ui.rowData;
                            var data = $.trim(rowData["Activity"]);
                            var html = "";
                            if (data == 'false') {
                                return "<img src='../../../Resource/Images/checknomark.gif'/>";
                            }
                            else {
                                return "<img src='../../../Resource/Images/checkmark.gif'/>";
                            }
                            return html;
                        }
                    }
                ];

                PQLoadGrid("U.UserID",_self.GridID_User , url, colM, 20, false,{RoleID:roleId});
                $(_self.GridID_User).pqGrid({
                    freezeCols: 4,
                    title: "<i class=\"icon-cog\"></i>&nbsp;用户管理"
                })

            }
            

            
            

        };
    </script>
</asp:Content>
