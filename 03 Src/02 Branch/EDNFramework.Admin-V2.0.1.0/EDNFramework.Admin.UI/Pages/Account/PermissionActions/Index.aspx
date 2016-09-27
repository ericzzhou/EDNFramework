<%@ Page Title="" Language="C#" MasterPageFile="../../Dialog.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Account.PermissionActions.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <%--<EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="系统安全 > 权限按钮维护" />--%>
    <div class="tools_bar-inner">

        <a href="javascript:void(0);" class="btn" id="btn_add">
            <i class="icon-plus-sign"></i>
            <span>新增</span>
        </a>
    </div>
    <EDNFramework:Messagebox ID="Messagebox2" runat="server" />
   <%-- <hr />--%>
    

    <div id="grid_json" class="tab-content action-table">
        <%--<div class="input-prepend input-append"></div>--%>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script>
        $(document).ready(function () {
            PageModel.Init();

        });

        var url = {
            ajaxUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.AjaxPath%>/Account/PermissionActions.ashx?ajax='
            , AddUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Account/PermissionActions/Add.aspx?PermissionCode='
            , EditUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/Account/PermissionActions/Edit.aspx?ActionID='
        };
        var paramter = {
            PermissionCode: '<%=Request["PermissionCode"]%>'
        };

        var PageModel = {
            Init: function () {
                $("#btn_add").click(function () {
                    $.RemoteDialog("添加权限按钮", url.AddUrl + paramter.PermissionCode, {
                        height: 300,
                        width: 450,
                        close: function () {
                            PageModel.Bind();
                        }
                    });
                });

                PageModel.Bind();
            },
            Bind: function () {
                var d = { Condition: { PermissionCode: paramter.PermissionCode } };
                $.AjaxPostCall(url.ajaxUrl + 'getlist', false, JSON.stringify(d), function (data) {
                    var html = "<h3>暂无按钮信息<h3>";
                    if (data && typeof data != undefined && data != null && data.length > 0) {
                        html = "";
                       
                        for (var i = 0; i < data.length; i++) {
                            var item = data[i];
                            html += "<div class=\"input-prepend input-append \" style=\"float:left;padding-left:5px;\">";
                            html += "<div class=\"btn-group\">";
                            html += "<button class=\"btn dropdown-toggle\" data-toggle=\"dropdown\">";
                            html += item.Description;
                            html += "<span class=\"caret\"></span>";
                            html += "</button>";
                            html += "<ul class=\"dropdown-menu\">";
                            html += "<li><a href=\"javascript:;\" onclick=\"PageModel.Edit(" + item.ActionID + ")\"><i class=\"icon-pencil\"></i> 编辑</a></li>";
                            html += "<li><a href=\"javascript:;\" onclick=\"PageModel.Delete(" + item.ActionID + ")\"><i class=\"icon-trash\"></i> 删除</a></li>";
                            //html += "<li class=\"divider\"></li>";
                            //html += "<li><a href=\"#\"><i class=\"i\"></i> Make admin</a></li>";
                            html += "</ul>";
                            html += "</div>";
                            html += "</div>";
                           
                        }
                    }
                    html += "<div style=\"clear:both\"></div>";
                    
                    $("#grid_json").html(html);
                });
            },
            Edit: function (ActionID) {
                $.RemoteDialog("编辑权限按钮", url.EditUrl + ActionID, {
                    height: 300,
                    width: 450,
                    close: function () {
                        PageModel.Bind();
                    }
                });
            },
            Delete: function (ActionID) {
                //删除按钮时候还要清空对应权限模块授权的按钮
                var d = { ActionID: ActionID };
                if ($.confirm("删除后不可恢复，确认继续？")) {
                    $.AjaxPostCall(url.ajaxUrl + 'delete', false, d, function (data) {
                        $.RemoveBodyLoading();
                        $.RemoveButtonLoading();

                        PageModel.Bind();
                    });
                }
            }

        };
    </script>
</asp:Content>
