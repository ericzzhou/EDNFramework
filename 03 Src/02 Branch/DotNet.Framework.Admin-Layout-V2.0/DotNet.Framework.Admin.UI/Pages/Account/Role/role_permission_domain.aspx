<%@ Page Title="" Language="C#" MasterPageFile="../../Admin.Master" AutoEventWireup="true" CodeBehind="role_permission_domain.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Account.Role.role_permission_domain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">

    <EDNFramework:Messagebox ID="Messagebox2" runat="server" />
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

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script>
        $(function () {
            $("#btn_save").click(function () {
                var data = {};
                $('input[name="ckPermission"]:checked').each(function (i) {
                    data[i] = $.trim($(this).val());
                });
                
                $.AjaxPost('?ajax=savepermission', true, { pcodes:JSON.stringify(data), roleid: <%=Request["roleid"]%> });
                
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
        });
    </script>
</asp:Content>
