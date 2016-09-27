<%@ Page Title="" Language="C#" MasterPageFile="../../Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.ControlPanel.SYSFloatAD.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="控制面板 > 浮动广告" />
    <EDNFramework:Info ID="Info1" runat="server" Text_Strong="网页浮动广告配置" Text_Normal="注意：请慎重修改此数据" />
    <EDNFramework:Messagebox ID="Messagebox2" runat="server" />

    <table id="tb_form" class="table table-striped table-bordered table-hover">
        <thead>
            <tr>
                <th colspan="2">左侧广告</th>
                <th colspan="2">右侧广告</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>宽度</td>
                <td>
                    <input type="text" name="Left_Width" />
                </td>
                <td>宽度</td>
                <td>
                    <input type="text" name="Right_Width" /></td>
            </tr>
            <tr>
                <td>高度</td>
                <td>
                    <input type="text" name="Left_Height" /></td>
                <td>高度</td>
                <td>
                    <input type="text" name="Right_Height" /></td>
            </tr>
            <tr>
                <td>左侧距离</td>
                <td>
                    <input type="text" name="Left_left" /></td>
                <td>右侧距离</td>
                <td>
                    <input type="text" name="Right_right" /></td>
            </tr>
            <tr>
                <td>顶部距离</td>
                <td>
                    <input type="text" name="Left_top" /></td>
                <td>顶部距离</td>
                <td>
                    <input type="text" name="Right_top" /></td>
            </tr>
            <tr>
                <td>状态</td>
                <td>
                    <label class="checkbox inline">
                        <input type="checkbox" checked="checked" name="Left_Enable" id="Left_Enable" />启用
                    </label>
                </td>
                <td>状态</td>
                <td>
                    <label class="checkbox inline">
                        <input type="checkbox" checked="checked" name="Right_Enable" id="Right_Enable" />启用
                    </label>
                </td>
            </tr>
            <tr>
                <td>广告内容</td>
                <td></td>
                <td>广告内容</td>
                <td></td>
            </tr>
            <tr>
                <td colspan="2">
                    <textarea style="width: 98%;" rows="5" name="Left_Body"></textarea></td>
                <td colspan="2">
                    <textarea style="width: 98%;" rows="5" name="Right_Body"></textarea></td>
            </tr>

        </tbody>
    </table>
    <div class="footer-actions taab-pane">
        <input type="button" id="btn_save" class="btn btn-primary btn-loading " value="保存" />

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script>
        var url = {
            ajaxUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.AjaxPath%>/ControlPanel/SYSFloatAD.ashx?ajax='
        };
        $(function () {
            var helper = new bind("#tb_form",<%=json%>);
            helper.bindform(); 

            $("#btn_save").click(function(){
                var data =helper.getformdata();
                $.AjaxPost(url.ajaxUrl + 'save', false, JSON.stringify(data));
            });
        });
    </script>
</asp:Content>
