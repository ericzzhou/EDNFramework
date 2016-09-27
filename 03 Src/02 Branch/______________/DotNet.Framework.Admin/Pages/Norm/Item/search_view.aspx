<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin.Master" AutoEventWireup="true" CodeBehind="search_view.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Norm.Item.search_view" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Libs/zTreeV3.5.14/css/zTreeStyle/zTreeStyle.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <input type="hidden" id="categoryId" name="categoryId" value="<%=Request["categoryid"] %>" />
    <div id="MessageBox" class="alert alert-business ">
        起始时间：<input type="text" id="txt_startTime" style="width: 70px;" />
        结束时间：<input type="text" id="txt_endTime" style="width: 70px;" />
        <input type="hidden" id="hidDepartment" />
        科室：<input type="text" id="showDepartment" style="width: 65px;" readonly="true" />
        <a id="menuBtn" href="#">选择</a>
        <%--<select id="sel_Department" style="width: 100px;">
            <option value="0">全部科室</option>
        </select><a id="showDepartment">选择</a>--%>
        指标目录：<select id="sel_normItem" style="width: 120px;">
            <option value="0">选择指标目录</option>
        </select>
        <%--input-medium search-query --%>
        <input type="button" id="btn_Search" class="btn-loading" value="查询" />
    </div>

    <div>
        <EDNFramework:Messagebox ID="Messagebox1" runat="server" />
    </div>


    <div id="grid_Item">
        <table class="table table-striped table-bordered table-hover <%--table-condensed--%>">
            <tbody>

                <tr>
                    <td>请选择条件检索到数据</td>
                </tr>
            </tbody>
        </table>
    </div>
    <div id="menuContent" class="alert alert-business" style="display: none; position: absolute;">
        <ul id="departmentMenu" class="ztree" style="margin-top: 0; width: 180px;"></ul>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Libs/zTreeV3.5.14/js/jquery.ztree.core-3.5.min.js"></script>
    <script src="<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Libs/zTreeV3.5.14/js/jquery.ztree.excheck-3.5.min.js"></script>

</asp:Content>
