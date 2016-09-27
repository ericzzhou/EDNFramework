<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Control_CheckUserLogin.ascx.cs" Inherits="DotNet.Framework.Admin.UI.Controls.Control_CheckUserLogin" %>
<script>
    $(function () {
        $.ajax({
            async: true,
            dataType: "JSON",
            type: "GET",
            url: '<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/Pages/ajax.ashx?ajax=chacklogin',
             data: {},
             success: function (data) {
                 if (!data || data.status == 'false')
                 {
                     top.location.href = '<%:DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath%>/login.aspx'
                    }
                }
         });
     });
</script>
