<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin.Master" AutoEventWireup="true" CodeBehind="RolePermission.aspx.cs" Inherits="DotNet.Framework.Admin.WebUI.Pages.Account.Role.RolePermission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PH_Head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="PH_TreeMenu" runat="server">
    <%-- <EDNFramework:TreeMenu ID="Treemenu1" runat="server" Menu="41" />--%>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="PH_SiteMapPath" runat="server">
    <li>系统安全</li>
    <li>角色权限</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="PH_Body" runat="server">
    <div class="inbox-nav-bar no-content-padding">

        <h1 class="page-title txt-color-blueDark hidden-tablet"><i class="fa fa-fw fa-inbox"></i>系统角色 &nbsp;
		    <div class="btn-group">
                <a href="#" data-toggle="dropdown" class="btn btn-default btn-xs dropdown-toggle"><span class="caret single"></span></a>
                <ul class="dropdown-menu">
                    <li>
                        <a href="javascript:void(0);">新增</a>
                    </li>
                    <li>
                        <a href="javascript:void(0);">删除</a>
                    </li>
                    <li class="divider"></li>
                </ul>
            </div>
        </h1>
        <%--<div class="inbox-checkbox-triggered">

            <div class="btn-group">
                <a href="javascript:void(0);" onclick="PageModel.AddControl();" rel="tooltip" title="" data-placement="bottom" data-original-title="添加" class="btn btn-default"><strong><i class="fa fa-plus fa-lg text-danger"></i></strong></a>
                <a href="javascript:void(0);" rel="tooltip" title="" data-placement="bottom" data-original-title="保存" class="btn btn-default"><strong><i class="fa fa-save fa-lg"></i></strong></a>
                <a href="javascript:void(0);" rel="tooltip" title="" data-placement="bottom" data-original-title="删除" class="btn btn-default btn-modal-delete"><strong><i class="fa fa-trash-o fa-lg"></i></strong></a>
            </div>

        </div>--%>


        <%--<div class="btn-group pull-right inbox-paging">
            <a href="javascript:void(0);" class="btn btn-default btn-sm"><strong><i class="fa fa-chevron-left"></i></strong></a>
            <a href="javascript:void(0);" class="btn btn-default btn-sm"><strong><i class="fa fa-chevron-right"></i></strong></a>
        </div>
        <span class="pull-right"><strong>1-30</strong> of <strong>3,452</strong></span>--%>
    </div>

    <div id="inbox-content" class="inbox-body no-content-padding">
        <EDNFramework:Messagebox ID="Messagebox1" runat="server" />
        <div class="inbox-side-bar">


            <h6>系统角色 <a href="javascript:void(0);" rel="tooltip" title="" data-placement="role" data-original-title="刷新" class="pull-right txt-color-darken"><i class="fa fa-refresh"></i></a></h6>

            <ul class="inbox-menu-lg" id="ul_role">
                <%--<li class="active">
                    <a href="javascript:void(0);">Inbox (14) </a>
                </li>
                <li>
                    <a href="javascript:void(0);">Sent</a>
                </li>
                <li>
                    <a href="javascript:void(0);">Draft</a>
                </li>
                <li>
                    <a href="javascript:void(0);">Trash</a>
                </li>--%>
            </ul>

        </div>
        <div class="table-wrap custom-scroll  fast " style="opacity: 1;">
            <div data-widget-sortable="false" data-widget-custombutton="false" data-widget-fullscreenbutton="false" data-widget-editbutton="false" id="wid-id-7" class="jarviswidget" style="" role="widget">
                <header role="heading">
                    <ul class="nav nav-tabs pull-left in">
                        <li class="">
                            <a href="#hr1" data-toggle="tab"><i class="fa fa-lg fa-arrow-circle-o-down"></i><span class="hidden-mobile hidden-tablet">角色成员 </span></a>
                        </li>
                        <li class="active">
                            <a href="#hr2" data-toggle="tab"><i class="fa fa-lg fa-arrow-circle-o-up"></i><span class="hidden-mobile hidden-tablet">模块权限 </span></a>
                        </li>
                        <li class="">
                            <a href="#hr3" data-toggle="tab"><i class="fa fa-lg fa-arrow-circle-o-up"></i><span class="hidden-mobile hidden-tablet">按钮权限 </span></a>
                        </li>
                    </ul>
                    <span class="jarviswidget-loader"><i class="fa fa-refresh fa-spin"></i></span>
                </header>

                <!-- widget div-->
                <div role="content">

                    <!-- widget edit box -->
                    <div class="jarviswidget-editbox">
                        <!-- This area used as dropdown edit box -->

                    </div>
                    <!-- end widget edit box -->

                    <!-- widget content -->
                    <div class="widget-body">

                        <div class="tab-content">
                            <div id="hr1" class="tab-pane ">
                                暂未实现

                            </div>
                            <div id="hr2" class="tab-pane active">
                                <table class="table table-striped table-bordered table-hover">
                                    <thead>
                                        <tr>
                                            <th style="">权限名</th>
                                            <th style="width: 100px;">权限类别</th>
                                            <th style="width: 300px;">请求地址</th>
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
                                        </tr>
                                        <%=HtmlPermission%>
                                    </tbody>
                                </table>
                                <EDNFramework:Messagebox ID="Messagebox2" runat="server" />
                                <div class="form-actions">
                                    <div class="row">
                                        <div class="col-md-12">
                                            
                                            <button class="btn btn-primary btn-modal-save " type="button">
                                                <i class="fa fa-save"></i>
                                                授权
                                            </button>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div id="hr3" class="tab-pane">
                                暂未实现
                            </div>
                        </div>


                    </div>
                    <!-- end widget content -->

                </div>
                <!-- end widget div -->

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="PH_Floor" runat="server">
    <script>
        var roleId = '<%=Request["role"]%>';
        $(function () {
            PageModel.Init();
        });
        var PageModel = {
            Init: function () {
                this.LoadRoles();
                this.AppendEvent();
                this.SetControlStatus();
            },
            SetControlStatus: function () {
                if ($.trim(roleId) == '') {
                    $(".btn-modal-save").addClass("disabled");
                }
            },
            LoadRoles: function () {
                $("#ul_role").empty();
                var menuid = '<%=Request["menuid"]%>';

                $.AjaxGet('/ajax/account/role.ashx?ajax=loadrole', false, {}, function (data) {
                    //$.RemoveButtonLoading();
                    //$.RemoveBodyLoading();
                    for (var i = 0; i < data.length; i++) {
                        var item = data[i];
                        var html = '<li';
                        if (item.RoleID == roleId) {
                            html += ' class="active" ';
                        }
                        html += '><a href="?menuid=' + menuid + '&role=' + item.RoleID + '">' + item.RoleName + '</a></li>';
                        $("#ul_role").append(html);
                    }
                });
            },
            AppendEvent: function () {
                var _self = this;
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
                    //$(this).change(function () {
                    //    alert("changed");
                    //    var data_this = $.trim($(this).attr("data-this"));
                    //    var data_parent = $.trim($(this).attr("data-parent"));
                    //    var data_checked = $(this).is(':checked');
                    //    $('input[name="ckPermission"]').each(function () {
                    //        var p = $.trim($(this).attr("data-parent"));
                    //        var t = $.trim($(this).attr("data-this"));
                    //        if (p == data_this) {
                    //            $(this).attr("checked", data_checked);
                    //        }
                    //        if (t == data_parent) {
                    //            if (data_checked == true) {
                    //                $(this).attr("checked", true);
                    //            }
                    //        }

                    //    });
                    //});
                });

                //授权按钮
                $(".btn-modal-save").click(function () {
                    _self.Impower();
                });
            },
            Impower: function () {
                if (roleId == "") {
                    $.Alert("请选择需要操作的角色。");
                    return;
                }
                var data = {};
                $('input[name="ckPermission"]:checked').each(function (i) {
                    data[i] = $.trim($(this).val());
                });

                $.AjaxPost('/ajax/account/role.ashx?ajax=impower', false, { pcodes: JSON.stringify(data), roleid: roleId });

            }
        };
    </script>
</asp:Content>
