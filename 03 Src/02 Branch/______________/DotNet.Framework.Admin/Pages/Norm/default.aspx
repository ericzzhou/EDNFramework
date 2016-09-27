<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Norm._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Libs/zTreeV3.5.14/css/zTreeStyle/zTreeStyle.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="指标维护 > 类别管理" />


    <div class="span3">
        <div class="widget">
            <div class="widget-header">
                <i class="icon-file"></i>
                <h3>指标分类</h3>
            </div>
            <div class="widget-content">
                <div class="tools_bar-inner">
                    <ul class="tools_bar-container">
                        <li>
                            <a href="javascript:void(0);" onclick="PageModel.AddCategory()">
                                <i class="icon-plus-sign"></i>
                                <span>新增</span>
                            </a>
                            <a href="javascript:void(0);" onclick="PageModel.EditCategory()">
                                <i class="icon-pencil"></i>
                                <span>编辑</span>
                            </a>

                            <a href="javascript:void(0);" onclick="PageModel.DeleteCategory()">
                                <i class="icon-minus-sign"></i>
                                <span>删除</span>
                            </a>


                        </li>
                    </ul>
                </div>
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
    <div id="div_input">
        <div class="widget">
            <div class="widget-header">
                <i class="icon-bookmark"></i>
                <h3 id="p_title">指标目录</h3>
            </div>
            <EDNFramework:Messagebox ID="Messagebox1" runat="server" />
            <div class="widget-content" id="NormContent" style="height: 512px">
                <iframe width="100%" height="512" frameborder="0" style="display: block;" id="frame_page" name="frame_page" src=""></iframe>
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
    <script src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Libs/zTreeV3.5.14/js/jquery.ztree.core-3.5.min.js"></script>
    <script>
        $(function () {
            $("#div_input").css({ width: document.body.clientWidth - 240 + "px", float: "right" });
            $(window).resize(function () {
                $("#div_input").css({ width: document.body.clientWidth - 240 + "px", float: "right" });
            })
        });

    </script>

</asp:Content>
