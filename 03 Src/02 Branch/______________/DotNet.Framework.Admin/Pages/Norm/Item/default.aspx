<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Dialog.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Norm.Item._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="tab-content">
        <input type="hidden" value="<%=Request["categoryid"] %>" id="categoryid" />
        <div class="tools_bar-inner">
            <ul class="tools_bar-container">
                <li>
                    <a href="javascript:void(0);" onclick="PageModel.AddNormItem()">
                        <i class="icon-plus-sign"></i>
                        <span>新增</span>
                    </a>
                    <a href="javascript:void(0);" onclick="PageModel.EditNormItem()">
                        <i class="icon-pencil"></i>
                        <span>编辑</span>
                    </a>

                    <a href="javascript:void(0);" onclick="PageModel.RowDelete()">
                        <i class="icon-minus-sign"></i>
                        <span>删除</span>
                    </a>
                     <a href="javascript:void(0);" onclick="PageModel.StopNormItem()">
                        <i class="icon-minus-sign"></i>
                        <span>停用</span>
                    </a>
                      <a href="javascript:void(0);" onclick="PageModel.StartNormItem()">
                        <i class="icon-minus-sign"></i>
                        <span>启用</span>
                    </a>
                </li>
            </ul>
        </div>
        <EDNFramework:Messagebox ID="Messagebox2" runat="server" />
        <div id="grid_Item" class="tab-content action-table ">
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
</asp:Content>
