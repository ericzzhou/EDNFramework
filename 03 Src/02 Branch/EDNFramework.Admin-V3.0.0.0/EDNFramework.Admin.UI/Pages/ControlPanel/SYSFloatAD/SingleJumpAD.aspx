<%@ Page Title="" Language="C#" MasterPageFile="../../Admin.Master" AutoEventWireup="true" CodeBehind="SingleJumpAD.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.ControlPanel.SYSFloatAD.SingleJumpAD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%=DotNet.Framework.WebTools.Editor.CreateCss()%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="控制面板 > 弹跳广告" />
    <EDNFramework:Info ID="Info1" runat="server" Text_Strong="网页浮动广告配置" Text_Normal="注意：请慎重修改此数据" />
    <EDNFramework:Messagebox ID="Messagebox2" runat="server" />

    <table id="tb_form" class="table table-striped table-bordered table-hover">
        <thead>
            <tr>
                <th colspan="2">弹跳广告维护</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>宽度</td>
                <td>
                    <input type="text" name="Width" />
                </td>

            </tr>
            <tr>
                <td>高度</td>
                <td>
                    <input type="text" name="Height" /></td>

            </tr>

            <tr>
                <td>状态</td>
                <td>
                    <label class="checkbox inline">
                        <input type="checkbox" checked="checked" name="Enable" id="Enable" />启用
                    </label>
                </td>

            </tr>
            <tr style="display: none;">
                <td>内容类型</td>
                <td>
                    <label class="radio inline">
                        <input type="radio" checked="checked" name="ContentType" id="ContentType_Font" value="font" />文字
                    </label>
                    <label class="radio inline">
                        <input type="radio" name="ContentType" id="ContentType_Img" value="image" />图片
                    </label>

                </td>

            </tr>
            <tr>
                <td>广告内容</td>
                <td></td>

            </tr>
            <tr>
                <td colspan="2">
                    <textarea style="width: 98%; height: 300px;" rows="10" name="Content" id="ad_Content"></textarea>

                </td>

            </tr>
        </tbody>
    </table>
    <div class="footer-actions taab-pane">
        <input type="button" id="btn_save" class="btn btn-primary btn-loading " value="保存" />

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <%=DotNet.Framework.WebTools.Editor.CreateJs()%>
    <script>
        <%=DotNet.Framework.WebTools.Editor.CreateEditor("edit_ad_Content","#ad_Content")%>
        var url = {
            ajaxUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.AjaxPath%>/ControlPanel/SYSFloatAD.ashx?ajax='
        };

        var pageModel = {
            Load:function(){
                $.AjaxGet(url.ajaxUrl + 'loadjumpad', false, {}, function (d) {

                    $.RemoveButtonLoading();
                    $.RemoveBodyLoading();
                   

                    var helper = new bind("#tb_form", d);
                    helper.bindform();
                    edit_ad_Content.html(d.Content);
                });
            },
            Event:function(){
                $("#btn_save").click(function(){
                    edit_ad_Content.sync();
                    var helper = new bind("#tb_form");
                    var data =helper.getformdata();
                    data.Content = edit_ad_Content.html();
                    $.AjaxPost(url.ajaxUrl + 'savejumpad', false, JSON.stringify(data));
                });
            }
        };
        $(function () {
            pageModel.Event();
            pageModel.Load();
           
        });
    </script>
</asp:Content>
