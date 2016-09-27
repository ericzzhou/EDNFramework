<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="DotNet.Framework.Admin.Pages.Account.Role._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph" runat="server">
         <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="系统安全 > 角色维护" />

    <EDNFramework:ToolsBar ID="ToolsBar" runat="server"
        Insert_Fun="PageModel.Insert()"
        Modify_Fun="PageModel.RowClick()"
        Detail_Fun="PageModel.ShowDetail()"
        Delete_Fun="PageModel.RowDelete()"
        disable_Clear="true" disable_Detail="true" />
    <EDNFramework:Messagebox ID="Messagebox2" runat="server" />
    <div id="grid_json" class="tab-content action-table ">
        </div>
    </div>
    <div class="container">
        <div class="modal hide fade" id="EditModal">
            <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                <h3>对话框标题</h3>
            </div>
            <div class="modal-body">
                <div class="tab-content">
                    <div class="tab-pane active form-horizontal" id="info">

    <div class="modal hide fade" id="EditModal">
        <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
            <h3>对话框标题</h3>
        </div>
        <div class="modal-body">
            <div class="tab-content">
                <div class="tab-pane active form-horizontal" id="info">

                        </div>
                            </div>
                        </div>

                    </div>
                <EDNFramework:Messagebox ID="Messagebox1" runat="server" />

                </div>
            </div>
        <div class="modal-footer">

            <input type="button" class="btn btn-modal-close" value="关闭" />
            <input type="button" value="保存" class="btn btn-primary btn-modal-save" />

        </div>
    </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
</asp:Content>
