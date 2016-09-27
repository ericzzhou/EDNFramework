<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Control_TreeMenu.ascx.cs" Inherits="DotNet.Framework.Admin.WebUI.Controls.Control_TreeMenu" %>

<nav>
   
    <!-- NOTE: Notice the gaps after each icon usage <i></i>..
				Please note that these links work a bit different than
				traditional hre="" links. See documentation for details.
				-->
     
    <ul>
        <%=HtmlSiteMapPath %>
        
    </ul>
</nav>
<script>
    $(function () {
        var menu_id = '<%=Menu %>';
        if (menu_id != "") {
            $("#menu_" + menu_id).addClass("active")
        }
    });
</script>