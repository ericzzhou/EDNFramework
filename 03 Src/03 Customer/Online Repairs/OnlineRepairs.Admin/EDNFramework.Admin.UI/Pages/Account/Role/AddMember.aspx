<%@ Page Title="" Language="C#" MasterPageFile="../../Dialog.Master" AutoEventWireup="true" CodeBehind="AddMember.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Account.Role.AddMember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <div class="widget">
        <div class="widget-header">
            <i class="icon-file"></i>
            <h3><%=RoleNameString%>[<%=Request["rid"] %>]；想拥有成员（请点击勾选）</h3>
        </div>
        <div class="widget-content">
            <div class="bs-docs-sidebar" id="user-content">
            </div>


        </div>
    </div>
    <EDNFramework:Messagebox ID="Messagebox2" runat="server" />
    <div class="footer-actions taab-pane" id="footer" style="text-align: center;">
        <button class="btn btn-primary btn_loading" type="button" id="btn_save">保存</button>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script>
        var url = {
            ajaxUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.AjaxPath%>/Account/Role.ashx?ajax='
        };
        $(function () {
            var users = <%=users%>;
            var roleId = <%=Request["rid"] %>;
            var html ="";
            if (users.length > 0) {
                $("#btn_save").removeAttr("disabled");
            }
            else {
                $("#btn_save").attr("disabled","disabled");
            }
            if (users.length>0) {
                $.each(users,function(key,item){
                    html+="<label class=\"checkbox\">";
                    html+="<input type=\"checkbox\" value=\""+item.UserID+"\">"+item.UserName;
                    html+="</label>";
                });
            }
            $("#user-content").html(html);

            $("#btn_save").click(function(){
                var cbs = $("#user-content :checkbox:checked"); 
                var cbs_str = '';
                cbs.each(function(i){
                    if (i >0) {
                        cbs_str +=",";
                    }
                    cbs_str +=$(this).val();
                });
                if (cbs_str != "") {
                    $.AjaxPost(url.ajaxUrl+'addmember', false,{rid:roleId,users:cbs_str});
                }
                else{
                    $.ShowMessage("请选择要添加的成员","alert-warning");
                }
            });
        });
    </script>
</asp:Content>
