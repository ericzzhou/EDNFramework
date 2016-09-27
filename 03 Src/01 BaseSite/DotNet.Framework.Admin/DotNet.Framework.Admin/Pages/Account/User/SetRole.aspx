<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin.Master" AutoEventWireup="true" CodeBehind="SetRole.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Account.User.SetRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
    <div class="container">
        <div class="widget">
            <div class="widget-header">
                <i class="icon-user"></i>
                <h3>设置角色</h3>
                <input type="button" id="btn_Save" value="保存" class="btn" />
            </div>
            <div class="widget-content">
                <EDNFramework:Messagebox ID="Messagebox2" runat="server" />
                <div class="tab-content action-table">
                    <table id="t" class="table table-striped table-bordered dataTable ">
                        <thead>
                            <tr>
                                <th style="width: 20px; text-align: center;">
                                    <input type="checkbox" id="title-table-checkbox" name="title-table-checkbox" />
                                </th>
                                <th style="width: 50px; text-align: center;">编号</th>
                                <th style="width: 200px;">角色</th>

                                <th>描述</th>
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
</asp:Content>
