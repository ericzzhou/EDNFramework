<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin.Master" AutoEventWireup="true" CodeBehind="search_detail.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Norm.Item.search_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <input type="hidden" id="categoryId" name="categoryId" value="<%=Request["categoryid"] %>" />
    <div id="MessageBox" class="alert alert-business ">
        起始时间：<input type="text" id="txt_startTime" style="width: 100px;" />
        结束时间：<input type="text" id="txt_endTime" style="width: 100px;" />
        科室：<select id="sel_Department" style="width: 100px;">
            <option value="0">全部科室</option>
        </select>
        指标目录：<select id="sel_normItem" style="width: 100px;">
            <option value="0">全部指标</option>
        </select>
        <%--input-medium search-query --%>
        <input type="button" id="btn_Search" class="btn-loading" value="查询" />
    </div>

    <div>
        <EDNFramework:Messagebox ID="Messagebox1" runat="server" />
    </div>


    <div id="grid_Item">
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
</asp:Content>
