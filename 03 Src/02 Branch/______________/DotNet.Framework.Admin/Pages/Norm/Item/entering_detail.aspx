<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin.Master" AutoEventWireup="true" CodeBehind="entering_detail.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Norm.Item.entering_detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <%--<table>
        <tr>
            <td></td>
            <td>运行管理指标1</td>
            <td>运行管理指标2</td>
            <td>运行管理指标3</td>
            <td>运行管理指标4</td>
            <td>运行管理指标5</td>
        </tr>
        <tr>
            <td>CCU病区</td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>产科病区</td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
        <tr>
            <td>儿 科</td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
            <td></td>
        </tr>
    </table>
    <hr />--%>

    <input type="hidden" id="categoryId" name="categoryId" value="<%=Request["categoryid"] %>" />
    <div id="MessageBox" class="alert alert-business ">
        <b>指标发生时间：</b><input type='text' style="width: 100px;" id="OccurrenceTime" name="OccurrenceTime" />
    </div>
    <div id="grid_Item">
    </div>

    <EDNFramework:Messagebox ID="Messagebox1" runat="server" />
    <div class="form-actions tab-pane">
        <input type="button" id="btn_Insert" class="btn btn-primary btn-loading " value="新增" />
        <input type="reset" class="btn" value="重置" />
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
</asp:Content>
