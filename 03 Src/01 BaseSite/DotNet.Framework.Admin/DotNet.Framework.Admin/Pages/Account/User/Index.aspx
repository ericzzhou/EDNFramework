<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Account.User.Index" %>

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
