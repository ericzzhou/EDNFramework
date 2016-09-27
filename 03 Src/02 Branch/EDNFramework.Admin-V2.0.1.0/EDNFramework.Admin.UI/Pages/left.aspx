<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="DotNet.Framework.Admin.UI.Pages.left" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <title></title>
    <link href="../Resource/Libs/jquery-ui/bundle/themes/ui-lightness/jquery.ui.all.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body {
            font-family: "Helvetica Neue", Helvetica, Arial, sans-serif;
            font-size: 12px;
        }

        .ui-accordion .ui-accordion-content {
            /*padding: 0.5em 0.5em;*/
            padding-top: 0.5em;
            padding-left: 0.5em;
            padding-right: 0.5em;
            padding-bottom: 1em;
        }

        #accordion > div > div {
            width: 90%;
            height: 35px;
            line-height: 35px;
            margin-left: 0;
            margin-right: 0;
            padding-left: 1em;
            margin: 0 auto;
        }

        .accordion_menu_selected {
            background-color: rgb(30, 113, 177);
            color: #fff;
            padding-left: 1em;
        }

        #accordion > div > div:hover {
            background-color: rgb(88, 149, 185);
            color: #fff;
            padding-left: 1em;
        }
    </style>
    <script src="<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Scripts/jquery-1.7.2.min.js"></script>
    <script src="<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Libs/jquery-ui/js/jquery-ui.min.js"></script>
    <script src="<%=DotNet.Framework.Admin.Core.Config.ConfigHelper.ResourcePath %>/Resource/Scripts/json2.js"></script>
    <script type="text/javascript">
        var myLayout;

        $(function () {
            $("#accordion").height($(window).height() - 50);

            $("#accordion").accordion({
                heightStyle: "fill"
            });


            $("#accordion div div").each(function () {
                $(this).click(function () {
                    $("#accordion div div").removeClass("accordion_menu_selected");
                    $(this).addClass("accordion_menu_selected");
                });
            });
            $("#accordion div div").click(function () {
                var href = $(this).attr("data-href");
                var frameid = top.document.getElementById("iframe_main");
                frameid.src = href;

                return;
            });
        });
    </script>

</head>
<body>

    <div id="accordion">
        <%=HtmlPermission %>
    </div>
</body>
</html>
