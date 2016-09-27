<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Control_MessageBox.ascx.cs" Inherits="DotNet.Framework.Admin.UI.Controls.Control_MessageBox" %>
<div id="MessageBox" class="alert fade in MessageBox" style="display:none;">
    <%--<button type="button" class="close" onclick="$('.MessageBox').fadeOut();">&times;</button>--%>
    <a href="javascript:void(0);" class="close" onclick="$('.MessageBox').fadeOut();">×</a>
    <strong>提示信息.</strong>
</div>
