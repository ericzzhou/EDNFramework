<%@ Page Title="" Language="C#" MasterPageFile="../../../Pages/Dialog.Master" AutoEventWireup="true" CodeBehind="AssignedTo.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.Repairs.Order.AssignedTo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <EDNFramework:BreadCrumb ID="BreadCrumb1" runat="server" BreadCrumbContent="报修系统 > 订单指派" />
    <br />
    <div class="tab-content">
        <div class="tab-pane active form-horizontal" id="info">
            <div class="control-group">
                <label class="control-label" for="users">处理人：</label>
                <div class="controls">
                    <select id="users">
                    </select>
                </div>
            </div>
             <div class="control-group">
                <label class="control-label" for="makedate">日期：</label>
                <div class="controls">
                    <input type="text" id="makedate" name="makedate" value="<%=DateTime.Now.ToString("yyyy-MM-dd") %>" />
                </div>
            </div>
             <div class="control-group">
                <label class="control-label" for="maketime">时间：</label>
                <div class="controls">
                  <input type="text" id="maketime" name="maketime" value="<%=DateTime.Now.ToString("HH:mm:ss") %>"/>
                </div>
            </div>
        </div>

        <EDNFramework:Messagebox ID="Messagebox1" runat="server" />

        <div class="footer-actions taab-pane" id="footer">
            <input type="button" id="btn_save" class="btn btn-primary btn-loading " value="保存" />
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="floor" runat="server">
    <script>
        var url = {
            ajaxUrl: '<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.AjaxPath%>/Repairs/Order.ashx?ajax='
        };
        $(function () {
            PageModel.Init();
        });

        var PageModel = {
            Init: function () {
                var _self = this;

                $.AjaxGet(url.ajaxUrl + "assignedtos", false, {}, function (data) {
                    var helper = new bind("#users", data);
                    helper.bindselect("NickName", "UserID", 0, "请选择", 0);
                    $.RemoveButtonLoading();
                    $.RemoveBodyLoading();
                });


                $("#btn_save").click(function () {
                    var touser = $("#users").val();
                    var makedate = $("#makedate").val();
                    var maketime = $("#maketime").val();
                    var orderid = <%=Request["id"]%>
                    $.AjaxPost(url.ajaxUrl + 'changeorderstatus', false, { status: 2, userid: touser, orderid: orderid, makedate: makedate, maketime: maketime });

                });
            }
        };
    </script>
</asp:Content>
