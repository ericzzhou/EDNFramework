<%@ Page Title="" Language="C#" MasterPageFile="../../Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Account.User.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <div class="container">
        <div class="widget">
            <div class="widget-header">
                <i class="icon-user"></i>
                <h3>用户管理</h3>
                <input type="button" id="btn_add" value="添加" class="btn" />
            </div>
            <div class="widget-content">
                <EDNFramework:Messagebox ID="Messagebox2" runat="server" />
                <div class="tab-content action-table ">
                    <table id="t" class="table table-striped table-bordered dataTable">
                        <thead>
                            <tr>
                                <th style="width: 40px; text-align: center;">编号</th>
                                <th>用户名</th>
                                <th>昵称</th>
                                <th>性别</th>
                                <th>电话</th>
                                <th>邮件</th>
                                <th>状态</th>
                                <th style="width: 100px; text-align: center;">操作</th>
                            </tr>
                        </thead>
                        <tbody id="t_body">
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script>


        $(document).ready(function () {
            PageModel.Bind();
            PageModel.AppendEvent();

        });


        var tbl;
        var PageModel = {
            sAjaxSource: 'Index.aspx?ajax=getlist',
            editAjaxSource: '',
            data: {},
            RowDelete: function (id) {
                _self = this;
                if ($.Confirm('删除后不可恢复，确定要删除么？')) {
                    $.AjaxPostCall('?ajax=deletemodel', true, { id: id }, function (data) {
                        if (data.result && data.result.error) {
                            $.RemoveBodyLoading();
                            $.RemoveButtonLoading();
                            $.AlertAutoClose(data.result.error);
                        }
                        else {
                            _self.Bind();
                            $.AlertAutoClose('删除成功');
                        }
                    });
                }
            },
            AppendEvent: function () {
                _self = this;

                $("#btn_add").click(function () {
                    window.location.href = 'add.aspx';
                });

            },
            Bind: function () {
                _self = this;
                tbl = $('.dataTable').dataTable({
                    "bDestroy": true,//屏蔽错误提示
                    "bProcessing": false,
                    'bPaginate': true,
                    'bLengthChange': false,
                    'sPaginationType': 'full_numbers',
                    'bFilter': false,
                    'sAjaxSource': _self.sAjaxSource,
                    "oLanguage": {
                        "sLengthMenu": "每页显示 _MENU_ 条记录",
                        "sZeroRecords": "对不起，查询不到任何相关数据",
                        "sInfo": "当前显示 _START_ 到 _END_ 条，共 _TOTAL_ 条记录",
                        "sInfoEmtpy": "找不到相关数据",
                        //"sInfoFiltered": "数据表中共为 _MAX_ 条记录",  
                        "sProcessing": "正在加载中...",
                        "sSearch": "搜索",
                        "sInfoEmpty": "显示 0 至 0 共 0 项",
                        "oPaginate": { "sFirst": "第一页", "sPrevious": "上一页 ", "sNext": "下一页 ", "sLast": "末页 " }
                    },

                    "aoColumns": [
                                { "mData": "UserID" },
                                { "mData": "UserName" },
                                { "mData": "NickName" },
                                { "mData": "Sex" },
                                { "mData": "Phone" },
                                { "mData": "Email" },//"Activity"
                                {
                                    "mData": null,
                                    'fnRender': function (obj) {
                                        var cla = "label";
                                        var val = '激活';
                                        if (!obj || !obj.aData || !obj.aData.Activity) {
                                            var cla = "label label-warning";
                                            var val = '冻结';
                                        }
                                        return '<span class="' + cla + '">' + val + '</span>';
                                    }
                                },
                                {
                                    "mData": null,
                                    "fnRender": function (obj) {
                                        var UserID = obj.aData.UserID;

                                        var html = "";
                                        html += "<a title=\"编辑\" href=\"edit.aspx?id=" + UserID + "\" class=\"btn btn-small btn-warning btn-row-edit\">";
                                        html += "<i class=\"btn-icon-only icon-edit\"></i>";
                                        html += "</a> ";
                                        html += "<a href=\"javascript:;\" onclick=\"PageModel.RowDelete('" + UserID + "');\" class=\"btn btn-small\">";
                                        html += "<i class=\"btn-icon-only icon-remove\"></i>";
                                        html += "</a> ";

                                        html += "<a title=\"角色\" href=\"SetRole.aspx?id=" + UserID + "\" class=\"btn btn-small\">";
                                        html += "角色";
                                        html += "</a>";

                                        return html;
                                    }
                                }

                    ],
                    'fnInitComplete': function () {
                        $.RemoveButtonLoading();
                        $.RemoveBodyLoading();
                    }
                });
            }
        };
    </script>
</asp:Content>
